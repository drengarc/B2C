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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Busy
{
    public partial class ProgressControl : UserControl
    {
        private bool _IsOperationInProgress;
        public bool IsOperationInProgress
        {
            get { return _IsOperationInProgress; }
            set { _IsOperationInProgress = value; //simpleButton1.Enabled = !value; 
            }
        }

        private const int INT_filesCount = 500;
        private const int INT_operationTime = 10;
        public ProgressControl()
        {
            InitializeComponent();
        }

        private static void CopyFile()
        {
            System.Threading.Thread.Sleep(INT_operationTime);
        }

        private void UpdateProgressBar(int value)
        {
            BeginInvoke(new MethodInvoker(delegate { progressBarControl2.EditValue = value; }));
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= INT_filesCount; i++)
            {
                CopyFile();
                int progress = i * 100 / INT_filesCount;
                backgroundWorker.ReportProgress(progress);
            }
        }


        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            UpdateProgressBar(e.ProgressPercentage);
        }

        private void backgroundWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateProgressBar(0);
            IsOperationInProgress = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            IsOperationInProgress = true;
            backgroundWorker.RunWorkerAsync();
        }
        public void calistir()
        {
            IsOperationInProgress = true;
            backgroundWorker.RunWorkerAsync();
        }
    }
}
