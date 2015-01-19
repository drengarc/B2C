namespace Prodma.WinForms
{
    partial class LogDetayGozlem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogDetayGozlem));
            this.panelControlGrid = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.KAYNAK_TIPlbl = new DevExpress.XtraEditors.LabelControl();
            this.LISTE_TIPlke = new DevExpress.XtraEditors.LookUpEdit();
            this.LISTE_TIPlbl = new DevExpress.XtraEditors.LabelControl();
            this.KAYNAK_TIPlke = new DevExpress.XtraEditors.LookUpEdit();
            this.panelTamam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LISTE_TIPlke.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KAYNAK_TIPlke.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // IPTAL_1btn
            // 
            this.IPTAL_1btn.Location = new System.Drawing.Point(951, 4);
            // 
            // TAMAM_1cmd
            // 
            this.TAMAM_1cmd.Location = new System.Drawing.Point(870, 4);
            // 
            // panelTamam
            // 
            this.panelTamam.Location = new System.Drawing.Point(0, 431);
            this.panelTamam.Size = new System.Drawing.Size(1029, 30);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 461);
            this.progressBar1.Size = new System.Drawing.Size(1029, 11);
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
            // panelControlGrid
            // 
            this.panelControlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlGrid.Location = new System.Drawing.Point(0, 41);
            this.panelControlGrid.Name = "panelControlGrid";
            this.panelControlGrid.Size = new System.Drawing.Size(1029, 390);
            this.panelControlGrid.TabIndex = 6;
            this.panelControlGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControlGrid_Paint);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.KAYNAK_TIPlbl);
            this.panelControl1.Controls.Add(this.LISTE_TIPlke);
            this.panelControl1.Controls.Add(this.LISTE_TIPlbl);
            this.panelControl1.Controls.Add(this.KAYNAK_TIPlke);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1029, 41);
            this.panelControl1.TabIndex = 5;
            // 
            // KAYNAK_TIPlbl
            // 
            this.KAYNAK_TIPlbl.Location = new System.Drawing.Point(381, 12);
            this.KAYNAK_TIPlbl.Name = "KAYNAK_TIPlbl";
            this.KAYNAK_TIPlbl.Size = new System.Drawing.Size(54, 13);
            this.KAYNAK_TIPlbl.TabIndex = 26;
            this.KAYNAK_TIPlbl.Text = "Kaynak Tipi";
            // 
            // LISTE_TIPlke
            // 
            this.LISTE_TIPlke.Location = new System.Drawing.Point(89, 9);
            this.LISTE_TIPlke.Name = "LISTE_TIPlke";
            this.LISTE_TIPlke.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LISTE_TIPlke.Size = new System.Drawing.Size(246, 20);
            this.LISTE_TIPlke.TabIndex = 0;
            this.LISTE_TIPlke.EditValueChanged += new System.EventHandler(this.LISTE_TIPlke_EditValueChanged);
            // 
            // LISTE_TIPlbl
            // 
            this.LISTE_TIPlbl.Location = new System.Drawing.Point(10, 16);
            this.LISTE_TIPlbl.Name = "LISTE_TIPlbl";
            this.LISTE_TIPlbl.Size = new System.Drawing.Size(41, 13);
            this.LISTE_TIPlbl.TabIndex = 0;
            this.LISTE_TIPlbl.Text = "Liste Tipi";
            // 
            // KAYNAK_TIPlke
            // 
            this.KAYNAK_TIPlke.Location = new System.Drawing.Point(447, 9);
            this.KAYNAK_TIPlke.Name = "KAYNAK_TIPlke";
            this.KAYNAK_TIPlke.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.KAYNAK_TIPlke.Size = new System.Drawing.Size(170, 20);
            this.KAYNAK_TIPlke.TabIndex = 1;
            this.KAYNAK_TIPlke.EditValueChanged += new System.EventHandler(this.KAYNAK_TIPlke_EditValueChanged);
            // 
            // CariTakipStokIstatistikleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 472);
            this.Controls.Add(this.panelControlGrid);
            this.Controls.Add(this.panelControl1);
            this.KeyPreview = true;
            this.LookAndFeel.SkinName = "Lilian";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "CariTakipStokIstatistikleri";
            this.Text = "Stok_Gozlem";
            this.Load += new System.EventHandler(this.CariTakipStokIstatistikleri_Load);
            this.Shown += new System.EventHandler(this.CariTakipStokIstatistikleri_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CariTakipStokIstatistikleri_KeyDown);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.Controls.SetChildIndex(this.panelTamam, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.panelControlGrid, 0);
            this.panelTamam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LISTE_TIPlke.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KAYNAK_TIPlke.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControlGrid;
        public DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl KAYNAK_TIPlbl;
        public DevExpress.XtraEditors.LookUpEdit LISTE_TIPlke;
        private DevExpress.XtraEditors.LabelControl LISTE_TIPlbl;
        private DevExpress.XtraEditors.LookUpEdit KAYNAK_TIPlke;

    }
}