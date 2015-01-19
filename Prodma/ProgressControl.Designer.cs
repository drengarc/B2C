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

namespace Busy
{
    partial class ProgressControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBarControl2 = new DevExpress.XtraEditors.ProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_Completed);
            // 
            // progressBarControl2
            // 
            this.progressBarControl2.Location = new System.Drawing.Point(3, 3);
            this.progressBarControl2.Name = "progressBarControl2";
            this.progressBarControl2.Size = new System.Drawing.Size(407, 18);
            this.progressBarControl2.TabIndex = 1;
            // 
            // ProgressControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBarControl2);
            this.Name = "ProgressControl";
            this.Size = new System.Drawing.Size(413, 32);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl2.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl2;

    }
}
