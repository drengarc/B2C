namespace Prodma.WinForms
{
    partial class ListDetayCalisma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListDetayCalisma));
            this.panelUst = new DevExpress.XtraEditors.PanelControl();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.filtreLke = new DevExpress.XtraEditors.LookUpEdit();
            this.saveFilterBtn = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pivotGridControl1 = new DevExpress.XtraPivotGrid.PivotGridControl();
            this.pivotGridField1 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField2 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.pivotGridField3 = new DevExpress.XtraPivotGrid.PivotGridField();
            this.controlNavigator1 = new DevExpress.XtraEditors.ControlNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.panelUst)).BeginInit();
            this.panelUst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filtreLke.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).BeginInit();
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
            this.imageList1.Images.SetKeyName(12, "pdf.ico");
            this.imageList1.Images.SetKeyName(13, "excel.ico");
            // 
            // panelUst
            // 
            this.panelUst.Controls.Add(this.checkEdit1);
            this.panelUst.Controls.Add(this.filtreLke);
            this.panelUst.Controls.Add(this.saveFilterBtn);
            this.panelUst.Controls.Add(this.simpleButton1);
            this.panelUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUst.Location = new System.Drawing.Point(0, 0);
            this.panelUst.Name = "panelUst";
            this.panelUst.Size = new System.Drawing.Size(836, 43);
            this.panelUst.TabIndex = 1;
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(193, 19);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Toplam Gösterim Durum Değiştir";
            this.checkEdit1.Size = new System.Drawing.Size(178, 18);
            this.checkEdit1.TabIndex = 55;
            this.checkEdit1.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // filtreLke
            // 
            this.filtreLke.Location = new System.Drawing.Point(49, 24);
            this.filtreLke.Name = "filtreLke";
            this.filtreLke.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.filtreLke.Size = new System.Drawing.Size(124, 20);
            this.filtreLke.TabIndex = 54;
            // 
            // saveFilterBtn
            // 
            this.saveFilterBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.saveFilterBtn.Appearance.Options.UseFont = true;
            this.saveFilterBtn.Location = new System.Drawing.Point(49, 5);
            this.saveFilterBtn.Name = "saveFilterBtn";
            this.saveFilterBtn.Size = new System.Drawing.Size(124, 19);
            this.saveFilterBtn.TabIndex = 53;
            this.saveFilterBtn.Text = "FİLTRE İŞLEMLERİ";
            // 
            // simpleButton1
            // 
            this.simpleButton1.BackgroundImage = global::Prodma.DataAccess.Resource1.excel;
            this.simpleButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.simpleButton1.ImageIndex = 13;
            this.simpleButton1.ImageList = this.imageList1;
            this.simpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.simpleButton1.Location = new System.Drawing.Point(12, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(31, 36);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.pivotGridControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 43);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(836, 321);
            this.panelControl1.TabIndex = 2;
            // 
            // pivotGridControl1
            // 
            this.pivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pivotGridControl1.Fields.AddRange(new DevExpress.XtraPivotGrid.PivotGridField[] {
            this.pivotGridField1,
            this.pivotGridField2,
            this.pivotGridField3});
            this.pivotGridControl1.Location = new System.Drawing.Point(2, 2);
            this.pivotGridControl1.Name = "pivotGridControl1";
            this.pivotGridControl1.Size = new System.Drawing.Size(832, 317);
            this.pivotGridControl1.TabIndex = 2;
            // 
            // pivotGridField1
            // 
            this.pivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField1.AreaIndex = 0;
            this.pivotGridField1.Name = "pivotGridField1";
            // 
            // pivotGridField2
            // 
            this.pivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.pivotGridField2.AreaIndex = 1;
            this.pivotGridField2.Name = "pivotGridField2";
            // 
            // pivotGridField3
            // 
            this.pivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.pivotGridField3.AreaIndex = 0;
            this.pivotGridField3.CellFormat.FormatString = "n2";
            this.pivotGridField3.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField3.Name = "pivotGridField3";
            this.pivotGridField3.TotalCellFormat.FormatString = "n3";
            this.pivotGridField3.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField3.TotalValueFormat.FormatString = "n2";
            this.pivotGridField3.TotalValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.pivotGridField3.ValueFormat.FormatString = "n2";
            this.pivotGridField3.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            // 
            // controlNavigator1
            // 
            this.controlNavigator1.Buttons.ImageList = this.imageList1;
            this.controlNavigator1.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 10, true, true, "Yazdır", "Yazdir"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, false, "Büyüt", "Büyüt"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, false, global::Prodma.DataAccessB2C.Resources.rsReportIngilizce.CARI_KOD_SA, null),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, false, global::Prodma.DataAccessB2C.Resources.rsReportIngilizce.CARI_KOD_SA, null),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, false, global::Prodma.DataAccessB2C.Resources.rsReportIngilizce.CARI_KOD_SA, null),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 12, true, true, "DetayCalisma", " Detay Çalışma "),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 12, true, true, "Excele Gönder", "Excel"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 13, true, true, "Pdf\'e Gönder", "Pdf")});
            this.controlNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlNavigator1.Location = new System.Drawing.Point(0, 500);
            this.controlNavigator1.Name = "controlNavigator1";
            this.controlNavigator1.ShowToolTips = true;
            this.controlNavigator1.Size = new System.Drawing.Size(836, 38);
            this.controlNavigator1.TabIndex = 3;
            this.controlNavigator1.Text = "controlNavigator1";
            // 
            // ListDetayCalisma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 538);
            this.Controls.Add(this.controlNavigator1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelUst);
            this.LookAndFeel.SkinName = "Lilian";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "ListDetayCalisma";
            this.Text = "ListForm";
            this.Load += new System.EventHandler(this.ListDetayCalisma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelUst)).EndInit();
            this.panelUst.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filtreLke.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pivotGridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelUst;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        public DevExpress.XtraPivotGrid.PivotGridControl pivotGridControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        public DevExpress.XtraEditors.ControlNavigator controlNavigator1;
        public DevExpress.XtraEditors.LookUpEdit filtreLke;
        public DevExpress.XtraEditors.SimpleButton saveFilterBtn;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField1;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField2;
        private DevExpress.XtraPivotGrid.PivotGridField pivotGridField3;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;

    }
}