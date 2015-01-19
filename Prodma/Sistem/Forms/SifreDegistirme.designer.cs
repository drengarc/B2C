namespace Prodma.Sistem.Forms
{
    partial class SifreDegistirme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SifreDegistirme));
            this.ESKI_SIFRElbl = new DevExpress.XtraEditors.LabelControl();
            this.ESKI_SIFREtxt = new DevExpress.XtraEditors.TextEdit();
            this.YENI_SIFREtxt = new DevExpress.XtraEditors.TextEdit();
            this.YENI_SIFRElbl = new DevExpress.XtraEditors.LabelControl();
            this.panelTamam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ESKI_SIFREtxt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YENI_SIFREtxt.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // IPTAL_1btn
            // 
            this.IPTAL_1btn.Location = new System.Drawing.Point(230, 4);
            // 
            // TAMAM_1cmd
            // 
            this.TAMAM_1cmd.Location = new System.Drawing.Point(149, 4);
            // 
            // panelTamam
            // 
            this.panelTamam.Location = new System.Drawing.Point(0, 68);
            this.panelTamam.Size = new System.Drawing.Size(308, 30);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 98);
            this.progressBar1.Size = new System.Drawing.Size(308, 11);
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
            // ESKI_SIFRElbl
            // 
            this.ESKI_SIFRElbl.Location = new System.Drawing.Point(12, 15);
            this.ESKI_SIFRElbl.Name = "ESKI_SIFRElbl";
            this.ESKI_SIFRElbl.Size = new System.Drawing.Size(43, 13);
            this.ESKI_SIFRElbl.TabIndex = 17;
            this.ESKI_SIFRElbl.Text = "Eski Şifre";
            // 
            // ESKI_SIFREtxt
            // 
            this.ESKI_SIFREtxt.Location = new System.Drawing.Point(149, 12);
            this.ESKI_SIFREtxt.Name = "ESKI_SIFREtxt";
            this.ESKI_SIFREtxt.Size = new System.Drawing.Size(100, 20);
            this.ESKI_SIFREtxt.TabIndex = 3;
            // 
            // YENI_SIFREtxt
            // 
            this.YENI_SIFREtxt.Location = new System.Drawing.Point(149, 38);
            this.YENI_SIFREtxt.Name = "YENI_SIFREtxt";
            this.YENI_SIFREtxt.Size = new System.Drawing.Size(100, 20);
            this.YENI_SIFREtxt.TabIndex = 3;
            // 
            // YENI_SIFRElbl
            // 
            this.YENI_SIFRElbl.Location = new System.Drawing.Point(12, 41);
            this.YENI_SIFRElbl.Name = "YENI_SIFRElbl";
            this.YENI_SIFRElbl.Size = new System.Drawing.Size(45, 13);
            this.YENI_SIFRElbl.TabIndex = 17;
            this.YENI_SIFRElbl.Text = "Yeni Şifre";
            // 
            // SifreDegistirme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 109);
            this.Controls.Add(this.YENI_SIFRElbl);
            this.Controls.Add(this.ESKI_SIFRElbl);
            this.Controls.Add(this.YENI_SIFREtxt);
            this.Controls.Add(this.ESKI_SIFREtxt);
            this.LookAndFeel.SkinName = "Lilian";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "SifreDegistirme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Toplu İrsaliye Silme";
            this.Load += new System.EventHandler(this.KullaniciKopyalama_Load);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.Controls.SetChildIndex(this.panelTamam, 0);
            this.Controls.SetChildIndex(this.ESKI_SIFREtxt, 0);
            this.Controls.SetChildIndex(this.YENI_SIFREtxt, 0);
            this.Controls.SetChildIndex(this.ESKI_SIFRElbl, 0);
            this.Controls.SetChildIndex(this.YENI_SIFRElbl, 0);
            this.panelTamam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ESKI_SIFREtxt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YENI_SIFREtxt.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl ESKI_SIFRElbl;
        private DevExpress.XtraEditors.TextEdit ESKI_SIFREtxt;
        private DevExpress.XtraEditors.TextEdit YENI_SIFREtxt;
        private DevExpress.XtraEditors.LabelControl YENI_SIFRElbl;


    }
}