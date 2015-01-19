namespace B2C.Forms
{
    partial class SepetSiparisOlustur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SepetSiparisOlustur));
            this.orderlke = new DevExpress.XtraEditors.LookUpEdit();
            this.orderlbl = new DevExpress.XtraEditors.LabelControl();
            this.SepetSecimilke = new DevExpress.XtraEditors.LookUpEdit();
            this.SepetSecimilbl = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelUstBilgi)).BeginInit();
            this.panelUstBilgi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).BeginInit();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderlke.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SepetSecimilke.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelUstBilgi
            // 
            this.panelUstBilgi.Controls.Add(this.SepetSecimilbl);
            this.panelUstBilgi.Controls.Add(this.orderlbl);
            this.panelUstBilgi.Controls.Add(this.SepetSecimilke);
            this.panelUstBilgi.Controls.Add(this.orderlke);
            this.panelUstBilgi.Size = new System.Drawing.Size(917, 38);
            // 
            // usr
            // 
            this.usr.Size = new System.Drawing.Size(913, 407);
            // 
            // panelGrid
            // 
            this.panelGrid.Location = new System.Drawing.Point(0, 38);
            this.panelGrid.Size = new System.Drawing.Size(917, 411);
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
            // orderlke
            // 
            this.orderlke.Location = new System.Drawing.Point(79, 43);
            this.orderlke.Name = "orderlke";
            this.orderlke.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.orderlke.Size = new System.Drawing.Size(316, 20);
            this.orderlke.TabIndex = 2;
            this.orderlke.EditValueChanged += new System.EventHandler(this.orderlke_EditValueChanged);
            // 
            // orderlbl
            // 
            this.orderlbl.Location = new System.Drawing.Point(8, 45);
            this.orderlbl.Name = "orderlbl";
            this.orderlbl.Size = new System.Drawing.Size(57, 13);
            this.orderlbl.TabIndex = 23;
            this.orderlbl.Text = "Sepettekiler";
            // 
            // SepetSecimilke
            // 
            this.SepetSecimilke.Location = new System.Drawing.Point(79, 11);
            this.SepetSecimilke.Name = "SepetSecimilke";
            this.SepetSecimilke.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SepetSecimilke.Size = new System.Drawing.Size(316, 20);
            this.SepetSecimilke.TabIndex = 2;
            this.SepetSecimilke.EditValueChanged += new System.EventHandler(this.SepetSecimilke_EditValueChanged);
            // 
            // SepetSecimilbl
            // 
            this.SepetSecimilbl.Location = new System.Drawing.Point(8, 13);
            this.SepetSecimilbl.Name = "SepetSecimilbl";
            this.SepetSecimilbl.Size = new System.Drawing.Size(57, 13);
            this.SepetSecimilbl.TabIndex = 23;
            this.SepetSecimilbl.Text = "Sepettekiler";
            // 
            // SepetSiparisOlustur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 483);
            this.LookAndFeel.SkinName = "Lilian";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "SepetSiparisOlustur";
            this.Text = "Teklif Sipariş Olustur";
            this.Load += new System.EventHandler(this.SiparisOlustur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelUstBilgi)).EndInit();
            this.panelUstBilgi.ResumeLayout(false);
            this.panelUstBilgi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelGrid)).EndInit();
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderlke.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SepetSecimilke.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl orderlbl;
        private DevExpress.XtraEditors.LookUpEdit orderlke;
        private DevExpress.XtraEditors.LabelControl SepetSecimilbl;
        private DevExpress.XtraEditors.LookUpEdit SepetSecimilke;
    }
}