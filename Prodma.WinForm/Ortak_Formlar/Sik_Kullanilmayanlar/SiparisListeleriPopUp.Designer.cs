namespace Prodma.WinForms
{
    partial class SiparisListeleriPopUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SiparisListeleriPopUp));
            this.SIPARIS_TIPlbl = new DevExpress.XtraEditors.LabelControl();
            this.FilterNametxt = new DevExpress.XtraEditors.TextEdit();
            this.Tamambtn = new DevExpress.XtraEditors.SimpleButton();
            this.YeniKayitBtn = new DevExpress.XtraEditors.SimpleButton();
            this.Silbtn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.FilterNametxt.Properties)).BeginInit();
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
            // SIPARIS_TIPlbl
            // 
            this.SIPARIS_TIPlbl.Location = new System.Drawing.Point(23, 36);
            this.SIPARIS_TIPlbl.Name = "SIPARIS_TIPlbl";
            this.SIPARIS_TIPlbl.Size = new System.Drawing.Size(46, 13);
            this.SIPARIS_TIPlbl.TabIndex = 46;
            this.SIPARIS_TIPlbl.Text = "Filtre Adı:";
            // 
            // FilterNametxt
            // 
            this.FilterNametxt.Location = new System.Drawing.Point(75, 33);
            this.FilterNametxt.Name = "FilterNametxt";
            this.FilterNametxt.Size = new System.Drawing.Size(297, 20);
            this.FilterNametxt.TabIndex = 74;
            // 
            // Tamambtn
            // 
            this.Tamambtn.Location = new System.Drawing.Point(135, 85);
            this.Tamambtn.Name = "Tamambtn";
            this.Tamambtn.Size = new System.Drawing.Size(75, 23);
            this.Tamambtn.TabIndex = 75;
            this.Tamambtn.Text = "Kaydet";
            this.Tamambtn.Click += new System.EventHandler(this.Tamambtn_Click);
            // 
            // YeniKayitBtn
            // 
            this.YeniKayitBtn.Location = new System.Drawing.Point(297, 85);
            this.YeniKayitBtn.Name = "YeniKayitBtn";
            this.YeniKayitBtn.Size = new System.Drawing.Size(75, 23);
            this.YeniKayitBtn.TabIndex = 76;
            this.YeniKayitBtn.Text = "Yeni Kayıt";
            this.YeniKayitBtn.Click += new System.EventHandler(this.YeniKayitBtn_Click);
            // 
            // Silbtn
            // 
            this.Silbtn.Location = new System.Drawing.Point(216, 85);
            this.Silbtn.Name = "Silbtn";
            this.Silbtn.Size = new System.Drawing.Size(75, 23);
            this.Silbtn.TabIndex = 77;
            this.Silbtn.Text = "Sil";
            this.Silbtn.Click += new System.EventHandler(this.Silbtn_Click);
            // 
            // SiparisListeleriPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 120);
            this.Controls.Add(this.Silbtn);
            this.Controls.Add(this.YeniKayitBtn);
            this.Controls.Add(this.Tamambtn);
            this.Controls.Add(this.FilterNametxt);
            this.Controls.Add(this.SIPARIS_TIPlbl);
            this.LookAndFeel.SkinName = "Lilian";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "SiparisListeleriPopUp";
            this.Text = "Filtre Seçenekleri";
            this.Load += new System.EventHandler(this.SiparisListeleriPopUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FilterNametxt.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl SIPARIS_TIPlbl;
        public DevExpress.XtraEditors.TextEdit FilterNametxt;
        public DevExpress.XtraEditors.SimpleButton Tamambtn;
        public DevExpress.XtraEditors.SimpleButton YeniKayitBtn;
        public DevExpress.XtraEditors.SimpleButton Silbtn;

    }
}