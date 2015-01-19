// Developer Express Code Central Example:
// How to update the ProgressBarControl from a separate thread
// 
// Very often when you perform any operation in a background thread, it can be very
// useful to indicate to an end-user the current state of progress. To display the
// progress, the ProgressBarControl can be used. This example illustrates how to
// perform a file copy operation in a background thread, and display the progress
// on a main form.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E2097

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Busy
{
    public partial class BusyForm : Form
    {
        public BusyForm()
        {
            InitializeComponent();
        }


        private void BusyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (realProgress1.IsOperationInProgress) 
            {

                e.Cancel = true;
                MessageBox.Show(this,"This operation in not completed yet. Please wait.",  "Cannot close this form");
            }
        }

        private void realProgress1_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            realProgress1.calistir();
            Text += "Click! ";
        }
        public void calistir()
        {
            realProgress1.calistir();
        }
    }
}
