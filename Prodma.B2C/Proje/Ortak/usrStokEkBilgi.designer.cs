namespace Ortak.Forms

{
    partial class usrStokEkBilgi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrStokEkBilgi));
            this.cargo_pricechk = new DevExpress.XtraEditors.CheckEdit();
            this.cargo_pricetxt = new DevExpress.XtraEditors.TextEdit();
            this.cargo_pricelbl = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cargo_pricechk.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cargo_pricetxt.Properties)).BeginInit();
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
            this.imageList1.Images.SetKeyName(12, "zoom.png");
            // 
            // cargo_pricechk
            // 
            this.cargo_pricechk.Location = new System.Drawing.Point(225, 3);
            this.cargo_pricechk.Name = "cargo_pricechk";
            this.cargo_pricechk.Properties.Caption = "";
            this.cargo_pricechk.Size = new System.Drawing.Size(21, 19);
            this.cargo_pricechk.TabIndex = 47;
            this.cargo_pricechk.Tag = "F";
            this.cargo_pricechk.CheckedChanged += new System.EventHandler(this.CheckBoxes_CheckedChanged);
            // 
            // cargo_pricetxt
            // 
            this.cargo_pricetxt.Location = new System.Drawing.Point(98, 3);
            this.cargo_pricetxt.Name = "cargo_pricetxt";
            this.cargo_pricetxt.Size = new System.Drawing.Size(121, 20);
            this.cargo_pricetxt.TabIndex = 13;
            // 
            // cargo_pricelbl
            // 
            this.cargo_pricelbl.Location = new System.Drawing.Point(14, 6);
            this.cargo_pricelbl.Name = "cargo_pricelbl";
            this.cargo_pricelbl.Size = new System.Drawing.Size(55, 13);
            this.cargo_pricelbl.TabIndex = 56;
            this.cargo_pricelbl.Text = "Kargo Fiyat";
            // 
            // usrStokEkBilgi
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cargo_pricechk);
            this.Controls.Add(this.cargo_pricetxt);
            this.Controls.Add(this.cargo_pricelbl);
            this.LookAndFeel.SkinName = "Lilian";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "usrStokEkBilgi";
            this.Size = new System.Drawing.Size(336, 62);
            ((System.ComponentModel.ISupportInitialize)(this.cargo_pricechk.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cargo_pricetxt.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit cargo_pricetxt;
        private DevExpress.XtraEditors.LabelControl cargo_pricelbl;
        private DevExpress.XtraEditors.CheckEdit cargo_pricechk;


    }
}
