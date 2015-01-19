

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
using Prodma.SistemB2C.Controllers;
using DevExpress.XtraGrid.Views.Base;
using System.Collections.Generic;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;

namespace Prodma.WinForms
{
    /// <summary>
    /// Summary description for MDIChild.
    /// </summary>
    /// 
    public partial class TanitimSablon : Sablon
    {
        #region Deðiþkenler
        bool F2YeBasildi = false;
        bool sablonKapat = true;
        IViewModel modelThis;
        public DevExpress.XtraTab.XtraTabPage tpMesaj;
        public DevExpress.XtraTab.XtraTabPage tpMesaj2;
        public System.Windows.Forms.ContextMenu ContextMenu1;
        public System.Windows.Forms.MenuItem[] contextMenuItems = new System.Windows.Forms.MenuItem[10];
        public DevExpress.XtraBars.BarButtonItem[] EkranListeleri = new BarButtonItem[10];
        public string TanitimDinamikFiltreSql = "";
        public string TanitimDinamikFiltreCariSql = "";
        public int kayitId = 0;
        public int tabloAlanId = 0;
        
        bool butonaBasildi = true;
        public bool gozlem = false;
        public int currentTab = -1;
        object obj;
        public bool escapeKapat = true; // TEKLÝF ALT USTACIKLAMANIN escapeKapatý false olmus
        public bool escapeKapatma = false; // menulerin escapeKapatmasý false
        public bool tabSelect = false;
        int verilenKodId;
        //public FisSablonSon fisfrm1;
        public TanitimSablon tanitimfrm;
        public int fiskodIstenenId = 0;
        public bool fiskodIstedi = false;
        GridControl gridIsteyenControl;
        GridView gridIsteyenView;
        DevExpress.XtraGrid.Columns.GridColumn columnIsteyen;
        public string kodIsteyenColumn;
        public bool ekTabAc = false;
        public bool ekTabAcildi = false;
        int intArama = 0;
        public bool KodArama = true;
        public int menuId=0;
        public bool blnValidateRow = true;
        public bool acilisTamamlandi = false;
        public bool blnValidatingEditor = true;
        public string errorTextValidatingEditor = "";
        public bool blnGridView1ShowingEditor = false;
        public string rowHandleExcepTionMessage = "";
        public bool blnKodIstemi = false;
        public bool gridViewErisim = true;
        TanitimSablon frm;
        int rowHandle = 0;
        private int X;
        private int Y;
        public int dondurulenId = 0;
        public bool kayitTamam;
        int sEditorRowSifirli = 0;
        string sEditorColumnSifirli = "";
        bool sonsutunkaydet = false;
        public bool yeniSatir = false;
        public bool ilkKayit = false;
        const string NotFoundText = "???";
        private IContainer components;
        public Label lblSonuc;
        public string tabloAdi;
        #region Devexpress kontrolleri
        int intBind = 0;
        int intBindTextEdit = 0;
        private DevExpress.XtraEditors.TextEdit[] textArama = new DevExpress.XtraEditors.TextEdit[64];
        private DevExpress.XtraEditors.TextEdit[] textArama_Satir = new DevExpress.XtraEditors.TextEdit[64];
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit[] repositoryItemTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit[64];
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn Column1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit;
        public DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit[] repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit[32];
        public BindingSource[] bindingSourceArr = new BindingSource[32];
        public BindingSource bindingSource1 = new BindingSource();
        public Dictionary<string, int> AlanAdiIndexi = new Dictionary<string, int>();
        public Dictionary<int, bool> koplalamaDurumu = new Dictionary<int, bool>();
        #endregion


        public Object ModelVm;
        public BindingSource bindingSource2;
        public ControlNavigator controlNavigator1;
        public PanelControl panelControl1;
        public PanelControl pnlIslemler;
        private Button BILGI_2cmd;
        public PanelControl pnlEkIslemler;
        private Button BILGI_3cmd;
        public PanelControl pnlArama;
        private Button BILGI1_cmd;

        public usrGridSatirBilgi usrGridBilgi = new usrGridSatirBilgi();
        public DevExpress.XtraTab.XtraTabControl tabControl1;
        public DevExpress.XtraTab.XtraTabPage tabPage1;
        public GridControl  gridControl1;
        public GridView  gridView1;
        private Panel pnlKodIstemi;
        public Label lblBilgi;
        public DevExpress.XtraTab.XtraTabPage tabPage2;
        public ControlNavigator controlNavigator2;
        public DevExpress.XtraTab.XtraTabPage tabPage3;
        public ControlNavigator controlNavigator3;
        public DevExpress.XtraTab.XtraTabPage tabPage4;
        public ControlNavigator controlNavigator4;
        public DevExpress.XtraTab.XtraTabPage tabPage5;
        public ControlNavigator controlNavigator5;
        public DevExpress.XtraTab.XtraTabPage tabPage6;
        public ControlNavigator controlNavigator6;
        public DevExpress.XtraTab.XtraTabPage tabPage7;
        public ControlNavigator controlNavigator7;
        public DevExpress.XtraTab.XtraTabPage tabPage8;
        public ControlNavigator controlNavigator8;
        public DevExpress.XtraTab.XtraTabPage tabPage9;
        public ControlNavigator controlNavigator9;
        public DevExpress.XtraTab.XtraTabPage tabPage10;
        public ControlNavigator controlNavigator10;
        public DevExpress.XtraTab.XtraTabPage tabPage11;
        public ControlNavigator controlNavigator11;
        public DevExpress.XtraTab.XtraTabPage tabPage12;
        public ControlNavigator controlNavigator12;
        public DevExpress.XtraTab.XtraTabPage tabPage13;
        public ControlNavigator controlNavigator13;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
        private DevExpress.XtraPrinting.PrintableComponentLink printableComponentLink1;
        private DevExpress.Utils.ToolTipController toolTipController1;
 
        public DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        public DevExpress.XtraBars.PopupMenu popupMenu1;

        public bool islemTamamDegil;
        #endregion
        #region formolaylar
        public TanitimSablon()
        {
            InitializeComponent();
            //gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Default;
            this.ContextMenu1 = new System.Windows.Forms.ContextMenu();
            eventHandler();
            Globals.escapeTabDegistir = true;
            this.panelControl1.Size = new System.Drawing.Size(0, 0);
            FileVersionInfo myFI = FileVersionInfo.GetVersionInfo(Application.StartupPath.ToString() + "/Prodma.Satis.exe");
            if (this.MdiParent != null)
            {
                this.MdiParent.Text = "PRODMA ERP -" + myFI.FileVersion;
            }
            EkranListeleri[0] = new BarButtonItem(barManager1, "Ekran Yazdýr");
            EkranListeleri[0].Name = "EkranList";
            this.popupMenu1.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(EkranListeleri[0]));
            Type hai = this.GetType();
            string name = hai.ToString();
            MenulerVm fVm = new MenulerVm();
            fVm.URL = name;
            MenulerCntrl cntrl = new MenulerCntrl();
            yetki = ListDenemeService.GetYETKI_MENULER(name);
            yetKiAyarla(yetki);//14.02.2012'de showndan buraya tasýndý. ikinci acýlan  formlar shown subýna girmiyor
            GoruntuAyarla();
        }
        //public TanitimSablon(IViewModel model)
        //{
        //    modelThis = model;
        //    InitializeComponent();
        //    //gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
        //    this.ContextMenu1 = new System.Windows.Forms.ContextMenu();
        //    eventHandler();
        //    Globals.escapeTabDegistir = true;
        //    this.panelControl1.Size = new System.Drawing.Size(0, 0);
        //    FileVersionInfo myFI = FileVersionInfo.GetVersionInfo(Application.StartupPath.ToString() + "/Prodma.Satis.exe");
        //    if (this.MdiParent != null)
        //    {
        //        this.MdiParent.Text = "PRODMA ERP -" + myFI.FileVersion;
        //    }
        //    EkranListeleri[0] = new BarButtonItem(barManager1, "Ekran Yazdýr");
        //    EkranListeleri[0].Name = "EkranList";
        //    this.popupMenu1.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(EkranListeleri[0]));
        //    Type hai = this.GetType();
        //    string name = hai.ToString();
        //    MenulerVm fVm = new MenulerVm();
        //    fVm.URL = name;
        //    MenulerCntrl cntrl = new MenulerCntrl();
        //    yetki = ListDenemeService.GetYETKI_MENULER(name);
        //    yetKiAyarla(yetki);//14.02.2012'de showndan buraya tasýndý. ikinci acýlan  formlar shown subýna girmiyor
        //    GoruntuAyarla();
        //}
        public void TanitimSablon_Load(object sender, EventArgs e)
        {
            currentTab = 0;
            
            this.Text = "Tanýtým";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.GroupPanelText = "Gruplamak Ýstediðiniz Alaný Bu Bölgeye Sürükleyiniz";
            TanitimDinamikFiltreCariSql = "";
            //if (Globals.cariErisilebilenSql != "" && Globals.cariErisilebilenSql != null)
            //{
            //    TanitimDinamikFiltreCariSql = Globals.cariErisilebilenSql;// "(CARI_TIP_ID==2) && (CARI_PLASIYER_ID!=118)"; //s;
            //}
            string s = OrtakIslemlerService.Filtreolustur(tabloAlanId, "",false);
            if (s.Trim() != "")
            {
                TanitimDinamikFiltreCariSql = TanitimDinamikFiltreCariSql + " AND ( " + s + " )";// "(CARI_TIP_ID==2) && (CARI_PLASIYER_ID!=118)"; //s;
                TanitimDinamikFiltreSql = s;
            }
            if (yetki != null && yetki.GORMESIN_E_H == true)
            {
            }
            else
            {
                Doldur();
                Filtrele();
            }
            CustomButonEkle();
            ContextMenuolustur();
            this.panelControl1.Size = new System.Drawing.Size(0, 0);
            //this.WindowState = FormWindowState.Normal;
            Globals.gnActiveForm = this.Text;//14.02.2012'de showndan buraya tasýndý. ikinci acýlan  formlar shown subýna girmiyor
            //yetKiAyarla(yetki);//14.02.2012'de showndan buraya tasýndý. ikinci acýlan  formlar shown subýna girmiyor
            this.gridControl1.Focus();//14.02.2012'de showndan buraya tasýndý. ikinci acýlan  formlar shown subýna girmiyor
            FileVersionInfo myFI = FileVersionInfo.GetVersionInfo(Application.StartupPath.ToString() + "/Prodma.Satis.exe");
            if (this.MdiParent != null)
            {
                this.MdiParent.Text = "PRODMA ERP -" + myFI.FileVersion;
            }
            this.gridView1.OptionsFind.AllowFindPanel = false;
        }
        private void TanitimSablon_Shown(object sender, EventArgs e)
        {
            FileVersionInfo myFI = FileVersionInfo.GetVersionInfo(Application.StartupPath.ToString() + "/Prodma.Satis.exe");
            if (this.MdiParent != null)
            {
                this.MdiParent.Text = "PRODMA ERP -" + myFI.FileVersion;
            }

        }
        public override void Form_Acilis(object sender, EventArgs e)
        {
            this.gridControl1.Focus();
            ActiveControl = (Control)this.gridControl1;
        }
        private void TanitimSablon_Activated(object sender, EventArgs e)
        {
            this.gridControl1.Focus();
            ActiveControl = (Control)this.gridControl1;
            Globals.gnActiveForm = this.Text;
        }
        public void yetKiAyarla(YetkiMenulerVm yetki)
        {
            if (yetki != null)
            {
                if (yetki.GORMESIN_E_H == true || yetki.OKU_E_H == false)
                {
                    this.gridControl1.DataSource = null;
                    this.gridView1.OptionsBehavior.Editable = false;
                    gorme = false;
                    silme = false;
                    kayitEtme = false;
                    guncelleme = false;
                    okuma = false;
                }
                else
                {
                    if (yetki.YAZ_E_H == false)
                    {
                        kayitEtme = false;
                    }
                    if (yetki.GUNCELLE_E_H == false)
                    {
                        guncelleme = false;
                    }
                    if (yetki.SIL_E_H == false)
                    {
                        silme = false;
                    }
                }
                if (yetki.OKU_E_H == true || (yetki.YAZ_E_H == false && yetki.GUNCELLE_E_H == false && yetki.SIL_E_H == false))
                {
                    //this.gridView1.OptionsBehavior.Editable = false;
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
            else
            {
                tamYetki = true;
            }
        }
        private void TanitimSablon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape )
            {
                if (this.gridView1.IsDefaultState == true)
                {
                    if (tabControl1.SelectedTabPage != tabPage1)
                    {
                        if (Globals.escapeTabDegistir==true) tabControl1.SelectedTabPage = tabPage1; // baska formlardan aciklmasýnda tab degisikligini escape ile yapamasin
                    }
                    else
                    {
                        if (escapeKapat == true && escapeKapatma == false)
                        {
                            this.Close();
                        }
                    }
                }
                else if (tabControl1.SelectedTabPage != tabPage1)
                {
                    if (Globals.escapeTabDegistir == true) tabControl1.SelectedTabPage = tabPage1;
                }
            }
            Tanitim_KeyDown(e);
        }
        private void TanitimSablon_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = sablonKapat;
            if (blnKodIstemi == true)
            {
                gridIsteyenControl.Enabled = true;
                gridIsteyenControl.Focus();
                if (fisfrm1 != null)
                {
                    if (gridIsteyenView.Name == "gridView1")
                    {
                        gridIsteyenView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(fisfrm1.gridView1_ValidateRow);
                        // gridIsteyenView.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(fisfrm.gridView1_ValidatingEditor);
                        gridIsteyenView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(fisfrm1.gridView1_FocusedRowChanged);
                    }
                    else
                    {
                        gridIsteyenView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(fisfrm1.gridView2_ValidateRow);
                        //   gridIsteyenView.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(fisfrm.gridView2_ValidatingEditor);
                        gridIsteyenView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(fisfrm1.gridView2_FocusedRowChanged);
                    }
                    fisfrm1.fiskodIstenenId = verilenKodId;
                    fisfrm1.WindowState = FormWindowState.Maximized;
                    fisfrm1.setVerilenKod(gridIsteyenView);
                    fisfrm1.fiskodIstedi = false;
                    gridIsteyenView.TopRowIndex = gridIsteyenView.FocusedRowHandle;
                }
                else if (tanitimfrm != null)
                {
                    gridIsteyenView.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(tanitimfrm.gridView1_ValidateRow);
                    gridIsteyenView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(tanitimfrm.gridView1_FocusedRowChanged);
                    tanitimfrm.fiskodIstenenId = verilenKodId;
                    tanitimfrm.WindowState = FormWindowState.Maximized;
                    tanitimfrm.setVerilenKod(gridIsteyenView);
                    tanitimfrm.fiskodIstedi = false;
                }
            }
            blnKodIstemi = false;
            //bindingSourceArr = null;
            //bindingSource1 = null;
            //gridControl1.Dispose();
            //gridView1.Dispose();
          //  GC.Collect();
        }
        public override bool KapatKontrol()// sablon kapat kontrol
        {
            sablonKapat = Form_Kapama_Islemi();
            return Form_Kapama_Islemi();
        }
        public void setVerilenKod(GridView view)
        {
            try
            {

                if (fiskodIstenenId != 0 && view != null)
                {
                    view.SetRowCellValue(view.FocusedRowHandle, view.FocusedColumn.FieldName, fiskodIstenenId);
                }
                view.ShowEditor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void MouseSpin(object sender, SpinEventArgs e)
        {
            //e.IsSpinUp = false;
            e.Handled = true;
        }
        public string Gridi_Olusturfisten()//GRÝD ve ARAMALAR AYARLANIYOR
        {
            string alanadi = "";
            int ust_id = 0;
            var q = ListDenemeService.GetALANLAR(tabloAdi, 1);
            tabloAlanId = (int)q[0].M_ALANLAR_ID;
            foreach (var ALAN in q)
            {
                Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
                //FieldInfo fi = typeof(GridColumn).GetField("minWidth", BindingFlags.NonPublic | BindingFlags.Instance);
                //fi.SetValue(Column1, 0);
                Column1.Name = Column1.FieldName = alanadi = ALAN.ALAN_AD;
                Column1.Caption = Globals.rman.GetString(ALAN.ALAN_LISTE_AD);
                Column1.Width = (int)ALAN.ALAN_LISTE_GENISLIK;
              //  Column1.VisibleIndex = 1;// Convert.ToInt32(ALAN.ALAN_SIRA);
                if (ALAN.ALAN_AD != "ID")
                {
                    Column1.Visible = true;
                    Column1.VisibleIndex = 1;
                }
                else
                {
                    Column1.Visible = false;
                }
                        
                if (ALAN.M_ALAN_CLASS_NAME != null) { Column1.Tag = Convert.ToString(ALAN.M_ALAN_CLASS_NAME) + "/" + Convert.ToString(ALAN.ID); }
                if ((ALAN.GORMESIN_E_H == true && ALAN.M_ALANLAR_ALT_ID == null) || ALAN.M_ALAN_TIP_2 == 2)
                {
                    Column1.Visible = false;
                }
                if (ALAN.YAZMASIN_E_H == true && ALAN.M_ALANLAR_ALT_ID == null)
                {
                    Column1.OptionsColumn.ReadOnly = true;
                }
                AlanAdiIndexi[ALAN.ALAN_AD] = intBind;
                if (ALAN.M_ALAN_KOPYALAMA_E_H == (int)EvetHayirEn.Hayir)
                {
                    koplalamaDurumu[intBind] = false;
                }
                if (ALAN.M_ALAN_KOPYALAMA_E_H == (int)EvetHayirEn.Hayir)
                {
                    koplalamaDurumu[intBind] = false;
                }
                if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.TEXTBOX)  // TEXT
                {
                    repositoryItemTextEdit[intBind] = new RepositoryItemTextEdit();
                    if (ALAN.KIRLIM_TIP_ID != null && ALAN.KIRLIM_TIP_ID != 0)
                    {
                        string kirilim = YardimciIslemler.KirilimUygula(ALAN.KIRLIM_TIP_ID);
                        this.repositoryItemTextEdit[intBind].Mask.EditMask = kirilim;
                        this.repositoryItemTextEdit[intBind].Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                        this.repositoryItemTextEdit[intBind].Mask.UseMaskAsDisplayFormat = true;
                    }
                    else
                    {
                        Column1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
                    }
                    if (ALAN.ALAN_AD == "ALINAN_NOT") //M_ALANLAR tablosuna arama tipi konulacak
                    {
                        Column1.Width = 80;
                    }
                    this.gridControl1.RepositoryItems.Add(repositoryItemTextEdit[intBind]);
                    repositoryItemTextEdit[intBind].AutoHeight = false;
                    repositoryItemTextEdit[intBind].MaxLength = Convert.ToInt16(ALAN.ALAN_UZUNLUK);
                    repositoryItemTextEdit[intBind].Name = ALAN.ALAN_AD;
                    this.repositoryItemTextEdit[intBind].Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.MouseSpin);
                    Column1.ColumnEdit = repositoryItemTextEdit[intBind];
                }
                else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.COMBOBOX)
                {
                    bindingSourceArr[intBind] = new System.Windows.Forms.BindingSource();
                    this.gridControl1.RepositoryItems.Add(repositoryItemLookUpEdit1[intBind]);
                    repositoryItemLookUpEdit1[intBind] = new RepositoryItemGridLookUpEdit();
                    string mt = "";
                    mt = "Get" + ALAN.ALAN_AD;
                    bindingSourceArr[intBind].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.AKTIF, 0, ALAN.ID, ust_id, "", "", 0);
                    AlanAdiIndexi[ALAN.ALAN_AD] = intBind;
                    this.repositoryItemLookUpEdit1[intBind].NullText = "";
                    this.repositoryItemLookUpEdit1[intBind].DataSource = bindingSourceArr[intBind];
                    this.repositoryItemLookUpEdit1[intBind].DisplayMember = "AD";
                    this.repositoryItemLookUpEdit1[intBind].Name = ALAN.ALAN_AD;
                    this.repositoryItemLookUpEdit1[intBind].ValueMember = "ID";
                    this.repositoryItemLookUpEdit1[intBind].CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.Space);
                    if (bindingSourceArr[intBind].DataSource != null)
                    {
                        if (this.repositoryItemLookUpEdit1[intBind].View.Columns.Count > 2)
                        {
                            this.repositoryItemLookUpEdit1[intBind].View.Columns["CARIVM"].Visible = false;
                        }
                    }
                    if ((int)ALAN.ALAN_LISTE_GENISLIK > 50 || ALAN.ALAN_AD == "CARI_ID" || ALAN.ALAN_AD == "STOK_ID") //M_ALANLAR tablosuna arama tipi konulacak
                    {
                        this.repositoryItemLookUpEdit1[intBind].ImmediatePopup = true;
                        this.repositoryItemLookUpEdit1[intBind].TextEditStyle = TextEditStyles.Standard;
                        this.repositoryItemLookUpEdit1[intBind].PopupFormSize = new Size(300, 500);
                        this.repositoryItemLookUpEdit1[intBind].View.Appearance.FocusedRow.ForeColor = Color.Red;
                        this.repositoryItemLookUpEdit1[intBind].PopupFilterMode = PopupFilterMode.Contains;
                        Column1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
                        repositoryItemLookUpEdit1[intBind].View.PopulateColumns(repositoryItemLookUpEdit1[intBind].DataSource);
                        // Column1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
                        this.repositoryItemLookUpEdit1[intBind].KeyDown += new System.Windows.Forms.KeyEventHandler(this.repositoryItemLookUpEdit1_KeyDown);
                        this.repositoryItemLookUpEdit1[intBind].ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.repositoryItemGridLookUpEdit1_ProcessNewValue);
                        //this.repositoryItemLookUpEdit1[intBind].EditValueChanged += new System.EventHandler(this.lke_EditValueChanged);
                    }
                    if (bindingSourceArr[intBind].DataSource != null)
                    {
                        this.repositoryItemLookUpEdit1[intBind].View.Columns[0].Visible = false;
                    }
                    this.repositoryItemLookUpEdit1[intBind].PopupBorderStyle = PopupBorderStyles.Style3D;
                    this.repositoryItemLookUpEdit1[intBind].AppearanceFocused.BackColor = Color.Red;
                    this.Column1.ColumnEdit = repositoryItemLookUpEdit1[intBind];

                }
                else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.EVETHAYIR)// EVET HAYIR
                {
                    bindingSourceArr[intBind] = new System.Windows.Forms.BindingSource();
                    this.gridControl1.RepositoryItems.Add(repositoryItemLookUpEdit1[intBind]);
                    repositoryItemLookUpEdit1[intBind] = new RepositoryItemGridLookUpEdit();
                    bindingSourceArr[intBind].DataSource = ListService.GetLK_HAYIR_EVET_ID((int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, 0, 0, "", "", 0);
                    this.repositoryItemLookUpEdit1[intBind].NullText = "";
                    this.repositoryItemLookUpEdit1[intBind].DataSource = bindingSourceArr[intBind];
                    if (bindingSourceArr[intBind].DataSource != null)
                    {
                        //List<IdAdVm> VM = (List<IdAdVm>)bindingSourceArr[intBind].DataSource;
                        if (this.repositoryItemLookUpEdit1[intBind].View.Columns.Count > 2)
                        {
                            this.repositoryItemLookUpEdit1[intBind].View.Columns["CARIVM"].Visible = false;
                        }
                    }
                    this.repositoryItemLookUpEdit1[intBind].DisplayMember = "AD";
                    this.repositoryItemLookUpEdit1[intBind].Name = ALAN.ALAN_AD;
                    this.repositoryItemLookUpEdit1[intBind].ValueMember = "ID";

                    this.Column1.ColumnEdit = repositoryItemLookUpEdit1[intBind];
                }
                else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.TARIH)//TARIH
                {
                }
                else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.DECIMAL)//DECIMAL
                {
                    if (ALAN.M_ALAN_ALT_BILGI == 1)
                    {
                        String format = "n" + Convert.ToInt32(ALAN.ALAN_DECIMAL);
                        Column1.SummaryItem.FieldName = ALAN.ALAN_AD;
                        Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        if (format != "")
                        {
                            if (format == "n0")
                            {
                                Column1.SummaryItem.DisplayFormat = "{0:0}";
                            }
                            else
                            {
                                Column1.SummaryItem.DisplayFormat = "{0:" + format + "}";
                            }

                        }
                    }
                    repositoryItemTextEdit[intBind] = new RepositoryItemTextEdit();
                    String a = new String('#', Convert.ToInt32(ALAN.ALAN_DECIMAL));
                    String b = new String('#', Convert.ToInt32(ALAN.ALAN_UZUNLUK));
                    this.repositoryItemTextEdit[intBind].Mask.EditMask = b + "." + a;
                    this.repositoryItemTextEdit[intBind].Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    this.repositoryItemTextEdit[intBind].Name = ALAN.ALAN_AD;
                    this.gridControl1.RepositoryItems.Add(repositoryItemTextEdit[intBind]);
                    this.repositoryItemTextEdit[intBind].Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.MouseSpin);
                    Column1.ColumnEdit = repositoryItemTextEdit[intBind];
                }

                else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.TAMSAYI)//TAMSAYI
                {
                    if (ALAN.M_ALAN_ALT_BILGI == 1)
                    {
                        String format = "n" + Convert.ToInt32(ALAN.ALAN_DECIMAL);
                        Column1.SummaryItem.FieldName = ALAN.ALAN_AD;
                        Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        if (format != "")
                        {
                            if (format == "n0")
                            {
                                Column1.SummaryItem.DisplayFormat = "{0:0}";
                            }
                            else
                            {
                                Column1.SummaryItem.DisplayFormat = "{0:" + format + "}";
                            }

                        }
                    }
                    repositoryItemTextEdit[intBind] = new RepositoryItemTextEdit();
                    String a = new String('#', Convert.ToInt32(ALAN.ALAN_DECIMAL));
                    String b = new String('#', Convert.ToInt32(ALAN.ALAN_UZUNLUK));
                    this.repositoryItemTextEdit[intBind].Mask.EditMask = b + "." + a;
                    this.repositoryItemTextEdit[intBind].Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    this.repositoryItemTextEdit[intBind].Name = ALAN.ALAN_AD;
                    this.gridControl1.RepositoryItems.Add(repositoryItemTextEdit[intBind]);
                    this.repositoryItemTextEdit[intBind].Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.MouseSpin);
                    Column1.ColumnEdit = repositoryItemTextEdit[intBind];
                }
                else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.CHECKBOX)//checkbox
                {
                    repositoryItemCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                    this.repositoryItemCheckEdit.AutoHeight = false;
                    this.repositoryItemCheckEdit.Name = ALAN.ALAN_AD;
                    this.gridControl1.RepositoryItems.Add(repositoryItemCheckEdit);
                    Column1.ColumnEdit = repositoryItemCheckEdit;
                }
                else if (ALAN.M_ALAN_TIP_ID == 7) // baglý Alan
                {
                    bindingSourceArr[intBind] = new System.Windows.Forms.BindingSource();
                    this.gridControl1.RepositoryItems.Add(repositoryItemLookUpEdit1[intBind]);
                    repositoryItemLookUpEdit = new RepositoryItemLookUpEdit();
                    string mt = "";
                    mt = "Get" + ALAN.ALAN_AD;
                    bindingSourceArr[intBind].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.AKTIF, 0, ALAN.ID, ust_id, "", "", 0);
                    repositoryItemLookUpEdit.NullText = "";
                    repositoryItemLookUpEdit.DataSource = bindingSourceArr[intBind];
                    repositoryItemLookUpEdit.DisplayMember = "AD";
                    repositoryItemLookUpEdit.Name = ALAN.ALAN_AD;
                    repositoryItemLookUpEdit.ValueMember = "ID";
                    //repositoryItemLookUpEdit.View.PopulateColumns(repositoryItemLookUpEdit.DataSource);
                    if (bindingSourceArr[intBind].DataSource != null)
                    {
                        this.repositoryItemLookUpEdit1[intBind].View.Columns[0].Visible = false;
                    }
                    repositoryItemLookUpEdit.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.Space);
                    this.Column1.ColumnEdit = repositoryItemLookUpEdit;

                }
                if (ALAN.ALAN_AD != "ID")
                {
                    textArama[intArama] = new DevExpress.XtraEditors.TextEdit();
                    textArama[intArama].Name = Column1.FieldName + " :";
                    textArama[intArama].TabIndex = 0;
                    pnlArama.Controls.Add(textArama[intArama]);
                    textArama[intArama].Location = new System.Drawing.Point(60, 25);
                    textArama[intArama].KeyDown += new KeyEventHandler(Arama);
                    intArama += 1;
                }
                intBind += 1;
                gridView1.Columns.Add(Column1);
            }
            return Globals.rman.GetString(tabloAdi);
        }
        public string Gridi_Olustureski()//GRÝD ve ARAMALAR AYARLANIYOR
        {
            string alanadi = "";
            int intArama = 0;
            try
            {
                int ust_id = 0;
                var q = ListDenemeService.GetALANLAR(tabloAdi, 1);
                tabloAlanId = (int)q[0].M_ALANLAR_ID;
                foreach (var ALAN in q)
                {
                    Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
                    Column1.Width = 5;
                    alanadi = ALAN.ALAN_AD;
                    if (ALAN.M_ALAN_TIP_ID == 1)  // TEXT
                    {
                        Column1.FieldName = ALAN.ALAN_AD;
                        Column1.Name = ALAN.ALAN_AD;
                        Column1.Caption = Globals.rman.GetString(ALAN.ALAN_LISTE_AD);
                        Column1.Width = (int)ALAN.ALAN_LISTE_GENISLIK;
                        // Column1.BestFit();  
                        Column1.Visible = true;
                        Column1.VisibleIndex = 1;
                        if (ALAN.M_ALAN_CLASS_NAME != null) { Column1.Tag = Convert.ToString(ALAN.M_ALAN_CLASS_NAME) + "/" + Convert.ToString(ALAN.ID); }
                        if ((ALAN.GORMESIN_E_H == true && ALAN.M_ALANLAR_ALT_ID == null) || ALAN.M_ALAN_TIP_2 == 2)
                        {
                            Column1.Visible = false;
                        }
                        if (ALAN.YAZMASIN_E_H == true && ALAN.M_ALANLAR_ALT_ID == null)
                        {
                            Column1.OptionsColumn.ReadOnly = true;
                            //Column1.OptionsColumn.AllowEdit = false;
                            //Column1.OptionsColumn.AllowFocus = true;
                        }
                        repositoryItemTextEdit[intBindTextEdit] = new RepositoryItemTextEdit();
                        if (ALAN.KIRLIM_TIP_ID != null && ALAN.KIRLIM_TIP_ID != 0)
                        {
                            string kirilim = YardimciIslemler.KirilimUygula(ALAN.KIRLIM_TIP_ID);
                            // this.repositoryItemTextEdit.Mask.EditMask = "\\w\\w\\w-\\w\\w-\\w\\w\\w\\w";
                            // this.repositoryItemTextEdit[intBindTextEdit].Mask.EditMask = "\\w\\w\\w \\w\\w \\w\\w \\w\\w\\w";
                            this.repositoryItemTextEdit[intBindTextEdit].Mask.EditMask = kirilim;
                            this.repositoryItemTextEdit[intBindTextEdit].Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                            this.repositoryItemTextEdit[intBindTextEdit].Mask.UseMaskAsDisplayFormat = true;
                        }
                        else
                        {
                            Column1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
                        }
                        if (ALAN.ALAN_AD == "ALINAN_NOT") //M_ALANLAR tablosuna arama tipi konulacak
                        {
                            Column1.Width = 80;
                        }
                        this.gridControl1.RepositoryItems.Add(repositoryItemTextEdit[intBindTextEdit]);
                        repositoryItemTextEdit[intBindTextEdit].AutoHeight = false;
                        repositoryItemTextEdit[intBindTextEdit].MaxLength = Convert.ToInt16(ALAN.ALAN_UZUNLUK);
                        repositoryItemTextEdit[intBindTextEdit].Name = ALAN.ALAN_AD;
                        this.repositoryItemTextEdit[intBindTextEdit].Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.MouseSpin);
                        Column1.ColumnEdit = repositoryItemTextEdit[intBindTextEdit];
                        intBindTextEdit++;
                        if (ALAN.M_ALAN_KOPYALAMA_E_H == (int)EvetHayirEn.Hayir)
                        {
                            koplalamaDurumu[intBind] = false;
                        }
                        AlanAdiIndexi[ALAN.ALAN_AD] = intBind;
                    }
                    else if (ALAN.M_ALAN_TIP_ID == 2)
                    {
                        Column1.FieldName = ALAN.ALAN_AD;
                        Column1.Name = ALAN.ALAN_LISTE_AD;
                        Column1.Caption = Globals.rman.GetString(ALAN.ALAN_LISTE_AD);
                        Column1.Width = (int)ALAN.ALAN_LISTE_GENISLIK;
                        Column1.Visible = true;
                        Column1.VisibleIndex = 1;
                        if ((ALAN.GORMESIN_E_H == true && ALAN.M_ALANLAR_ALT_ID == null) || ALAN.M_ALAN_TIP_2 == 2)
                        {
                            Column1.Visible = false;
                            Column1.VisibleIndex = -1;
                        }
                        if (ALAN.YAZMASIN_E_H == true && ALAN.M_ALANLAR_ALT_ID == null)
                        {
                            Column1.OptionsColumn.ReadOnly = true;
                        }
                        if (ALAN.M_ALAN_CLASS_NAME != null) { Column1.Tag = Convert.ToString(ALAN.M_ALAN_CLASS_NAME) + "/" + Convert.ToString(ALAN.ID); }
                        bindingSourceArr[intBind] = new System.Windows.Forms.BindingSource();
                        this.gridControl1.RepositoryItems.Add(repositoryItemLookUpEdit1[intBind]);
                        repositoryItemLookUpEdit1[intBind] = new RepositoryItemGridLookUpEdit();
                        string mt = "";
                        mt = "Get" + ALAN.ALAN_AD;
                        if (ALAN.ALAN_AD == "STOK_ID" || ALAN.ALAN_AD == "CARI_ID" || ALAN.M_ALAN_ARAMA_TIP_ID == 1) //M_ALANLAR tablosuna arama tipi konulacak
                        {
                            bindingSourceArr[intBind].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTEKIRILIMSIZ, (int)AktifPasifTumuEn.TUMU, 0, ALAN.ID, ust_id, "", "", 0);
                        }
                        else
                        {
                            bindingSourceArr[intBind].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, ALAN.ID, ust_id, "", "", 0);
                        }
                        if (ALAN.M_ALAN_KOPYALAMA_E_H == (int)EvetHayirEn.Hayir)
                        {
                            koplalamaDurumu[intBind] = false;
                        }
                        if (bindingSourceArr[intBind].DataSource != null)
                        {
                            if (repositoryItemLookUpEdit1[intBind].View.Columns.Count > 2)
                            {
                                repositoryItemLookUpEdit1[intBind].View.Columns["CARIVM"].Visible = false;
                            }
                        }
                        AlanAdiIndexi[ALAN.ALAN_AD] = intBind;
                        this.repositoryItemLookUpEdit1[intBind].NullText = "";
                        this.repositoryItemLookUpEdit1[intBind].DataSource = bindingSourceArr[intBind];
                        this.repositoryItemLookUpEdit1[intBind].DisplayMember = "AD";
                        this.repositoryItemLookUpEdit1[intBind].Name = ALAN.ALAN_AD;
                        this.repositoryItemLookUpEdit1[intBind].ValueMember = "ID";
                        this.repositoryItemLookUpEdit1[intBind].CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.Space);
                        repositoryItemLookUpEdit1[intBind].View.PopulateColumns(repositoryItemLookUpEdit1[intBind].DataSource);
                        if (ALAN.ALAN_AD == "STOK_ID" || ALAN.ALAN_AD == "CARI_ID" || ALAN.M_ALAN_ARAMA_TIP_ID==1 ) //M_ALANLAR tablosuna arama tipi konulacak
                        {
                            Column1.Width = 60;
                            this.repositoryItemLookUpEdit1[intBind].ImmediatePopup = true;
                            this.repositoryItemLookUpEdit1[intBind].TextEditStyle = TextEditStyles.Standard;
                            this.repositoryItemLookUpEdit1[intBind].PopupFilterMode = PopupFilterMode.Contains;
                            Column1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
                        }
                        else
                        {
                            Column1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
                        }
                        if (bindingSourceArr[intBind].DataSource != null)
                        {
                            this.repositoryItemLookUpEdit1[intBind].View.Columns[0].Visible = false;
                        }
                        if (this.repositoryItemLookUpEdit1[intBind].View.Columns.Count > 2)
                        {
                            //this.repositoryItemLookUpEdit1[intBind].View.Columns["CARIVM"].Visible = false;
                        }
                        this.Column1.ColumnEdit = repositoryItemLookUpEdit1[intBind];
                        this.repositoryItemLookUpEdit1[intBind].KeyDown += new System.Windows.Forms.KeyEventHandler(this.repositoryItemLookUpEdit1_KeyDown);
                        this.repositoryItemLookUpEdit1[intBind].ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.repositoryItemGridLookUpEdit1_ProcessNewValue);
                        intBind += 1;
                    }
                    else if (ALAN.M_ALAN_TIP_ID == 8)// EVET HAYIR
                    {
                        Column1.FieldName = ALAN.ALAN_AD;
                        Column1.Name = ALAN.ALAN_AD;
                        Column1.Caption = Globals.rman.GetString(ALAN.ALAN_LISTE_AD);
                        //Column1.Width = (int)ALAN.ALAN_LISTE_GENISLIK;
                        //Column1.BestFit();  
                        Column1.Visible = true;
                        Column1.VisibleIndex = 1;
                        if ((ALAN.GORMESIN_E_H == true && ALAN.M_ALANLAR_ALT_ID == null) || ALAN.M_ALAN_TIP_2 == 2)
                        {
                            Column1.Visible = false;
                            Column1.VisibleIndex = -1;
                        }
                        if (ALAN.YAZMASIN_E_H == true && ALAN.M_ALANLAR_ALT_ID == null)
                        {
                            Column1.OptionsColumn.ReadOnly = true;
                            //Column1.OptionsColumn.AllowEdit = false;
                            //Column1.OptionsColumn.AllowFocus = true;
                        }

                        if (ALAN.M_ALAN_CLASS_NAME != null) { Column1.Tag = Convert.ToString(ALAN.M_ALAN_CLASS_NAME) + "/" + Convert.ToString(ALAN.ID); }
                        bindingSourceArr[intBind] = new System.Windows.Forms.BindingSource();
                        this.gridControl1.RepositoryItems.Add(repositoryItemLookUpEdit1[intBind]);
                        repositoryItemLookUpEdit1[intBind] = new RepositoryItemGridLookUpEdit();
                        bindingSourceArr[intBind].DataSource = ListService.GetLK_HAYIR_EVET_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
                        this.repositoryItemLookUpEdit1[intBind].NullText = "";
                        this.repositoryItemLookUpEdit1[intBind].DataSource = bindingSourceArr[intBind];
                        if (bindingSourceArr[intBind].DataSource != null)
                        {
                            //List<IdAdVm> VM = (List<IdAdVm>)bindingSourceArr[intBind].DataSource;
                            if (repositoryItemLookUpEdit1[intBind].View.Columns.Count > 2)
                            {
                                repositoryItemLookUpEdit1[intBind].View.Columns["CARIVM"].Visible = false;
                            }
                        }
                        this.repositoryItemLookUpEdit1[intBind].DisplayMember = "AD";
                        this.repositoryItemLookUpEdit1[intBind].Name = ALAN.ALAN_AD;
                        this.repositoryItemLookUpEdit1[intBind].ValueMember = "ID";
                        this.repositoryItemLookUpEdit1[intBind].CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.Space);
                        repositoryItemLookUpEdit1[intBind].View.PopulateColumns(repositoryItemLookUpEdit1[intBind].DataSource);
                        if (bindingSourceArr[intBind].DataSource != null)
                        {
                            this.repositoryItemLookUpEdit1[intBind].View.Columns[0].Visible = false;
                        }
                        this.Column1.ColumnEdit = repositoryItemLookUpEdit1[intBind];
                        intBind += 1;
                        if (ALAN.M_ALAN_KOPYALAMA_E_H == (int)EvetHayirEn.Hayir)
                        {
                            koplalamaDurumu[intBind] = false;
                        }
                        AlanAdiIndexi[ALAN.ALAN_AD] = intBind;
                    }
                    else if (ALAN.M_ALAN_TIP_ID == 3)//TARIH
                    {
                        Column1.FieldName = ALAN.ALAN_AD;
                        Column1.Name = ALAN.ALAN_AD;
                        Column1.Visible = true;
                        Column1.Caption = Globals.rman.GetString(ALAN.ALAN_LISTE_AD);
                        Column1.Width = (int)ALAN.ALAN_LISTE_GENISLIK;
                        //Column1.Width = 4;
                        //Column1.BestFit();  
                        Column1.VisibleIndex = 1;
                        if (ALAN.M_ALAN_CLASS_NAME != null) { Column1.Tag = Convert.ToString(ALAN.M_ALAN_CLASS_NAME) + "/" + Convert.ToString(ALAN.ID); }
                        if ((ALAN.GORMESIN_E_H == true && ALAN.M_ALANLAR_ALT_ID == null) || ALAN.M_ALAN_TIP_2 == 2)
                        {
                            Column1.Visible = false;
                            Column1.VisibleIndex = -1;
                        }
                        if (ALAN.YAZMASIN_E_H == true && ALAN.M_ALANLAR_ALT_ID == null)
                        {
                            Column1.OptionsColumn.ReadOnly = true;
                            //Column1.OptionsColumn.AllowEdit = false;
                            //Column1.OptionsColumn.AllowFocus = true;
                        }
                        repositoryItemDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
                        this.repositoryItemDateEdit.AutoHeight = false;
                        this.repositoryItemDateEdit.Name = ALAN.ALAN_AD;
                        //this.repositoryItemDateEdit.VistaTimeProperties.NullText =Now.to
                        this.repositoryItemDateEdit.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                    new DevExpress.XtraEditors.Controls.EditorButton()});
                        this.gridControl1.RepositoryItems.Add(repositoryItemDateEdit);
                        Column1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
                        Column1.ColumnEdit = repositoryItemDateEdit;
                        if (ALAN.M_ALAN_KOPYALAMA_E_H == (int)EvetHayirEn.Hayir)
                        {
                            koplalamaDurumu[intBind] = false;
                        }
                        AlanAdiIndexi[ALAN.ALAN_AD] = intBind;
                    }
                    else if (ALAN.M_ALAN_TIP_ID == 4)//DECIMAL
                    {
                        Column1.FieldName = ALAN.ALAN_AD;
                        Column1.Name = ALAN.ALAN_AD;
                        Column1.Caption = Globals.rman.GetString(ALAN.ALAN_LISTE_AD);
                        Column1.Width = (int)ALAN.ALAN_LISTE_GENISLIK;
                        //Column1.BestFit();  
                        Column1.Visible = true;
                        Column1.VisibleIndex = 1;
                        if (ALAN.M_ALAN_CLASS_NAME != null) { Column1.Tag = Convert.ToString(ALAN.M_ALAN_CLASS_NAME) + "/" + Convert.ToString(ALAN.ID); }
                        if (ALAN.M_ALAN_ALT_BILGI == 1)
                        {
                            Column1.SummaryItem.FieldName = ALAN.ALAN_AD;
                            Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        }
                        if ((ALAN.GORMESIN_E_H == true && ALAN.M_ALANLAR_ALT_ID == null) || ALAN.M_ALAN_TIP_2 == 2)
                        {
                            Column1.Visible = false;
                            Column1.VisibleIndex = -1;
                        }
                        if (ALAN.YAZMASIN_E_H == true && ALAN.M_ALANLAR_ALT_ID == null)
                        {
                            Column1.OptionsColumn.ReadOnly = true;
                            //Column1.OptionsColumn.AllowEdit = false;
                            //Column1.OptionsColumn.AllowFocus = true;
                        }
                        repositoryItemTextEdit[intBindTextEdit] = new RepositoryItemTextEdit();
                        String a = new String('#', Convert.ToInt32(ALAN.ALAN_DECIMAL));
                        String b = new String('#', Convert.ToInt32(ALAN.ALAN_UZUNLUK));
                        this.repositoryItemTextEdit[intBindTextEdit].Mask.EditMask = b + "." + a;
                        this.repositoryItemTextEdit[intBindTextEdit].Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        this.repositoryItemTextEdit[intBindTextEdit].Name = ALAN.ALAN_AD;
                        this.gridControl1.RepositoryItems.Add(repositoryItemTextEdit[intBindTextEdit]);
                        this.repositoryItemTextEdit[intBindTextEdit].Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.MouseSpin);
                        Column1.ColumnEdit = repositoryItemTextEdit[intBindTextEdit];
                        if (ALAN.M_ALAN_KOPYALAMA_E_H == (int)EvetHayirEn.Hayir)
                        {
                            koplalamaDurumu[intBind] = false;
                        }
                        AlanAdiIndexi[ALAN.ALAN_AD] = intBind;
                    }

                    else if (ALAN.M_ALAN_TIP_ID == 5)//TAMSAYI
                    {
                        Column1.FieldName = ALAN.ALAN_AD;
                        Column1.Name = ALAN.ALAN_AD;
                        Column1.Caption = Globals.rman.GetString(ALAN.ALAN_LISTE_AD);
                        Column1.Width = (int)ALAN.ALAN_LISTE_GENISLIK;
                        //Column1.BestFit();  
                        if (ALAN.ALAN_AD != "ID")
                        {
                            Column1.Visible = true;
                            Column1.VisibleIndex = 1;
                        }
                        else
                        {
                            Column1.Visible = false;
                        }
                        
                        if (ALAN.M_ALAN_ALT_BILGI == 1)
                        {
                            Column1.SummaryItem.FieldName = ALAN.ALAN_AD;
                            Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        }
                        if ((ALAN.GORMESIN_E_H == true && ALAN.M_ALANLAR_ALT_ID == null) || ALAN.M_ALAN_TIP_2 == 2)
                        {
                            Column1.Visible = false;
                            Column1.VisibleIndex = -1;
                        }
                        if (ALAN.YAZMASIN_E_H == true && ALAN.M_ALANLAR_ALT_ID == null)
                        {
                            Column1.OptionsColumn.ReadOnly = true;
                            //Column1.OptionsColumn.AllowEdit = false;
                            //Column1.OptionsColumn.AllowFocus = true;
                        }
                        repositoryItemTextEdit[intBindTextEdit] = new RepositoryItemTextEdit();
                        this.gridControl1.RepositoryItems.Add(repositoryItemTextEdit[intBindTextEdit]);
                        repositoryItemTextEdit[intBindTextEdit].AutoHeight = false;
                        repositoryItemTextEdit[intBindTextEdit].MaxLength = Convert.ToInt16(ALAN.ALAN_UZUNLUK);
                        repositoryItemTextEdit[intBindTextEdit].Name = ALAN.ALAN_AD;
                        Column1.ColumnEdit = repositoryItemTextEdit[intBindTextEdit];
                        this.repositoryItemTextEdit[intBindTextEdit].Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.MouseSpin);
                        intBind += 1;
                        if (ALAN.M_ALAN_KOPYALAMA_E_H == (int)EvetHayirEn.Hayir)
                        {
                            koplalamaDurumu[intBind] = false;
                        }
                        AlanAdiIndexi[ALAN.ALAN_AD] = intBind;
                    }
                    else if (ALAN.M_ALAN_TIP_ID == 6)//checkbox
                    {
                        Column1.FieldName = ALAN.ALAN_AD;
                        Column1.Name = ALAN.ALAN_AD;
                        Column1.Caption = Globals.rman.GetString(ALAN.ALAN_LISTE_AD);
                        //Column1.Width = (int)ALAN.ALAN_LISTE_GENISLIK;
                        //Column1.BestFit();  
                        Column1.Visible = true;
                        Column1.VisibleIndex = 1;
                        if (ALAN.M_ALAN_CLASS_NAME != null) { Column1.Tag = Convert.ToString(ALAN.M_ALAN_CLASS_NAME) + "/" + Convert.ToString(ALAN.ID); }
                        if ((ALAN.GORMESIN_E_H == true && ALAN.M_ALANLAR_ALT_ID == null) || ALAN.M_ALAN_TIP_2 == 2)
                        {
                            Column1.Visible = false;
                            Column1.VisibleIndex = -1;
                        }
                        if (ALAN.YAZMASIN_E_H == true && ALAN.M_ALANLAR_ALT_ID == null)
                        {
                            Column1.OptionsColumn.ReadOnly = true;
                            //Column1.OptionsColumn.AllowEdit = false;
                            //Column1.OptionsColumn.AllowFocus = true;
                        }
                        repositoryItemCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                        this.repositoryItemCheckEdit.AutoHeight = false;
                        this.repositoryItemCheckEdit.Name = ALAN.ALAN_AD;
                        this.gridControl1.RepositoryItems.Add(repositoryItemCheckEdit);
                        Column1.ColumnEdit = repositoryItemCheckEdit;
                        if (ALAN.M_ALAN_KOPYALAMA_E_H == (int)EvetHayirEn.Hayir)
                        {
                            koplalamaDurumu[intBind] = false;
                        }
                        AlanAdiIndexi[ALAN.ALAN_AD] = intBind;

                    }
                    else if (ALAN.M_ALAN_TIP_ID == 7) // baglý Alan
                    {
                        Column1.FieldName = ALAN.ALAN_AD;
                        Column1.Name = ALAN.ALAN_AD;
                        Column1.Caption = Globals.rman.GetString(ALAN.ALAN_LISTE_AD);
                        //Column1.Width = (int)ALAN.ALAN_LISTE_GENISLIK;
                        //Column1.BestFit();  
                        Column1.Visible = true;
                        Column1.VisibleIndex = 1;
                        if (ALAN.M_ALAN_CLASS_NAME != null) { Column1.Tag = Convert.ToString(ALAN.M_ALAN_CLASS_NAME) + "/" + Convert.ToString(ALAN.ID); }
                        if (ALAN.GORMESIN_E_H == true && ALAN.M_ALANLAR_ALT_ID == null)
                        {
                            Column1.Visible = false;
                            Column1.VisibleIndex = -1;
                        }
                        if (ALAN.YAZMASIN_E_H == true && ALAN.M_ALANLAR_ALT_ID == null)
                        {
                            Column1.OptionsColumn.ReadOnly = true;
                            //Column1.OptionsColumn.AllowEdit = false;
                            //Column1.OptionsColumn.AllowFocus = true;
                        }
                        bindingSourceArr[intBind] = new System.Windows.Forms.BindingSource();
                        this.gridControl1.RepositoryItems.Add(repositoryItemLookUpEdit1[intBind]);
                        repositoryItemLookUpEdit = new RepositoryItemLookUpEdit();
                        string mt = "";
                        mt = "Get" + ALAN.ALAN_AD;
                        bindingSourceArr[intBind].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, ALAN.ID, ust_id,"","",0);
                        repositoryItemLookUpEdit.NullText = "";
                        repositoryItemLookUpEdit.DataSource = bindingSourceArr[intBind];
                        repositoryItemLookUpEdit.DisplayMember = "AD";
                        repositoryItemLookUpEdit.Name = ALAN.ALAN_AD;
                        repositoryItemLookUpEdit.ValueMember = "ID";
                        //repositoryItemLookUpEdit.Properties.View.PopulateColumns(repositoryItemLookUpEdit.DataSource);
                        if (bindingSourceArr[intBind].DataSource != null)
                        {
                            this.repositoryItemLookUpEdit1[intBind].View.Columns[0].Visible = false;
                        }
                        this.Column1.ColumnEdit = repositoryItemLookUpEdit;
                        intBind += 1;
                        if (ALAN.M_ALAN_KOPYALAMA_E_H == (int)EvetHayirEn.Hayir)
                        {
                            koplalamaDurumu[intBind] = false;
                        }
                        AlanAdiIndexi[ALAN.ALAN_AD] = intBind;
                    }
                    this.gridView1.Columns.Add(Column1);
                    if (ALAN.ALAN_AD != "ID")
                    {
                        textArama[intArama] = new DevExpress.XtraEditors.TextEdit();
                        textArama[intArama].Name = Column1.FieldName + " :";
                        textArama[intArama].TabIndex = 0;
                        pnlArama.Controls.Add(textArama[intArama]);
                        textArama[intArama].Location = new System.Drawing.Point(60, 25);
                        textArama[intArama].KeyDown += new KeyEventHandler(Arama);
                        intArama += 1;
                    }
                    
                }

            }
            catch (Exception)
            {

                MessageBox.Show("alan tanýmlamasýnda sorun  " + alanadi);
            }
            return Globals.rman.GetString(tabloAdi);
        }
        public string Gridi_Olustur()//GRÝD ve ARAMALAR AYARLANIYOR
        {
            string alanadi = "";
            int intArama = 0;
            try
            {
                int ust_id = 0;
                var q = ListDenemeService.GetALANLAR(tabloAdi, 1);
                tabloAlanId = (int)q[0].M_ALANLAR_ID;
                foreach (var ALAN in q)
                {
                    Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
                    Column1.Width = 5;
                    alanadi = ALAN.ALAN_AD;
                    Column1.FieldName = ALAN.ALAN_AD;
                    Column1.Name = ALAN.ALAN_AD;
                    Column1.Caption = Globals.rman.GetString(ALAN.ALAN_LISTE_AD);
                    Column1.Width = (int)ALAN.ALAN_LISTE_GENISLIK;
                    // Column1.BestFit();  
                    Column1.Visible = true;
                    Column1.VisibleIndex = Convert.ToInt32(ALAN.ALAN_SIRA);
                    if (ALAN.M_ALAN_CLASS_NAME != null) { Column1.Tag = Convert.ToString(ALAN.M_ALAN_CLASS_NAME) + "/" + Convert.ToString(ALAN.ID); }
                    if ((ALAN.GORMESIN_E_H == true && ALAN.M_ALANLAR_ALT_ID == null) || ALAN.M_ALAN_TIP_2 == 2)
                    {
                        Column1.Visible = false;
                    }
                    if (ALAN.YAZMASIN_E_H == true && ALAN.M_ALANLAR_ALT_ID == null)
                    {
                        Column1.OptionsColumn.ReadOnly = true;
                    }
                    if (ALAN.M_ALAN_KOPYALAMA_E_H == (int)EvetHayirEn.Hayir)
                    {
                        koplalamaDurumu[intBind] = false;
                    }
                    AlanAdiIndexi[ALAN.ALAN_AD] = intBind;
                    if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.TEXTBOX)  // TEXT
                    {
                        repositoryItemTextEdit[intBind] = new RepositoryItemTextEdit();
                        if (ALAN.KIRLIM_TIP_ID != null && ALAN.KIRLIM_TIP_ID != 0)
                        {
                            string kirilim = YardimciIslemler.KirilimUygula(ALAN.KIRLIM_TIP_ID);
                            this.repositoryItemTextEdit[intBind].Mask.EditMask = kirilim;
                            this.repositoryItemTextEdit[intBind].Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                            this.repositoryItemTextEdit[intBind].Mask.UseMaskAsDisplayFormat = true;
                        }
                        if (ALAN.ALAN_AD == "ALINAN_NOT") //M_ALANLAR tablosuna arama tipi konulacak
                        {
                            Column1.Width = 80;
                        }
                        this.gridControl1.RepositoryItems.Add(repositoryItemTextEdit[intBind]);
                        repositoryItemTextEdit[intBind].AutoHeight = false;
                        repositoryItemTextEdit[intBind].MaxLength = Convert.ToInt16(ALAN.ALAN_UZUNLUK);
                        repositoryItemTextEdit[intBind].Name = ALAN.ALAN_AD;
                        this.repositoryItemTextEdit[intBind].Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.MouseSpin);
                        Column1.ColumnEdit = repositoryItemTextEdit[intBind];
                    }
                    else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.COMBOBOX)
                    {
                        bindingSourceArr[intBind] = new System.Windows.Forms.BindingSource();
                        this.gridControl1.RepositoryItems.Add(repositoryItemLookUpEdit1[intBind]);
                        repositoryItemLookUpEdit1[intBind] = new RepositoryItemGridLookUpEdit();
                        repositoryItemLookUpEdit1[intBind].ExportMode = ExportMode.DisplayText;
                        string mt = "";
                        mt = "Get" + ALAN.ALAN_AD;

                        // Column1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;

                        if (ALAN.M_ALAN_ARAMA_TIP_ID == (int)AlanAramaTipEn.StandartListKirilimsiz)
                        {
                            this.repositoryItemLookUpEdit1[intBind].ImmediatePopup = false;
                            Column1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List;
                            bindingSourceArr[intBind].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTEKIRILIMSIZ, (int)AktifPasifTumuEn.TUMU, 0, ALAN.ID, ust_id, "", "", 0);
                        }
                        else if (ALAN.M_ALAN_ARAMA_TIP_ID == (int)AlanAramaTipEn.StandartListKirilimli || ALAN.M_ALAN_ARAMA_TIP_ID == (int)AlanAramaTipEn.StandartListKirilimBelirtmeden)
                        {
                            this.repositoryItemLookUpEdit1[intBind].ImmediatePopup = false;
                            Column1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List;
                            bindingSourceArr[intBind].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, ALAN.ID, ust_id, "", "", 0);
                        }
                        else if (ALAN.M_ALAN_ARAMA_TIP_ID == (int)AlanAramaTipEn.StandartCheckKirilimsiz)
                        {
                            this.repositoryItemLookUpEdit1[intBind].ImmediatePopup = false;
                            Column1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
                            bindingSourceArr[intBind].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTEKIRILIMSIZ, (int)AktifPasifTumuEn.TUMU, 0, ALAN.ID, ust_id, "", "", 0);
                        }
                        else if (ALAN.M_ALAN_ARAMA_TIP_ID == (int)AlanAramaTipEn.StandartCheckKirilimli || ALAN.M_ALAN_ARAMA_TIP_ID == (int)AlanAramaTipEn.StandartCheckKirilimBelirtmeden)
                        {
                            this.repositoryItemLookUpEdit1[intBind].ImmediatePopup = false;
                            Column1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
                            bindingSourceArr[intBind].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, ALAN.ID, ust_id, "", "", 0);
                        }
                        else if (ALAN.M_ALAN_ARAMA_TIP_ID == (int)AlanAramaTipEn.PopupListKirilimsiz)
                        {
                            this.repositoryItemLookUpEdit1[intBind].ImmediatePopup = true;
                            Column1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List;
                            bindingSourceArr[intBind].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTEKIRILIMSIZ, (int)AktifPasifTumuEn.TUMU, 0, ALAN.ID, ust_id, "", "", 0);
                        }
                        else if (ALAN.M_ALAN_ARAMA_TIP_ID == (int)AlanAramaTipEn.PopupListKirilimli || ALAN.M_ALAN_ARAMA_TIP_ID == (int)AlanAramaTipEn.PopupListKirilimBelirtmeden)
                        {
                            this.repositoryItemLookUpEdit1[intBind].ImmediatePopup = true;
                            Column1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List;
                            bindingSourceArr[intBind].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, ALAN.ID, ust_id, "", "", 0);
                        }
                        else if (ALAN.M_ALAN_ARAMA_TIP_ID == (int)AlanAramaTipEn.PopupCheckKirilimsiz)
                        {
                            this.repositoryItemLookUpEdit1[intBind].ImmediatePopup = true;
                            Column1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
                            bindingSourceArr[intBind].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTEKIRILIMSIZ, (int)AktifPasifTumuEn.TUMU, 0, ALAN.ID, ust_id, "", "", 0);
                        }
                        else if (ALAN.M_ALAN_ARAMA_TIP_ID == (int)AlanAramaTipEn.PopupCheckKirilimli || ALAN.M_ALAN_ARAMA_TIP_ID == (int)AlanAramaTipEn.PopupCheckKirilimBelirtmeden)
                        {
                            this.repositoryItemLookUpEdit1[intBind].ImmediatePopup = true;
                            Column1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
                            bindingSourceArr[intBind].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, ALAN.ID, ust_id, "", "", 0);
                        }
                        this.repositoryItemLookUpEdit1[intBind].TextEditStyle = TextEditStyles.Standard;
                        this.repositoryItemLookUpEdit1[intBind].PopupFilterMode = PopupFilterMode.Contains;
                        Column1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
                        this.repositoryItemLookUpEdit1[intBind].PopupFormSize = new Size(300, 500);
                        this.repositoryItemLookUpEdit1[intBind].View.Appearance.FocusedRow.ForeColor = Color.Red;
                        this.repositoryItemLookUpEdit1[intBind].PopupBorderStyle = PopupBorderStyles.Style3D;
                        this.repositoryItemLookUpEdit1[intBind].AppearanceFocused.BackColor = Color.Red;
                        this.repositoryItemLookUpEdit1[intBind].NullText = "";
                        this.repositoryItemLookUpEdit1[intBind].DataSource = bindingSourceArr[intBind];
                        this.repositoryItemLookUpEdit1[intBind].DisplayMember = "AD";
                        this.repositoryItemLookUpEdit1[intBind].Name = ALAN.ALAN_AD;
                        this.repositoryItemLookUpEdit1[intBind].ValueMember = "ID";
                        this.repositoryItemLookUpEdit1[intBind].CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.Space);
                        if (bindingSourceArr[intBind].DataSource != null)
                        {
                            repositoryItemLookUpEdit1[intBind].View.PopulateColumns(repositoryItemLookUpEdit1[intBind].DataSource);
                            //repositoryItemLookUpEdit1[intBind].View.Columns(repositoryItemLookUpEdit1[intBind].ValueMember).Visible = false;
                            this.repositoryItemLookUpEdit1[intBind].View.Columns[0].Visible = false;
                            if (repositoryItemLookUpEdit1[intBind].View.Columns.Count > 2)
                            {
                                repositoryItemLookUpEdit1[intBind].View.Columns[2].Visible = false;
                            }
                        }
                        this.Column1.ColumnEdit = repositoryItemLookUpEdit1[intBind];
                        this.repositoryItemLookUpEdit1[intBind].KeyDown += new System.Windows.Forms.KeyEventHandler(this.repositoryItemLookUpEdit1_KeyDown);
                        this.repositoryItemLookUpEdit1[intBind].ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.repositoryItemGridLookUpEdit1_ProcessNewValue);
                    }
                    else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.EVETHAYIR)// EVET HAYIR
                    {
                        bindingSourceArr[intBind] = new System.Windows.Forms.BindingSource();
                        this.gridControl1.RepositoryItems.Add(repositoryItemLookUpEdit1[intBind]);
                        repositoryItemLookUpEdit1[intBind] = new RepositoryItemGridLookUpEdit();
                        repositoryItemLookUpEdit1[intBind].ExportMode = ExportMode.DisplayText;
                        bindingSourceArr[intBind].DataSource = ListService.GetLK_HAYIR_EVET_ID((int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, 0, 0, "", "", 0);
                        this.repositoryItemLookUpEdit1[intBind].NullText = "";
                        this.repositoryItemLookUpEdit1[intBind].DataSource = bindingSourceArr[intBind];
                        this.repositoryItemLookUpEdit1[intBind].DisplayMember = "AD";
                        this.repositoryItemLookUpEdit1[intBind].Name = ALAN.ALAN_AD;
                        this.repositoryItemLookUpEdit1[intBind].ValueMember = "ID";
                        this.repositoryItemLookUpEdit1[intBind].CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.Space);
                        repositoryItemLookUpEdit1[intBind].View.PopulateColumns(repositoryItemLookUpEdit1[intBind].DataSource);
                        if (bindingSourceArr[intBind].DataSource != null)
                        {
                            this.repositoryItemLookUpEdit1[intBind].View.Columns[0].Visible = false;
                            if (repositoryItemLookUpEdit1[intBind].View.Columns.Count > 2)
                            {
                                repositoryItemLookUpEdit1[intBind].View.Columns[2].Visible = false;
                            }
                        }
                        this.Column1.ColumnEdit = repositoryItemLookUpEdit1[intBind];
                    }
                    else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.TARIH)//TARIH
                    {
                        repositoryItemDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
                        this.repositoryItemDateEdit.AutoHeight = false;
                        this.repositoryItemDateEdit.Name = ALAN.ALAN_AD;
                        //this.repositoryItemDateEdit.VistaTimeProperties.NullText =Now.to
                        this.repositoryItemDateEdit.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                    new DevExpress.XtraEditors.Controls.EditorButton()});
                        this.gridControl1.RepositoryItems.Add(repositoryItemDateEdit);
                        Column1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
                        Column1.ColumnEdit = repositoryItemDateEdit;
                    }
                    else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.DECIMAL)//DECIMAL
                    {
                        if (ALAN.M_ALAN_ALT_BILGI == 1)
                        {
                            String format = "n" + Convert.ToInt32(ALAN.ALAN_DECIMAL);
                            Column1.SummaryItem.FieldName = ALAN.ALAN_AD;
                            Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                            if (format != "")
                            {
                                if (format == "n0")
                                {
                                    Column1.SummaryItem.DisplayFormat = "{0:0}";
                                }
                                else
                                {
                                    Column1.SummaryItem.DisplayFormat = "{0:" + format + "}";
                                }

                            }
                        }
                        repositoryItemTextEdit[intBind] = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                        String a = new String('#', Convert.ToInt32(ALAN.ALAN_DECIMAL));
                        String b = new String('#', Convert.ToInt32(ALAN.ALAN_UZUNLUK));
                        /////////////this.repositoryItemTextEdit.Mask.EditMask = b + "." + a;
                        if (a == "##")
                        {
                            this.repositoryItemTextEdit[intBind].Mask.EditMask = "###,###,###,##0.00";
                        }
                        else
                        {
                            this.repositoryItemTextEdit[intBind].Mask.EditMask = "###,###,##0.00000";
                        }

                        this.repositoryItemTextEdit[intBind].Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        this.repositoryItemTextEdit[intBind].Mask.UseMaskAsDisplayFormat = true;
                        this.repositoryItemTextEdit[intBind].Name = ALAN.ALAN_AD;
                        this.gridControl1.RepositoryItems.Add(repositoryItemTextEdit[intBind]);
                        this.repositoryItemTextEdit[intBind].Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.MouseSpin);
                        Column1.ColumnEdit = repositoryItemTextEdit[intBind];
                    }
                    else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.TAMSAYI)//TAMSAYI
                    {
                        if (ALAN.ALAN_AD == "ID")
                        {
                            Column1.Visible = false;
                        }
                        if (ALAN.M_ALAN_ALT_BILGI == 1)
                        {
                            Column1.SummaryItem.FieldName = ALAN.ALAN_AD;
                            Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        }
                        repositoryItemTextEdit[intBind] = new RepositoryItemTextEdit();
                        this.gridControl1.RepositoryItems.Add(repositoryItemTextEdit[intBind]);
                        repositoryItemTextEdit[intBind].AutoHeight = false;
                        repositoryItemTextEdit[intBind].MaxLength = Convert.ToInt16(ALAN.ALAN_UZUNLUK);
                        repositoryItemTextEdit[intBind].Name = ALAN.ALAN_AD;
                        Column1.ColumnEdit = repositoryItemTextEdit[intBind];
                        this.repositoryItemTextEdit[intBind].Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.MouseSpin);
                    }
                    intBind += 1;
                    this.gridView1.Columns.Add(Column1);
                    
                }

            }
            catch (Exception)
            {

                MessageBox.Show("alan tanýmlamasýnda sorun  " + alanadi);
            }
            return Globals.rman.GetString(tabloAdi);
        }
        private void repositoryItemLookUpEdit1_KeyDown(object sender, KeyEventArgs e)// gridlookupeditlerde lookuoeditin icerigini degisimek icin kullanýlabilir.
        {
            //if (e.KeyCode == Keys.F4)
            //{
            //    DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs arg = new DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs(obj);
            //    repositoryItemGridLookUpEdit1_ProcessNewValue(this.gridView1, arg);
            //}
            //else if (e.KeyCode == Keys.F6)
            //{
            //    this.repositoryItemLookUpEdit1[4].DataSource = bindingSourceArr[4];
            //    this.repositoryItemLookUpEdit1[4].DisplayMember = "KOD";
            //    this.gridView1.RefreshData();
            //}
            //else if (e.KeyCode == Keys.F7)
            //{
            //    this.repositoryItemLookUpEdit1[4].DataSource = bindingSourceArr[4];
            //    this.repositoryItemLookUpEdit1[4].DisplayMember = "AD";
            //    this.gridView1.RefreshData();
            //}
            //else if (e.KeyCode == Keys.O)
            //{
            //    // string s = this.gridView1.GetRowCellDisplayText(this.gridView1.FocusedRowHandle, this.gridView1.VisibleColumns[0]);
            //    //   s = this.repositoryItemLookUpEdit1[12];
            //}
        }
        private void repositoryItemGridLookUpEdit1_ProcessNewValue(object sender, ProcessNewValueEventArgs e)//gridlookueditlerde icinde valuesu olmayan bir degerin alinip ona gore islem yapilabilmesi icin kullanýlýyor
        {
            if (this.gridView1.FocusedColumn == null) return;
            if (this.gridView1.FocusedColumn.FieldName == "STOK_ID" || this.gridView1.FocusedColumn.FieldName == "CARI_ID")
            {
                obj = e.DisplayValue;
                if (e.DisplayValue != null) ProcessNewValue(e.DisplayValue.ToString());
            }
        }
        private void eventHandler()
        {
            barManager1.ItemClick += new ItemClickEventHandler(barManager_ItemClick);
            this.Load += new System.EventHandler(this.TanitimSablon_Load);
            this.Shown += new System.EventHandler(this.TanitimSablon_Shown);
            this.Activated += new System.EventHandler(this.TanitimSablon_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TanitimSablon_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TanitimSablon_KeyDown);
            this.controlNavigator1.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.controlNavigator1_ButtonClick);
            this.gridControl1.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl1_ProcessGridKey);
            //this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(this.gridView1_ShowGridMenu);
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.gridView1_FocusedColumnChanged);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView1_ValidatingEditor);
            this.gridView1.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            this.gridView1.ShownEditor += new System.EventHandler(this.gridView1_ShownEditor);
            this.gridView1.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView1_BeforeLeaveRow);
            //this.gridView1.BeforePrintRow += new DevExpress.XtraGrid.Views.Base.BeforePrintRowEventHandler(this.gridView1_BeforePrintRow);
            this.gridView1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView1_ShowingEditor);
            this.gridView1.CustomDrawFooter += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gridView1_CustomDrawFooter);
            this.BILGI1_cmd.Click += new System.EventHandler(this.BILGI_1cmd_Click);
            this.BILGI_2cmd.Click += new System.EventHandler(this.BILGI_2cmd_Click);
            this.BILGI_3cmd.Click += new System.EventHandler(this.BILGI_3cmd_Click);
            this.tabControl1.Selecting += new DevExpress.XtraTab.TabPageCancelEventHandler(this.tabControl1_Selecting);
            this.tabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tabControl1_KeyDown);
            this.controlNavigator2.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.controlNavigator2_ButtonClick);
            this.controlNavigator3.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.controlNavigator3_ButtonClick);
            this.printableComponentLink1.CreateReportHeaderArea += new DevExpress.XtraPrinting.CreateAreaEventHandler(this.printableComponentLink1_CreateReportHeaderArea);
            this.printableComponentLink1.Component = this.gridControl1;

        }
     
        private void tabControl1_Selecting(object sender, DevExpress.XtraTab.TabPageCancelEventArgs e)// sifirli kayýt yeni ekleniyorsa ise tab degisimini engelliyor, tureyen sinifa gidiyor
        {
            if (this.DesignMode == false)
            {

                if (yeniSatir == true && e.Page == tabPage1)// sifirli kayitta fis yok ise satirin acilmasini engelliyor
                {
                  //  e.Cancel = true; 12.02.2012' de kaldýrdým. bakýlacak.
                }
                else
                {
                    TabPage_Selecting(e.Page); // tureyen forma gisi
                    e.Cancel =  tabSelect; // tureyen form donusu   12.02.2012 de false deger bu hale getirildi.             
                }
                if (e.Page != tabPage1 && e.Cancel == false)// sifirli kayitta fis yok ise satirin acilmasini engelliyor
                {
                    controlNavigator1.Visible = false;
                }
            }
            if (e.Page == tabPage1 && e.Cancel == false)// sifirli kayitta fis yok ise satirin acilmasini engelliyor
            {
                controlNavigator1.Visible = true;
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)//satirYeniKayitac true oluyor,currenttab aliniyor, alt siniflarda index change aclistiriliyor
        {
            if (this.DesignMode == false)
            {
                if (tabControl1.SelectedTabPageIndex == 0)
                {
                    //if (this.gridView1.FocusedRowHandle < 0)
                    //{
                    //    this.gridView1.FocusedRowHandle = this.gridView1.RowCount - 2;// yeni kayýt acýldýgýnda eski satýra donmesi icin konuldu.
                    //}    
                    //this.gridView1.TopRowIndex = this.gridView1.FocusedRowHandle;
                    this.gridControl1.Focus();
                }
                TabPage_Index_Changed(tabControl1.SelectedTabPageIndex);// tureyen forma gidis
                currentTab = tabControl1.SelectedTabPageIndex; // tab seciminin tureyen formda ayarlanmasi icin konuldu
                if (currentTab == 0)
                {
                    controlNavigator1.Visible = true;
                }
                Globals.escapeTabDegistir = true;
            }
        }
        
        public void KodIsteyenFisSet(object frFis, GridControl gridControl, GridView view, DevExpress.XtraGrid.Columns.GridColumn column)
        {
            fisfrm1 = frFis;
            //fisfrm.fiskodIstedi = false;
            gridIsteyenControl = gridControl;
            gridIsteyenView = view;
            columnIsteyen = column;
        }
        public void KodIsteyenTanitimSet(TanitimSablon frTanitim, GridControl gridControl, GridView view, DevExpress.XtraGrid.Columns.GridColumn column)
        {
            tanitimfrm = frTanitim;
            //fisfrm.fiskodIstedi = false;
            gridIsteyenControl = gridControl;
            gridIsteyenView = view;
            columnIsteyen = column;
        }

        public void ContextMenuolustur()
        {
            int index = 0;
            foreach (var buttons in controlNavigator1.Buttons.CustomButtons)
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)buttons;
                if (btn.Tag != null)
                {
                    contextMenuItems[index] = new MenuItem();
                    contextMenuItems[index].Text = btn.Hint;
                    contextMenuItems[index].Tag = btn.Tag;
                    ContextMenu1.MenuItems.Add(contextMenuItems[index]);
                    if (btn.Tag.ToString() == "Yazdir")
                    {
                        MenuItem mn11 = new MenuItem();
                        for (int i = 0; i < EkranListeleri.Length; i++)
                        {
                            if (EkranListeleri[i] != null && EkranListeleri[i].Name != "")
                            {
                                mn11 = new MenuItem();
                                mn11.Text = EkranListeleri[i].Caption;
                                mn11.Tag = EkranListeleri[i].Name;
                                contextMenuItems[index].MenuItems.Add(mn11);
                                mn11.Click += new System.EventHandler(this.MenuItemDetay1_Click);
                            }
                        }
                    }
                    contextMenuItems[index].Click += new System.EventHandler(this.MenuItem1_Click);
                    index++;
                }

            }

        }
        private void MenuItem1_Click(object sender, System.EventArgs e)
        {
            YardimciIslemlerKontrols.ProgramBeklemeGoster();
            MenuItem mn = (MenuItem)sender;
            NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator1.Buttons.CustomButtons[0]);
            args.Button.Tag = mn.Tag;
            args.Button.Hint = mn.Text;
            controlNavigator1_ButtonClick(controlNavigator1, args);
            //this.usrcontrolNavigator_ButtonClick(sender, e);
            YardimciIslemlerKontrols.ProgramBeklemeDurdur();
        }
        private void MenuItemDetay1_Click(object sender, System.EventArgs e)
        {
            YardimciIslemlerKontrols.ProgramBeklemeGoster();
            MenuItem mn = (MenuItem)sender;
            YazdirmaIslemleri(mn.Tag.ToString(), gridControl1, printableComponentLink1);
            Bar_Manager_Islemleri(mn.Tag.ToString());
            YardimciIslemlerKontrols.ProgramBeklemeDurdur();
        }
        void YazdirmaIslemleri(string islem, GridControl gridControl, PrintableComponentLink pLink)
        {
            if (islem == "EkranList")
            {
                pLink.CreateDocument();
                pLink.ShowPreview();
            }
            else if (islem == "Excell")
            {
                gridView1.OptionsPrint.AutoWidth = false;
                string filepath = System.IO.Path.GetTempFileName();
                filepath = filepath.Remove(filepath.LastIndexOf('.') + 1);
                filepath = String.Concat(filepath, "xlsx");
                //XlsxExportOptions options = new XlsxExportOptions();
                //options.TextExportMode = TextExportMode.Text;
                //gridControl.ExportToXlsx(filepath, options);
                gridControl1.ExportToXlsx(filepath);
                System.Diagnostics.ProcessStartInfo startInfo =
                     new System.Diagnostics.ProcessStartInfo("Excel.exe", String.Format("/r \"{0}\"", filepath));
                System.Diagnostics.Process.Start(startInfo);
            }
            else if (islem == "Pdf")
            {
                gridView1.OptionsPrint.AutoWidth = false;
                string filepath = System.IO.Path.GetTempFileName();
                filepath = filepath.Remove(filepath.LastIndexOf('.') + 1);
                filepath = String.Concat(filepath, "pdf");
                gridControl.ExportToPdf(filepath);
                Process process = new Process();
                process.StartInfo.FileName = filepath;// String.Format("/r \"{0}\"", filepath);
                process.StartInfo.Verb = "Open";
                process.StartInfo.WindowStyle =
                ProcessWindowStyle.Normal;
                process.Start();
            }
        }

        private void barManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YardimciIslemlerKontrols.ProgramBeklemeGoster();
            BarSubItem subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            YazdirmaIslemleri(e.Item.Name, gridControl1, printableComponentLink1);
            Bar_Manager_Islemleri(e.Item.Name);
            YardimciIslemlerKontrols.ProgramBeklemeDurdur();
        }
        public void GoruntuAyarla()
        {
            foreach (DevExpress.XtraTab.XtraTabPage item in tabControl1.TabPages)
            {
                item.Appearance.Header.Font = new Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                item.Appearance.Header.Options.UseFont = true;
                item.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                //item.Appearance.Header.ForeColor = System.Drawing.Color.Red;
            }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TanitimSablon));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.lblSonuc = new System.Windows.Forms.Label();
            this.bindingSource2 = new System.Windows.Forms.BindingSource();
            this.controlNavigator1 = new DevExpress.XtraEditors.ControlNavigator();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pnlIslemler = new DevExpress.XtraEditors.PanelControl();
            this.BILGI_2cmd = new System.Windows.Forms.Button();
            this.pnlEkIslemler = new DevExpress.XtraEditors.PanelControl();
            this.BILGI_3cmd = new System.Windows.Forms.Button();
            this.pnlArama = new DevExpress.XtraEditors.PanelControl();
            this.BILGI1_cmd = new System.Windows.Forms.Button();
            this.tabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.pnlKodIstemi = new System.Windows.Forms.Panel();
            this.lblBilgi = new System.Windows.Forms.Label();
            this.tabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.controlNavigator2 = new DevExpress.XtraEditors.ControlNavigator();
            this.tabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.controlNavigator3 = new DevExpress.XtraEditors.ControlNavigator();
            this.tabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.controlNavigator4 = new DevExpress.XtraEditors.ControlNavigator();
            this.tabPage5 = new DevExpress.XtraTab.XtraTabPage();
            this.controlNavigator5 = new DevExpress.XtraEditors.ControlNavigator();
            this.tabPage6 = new DevExpress.XtraTab.XtraTabPage();
            this.controlNavigator6 = new DevExpress.XtraEditors.ControlNavigator();
            this.tabPage7 = new DevExpress.XtraTab.XtraTabPage();
            this.controlNavigator7 = new DevExpress.XtraEditors.ControlNavigator();
            this.tabPage8 = new DevExpress.XtraTab.XtraTabPage();
            this.controlNavigator8 = new DevExpress.XtraEditors.ControlNavigator();
            this.tabPage9 = new DevExpress.XtraTab.XtraTabPage();
            this.controlNavigator9 = new DevExpress.XtraEditors.ControlNavigator();
            this.tabPage10 = new DevExpress.XtraTab.XtraTabPage();
            this.controlNavigator10 = new DevExpress.XtraEditors.ControlNavigator();
            this.tabPage11 = new DevExpress.XtraTab.XtraTabPage();
            this.controlNavigator11 = new DevExpress.XtraEditors.ControlNavigator();
            this.tabPage12 = new DevExpress.XtraTab.XtraTabPage();
            this.controlNavigator12 = new DevExpress.XtraEditors.ControlNavigator();
            this.tabPage13 = new DevExpress.XtraTab.XtraTabPage();
            this.controlNavigator13 = new DevExpress.XtraEditors.ControlNavigator();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem();
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu();

            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlIslemler)).BeginInit();
            this.pnlIslemler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEkIslemler)).BeginInit();
            this.pnlEkIslemler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlArama)).BeginInit();
            this.pnlArama.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.tabPage12.SuspendLayout();
            this.tabPage13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
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
            // lblSonuc
            // 
            this.lblSonuc.AutoSize = true;
            this.lblSonuc.Location = new System.Drawing.Point(323, 9);
            this.lblSonuc.Name = "lblSonuc";
            this.lblSonuc.Size = new System.Drawing.Size(0, 13);
            this.lblSonuc.TabIndex = 2;
            // 
            // controlNavigator1
            // 
            this.controlNavigator1.Buttons.ImageList = this.imageList1;
            this.controlNavigator1.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 10, true, true, "Yazdýr", "Yazdir"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem1", "Islem1"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem2", "Islem2"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem3", "Islem3"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem4", "Islem4"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem5", "Islem5"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem6", "Islem6"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem7", "Islem7")});
            this.controlNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlNavigator1.Location = new System.Drawing.Point(0, 521);
            this.controlNavigator1.Name = "controlNavigator1";
            this.controlNavigator1.NavigatableControl = this.gridControl1;
            this.controlNavigator1.ShowToolTips = true;
            this.controlNavigator1.Size = new System.Drawing.Size(948, 34);
            this.controlNavigator1.TabIndex = 7;
            this.controlNavigator1.Text = "controlNavigator1";
            this.controlNavigator1.ToolTipController = this.toolTipController1;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(3, 3);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(934, 461);
            this.gridControl1.TabIndex = 14;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.gridView1.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(153)))), ((int)(((byte)(182)))));
            this.gridView1.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.gridView1.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.ColumnFilterButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(198)))), ((int)(((byte)(215)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.BorderColor = System.Drawing.Color.White;
            this.gridView1.Appearance.ColumnFilterButtonActive.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.ColumnFilterButtonActive.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.gridView1.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.Options.UseForeColor = true;
            //this.gridView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            //this.gridView1.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(153)))), ((int)(((byte)(182)))));
            //this.gridView1.Appearance.FilterCloseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            //this.gridView1.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            //this.gridView1.Appearance.FilterCloseButton.Options.UseBackColor = true;
            //this.gridView1.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.ForestGreen;
            this.gridView1.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterPanel.Options.UseFont = true;
            this.gridView1.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(124)))), ((int)(((byte)(148)))));
            this.gridView1.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.Red;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(180)))), ((int)(((byte)(191)))));
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.gridView1.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(153)))), ((int)(((byte)(182)))));
            this.gridView1.Appearance.FooterPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.gridView1.Appearance.FooterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridView1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridView1.Appearance.GroupButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridView1.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupButton.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupButton.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridView1.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(131)))), ((int)(((byte)(161)))));
            this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridView1.Appearance.GroupRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseBorderColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.gridView1.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(153)))), ((int)(((byte)(182)))));
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(250)))));
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.HeaderPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(219)))), ((int)(((byte)(226)))));
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(131)))), ((int)(((byte)(161)))));
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(164)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView1.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(253)))));
            this.gridView1.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(165)))), ((int)(((byte)(177)))));
            this.gridView1.Appearance.Preview.Options.UseBackColor = true;
            this.gridView1.Appearance.Preview.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseForeColor = true;
            this.gridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(197)))), ((int)(((byte)(205)))));
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(164)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.pnlIslemler);
            this.panelControl1.Controls.Add(this.pnlEkIslemler);
            this.panelControl1.Controls.Add(this.pnlArama);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 496);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(0, 0);
            this.panelControl1.TabIndex = 16;
            // 
            // pnlIslemler
            // 
            this.pnlIslemler.Controls.Add(this.BILGI_2cmd);
            this.pnlIslemler.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlIslemler.Location = new System.Drawing.Point(2, -17);
            this.pnlIslemler.Name = "pnlIslemler";
            this.pnlIslemler.Size = new System.Drawing.Size(944, 20);
            this.pnlIslemler.TabIndex = 0;
            this.pnlIslemler.Visible = false;
            // 
            // BILGI_2cmd
            // 
            this.BILGI_2cmd.Dock = System.Windows.Forms.DockStyle.Top;
            this.BILGI_2cmd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BILGI_2cmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.BILGI_2cmd.Location = new System.Drawing.Point(2, 2);
            this.BILGI_2cmd.Name = "BILGI_2cmd";
            this.BILGI_2cmd.Size = new System.Drawing.Size(940, 20);
            this.BILGI_2cmd.TabIndex = 0;
            this.BILGI_2cmd.Text = "ÝÞLEMLER";
            this.BILGI_2cmd.UseVisualStyleBackColor = true;
            // 
            // pnlEkIslemler
            // 
            this.pnlEkIslemler.Controls.Add(this.BILGI_3cmd);
            this.pnlEkIslemler.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlEkIslemler.Location = new System.Drawing.Point(2, 3);
            this.pnlEkIslemler.Name = "pnlEkIslemler";
            this.pnlEkIslemler.Size = new System.Drawing.Size(944, 20);
            this.pnlEkIslemler.TabIndex = 1;
            this.pnlEkIslemler.Visible = false;
            // 
            // BILGI_3cmd
            // 
            this.BILGI_3cmd.Dock = System.Windows.Forms.DockStyle.Top;
            this.BILGI_3cmd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BILGI_3cmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.BILGI_3cmd.Location = new System.Drawing.Point(2, 2);
            this.BILGI_3cmd.Name = "BILGI_3cmd";
            this.BILGI_3cmd.Size = new System.Drawing.Size(940, 23);
            this.BILGI_3cmd.TabIndex = 0;
            this.BILGI_3cmd.Text = "EK ÝÞLEMLER";
            this.BILGI_3cmd.UseVisualStyleBackColor = true;
            // 
            // pnlArama
            // 
            this.pnlArama.Controls.Add(this.BILGI1_cmd);
            this.pnlArama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlArama.Location = new System.Drawing.Point(2, 2);
            this.pnlArama.Name = "pnlArama";
            this.pnlArama.Size = new System.Drawing.Size(944, 21);
            this.pnlArama.TabIndex = 0;
            // 
            // BILGI1_cmd
            // 
            this.BILGI1_cmd.Dock = System.Windows.Forms.DockStyle.Top;
            this.BILGI1_cmd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BILGI1_cmd.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.BILGI1_cmd.Location = new System.Drawing.Point(2, 2);
            this.BILGI1_cmd.Name = "BILGI1_cmd";
            this.BILGI1_cmd.Size = new System.Drawing.Size(940, 20);
            this.BILGI1_cmd.TabIndex = 0;
            this.BILGI1_cmd.Text = "ARAMA";
            this.BILGI1_cmd.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabPage = this.tabPage1;
            this.tabControl1.Size = new System.Drawing.Size(948, 496);
            this.tabControl1.TabIndex = 17;
            this.tabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPage1,
            this.tabPage2,
            this.tabPage3,
            this.tabPage4,
            this.tabPage5,
            this.tabPage6,
            this.tabPage7,
            this.tabPage8,
            this.tabPage9,
            this.tabPage10,
            this.tabPage11,
            this.tabPage12,
            this.tabPage13});
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.gridControl1);
            this.tabPage1.Controls.Add(this.pnlKodIstemi);
            this.tabPage1.Controls.Add(this.lblBilgi);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(940, 467);
            this.tabPage1.Text = "Bilgi Giriþ";
            // 
            // pnlKodIstemi
            // 
            this.pnlKodIstemi.Location = new System.Drawing.Point(191, 58);
            this.pnlKodIstemi.Name = "pnlKodIstemi";
            this.pnlKodIstemi.Size = new System.Drawing.Size(434, 206);
            this.pnlKodIstemi.TabIndex = 6;
            this.pnlKodIstemi.Visible = false;
            // 
            // lblBilgi
            // 
            this.lblBilgi.AutoSize = true;
            this.lblBilgi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblBilgi.ForeColor = System.Drawing.Color.Coral;
            this.lblBilgi.Location = new System.Drawing.Point(525, 14);
            this.lblBilgi.Name = "lblBilgi";
            this.lblBilgi.Size = new System.Drawing.Size(0, 16);
            this.lblBilgi.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.controlNavigator2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(940, 467);
            this.tabPage2.Text = "Ek bilgiler";
            // 
            // controlNavigator2
            // 
            this.controlNavigator2.Buttons.Append.Visible = false;
            this.controlNavigator2.Buttons.CancelEdit.Visible = false;
            this.controlNavigator2.Buttons.Edit.Visible = false;
            this.controlNavigator2.Buttons.EndEdit.Visible = false;
            this.controlNavigator2.Buttons.First.Visible = false;
            this.controlNavigator2.Buttons.Last.Visible = false;
            this.controlNavigator2.Buttons.Next.Visible = false;
            this.controlNavigator2.Buttons.NextPage.Visible = false;
            this.controlNavigator2.Buttons.Prev.Visible = false;
            this.controlNavigator2.Buttons.PrevPage.Visible = false;
            this.controlNavigator2.Buttons.Remove.Visible = false;
            this.controlNavigator2.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 9, true, true, "Kaydet", global::Prodma.DataAccessB2C.Resources.rsReportIngilizce.ASSEMBLY_NAME),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 10, true, true, "Vacgec", global::Prodma.DataAccessB2C.Resources.rsReportIngilizce.ASSEMBLY_NAME)});
            this.controlNavigator2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlNavigator2.Location = new System.Drawing.Point(3, 424);
            this.controlNavigator2.Name = "controlNavigator2";
            this.controlNavigator2.Size = new System.Drawing.Size(934, 40);
            this.controlNavigator2.TabIndex = 0;
            this.controlNavigator2.Text = "controlNavigator2";
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.Controls.Add(this.controlNavigator3);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(940, 467);
            this.tabPage3.Text = "tabPage3";
            // 
            // controlNavigator3
            // 
            this.controlNavigator3.Buttons.Append.Visible = false;
            this.controlNavigator3.Buttons.CancelEdit.Visible = false;
            this.controlNavigator3.Buttons.Edit.Visible = false;
            this.controlNavigator3.Buttons.EndEdit.Visible = false;
            this.controlNavigator3.Buttons.First.Visible = false;
            this.controlNavigator3.Buttons.Last.Visible = false;
            this.controlNavigator3.Buttons.Next.Visible = false;
            this.controlNavigator3.Buttons.NextPage.Visible = false;
            this.controlNavigator3.Buttons.Prev.Visible = false;
            this.controlNavigator3.Buttons.PrevPage.Visible = false;
            this.controlNavigator3.Buttons.Remove.Visible = false;
            this.controlNavigator3.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(9),
            new DevExpress.XtraEditors.NavigatorCustomButton(10)});
            this.controlNavigator3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlNavigator3.Location = new System.Drawing.Point(3, 424);
            this.controlNavigator3.Name = "controlNavigator3";
            this.controlNavigator3.Size = new System.Drawing.Size(934, 40);
            this.controlNavigator3.TabIndex = 1;
            this.controlNavigator3.Text = "controlNavigator3";
            // 
            // tabPage4
            // 
            this.tabPage4.AutoScroll = true;
            this.tabPage4.Controls.Add(this.controlNavigator4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(940, 467);
            this.tabPage4.Text = "tabPage4";
            // 
            // controlNavigator4
            // 
            this.controlNavigator4.Buttons.Append.Visible = false;
            this.controlNavigator4.Buttons.CancelEdit.Visible = false;
            this.controlNavigator4.Buttons.Edit.Visible = false;
            this.controlNavigator4.Buttons.EndEdit.Visible = false;
            this.controlNavigator4.Buttons.Remove.Visible = false;
            this.controlNavigator4.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(9),
            new DevExpress.XtraEditors.NavigatorCustomButton(10)});
            this.controlNavigator4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlNavigator4.Location = new System.Drawing.Point(3, 424);
            this.controlNavigator4.Name = "controlNavigator4";
            this.controlNavigator4.Size = new System.Drawing.Size(934, 40);
            this.controlNavigator4.TabIndex = 1;
            this.controlNavigator4.Text = "controlNavigator4";
            // 
            // tabPage5
            // 
            this.tabPage5.AutoScroll = true;
            this.tabPage5.Controls.Add(this.controlNavigator5);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(940, 467);
            this.tabPage5.Text = "tabPage5";
            // 
            // controlNavigator5
            // 
            this.controlNavigator5.Buttons.Append.Visible = false;
            this.controlNavigator5.Buttons.CancelEdit.Visible = false;
            this.controlNavigator5.Buttons.Edit.Visible = false;
            this.controlNavigator5.Buttons.EndEdit.Visible = false;
            this.controlNavigator5.Buttons.Remove.Visible = false;
            this.controlNavigator5.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(9),
            new DevExpress.XtraEditors.NavigatorCustomButton(10)});
            this.controlNavigator5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlNavigator5.Location = new System.Drawing.Point(3, 424);
            this.controlNavigator5.Name = "controlNavigator5";
            this.controlNavigator5.Size = new System.Drawing.Size(934, 40);
            this.controlNavigator5.TabIndex = 1;
            this.controlNavigator5.Text = "controlNavigator5";
            // 
            // tabPage6
            // 
            this.tabPage6.AutoScroll = true;
            this.tabPage6.Controls.Add(this.controlNavigator6);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(940, 467);
            this.tabPage6.Text = "tabPage6";
            // 
            // controlNavigator6
            // 
            this.controlNavigator6.Buttons.Append.Visible = false;
            this.controlNavigator6.Buttons.CancelEdit.Visible = false;
            this.controlNavigator6.Buttons.Edit.Visible = false;
            this.controlNavigator6.Buttons.EndEdit.Visible = false;
            this.controlNavigator6.Buttons.Remove.Visible = false;
            this.controlNavigator6.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(9),
            new DevExpress.XtraEditors.NavigatorCustomButton(10)});
            this.controlNavigator6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlNavigator6.Location = new System.Drawing.Point(3, 424);
            this.controlNavigator6.Name = "controlNavigator6";
            this.controlNavigator6.Size = new System.Drawing.Size(934, 40);
            this.controlNavigator6.TabIndex = 1;
            this.controlNavigator6.Text = "controlNavigator6";
            // 
            // tabPage7
            //
            this.tabPage7.AutoScroll = true; 
            this.tabPage7.Controls.Add(this.controlNavigator7);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(940, 467);
            this.tabPage7.Text = "tabPage7";
            // 
            // controlNavigator7
            // 
            this.controlNavigator7.Buttons.Append.Visible = false;
            this.controlNavigator7.Buttons.CancelEdit.Visible = false;
            this.controlNavigator7.Buttons.Edit.Visible = false;
            this.controlNavigator7.Buttons.EndEdit.Visible = false;
            this.controlNavigator7.Buttons.Remove.Visible = false;
            this.controlNavigator7.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(9),
            new DevExpress.XtraEditors.NavigatorCustomButton(10)});
            this.controlNavigator7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlNavigator7.Location = new System.Drawing.Point(3, 424);
            this.controlNavigator7.Name = "controlNavigator7";
            this.controlNavigator7.Size = new System.Drawing.Size(934, 40);
            this.controlNavigator7.TabIndex = 1;
            this.controlNavigator7.Text = "controlNavigator7";
            // 
            // tabPage8
            //
            this.tabPage8.AutoScroll = true; 
            this.tabPage8.Controls.Add(this.controlNavigator8);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(940, 467);
            this.tabPage8.Text = "tabPage8";
            // 
            // controlNavigator8
            // 
            this.controlNavigator8.Buttons.Append.Visible = false;
            this.controlNavigator8.Buttons.CancelEdit.Visible = false;
            this.controlNavigator8.Buttons.Edit.Visible = false;
            this.controlNavigator8.Buttons.EndEdit.Visible = false;
            this.controlNavigator8.Buttons.Remove.Visible = false;
            this.controlNavigator8.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(9),
            new DevExpress.XtraEditors.NavigatorCustomButton(10)});
            this.controlNavigator8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlNavigator8.Location = new System.Drawing.Point(3, 424);
            this.controlNavigator8.Name = "controlNavigator8";
            this.controlNavigator8.Size = new System.Drawing.Size(934, 40);
            this.controlNavigator8.TabIndex = 1;
            this.controlNavigator8.Text = "controlNavigator8";
            // 
            // tabPage9
            // 
            this.tabPage9.AutoScroll = true;
            this.tabPage9.Controls.Add(this.controlNavigator9);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(940, 467);
            this.tabPage9.Text = "tabPage9";
            // 
            // controlNavigator9
            // 
            this.controlNavigator9.Buttons.Append.Visible = false;
            this.controlNavigator9.Buttons.CancelEdit.Visible = false;
            this.controlNavigator9.Buttons.Edit.Visible = false;
            this.controlNavigator9.Buttons.EndEdit.Visible = false;
            this.controlNavigator9.Buttons.Remove.Visible = false;
            this.controlNavigator9.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(9),
            new DevExpress.XtraEditors.NavigatorCustomButton(10)});
            this.controlNavigator9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlNavigator9.Location = new System.Drawing.Point(3, 424);
            this.controlNavigator9.Name = "controlNavigator9";
            this.controlNavigator9.Size = new System.Drawing.Size(934, 40);
            this.controlNavigator9.TabIndex = 1;
            this.controlNavigator9.Text = "controlNavigator9";
            // 
            // tabPage10
            // 
            this.tabPage10.AutoScroll = true;
            this.tabPage10.Controls.Add(this.controlNavigator10);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(940, 467);
            this.tabPage10.Text = "tabPage10";
            // 
            // controlNavigator10
            // 
            this.controlNavigator10.Buttons.Append.Visible = false;
            this.controlNavigator10.Buttons.CancelEdit.Visible = false;
            this.controlNavigator10.Buttons.Edit.Visible = false;
            this.controlNavigator10.Buttons.EndEdit.Visible = false;
            this.controlNavigator10.Buttons.Remove.Visible = false;
            this.controlNavigator10.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(9),
            new DevExpress.XtraEditors.NavigatorCustomButton(10)});
            this.controlNavigator10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlNavigator10.Location = new System.Drawing.Point(3, 424);
            this.controlNavigator10.Name = "controlNavigator10";
            this.controlNavigator10.Size = new System.Drawing.Size(934, 40);
            this.controlNavigator10.TabIndex = 1;
            this.controlNavigator10.Text = "controlNavigator10";
            // 
            // tabPage11
            // 
            this.tabPage11.AutoScroll = true;
            this.tabPage11.Controls.Add(this.controlNavigator11);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(940, 467);
            this.tabPage11.Text = "tabPage11";
            // 
            // controlNavigator11
            // 
            this.controlNavigator11.Buttons.Append.Visible = false;
            this.controlNavigator11.Buttons.CancelEdit.Visible = false;
            this.controlNavigator11.Buttons.Edit.Visible = false;
            this.controlNavigator11.Buttons.EndEdit.Visible = false;
            this.controlNavigator11.Buttons.Remove.Visible = false;
            this.controlNavigator11.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(9),
            new DevExpress.XtraEditors.NavigatorCustomButton(10)});
            this.controlNavigator11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlNavigator11.Location = new System.Drawing.Point(3, 424);
            this.controlNavigator11.Name = "controlNavigator11";
            this.controlNavigator11.Size = new System.Drawing.Size(934, 40);
            this.controlNavigator11.TabIndex = 1;
            this.controlNavigator11.Text = "controlNavigator11";
            // 
            // tabPage12
            // 
            this.tabPage12.AutoScroll = true;
            this.tabPage12.Controls.Add(this.controlNavigator12);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage12.Size = new System.Drawing.Size(940, 467);
            this.tabPage12.Text = "tabPage12";
            // 
            // controlNavigator12
            // 
            this.controlNavigator12.Buttons.Append.Visible = false;
            this.controlNavigator12.Buttons.CancelEdit.Visible = false;
            this.controlNavigator12.Buttons.Edit.Visible = false;
            this.controlNavigator12.Buttons.EndEdit.Visible = false;
            this.controlNavigator12.Buttons.Remove.Visible = false;
            this.controlNavigator12.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(9),
            new DevExpress.XtraEditors.NavigatorCustomButton(10)});
            this.controlNavigator12.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlNavigator12.Location = new System.Drawing.Point(3, 424);
            this.controlNavigator12.Name = "controlNavigator12";
            this.controlNavigator12.Size = new System.Drawing.Size(934, 40);
            this.controlNavigator12.TabIndex = 1;
            this.controlNavigator12.Text = "controlNavigator12";
            // 
            // tabPage13
            // 
            this.tabPage13.AutoScroll = true;
            this.tabPage13.Controls.Add(this.controlNavigator13);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage13.Size = new System.Drawing.Size(940, 467);
            this.tabPage13.Text = "tabPage13";
            // 
            // controlNavigator13
            // 
            this.controlNavigator13.Buttons.Append.Visible = false;
            this.controlNavigator13.Buttons.CancelEdit.Visible = false;
            this.controlNavigator13.Buttons.Edit.Visible = false;
            this.controlNavigator13.Buttons.EndEdit.Visible = false;
            this.controlNavigator13.Buttons.Remove.Visible = false;
            this.controlNavigator13.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(9),
            new DevExpress.XtraEditors.NavigatorCustomButton(10)});
            this.controlNavigator13.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlNavigator13.Location = new System.Drawing.Point(3, 424);
            this.controlNavigator13.Name = "controlNavigator13";
            this.controlNavigator13.Size = new System.Drawing.Size(934, 40);
            this.controlNavigator13.TabIndex = 1;
            this.controlNavigator13.Text = "controlNavigator13";
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
            this.printableComponentLink1.PrintingSystem = this.printingSystem1;
            this.printableComponentLink1.PrintingSystemBase = this.printingSystem1;
            // 
            // TanitimSablon
            // 

            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.MaxItemId = 0;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(948, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 555);
            this.barDockControlBottom.Size = new System.Drawing.Size(948, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 555);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(948, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 555);
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // popupMenu1
            // 
           // this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";



            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(948, 555);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.controlNavigator1);
            this.Controls.Add(this.lblSonuc);
            this.KeyPreview = true;
            this.LookAndFeel.SkinName = "Lilian";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "TanitimSablon";
            this.Text = "TanitimSablon";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlIslemler)).EndInit();
            this.pnlIslemler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlEkIslemler)).EndInit();
            this.pnlEkIslemler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlArama)).EndInit();
            this.pnlArama.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.tabPage10.ResumeLayout(false);
            this.tabPage11.ResumeLayout(false);
            this.tabPage12.ResumeLayout(false);
            this.tabPage13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        #region olaylar
        public void customButonIslemleri(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == "Yazdir")
            {
                if (this.popupMenu1.Manager != null)
                {
                    FieldInfo fi = typeof(NavigatorButtonsBase).GetField("viewInfo", BindingFlags.Instance | BindingFlags.NonPublic);
                    NavigatorButtonsViewInfo buttonsViewInfo = (NavigatorButtonsViewInfo)fi.GetValue(controlNavigator1.ViewInfo.Buttons);
                    Point mousePosition = controlNavigator1.PointToClient(Control.MousePosition);
                    NavigatorButtonViewInfo buttonViewInfo = buttonsViewInfo.ButtonViewInfoAt(mousePosition);
                    Point menuPosition = new Point(buttonViewInfo.Bounds.Left, buttonViewInfo.Bounds.Bottom);
                    menuPosition = controlNavigator1.PointToScreen(menuPosition);
                    popupMenu1.ShowPopup(menuPosition);
                }
                else
                {
                    printableComponentLink1.CreateDocument();
                    printableComponentLink1.ShowPreview();
                }
            }
            else
            {
                Custom_Buton_Islemleri(e.Button.Tag.ToString());
            }

        }
        private void printableComponentLink1_CreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
        {
            string d = this.gridView1.FilterPanelText;
            DevExpress.XtraPrinting.TextBrick brick;
            brick = e.Graph.DrawString(this.Text, Color.Navy, new RectangleF(0, 0, 500, 40), DevExpress.XtraPrinting.BorderSide.None);
            brick.Font = new Font("Tahoma", 8);
            brick.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);
            DevExpress.XtraPrinting.TextBrick brick1;
            brick1 = e.Graph.DrawString(d, Color.Navy, new RectangleF(0, 30, 500, 40), DevExpress.XtraPrinting.BorderSide.None);
            brick1.Font = new Font("Tahoma", 8);
            brick1.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);
        }
        public void yazdir()
        {
            printableComponentLink1.CreateDocument();
            printableComponentLink1.ShowPreview();
        }
        private void KayitaGonder(bool kaydet)
        {

            if (kaydet == false)
            {
                NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator1.Buttons.CancelEdit);
                controlNavigator1_ButtonClick(controlNavigator1, args);
                if (!args.Handled)
                {
                    controlNavigator1.NavigatableControl.DoAction(NavigatorButtonType.CancelEdit);
                }
            }
            else
            {
                NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator1.Buttons.EndEdit);
                controlNavigator1_ButtonClick(controlNavigator1, args);
                if (!args.Handled)
                {
                    controlNavigator1.NavigatableControl.DoAction(NavigatorButtonType.EndEdit);
                }
            }
        }//controlnavigatorý tetikliyor
        private bool Kayit(Object row, int rowHandle)
        {
            if (sonsutunkaydet == true)
            {
                ModelVm = row;
                KayitaGonder(true);
                
                if (yeniSatir == true)
                {
                    if (islemTamamDegil == false)
                    {
                        yeniSatir = false;
                        if (ekTabAc == true)
                        {
                            this.gridView1.FocusedRowHandle = rowHandle; // sifirli grdin eski satira focuslanmasý icin.
                            Ikinci_Tab_Ac();
                            ekTabAcildi = true;
                        }
                    }
                    
                }
                sonsutunkaydet = false;
            }
            else
            {
                DialogResult res = MessageBox.Show("Onayla?", "Kayýt Yapýlsýn Mý?", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    ModelVm = row;
                    KayitaGonder(true);
                    if (yeniSatir == true)
                    {
                        if (islemTamamDegil == false)
                        {
                            yeniSatir = false;
                            if (ekTabAc == true)
                            {
                                this.gridView1.FocusedRowHandle = rowHandle; // sifirli grdin eski satira focuslanmasý icin.
                                Ikinci_Tab_Ac();
                            }
                        }

                    }
                }
                else
                {
                    if (yeniSatir == true)
                    {
                        return false;
                    }
                    else
                    {
                       islemTamamDegil = false;
                       this.Doldur();//Eski_Kayit_Al_Yukle
                    }
                }
            }
            if (islemTamamDegil == true) 
            {
                rowHandleExcepTionMessage = rowHandleExcepTionMessage=="" ?"Bilinmeyen Bir Hata Oluþtu":rowHandleExcepTionMessage;
                escapeKapatma = true;
            }
            return !islemTamamDegil;
        }//form kaydet-silleri tetikliyor
        #endregion
        #region virtuals
        public virtual bool Form_Kapama_Islemi() { return false; }
        public virtual void Bar_Manager_Islemleri(string islem) { }
        public virtual void CustomButonEkle()
        {
            try
            {
                for (int i = 0; i < 8; i++)
                {
                    this.controlNavigator1.CustomButtons.RemoveAt(1);
                }

            }
            catch (Exception)
            {
               // throw;
            }
        
        }
        public virtual void ProcessNewValue(string value)//gridlookueditlerde icinde valuesu olmayan bir degerin alinip ona gore islem yapilabilmesi icin kullanýlýyor 
        {
        }
        public virtual void Custom_Buton_Islemleri(string islem) { }
        public void KodIstemiAc(string kriter,int index,bool yeniKayit) 
        {
            if (yeniKayit)
            {
                gridView1.AddNewRow();
                gridView1.SetRowCellValue(gridView1.FocusedRowHandle, "KOD", (object)kriter);
            }
            else
            {
                AramaKodIstemi(kriter, index);
            }
        }
        public virtual void Tanitim_KeyDown(KeyEventArgs args) { }
        public virtual void Bul() { }
        public virtual void Kaydet() { }
        public virtual void Sil() { }
        public virtual void Vazgec() { }
        public virtual void Yazdir() { }
        public virtual void Yeni_Kayit() { }
        public virtual void Alan_Doldur() { }
        public virtual void Doldur() { }
        public virtual void Filtrele() { }
        public virtual void ShownEditor() { }
        public virtual void InitNewRow(int focusedRow) { }
        public virtual void ShowingEditor(int FocusedRowHandle, DevExpress.XtraGrid.Columns.GridColumn FocusedColumn) { }
        public virtual void ValidateRow(int FocusedRowHandle) { }
        public virtual void ValidatingEditor(object value, int FocusedRowHandle, DevExpress.XtraGrid.Columns.GridColumn FocusedColumn) { }
        public virtual void Eski_Kayit_Al_Yukle_Satir(int rowHandle) { }
        public virtual void TabPage_Index_Changed(int index)
        {
            //BagliGridDoldur(false); 
        }
        public virtual void Dinamik_TextBox_Olustur(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e) { }
        public virtual void FocusedColumnChanged(GridView  gridView1, int FocusedRowHandle, int PrevFocusedRowHandle, DevExpress.XtraGrid.Columns.GridColumn FocusedColumn, DevExpress.XtraGrid.Columns.GridColumn PrevFocusedColumn, bool yeniSatir) { }
        public virtual void FocusedRowChanged() { }
        public virtual void ProcessGridKey(GridView view, KeyEventArgs args, int FocusedRowHandle, DevExpress.XtraGrid.Columns.GridColumn FocusedColumn) { }
        public virtual void BagliGridDoldur(bool hepsi) { }
        public virtual void controlNavigator2Kaydet() { }
        public virtual void controlNavigator2Yeni_Kayit() { }
        public virtual void controlNavigator2Vazgec() { }
        public virtual void controlNavigator3Kaydet() { }
        public virtual void controlNavigator3Vazgec() { }
        public virtual void TabPage_Selecting(DevExpress.XtraTab.XtraTabPage tb) { }
        public virtual void Ikinci_Tab_Ac() { }
        public virtual void ModelDoldur() { }
        #endregion
        #region kontroller
    
        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Insert)
            {
                NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator1.Buttons.EndEdit);
                controlNavigator1_ButtonClick(controlNavigator1, args);
                if (!args.Handled)
                {
                    controlNavigator1.NavigatableControl.DoAction(NavigatorButtonType.EndEdit);
                }
            }
        }// ikinci tabda key basma iþlerini kontrol ediyor
        private void controlNavigator1_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)//Override yeni kayýt/guncelle/sil/ilerigerisatirolustur iþlemi Yapýlýyor.
        {

            lblBilgi.Text = "";
            //System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = false;
            ControlNavigator navigator = (ControlNavigator)sender;
            if (e.Button.ButtonType == NavigatorButtonType.Custom)
            {
                customButonIslemleri(sender, e);
            }
            else if (e.Button.ImageIndex == 0)
            {
                this.Doldur();
            }
            else if (e.Button == navigator.Buttons.Next || e.Button == navigator.Buttons.Prev || e.Button == navigator.Buttons.First || e.Button == navigator.Buttons.Last)
            {
                //if (this.gridView1.FocusedRowHandle >= 0) TabPage_Index_Changed(tabControl1.SelectedTabPageIndex);
            }
            else if (e.Button == navigator.Buttons.Append)// Yeni kayýda basildiginda direk kayida hazir olunmasi icin
            {
                //gridView1.ActiveFilterCriteria = null;
                //gridView1.ActiveFilterString=""; 25082012 de silindi
                if (kayitEtme == false) { MessageBox.Show("Kayit Yetkiniz Bulunmamakatadýr"); e.Handled = true; return; }
                gridView1.OptionsView.ShowAutoFilterRow = false;
                this.gridView1.FocusedColumn = this.gridView1.VisibleColumns[0];
                this.gridView1.ShowEditor();
            }
            else if (e.Button == navigator.Buttons.EndEdit)//Kaydete basildiginda grid tabinda ise
            {
                if (butonaBasildi == true)
                {
                    BaseContainerValidateEditorEventArgs args = new BaseContainerValidateEditorEventArgs(null);
                    gridView1_ValidatingEditor(gridView1, args);
                    return;
                }
                if (yeniSatir == false)
                {
                    if (yetki==null || (yetki.YAZ_E_H == true || yetki.YAZ_E_H == null))
                    {
                        this.Kaydet();
                    }
                    else
                    { MessageBox.Show("Yazma Yetkiniz Bulunmamaktadýr"); }
                }
                else
                {
                    this.Yeni_Kayit();
                    //this.Doldur();
                    //this.gridView1.TopRowIndex = gridView1.FocusedRowHandle;
                }
                //Object a = ModelVm;
                e.Handled = !islemTamamDegil;
            }
            else if (e.Button == navigator.Buttons.Remove)//Sil Ýþlemi
            {
                if (silme == true)
                {
                    DialogResult res = MessageBox.Show("Seçili Satýr kaydý silinecek, Emin misiniz ?", "PRODMA ERP", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        this.controlNavigator1.Focus();
                        this.Sil();
                        e.Handled = islemTamamDegil;
                        if (islemTamamDegil == true) this.Doldur();
                        this.gridView1.TopRowIndex = gridView1.FocusedRowHandle;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Silme Yetkiniz Bulunmamaktadýr");
                    e.Handled = true;
                    return;
                }
                this.gridControl1.Focus();
            }
            else if (e.Button == navigator.Buttons.CancelEdit)//Sil Ýþlemi
            {
                e.Handled = false;
            }
            butonaBasildi = true;
        }
        private void controlNavigator2_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            ControlNavigator navigator = (ControlNavigator)sender;
            if (e.Button.ImageIndex  == 9)//Kaydete basildiginda grid tabinda ise
            {

                controlNavigator2Kaydet();
                e.Handled = islemTamamDegil;
                if (islemTamamDegil == true) { controlNavigator2Vazgec(); } else { MessageBox.Show("Ýþlem Tamamlandý"); } 
            }
            else if (e.Button.ImageIndex == 10)//Sil Ýþlemi
            {
                controlNavigator2Vazgec();
                e.Handled = islemTamamDegil;
            }
        }
        private void controlNavigator3_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            ControlNavigator navigator = (ControlNavigator)sender;
            if (e.Button.ImageIndex == 9)//Kaydete basildiginda grid tabinda ise
            {

                controlNavigator3Kaydet();
                e.Handled = islemTamamDegil;
            }
            else if (e.Button.ImageIndex == 10)//Sil Ýþlemi
            {
                controlNavigator3Vazgec();
                e.Handled = islemTamamDegil;
            }
        }
        #endregion
        #region gridkontroller
        private void gridView1_ShowGridMenu(object sender, DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs e)
        {
            GridView view = (GridView)sender;
            GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
            if (hitInfo.InRow)
            {
                //view.FocusedRowHandle = hitInfo.RowHandle;
                ContextMenu1.Show(view.GridControl, e.Point);
            }
        }
        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        { 
            INavigatableControl gr = this.gridControl1;
            bool remove = gr.IsActionEnabled(NavigatorButtonType.Remove);
            GridControl grid = sender as GridControl;
            GridView view = grid.FocusedView as GridView;
            KeyEventArgs keyArgs = new KeyEventArgs(e.KeyCode);
           
             if (Control.ModifierKeys == Keys.Control)
             {
                 if (e.KeyCode == Keys.G && gozlem == false)
                 {
                     gozlem = true;// iki kere aciliyor
                     if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID") != null && GenelParametreSng.Nesne().kullaniciBilgileri.ROL_ID==(int)RolEn.Admin)
                     {
                         LogDetayGozlem frm = new LogDetayGozlem();
                         frm.ID = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");
                         frm.tabloAdi = tabloAdi;
                         frm.ShowDialog();
                         gozlem = false;
                     }
                 }
                 if (e.KeyCode == Keys.Y)
                 {
                     if (view.ActiveEditor is
 DevExpress.XtraEditors.GridLookUpEdit)
                     {
                             string mt = "Get" + view.FocusedColumn.FieldName;
                             bindingSourceArr[view.FocusedColumn.VisibleIndex].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, 0, 0, "", "", 0);
                     }
                 }
                 if (e.KeyCode == Keys.R)
                 {
                     Doldur();
                     int fRow = gridView1.FocusedRowHandle;
                     FocusedRowChangedEventArgs a = new FocusedRowChangedEventArgs(fRow, fRow);
                     gridView1_FocusedRowChanged(gridView1, a);
                 }
                 if (e.KeyCode == Keys.F1)
                 {
                     if (gridView1.Columns["ID"].Visible == false)
                     {
                         gridView1.Columns["ID"].Visible = true;
                     }
                     else
                     {
                         gridView1.Columns["ID"].Visible = false;
                     }
                 }
                 else if (e.KeyCode == Keys.F5 && gozlem==false)
                 {
                     gozlem = true;// iki kere aciliyor
                     //if (tabloAdi != "STOK")
                     //{
                     //    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "STOK_ID") != null)
                     //    {

                     //        StokIliskiliListeler frm = new StokIliskiliListeler();
                     //        frm.stokId = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "STOK_ID");
                     //        frm.ShowDialog();
                     //        gozlem = false;
                     //    }
                     //}
                     //else
                     //{
                     //    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID") != null)
                     //    {

                     //        StokIliskiliListeler frm = new StokIliskiliListeler();
                     //        frm.stokId = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");
                     //        frm.ShowDialog();
                     //        gozlem = false;
                     //    }
                       
                     //}
                     //object a = FisOrtakService.GetStokAmbarDurum((int)gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "STOK_ID"));
                     //frm.listObject = a;
                     //frm.Text = "STok Ambar Miktarlarý ";
                     //frm.panelControl1.Size = new System.Drawing.Size(0, 0);
                     //frm.ShowDialog();
                 }
             }
             else
             {
                 if (e.KeyCode == Keys.F5 || e.KeyCode == Keys.F4)
                 {
                     try
                     {
                         bool yeniSatirEski = yeniSatir;
                         string[] _st = Convert.ToString(view.FocusedColumn.Tag).Split('/');
                         if (_st[0].Length > 0)
                         {
                             this.gridView1.ValidateRow -= new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
                             this.gridView1.FocusedRowChanged -= new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
                             fiskodIstedi = true;
                             this.gridControl1.Enabled = false;
                             Type hai = Type.GetType(_st[0], true);
                             frm = (TanitimSablon)(Activator.CreateInstance(hai));
                             frm.MdiParent = this.MdiParent;
                             frm.blnKodIstemi = true;
                             frm.KodIsteyenTanitimSet(this, this.gridControl1, this.gridView1, this.gridView1.FocusedColumn);
                             frm.Show();
                             if (obj != null)
                             {
                                 if (e.KeyCode == Keys.F5)
                                 { frm.KodIstemiAc(Convert.ToString(obj), 1, false); }//koda gore arama
                                 else if (e.KeyCode == Keys.F4)
                                 { frm.KodIstemiAc(Convert.ToString(obj), 2, false); }//ada gore arama
                                 else
                                 { frm.KodIstemiAc(Convert.ToString(obj), 0, true); }//yeni kayýt icin
                                 obj = null;
                             }
                             else
                             {
                                 string kod = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.FocusedColumn));
                                 frm.KodIstemiAc(kod, 0, false);//secili kayýt icin
                                 obj = null;
                             }
                             yeniSatir = yeniSatirEski;
                             frm.WindowState = FormWindowState.Normal;
                             //this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
                             //this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
                         }
                     }
                     catch (Exception)
                     {
                         this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
                         this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
                         this.gridControl1.Enabled = true;
                         view.OptionsSelection.EnableAppearanceFocusedCell = true;
                         view.ShowEditor();
                         ProcessGridKey(this.gridView1, keyArgs, this.gridView1.FocusedRowHandle, this.gridView1.FocusedColumn);
                     }

                 }
            if (e.KeyCode == Keys.Delete)
            {
                if (gridView1.FocusedRowHandle != GridControl.AutoFilterRowHandle)
                {
                    if (silme == false) { MessageBox.Show("Silme Yetkiniz Bulunmamakatadýr"); return; }
                    if (remove == true)
                    {
                        NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator1.Buttons.Remove);
                        controlNavigator1_ButtonClick(controlNavigator1, args);
                        if (!args.Handled)
                        {
                            controlNavigator1.NavigatableControl.DoAction(NavigatorButtonType.Remove);
                            int fRow = gridView1.FocusedRowHandle;
                            FocusedRowChangedEventArgs a = new FocusedRowChangedEventArgs(fRow, fRow);
                            gridView1_FocusedRowChanged(gridView1, a);
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Insert)
            {
                if (kayitEtme==false) {MessageBox.Show("Kayit Yetkiniz Bulunmamakatadýr");return;}
                NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator1.Buttons.EndEdit);
                controlNavigator1_ButtonClick(controlNavigator1, args);
                if (!args.Handled)
                {
                    controlNavigator1.NavigatableControl.DoAction(NavigatorButtonType.EndEdit);
                }
            }
            else if (e.KeyData == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (blnKodIstemi == true && yeniSatir==false)
                {
                    //KeyEventArgs args = new KeyEventArgs(e.KeyCode);
                    //gridIsteyenView.SetRowCellValue(gridIsteyenView.FocusedRowHandle, columnIsteyen.FieldName, Convert.ToInt32(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "ID")));
                    verilenKodId = Convert.ToInt32(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "ID"));
                    gridIsteyenControl.Enabled = true;
                    gridIsteyenControl.Focus();
                    //gridIsteyenView.TopRowIndex = gridIsteyenView.FocusedRowHandle;
                    this.Close();
                    if (view.FocusedColumn.VisibleIndex == view.VisibleColumns.Count - 1)
                    {
                        sonsutunkaydet = true;
                        //this.gridView1.AddNewRow(); 
                    }
                }
                else
                {
                    if (gridView1.FocusedRowHandle != GridControl.AutoFilterRowHandle)
                    {
                        if (kayitEtme == false ) { MessageBox.Show("Kayit Yetkiniz Bulunmamakatadýr"); return; }
                       // sonRow = sonRowBul(gridView2);
                        if (view.FocusedColumn!=null && view.FocusedColumn.VisibleIndex == view.VisibleColumns.Count - 1)
                        {
                            sonsutunkaydet = true;
                            if (gridView1.FocusedRowHandle < 0 || gridView1.FocusedRowHandle == gridView1.RowCount - 2)
                            {
                                NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator1.Buttons.Append);
                                controlNavigator1_ButtonClick(controlNavigator1, args);
                                if (!args.Handled)
                                {
                                    controlNavigator1.NavigatableControl.DoAction(NavigatorButtonType.Append);
                                }
                            } 
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.F2)
            {
                F2YeBasildi = true;
                gridView1.OptionsView.ShowAutoFilterRow = false;
                gridView1.ActiveFilterString = "";
                if (kayitEtme==false) {MessageBox.Show("Kayit Yetkiniz Bulunmamakatadýr");return;}
                if (view.State == DevExpress.XtraGrid.Views.Grid.GridState.Normal)
                {

                    NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator1.Buttons.Append);
                    controlNavigator1_ButtonClick(controlNavigator1, args);
                    if (!args.Handled)
                    {
                        controlNavigator1.NavigatableControl.DoAction(NavigatorButtonType.Append);
                    }
                }
                F2YeBasildi = false;

            }
            else if (e.KeyCode == Keys.F5)
            {
                
            }
            else if (e.KeyCode == Keys.Escape)
            {
                //NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator1.Buttons.CancelEdit);
                //controlNavigator1_ButtonClick(controlNavigator1, args);
                //if (!args.Handled)
                //{
                //   controlNavigator1.NavigatableControl.DoAction(NavigatorButtonType.CancelEdit);
                //}
                if (remove == true) 
                {
                    if (this.gridView1.IsDefaultState == true) 
                    {
                        if (escapeKapatma == true)
                        {
                            this.Doldur();
                            this.gridView1.TopRowIndex = gridView1.FocusedRowHandle;
                        }
                        if (escapeKapat == true && escapeKapatma == false)
                        {
                            this.Close();
                        }
                        else
                        {
                            escapeKapatma = false;
                        }
                        
                    }
                } 
            }
            else if (e.KeyCode == Keys.F10)
            {
                if (kayitEtme==false) {MessageBox.Show("Kayit Yetkiniz Bulunmamakatadýr");return;}
                NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator1.Buttons.Edit);
                controlNavigator1_ButtonClick(controlNavigator1, args);
                if (!args.Handled)
                {
                    controlNavigator1.NavigatableControl.DoAction(NavigatorButtonType.Edit);
                }
            }
            //else if (e.KeyCode == Keys.F6)
            //{
            //    if (this.gridView1.IsEditing)
            //        this.gridView1.HideEditor();
            //    this.gridView1.CancelUpdateCurrentRow();
            //}
            else if (e.KeyCode == Keys.F8)
            {
                //Ikinci_Tab_Ac();
            }
            else if (e.KeyCode == Keys.F9)
            {
                if (koplalamaDurumu.ContainsKey(AlanAdiIndexi[view.FocusedColumn.FieldName]) == false)
                {
                    if (view.FocusedRowHandle < 0)
                    {
                        view.SetRowCellValue(view.FocusedRowHandle, view.FocusedColumn.FieldName, view.GetRowCellValue(view.RowCount - 2, view.FocusedColumn.FieldName));
                    }
                    else
                    {
                        view.SetRowCellValue(view.FocusedRowHandle, view.FocusedColumn.FieldName, view.GetRowCellValue(view.RowCount - 3, view.FocusedColumn.FieldName));
                    }
                }
                if (view.ActiveEditor != null) view.ActiveEditor.IsModified = true;
            }
             
            else if (e.KeyCode == Keys.F3)
            {
                if (view.OptionsView.ShowAutoFilterRow == false)
                {
                    if (Control.ModifierKeys != Keys.Shift)
                    {
                        view.OptionsView.ShowAutoFilterRow = true;
                        view.FocusedRowHandle = GridControl.AutoFilterRowHandle;
                    }
                }
                else
                {
                    view.OptionsView.ShowAutoFilterRow = false;
                }
            }
        }
            ProcessGridKey(this.gridView1, keyArgs, this.gridView1.FocusedRowHandle, this.gridView1.FocusedColumn);
        }
        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle == GridControl.AutoFilterRowHandle) return;
            if (e.FocusedColumn == null || e.PrevFocusedColumn == null) return;
            FocusedColumnChanged(this.gridView1, this.gridView1.FocusedRowHandle, this.gridView1.FocusedRowHandle, e.FocusedColumn, e.PrevFocusedColumn, yeniSatir);
        }
        public void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridViewErisim = true;
            escapeKapatma = false;// kayit yapilamama durumunda sablon icerisinde rowu degistrsin ama ekran kapatilamasin diye kondu
            if (gridView1.FocusedRowHandle == GridControl.AutoFilterRowHandle  || this.gridControl1.Enabled == false) return;
            gridView1.OptionsView.ShowAutoFilterRow = false;
            if (gridView1.FocusedRowHandle < 0 && yeniSatir == false) return;
            if (tabControl1.SelectedTabPage == tabPage1) // || tabControl1.SelectedTabPage == tbFisSatir siparislenen kayýtýn siparislendigi belli olmuyordu. fis_satir tabýnda iken
            {
                ModelVm = this.gridView1.GetFocusedRow();
            }
            //ModelVm = this.gridView1.GetFocusedRow();
            yeniSatir = false;
            if (tabControl1.SelectedTabPageIndex != 0 )
            {
                TabPage_Index_Changed(tabControl1.SelectedTabPageIndex);
            }
            FocusedRowChanged();
            if (gridViewErisim == false)
            {
                controlNavigator1.Buttons.Remove.Enabled = false;
                controlNavigator1.Buttons.Append.Enabled = true;
            }
            else
            {
                controlNavigator1.Buttons.Remove.Enabled = true;
                gridView1.OptionsBehavior.Editable = true;
            }
            if (Convert.ToInt32(this.gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"))> 0) ilkKayit = false;
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //BagliGridDoldur(true);
        }
        public void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            butonaBasildi = false;
            rowHandleExcepTionMessage = "";
            if (gridView1.FocusedRowHandle == GridControl.AutoFilterRowHandle  || this.gridControl1.Enabled == false)
            {
                e.Valid = false; return;
            }
            if (tabControl1.SelectedTabPage == tabPage1 && this.gridControl1.Enabled == true)
            {
                if (yeniSatir == true && sonsutunkaydet == false)
                {
                    NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator1.Buttons.CancelEdit);
                    controlNavigator1_ButtonClick(controlNavigator1, args);
                    if (!args.Handled)
                    {
                        controlNavigator1.NavigatableControl.DoAction(NavigatorButtonType.CancelEdit);
                    }
                    return;
                }
                //else if (Globals.gnActiveForm != this.Text)
                //{
                //    if (Convert.ToInt32(this.gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID")) == 0)
                //    {
                //        e.Valid = false;
                //        return;
                //    }
                //    NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator1.Buttons.CancelEdit);
                //    controlNavigator1_ButtonClick(controlNavigator1, args);
                //    if (!args.Handled)
                //    {
                //        controlNavigator1.NavigatableControl.DoAction(NavigatorButtonType.CancelEdit);
                //    }
                //    return;
                //}
                ValidateRow(this.gridView1.FocusedRowHandle);
                e.Valid = blnValidateRow;
                if (e.Valid == true)
                {
                    e.Valid = Kayit(e.Row, e.RowHandle);
                }
            }
            if (e.Valid == true)
                yeniSatir = false;
            //if (ekTabAcildi == true)
            //{
            //    e.Valid = false;
            //    ekTabAcildi = false;
            //}
        }
        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            if (Globals.mFormAc == false)
            {
                e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
                if (rowHandleExcepTionMessage != "")
                {
                    //Doldur();
                    MessageBox.Show(rowHandleExcepTionMessage);
                    //this.gridView1.CancelUpdateCurrentRow(); 
                } 
            }
            else
            {
                e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
                Globals.mFormAc = false;
            }
        }
        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn gridCol in gridView1.Columns)
            {
                if (gridCol.FieldName=="LK_DURUM_ID")
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol, 1);
                }
                if (gridCol.FieldName == "TARIH")
                {
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridCol, DateTime.Today);
                }
            }
            if (ekTabAcildi != true) { ModelVm = this.gridView1.GetFocusedRow(); ekTabAcildi = false; }
            InitNewRow(e.RowHandle);// varsayýlan degerleri modele yerlestir.
            this.gridView1.FocusedColumn = this.gridView1.VisibleColumns[0];
            yeniSatir = true;
            ilkKayit = true;
            blnGridView1ShowingEditor = false;
            gridView1.OptionsBehavior.Editable = true;
            //tabPage4.Text = "";
        }
        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            //if (tpMesaj2 != null) tpMesaj2.Text = gridView1.RowCount - 1 + " Kayýt Listelenmiþtir";
            if (kayitEtme == false)
            { 
                e.Cancel = true; 
              //  MessageBox.Show("Kayýt Yapma Yetkiniz Bulunmamaktadýr"); 
                return; 
            }
            else if (gridViewErisim == false)
            {
                e.Cancel = true;
                return;
            }
            if (gridView1.FocusedRowHandle == GridControl.AutoFilterRowHandle) return;
            if (sEditorColumnSifirli != this.gridView1.FocusedColumn.FieldName.ToString() || sEditorRowSifirli != this.gridView1.FocusedRowHandle)
            {
                blnGridView1ShowingEditor = false;
                ShowingEditor(this.gridView1.FocusedRowHandle, this.gridView1.FocusedColumn);
            }
            e.Cancel = blnGridView1ShowingEditor;
            sEditorRowSifirli = this.gridView1.FocusedRowHandle;
            sEditorColumnSifirli = this.gridView1.FocusedColumn.FieldName.ToString();
        }// tanýmlanmadý
        private void gridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            if (gridView1.FocusedRowHandle == GridControl.AutoFilterRowHandle) return;
            errorTextValidatingEditor = "";
            blnValidatingEditor = true;
            //if (e.Value != null) ValidatingEditor(e.Value, this.gridView1.FocusedRowHandle, this.gridView1.FocusedColumn);
            ValidatingEditor(e.Value, this.gridView1.FocusedRowHandle, this.gridView1.FocusedColumn); //30.11.2012 de yukarýsý kapatýlýp bu satur haline getirildi.
            
            e.ErrorText = errorTextValidatingEditor;
            e.Valid = blnValidatingEditor;
            if (e.Valid == true)
            {
                try
                {
                    int result;
                    if (int.TryParse(Convert.ToString(e.Value), out result) == true && Convert.ToInt32(e.Value)>0)
                    {
                        object sonuc = ListService.InvokeMethod("Get" + this.gridView1.FocusedColumn.FieldName, (int)ListServiceTipEn.LISTEBYIDAKTIF, (int)AktifPasifTumuEn.AKTIF, Convert.ToInt32(e.Value), 0, 0, "", "", 0);
                        if (sonuc!=null && Convert.ToInt32(sonuc) == 0)
                        {
                            DialogResult res = MessageBox.Show("Pasifleþtirilmiþ Alan, Ýþlem Yapmak Ýstediðinize Emin Misiniz", "PRODMA ERP", MessageBoxButtons.YesNo);
                            if (res == DialogResult.Yes)
                            {
                                e.Valid = true;
                            }
                            else
                            {
                                e.Valid = false;
                                return;
                            }
                        }
                        string[] _st = Convert.ToString(this.gridView1.FocusedColumn.Tag).Split('/');
                        if (_st.Length > 1)
                        {
                            object sonuc2 = ListService.InvokeMethod("Get" + this.gridView1.FocusedColumn.FieldName, (int)ListServiceTipEn.YETKIKONTROL, (int)AktifPasifTumuEn.TUMU, Convert.ToInt32(e.Value), Convert.ToInt32(_st[1]), Globals.gnKullaniciId,"","",0);
                            if (sonuc2 != null && (bool)sonuc2 == false)
                            {
                                e.ErrorText = "Bu Bilgiyi Seçme Yetkiniz Bulunmamaktadýr";
                                e.Valid = false;
                                return;
                            }
                        }
                    }



                }
                catch (Exception)
                {
                    //  throw;
                }
            }
        }// tanýmlanmadý
        public void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                int width = e.Bounds.Width;
                if (textArama[e.Column.VisibleIndex] != null)
                {
                    //textArama[e.Column.VisibleIndex].Width = width;
                    //textArama[e.Column.VisibleIndex].Size = new System.Drawing.Size(e.Bounds.Width, e.Bounds.Height);
                    //textArama[e.Column.VisibleIndex].TabIndex = 0;
                    //textArama[e.Column.VisibleIndex].Location = new System.Drawing.Point(e.Bounds.Left, textArama[e.Column.VisibleIndex].Location.Y);
                    ////usrGridBilgi.Dinamik_TextBox_Olustur(sender, e); 
                    Dinamik_TextBox_Olustur(sender, e);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("customdrawcellde hata:" + ex.Message.ToString());
            }
            
        }
        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle == GridControl.AutoFilterRowHandle) return;

            if (yeniSatir==true) gridView1.ActiveEditor.IsModified = true;  //30.11.2012 de eklendi.
            //gridView1.ActiveEditor.IsModified = true;  //30.11.2012 de eklendi.yukarýsý kapatýlýp

            if (this.gridView1.ActiveEditor is DevExpress.XtraEditors.DateEdit)
            {

                DevExpress.XtraEditors.DateEdit edit;
                string date = Convert.ToString(DateTime.Today);
                edit = (DevExpress.XtraEditors.DateEdit)this.gridView1.ActiveEditor;
                if (edit.Text == "01.01.0001")
                    edit.Text = date;
                //int introw = this.gridView1.FocusedRowHandle;
                //int ust_id = Convert.ToInt16(this.gridView1.GetRowCellValue(introw, "M_ALANLAR_UST_ID"));
                //edit.Properties.DataSource = ListDenemeService.GetM_ALANLAR_ID_BY_PARAM(0, ust_id);
                //edit.Properties.DisplayMember = "AD";
                //edit.Properties.ValueMember = "ID";
                //   edit.View.Columns[0].Visible = false;  
            }
            if (this.gridView1.FocusedColumn.FieldName == "STOK_ID" && this.gridView1.ActiveEditor is
         DevExpress.XtraEditors.GridLookUpEdit)
            {
                DevExpress.XtraEditors.GridLookUpEdit edit;
                edit = (DevExpress.XtraEditors.GridLookUpEdit)this.gridView1.ActiveEditor;
                //edit.Properties.DataSource = ListService.GetSTOK_ID((int)ListServiceTipEn.LISTEKIRILIMSIZ, (int)AktifPasifTumuEn.TUMU, 0, 0, 0, "", "", 0);
                edit.Properties.DisplayMember = "AD";
                edit.Properties.ValueMember = "ID";
            }
            else if (this.gridView1.FocusedColumn.FieldName == "CARI_ID" && this.gridView1.ActiveEditor is
        DevExpress.XtraEditors.GridLookUpEdit)
            {
                DevExpress.XtraEditors.GridLookUpEdit edit;
                edit = (DevExpress.XtraEditors.GridLookUpEdit)this.gridView1.ActiveEditor;
                //edit.Properties.DataSource = ListService.GetCARI_ID((int)ListServiceTipEn.LISTEKIRILIMSIZ, (int)AktifPasifTumuEn.TUMU, 0, 0, 0, "", "", 0);
                edit.Properties.DisplayMember = "AD";
                edit.Properties.ValueMember = "ID";
            }
            else if (this.gridView1.FocusedColumn.FieldName == "MUHASEBE_HESAP_PLANI_ID" && this.gridView1.ActiveEditor is
      DevExpress.XtraEditors.GridLookUpEdit)
            {
                DevExpress.XtraEditors.GridLookUpEdit edit;
                edit = (DevExpress.XtraEditors.GridLookUpEdit)this.gridView1.ActiveEditor;
                //edit.Properties.DataSource = ListService.GetMUHASEBE_HESAP_PLANI_ID((int)ListServiceTipEn.LISTEKIRILIMSIZ, (int)AktifPasifTumuEn.TUMU, 0, 0, 0, "", "", 0);
                edit.Properties.DisplayMember = "AD";
                edit.Properties.ValueMember = "ID";
            }
            else if (this.gridView1.FocusedColumn.FieldName == "MUHASEBE_MASRAF_YERI_ID" && this.gridView1.ActiveEditor is
   DevExpress.XtraEditors.GridLookUpEdit)
            {
                DevExpress.XtraEditors.GridLookUpEdit edit;
                edit = (DevExpress.XtraEditors.GridLookUpEdit)this.gridView1.ActiveEditor;
                //edit.Properties.DataSource = ListService.GetMUHASEBE_MASRAF_YERI_ID((int)ListServiceTipEn.LISTEKIRILIMSIZ, (int)AktifPasifTumuEn.TUMU, 0, 0, 0, "", "", 0);
                edit.Properties.DisplayMember = "AD";
                edit.Properties.ValueMember = "ID";
            }
            ShownEditor();
        }
        private void gridView1_BeforeLeaveRow(object sender, RowAllowEventArgs e)
        {
            if (gridView1.FocusedRowHandle == GridControl.AutoFilterRowHandle || tabControl1.SelectedTabPage != tabPage1 || this.gridControl1.Enabled == false) return;
            GridView view = (GridView)sender;
            if ((view.GetRowCellValue(view.FocusedRowHandle, "ID") == null || Convert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "ID")) == 0) && view.FocusedRowHandle >= 0)
            {
                //Doldur();
            }
            //if (yeniSatirSifirli==true) e.Allow = false;
        }
        private void gridView1_CustomDrawFooter(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e) {
            e.Painter.DrawObject(e.Info);

            //GridView view = sender as GridView;
            //GridViewInfo gvi = view.GetViewInfo() as GridViewInfo;

            //DevExpress.Utils.Drawing.FooterCellInfoArgs info = new DevExpress.Utils.Drawing.FooterCellInfoArgs(e.Cache);
            //info.Appearance.Assign(view.PaintAppearance.FooterPanel);
            //Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y, view.IndicatorWidth, e.Bounds.Height);
            //rect.Inflate(-3, -3);
            //info.Bounds = rect;
            //info.DisplayText = string.Format("{0}", view.DataRowCount);
            //gvi.Painter.ElementsPainter.FooterCell.DrawObject(info);

            //e.Handled = true;

            e.Painter.DrawObject(e.Info);

            GridView view = sender as GridView;
            //string s = "Kayýt Listelendi";
            //if (Globals.rman.GetString("Kayýt Listelendi") != null) { s = Globals.rman.GetString("Kayýt Listelendi"); }
            string sum = string.Format("{0}", view.DataRowCount + " " + YardimciIslemler.IstenilenDileCevir("Kayýt Listelendi"));
            Point point = new Point(e.Bounds.Left + 3, e.Bounds.Top + 3);
            e.Graphics.DrawString(sum, new Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162))), Brushes.Black, point);

            e.Handled = true;   

        }
        #endregion
        #region PopUpFormAc
        public event EventHandler ButtonClick;
        #region KodVer
        private void OnButtonClicked(EventArgs e)
        {
            if (ButtonClick != null)
            {
                ButtonClick(this, e);
            }
        }
        public int Value
        {
            get
            {
                return dondurulenId;
            }
        }
        private int _kodVerId;
        public int kodVerId
        {
            get { return _kodVerId; }
            set { _kodVerId = value; }
        }
        private void KodVer(EventArgs e)
        {
            dondurulenId = Convert.ToInt32(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "ID"));
            _kodVerId = dondurulenId;
            this.Close();
            //OnButtonClicked(e);
        }
        #endregion
        #region KodIste
        public void Form_Ac()
        {
            if (this.gridView1.FocusedColumn.Tag != null)
            {
                int columnIndex = 1;
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridViewInfo viewInfo = (DevExpress.XtraGrid.Views.Grid.ViewInfo.GridViewInfo)this.gridView1.GetViewInfo();
                //DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo cellInfo = viewInfo.GetGridCellInfo(this.gridView1.FocusedRowHandle, columnIndex);
                //X = cellInfo.Bounds.Left;
                //Y = cellInfo.Bounds.Top;
                // pnlKodIstemi.Location = new Point(X, Y + 100);
                rowHandle = this.gridView1.FocusedRowHandle;
                this.gridControl1.Enabled = false;
                this.pnlKodIstemi.Visible = true;
                string[] _st = Convert.ToString(this.gridView1.FocusedColumn.Tag).Split('/'); //"Prodma.Satis.CariHesap.Cari,Prodma.Satis";
                Type hai = Type.GetType(_st[0], true);
                frm = (TanitimSablon)(Activator.CreateInstance(hai));
                frm.Visible = true;
                frm.blnKodIstemi = true;
                frm.ButtonClick += frm_ButtonClick;
                this.pnlKodIstemi.Size = new System.Drawing.Size(800, 365);
                frm.TopLevel = false;
                this.pnlKodIstemi.Controls.Add(frm);
                frm.Dock = System.Windows.Forms.DockStyle.Fill;
                frm.Show();
                ActiveControl = (Control)this.frm;
                frm.gridView1.Focus();
            }
        }
        void frm_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                frm.blnKodIstemi = false;
                this.Text = Convert.ToString(dondurulenId);
                this.gridView1.SetRowCellValue(rowHandle, this.gridView1.FocusedColumn.FieldName, frm.dondurulenId);
                this.Text = Convert.ToString(frm.dondurulenId);
                pnlKodIstemi.Visible = false;
                ActiveControl = (Control)this.gridControl1;
                this.gridControl1.Enabled = true;
                this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = true;
                this.gridView1.FocusedRowHandle = rowHandle;
                this.gridView1.ShowEditor();
                frm.Visible = false;
            }
            catch (Exception)
            {
                //throw;
            }
        }
        #endregion
        #endregion
        #region ekranaltislemlerAC
        private bool blnBilgi1Kapat = false;
        private bool blnBilgi2Kapat = false;
        private bool blnBilgi3Kapat = false;
        private void PanelAyarla(bool blnKapat)
        {
            if (blnKapat == true)
            {
                //pnl.Size = new System.Drawing.Size(536, 20);

                this.panelControl1.Size = new System.Drawing.Size(536, this.panelControl1.Size.Height - 80);

            }
            else
            {
                //pnl.Size = new System.Drawing.Size(536, 100);
                this.panelControl1.Size = new System.Drawing.Size(536, this.panelControl1.Size.Height + 100);
            }
        }
        private void BILGI_1cmd_Click(object sender, EventArgs e)
        {
            if (blnBilgi1Kapat == true)// kapatma
            {
                if (pnlEkIslemler.Visible == false && pnlIslemler.Visible == false)
                {
                    this.pnlArama.Size = new System.Drawing.Size(536, 20);
                    this.panelControl1.Size = new System.Drawing.Size(536, 25);
                    blnBilgi1Kapat = false;
                }
                else
                {
                    this.pnlArama.Size = new System.Drawing.Size(536, 20);
                    blnBilgi1Kapat = false;
                    if (blnBilgi3Kapat == true && blnBilgi2Kapat == true)// ikisi de acik
                    {
                        this.panelControl1.Size = new System.Drawing.Size(536, 220);
                    }
                    else if (blnBilgi3Kapat == false && blnBilgi2Kapat == false)// ikisi de kapali
                    {
                        this.panelControl1.Size = new System.Drawing.Size(536, 65);
                    }
                    else
                    {
                        this.panelControl1.Size = new System.Drawing.Size(536, 140);
                    }
                }
            }
            else
            {
                if (pnlEkIslemler.Visible == false && pnlIslemler.Visible == false)
                {
                    this.pnlArama.Size = new System.Drawing.Size(536, 40);
                    this.panelControl1.Size = new System.Drawing.Size(536, 65);
                    blnBilgi1Kapat = true;
                }
                else
                {
                    this.pnlArama.Size = new System.Drawing.Size(536, 90);
                    blnBilgi1Kapat = true;
                    if (blnBilgi3Kapat == true && blnBilgi2Kapat == true)// ikisi de acik
                    {
                        this.panelControl1.Size = new System.Drawing.Size(536, 240);
                    }
                    else if (blnBilgi3Kapat == false && blnBilgi2Kapat == false)// ikisi de kapali
                    {
                        this.panelControl1.Size = new System.Drawing.Size(536, 90);
                    }
                    else
                    {
                        this.panelControl1.Size = new System.Drawing.Size(536, 160);
                    }
                }
            }
        }
        private void BILGI_2cmd_Click(object sender, EventArgs e)
        {
            if (blnBilgi2Kapat == true)
            {
                this.pnlIslemler.Size = new System.Drawing.Size(536, 20);
                if (blnBilgi1Kapat == true && blnBilgi3Kapat == true)// ikisi de acik
                {
                    this.panelControl1.Size = new System.Drawing.Size(536, 220);
                }
                else if (blnBilgi1Kapat == false && blnBilgi3Kapat == false)// ikisi de kapali
                {
                    this.panelControl1.Size = new System.Drawing.Size(536, 65);
                }
                else
                {
                    this.panelControl1.Size = new System.Drawing.Size(536, 140);
                }

                blnBilgi2Kapat = false;
            }
            else
            {
                this.pnlIslemler.Size = new System.Drawing.Size(536, 100);
                if (blnBilgi1Kapat == true && blnBilgi3Kapat == true)// ikisi de acik
                {
                    this.panelControl1.Size = new System.Drawing.Size(536, 300);
                }
                else if (blnBilgi1Kapat == false && blnBilgi3Kapat == false)// ikisi de kapali
                {
                    this.panelControl1.Size = new System.Drawing.Size(536, 145);
                }
                else
                {
                    this.panelControl1.Size = new System.Drawing.Size(536, 220);
                }

                blnBilgi2Kapat = true;
            }

        }
        private void BILGI_3cmd_Click(object sender, EventArgs e)
        {
            if (blnBilgi3Kapat == true)
            {
                this.pnlEkIslemler.Size = new System.Drawing.Size(536, 20);
                blnBilgi3Kapat = false;
                if (blnBilgi1Kapat == true && blnBilgi2Kapat == true)// ikisi de acik
                {
                    this.panelControl1.Size = new System.Drawing.Size(536, 220);
                }
                else if (blnBilgi1Kapat == false && blnBilgi2Kapat == false)// ikisi de kapali
                {
                    this.panelControl1.Size = new System.Drawing.Size(536, 65);
                }
                else
                {
                    this.panelControl1.Size = new System.Drawing.Size(536, 140);
                }

            }
            else
            {
                this.pnlEkIslemler.Size = new System.Drawing.Size(536, 100);
                if (blnBilgi1Kapat == true && blnBilgi2Kapat == true)// ikisi de acik
                {
                    this.panelControl1.Size = new System.Drawing.Size(536, 300);
                }

                else if (blnBilgi1Kapat == false && blnBilgi2Kapat == false)// ikisi de kapali
                {
                    this.panelControl1.Size = new System.Drawing.Size(536, 145);
                }
                else
                {
                    this.panelControl1.Size = new System.Drawing.Size(536, 220);

                }
                blnBilgi3Kapat = true;
            }
        }
        private void Arama(object sender, KeyEventArgs e)
        {
            int result1 = 0;
            string arama = "";
            string aranan = "";
            TextEdit tx = (TextEdit)sender;
            int sort = 0;
         

            //this.gridView1.BeginDataUpdate();
            //try
            //{
            //    this.gridView1.ClearSorting();
            //    this.gridView1.Columns["Trademark"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            //    this.gridView1.Columns["Model"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            //}
            //finally
            //{
            //    this.gridView1.EndDataUpdate();
            //}
            if (e.KeyCode == Keys.Enter)
            {
                for (int j = 0; j < intArama - 1; j++)
                {
                    arama = textArama[j].Text;
                    result1 = arama.CompareTo(tx.Text);
                    if (result1 == 0)
                    {
                        sort = j;
                        break;
                    }
                }
            

                for (int i = 0; i < this.gridView1.RowCount; i++)
                {
                    bool focus = true;
                    arama = "";
                    aranan = "";
                    result1 = 0;
                    int[] result = new int[intArama];
                    for (int j = 0; j < intArama - 1; j++)
                    {
                        arama = textArama[j].Text;
                        aranan = this.gridView1.GetRowCellDisplayText(i, this.gridView1.VisibleColumns[j]);
                        result1 = arama.CompareTo(aranan);
                        if (result1 > 0)
                        {
                            focus = false; break;
                        }
                    }
                    if (focus == true)
                    {

                        this.gridView1.FocusedRowHandle = i;
                        this.gridView1.TopRowIndex = i;
                        this.gridControl1.Focus();  
                        break;
                    }
                }
           }
        }
        private void AramaKodIstemi(string kriter, int index)
        {
            if (kriter == "") return;
            if (index == 0)
            {
                if (kriter != "")
                {
                    if (Convert.ToInt32(kriter) == 0) return;
                    AramaKodIstemiId(Convert.ToInt32(kriter), 0);
                    return;
                }
            }
            int result1 = 0;
            string arama = kriter;
            string aranan = "";
            this.gridView1.ClearSorting();
            this.gridView1.Columns["AD"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            for (int i = 0; i < this.gridView1.RowCount; i++)
            {
                bool focus = false;
                result1 = 0;
                aranan = Convert.ToString(this.gridView1.GetRowCellValue(i, this.gridView1.Columns[index]));
                result1 = arama.CompareTo(aranan);
                if (result1 < 0)
                {
                    focus = true;
                }
                if (focus == true)
                {

                    this.gridView1.FocusedRowHandle = i;
                    this.gridView1.TopRowIndex = i;
                    this.gridControl1.Focus();
                    break;
                }
            }
        }
        private void AramaKodIstemiId(int id, int index)
        {
            int arama = id;
            int aranan = 0;
            for (int i = 0; i < this.gridView1.RowCount; i++)
            {
                aranan = Convert.ToInt32(this.gridView1.GetRowCellValue(i, "ID"));
                if (arama == aranan)
                {
                    this.gridView1.FocusedRowHandle = i;
                    this.gridView1.TopRowIndex = i;
                    this.gridControl1.Focus();
                }
            }
        }
        #endregion

    }
}
