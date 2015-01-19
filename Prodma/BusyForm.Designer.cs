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
    partial class BusyForm
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
            this.realProgress1 = new Busy.ProgressControl();
            this.SuspendLayout();
            // 
            // realProgress1
            // 
            this.realProgress1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.realProgress1.IsOperationInProgress = false;
            this.realProgress1.Location = new System.Drawing.Point(0, 0);
            this.realProgress1.Name = "realProgress1";
            this.realProgress1.Size = new System.Drawing.Size(416, 111);
            this.realProgress1.TabIndex = 3;
            this.realProgress1.Load += new System.EventHandler(this.realProgress1_Load);
            // 
            // BusyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 111);
            this.Controls.Add(this.realProgress1);
            this.Name = "BusyForm";
            this.Text = "Busy Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BusyForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private ProgressControl realProgress1;
        //private DevExpress.XtraEditors.SimpleButton simpleButton1;

    }
}

