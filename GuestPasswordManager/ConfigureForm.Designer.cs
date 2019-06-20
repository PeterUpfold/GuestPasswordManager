namespace GuestPasswordManager
{
    partial class ConfigureForm
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
            GuestPasswordManager.Properties.Settings settings2 = new GuestPasswordManager.Properties.Settings();
            this.searchBaseLabel = new System.Windows.Forms.Label();
            this.foundUsersLabel = new System.Windows.Forms.Label();
            this.passwordLengthLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.debugNodesButton = new System.Windows.Forms.Button();
            this.passwordLengthBox = new System.Windows.Forms.NumericUpDown();
            this.adPicker = new GuestPasswordManager.Support.ADPicker();
            ((System.ComponentModel.ISupportInitialize)(this.passwordLengthBox)).BeginInit();
            this.SuspendLayout();
            // 
            // searchBaseLabel
            // 
            this.searchBaseLabel.AutoSize = true;
            this.searchBaseLabel.Location = new System.Drawing.Point(22, 20);
            this.searchBaseLabel.Name = "searchBaseLabel";
            this.searchBaseLabel.Size = new System.Drawing.Size(266, 15);
            this.searchBaseLabel.TabIndex = 1;
            this.searchBaseLabel.Text = "Choose an OU where the target users are located:";
            // 
            // foundUsersLabel
            // 
            this.foundUsersLabel.AutoSize = true;
            this.foundUsersLabel.Location = new System.Drawing.Point(37, 313);
            this.foundUsersLabel.Name = "foundUsersLabel";
            this.foundUsersLabel.Size = new System.Drawing.Size(138, 15);
            this.foundUsersLabel.TabIndex = 3;
            this.foundUsersLabel.Text = "Found 0 users in this OU.";
            // 
            // passwordLengthLabel
            // 
            this.passwordLengthLabel.AutoSize = true;
            this.passwordLengthLabel.Location = new System.Drawing.Point(23, 467);
            this.passwordLengthLabel.Name = "passwordLengthLabel";
            this.passwordLengthLabel.Size = new System.Drawing.Size(97, 15);
            this.passwordLengthLabel.TabIndex = 8;
            this.passwordLengthLabel.Text = "Password length:";
            this.passwordLengthLabel.Click += new System.EventHandler(this.passwordLengthLabel_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(672, 571);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(115, 29);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "&Save && Close";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 571);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(115, 29);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(659, 732);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 29);
            this.button1.TabIndex = 11;
            this.button1.Text = "&Save && Close";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // debugNodesButton
            // 
            this.debugNodesButton.Location = new System.Drawing.Point(699, 316);
            this.debugNodesButton.Name = "debugNodesButton";
            this.debugNodesButton.Size = new System.Drawing.Size(75, 23);
            this.debugNodesButton.TabIndex = 12;
            this.debugNodesButton.Text = "nodes";
            this.debugNodesButton.UseVisualStyleBackColor = true;
            this.debugNodesButton.Visible = false;
            this.debugNodesButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // passwordLengthBox
            // 
            settings2.LDAPSearchBase = "";
            settings2.PasswordLength = new decimal(new int[] {
            8,
            0,
            0,
            0});
            settings2.SettingsKey = "";
            settings2.UpgradeRequired = true;
            this.passwordLengthBox.DataBindings.Add(new System.Windows.Forms.Binding("Value", settings2, "PasswordLength", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.passwordLengthBox.Location = new System.Drawing.Point(300, 465);
            this.passwordLengthBox.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.passwordLengthBox.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.passwordLengthBox.Name = "passwordLengthBox";
            this.passwordLengthBox.Size = new System.Drawing.Size(120, 23);
            this.passwordLengthBox.TabIndex = 3;
            this.passwordLengthBox.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.passwordLengthBox.ValueChanged += new System.EventHandler(this.passwordLengthBox_ValueChanged);
            // 
            // adPicker
            // 
            this.adPicker.ADsPath = "";
            this.adPicker.Location = new System.Drawing.Point(25, 51);
            this.adPicker.Name = "adPicker";
            this.adPicker.Size = new System.Drawing.Size(762, 259);
            this.adPicker.TabIndex = 13;
            // 
            // ConfigureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 612);
            this.Controls.Add(this.adPicker);
            this.Controls.Add(this.debugNodesButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.passwordLengthBox);
            this.Controls.Add(this.passwordLengthLabel);
            this.Controls.Add(this.foundUsersLabel);
            this.Controls.Add(this.searchBaseLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigureForm";
            this.Text = "Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Configuration_FormClosing);
            this.Load += new System.EventHandler(this.ConfigureForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Configuration_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.passwordLengthBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label searchBaseLabel;
        private System.Windows.Forms.Label foundUsersLabel;
        private System.Windows.Forms.Label passwordLengthLabel;
        private System.Windows.Forms.NumericUpDown passwordLengthBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button debugNodesButton;
        private Support.ADPicker adPicker;
    }
}