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
using Prodma.SistemB2C.Models;
using System.Collections.Generic;
using System.Text;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using Microsoft.Reporting.WinForms;
using Prodma.SistemB2C.Controllers;
using Prodma.Raporlar;
using System.Management;
//using System.Runtime.InteropServices;
namespace Prodma.WinForms
{
    /// <summary>
    /// Summary description for MDIChild.
    /// </summary>
    /// 
    public partial class ListSablonStok : Sablon
    {
     
        #region Deðiþkenler
        string defaultPrinter = "";
        string  printerName;
        int  YatayDikey;
        string  KagitSecimi;
        YaziciSec frm;
        public GridOzellikleri gridOzellikleri;
        usrRapor usrRaporEkran;
        public int varsayilanStokId = 0;
        public int varsayilanCariId = 0;
        public int varsayilanPersonelId = 0;
        public int varsayilanHesapPlaniId = 0;
        public int varsayilanSifirli = 0;
        public int tiklananButon = 0;
        public bool gridEkli = true;
        public bool raporEkli = false;
        public int sifirliId = 0;
        public int satirId = 0;
        public bool direktYazdir = false;
        bool kayitliSorgu=false;
        public Dictionary<string, string> filterParametersForm = new Dictionary<string, string>();
        public Dictionary<string, string> setValues = new Dictionary<string, string>();
        public Dictionary<string, string> reportsParametersForm = new Dictionary<string, string>();
        public string[] dinamikAlanlar;
        public string dinamikAltAlan;
      
        int maximum = 100;
        public bool gridiolusturDinamik = false;
        public bool sorguBitti = false;
        public ListSablonOzellikleriVm ListeOzellikleri = new ListSablonOzellikleriVm();
        private IContainer components;
        public PanelControl panelControl1;
        public PanelControl panelControl2;
        public BindingSource[] bn;
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
        public PanelControl panelControlGridControl;
        public Dictionary<string, string> parametersForm = new Dictionary<string, string>();
        private System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Timer timer1;
        public PanelControl panelControlGrupSecimi;
        public GridLookUpEdit Gruplke;
        private GridView gridView3;
        private LabelControl GRUP_SECIMlbl;
        public PanelControl panelGenelList;
        public PanelControl panelListeOzel;
        public LookUpEdit filtreLke;
        public SimpleButton saveFilterBtn;
        public SimpleButton OZELYAZDIRbtn;
        public SimpleButton TAMAMbtn;
        private LabelControl ALANLARlbl;
        public SimpleButton IPTALbtn;
        public CheckedComboBoxEdit gridViewColumnschl;
        private LabelControl lblBilgi;
        public SimpleButton TAMAMYAZDIRbtn;
        public GridLookUpEdit Grup2lke;
        private GridView gridView1;
        public LabelControl UST_GRUPlbl;
        private LabelControl LK_DETAY_GOSTER_E_Hlbl;
        public LookUpEdit LK_DETAY_GOSTER_E_Hlke;
        public LookUpEdit LISTE_SECIMIlke;
        public LabelControl lblBit;
        public LabelControl lblBas;
        private LabelControl DIL__IDlbl;
        public LookUpEdit DIL_IDlke;
        private SimpleButton simpleButton1;
        private SimpleButton simpleButton2;
        public usrGridIslem gridControl ;

        #endregion
        #region formolaylar
        public ListSablonStok()
        {
            InitializeComponent();
            gridControl = new usrGridIslem(GridIslemEn.Bilgilendirme,GridOzellikleriEn.Standart);
            OZELYAZDIRbtn.Enabled = false;
            gridControl.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlGridControl.Controls.Add(gridControl);
            eventHandler();
            this.ClientSize = new Size(867, 600);
            this.StartPosition = FormStartPosition.Manual;
            YardimciIslemlerKontrols.InvokeLueContainSet("LK_HAYIR_EVET_ID", LK_DETAY_GOSTER_E_Hlke);
            YardimciIslemlerKontrols.InvokeEnumSet(YardimciIslemlerKontrols.EnumToList<ListSablonListeSecimiEn>(), LISTE_SECIMIlke);
            LK_DETAY_GOSTER_E_Hlke.EditValueChanged += new System.EventHandler(this.LK_DETAY_GOSTER_E_Hlke_EditValueChanged);
            gridOzellikleri = new GridOzellikleri();

            if (Globals.gnKullaniciRolId == (int)RolEn.YabanciPlasiyer)
            {
                TAMAMbtn.Enabled = false;
            }

            if (Globals.rman.GetString("TAMAMYAZDIR") != null) { TAMAMYAZDIRbtn.Text = Globals.rman.GetString("TAMAMYAZDIR"); }
            if (Globals.rman.GetString("TAMAM") != null) { TAMAMbtn.Text = Globals.rman.GetString("TAMAM"); }
            if (Globals.rman.GetString("OZELYAZDIR") != null) { OZELYAZDIRbtn.Text = Globals.rman.GetString("OZELYAZDIR"); }
            if (Globals.rman.GetString("IPTAL") != null) { IPTALbtn.Text = Globals.rman.GetString("IPTAL"); }
            if (Globals.rman.GetString("Alanlar") != null) { ALANLARlbl.Text = Globals.rman.GetString("Alanlar"); }
            if (Globals.rman.GetString("DIL__ID") != null) { DIL__IDlbl.Text = Globals.rman.GetString("DIL__ID"); }
            if (Globals.rman.GetString("saveFilter") != null) { saveFilterBtn.Text = Globals.rman.GetString("saveFilter"); }
            if (Globals.rman.GetString("GRUP_SECIM") != null) { GRUP_SECIMlbl.Text = Globals.rman.GetString("GRUP_SECIM"); }
            if (Globals.rman.GetString("LK_DETAY_GOSTER_E_H") != null) { LK_DETAY_GOSTER_E_Hlbl.Text = Globals.rman.GetString("LK_DETAY_GOSTER_E_H"); }
            if (Globals.rman.GetString("UST_GRUP") != null) { UST_GRUPlbl.Text = Globals.rman.GetString("UST_GRUP"); }
            
            

        }
        public void ListSablon_Load(object sender, EventArgs e)
        {
            YardimciIslemlerKontrols.InvokeLueContainSet("DIL_ID", DIL_IDlke);
            YardimciIslemlerKontrols.LueDsDuzenle(DIL_IDlke);
            DIL_IDlke.EditValue = Convert.ToInt32(Dil.Turkce);
            YardimciIslemlerKontrols.LueDsDuzenle(LK_DETAY_GOSTER_E_Hlke);
            YardimciIslemlerKontrols.LueEnumDuzenle(LISTE_SECIMIlke);
            gridControl.gridView1.OptionsView.ShowGroupPanel = true;
            gridControl.gridView1.GroupPanelText = "Gruplamak Ýstediðiniz Alaný Bu Bölgeye Sürükleyiniz";
            panelControlGrupSecimi.Visible = ListeOzellikleri.GrupPaneliGosterilsinMi;
          
            if (ListeOzellikleri.listSablonTip == (int)ListSablonEn.DinamikUpdate)
            {
                //DIL__IDlbl.Visible=false;
                //DIL_IDlke.Visible=false;
                OZELYAZDIRbtn.Text = "KAYIT";
                panelControlGrupSecimi.Visible = false;
                ListeOzellikleri.GrupPaneliGosterilsinMi =false;
                ListeOzellikleri.IkinciGrupGosterilsinMi = false;
                TAMAMYAZDIRbtn.Visible = false;
                //filtreLke.Visible = false;
                //gridViewColumnschl.Visible = false;
                //Alanlarlbl.Visible = false;
                //saveFilterBtn.Visible = false;
            }
            if (ListeOzellikleri.listSablonTip == (int)ListSablonEn.ListeleIslemYap)
            {
                //DIL__IDlbl.Visible = false;
                //DIL_IDlke.Visible = false;
                OZELYAZDIRbtn.Visible = false;
                panelControlGrupSecimi.Visible = false;
                ListeOzellikleri.GrupPaneliGosterilsinMi = false;
                ListeOzellikleri.IkinciGrupGosterilsinMi = false;
                TAMAMYAZDIRbtn.Visible = false;
                filtreLke.Visible = false;
                gridViewColumnschl.Visible = false;
                ALANLARlbl.Visible = false;
                saveFilterBtn.Visible = false;
            }
            else if (ListeOzellikleri.listSablonTip == (int)ListSablonEn.DinamikListe)
            {
                LISTE_SECIMIlke.Visible = false;
                ListeOzellikleri.GrupPaneliGosterilsinMi = false;
                ListeOzellikleri.IkinciGrupGosterilsinMi = false;
                panelControlGrupSecimi.Visible = false;
            }
            else if (ListeOzellikleri.listSablonTip == (int)ListSablonEn.StandartRaporsuz || ListeOzellikleri.listSablonTip == (int)ListSablonEn.TabPagesizRaporsuz)
            {
                LISTE_SECIMIlke.Visible = false;
                ListeOzellikleri.IkinciGrupGosterilsinMi = false;
                OZELYAZDIRbtn.Visible = false;
                TAMAMYAZDIRbtn.Visible = false;
                //DIL__IDlbl.Visible = false;
                //DIL_IDlke.Visible = false;
            }
            if (ListeOzellikleri.EkModelli == (int)ListeEkModelEn.Hayir)
            {
                LISTE_SECIMIlke.Visible = false;
            }
            else
            {
                LISTE_SECIMIlke.Visible = true;
                LISTE_SECIMIlke.EditValue = ListSablonListeSecimiEn.Genel;
            }
            IlkDegerleriVer();
            LK_DETAY_GOSTER_E_Hlke.EditValue = (int)EvetHayirEn.Evet;
            //YetkiIslemlerVm listYetki = new YetkiIslemlerVm();
            //if (ListeOzellikleri.sinirliYetkiEH == null)
            //{
            //    ListeOzellikleri.sinirliYetkiEH = (int)EvetHayirEn.Hayir;
            //    listYetki = ListDenemeService.GetYETKI_ISLEMLER(Globals.gnKullaniciId, ListeOzellikleri.ListeSahipTipId, (int)IslemListeEn.ISLEM, ListeOzellikleri.raporYetkiAdi);
            //}
            //if (listYetki != null  && listYetki.SINIRLI_YETKI_E_H == (int)EvetHayirEn.Evet)
            //{
            //    ListeOzellikleri.sinirliYetkiEH = (int)EvetHayirEn.Evet;
            //    gridViewColumnschl.Enabled = false;
            //    saveFilterBtn.Enabled = false;
            //    LISTE_SECIMIlke.Enabled = false;
            //}
            gridControl.gridIslemAdi = ListeOzellikleri.mt!=null? ListeOzellikleri.mt[0]: "";
           // VarSayilanRaporDegerleriniAyarla();
        }
        public void ListSablon_Shown(object sender, EventArgs e)
        {
            try
            {
                ActiveControl = (Control)gridControl.gridControl1;
            }
            catch (Exception)
            {
                
            //    throw;
            }
            if (ListeOzellikleri.mt != null)
            {
                filtreLke.Properties.DataSource = ListDenemeService.GetFILTRELER_ID(Globals.gnKullaniciId, ListeOzellikleri.mt[0],(int)FiltreTipEn.Listeler);
                filtreLke.Properties.ValueMember = "ID";
                filtreLke.Properties.DisplayMember = "AD";
                filtreLke.Properties.NullText = "Filtreler";
                filtreLke.Properties.PopulateColumns();
                filtreLke.Properties.Columns["ID"].Visible = false;
            }
            VarSayilanRaporDegerleriniAyarla();
            YetkiIslemlerVm listYetki = new YetkiIslemlerVm();
            if (ListeOzellikleri.sinirliYetkiEH != null && (GenelParametreSng.Nesne().kullaniciBilgileri.ROL_ID != (int)RolEn.Admin && GenelParametreSng.Nesne().kullaniciBilgileri.ROL_ID != (int)RolEn.AdminAlt))
            {
                if (ListeOzellikleri.sinirliYetkiEH == (int)EvetHayirEn.Evet)
                {
                    gridViewColumnschl.Enabled = false;
                    saveFilterBtn.Enabled = false;
                    LISTE_SECIMIlke.Enabled = false;
                }
                else
                {
                    gridViewColumnschl.Enabled = true;
                    saveFilterBtn.Enabled = true;
                    LISTE_SECIMIlke.Enabled = true;
                }
            }
            else
            {
                ListeOzellikleri.sinirliYetkiEH = (int)EvetHayirEn.Hayir;
                listYetki = ListDenemeService.GetYETKI_ISLEMLER(Globals.gnKullaniciId, ListeOzellikleri.ListeSahipTipId, (int)IslemListeEn.LISTE, ListeOzellikleri.raporYetkiAdi);
                if (listYetki != null && listYetki.SINIRLI_YETKI_E_H != null && listYetki.SINIRLI_YETKI_E_H == (int)EvetHayirEn.Evet)
                {
                    ListeOzellikleri.sinirliYetkiEH = (int)EvetHayirEn.Evet;
                    gridViewColumnschl.Enabled = false;
                    saveFilterBtn.Enabled = false;
                    LISTE_SECIMIlke.Enabled = false;
                }
            }
            

        }
        private void ListSablonStok_Shown(object sender, EventArgs e)
        {

        }
        private void ListSablonStok_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                this.Close();
                this.Dispose();
            }
        }
        private void eventHandler()
        {
            this.Load += new System.EventHandler(this.ListSablon_Load);
            this.Shown += new System.EventHandler(this.ListSablon_Shown);
            this.TAMAMbtn.Click += new System.EventHandler(this.TAMAMbtn_Click);
            this.OZELYAZDIRbtn.Click += new System.EventHandler(this.OZELYAZDIRbtn_Click);
            this.IPTALbtn.Click += new System.EventHandler(this.IPTALbtn_Click);
            this.printableComponentLink1.CreateReportHeaderArea += new DevExpress.XtraPrinting.CreateAreaEventHandler(this.printableComponentLink1_CreateReportHeaderArea);
            this.printableComponentLink1.Component = gridControl.gridControl1;
            this.gridViewColumnschl.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.gridViewColumnschl_Closed);
            this.gridControl.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            //this.saveFilter.Click += new System.EventHandler(this.saveFilter_Click);
            this.filtreLke.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.filtreLke_Closed);
            this.tbControl.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tbControl_SelectedIndexChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TanitimSablon_FormClosing);
            //this.filtreLke.EditValueChanged += new System.EventHandler(this.filtreLke_EditValueChanged);
        }
        private void tbControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage_Index_Changed(tbControl.SelectedTabPageIndex);// tureyen forma gidis
           // currentTab = tabControl1.SelectedTabPageIndex; // tab seciminin tureyen formda ayarlanmasi icin konuldu
        }
        public override void Form_Acilis(object sender, EventArgs e)
        {
            if (ListeOzellikleri.mt != null  &&  ListeOzellikleri.listSablonTip != (int)ListSablonEn.DinamikUpdate)
            {
                BindingSource bnSource = new BindingSource();
                bnSource.DataSource = ListDenemeService.GetFILTRELER_ID(Globals.gnKullaniciId, ListeOzellikleri.mt[0], (int)FiltreTipEn.Listeler);
                if (bnSource.Count > 0)
                {
                    filtreLke.Properties.DataSource = bnSource;
                    filtreLke.Properties.ValueMember = "ID";
                    filtreLke.Properties.DisplayMember = "AD";
                    filtreLke.Properties.NullText = "Filtreler";
                    filtreLke.Properties.PopulateColumns();
                    filtreLke.Properties.Columns["ID"].Visible = false;
                }
                
            }
            VarSayilanRaporDegerleriniAyarla();
        }
        private void TanitimSablon_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            for (int i = 0; i < bn.Length; i++)
            {
                if (bn[i] != null)
                {
                    bn[i].Dispose();
                }
            }
            if (usrRaporEkran != null)
            {
                usrRaporEkran.reportViewer1.LocalReport.ReleaseSandboxAppDomain();
            }
            gridControl.gridControl1.Dispose();
            gridControl.gridView1.Dispose();
        }
        protected override void Dispose(bool disposing)
        {
            //bn = null;
            if (defaultPrinter != "")
            {
                setDefaultPrinter(defaultPrinter);
            }
            //usrRaporEkran.reportViewer1.LocalReport.ReleaseSandboxAppDomain();
            //usrRaporEkran.Dispose();
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
            GC.Collect();
        }
        #endregion
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListSablonStok));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.DIL_IDlke = new DevExpress.XtraEditors.LookUpEdit();
            this.DIL__IDlbl = new DevExpress.XtraEditors.LabelControl();
            this.lblBit = new DevExpress.XtraEditors.LabelControl();
            this.lblBas = new DevExpress.XtraEditors.LabelControl();
            this.lblBilgi = new DevExpress.XtraEditors.LabelControl();
            this.TAMAMYAZDIRbtn = new DevExpress.XtraEditors.SimpleButton();
            this.OZELYAZDIRbtn = new DevExpress.XtraEditors.SimpleButton();
            this.TAMAMbtn = new DevExpress.XtraEditors.SimpleButton();
            this.ALANLARlbl = new DevExpress.XtraEditors.LabelControl();
            this.IPTALbtn = new DevExpress.XtraEditors.SimpleButton();
            this.gridViewColumnschl = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.filtreLke = new DevExpress.XtraEditors.LookUpEdit();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.saveFilterBtn = new DevExpress.XtraEditors.SimpleButton();
            this.LISTE_SECIMIlke = new DevExpress.XtraEditors.LookUpEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.tbControl = new DevExpress.XtraTab.XtraTabControl();
            this.tbGenel = new DevExpress.XtraTab.XtraTabPage();
            this.panelListeOzel = new DevExpress.XtraEditors.PanelControl();
            this.panelGenelList = new DevExpress.XtraEditors.PanelControl();
            this.panelControlGrupSecimi = new DevExpress.XtraEditors.PanelControl();
            this.LK_DETAY_GOSTER_E_Hlbl = new DevExpress.XtraEditors.LabelControl();
            this.Grup2lke = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.UST_GRUPlbl = new DevExpress.XtraEditors.LabelControl();
            this.Gruplke = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GRUP_SECIMlbl = new DevExpress.XtraEditors.LabelControl();
            this.LK_DETAY_GOSTER_E_Hlke = new DevExpress.XtraEditors.LookUpEdit();
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
            ((System.ComponentModel.ISupportInitialize)(this.DIL_IDlke.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewColumnschl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filtreLke.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LISTE_SECIMIlke.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbControl)).BeginInit();
            this.tbControl.SuspendLayout();
            this.tbGenel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelListeOzel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelGenelList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlGrupSecimi)).BeginInit();
            this.panelControlGrupSecimi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grup2lke.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gruplke.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LK_DETAY_GOSTER_E_Hlke.Properties)).BeginInit();
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
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.DIL_IDlke);
            this.panelControl1.Controls.Add(this.DIL__IDlbl);
            this.panelControl1.Controls.Add(this.lblBit);
            this.panelControl1.Controls.Add(this.lblBas);
            this.panelControl1.Controls.Add(this.lblBilgi);
            this.panelControl1.Controls.Add(this.TAMAMYAZDIRbtn);
            this.panelControl1.Controls.Add(this.OZELYAZDIRbtn);
            this.panelControl1.Controls.Add(this.TAMAMbtn);
            this.panelControl1.Controls.Add(this.ALANLARlbl);
            this.panelControl1.Controls.Add(this.IPTALbtn);
            this.panelControl1.Controls.Add(this.gridViewColumnschl);
            this.panelControl1.Controls.Add(this.filtreLke);
            this.panelControl1.Controls.Add(this.progressBar1);
            this.panelControl1.Controls.Add(this.saveFilterBtn);
            this.panelControl1.Controls.Add(this.LISTE_SECIMIlke);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1120, 56);
            this.panelControl1.TabIndex = 1;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(175, 2);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(33, 23);
            this.simpleButton2.TabIndex = 669;
            this.simpleButton2.Text = "....";
            this.simpleButton2.Visible = false;
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            //this.simpleButton1.BackgroundImage = global::Prodma.DataAccessB2C.Resource1.zoom;
            //this.simpleButton1.Image = global::Prodma.DataAccessB2C.Resource1.zoom;
            this.simpleButton1.Location = new System.Drawing.Point(445, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(28, 23);
            this.simpleButton1.TabIndex = 82;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // DIL_IDlke
            // 
            this.DIL_IDlke.Location = new System.Drawing.Point(613, 21);
            this.DIL_IDlke.Name = "DIL_IDlke";
            this.DIL_IDlke.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.DIL_IDlke.Properties.Appearance.Options.UseBackColor = true;
            this.DIL_IDlke.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DIL_IDlke.Size = new System.Drawing.Size(100, 20);
            this.DIL_IDlke.TabIndex = 81;
            // 
            // DIL__IDlbl
            // 
            this.DIL__IDlbl.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.DIL__IDlbl.Location = new System.Drawing.Point(613, 4);
            this.DIL__IDlbl.Name = "DIL__IDlbl";
            this.DIL__IDlbl.Size = new System.Drawing.Size(14, 13);
            this.DIL__IDlbl.TabIndex = 80;
            this.DIL__IDlbl.Text = "Dil";
            // 
            // lblBit
            // 
            this.lblBit.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblBit.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblBit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblBit.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBit.Location = new System.Drawing.Point(308, 28);
            this.lblBit.Name = "lblBit";
            this.lblBit.Size = new System.Drawing.Size(131, 13);
            this.lblBit.TabIndex = 79;
            this.lblBit.Tag = "B";
            // 
            // lblBas
            // 
            this.lblBas.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblBas.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblBas.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblBas.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBas.Location = new System.Drawing.Point(138, 28);
            this.lblBas.Name = "lblBas";
            this.lblBas.Size = new System.Drawing.Size(122, 13);
            this.lblBas.TabIndex = 79;
            this.lblBas.Tag = "B";
            // 
            // lblBilgi
            // 
            this.lblBilgi.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblBilgi.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblBilgi.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblBilgi.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBilgi.Location = new System.Drawing.Point(3, 28);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Size = new System.Drawing.Size(93, 13);
            this.lblBilgi.TabIndex = 79;
            this.lblBilgi.Tag = "B";
            // 
            // TAMAMYAZDIRbtn
            // 
            this.TAMAMYAZDIRbtn.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.TAMAMYAZDIRbtn.Appearance.Options.UseFont = true;
            this.TAMAMYAZDIRbtn.Location = new System.Drawing.Point(84, 2);
            this.TAMAMYAZDIRbtn.Name = "TAMAMYAZDIRbtn";
            this.TAMAMYAZDIRbtn.Size = new System.Drawing.Size(124, 23);
            this.TAMAMYAZDIRbtn.TabIndex = 56;
            this.TAMAMYAZDIRbtn.Text = "LÝSTE YAZDIR";
            this.TAMAMYAZDIRbtn.Click += new System.EventHandler(this.TAMAMYAZDIRbtn_Click);
            // 
            // OZELYAZDIRbtn
            // 
            this.OZELYAZDIRbtn.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.OZELYAZDIRbtn.Appearance.Options.UseFont = true;
            this.OZELYAZDIRbtn.Location = new System.Drawing.Point(214, 2);
            this.OZELYAZDIRbtn.Name = "OZELYAZDIRbtn";
            this.OZELYAZDIRbtn.Size = new System.Drawing.Size(71, 23);
            this.OZELYAZDIRbtn.TabIndex = 56;
            this.OZELYAZDIRbtn.Text = "YAZDIR";
            // 
            // TAMAMbtn
            // 
            this.TAMAMbtn.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.TAMAMbtn.Appearance.Options.UseFont = true;
            this.TAMAMbtn.Location = new System.Drawing.Point(291, 2);
            this.TAMAMbtn.Name = "TAMAMbtn";
            this.TAMAMbtn.Size = new System.Drawing.Size(71, 23);
            this.TAMAMbtn.TabIndex = 53;
            this.TAMAMbtn.Text = "TAMAM";
            // 
            // ALANLARlbl
            // 
            this.ALANLARlbl.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ALANLARlbl.Location = new System.Drawing.Point(476, 3);
            this.ALANLARlbl.Name = "ALANLARlbl";
            this.ALANLARlbl.Size = new System.Drawing.Size(40, 13);
            this.ALANLARlbl.TabIndex = 59;
            this.ALANLARlbl.Text = "Alanlar";
            // 
            // IPTALbtn
            // 
            this.IPTALbtn.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.IPTALbtn.Appearance.Options.UseFont = true;
            this.IPTALbtn.Location = new System.Drawing.Point(368, 2);
            this.IPTALbtn.Name = "IPTALbtn";
            this.IPTALbtn.Size = new System.Drawing.Size(71, 23);
            this.IPTALbtn.TabIndex = 55;
            this.IPTALbtn.Text = "ÝPTAL";
            // 
            // gridViewColumnschl
            // 
            this.gridViewColumnschl.Location = new System.Drawing.Point(476, 21);
            this.gridViewColumnschl.Name = "gridViewColumnschl";
            this.gridViewColumnschl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridViewColumnschl.Properties.NullText = "[EditValue is null]";
            this.gridViewColumnschl.Size = new System.Drawing.Size(131, 20);
            this.gridViewColumnschl.TabIndex = 57;
            // 
            // filtreLke
            // 
            this.filtreLke.Location = new System.Drawing.Point(719, 21);
            this.filtreLke.Name = "filtreLke";
            this.filtreLke.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.filtreLke.Size = new System.Drawing.Size(124, 20);
            this.filtreLke.TabIndex = 52;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(2, 43);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1116, 11);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 48;
            // 
            // saveFilterBtn
            // 
            this.saveFilterBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.saveFilterBtn.Appearance.Options.UseFont = true;
            this.saveFilterBtn.Location = new System.Drawing.Point(719, 2);
            this.saveFilterBtn.Name = "saveFilterBtn";
            this.saveFilterBtn.Size = new System.Drawing.Size(124, 19);
            this.saveFilterBtn.TabIndex = 29;
            this.saveFilterBtn.Text = "FÝLTRE ÝÞLEMLERÝ";
            this.saveFilterBtn.Click += new System.EventHandler(this.saveFilter_Click);
            // 
            // LISTE_SECIMIlke
            // 
            this.LISTE_SECIMIlke.Location = new System.Drawing.Point(4, 3);
            this.LISTE_SECIMIlke.Name = "LISTE_SECIMIlke";
            this.LISTE_SECIMIlke.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LISTE_SECIMIlke.Properties.PopupSizeable = false;
            this.LISTE_SECIMIlke.Size = new System.Drawing.Size(59, 20);
            this.LISTE_SECIMIlke.TabIndex = 58;
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
            this.tbGenel.Controls.Add(this.panelListeOzel);
            this.tbGenel.Controls.Add(this.panelGenelList);
            this.tbGenel.Controls.Add(this.panelControlGrupSecimi);
            this.tbGenel.Name = "tbGenel";
            this.tbGenel.Size = new System.Drawing.Size(1114, 277);
            this.tbGenel.Text = "Genel";
            // 
            // panelListeOzel
            // 
            this.panelListeOzel.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelListeOzel.Location = new System.Drawing.Point(440, 0);
            this.panelListeOzel.Name = "panelListeOzel";
            this.panelListeOzel.Size = new System.Drawing.Size(401, 246);
            this.panelListeOzel.TabIndex = 39;
            // 
            // panelGenelList
            // 
            this.panelGenelList.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelGenelList.Location = new System.Drawing.Point(0, 0);
            this.panelGenelList.Name = "panelGenelList";
            this.panelGenelList.Size = new System.Drawing.Size(440, 246);
            this.panelGenelList.TabIndex = 38;
            // 
            // panelControlGrupSecimi
            // 
            this.panelControlGrupSecimi.Controls.Add(this.LK_DETAY_GOSTER_E_Hlbl);
            this.panelControlGrupSecimi.Controls.Add(this.Grup2lke);
            this.panelControlGrupSecimi.Controls.Add(this.UST_GRUPlbl);
            this.panelControlGrupSecimi.Controls.Add(this.Gruplke);
            this.panelControlGrupSecimi.Controls.Add(this.GRUP_SECIMlbl);
            this.panelControlGrupSecimi.Controls.Add(this.LK_DETAY_GOSTER_E_Hlke);
            this.panelControlGrupSecimi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControlGrupSecimi.Location = new System.Drawing.Point(0, 246);
            this.panelControlGrupSecimi.Name = "panelControlGrupSecimi";
            this.panelControlGrupSecimi.Size = new System.Drawing.Size(1114, 31);
            this.panelControlGrupSecimi.TabIndex = 37;
            // 
            // LK_DETAY_GOSTER_E_Hlbl
            // 
            this.LK_DETAY_GOSTER_E_Hlbl.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.LK_DETAY_GOSTER_E_Hlbl.Location = new System.Drawing.Point(306, 8);
            this.LK_DETAY_GOSTER_E_Hlbl.Name = "LK_DETAY_GOSTER_E_Hlbl";
            this.LK_DETAY_GOSTER_E_Hlbl.Size = new System.Drawing.Size(75, 13);
            this.LK_DETAY_GOSTER_E_Hlbl.TabIndex = 43;
            this.LK_DETAY_GOSTER_E_Hlbl.Text = "Detay Göster";
            // 
            // Grup2lke
            // 
            this.Grup2lke.Location = new System.Drawing.Point(633, 5);
            this.Grup2lke.Name = "Grup2lke";
            this.Grup2lke.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Grup2lke.Properties.View = this.gridView1;
            this.Grup2lke.Size = new System.Drawing.Size(208, 20);
            this.Grup2lke.TabIndex = 23;
            this.Grup2lke.Visible = false;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // UST_GRUPlbl
            // 
            this.UST_GRUPlbl.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.UST_GRUPlbl.Location = new System.Drawing.Point(538, 8);
            this.UST_GRUPlbl.Name = "UST_GRUPlbl";
            this.UST_GRUPlbl.Size = new System.Drawing.Size(89, 13);
            this.UST_GRUPlbl.TabIndex = 22;
            this.UST_GRUPlbl.Text = "Üst Grup Seçimi";
            this.UST_GRUPlbl.Visible = false;
            // 
            // Gruplke
            // 
            this.Gruplke.Location = new System.Drawing.Point(84, 5);
            this.Gruplke.Name = "Gruplke";
            this.Gruplke.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Gruplke.Properties.View = this.gridView3;
            this.Gruplke.Size = new System.Drawing.Size(193, 20);
            this.Gruplke.TabIndex = 21;
            // 
            // gridView3
            // 
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // GRUP_SECIMlbl
            // 
            this.GRUP_SECIMlbl.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.GRUP_SECIMlbl.Location = new System.Drawing.Point(11, 8);
            this.GRUP_SECIMlbl.Name = "GRUP_SECIMlbl";
            this.GRUP_SECIMlbl.Size = new System.Drawing.Size(67, 13);
            this.GRUP_SECIMlbl.TabIndex = 20;
            this.GRUP_SECIMlbl.Text = "Grup Seçimi";
            // 
            // LK_DETAY_GOSTER_E_Hlke
            // 
            this.LK_DETAY_GOSTER_E_Hlke.Location = new System.Drawing.Point(387, 5);
            this.LK_DETAY_GOSTER_E_Hlke.Name = "LK_DETAY_GOSTER_E_Hlke";
            this.LK_DETAY_GOSTER_E_Hlke.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LK_DETAY_GOSTER_E_Hlke.Size = new System.Drawing.Size(121, 20);
            this.LK_DETAY_GOSTER_E_Hlke.TabIndex = 42;
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
            this.xtraTabPage3.AutoScroll = true;
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(1114, 277);
            this.xtraTabPage3.Text = "xtraTabPage3";
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.AutoScroll = true;
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(1114, 277);
            this.xtraTabPage4.Text = "xtraTabPage4";
            // 
            // xtraTabPage5
            // 
            this.xtraTabPage5.AutoScroll = true;
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.Size = new System.Drawing.Size(1114, 277);
            this.xtraTabPage5.Text = "xtraTabPage5";
            // 
            // xtraTabPage6
            // 
            this.xtraTabPage6.AutoScroll = true;
            this.xtraTabPage6.Name = "xtraTabPage6";
            this.xtraTabPage6.Size = new System.Drawing.Size(1114, 277);
            this.xtraTabPage6.Text = "xtraTabPage6";
            // 
            // xtraTabPage7
            // 
            this.xtraTabPage7.AutoScroll = true;
            this.xtraTabPage7.Name = "xtraTabPage7";
            this.xtraTabPage7.Size = new System.Drawing.Size(1114, 277);
            this.xtraTabPage7.Text = "xtraTabPage7";
            // 
            // xtraTabPage8
            // 
            this.xtraTabPage8.AutoScroll = true;
            this.xtraTabPage8.Name = "xtraTabPage8";
            this.xtraTabPage8.Size = new System.Drawing.Size(1114, 277);
            this.xtraTabPage8.Text = "xtraTabPage8";
            // 
            // xtraTabPage9
            // 
            this.xtraTabPage9.AutoScroll = true;
            this.xtraTabPage9.Name = "xtraTabPage9";
            this.xtraTabPage9.Size = new System.Drawing.Size(1114, 277);
            this.xtraTabPage9.Text = "xtraTabPage9";
            // 
            // xtraTabPage10
            // 
            this.xtraTabPage10.AutoScroll = true;
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
            this.panelControlGridControl.Location = new System.Drawing.Point(2, 58);
            this.panelControlGridControl.Name = "panelControlGridControl";
            this.panelControlGridControl.Size = new System.Drawing.Size(1120, 211);
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
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ListSablonStok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1124, 580);
            this.Controls.Add(this.panelControlGrid);
            this.Controls.Add(this.panelControl2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.LookAndFeel.SkinName = "Lilian";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "ListSablonStok";
            this.Text = "ListSablon";
            this.Shown += new System.EventHandler(this.ListSablonStok_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListSablonStok_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DIL_IDlke.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewColumnschl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filtreLke.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LISTE_SECIMIlke.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbControl)).EndInit();
            this.tbControl.ResumeLayout(false);
            this.tbGenel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelListeOzel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelGenelList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlGrupSecimi)).EndInit();
            this.panelControlGrupSecimi.ResumeLayout(false);
            this.panelControlGrupSecimi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grup2lke.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gruplke.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LK_DETAY_GOSTER_E_Hlke.Properties)).EndInit();
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
        public void OzelYazdir()
        {

            try
            {
                timer1.Enabled = false;
                this.panelControlGridControl.Controls.Clear();
                usrRaporEkran = new usrRapor();
                if (parametersForm.ContainsKey("YAZICI"))
                {
                  setDefaultPrinter(parametersForm["YAZICI"]);
                }
                gridEkli = false;
                this.panelControlGridControl.Controls.Add(usrRaporEkran);
                raporEkli = true;
                usrRaporEkran.RaporGoruntule(bn, ListeOzellikleri.reportDataSet, ListeOzellikleri.reportName, ListeOzellikleri.prmRapor, parametersForm);
                usrRaporEkran.Dock = DockStyle.Fill;
                usrRaporEkran.Show();
                
            }
            catch (Exception ex)
            {
                sorguBitti = false;
                timer1.Enabled = false;
                MessageBox.Show(ex.InnerException.ToString());
            }
        }
        public virtual void TamamTum() { }
        public virtual void ParametreSet() { }
        public virtual void FilterParametreSet() { }
        public virtual void ReportParameterSet() { }
        public virtual void IlkDegerleriVer() { }
        public virtual void SeriKayit() { }
        public virtual void Sil() { }
        public virtual void SetFilter(){ }
        public virtual void VarSayilanRaporDegerleriniAyarla() { }
        public virtual void GridGoruntuAyarla() { }
        public virtual bool IslemYapKontrol() { return true; }
        #endregion
        #region override edilenler
        private void TAMAMbtn_Click(object sender, EventArgs e)
        {
            if (bn[0] != null)
            {
                bn[0].DataSource = null;
                bn[0].Dispose();
                GC.Collect();
                if (gridControl.gridControl1.DataSource != null)
                {
                    gridControl.gridControl1.DataSource = null;
                }
                bn[0] = new BindingSource();
            }
            if (ListeOzellikleri.sinirliYetkiEH == (int)EvetHayirEn.Evet)
            {
                if (filtreLke.EditValue==null)
                {
                    MessageBox.Show("Kayýtlý Listelerden Bir Seçim Yapmalýsýnýz");
                    return;
                }
            }
            gridEkli = true;
            this.panelControlGridControl.Controls.Clear();
            this.panelControlGridControl.Controls.Add(gridControl);
            tiklananButon = 1;
            kayitliSorgu = false;
            direktYazdir = false;
            Listele(); // icinde parametreset , reportParametreSet,Goster var
            OZELYAZDIRbtn.Enabled = true;
        }
        private void TAMAMYAZDIRbtn_Click(object sender, EventArgs e)
        {
            if (ListeOzellikleri.listSablonTip == (int)ListSablonEn.DinamikUpdate)
            {
                Sil();
            }
                else
                {

                if (ListeOzellikleri.sinirliYetkiEH == (int)EvetHayirEn.Evet)
                {
                    if (filtreLke.EditValue == null)
                    {
                        MessageBox.Show("Kayýtlý Listelerden Bir Seçim Yapmalýsýnýz");
                        return;
                    }
                }
                if (ListeOzellikleri.reportName==null || ListeOzellikleri.reportName.Trim() == "")
                {
                    MessageBox.Show("Rapor Tanýmlanmamýþ");
                    return;
                }
                OZELYAZDIRbtn.Enabled = false;
                this.panelControlGridControl.Controls.Clear();
                kayitliSorgu = false;
                direktYazdir = true;
                //ReportParameterSet();
                string yazici = "";
                if (parametersForm.ContainsKey("YAZICI")) yazici = parametersForm["YAZICI"];
                string yatayDikey = "";
                if (parametersForm.ContainsKey("YATAYDIKEY")) yatayDikey = parametersForm["YATAYDIKEY"];
                string kagitSecimi = "";
                if (parametersForm.ContainsKey("KAGITSECIMI")) kagitSecimi = parametersForm["KAGITSECIMI"];
                ParametreSet();
                parametersForm.Add("DIL_ID", Convert.ToInt32(DIL_IDlke.EditValue).ToString());
                if (yazici.Trim() !="") parametersForm.Add("YAZICI", yazici);
                if (yatayDikey.Trim() != "") parametersForm.Add("YATAYDIKEY", yatayDikey);
                if (kagitSecimi.Trim() != "") parametersForm.Add("KAGITSECIMI", kagitSecimi);
                Goster();
            }            
        }
        public void Goster()
        {
         
                timer1.Enabled = true;
                progressBar1.Value = 0;
                progressBar1.Maximum = maximum;
                progressBar1.Step = 1;
                timer1.Enabled = true;
                lblBas.Text = DateTime.Now.ToString();
                Thread t = new Thread(Tamam);
                t.Start();
                Thread.Sleep(15);
 
        }
        public void griddoldur()
        {
            if (gridEkli == true)
            {
                timer1.Enabled = false;
                gridControl.gridControl1.DataSource = bn[0];
                lblBit.Text = DateTime.Now.ToString();
                GridViewCheckedComboBoxLoad();
                if (setValues.ContainsKey("gridViewColumnschl"))
                {
                    gridViewColumnschl.SetEditValue(setValues["gridViewColumnschl"]);
                }// griddeki alan secimi kayitlar yuklendikten sonra yapiliyor.
                //if (kayitliSorgu == true)
                //{
                //    if (setValues.ContainsKey("gridViewColumnschl")) { gridViewColumnschl.SetEditValue(setValues["gridViewColumnschl"]); gridColumnYenile(); }// griddeki alan secimi kayitlar yuklendikten sonra yapiliyor.
                //}
                //else
                //{
                //    gridColumnYenile();
                //}
                gridColumnYenile();

                
                if (bn!=null)
                {
                    //string s = "Kayýt Listelendi";
                    //if (Globals.rman.GetString("Kayýt Listelendi") != null) { s = Globals.rman.GetString("Kayýt Listelendi"); }
                    lblBilgi.Text = bn[0].Count + " " + YardimciIslemler.IstenilenDileCevir("Kayýt Listelendi");
                    gridControl.gridView1.BestFitColumns();    
                }
                gridControl.PrintOzellikDuzenle();
               
                //gridControl.gridView1.GroupFooterShowMode = GroupFooterShowMode.Hidden;
                //gridControl.gridView1.OptionsView.ShowGroupExpandCollapseButtons = false;
                //ListForm frm = new ListForm();
                ////frm.Controls.Add(panelControl1);
                //frm.StartPosition = FormStartPosition.CenterParent;
                //frm.WindowState = FormWindowState.Maximized;
                ////frm.Controls.Add(gridControl);
                //frm.grd = gridControl;
                //frm.Controls.Add(frm.grd);
                ////frm.Controls.Add(gridView1);
                //frm.ShowDialog();

                //gridControl = frm.grd;
                //this.panelControlGridControl.Controls.Add(gridControl);
            }
            else
            {
                this.panelControlGridControl.Controls.Remove(gridControl);
                gridEkli = true;
             }
        }
        private void printableComponentLink1_CreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
        {
            string d = gridControl.gridView1.FilterPanelText;
            DevExpress.XtraPrinting.TextBrick brick;
            brick = e.Graph.DrawString(this.Text, Color.Navy, new RectangleF(0, 0, 500, 40), DevExpress.XtraPrinting.BorderSide.None);
            brick.Font = new Font("Tahoma", 8);
            brick.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);
            DevExpress.XtraPrinting.TextBrick brick1;
            brick1 = e.Graph.DrawString(gridControl.gridView1.FilterPanelText, Color.Navy, new RectangleF(0, 30, 500, 40), DevExpress.XtraPrinting.BorderSide.None);
            brick1.Font = new Font("Tahoma", 8);
            brick1.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);
        }
        private void OZELYAZDIRbtn_Click(object sender, EventArgs e)
        {
            if (ListeOzellikleri.listSablonTip == (int)ListSablonEn.DinamikUpdate)
            {
                SeriKayit();
            }
            else
            {
                if (ListeOzellikleri.reportName.Trim() == "")
                {
                    MessageBox.Show("Rapor Tanýmlanmamýþ");
                    return;
                }
                else
                {
                    ReportParameterSet();
                }
                OzelYazdir();
            }
            OZELYAZDIRbtn.Enabled = false;
        }
        private void IPTALbtn_Click(object sender, EventArgs e)
        {
            this.Dispose(); 
            this.Close(); 
        }
        #endregion
        void GridGoruntuAyarlaDefault()
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn item in this.gridControl.gridView1.Columns)
            {
                if (item.FieldName == "GRUP_SECIM1" || item.FieldName == "GRUP_SECIM2" || item.FieldName == "GRUP_SECIM_KOD_1" || item.FieldName == "GRUP_SECIM_AD_1" || item.FieldName == "GRUP_SECIM_KOD_2" || item.FieldName == "GRUP_SECIM_AD_2")
                {
                    item.Visible = false;
                }
                if (item.FieldName == "GRUP_SECIM" && Gruplke.Visible == false)
                {
                    item.Visible = false;
                }
            }
            GridGoruntuAyarla();
        }
        void Listele()
        {
                butonlariIsle(false); 
                maximum = 300;
               
                ParametreSet();
                parametersForm.Add("DIL_ID", Convert.ToInt32(DIL_IDlke.EditValue).ToString());
                if (ListeOzellikleri.listSablonTip ==  (int)ListSablonEn.DinamikUpdate)
                {
                    gridControl.gridView1.Columns.Clear();
                    List<Alanlar> list = new List<Alanlar>();
                    list = ListDenemeService.GetALANLAR("product");
                    if (ListeOzellikleri.dinamikUpdateTabloTip == "STOK" || ListeOzellikleri.dinamikUpdateTabloTip == "CARI")
                    {
                        ListeOzellikleri.dinamikUpdateTabloTip = ListeOzellikleri.dinamikUpdateTabloTip + "TABLOSU";
                        YardimciIslemlerKontrols.Gridi_OlusturbyList(list, gridControl.gridView1, gridControl.gridControl1, 0, ListeOzellikleri.dinamikUpdateTabloTip, true, true);
                    }
                    else
                    {
                        if (LISTE_SECIMIlke.Visible == true)
                        {
                            if (Convert.ToInt32(LISTE_SECIMIlke.EditValue) == (int)ListSablonListeSecimiEn.Genel)
                            {
                                YardimciIslemlerKontrols.Gridi_OlusturbyList(list, gridControl.gridView1, gridControl.gridControl1, 0, "", true, true);

                            }
                            else if (Convert.ToInt32(LISTE_SECIMIlke.EditValue) == (int)ListSablonListeSecimiEn.Tum)
                            {
                                YardimciIslemlerKontrols.Gridi_OlusturbyList(list, gridControl.gridView1, gridControl.gridControl1, 0, "", true, true);
                                YardimciIslemlerKontrols.Grid_Olustur("Satis.StokAmbar.Models", "StokListVm", "Prodma.DataAccess", gridControl.gridView1, ListeOzellikleri.toplamAlanlari, gridOzellikleri);

                            }
                            else if (Convert.ToInt32(LISTE_SECIMIlke.EditValue) == (int)ListSablonListeSecimiEn.TumDetayli)
                            {
                                YardimciIslemlerKontrols.Gridi_OlusturbyList(list, gridControl.gridView1, gridControl.gridControl1, 0, "", true, true);
                                YardimciIslemlerKontrols.Grid_Olustur("Satis.StokAmbar.Models", "StokListVm", "Prodma.DataAccess", gridControl.gridView1, ListeOzellikleri.toplamAlanlari, gridOzellikleri);
                                YardimciIslemlerKontrols.Grid_Olustur("Satis.StokAmbar.Models", "StokHesaplananBilgilerVm", "Prodma.DataAccess", gridControl.gridView1, ListeOzellikleri.toplamAlanlari, gridOzellikleri);
                            }
                            //YardimciIslemlerKontrols.Grid_Olustur_Tum_Kayitlar(ListeOzellikleri.modelPath, ListeOzellikleri.modelName, "Prodma.DataAccess", gridControl.gridView1, gridControl.gridControl1, ListeOzellikleri.toplamAlanlari, ListeOzellikleri.EkModelli, gridOzellikleri);
                                               
                        }
                       // YardimciIslemlerKontrols.Gridi_OlusturbyList(list, gridControl.gridView1, gridControl.gridControl1, 0, "", true, true);
                    }
                }
                else if (ListeOzellikleri.listSablonTip == (int)ListSablonEn.ListeleIslemYap)
                {
                }
                else if (ListeOzellikleri.listSablonTip == (int)ListSablonEn.DinamikListe)
                {
                    gridControl.gridView1.Columns.Clear();
                    if (dinamikAlanlar != null) YardimciIslemlerKontrols.Grid_Olustur_Dinamik1(ListeOzellikleri.modelPath, ListeOzellikleri.modelName, "Prodma.DataAccess", gridControl.gridView1, gridControl.gridControl1, ListeOzellikleri.toplamAlanlari, dinamikAlanlar, dinamikAltAlan, parametersForm);
                }
                else
                {
                    gridControl.gridView1.Columns.Clear();
                    
                    gridOzellikleri.autoWidth = false;
                    if (LK_DETAY_GOSTER_E_Hlke.EditValue!= null && (int)LK_DETAY_GOSTER_E_Hlke.EditValue==(int)EvetHayirEn.Hayir)
                    {
                        gridControl.gridView1.OptionsPrint.PrintDetails = false;
                        gridControl.gridView1.OptionsPrint.ExpandAllDetails = false;
                        gridControl.gridView1.OptionsPrint.ExpandAllGroups = false;
                        gridControl.gridView1.GroupFooterShowMode = GroupFooterShowMode.Hidden;
                        //gridControl.gridView1.yeniYazim = true;
                        gridOzellikleri.acilmamisSatirlariGosterme = true;

                    }
                    else
                    {
                        gridControl.gridView1.OptionsPrint.PrintDetails = true;
                        gridControl.gridView1.OptionsPrint.ExpandAllDetails = true;
                        gridControl.gridView1.OptionsPrint.ExpandAllGroups = true;
                        gridControl.gridView1.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
                        gridOzellikleri.groupFooterShowMode = GroupFooterShowMode.VisibleAlways;
                        //gridControl.gridView1.yeniYazim = false;
                        //gridOzellikleri.acilmamisSatirlariGosterme = false;
                    }
                    gridOzellikleri.dil = (int)DIL_IDlke.EditValue;
                    gridControl.gridView1.OptionsPrint.UsePrintStyles = true;
                    gridControl.gridView1.AppearancePrint.GroupRow.ForeColor = Color.Blue;
                    gridControl.gridView1.GroupFormat = "[#image]{1} {2}"; 
                    if (LISTE_SECIMIlke.Visible==true && (Convert.ToInt32(LISTE_SECIMIlke.EditValue) == (int)ListSablonListeSecimiEn.Tum || Convert.ToInt32(LISTE_SECIMIlke.EditValue) == (int)ListSablonListeSecimiEn.TumDetayli))
                    {
                        YardimciIslemlerKontrols.Grid_Olustur_Tum_Kayitlar(ListeOzellikleri.modelPath, ListeOzellikleri.modelName, "Prodma.DataAccess", gridControl.gridView1, gridControl.gridControl1, ListeOzellikleri.toplamAlanlari, ListeOzellikleri.EkModelli, gridOzellikleri);
                    }
                    else
                    {
                        YardimciIslemlerKontrols.Grid_Olustur(ListeOzellikleri.modelPath, ListeOzellikleri.modelName, "Prodma.DataAccess", gridControl.gridView1, ListeOzellikleri.toplamAlanlari, gridOzellikleri);
                    }
                }
                if (IslemYapKontrol() == false)
                {
                    butonlariIsle(true);
                    return;
                }
                Goster();
                if (ListeOzellikleri.listSablonTip != (int)ListSablonEn.StandartRaporsuz)
                {
                    //gridControl.gridView1.Columns.Clear();
                    //ReportParameterSet();
                }
                GridGoruntuAyarlaDefault();
        }
        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            lblBilgi.Text = Convert.ToString(gridControl.gridView1.RowCount - 1) + " Kayýt";
        }
        public void GridViewCheckedComboBoxLoad()
        {
                gridViewColumnschl.Properties.Items.Clear();
                foreach (DevExpress.XtraGrid.Columns.GridColumn item in this.gridControl.gridView1.Columns)
                {

                    if (item.Visible == true) gridViewColumnschl.Properties.Items.Add(item.Caption.ToString(), item.Visible == true ? CheckState.Checked : CheckState.Unchecked, true);
                }
        }
        private void gridViewColumnschl_Closed(object sender, ClosedEventArgs e)
        {
            gridColumnYenile();
        }
        public void gridColumnYenile()
        {
            foreach (CheckedListBoxItem item in gridViewColumnschl.Properties.Items)
            {
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridControl.gridView1.Columns)
                {
                    if (column.Caption.ToString() == item.Value.ToString())
                    {
                        if (item.CheckState == CheckState.Checked)
                        {
                            column.Visible = true;
                        }
                        else
                        {
                            column.Visible = false;
                        }

                        break;
                    }

                }

            }
            if (setValues.ContainsKey("GRUPLAMA"))
            {
                int sira = 0;
                string[] grupIndex = setValues["GRUPLAMA"].Split(','); // Marka,Model
                for (int i = 0; i < grupIndex.Length; i++)
                {
                    sira = 0;
                    foreach (DevExpress.XtraGrid.Columns.GridColumn item in this.gridControl.gridView1.Columns)
                    {
                        if (item.FieldName == grupIndex[i])
                        {
                            break;
                        }
                        sira++;
                        //if (item.GroupIndex != -1)
                        //{
                        //    if (ilk == true)
                        //    {
                        //        //degerAlani += "GRUPLAMA" + "»" + item.AbsoluteIndex;
                        //        degerAlani += "GRUPLAMA" + "»" + item.FieldName;
                        //        ilk = false;
                        //    }
                        //    else
                        //    {
                        //        degerAlani += "," + item.AbsoluteIndex;
                        //    }

                        //}
                        // if (item.Visible == true) gridViewColumnschl.Properties.Items.Add(item.Caption.ToString(), item.Visible == true ? CheckState.Checked : CheckState.Unchecked, true);
                    }
                    if ( gridControl.gridView1.Columns.Count>sira)
                       gridControl.gridView1.Columns[sira].GroupIndex = i;
                }
                 
                
            }
            //if (setValues.ContainsKey("GRIDOZELLIKLERI"))
            //{
            //    string layout = setValues["GRIDOZELLIKLERI"].ToString();
                
            //      gridControl.gridView1.RestoreLayoutFromXml(layout, DevExpress.Utils.OptionsLayoutBase.FullLayout);
            //}
            if (setValues.ContainsKey("FILTERSTRING"))
            {
                string filter = setValues["FILTERSTRING"].ToString();

                if (filter.Trim()!="")
                {
                    gridControl.gridView1.ActiveFilterString = filter;                    
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            if (sorguBitti == true)
            {
                if (ListeOzellikleri.AcilistaYukle == true || direktYazdir==true)
                {
                    if (ListeOzellikleri.reportName.Trim() == "")
                    {
                        MessageBox.Show("Rapor Tanýmlanmamýþ");
                        return;
                    }
                    else
                    {
                        ReportParameterSet();
                    }
                    OzelYazdir();
                }
                else
                {
                    griddoldur();
                }
                progressBar1.Value = 0;
                butonlariIsle(true);
                GridGoruntuAyarlaDefault();
                return;
            }
            else if (progressBar1.Value == maximum)
            {
                progressBar1.Value = 0;
            }
        }
        private void saveFilter_Click(object sender, EventArgs e)
        {
            FilterParametreSet();
            FiltrelerCntrl cntrl = new FiltrelerCntrl();
            FiltrelerVm filtreVm = new FiltrelerVm();
            SiparisListeleriPopUp popUp = new SiparisListeleriPopUp();
            popUp.filterName = Convert.ToString(filtreLke.GetColumnValue("AD"));
            popUp.ShowDialog();
            filtreVm.RAPOR_ADI = popUp.FilterNametxt.Text;
            filtreVm.KULLANICI_ID = Globals.gnKullaniciId;
            filtreVm.FORM_ADI = ListeOzellikleri.mt[0];
            string degerAlani = "";
            foreach (var item in filterParametersForm)
            {
                if (item.Value != null && item.Value != "")
                    degerAlani += item.Key + "»" + item.Value + "‡";
            }
            bool ilk = true;
            foreach (DevExpress.XtraGrid.Columns.GridColumn item in this.gridControl.gridView1.Columns)
            {
                if (item.GroupIndex!=-1)
                {
                    if (ilk == true)
                    {
                        //degerAlani += "GRUPLAMA" + "»" + item.AbsoluteIndex;
                        degerAlani += "GRUPLAMA" + "»" + item.FieldName;
                        ilk = false;
                    }
                    else
                    {
                        degerAlani += "," + item.FieldName;
                    }
                    
                }
                // if (item.Visible == true) gridViewColumnschl.Properties.Items.Add(item.Caption.ToString(), item.Visible == true ? CheckState.Checked : CheckState.Unchecked, true);
            }

            degerAlani += "‡FILTERSTRING" + "»" + gridControl.gridView1.ActiveFilterString;
            if(frm!=null && frm._printerName!="")
            {
               degerAlani += "‡YAZICI" + "»" + frm._printerName;
               degerAlani += "‡YATAYDIKEY" + "»" + frm._YatayDikey;
               degerAlani += "‡KAGITSECIMI" + "»" + frm._KagitSecimi;
            }
         

            //string layaout = Application.StartupPath + "/" + popUp.FilterNametxt.Text;
            //gridControl.gridView1.SaveLayoutToXml(layaout);
            filtreVm.DEGER_ALANI = degerAlani; //+ "‡" + "GRIDOZELLIKLERI" + "»" + layaout;
             
            if (popUp.islem == 2)
            {
                filtreVm.FILTRE_TIP_ID = (int)FiltreTipEn.Listeler;
                cntrl.Ekle(filtreVm);
                //filtreLke.Properties.DataSource = ListDenemeService.GetFILTRELER_ID(nesne.kullaniciBilgileri.ID, formName);
            }
            else if (popUp.islem == 0)
            {
                filtreVm.ID = Convert.ToInt32(filtreLke.EditValue);
                filtreVm =  cntrl.Liste_Al(filtreVm)[0];
                filtreVm.DEGER_ALANI = degerAlani;
                if (filtreVm.KULLANICI_ID != filtreVm.FILTRE_OLUSTURAN_KULLANICI_ID)
                {
                    MessageBox.Show("Baþkasý Tarafýndan Oluþturulmuþ Filtreyi deðiþtiremezsiniz");
                    return;
                }
                filtreVm.FILTRE_TIP_ID = (int)FiltreTipEn.Listeler;
                cntrl.Guncelle(filtreVm, filtreVm.ID);
                //filtreLke.Properties.DataSource = ListDenemeService.GetFILTRELER_ID(nesne.kullaniciBilgileri.ID, formName);
            }
            else if (popUp.islem == 1)
            {
                filtreVm.ID = Convert.ToInt32(filtreLke.EditValue);
                filtreVm = cntrl.Liste_Al(filtreVm)[0];
                if (filtreVm.KULLANICI_ID != filtreVm.FILTRE_OLUSTURAN_KULLANICI_ID)
                {
                    MessageBox.Show("Baþkasý Tarafýndan Oluþturulmuþ Filtreyi Silemezsiniz");
                    return;
                }
                cntrl.Sil(filtreVm.ID, filtreVm);
                //filtreLke.Properties.DataSource = ListDenemeService.GetFILTRELER_ID(nesne.kullaniciBilgileri.ID, formName);
            }
            filtreLke.Properties.DataSource = ListDenemeService.GetFILTRELER_ID(Globals.gnKullaniciId, ListeOzellikleri.mt[0], (int)FiltreTipEn.Listeler);
            filtreLke.Properties.ValueMember = "ID";
            filtreLke.Properties.DisplayMember = "AD";
            filtreLke.Properties.NullText = "Filtreler";
            if (filtreLke.Properties.Columns.Count > 0)
            {
                filtreLke.Properties.Columns["ID"].Visible = false;
            }
        }
        private void filtreLke_Closed(object sender, ClosedEventArgs e)
        {
            setValues.Clear();
            if (Convert.ToInt32(filtreLke.EditValue) == -1)
            {
                if (ListeOzellikleri.sinirliYetkiEH != null && ListeOzellikleri.sinirliYetkiEH == (int)EvetHayirEn.Evet)
                {
                    LISTE_SECIMIlke.Enabled = true;
                    LISTE_SECIMIlke.EditValue = (int)ListSablonListeSecimiEn.Genel;
                    LISTE_SECIMIlke.Enabled = false;
                }
                
                gridViewColumnschl.CheckAll();
                VarSayilanRaporDegerleriniAyarla();
                return;
            }
            if (filtreLke.EditValue != null && Convert.ToInt32(filtreLke.EditValue)!=-1)
            {
                string s1 = ListDenemeService.GetFILTRELER_DEGER_ALANI((int)filtreLke.EditValue);
                if (s1!=null)
                {
                    string[] selected = ListDenemeService.GetFILTRELER_DEGER_ALANI((int)filtreLke.EditValue).ToString().Split('‡');

                    foreach (var item in selected)
                    {
                        if (item != "")
                        {
                            string[] a = item.Split('»');
                            if (a[0] == "YAZICI")
                            {
                                parametersForm["YAZICI"] = a[1];
                            }
                            if (a[0] == "YATAYDIKEY")
                            {
                                parametersForm["YATAYDIKEY"] = a[1];
                            }
                            if (a[0] == "KAGITSECIMI")
                            {
                                parametersForm["KAGITSECIMI"] = a[1];
                            }
                            else
                            {
                                setValues.Add(a[0], a[1]);
                            }
                        }
                       
                            
                    }
                    SetFilter();    
                }
                
            }
            if (setValues.ContainsKey("LISTE_SECIMI"))
            {
                if (Convert.ToInt32(setValues["LISTE_SECIMI"]) == 0)
                {
                    LISTE_SECIMIlke.EditValue = (int)ListSablonListeSecimiEn.Genel;
                }
                else
                {
                    LISTE_SECIMIlke.EditValue = (int)ListSablonListeSecimiEn.Tum;
                }
            }
            kayitliSorgu = true;
            gridControl.detayCalismaDegerId = Convert.ToInt32(filtreLke.EditValue);
          //  Listele();
        }
        void butonlariIsle(bool deger)
        {
            TAMAMYAZDIRbtn.Enabled = deger;
            TAMAMbtn.Enabled =deger;
            IPTALbtn.Enabled = deger;
            filtreLke.Enabled = deger;
            gridViewColumnschl.Enabled = deger;
            if (ListeOzellikleri.listSablonTip == (int)ListSablonEn.ListeleIslemYap)
            {
                this.ControlBox = deger;
                this.KeyPreview = deger;
            }
            //OZELYAZDIRbtn.Enabled = deger;
            LISTE_SECIMIlke.Enabled = deger;

            if (ListeOzellikleri.sinirliYetkiEH != null &&  ListeOzellikleri.sinirliYetkiEH == (int)EvetHayirEn.Evet)
            {
                gridViewColumnschl.Enabled = false;
                saveFilterBtn.Enabled = false;
                LISTE_SECIMIlke.Enabled = false;
            }
        }
        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

          
            if (gridEkli == true)
            {
                ListForm frm = new ListForm();
                frm.Text = ListeOzellikleri.ListeAdi;
                //frm.Controls.Add(panelControl1);
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.WindowState = FormWindowState.Maximized;
                //frm.Controls.Add(gridControl);
                frm.grd = gridControl;
                frm.Controls.Add(frm.grd);
                frm.grd.Dock = DockStyle.Fill;
                frm.a = frm.grd.gridControl1.DataSource;
                frm.pivotGridControl1.DataSource = frm.grd.gridControl1.DataSource;
                frm.ShowDialog();
                gridControl = frm.grd;
                this.panelControlGridControl.Controls.Add(gridControl);
            }
            else
            {
                ListForm frm = new ListForm();
                frm.Text = ListeOzellikleri.ListeAdi;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.WindowState = FormWindowState.Maximized;
                frm.Controls.Add(usrRaporEkran);
                frm.ShowDialog();
                this.panelControlGridControl.Controls.Add(usrRaporEkran);
            }
            
            //frm.Controls.Add(gridView1);
        
        }

        private void LK_DETAY_GOSTER_E_Hlke_EditValueChanged(object sender, EventArgs e)
        {
            if (LK_DETAY_GOSTER_E_Hlke.EditValue!=null && (int)LK_DETAY_GOSTER_E_Hlke.EditValue != (int)EvetHayirEn.Evet)
            {
                gridControl.detayGosterme = true;
                //gridControl.gridView1.yeniYazim = true;
                gridControl.gridView1.GroupFooterShowMode = GroupFooterShowMode.Hidden;
                gridControl.gridView1.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(gridControl.gridView1_CustomDrawGroupRow);
                foreach (GridGroupSummaryItem item in gridControl.gridView1.GroupSummary)
                {
                    item.ShowInGroupColumnFooter = null;
                }
            }
            else
            {
                gridControl.detayGosterme = false;
                //gridControl.gridView1.yeniYazim = false;
                gridControl.gridView1.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
                gridControl.gridView1.CustomDrawGroupRow -= new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(gridControl.gridView1_CustomDrawGroupRow);
                foreach (GridGroupSummaryItem item in gridControl.gridView1.GroupSummary)
                {
                    item.ShowInGroupColumnFooter = gridControl.gridView1.Columns[item.FieldName.ToString()];
                }

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frm = new YaziciSec();
            frm.Show();
            if (parametersForm.ContainsKey("YAZICI"))
            {
                frm.YAZICI_ADItxt.Text = parametersForm["YAZICI"];
            }
            if (parametersForm.ContainsKey("YATAYDIKEY"))
            {
                frm.DIKEY_YATAYlke.EditValue = Convert.ToInt32(parametersForm["YATAYDIKEY"]);
            }
            if (parametersForm.ContainsKey("KAGITSECIMI"))
            {
                frm.KAGIT_SECIMItxt.Text = parametersForm["KAGITSECIMI"];
            }
        }
        void setDefaultPrinter(string printer1)
        {
            var query = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
            var printers = query.Get();
            foreach (ManagementObject printer in printers)
            {
                if (printer["name"].ToString() == printer1)
                {
                    printer.InvokeMethod("SetDefaultPrinter", new object[] { printer1 });
                }
            }
        }
        void getDefaultPrinter()
        {
            //defaultPrinter = "";
            //StringBuilder dp = new StringBuilder(256);
            //int size = dp.Capacity;
            //if (myPrinters.GetDefaultPrinter(dp, ref size))
            //{
            //    defaultPrinter = dp.ToString().Trim();
            //}
           
        }
    }
 
    public class ListSablonOzellikleriVm
    {
        public int listSablonTip { get; set; } 
        public string dinamikUpdateTabloTip = "";
        public string ListeAdi { get; set; }
        public string modelPath { get; set; }
        public string modelName { get; set; }
        public string reportName { get; set; }
        public string raporBaslik { get; set; }
        public string[] toplamAlanlari { get; set; }
        public string[] reportDataSet { get; set; }
        public string[] reportParameter { get; set; }
        public Dictionary<string, string> raporParametreleri { get; set; }
        public string[] mt { get; set; }
        public ReportParameter[] prmRapor;
        public bool GrupPaneliGosterilsinMi { get; set; }
        public bool IkinciGrupGosterilsinMi { get; set; }
        public int EkModelli { get; set; }
        public bool AcilistaYukle { get; set; }
        public string grupEditValue { get; set; }
        public string grup2EditValue { get; set; }
        public int varsayilanPersonelId { get; set; }
        public int varsayilanStokId { get; set; }
        public int varsayilanCariId { get; set; }
        public int varsayilanAlisSatisId { get; set; }
        public string varsayilanNo1 { get; set; }
        public string varsayilanNo2 { get; set; }
        public string varsayilanNo3 { get; set; }
        public bool StokEkFiltresiz { get; set; }
        public bool CariEkFiltresiz { get; set; }
        public bool Raposuz { get; set; }
        public string raporYetkiAdi { get; set; }
        public int? sinirliYetkiEH { get; set; }
        public int ListeSahipTipId { get; set; }
        public int MuhasebeHesapMasrafYeriHesapModelli { get; set; }
    }
}
