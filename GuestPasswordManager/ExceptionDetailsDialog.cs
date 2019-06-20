using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuestPasswordManager
{
    /// <summary>
    /// Friendly dialog box to show exception details with a friendly message.
    /// </summary>
    public partial class ExceptionDetailsDialog : Form
    {
        public ExceptionDetailsDialog(string friendlyMessage, Exception exception)
        {
            InitializeComponent();

            friendlyExplanationLabel.Text = friendlyMessage;
            exceptionTextBox.Text = exception.ToString();
        }
    }
}
