using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuestPasswordManager.Properties;
using GuestPasswordManager.Support;

namespace GuestPasswordManager
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Reference to logger
        /// </summary>
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Worker thread to fetch users for the list box.
        /// </summary>
        private BackgroundWorker fetchUsersWorker = new BackgroundWorker();

        /// <summary>
        /// All loaded user objects from the specified OU.
        /// </summary>
        private IEnumerable<GuestUser> users;

        /// <summary>
        /// The user on which to operate.
        /// </summary>
        private GuestUser user;

        /// <summary>
        /// The new password generated.
        /// </summary>
        private string newPassword = "";

        /// <summary>
        /// Whether or not the background password set operation completed successfully.
        /// </summary>
        private bool? passwordSetSucceeded = null;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Tool strip button to open the configuration dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void configureButton_Click(object sender, EventArgs e)
        {
            configureButton.Enabled = false;
            configureButton.Text = "Loading config...";
            ToggleProgressAnimation(true);
            new ConfigureForm(this).ShowDialog();
            configureButton.Enabled = true;
            configureButton.Text = "Configure...";
            ToggleProgressAnimation(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            Logger.Info($"Start up at {DateTime.Now} -- {Assembly.GetExecutingAssembly().FullName}");

            // migrate settings
            if (Settings.Default.UpgradeRequired)
            {
                Settings.Default.Upgrade();
                Settings.Default.UpgradeRequired = false;
                Settings.Default.Save();
            }

            fetchUsersWorker.DoWork += FetchUsersWorkerOnDoWork;
            fetchUsersWorker.RunWorkerCompleted += (o, args) =>
            {
                if (users != null && users.Any())
                {
                    chooseAccountBox.Items.Clear();
                    foreach (GuestUser eachUser in users)
                    {
                        chooseAccountBox.Items.Add(eachUser);
                    }
                }
            };
            fetchUsersWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Reload the UI after changes on the configuration screen.
        /// </summary>
        public void ReloadUI()
        {
            Logger.Info($"Reload UI at {DateTime.Now}");
            if (!fetchUsersWorker.IsBusy)
            {
                fetchUsersWorker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Get users from the specified OU ready to add to the list box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="doWorkEventArgs"></param>
        private void FetchUsersWorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            try
            {
                users =
                    GuestUser.LoadGuestUsers(Properties.Settings.Default["LDAPSearchBase"].ToString());
            }
            catch (Exception e)
            {
                Logger.Warn($"Failed to load guest users from {Properties.Settings.Default["LDAPSearchBase"]} -- {e}");
            }
        }

        /// <summary>
        /// When the user changes the selected item in the list box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chooseAccountBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (users == null)
            {
                Logger.Info("No users to select -- users is null");
                return;
            }

            if (!users.Any())
            {
                Logger.Info("No users to select");
                return;
            }

            // match user
            try
            {
                user = users.Single((theUser =>
                    (theUser.ADUser.SamAccountName == (sender as ComboBox).SelectedItem.ToString())));
                disableButton.Enabled = true;
                generatePassword.Enabled = true;
                UpdateStatusLabel();
            }

            catch (Exception ex)
            {
                Logger.Warn($"Failed to match the user selected to a GuestUser object -- {ex}");
            }


            passwordRevealBox.Text = "";
            adUsername.Text = user.ADUser.SamAccountName;

            revealButton.Enabled = false;
            printButton.Enabled = false;

            passwordRevealBox.Enabled = true;
            passwordRevealBox.ReadOnly = true;


            adUsername.Enabled = true;
            adUsername.ReadOnly = true;
        }

        /// <summary>
        /// Update the label which shows the user status.
        /// </summary>
        private void UpdateStatusLabel()
        {
            if (user == null)
            {
                Logger.Info($"Will not update status label for null user");
                return;
            }

            accountStatusLabel.Enabled = true;
            accountStatusLabel.Text = $"Enabled: {user.Enabled}";

            if (user.Enabled != null && (bool)user.Enabled)
            {
                disableButton.Text = "&Disable";
            }
            else if (user.Enabled != null)
            {
                disableButton.Text = "Enable";
            }
        }

        /// <summary>
        /// Toggle the account enabled/disabled state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void disableButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (user == null)
                {
                    NotifyUserIsNull();
                    return;
                }

                if (user.Enabled != null)
                {
                    user.Enabled = !user.Enabled;
                }

                user.ADUser.Save();

                UpdateStatusLabel();
            }
            catch (Exception ex)
            {
                ExceptionDetailsDialog exceptionDialog = new ExceptionDetailsDialog(
                    $"Failed to change the user's enabled status. Please check your account has permission to perform this task.",
                    ex);
                exceptionDialog.ShowDialog();
                return;
            }
        }

        /// <summary>
        /// Show a message box when the current user is null and the operation cannot be performed.
        /// </summary>
        private static void NotifyUserIsNull()
        {
            MessageBox.Show("No user is currently selected.", "Cannot Toggle Enabled State", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        /// <summary>
        /// Generate and set the password across AD and SQL.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generatePassword_Click(object sender, EventArgs e)
        {
            if (!generatePassword.Enabled)
            {
                // protect against accidental double-click
                Logger.Info($"Will not run while generatePassword button will be enabled");
                return;
            }

            if (generatePasswordWorker.IsBusy)
            {
                // protect against accidental double invocation of worker
                Logger.Info($"Will not run while generatePasswordWorker is busy");
                return;
            }

            generatePassword.Enabled = false;
            ToggleProgressAnimation(true);
            statusStripLabel.Text = "Generating and setting a password...";

            generatePassword.Text = "Generating...";
            generatePasswordWorker.DoWork += GenerateAndSetPassword;
            generatePasswordWorker.RunWorkerCompleted += delegate
            {
                ToggleProgressAnimation(false);

                if (passwordSetSucceeded != null && (bool)passwordSetSucceeded)
                {
                    passwordRevealBox.Text = newPassword;
                    adUsername.Text = user.ADUser.SamAccountName;

                    revealButton.Enabled = true;
                    printButton.Enabled = true;

                    passwordRevealBox.Enabled = true;
                    passwordRevealBox.ReadOnly = true;


                    adUsername.Enabled = true;
                    adUsername.ReadOnly = true;
                }

                generatePassword.Enabled = true;
                generatePassword.Text = "&Generate Password";
            };
            generatePasswordWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Delegate to show an exception with details to the user from a non-UI thread.
        /// </summary>
        /// <param name="details"></param>
        /// <param name="ex"></param>
        private delegate void ShowExceptionDialogWithDetails(string details, Exception ex);

        /// <summary>
        /// Show an exception dialog to the user.
        /// </summary>
        /// <param name="details"></param>
        /// <param name="ex"></param>
        private void ShowExceptionDialog(string details, Exception ex)
        {
            ExceptionDetailsDialog exceptionDialog =
                new ExceptionDetailsDialog(details, ex);
            exceptionDialog.ShowDialog();
        }

        /// <summary>
        /// Generate and set the password across AD and SQL. Runs in BackgroundWorker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateAndSetPassword(object sender, DoWorkEventArgs e)
        {
            generatePasswordWorker.DoWork -= GenerateAndSetPassword;

            if (user == null)
            {
                NotifyUserIsNull();
                passwordSetSucceeded = false;
                return;
            }

            try
            {
                int passwordLength = Int32.Parse(Properties.Settings.Default["PasswordLength"].ToString());
                newPassword = GuestUser.GenerateRandomPassword(passwordLength);
            }
            catch (Exception ex)
            {
                Invoke(new ShowExceptionDialogWithDetails(ShowExceptionDialog), "Unable to generate the password.", ex);
                passwordSetSucceeded = false;
                return;
            }

            try
            {
                user.SetPassword(newPassword);
            }
            catch (Exception ex)
            {
                Invoke(new ShowExceptionDialogWithDetails(ShowExceptionDialog),
                    $"There was a problem setting the user's password. Check that your user account has been delegated permission to change the user's password.",
                    ex);
                passwordSetSucceeded = false;
                return;
            }

            passwordSetSucceeded = true;
        }

        /// <summary>
        /// Reveal the generated password.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void revealButton_Click(object sender, EventArgs e)
        {
            if (passwordRevealBox.UseSystemPasswordChar)
            {
                passwordRevealBox.UseSystemPasswordChar = false;
                revealButton.Text = "Conceal";
            }
            else
            {
                passwordRevealBox.UseSystemPasswordChar = true;
                revealButton.Text = "Reveal";
            }
        }

        /// <summary>
        /// Show the about box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutBoxButton_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        /// <summary>
        /// Set up a print preview for the user details.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printButton_Click(object sender, EventArgs e)
        {
            ToggleProgressAnimation(true);
            printUserDetails.DocumentName =
                Assembly.GetExecutingAssembly().FullName + " " + DateTime.Now.ToShortDateString();


            printDetailsPreview.Document = printUserDetails;
            printDetailsDialog.Document = printUserDetails;
            printUserDetails.PrintPage += PrintUserDetails_PrintPage;
            //printDetailsPreview.ShowDialog();
            DialogResult result = printDetailsDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Logger.Info($"Print dialog returned OK");
                printUserDetails.Print();
            }

            ToggleProgressAnimation(false);

        }

        /// <summary>
        /// Write the print contents to the print stream.
        /// </summary>
        private void WriteToPrintStream(Stream printStream)
        {
            // set up the stream containing the text to print

            StreamWriter writer = new StreamWriter(printStream);
            writer.WriteLine($"Windows username: {user.ADUser.SamAccountName}");
            writer.WriteLine($"Windows Password: {user.NewPassword}");
            writer.WriteLine("");
            writer.WriteLine("");

            writer.WriteLine($"Email address: {user.EmailAddress}");
            writer.WriteLine($"Use the Windows password for email.");

            writer.WriteLine("");
            writer.WriteLine($"Printed on {DateTime.Now}");
            writer.WriteLine($"Expires on {DateTime.Today.AddDays(1)}");
            writer.WriteLine("");
            writer.WriteLine("");
            writer.WriteLine("Misuse of these details is illegal under the");
            writer.WriteLine("Computer Misuse Act 1990.");
            writer.WriteLine("");
            writer.WriteLine("If found, return to Test Valley School,");
            writer.WriteLine("SO20 6HA.");
            writer.Flush();

        }

        /// <summary>
        /// Print the user details.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintUserDetails_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs ev)
        {
            Font printFont = new Font("Consolas", 18);
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string line = null;

            using (MemoryStream printStream = new MemoryStream())
            {
                WriteToPrintStream(printStream);

                printStream.Position = 0; //rewind the stream
                using (StreamReader reader = new StreamReader(printStream))
                {
                    // Calculate the number of lines per page.
                    linesPerPage = ev.MarginBounds.Height /
                                   printFont.GetHeight(ev.Graphics);

                    // Print each line of the file.
                    while (count < linesPerPage &&
                           ((line = reader.ReadLine()) != null))
                    {
                        yPos = topMargin + (count *
                                            printFont.GetHeight(ev.Graphics));
                        ev.Graphics.DrawString(line, printFont, Brushes.Black,
                            leftMargin, yPos, new StringFormat());
                        count++;
                    }

                    // If more lines exist, print another page.
                    if (line != null)
                    {
                        ev.HasMorePages = true;
                    }
                    else
                    {
                        ev.HasMorePages = false;
                    }
                }
            }

        }

        /// <summary>
        /// Show a print preview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printPreviewButton_Click(object sender, EventArgs e)
        {
            printDetailsPreview.Document = printUserDetails;
            using (MemoryStream printStream = new MemoryStream())
            {
                WriteToPrintStream(printStream);
            }
            printDetailsPreview.ShowDialog();
        }

        /// <summary>
        /// Animate or 'un-animate' the progress bar.
        /// </summary>
        private void ToggleProgressAnimation(bool? force = null, [CallerMemberName] string caller = "")
        {
            Logger.Debug($"{MethodBase.GetCurrentMethod().Name}: Invoked by {caller}");
            if (force == null)
            {
                progressBar.Visible = !progressBar.Visible;
            }
            else
            {
                progressBar.Visible = (bool)force;
                statusStripLabel.Text = "Ready";
            }
        }


    }
}