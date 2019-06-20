namespace GuestPasswordManager
{
    partial class ExceptionDetailsDialog
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
            this.friendlyExplanationLabel = new System.Windows.Forms.Label();
            this.exceptionTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // friendlyExplanationLabel
            // 
            this.friendlyExplanationLabel.AutoSize = true;
            this.friendlyExplanationLabel.Location = new System.Drawing.Point(110, 220);
            this.friendlyExplanationLabel.Name = "friendlyExplanationLabel";
            this.friendlyExplanationLabel.Size = new System.Drawing.Size(35, 13);
            this.friendlyExplanationLabel.TabIndex = 0;
            this.friendlyExplanationLabel.Text = "label1";
            // 
            // exceptionTextBox
            // 
            this.exceptionTextBox.Enabled = false;
            this.exceptionTextBox.Location = new System.Drawing.Point(224, 239);
            this.exceptionTextBox.Multiline = true;
            this.exceptionTextBox.Name = "exceptionTextBox";
            this.exceptionTextBox.Size = new System.Drawing.Size(401, 156);
            this.exceptionTextBox.TabIndex = 1;
            // 
            // ExceptionDetailsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exceptionTextBox);
            this.Controls.Add(this.friendlyExplanationLabel);
            this.Name = "ExceptionDetailsDialog";
            this.Text = "ExceptionDetailsDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label friendlyExplanationLabel;
        private System.Windows.Forms.TextBox exceptionTextBox;
    }
}