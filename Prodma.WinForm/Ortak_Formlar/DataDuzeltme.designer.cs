namespace Prodma.WinForms
{
    partial class DataDuzeltme
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataDuzeltme));
            this.TARIHdtbas = new DevExpress.XtraEditors.DateEdit();
            this.BAS_TARIH_NOlbl = new DevExpress.XtraEditors.LabelControl();
            this.TARIHdtbit = new DevExpress.XtraEditors.DateEdit();
            this.panelTamam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TARIHdtbas.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TARIHdtbas.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TARIHdtbit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TARIHdtbit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTamam
            // 
            this.panelTamam.Location = new System.Drawing.Point(0, 81);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 111);
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
            // TARIHdtbas
            // 
            this.TARIHdtbas.EditValue = null;
            this.TARIHdtbas.Location = new System.Drawing.Point(140, 12);
            this.TARIHdtbas.Name = "TARIHdtbas";
            this.TARIHdtbas.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TARIHdtbas.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.TARIHdtbas.Size = new System.Drawing.Size(100, 20);
            this.TARIHdtbas.TabIndex = 503;
            // 
            // BAS_TARIH_NOlbl
            // 
            this.BAS_TARIH_NOlbl.Location = new System.Drawing.Point(7, 15);
            this.BAS_TARIH_NOlbl.Name = "BAS_TARIH_NOlbl";
            this.BAS_TARIH_NOlbl.Size = new System.Drawing.Size(94, 13);
            this.BAS_TARIH_NOlbl.TabIndex = 505;
            this.BAS_TARIH_NOlbl.Text = "Başlangıç Tarih / No";
            // 
            // TARIHdtbit
            // 
            this.TARIHdtbit.EditValue = null;
            this.TARIHdtbit.Location = new System.Drawing.Point(257, 12);
            this.TARIHdtbit.Name = "TARIHdtbit";
            this.TARIHdtbit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TARIHdtbit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.TARIHdtbit.Size = new System.Drawing.Size(100, 20);
            this.TARIHdtbit.TabIndex = 503;
            // 
            // DataDuzeltme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 122);
            this.Controls.Add(this.TARIHdtbit);
            this.Controls.Add(this.TARIHdtbas);
            this.Controls.Add(this.BAS_TARIH_NOlbl);
            this.LookAndFeel.SkinName = "Lilian";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "DataDuzeltme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Data Düzeltme";
            this.Load += new System.EventHandler(this.TopluIrsaliyeSilme_Load);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.Controls.SetChildIndex(this.panelTamam, 0);
            this.Controls.SetChildIndex(this.BAS_TARIH_NOlbl, 0);
            this.Controls.SetChildIndex(this.TARIHdtbas, 0);
            this.Controls.SetChildIndex(this.TARIHdtbit, 0);
            this.panelTamam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TARIHdtbas.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TARIHdtbas.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TARIHdtbit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TARIHdtbit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.DateEdit TARIHdtbas;
        private DevExpress.XtraEditors.LabelControl BAS_TARIH_NOlbl;
        public DevExpress.XtraEditors.DateEdit TARIHdtbit;



    }
}