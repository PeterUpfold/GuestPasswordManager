namespace GuestPasswordManager
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.accountStatusLabel = new System.Windows.Forms.Label();
            this.disableButton = new System.Windows.Forms.Button();
            this.generatePassword = new System.Windows.Forms.Button();
            this.detailsGroup = new System.Windows.Forms.GroupBox();
            this.printPreviewButton = new System.Windows.Forms.Button();
            this.passwordExplanatoryLabel = new System.Windows.Forms.Label();
            this.adUsernameLabel = new System.Windows.Forms.Label();
            this.adUsername = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.revealButton = new System.Windows.Forms.Button();
            this.passwordRevealBox = new System.Windows.Forms.TextBox();
            this.printButton = new System.Windows.Forms.Button();
            this.chooseAccountLabel = new System.Windows.Forms.Label();
            this.chooseAccountBox = new System.Windows.Forms.ComboBox();
            this.mainFormToolStrip = new System.Windows.Forms.ToolStrip();
            this.configureButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutBoxButton = new System.Windows.Forms.ToolStripButton();
            this.printUserDetails = new System.Drawing.Printing.PrintDocument();
            this.printDetailsPreview = new System.Windows.Forms.PrintPreviewDialog();
            this.printDetailsDialog = new System.Windows.Forms.PrintDialog();
            this.generatePasswordWorker = new System.ComponentModel.BackgroundWorker();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.detailsGroup.SuspendLayout();
            this.mainFormToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.accountStatusLabel);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.disableButton);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.generatePassword);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.detailsGroup);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.chooseAccountLabel);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.chooseAccountBox);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(707, 434);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(707, 481);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.mainFormToolStrip);
            // 
            // statusStrip
            // 
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar,
            this.statusStripLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(707, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 1;
            // 
            // progressBar
            // 
            this.progressBar.MarqueeAnimationSpeed = 10;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(200, 16);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.Visible = false;
            // 
            // statusStripLabel
            // 
            this.statusStripLabel.Name = "statusStripLabel";
            this.statusStripLabel.Size = new System.Drawing.Size(42, 17);
            this.statusStripLabel.Text = "Ready.";
            // 
            // accountStatusLabel
            // 
            this.accountStatusLabel.AutoSize = true;
            this.accountStatusLabel.Enabled = false;
            this.accountStatusLabel.Location = new System.Drawing.Point(227, 63);
            this.accountStatusLabel.Name = "accountStatusLabel";
            this.accountStatusLabel.Size = new System.Drawing.Size(246, 15);
            this.accountStatusLabel.TabIndex = 6;
            this.accountStatusLabel.Text = "Choose an account to see the account status.";
            // 
            // disableButton
            // 
            this.disableButton.Enabled = false;
            this.disableButton.Location = new System.Drawing.Point(230, 96);
            this.disableButton.Name = "disableButton";
            this.disableButton.Size = new System.Drawing.Size(153, 36);
            this.disableButton.TabIndex = 5;
            this.disableButton.Text = "&Disable";
            this.disableButton.UseVisualStyleBackColor = true;
            this.disableButton.Click += new System.EventHandler(this.disableButton_Click);
            // 
            // generatePassword
            // 
            this.generatePassword.Enabled = false;
            this.generatePassword.Location = new System.Drawing.Point(421, 96);
            this.generatePassword.Name = "generatePassword";
            this.generatePassword.Size = new System.Drawing.Size(153, 36);
            this.generatePassword.TabIndex = 4;
            this.generatePassword.Text = "&Generate Password";
            this.generatePassword.UseVisualStyleBackColor = true;
            this.generatePassword.Click += new System.EventHandler(this.generatePassword_Click);
            // 
            // detailsGroup
            // 
            this.detailsGroup.Controls.Add(this.printPreviewButton);
            this.detailsGroup.Controls.Add(this.passwordExplanatoryLabel);
            this.detailsGroup.Controls.Add(this.adUsernameLabel);
            this.detailsGroup.Controls.Add(this.adUsername);
            this.detailsGroup.Controls.Add(this.passwordLabel);
            this.detailsGroup.Controls.Add(this.revealButton);
            this.detailsGroup.Controls.Add(this.passwordRevealBox);
            this.detailsGroup.Controls.Add(this.printButton);
            this.detailsGroup.Location = new System.Drawing.Point(15, 138);
            this.detailsGroup.Name = "detailsGroup";
            this.detailsGroup.Size = new System.Drawing.Size(665, 291);
            this.detailsGroup.TabIndex = 3;
            this.detailsGroup.TabStop = false;
            this.detailsGroup.Text = "Details";
            // 
            // printPreviewButton
            // 
            this.printPreviewButton.Location = new System.Drawing.Point(464, 262);
            this.printPreviewButton.Name = "printPreviewButton";
            this.printPreviewButton.Size = new System.Drawing.Size(75, 23);
            this.printPreviewButton.TabIndex = 8;
            this.printPreviewButton.Text = "Preview";
            this.printPreviewButton.UseVisualStyleBackColor = true;
            this.printPreviewButton.Visible = false;
            this.printPreviewButton.Click += new System.EventHandler(this.printPreviewButton_Click);
            // 
            // passwordExplanatoryLabel
            // 
            this.passwordExplanatoryLabel.AutoSize = true;
            this.passwordExplanatoryLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordExplanatoryLabel.Location = new System.Drawing.Point(108, 219);
            this.passwordExplanatoryLabel.Name = "passwordExplanatoryLabel";
            this.passwordExplanatoryLabel.Size = new System.Drawing.Size(451, 15);
            this.passwordExplanatoryLabel.TabIndex = 7;
            this.passwordExplanatoryLabel.Text = "To be able to reveal the password or print the details, click Generate Password a" +
    "bove.";
            // 
            // adUsernameLabel
            // 
            this.adUsernameLabel.AutoSize = true;
            this.adUsernameLabel.Location = new System.Drawing.Point(23, 52);
            this.adUsernameLabel.Name = "adUsernameLabel";
            this.adUsernameLabel.Size = new System.Drawing.Size(115, 15);
            this.adUsernameLabel.TabIndex = 5;
            this.adUsernameLabel.Text = "Windows Username:";
            // 
            // adUsername
            // 
            this.adUsername.Enabled = false;
            this.adUsername.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adUsername.Location = new System.Drawing.Point(144, 34);
            this.adUsername.Name = "adUsername";
            this.adUsername.Size = new System.Drawing.Size(302, 41);
            this.adUsername.TabIndex = 4;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(23, 109);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(60, 15);
            this.passwordLabel.TabIndex = 3;
            this.passwordLabel.Text = "Password:";
            // 
            // revealButton
            // 
            this.revealButton.Enabled = false;
            this.revealButton.Location = new System.Drawing.Point(464, 165);
            this.revealButton.Name = "revealButton";
            this.revealButton.Size = new System.Drawing.Size(103, 29);
            this.revealButton.TabIndex = 2;
            this.revealButton.Text = "&Reveal";
            this.revealButton.UseVisualStyleBackColor = true;
            this.revealButton.Click += new System.EventHandler(this.revealButton_Click);
            // 
            // passwordRevealBox
            // 
            this.passwordRevealBox.Enabled = false;
            this.passwordRevealBox.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordRevealBox.Location = new System.Drawing.Point(144, 91);
            this.passwordRevealBox.Name = "passwordRevealBox";
            this.passwordRevealBox.Size = new System.Drawing.Size(302, 41);
            this.passwordRevealBox.TabIndex = 1;
            this.passwordRevealBox.UseSystemPasswordChar = true;
            // 
            // printButton
            // 
            this.printButton.Enabled = false;
            this.printButton.Image = global::GuestPasswordManager.Properties.Resources.Print_16x;
            this.printButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.printButton.Location = new System.Drawing.Point(556, 256);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(103, 29);
            this.printButton.TabIndex = 0;
            this.printButton.Text = "&Print";
            this.printButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // chooseAccountLabel
            // 
            this.chooseAccountLabel.AutoSize = true;
            this.chooseAccountLabel.Location = new System.Drawing.Point(12, 40);
            this.chooseAccountLabel.Name = "chooseAccountLabel";
            this.chooseAccountLabel.Size = new System.Drawing.Size(98, 15);
            this.chooseAccountLabel.TabIndex = 2;
            this.chooseAccountLabel.Text = "Choose Account:";
            // 
            // chooseAccountBox
            // 
            this.chooseAccountBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chooseAccountBox.FormattingEnabled = true;
            this.chooseAccountBox.Items.AddRange(new object[] {
            "[No accounts found. Please click Configure]"});
            this.chooseAccountBox.Location = new System.Drawing.Point(137, 37);
            this.chooseAccountBox.Name = "chooseAccountBox";
            this.chooseAccountBox.Size = new System.Drawing.Size(437, 23);
            this.chooseAccountBox.TabIndex = 1;
            this.chooseAccountBox.SelectedIndexChanged += new System.EventHandler(this.chooseAccountBox_SelectedIndexChanged);
            // 
            // mainFormToolStrip
            // 
            this.mainFormToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mainFormToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configureButton,
            this.toolStripSeparator1,
            this.aboutBoxButton});
            this.mainFormToolStrip.Location = new System.Drawing.Point(3, 0);
            this.mainFormToolStrip.Name = "mainFormToolStrip";
            this.mainFormToolStrip.Size = new System.Drawing.Size(151, 25);
            this.mainFormToolStrip.TabIndex = 0;
            // 
            // configureButton
            // 
            this.configureButton.Image = global::GuestPasswordManager.Properties.Resources.Settings_16x;
            this.configureButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.configureButton.Name = "configureButton";
            this.configureButton.Size = new System.Drawing.Size(89, 22);
            this.configureButton.Text = "&Configure...";
            this.configureButton.Click += new System.EventHandler(this.configureButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // aboutBoxButton
            // 
            this.aboutBoxButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.aboutBoxButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aboutBoxButton.Name = "aboutBoxButton";
            this.aboutBoxButton.Size = new System.Drawing.Size(44, 22);
            this.aboutBoxButton.Text = "About";
            this.aboutBoxButton.Click += new System.EventHandler(this.aboutBoxButton_Click);
            // 
            // printDetailsPreview
            // 
            this.printDetailsPreview.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printDetailsPreview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printDetailsPreview.ClientSize = new System.Drawing.Size(400, 300);
            this.printDetailsPreview.Enabled = true;
            this.printDetailsPreview.Icon = ((System.Drawing.Icon)(resources.GetObject("printDetailsPreview.Icon")));
            this.printDetailsPreview.Name = "printDetailsPreview";
            this.printDetailsPreview.Visible = false;
            // 
            // printDetailsDialog
            // 
            this.printDetailsDialog.UseEXDialog = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 481);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Guest Password Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.detailsGroup.ResumeLayout(false);
            this.detailsGroup.PerformLayout();
            this.mainFormToolStrip.ResumeLayout(false);
            this.mainFormToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ComboBox chooseAccountBox;
        private System.Windows.Forms.ToolStrip mainFormToolStrip;
        private System.Windows.Forms.ToolStripButton configureButton;
        private System.Windows.Forms.Button disableButton;
        private System.Windows.Forms.Button generatePassword;
        private System.Windows.Forms.GroupBox detailsGroup;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Label chooseAccountLabel;
        private System.Windows.Forms.Label adUsernameLabel;
        private System.Windows.Forms.TextBox adUsername;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button revealButton;
        private System.Windows.Forms.TextBox passwordRevealBox;
        private System.Windows.Forms.Label accountStatusLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton aboutBoxButton;
        private System.Drawing.Printing.PrintDocument printUserDetails;
        private System.Windows.Forms.PrintPreviewDialog printDetailsPreview;
        private System.Windows.Forms.PrintDialog printDetailsDialog;
        private System.Windows.Forms.Label passwordExplanatoryLabel;
        private System.Windows.Forms.Button printPreviewButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker generatePasswordWorker;
        private System.Windows.Forms.ToolStripStatusLabel statusStripLabel;
    }
}

