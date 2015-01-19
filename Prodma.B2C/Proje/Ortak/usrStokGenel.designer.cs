namespace Listeler.UserControlStok
{
    partial class usrStokGenel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usrStokGenel));
            this.STOK_ALTERNATIF_IDlbl = new DevExpress.XtraEditors.LabelControl();
            this.STOK_IDéBASlbl = new DevExpress.XtraEditors.LabelControl();
            this.STOK_IDglebas = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.manufacturer_idchl = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.STOK_IDglebas.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.manufacturer_idchl.Properties)).BeginInit();
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
            // STOK_ALTERNATIF_IDlbl
            // 
            this.STOK_ALTERNATIF_IDlbl.Location = new System.Drawing.Point(4, 34);
            this.STOK_ALTERNATIF_IDlbl.Name = "STOK_ALTERNATIF_IDlbl";
            this.STOK_ALTERNATIF_IDlbl.Size = new System.Drawing.Size(30, 13);
            this.STOK_ALTERNATIF_IDlbl.TabIndex = 39;
            this.STOK_ALTERNATIF_IDlbl.Text = "Üretici";
            // 
            // STOK_IDéBASlbl
            // 
            this.STOK_IDéBASlbl.Location = new System.Drawing.Point(4, 8);
            this.STOK_IDéBASlbl.Name = "STOK_IDéBASlbl";
            this.STOK_IDéBASlbl.Size = new System.Drawing.Size(21, 13);
            this.STOK_IDéBASlbl.TabIndex = 34;
            this.STOK_IDéBASlbl.Text = "Stok";
            // 
            // STOK_IDglebas
            // 
            this.STOK_IDglebas.Location = new System.Drawing.Point(135, 5);
            this.STOK_IDglebas.Name = "STOK_IDglebas";
            this.STOK_IDglebas.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.STOK_IDglebas.Properties.NullText = "[EditValue is null]";
            this.STOK_IDglebas.Size = new System.Drawing.Size(251, 20);
            this.STOK_IDglebas.TabIndex = 0;
            // 
            // manufacturer_idchl
            // 
            this.manufacturer_idchl.Location = new System.Drawing.Point(135, 31);
            this.manufacturer_idchl.Name = "manufacturer_idchl";
            this.manufacturer_idchl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.manufacturer_idchl.Properties.NullText = "[EditValue is null]";
            this.manufacturer_idchl.Size = new System.Drawing.Size(251, 20);
            this.manufacturer_idchl.TabIndex = 2;
            // 
            // usrStokGenel
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.STOK_ALTERNATIF_IDlbl);
            this.Controls.Add(this.STOK_IDéBASlbl);
            this.Controls.Add(this.STOK_IDglebas);
            this.Controls.Add(this.manufacturer_idchl);
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "usrStokGenel";
            this.Size = new System.Drawing.Size(413, 111);
            this.Load += new System.EventHandler(this.usrStokGenel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.STOK_IDglebas.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.manufacturer_idchl.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl STOK_ALTERNATIF_IDlbl;
        private DevExpress.XtraEditors.LabelControl STOK_IDéBASlbl;
        private DevExpress.XtraEditors.CheckedComboBoxEdit STOK_IDglebas;
        private DevExpress.XtraEditors.CheckedComboBoxEdit manufacturer_idchl;

    }
}
