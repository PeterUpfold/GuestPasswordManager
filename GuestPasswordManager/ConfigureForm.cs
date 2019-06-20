using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuestPasswordManager.Support;

namespace GuestPasswordManager
{
    public partial class ConfigureForm : Form
    {
        /// <summary>
        /// Reference to logger
        /// </summary>
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The form that caused us to open.
        /// </summary>
        protected Form Invoker;

        /// <summary>
        /// Load the users from the OU
        /// </summary>
        private BackgroundWorker loadUsersWorker = new BackgroundWorker();

        public ConfigureForm()
        {
            InitializeComponent();
        }

        public ConfigureForm(Form invoker)
        {
            Invoker = invoker;
            InitializeComponent();
        }

        private void ConfigureForm_Load(object sender, EventArgs e)
        {

            if (Properties.Settings.Default["LDAPSearchBase"] != null)
            {
                Logger.Info($"Existing LDAP search base is {Properties.Settings.Default["LDAPSearchBase"]}");
                try
                {
                    adPicker.ADsPath = (string)Properties.Settings.Default["LDAPSearchBase"];
                    // we will run UpdateADPreviewLabel() later (not yet bound to events)
                }
                catch (Exception ex)
                {
                    Logger.Error($"Failed to set AD picker LDAP path to {Properties.Settings.Default["LDAPSearchBase"]} -- {ex}");
                }
            }

            adPicker.AfterSelect += UpdateADPreviewLabel();
            adPicker.AfterExpand += UpdateADPreviewLabel();

            loadUsersWorker.WorkerSupportsCancellation = true;
            loadUsersWorker.DoWork += LoadUsersDoWork;
            loadUsersWorker.RunWorkerCompleted += LoadUsersCompleted;

            if (Properties.Settings.Default["LDAPSearchBase"] != null)
            {
                // fire now to populate the preview of user count from the pre-saved search base
                UpdateADPreviewLabel().Invoke();
            }
        }

        /// <summary>
        /// Completed loading the users from the OU
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadUsersCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Properties.Settings.Default["LDAPSearchBase"] = adPicker.ADsPath;
        }

        /// <summary>
        /// Load the users from the OU
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadUsersDoWork(object sender, DoWorkEventArgs e)
        {
            IEnumerable<GuestUser> users = GuestUser.LoadGuestUsers(adPicker.ADsPath);

            foundUsersLabel.Invoke((MethodInvoker)(() => foundUsersLabel.Text = $"Found {users.Count()} users in {adPicker.ADsPath}"));
        }

        /// <summary>
        /// Update 
        /// </summary>
        /// <returns></returns>
        private Action UpdateADPreviewLabel()
        {
            return delegate
            {
                if (loadUsersWorker.IsBusy)
                {
                    return;
                }
                foundUsersLabel.Text = $"Enumerating users...";
                loadUsersWorker.RunWorkerAsync();
            };
        }

        private void passwordLengthBox_ValueChanged(object sender, EventArgs e)
        {

        }

        private void passwordLengthLabel_Click(object sender, EventArgs e)
        {

        }

        private void Configuration_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void Configuration_FormClosing(object sender, FormClosingEventArgs e)
        {
            (Parent as MainForm)?.ReloadUI();
        }


        private void saveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            if (Invoker is MainForm form)
            {
                form.ReloadUI();
            }
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Logger.Debug(adPicker.TreeView.Nodes.Count);
        }
    }
}
