using System;
using System.Drawing;
using System.Collections;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using DevExpress.XtraEditors;
using System.Reflection;
using DevExpress.XtraEditors.ViewInfo;
using Prodma.DataAccessB2C;
using System.Linq;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System.Threading;
using Prodma.Sistem.Models;
using System.Collections.Generic;
using System.Text;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using Microsoft.Reporting.WinForms;
using Prodma.Sistem.Controllers;
namespace Prodma.WinForms
{
    /// <summary>
    /// Summary description for MDIChild.
    /// </summary>
    /// 
    public partial class ListSablonIslem : Sablon
    {
      
        #region Deðiþkenler
        public string formName;
        public Dictionary<string, string> filterParametersForm = new Dictionary<string, string>();
        public Dictionary<string, string> setValues = new Dictionary<string, string>();
        public string[] dinamikAlanlar;
        public string dinamikAltAlan;
        public string dinamikUpdateTabloTip = "";
        public bool dinamikUpdateMi=false;
        public bool dinamikListeMi = false;
        public bool gridiolusturDinamik = false;
        public bool sorguBitti = false;
        public ReportParameter[] prmRapor;
        public string[] toplamAlanlari;
        public string ListeAdi = "";
        public string modelPath = "";
        public string modelName = "";
        public string reportDataSet = "";
        public string reportName = "";
        public string[] reportParameter;
        public string mt = "";
        public int varsayilanStokId = 0;
        public int varsayilanCariId = 0;
        public int varsayilanAlisSatisId = 0;
        private IContainer components;
        public PanelControl panelControl1;
        public PanelControl panelControl2;
        public BindingSource bn = new BindingSource();
        public DevExpress.XtraTab.XtraTabControl tbControl;
        public DevExpress.XtraTab.XtraTabPage tbGenel;
        public DevExpress.XtraTab.XtraTabPage tbBalantili;
        public DevExpress.XtraTab.XtraTabPage tbKodlar;
        public DevExpress.XtraTab.XtraTabPage tbDetay;
        public DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        public DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        public DevExpress.XtraTab.XtraTabPage xtraTabPage5;
        public DevExpress.XtraTab.XtraTabPage xtraTabPage6;
        public DevExpress.XtraTab.XtraTabPage xtraTabPage7;
        public DevExpress.XtraTab.XtraTabPage xtraTabPage8;
        public DevExpress.XtraTab.XtraTabPage xtraTabPage9;
        public DevExpress.XtraTab.XtraTabPage xtraTabPage10;
        public PanelControl panelControlGrid;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
        public LabelControl lblBit;
        public LabelControl lblBas;
        public PanelControl panelControlGridControl;
        public Dictionary<string, string> parametersForm = new Dictionary<string, string>();
        private System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Timer timer1;
        public PanelControl panelGenelList;
        public SimpleButton LISTELEbtn;
        public SimpleButton IPTALbtn;
        public SimpleButton ISLEM_YAPbtn;
        public PanelControl panelOzel;
        public usrGridIslem gridControl = new usrGridIslem(GridIslemEn.Bilgilendirme);

        #endregion
        #region formolaylar
        public ListSablonIslem()
        {
            InitializeComponent();
            gridControl.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlGridControl.Controls.Add(gridControl);
            eventHandler();
            this.ClientSize = new Size(867, 600);
            this.StartPosition = FormStartPosition.Manual;
        }
        public void ListSablon_Load(object sender, EventArgs e)
        {
            gridControl.gridView1.OptionsView.ShowGroupPanel = true;
            gridControl.gridView1.GroupPanelText = "Gruplamak Ýstediðiniz Alaný Bu Bölgeye Sürükleyiniz";
            if (yetki != null)
            {
                if (yetki.OKU_E_H == true && yetki.YAZ_E_H == false && yetki.GUNCELLE_E_H == false && yetki.SIL_E_H == false)
                {
                    gridControl.gridView1.OptionsBehavior.Editable = false;
                }
                if (yetki.OKU_E_H == false || yetki.YAZ_E_H == false || yetki.GUNCELLE_E_H == false || yetki.SIL_E_H == false)
                {
                    tamYetki = false;
                }
                else
                {
                    tamYetki = true;
                }
            }
          
            IlkDegerleriVer();
        }
        private void ListSablon_Shown(object sender, EventArgs e)
        {
            try
            {
                ActiveControl = (Control)gridControl.gridControl1;
            }
            catch (Exception)
            {
                
            //    throw;
            }
        }
        private void eventHandler()
        {
            this.Load += new System.EventHandler(this.ListSablon_Load);
            this.Shown += new System.EventHandler(this.ListSablon_Shown);
            this.ISLEM_YAPbtn.Click += new System.EventHandler(this.TAMAMbtn_Click);
            this.IPTALbtn.Click += new System.EventHandler(this.IPTALbtn_Click);
            this.tbControl.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tbControl_SelectedIndexChanged);
            this.LISTELEbtn.Click += new System.EventHandler(this.LISTELEbtn_Click);
        }
        private void tbControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage_Index_Changed(tbControl.SelectedTabPageIndex);// tureyen forma gidis
           // currentTab = tabControl1.SelectedTabPageIndex; // tab seciminin tureyen formda ayarlanmasi icin konuldu
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #endregion
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListSablonIslem));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.ISLEM_YAPbtn = new DevExpress.XtraEditors.SimpleButton();
            this.LISTELEbtn = new DevExpress.XtraEditors.SimpleButton();
            this.IPTALbtn = new DevExpress.XtraEditors.SimpleButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblBit = new DevExpress.XtraEditors.LabelControl();
            this.lblBas = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.tbControl = new DevExpress.XtraTab.XtraTabControl();
            this.tbGenel = new DevExpress.XtraTab.XtraTabPage();
            this.panelOzel = new DevExpress.XtraEditors.PanelControl();
            this.panelGenelList = new DevExpress.XtraEditors.PanelControl();
            this.tbBalantili = new DevExpress.XtraTab.XtraTabPage();
            this.tbKodlar = new DevExpress.XtraTab.XtraTabPage();
            this.tbDetay = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage6 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage7 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage8 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage9 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage10 = new DevExpress.XtraTab.XtraTabPage();
            this.panelControlGrid = new DevExpress.XtraEditors.PanelControl();
            this.panelControlGridControl = new DevExpress.XtraEditors.PanelControl();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem();
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink();
            this.timer1 = new System.Windows.Forms.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbControl)).BeginInit();
            this.tbControl.SuspendLayout();
            this.tbGenel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelOzel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelGenelList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlGrid)).BeginInit();
            this.panelControlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Images.SetKeyName(0, "Printer.ico");
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.ISLEM_YAPbtn);
            this.panelControl1.Controls.Add(this.LISTELEbtn);
            this.panelControl1.Controls.Add(this.IPTALbtn);
            this.panelControl1.Controls.Add(this.progressBar1);
            this.panelControl1.Controls.Add(this.lblBit);
            this.panelControl1.Controls.Add(this.lblBas);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1120, 50);
            this.panelControl1.TabIndex = 1;
            // 
            // ISLEM_YAPbtn
            // 
            this.ISLEM_YAPbtn.Location = new System.Drawing.Point(211, 8);
            this.ISLEM_YAPbtn.Name = "ISLEM_YAPbtn";
            this.ISLEM_YAPbtn.Size = new System.Drawing.Size(72, 23);
            this.ISLEM_YAPbtn.TabIndex = 53;
            this.ISLEM_YAPbtn.Text = "ÝÞLEMÝ YAP";
            // 
            // LISTELEbtn
            // 
            this.LISTELEbtn.Location = new System.Drawing.Point(146, 8);
            this.LISTELEbtn.Name = "LISTELEbtn";
            this.LISTELEbtn.Size = new System.Drawing.Size(59, 23);
            this.LISTELEbtn.TabIndex = 53;
            this.LISTELEbtn.Text = "LÝSTELE";
            this.LISTELEbtn.Visible = false;
            // 
            // IPTALbtn
            // 
            this.IPTALbtn.Location = new System.Drawing.Point(289, 8);
            this.IPTALbtn.Name = "IPTALbtn";
            this.IPTALbtn.Size = new System.Drawing.Size(45, 23);
            this.IPTALbtn.TabIndex = 55;
            this.IPTALbtn.Text = "ÝPTAL";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(2, 37);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1116, 11);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 48;
            // 
            // lblBit
            // 
            this.lblBit.Location = new System.Drawing.Point(10, 18);
            this.lblBit.Name = "lblBit";
            this.lblBit.Size = new System.Drawing.Size(0, 13);
            this.lblBit.TabIndex = 32;
            // 
            // lblBas
            // 
            this.lblBas.Location = new System.Drawing.Point(10, 2);
            this.lblBas.Name = "lblBas";
            this.lblBas.Size = new System.Drawing.Size(0, 13);
            this.lblBas.TabIndex = 31;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.tbControl);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1124, 309);
            this.panelControl2.TabIndex = 2;
            // 
            // tbControl
            // 
            this.tbControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbControl.Location = new System.Drawing.Point(2, 2);
            this.tbControl.LookAndFeel.SkinName = "Lilian";
            this.tbControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tbControl.Name = "tbControl";
            this.tbControl.SelectedTabPage = this.tbGenel;
            this.tbControl.Size = new System.Drawing.Size(1120, 305);
            this.tbControl.TabIndex = 1;
            this.tbControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tbGenel,
            this.tbBalantili,
            this.tbKodlar,
            this.tbDetay,
            this.xtraTabPage3,
            this.xtraTabPage4,
            this.xtraTabPage5,
            this.xtraTabPage6,
            this.xtraTabPage7,
            this.xtraTabPage8,
            this.xtraTabPage9,
            this.xtraTabPage10});
            // 
            // tbGenel
            // 
            this.tbGenel.Controls.Add(this.panelOzel);
            this.tbGenel.Controls.Add(this.panelGenelList);
            this.tbGenel.Name = "tbGenel";
            this.tbGenel.Size = new System.Drawing.Size(1114, 277);
            this.tbGenel.Text = "Genel";
            // 
            // panelOzel
            // 
            this.panelOzel.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelOzel.Location = new System.Drawing.Point(493, 0);
            this.panelOzel.Name = "panelOzel";
            this.panelOzel.Size = new System.Drawing.Size(493, 277);
            this.panelOzel.TabIndex = 39;
            // 
            // panelGenelList
            // 
            this.panelGenelList.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelGenelList.Location = new System.Drawing.Point(0, 0);
            this.panelGenelList.Name = "panelGenelList";
            this.panelGenelList.Size = new System.Drawing.Size(493, 277);
            this.panelGenelList.TabIndex = 38;
            // 
            // tbBalantili
            // 
            this.tbBalantili.AutoScroll = true;
            this.tbBalantili.Name = "tbBalantili";
            this.tbBalantili.Size = new System.Drawing.Size(1114, 277);
            this.tbBalantili.Text = "Baðlantýlý Filtreler";
            // 
            // tbKodlar
            // 
            this.tbKodlar.AutoScroll = true;
            this.tbKodlar.Name = "tbKodlar";
            this.tbKodlar.Size = new System.Drawing.Size(1114, 277);
            this.tbKodlar.Text = "Gruplar";
            // 
            // tbDetay
            // 
            this.tbDetay.AutoScroll = true;
            this.tbDetay.Name = "tbDetay";
            this.tbDetay.Size = new System.Drawing.Size(1114, 277);
            this.tbDetay.Text = "Detay Filtreler";
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(1114, 277);
            this.xtraTabPage3.Text = "xtraTabPage3";
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(1114, 277);
            this.xtraTabPage4.Text = "xtraTabPage4";
            // 
            // xtraTabPage5
            // 
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.Size = new System.Drawing.Size(1114, 277);
            this.xtraTabPage5.Text = "xtraTabPage5";
            // 
            // xtraTabPage6
            // 
            this.xtraTabPage6.Name = "xtraTabPage6";
            this.xtraTabPage6.Size = new System.Drawing.Size(1114, 277);
            this.xtraTabPage6.Text = "xtraTabPage6";
            // 
            // xtraTabPage7
            // 
            this.xtraTabPage7.Name = "xtraTabPage7";
            this.xtraTabPage7.Size = new System.Drawing.Size(1114, 277);
            this.xtraTabPage7.Text = "xtraTabPage7";
            // 
            // xtraTabPage8
            // 
            this.xtraTabPage8.Name = "xtraTabPage8";
            this.xtraTabPage8.Size = new System.Drawing.Size(1114, 277);
            this.xtraTabPage8.Text = "xtraTabPage8";
            // 
            // xtraTabPage9
            // 
            this.xtraTabPage9.Name = "xtraTabPage9";
            this.xtraTabPage9.Size = new System.Drawing.Size(1114, 277);
            this.xtraTabPage9.Text = "xtraTabPage9";
            // 
            // xtraTabPage10
            // 
            this.xtraTabPage10.Name = "xtraTabPage10";
            this.xtraTabPage10.Size = new System.Drawing.Size(1114, 277);
            this.xtraTabPage10.Text = "xtraTabPage10";
            // 
            // panelControlGrid
            // 
            this.panelControlGrid.Controls.Add(this.panelControlGridControl);
            this.panelControlGrid.Controls.Add(this.panelControl1);
            this.panelControlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlGrid.Location = new System.Drawing.Point(0, 309);
            this.panelControlGrid.Name = "panelControlGrid";
            this.panelControlGrid.Size = new System.Drawing.Size(1124, 271);
            this.panelControlGrid.TabIndex = 3;
            // 
            // panelControlGridControl
            // 
            this.panelControlGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlGridControl.Location = new System.Drawing.Point(2, 52);
            this.panelControlGridControl.Name = "panelControlGridControl";
            this.panelControlGridControl.Size = new System.Drawing.Size(1120, 217);
            this.panelControlGridControl.TabIndex = 33;
            // 
            // printingSystem1
            // 
            this.printingSystem1.Links.AddRange(new object[] {
            this.printableComponentLink1});
            // 
            // printableComponentLink1
            // 
            // 
            // 
            // 
            this.printableComponentLink1.ImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink1.ImageCollection.ImageStream")));
            this.printableComponentLink1.Owner = null;
            this.printableComponentLink1.PrintingSystem = this.printingSystem1;
            this.printableComponentLink1.PrintingSystemBase = this.printingSystem1;
            // 
            // ListSablonIslem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1124, 580);
            this.Controls.Add(this.panelControlGrid);
            this.Controls.Add(this.panelControl2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Lilian";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "ListSablonIslem";
            this.Text = "ListSablon";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbControl)).EndInit();
            this.tbControl.ResumeLayout(false);
            this.tbGenel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelOzel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelGenelList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlGrid)).EndInit();
            this.panelControlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        #region virtuals
        public virtual void TabPage_Index_Changed(int index) { }
        public virtual void Tamam() { }
        public virtual void OzelYazdir() { }
        public virtual void TamamTum() { }
        public virtual void ParametreSet() { }
        public virtual void FilterParametreSet() { }
        public virtual void ReportParameterSet() { }
        public virtual void IlkDegerleriVer() { }
        public virtual void Listele() { }
        public virtual string IslemYapKontrol() { return ""; }
        #endregion
        #region override edilenler
        private void TAMAMbtn_Click(object sender, EventArgs e)
        {
            ParametreSet();
            string mesaj =IslemYapKontrol();
            if (mesaj == "")
                Tamam();
            else
                MessageBox.Show(mesaj);
        }
        private void IPTALbtn_Click(object sender, EventArgs e)
        {
            this.Dispose(); 
            this.Close(); 
        }
        #endregion
        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
          //  lblBilgi.Text = Convert.ToString(gridControl.gridView1.RowCount - 1) + " Kayýt";
        }
        void butonlariIsle(bool deger)
        {
            LISTELEbtn.Enabled =deger;
            IPTALbtn.Enabled = deger;
        }
        private void LISTELEbtn_Click(object sender, EventArgs e)
        {
            Listele();
            gridControl.gridView1.BestFitColumns();
        }

         
     
    }
}
