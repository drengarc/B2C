namespace Prodma.WinForms
{
    partial class Islemler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Islemler));
            this.timer1 = new System.Windows.Forms.Timer();
            this.IPTAL_1btn = new DevExpress.XtraEditors.SimpleButton();
            this.TAMAM_1cmd = new DevExpress.XtraEditors.SimpleButton();
            this.panelTamam = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panelTamam.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Images.SetKeyName(0, "teklif.png");
            this.imageList1.Images.SetKeyName(1, "siparis.png");
            this.imageList1.Images.SetKeyName(2, "irsaliye.png");
            this.imageList1.Images.SetKeyName(3, "muhasebe.png");
            this.imageList1.Images.SetKeyName(4, "sistem.png");
            this.imageList1.Images.SetKeyName(5, "Altec Lansing ACS-48.ico");
            this.imageList1.Images.SetKeyName(6, "115.png");
            this.imageList1.Images.SetKeyName(7, "documents_gear.png");
            this.imageList1.Images.SetKeyName(8, "NeXT MS-DOS Batch File.ico");
            this.imageList1.Images.SetKeyName(9, "windows.png");
            this.imageList1.Images.SetKeyName(10, "Printer.ico");
            this.imageList1.Images.SetKeyName(11, "images.jpg");
            // 
            // IPTAL_1btn
            // 
            this.IPTAL_1btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.IPTAL_1btn.Location = new System.Drawing.Point(303, 4);
            this.IPTAL_1btn.Name = "IPTAL_1btn";
            this.IPTAL_1btn.Size = new System.Drawing.Size(75, 23);
            this.IPTAL_1btn.TabIndex = 501;
            this.IPTAL_1btn.Text = "İPTAL";
            // 
            // TAMAM_1cmd
            // 
            this.TAMAM_1cmd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TAMAM_1cmd.Location = new System.Drawing.Point(222, 4);
            this.TAMAM_1cmd.Name = "TAMAM_1cmd";
            this.TAMAM_1cmd.Size = new System.Drawing.Size(75, 23);
            this.TAMAM_1cmd.TabIndex = 500;
            this.TAMAM_1cmd.Text = "TAMAM";
            // 
            // panelTamam
            // 
            this.panelTamam.Controls.Add(this.IPTAL_1btn);
            this.panelTamam.Controls.Add(this.TAMAM_1cmd);
            this.panelTamam.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTamam.Location = new System.Drawing.Point(0, 273);
            this.panelTamam.Name = "panelTamam";
            this.panelTamam.Size = new System.Drawing.Size(381, 30);
            this.panelTamam.TabIndex = 502;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 303);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(381, 11);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 50;
            // 
            // Islemler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 314);
            this.Controls.Add(this.panelTamam);
            this.Controls.Add(this.progressBar1);
            this.LookAndFeel.SkinName = "Lilian";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "Islemler";
            this.Text = "Islemler";
            this.panelTamam.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Timer timer1;
        public DevExpress.XtraEditors.SimpleButton IPTAL_1btn;
        public DevExpress.XtraEditors.SimpleButton TAMAM_1cmd;
        public System.Windows.Forms.Panel panelTamam;
        public System.Windows.Forms.ProgressBar progressBar1;
    }
}