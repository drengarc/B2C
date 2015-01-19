using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Prodma.DataAccess;

using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using System.Reflection;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Text.RegularExpressions;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Filter;
using Prodma.Sistem.Models;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using Prodma.Parent;
using Prodma.Sistem.Controllers;
using DevExpress.XtraBars;
using System.Diagnostics;
namespace Prodma.WinForms
{
    /// <summary>
    /// Summary description for MDIChild.
    /// </summary>
    /// 
    public partial class FisSablonSon : Sablon
    {
        #region Deðiþkenler
        public bool gridHelperYenile = false;
        public bool degisikligeBagliSayfaDoldur = false;
        public bool detayliCariListelendi = false;
        public bool sinirsizYetki=false;
        public int eskiRow = 0;
        public DateTime? baslangicFisDoldurrmaTarih = YardimciIslemler.TarihSetBugun();
        public bool kayitSilinmisUyarisi = true;// satýrdan sýfýrlý kayýda donerken uyarý vermesin diye konuldu
        public bool kayitSilinmeUyarisiniGosterme = false;
        public bool helperOlustu = true;
        public bool gridYenileme = false;
        public bool satirOlustu = false;
        public string sifirliTabloAdi;
        public string satirTabloAdi;

        public bool gridView2Erisim;
        public bool gridView2Erisim_1;
        public DevExpress.XtraBars.BarButtonItem[] EkranListeleri = new BarButtonItem[10];
        public DevExpress.XtraBars.BarButtonItem[] EkranListeleriSatir = new BarButtonItem[10];

        public System.Windows.Forms.MenuItem[] contextMenuItems = new System.Windows.Forms.MenuItem[21];
        public System.Windows.Forms.MenuItem[] contextMenuItemsSatir = new System.Windows.Forms.MenuItem[20];

        public usrGridSatirBilgi usrGridBilgi = new usrGridSatirBilgi();
        
        public BindingSource bnSifir = new BindingSource();
        public BindingSource bnSatir = new BindingSource();
        public HelperBase helperBase = new HelperBase();
        public IViewModel sifirBaseVm = new IViewModel();
        #region degiskenler
        public int tabloAlanId=0;
        public string FisDinamikFiltreSql = "";
        public string FisDinamikFiltreCariSql = "";

        bool sablonKapat = true;
        public bool ilkAcilis = true;
        public bool disaridanAc = false;
        public bool formKapat = false; // siparisten rsaliye olusturmada  stok ilisliki kodlara bakmasin diye konuldu.
        bool escape = false;
        public int fiyatId;
        #region showingeditorflags
        int sEditorRowSifirli = 0;
        string sEditorColumnSifirli = "";
        public bool blnGridView1ShowingEditor = true;
        int sEditorRowSatir = 0;
        string sEditorColumnSatir = "";
        public bool blnGridView1ShowingEditor_Satir = true;
        #endregion
        public bool gozlem = false;
        public Dictionary<string,int> AlanAdiIndexi = new Dictionary<string,int>();
        public Dictionary<int, bool> koplalamaDurumu = new Dictionary<int, bool>();
        public bool arakayit = false;
        public int araKayitSatirNo;
        private bool navigatoraBasildi=false;
        TanitimSablon frm;
        public bool fiskodIstedi=false;
        public int fiskodIstenenId = 0;
        public object focusedColumValue = null;
        string sonRow = "";
        object obj;
        public int degisenStokId = 0;
        public bool m_closeForm = true;
        public string kayitEdilemez = "";
        public bool erisim = true;
        public bool acilisTamalandi = false;
        public int currentTabEski = -1;
        public int currentTab=-1;
        public bool tabSelect = false;
        public bool satirYeniKayitAc = false;
        public int sifirliKayitId = 0;
        public int satirKayitId = 0;
        public bool f2InitRow = false;
        public bool f2InitRow_Satir = false;
        #region Devexpress kontrolleri
        int intBind = 0;
        private DevExpress.XtraEditors.TextEdit[] textArama = new DevExpress.XtraEditors.TextEdit[128];
        private DevExpress.XtraEditors.TextEdit[] textArama_Satir = new DevExpress.XtraEditors.TextEdit[128];
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn Column1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit;
        public DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit[] repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit[128];
        public BindingSource[] bindingSourceArr = new BindingSource[128];
        public BindingSource bindingSource1 = new BindingSource();
        #endregion
        bool sonsutunkaydet = false;
        public bool gridView1Erisim=true;
        public bool islemTamamDegilSifirli = false;
        public bool blnbeforeLeaveRow = true;
        public bool blnValidateRow = true;
        public string rowHandleExcepTionMessage = "";
        public bool blnValidatingEditor = true;
        public string errorTextValidatingEditor = "";
        bool sonsutunkaydetsatir = false;
        public bool islemTamamDegilSatir = false;
        public bool blnbeforeLeaveRow_Satir = true;
        public bool blnValidateRow_Satir = true;
        public string rowHandleExcepTionMessage_Satir = "";
        public bool blnValidatingEditor_Satir = true;
        public string errorTextValidatingEditor_Satir = "";
        public bool yeniSatirSifirli = false;
        public bool yeniSatirSatir = true;
        public Object ModelSifirVm;
        public Object ModelSatirVm;
        public FiyatVm fiyatStok;
        #endregion
        #region control degiskenler
        public DevExpress.XtraTab.XtraTabPage tpMesaj;
        private IContainer components;
        public BindingSource bindingSource2;
        public ControlNavigator controlNavigator1;
        public PanelControl panelControl1;
        public PanelControl pnlIslemler;
        private Button BILGI_2cmd;
        public PanelControl pnlEkIslemler;
        private Button BILGI_3cmd;
        public PanelControl pnlArama;
        private Button BILGI1_cmd;
        public DevExpress.XtraTab.XtraTabControl tabControl1;
        public DevExpress.XtraTab.XtraTabPage tbFisGenel;
        public Label lblBilgi;
        public DevExpress.XtraTab.XtraTabPage tbFisSatir;
        public DevExpress.XtraTab.XtraTabPage tbFisEkbilgi;
        public DevExpress.XtraTab.XtraTabPage tbSatirBilgi;
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
        public GridControl  gridControl1;
        public GridView  gridView1;
        public System.Windows.Forms.ContextMenu ContextMenu1;
        public System.Windows.Forms.ContextMenu ContextMenu1Satir;
        public RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private GridView repositoryItemGridLookUpEdit1View;
        public RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit2;
        private GridView repositoryItemGridLookUpEdit2View;
        public Panel panel1;
        public ControlNavigator controlNavigator3;
        public GridControl gridControl2;
        public GridView gridView2;
        public Panel pnlStokBilgileri;
        private DevExpress.Utils.ToolTipController toolTipGridview2;
        public PrintingSystem printingSystem1;
        public PrintableComponentLink printableComponentLink1;
        public PrintingSystem printingSystem2;
        public PrintableComponentLink printableComponentLink2;
        public LabelControl lblMesaj;
        private ImageCollection imageCollection1;
        public Panel panel2;
        public Panel panel3;
        public Panel panel4;
        public Panel panel5;
        public Panel panel6;
        public Panel panel7;
        public Panel panel8;
        public Panel panel9;
        public Panel panel10;
        public Panel panel11;
        public Panel panel12;
        public PanelControl panel2Alt;
        public PanelControl panel3Alt;
        public PanelControl panel4Alt;
        public PanelControl panel5Alt;
        public PanelControl panel6Alt;
        public PanelControl panel7Alt;
        public PanelControl panel8Alt;
        public PanelControl panel9Alt;
        public PanelControl panel10Alt;
        public PanelControl panel11Alt;
        public PanelControl panel12Alt;
        public DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        public DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1dsfsd;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        public DevExpress.XtraBars.PopupMenu popupMenu2;
        public DevExpress.XtraBars.BarManager barManager2;
        public ControlNavigator controlNavigator2;
        #endregion
        #endregion
        #region formolaylar
        public FisSablonSon()
        {
            InitializeComponent();
            this.ContextMenu1 = new System.Windows.Forms.ContextMenu();
            this.ContextMenu1Satir = new System.Windows.Forms.ContextMenu();
            Type hai = this.GetType();
            string name = hai.ToString();
            MenulerVm fVm = new MenulerVm();
            fVm.URL = name;
            MenulerCntrl cntrl = new MenulerCntrl();
            yetki = ListDenemeService.GetYETKI_MENULER(name);
            yetKiAyarla(yetki);
            eventHandler();
            Goruntu_Ayarla();
            this.gridView1.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            //KullaniciYetkileriVm Vm = GenelParametreSng.Nesne().kullaniciYetkileri;
            if (GenelParametreSng.Nesne().kullaniciYetkileri.FIS_GOSTERIM_SINIRLA_E_H == (int)EvetHayirEn.Evet)
            {
                int gun = GenelParametreSng.Nesne().kullaniciYetkileri.FIS_SON_GUN != null ? (int)GenelParametreSng.Nesne().kullaniciYetkileri.FIS_SON_GUN : 1;
                DateTime oldestDate = DateTime.Now.Subtract(new TimeSpan(gun, 0, 0, 0, 0));
                baslangicFisDoldurrmaTarih = oldestDate;
            }
            else
            {
                baslangicFisDoldurrmaTarih =  YardimciIslemler.TarihSet1900();
            }
        }
        void Goruntu_Ayarla()
        {
            //System.Windows.Forms.MenuItem MenuItem1 = new System.Windows.Forms.MenuItem();
            //System.Windows.Forms.MenuItem MenuItem2 = new System.Windows.Forms.MenuItem();
            

            //this.ContextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            //MenuItem1,
            //MenuItem2});
            //// 
            //// MenuItem1
            //// 
            //MenuItem1.Index = 0;
            //MenuItem1.Text = "Edit";
            ////this.MenuItem1.Click += new System.EventHandler(this.MenuItem1_Click);
            //// 
            //// MenuItem2
            //// 
            //MenuItem2.Index = 1;
            //MenuItem2.Text = "Delete";
            //this.MenuItem2.Click += new System.EventHandler(this.MenuItem2_Click);

            this.panelControl1.Visible = false;
            foreach (DevExpress.XtraTab.XtraTabPage item in tabControl1.TabPages)
            {
                item.Appearance.Header.Font = new Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                item.Appearance.Header.Options.UseFont = true;
            }
            EkranListeleri[0] = new BarButtonItem(barManager1, "Ekran Yazdýr");
            EkranListeleri[0].Name = "EkranList";
            this.popupMenu1.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(EkranListeleri[0]));

            EkranListeleriSatir[0] = new BarButtonItem(barManager2, "Ekran Yazdýr");
            EkranListeleriSatir[0].Name = "EkranList";
            this.popupMenu2.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(EkranListeleriSatir[0]));
            EkranListeleriSatir[1] = new BarButtonItem(barManager2, "Excell");
            EkranListeleriSatir[1].Name = "Excell";
            this.popupMenu2.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(EkranListeleriSatir[1]));
            EkranListeleriSatir[2] = new BarButtonItem(barManager2, "Pdf");
            EkranListeleriSatir[2].Name = "Pdf";
            this.popupMenu2.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(EkranListeleriSatir[2]));
        }
        public void FisSablon_Load(object sender, EventArgs e)
        {
            this.gridView1.GroupPanelText = "Gruplamak Ýstediðiniz Alaný Bu Bölgeye Sürükleyiniz";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            currentTab = 0;
            this.Size = new Size(2500, 900);
            sonRow = sonRowBul(gridView1);
            //Type hai = this.GetType();
            //string name = hai.ToString();
            //MenulerVm fVm = new MenulerVm();
            //fVm.URL = name;
            //MenulerCntrl cntrl = new MenulerCntrl();
            //yetki = ListDenemeService.GetYETKI_MENULER(name);
            FisDinamikFiltreCariSql = "";
            if (Globals.cariErisilebilenSql != "" && Globals.cariErisilebilenSql != null)
            {
                FisDinamikFiltreCariSql = Globals.cariErisilebilenSql;// "(CARI_TIP_ID==2) && (CARI_PLASIYER_ID!=118)"; //s;
            }
            string s = OrtakIslemlerService.Filtreolustur(tabloAlanId, "",false);
            if (s.Trim() != "")
            {
               // FisDinamikFiltreCariSql = FisDinamikFiltreCariSql + " AND ( " + s + " )";// "(CARI_TIP_ID==2) && (CARI_PLASIYER_ID!=118)"; //s;
                FisDinamikFiltreSql = s;
            }
            ContextMenuolustur();
         //   this.gridView1.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            this.gridView1.OptionsFind.AllowFindPanel = false;
        }
        private void FisSablon_Shown(object sender, EventArgs e)//YETKÝLER BELIRLENIYOR
        {
            //ActiveControl = (Control)this.gridControl1;
            //yetKiAyarla(yetki);
            //acilisTamalandi = true;
            //Globals.mFormAc = false;
            //ColumnGenislikAyarla(gridView1);
            ////Globals.fisSongun = 3000;
            //this.controlNavigator1.CustomButtons[0].Tag = "Yazdir";
            //this.controlNavigator1.CustomButtons[0].Hint = "YAZDIR";
            //this.controlNavigator1.CustomButtons[0].ImageIndex = 10;
            //this.controlNavigator2.CustomButtons[0].Tag = "Yazdir";
            //this.controlNavigator2.CustomButtons[0].Hint = "YAZDIR";
            //this.controlNavigator2.CustomButtons[0].ImageIndex = 10;
         
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
                    if (btn.Tag.ToString()=="Yazdir")
                    {
                        MenuItem mn11 = new MenuItem();
                        for (int i = 0; i < EkranListeleri.Length; i++)
                        {
                            if (EkranListeleri[i]!=null && EkranListeleri[i].Name != "")
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
            index = 0;
            foreach (var buttons in controlNavigator2.Buttons.CustomButtons)
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)buttons;
                if (btn.Tag != null)
                {
                    contextMenuItemsSatir[index] = new MenuItem();
                    contextMenuItemsSatir[index].Text = btn.Hint;
                    contextMenuItemsSatir[index].Tag = btn.Tag;
                    ContextMenu1Satir.MenuItems.Add(contextMenuItemsSatir[index]);
                    if (btn.Tag.ToString() == "Yazdir")
                    {
                        MenuItem mn11 = new MenuItem();
                        for (int i = 0; i < EkranListeleriSatir.Length; i++)
                        {
                            if (EkranListeleriSatir[i] != null && EkranListeleriSatir[i].Name != "")
                            {
                                mn11 = new MenuItem();
                                mn11.Text = EkranListeleriSatir[i].Caption;
                                mn11.Tag = EkranListeleriSatir[i].Name;
                                contextMenuItemsSatir[index].MenuItems.Add(mn11);
                                mn11.Click += new System.EventHandler(this.MenuItemDetay2_Click);
                            }
                        }
                    }
                    contextMenuItemsSatir[index].Click += new System.EventHandler(this.MenuItem2_Click);
                    index++;
                }

            }
        }
        private void MenuItemDetay1_Click(object sender, System.EventArgs e)
        {
            YardimciIslemlerKontrols.ProgramBeklemeGoster();
            MenuItem mn = (MenuItem)sender;
            YazdirmaIslemleri(mn.Tag.ToString(),gridControl1,printableComponentLink1);
            Bar_Manager_Islemleri(mn.Tag.ToString());
            YardimciIslemlerKontrols.ProgramBeklemeDurdur();
            gridHelperYenile = true;
        }
        private void MenuItemDetay2_Click(object sender, System.EventArgs e)
        {
            YardimciIslemlerKontrols.ProgramBeklemeGoster();
            MenuItem mn = (MenuItem)sender;
            YazdirmaIslemleri(mn.Tag.ToString(),gridControl2,printableComponentLink2);
            Bar_Manager_Islemleri_Satir(mn.Tag.ToString());
            YardimciIslemlerKontrols.ProgramBeklemeDurdur();
            gridHelperYenile = true;
        }
        private void barManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YardimciIslemlerKontrols.ProgramBeklemeGoster();
            BarSubItem subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            YazdirmaIslemleri(e.Item.Name,gridControl1,printableComponentLink1);
            Bar_Manager_Islemleri(e.Item.Name);
            YardimciIslemlerKontrols.ProgramBeklemeDurdur();
            gridHelperYenile = true;
        }
        private void barManager2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YardimciIslemlerKontrols.ProgramBeklemeGoster();
            BarSubItem subMenu = e.Item as BarSubItem;
            if (subMenu != null) return;
            YazdirmaIslemleri(e.Item.Name,gridControl2,printableComponentLink2);
            Bar_Manager_Islemleri_Satir(e.Item.Name);
            YardimciIslemlerKontrols.ProgramBeklemeDurdur();
            gridHelperYenile = true;
        }
        void YazdirmaIslemleri(string islem, GridControl gridControl,PrintableComponentLink pLink)
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
                //gridControl.ExportToXlsx(filepath,options);
                gridControl.ExportToXlsx(filepath);
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
            gridHelperYenile = true;
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
            gridHelperYenile = true;
        }
        private void MenuItem2_Click(object sender, System.EventArgs e)
        {
            YardimciIslemlerKontrols.ProgramBeklemeGoster();
            MenuItem mn = (MenuItem)sender;
            NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator2.Buttons.CustomButtons[0]);
            args.Button.Tag = mn.Tag;
            args.Button.Hint = mn.Text;
            controlNavigator2_ButtonClick(controlNavigator2, args);
            //this.usrcontrolNavigator_ButtonClick(sender, e);
            YardimciIslemlerKontrols.ProgramBeklemeDurdur();
            gridHelperYenile = true;

        }
        public override void Form_Acilis(object sender, EventArgs e)
        {
            ActiveControl = (Control)this.gridControl1;
            //yetKiAyarla(yetki);
            acilisTamalandi = true;
            Globals.mFormAc = false;
            ColumnGenislikAyarla(gridView1);
            //Globals.fisSongun = 3000;
            this.controlNavigator1.CustomButtons[0].Tag = "Yazdir";
            this.controlNavigator1.CustomButtons[0].Hint = "YAZDIR";
            this.controlNavigator1.CustomButtons[0].ImageIndex = 10;
            this.controlNavigator2.CustomButtons[0].Tag = "Yazdir";
            this.controlNavigator2.CustomButtons[0].Hint = "YAZDIR";
            this.controlNavigator2.CustomButtons[0].ImageIndex = 10;

   
        }
        public void yetKiAyarla(YetkiMenulerVm yetki)
        {
            if (yetki != null)
            {
                if (yetki.GORMESIN_E_H == true || yetki.OKU_E_H == false)
                {
                    this.gridControl1.DataSource = null;
                    this.gridControl2.DataSource = null;
                    //this.gridView1.OptionsBehavior.Editable = false;
                    gridView1Erisim = false;
                    gridView2Erisim = false;
                    gridView2Erisim_1 = false;
                    //this.gridView2.OptionsBehavior.Editable = false;
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
                    //tamYetki = true;
                }
            }
            else
            {
                tamYetki = true;
            }
        }
        private void FisSablonSon_Activated(object sender, EventArgs e)
        {
            Globals.mFormAc = false;
            int rowEski =0;
            int fRow = 0;
            Globals.gnActiveForm = this.Text;
            if (gridView1.FocusedRowHandle < 0)// yeni kayýt acýldýgýnda tekrar yuklemede hangi kayýtta olduguna bakalim.
            {
                rowEski = gridView1.RowCount-2;
                fRow = gridView1.RowCount -2;
            }
            else
            {
                rowEski = gridView1.FocusedRowHandle;
                fRow = gridView1.FocusedRowHandle;
            }
           ilkAcilis = true;
           // tabControl1.SelectedTabPage = tbFisGenel;
            if (ilkAcilis == false && fiskodIstedi == false) // fis kod istedi ise buraya girmemeli
            {
                //Ekran_Yenile();
                FocusedRowChangedEventArgs a = new FocusedRowChangedEventArgs(fRow, fRow);
                gridView1_FocusedRowChanged(gridView1, a);
                satirYeniKayitAc = false;// satýr kayýdýnda  yeni ekran acýp f2 ye basip oka basarsam, satir_Doldur da addnewrow yapiyordu, addnewrow gereksiz olabilir , kaldirdim.
                if (tabControl1.SelectedTabPageIndex == 0)
                {
                    gridView1.FocusedRowHandle = gridView1.FocusedRowHandle;
                    gridView1.TopRowIndex = gridView1.FocusedRowHandle;
                }
                else if (tabControl1.SelectedTabPageIndex == 1)
                {
                    gridView1.FocusedRowHandle = rowEski;
                    fRow = gridView2.FocusedRowHandle;
                    FocusedRowChangedEventArgs a1 = new FocusedRowChangedEventArgs(fRow, fRow);
                    gridView2_FocusedRowChanged(gridView2, a1);
                    gridView2.TopRowIndex = gridView2.FocusedRowHandle;
                }
                else
                {
                    tabControl1.SelectedTabPage = tbFisGenel;
                    gridView1.FocusedRowHandle = gridView1.FocusedRowHandle;
                    gridView1.TopRowIndex = gridView1.FocusedRowHandle;
                }
            }
            else
            {
               // gridView1.ActiveEditor.IsModified = true;
              //  gridView2.ActiveEditor.IsModified = true;
            }
            ilkAcilis = false;
            fiskodIstedi = false;
            if (tabControl1.SelectedTabPageIndex == 0)
            {
                this.ActiveControl = this.gridControl1;
            }
            else if (tabControl1.SelectedTabPageIndex == 1)
            {
                this.ActiveControl = this.gridControl2;
            }
        }
        private void FisSablon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                
                if ((tabControl1.SelectedTabPage == tbFisGenel && gridView1.FocusedRowHandle >= 0) || gridView1.RowCount==1) 
                {
                    if (Convert.ToInt32(this.gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID")) == 0)
                    {
                        //return;
                        this.Close(); // recete fis sifirli bostu kapatamiyordu o yuzden koydum. returnu kaldirdim.
                    }
                    if (this.gridView1.IsDefaultState == true)
                    {
                        this.Close();
                    }
                }
                else if ((tabControl1.SelectedTabPage == tbFisSatir && gridView2.FocusedRowHandle>=0) || gridView2.RowCount==1)
                {
                    if (this.gridView2.IsDefaultState == true)
                    {
                        tabControl1.SelectedTabPage = tbFisGenel;
                    }
                }
                else if (tabControl1.SelectedTabPage != tbFisGenel && gridView2.FocusedRowHandle>=0)
                {
                    tabControl1.SelectedTabPageIndex = currentTabEski;
                }
            }
            else
            {
               Fis_KeyDown(e);
            }
        }
        private void MouseSpin(object sender, SpinEventArgs e)
        {
            //e.IsSpinUp = false;
            e.Handled = true;
        }
        public string Gridi_Olustur(string tabloAdi, GridView grd)//GRÝD ve ARAMALAR AYARLANIYOR
        {
            string alanadi = "";
            //try
            //{
                int ust_id = 0;
                var q = ListDenemeService.GetALANLAR(tabloAdi, 1);
                if (grd.Name == "gridView1")
                {
                    tabloAlanId = (int)q[0].M_ALANLAR_ID;
                    sifirliTabloAdi = tabloAdi;
                }
                else
                {
                    satirTabloAdi = tabloAdi;
                }
                foreach (var ALAN in q)
                {
                    Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
                    FieldInfo fi = typeof(GridColumn).GetField("minWidth", BindingFlags.NonPublic | BindingFlags.Instance);
                    fi.SetValue(Column1, 0);
                    Column1.Name = Column1.FieldName = alanadi = ALAN.ALAN_AD;
                    Column1.Caption = Globals.rman.GetString(ALAN.ALAN_LISTE_AD);
                    Column1.Width = (int)ALAN.ALAN_LISTE_GENISLIK;
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
                    AlanAdiIndexi[grd.Name + ALAN.ALAN_AD] = intBind;
                    if (ALAN.M_ALAN_KOPYALAMA_E_H == (int)EvetHayirEn.Hayir)
                    {
                        koplalamaDurumu[intBind] = false;
                    }
                    if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.TEXTBOX)  // TEXT
                    {
                        repositoryItemTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                        if (ALAN.KIRLIM_TIP_ID != null && ALAN.KIRLIM_TIP_ID != 0)
                        {
                            string kirilim = YardimciIslemler.KirilimUygula(ALAN.KIRLIM_TIP_ID);
                            repositoryItemTextEdit.Mask.EditMask = kirilim;
                            repositoryItemTextEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                            repositoryItemTextEdit.Mask.UseMaskAsDisplayFormat = true;
                        }
                        this.gridControl1.RepositoryItems.Add(repositoryItemTextEdit);
                        repositoryItemTextEdit.AutoHeight = false;
                        repositoryItemTextEdit.MaxLength = Convert.ToInt16(ALAN.ALAN_UZUNLUK);
                        repositoryItemTextEdit.Name = ALAN.ALAN_AD;
                        Column1.ColumnEdit = repositoryItemTextEdit;
                        this.repositoryItemTextEdit.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.MouseSpin);
                    }
                    else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.COMBOBOX)
                    {
                        bindingSourceArr[intBind] = new System.Windows.Forms.BindingSource();
                        this.gridControl1.RepositoryItems.Add(repositoryItemLookUpEdit1[intBind]);
                        repositoryItemLookUpEdit1[intBind] = new RepositoryItemGridLookUpEdit();
                        //DevExpress.XtraEditors.Repository.ExportMode.DisplayText
                        repositoryItemLookUpEdit1[intBind].ExportMode = ExportMode.DisplayText;
                        string mt = "";
                        mt = "Get" + ALAN.ALAN_AD;
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
                        //this.repositoryItemLookUpEdit1[intBind].View.OptionsFilter.
                        //this.repositoryItemLookUpEdit1[intBind].View.OptionsFilter = AutoFilterCondition.Contains;
                        this.repositoryItemLookUpEdit1[intBind].PopupFilterMode = PopupFilterMode.Contains;
                        Column1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
                        //this.repositoryItemLookUpEdit1[intBind].o = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.Space);
                        this.repositoryItemLookUpEdit1[intBind].PopupFormSize = new Size(500, 500);
                        this.repositoryItemLookUpEdit1[intBind].View.Appearance.FocusedRow.ForeColor = Color.Red;
                        this.repositoryItemLookUpEdit1[intBind].PopupBorderStyle = PopupBorderStyles.Style3D;
                        this.repositoryItemLookUpEdit1[intBind].AppearanceFocused.BackColor = Color.Red;

                        this.repositoryItemLookUpEdit1[intBind].NullText = "";
                        this.repositoryItemLookUpEdit1[intBind].DataSource = bindingSourceArr[intBind];
                        this.repositoryItemLookUpEdit1[intBind].DisplayMember = "AD";
                        this.repositoryItemLookUpEdit1[intBind].Name = ALAN.ALAN_AD;
                        this.repositoryItemLookUpEdit1[intBind].ValueMember = "ID";
                        this.repositoryItemLookUpEdit1[intBind].CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.Space);
                        repositoryItemLookUpEdit1[intBind].View.PopulateColumns(repositoryItemLookUpEdit1[intBind].DataSource);
                        if (ALAN.ALAN_AD == "CARI_ID" || ALAN.ALAN_AD == "STOK_ID") //M_ALANLAR tablosuna arama tipi konulacak
                        {
                            this.repositoryItemLookUpEdit1[intBind].KeyDown += new System.Windows.Forms.KeyEventHandler(this.repositoryItemLookUpEdit1_KeyDown);
                            this.repositoryItemLookUpEdit1[intBind].ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.repositoryItemGridLookUpEdit1_ProcessNewValue);
                            this.repositoryItemLookUpEdit1[intBind].EditValueChanged += new System.EventHandler(this.lke_EditValueChanged);
                            this.repositoryItemLookUpEdit1[intBind].PopupFormSize = new Size(1000, 500);

                        }
                        if (bindingSourceArr[intBind].DataSource != null)
                        {
                            this.repositoryItemLookUpEdit1[intBind].View.Columns[0].Visible = false;
                            if (repositoryItemLookUpEdit1[intBind].View.Columns.Count > 2)
                            {
                                repositoryItemLookUpEdit1[intBind].View.Columns["CARIVM"].Visible = false;
                            }
                        }
                      
                        this.Column1.ColumnEdit = repositoryItemLookUpEdit1[intBind];
                        
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
                        repositoryItemLookUpEdit1[intBind].View.PopulateColumns(repositoryItemLookUpEdit1[intBind].DataSource);
                        if (bindingSourceArr[intBind].DataSource != null)
                        {
                            this.repositoryItemLookUpEdit1[intBind].View.Columns[0].Visible = false;
                            if (repositoryItemLookUpEdit1[intBind].View.Columns.Count > 2)
                            {
                                repositoryItemLookUpEdit1[intBind].View.Columns["CARIVM"].Visible = false;
                            }
                        }
                        this.Column1.ColumnEdit = repositoryItemLookUpEdit1[intBind];
                    }
                    else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.TARIH)//TARIH
                    {
                        DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
                        repositoryItemDateEdit.AutoHeight = false;
                        repositoryItemDateEdit.Name = ALAN.ALAN_AD;
                        repositoryItemDateEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
                        //this.repositoryItemDateEdit.VistaTimeProperties.NullText =Now.to
                        repositoryItemDateEdit.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                    new DevExpress.XtraEditors.Controls.EditorButton()});
                        this.gridControl1.RepositoryItems.Add(repositoryItemDateEdit);
                        Column1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List;
                        Column1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
                        Column1.ColumnEdit = repositoryItemDateEdit;
                    }
                    else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.DECIMAL)//DECIMAL
                    {
                        if (ALAN.M_ALAN_ALT_BILGI == 1)
                        {
                            String format = "n" +  Convert.ToInt32(ALAN.ALAN_DECIMAL);
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
                        repositoryItemTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                        String a = new String('#', Convert.ToInt32(ALAN.ALAN_DECIMAL));
                        String b = new String('#', Convert.ToInt32(ALAN.ALAN_UZUNLUK));
                        /////////////this.repositoryItemTextEdit.Mask.EditMask = b + "." + a;
                        if (a == "##")
                        {
                            this.repositoryItemTextEdit.Mask.EditMask = "###,###,###,##0.00";
                        }
                        else
                        {
                            this.repositoryItemTextEdit.Mask.EditMask = "###,###,##0.00000";
                        }
                        this.repositoryItemTextEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        this.repositoryItemTextEdit.Mask.UseMaskAsDisplayFormat = true;
                        this.repositoryItemTextEdit.Name = ALAN.ALAN_AD;
                        this.gridControl1.RepositoryItems.Add(repositoryItemTextEdit);
                        this.repositoryItemTextEdit.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.MouseSpin);
                        Column1.ColumnEdit = repositoryItemTextEdit;
                    }

                    else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.TAMSAYI)//TAMSAYI
                    {
                        if (ALAN.M_ALAN_ALT_BILGI == 1)
                        {
                            Column1.SummaryItem.FieldName = ALAN.ALAN_AD;
                            Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        }
                        repositoryItemTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                        this.gridControl1.RepositoryItems.Add(repositoryItemTextEdit);
                        repositoryItemTextEdit.AutoHeight = false;
                        repositoryItemTextEdit.MaxLength = Convert.ToInt16(ALAN.ALAN_UZUNLUK);
                        repositoryItemTextEdit.Name = ALAN.ALAN_AD;
                        this.repositoryItemTextEdit.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.MouseSpin);
                        Column1.ColumnEdit = repositoryItemTextEdit;
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
                        repositoryItemLookUpEdit.ExportMode = ExportMode.DisplayText;
                        string mt = "";
                        mt = "Get" + ALAN.ALAN_AD;
                        bindingSourceArr[intBind].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.AKTIF, 0, ALAN.ID, ust_id, "", "", 0);
                        repositoryItemLookUpEdit.NullText = "";
                        repositoryItemLookUpEdit.DataSource = bindingSourceArr[intBind];
                        repositoryItemLookUpEdit.DisplayMember = "AD";
                        repositoryItemLookUpEdit.Name = ALAN.ALAN_AD;
                        repositoryItemLookUpEdit.ValueMember = "ID";
                        repositoryItemLookUpEdit1[intBind].View.PopulateColumns(repositoryItemLookUpEdit1[intBind].DataSource);
                        if (bindingSourceArr[intBind].DataSource != null)
                        {
                            this.repositoryItemLookUpEdit1[intBind].View.Columns[0].Visible = false;
                        }
                        repositoryItemLookUpEdit.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.Space);
                        this.Column1.ColumnEdit = repositoryItemLookUpEdit;
                        
                    }
                    intBind += 1;
                    grd.Columns.Add(Column1);
                }

            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("alan tanýmlamasýnda sorun  " + alanadi);
            //}
            return Globals.rman.GetString(tabloAdi);
        }
        public void Gridi_OlusturSatir()//GRÝD ve ARAMALAR AYARLANIYOR
        {
            if (bindingSourceArr == null) { satirOlustu = true; return; }
            GridView grd = gridView2;          
            string alanadi = "";
            int intArama = 0;
            //try
            //{
                int ust_id = 0;
                var q = ListDenemeService.GetALANLAR(satirTabloAdi, 1);
                foreach (var ALAN in q)
                {
                    Column1 = new DevExpress.XtraGrid.Columns.GridColumn();
                    FieldInfo fi = typeof(GridColumn).GetField("minWidth", BindingFlags.NonPublic | BindingFlags.Instance);
                    fi.SetValue(Column1, 0);
                    Column1.Name = Column1.FieldName = alanadi = ALAN.ALAN_AD;
                    Column1.Caption = Globals.rman.GetString(ALAN.ALAN_LISTE_AD);
                    Column1.Width = (int)ALAN.ALAN_LISTE_GENISLIK;
                    Column1.VisibleIndex = (int)ALAN.ALAN_SIRA;
                    if (ALAN.M_ALAN_CLASS_NAME != null) { Column1.Tag = Convert.ToString(ALAN.M_ALAN_CLASS_NAME) + "/" + Convert.ToString(ALAN.ID); }
                    if ((ALAN.GORMESIN_E_H == true && ALAN.M_ALANLAR_ALT_ID == null) || ALAN.M_ALAN_TIP_2 == 2)
                    {
                        Column1.Visible = false;
                    }
                    if (ALAN.YAZMASIN_E_H == true && ALAN.M_ALANLAR_ALT_ID == null)
                    {
                        Column1.OptionsColumn.ReadOnly = true;
                    }
                    AlanAdiIndexi[grd.Name + ALAN.ALAN_AD] = intBind;
                    if (ALAN.M_ALAN_KOPYALAMA_E_H == (int)EvetHayirEn.Hayir)
                    {
                        koplalamaDurumu[intBind] = false;
                    }
                    if (ALAN.M_ALAN_KOPYALAMA_E_H == (int)EvetHayirEn.Hayir)
                    {
                        koplalamaDurumu[intBind] = false;
                    }
                    if ((int)ALAN.ALAN_LISTE_GENISLIK > 50 || ALAN.ALAN_AD == "CARI_ID" || ALAN.ALAN_AD == "STOK_ID") //M_ALANLAR tablosuna arama tipi konulacak
                    {
                        //Column1.Width = 60;
                    }
                    if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.TEXTBOX)  // TEXT
                    {
                        repositoryItemTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                        this.gridControl2.RepositoryItems.Add(repositoryItemTextEdit);
                        repositoryItemTextEdit.AutoHeight = false;
                        repositoryItemTextEdit.MaxLength = Convert.ToInt16(ALAN.ALAN_UZUNLUK);
                        repositoryItemTextEdit.Name = ALAN.ALAN_AD;
                        Column1.ColumnEdit = repositoryItemTextEdit;
                        this.repositoryItemTextEdit.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.MouseSpin);
                    }
                    else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.COMBOBOX)
                    {
                        bindingSourceArr[intBind] = new System.Windows.Forms.BindingSource();
                        this.gridControl2.RepositoryItems.Add(repositoryItemLookUpEdit1[intBind]);
                        repositoryItemLookUpEdit1[intBind] = new RepositoryItemGridLookUpEdit();
                        repositoryItemLookUpEdit1[intBind].ExportMode = ExportMode.DisplayText;
                        string mt = "";
                        mt = "Get" + ALAN.ALAN_AD;
                        bindingSourceArr[intBind].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.AKTIF, 0, ALAN.ID, ust_id, "", "", 0);
                        AlanAdiIndexi[grd.Name + ALAN.ALAN_AD] = intBind;
                        this.repositoryItemLookUpEdit1[intBind].NullText = "";
                        this.repositoryItemLookUpEdit1[intBind].DataSource = bindingSourceArr[intBind];
                        this.repositoryItemLookUpEdit1[intBind].DisplayMember = "AD";
                        this.repositoryItemLookUpEdit1[intBind].Name = ALAN.ALAN_AD;
                        this.repositoryItemLookUpEdit1[intBind].ValueMember = "ID";
                        this.repositoryItemLookUpEdit1[intBind].CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.Space);
                        repositoryItemLookUpEdit1[intBind].View.PopulateColumns(repositoryItemLookUpEdit1[intBind].DataSource);
                        if (bindingSourceArr[intBind].DataSource != null)
                        {
                            if (this.repositoryItemLookUpEdit1[intBind].View.Columns.Count > 2)
                            {
                                this.repositoryItemLookUpEdit1[intBind].View.Columns["CARIVM"].Visible = false;
                            }
                        }
                       
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
                        this.repositoryItemLookUpEdit1[intBind].PopupFormSize = new Size(300, 500);
                        this.repositoryItemLookUpEdit1[intBind].View.Appearance.FocusedRow.ForeColor = Color.Red;
                        this.repositoryItemLookUpEdit1[intBind].PopupFilterMode = PopupFilterMode.Contains;
                        //Column1.OptionsFilter.FilterPopupMode = FilterPopupMode.
                        repositoryItemLookUpEdit1[intBind].View.PopulateColumns(repositoryItemLookUpEdit1[intBind].DataSource);
                        Column1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
                        if ((int)ALAN.ALAN_LISTE_GENISLIK > 50 || ALAN.ALAN_AD == "CARI_ID" || ALAN.ALAN_AD == "STOK_ID") //M_ALANLAR tablosuna arama tipi konulacak
                        {
                            this.repositoryItemLookUpEdit1[intBind].KeyDown += new System.Windows.Forms.KeyEventHandler(this.repositoryItemLookUpEdit1_KeyDown);
                           this.repositoryItemLookUpEdit1[intBind].ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(this.repositoryItemGridLookUpEdit1_ProcessNewValue);
                            this.repositoryItemLookUpEdit1[intBind].EditValueChanged += new System.EventHandler(this.lke_EditValueChanged);
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
                        this.gridControl2.RepositoryItems.Add(repositoryItemLookUpEdit1[intBind]);
                        repositoryItemLookUpEdit1[intBind] = new RepositoryItemGridLookUpEdit();
                        repositoryItemLookUpEdit1[intBind].ExportMode = ExportMode.DisplayText;
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
                        DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
                        repositoryItemDateEdit.AutoHeight = false;
                        repositoryItemDateEdit.Name = ALAN.ALAN_AD;
                        repositoryItemDateEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
                        //this.repositoryItemDateEdit.VistaTimeProperties.NullText =Now.to
                        repositoryItemDateEdit.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                    new DevExpress.XtraEditors.Controls.EditorButton()});
                        this.gridControl1.RepositoryItems.Add(repositoryItemDateEdit);
                        Column1.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List;
                        Column1.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.Value;
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
                        repositoryItemTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                        String a = new String('#', Convert.ToInt32(ALAN.ALAN_DECIMAL));
                        String b = new String('#', Convert.ToInt32(ALAN.ALAN_UZUNLUK));
                        /////////////this.repositoryItemTextEdit.Mask.EditMask = b + "." + a;
                        if (a == "##")
                        {
                            this.repositoryItemTextEdit.Mask.EditMask = "###,###,###,##0.00";
                        }
                        else
                        {
                            this.repositoryItemTextEdit.Mask.EditMask = "###,###,##0.00000";
                        }
                        this.repositoryItemTextEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        this.repositoryItemTextEdit.Mask.UseMaskAsDisplayFormat = true;
                        this.repositoryItemTextEdit.Name = ALAN.ALAN_AD;
                        this.gridControl2.RepositoryItems.Add(repositoryItemTextEdit);
                        this.repositoryItemTextEdit.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.MouseSpin);
                        Column1.ColumnEdit = repositoryItemTextEdit;
                    }

                    else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.TAMSAYI)//TAMSAYI
                    {
                        if (ALAN.M_ALAN_ALT_BILGI == 1)
                        {
                            Column1.SummaryItem.FieldName = ALAN.ALAN_AD;
                            Column1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        }
                        repositoryItemTextEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                        this.gridControl2.RepositoryItems.Add(repositoryItemTextEdit);
                        repositoryItemTextEdit.AutoHeight = false;
                        repositoryItemTextEdit.MaxLength = Convert.ToInt16(ALAN.ALAN_UZUNLUK);
                        repositoryItemTextEdit.Name = ALAN.ALAN_AD;
                        this.repositoryItemTextEdit.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.MouseSpin);
                        Column1.ColumnEdit = repositoryItemTextEdit;
                    }
                    else if (ALAN.M_ALAN_TIP_ID == (int)AlanTipEn.CHECKBOX)//checkbox
                    {
                        repositoryItemCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
                        this.repositoryItemCheckEdit.AutoHeight = false;
                        this.repositoryItemCheckEdit.Name = ALAN.ALAN_AD;
                        this.gridControl2.RepositoryItems.Add(repositoryItemCheckEdit);
                        Column1.ColumnEdit = repositoryItemCheckEdit;
                    }
                    else if (ALAN.M_ALAN_TIP_ID == 7) // baglý Alan
                    {
                        bindingSourceArr[intBind] = new System.Windows.Forms.BindingSource();
                        this.gridControl2.RepositoryItems.Add(repositoryItemLookUpEdit1[intBind]);
                        repositoryItemLookUpEdit = new RepositoryItemLookUpEdit();
                        string mt = "";
                        mt = "Get" + ALAN.ALAN_AD;
                        bindingSourceArr[intBind].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.AKTIF, 0, ALAN.ID, ust_id, "", "", 0);
                        repositoryItemLookUpEdit.NullText = "";
                        repositoryItemLookUpEdit.DataSource = bindingSourceArr[intBind];
                        repositoryItemLookUpEdit.DisplayMember = "AD";
                        repositoryItemLookUpEdit.Name = ALAN.ALAN_AD;
                        repositoryItemLookUpEdit.ValueMember = "ID";
                        repositoryItemLookUpEdit1[intBind].View.PopulateColumns(repositoryItemLookUpEdit1[intBind].DataSource);
                        if (bindingSourceArr[intBind].DataSource != null)
                        {
                            this.repositoryItemLookUpEdit1[intBind].View.Columns[0].Visible = false;
                        }
                        repositoryItemLookUpEdit.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.Space);
                        this.Column1.ColumnEdit = repositoryItemLookUpEdit;

                    }
                    intBind += 1;
                    grd.Columns.Add(Column1);
                }

                AltToplamYazSatir();
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("alan tanýmlamasýnda sorun  " + alanadi);
            //}
            satirOlustu = true;
      //      return Globals.rman.GetString(tabloAdi);
            this.gridView2.OptionsFind.AllowFindPanel = false;
        }
        private void repositoryItemLookUpEdit1_KeyDown(object sender, KeyEventArgs e)// gridlookupeditlerde lookuoeditin icerigini degisimek icin kullanýlabilir.
        {
            //DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit ed = (DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit)sender;
            //if (e.KeyCode == ' ' && !ed.IsPopupOpen) e.Handled = true;
            //ed.ShowPopup();

            if (e.KeyCode == Keys.F4)
            {
                DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs arg = new DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs(obj);
                repositoryItemGridLookUpEdit1_ProcessNewValue(this.gridView2, arg);
            }
            else if (e.KeyCode == Keys.F6)
            {
             //   this.repositoryItemLookUpEdit1[4].DataSource = bindingSourceArr[4];
             //   this.repositoryItemLookUpEdit1[4].DisplayMember = "KOD";
             //   this.gridView1.RefreshData();
            }
            else if (e.KeyCode == Keys.F7)
            {
             //   this.repositoryItemLookUpEdit1[4].DataSource = bindingSourceArr[4];
             //   this.repositoryItemLookUpEdit1[4].DisplayMember = "AD";
             //   this.gridView1.RefreshData();
            }
            else if (e.KeyCode == Keys.O)
            {
                // string s = this.gridView2.GetRowCellDisplayText(this.gridView2.FocusedRowHandle, this.gridView2.VisibleColumns[0]);
                //   s = this.repositoryItemLookUpEdit1[12];
            }
            else if (e.KeyCode == Keys.Space)
            {
                //e.Handled = true;
            }
        }
        private void lke_EditValueChanged(object sender, EventArgs e)
        {
            if (this.gridView2.FocusedColumn!=null && this.gridView2.FocusedColumn.FieldName == "STOK_ID")
            {
                GridLookUpEdit gle =  (GridLookUpEdit) sender;
                degisenStokId  = Convert.ToInt32(gle.EditValue);
            }
        }
        private void repositoryItemGridLookUpEdit1_ProcessNewValue(object sender, ProcessNewValueEventArgs e)//gridlookueditlerde icinde valuesu olmayan bir degerin alinip ona gore islem yapilabilmesi icin kullanýlýyor
        {
            //GridView view = (GridView)sender;
            if (e.DisplayValue.ToString().Trim()=="")
            {
                return;
            }
            if (tabControl1.SelectedTabPage == tbFisGenel)
            {
                if (this.gridView1.FocusedColumn == null) return;
                if (this.gridView1.FocusedColumn.FieldName == "STOK_ID" || this.gridView1.FocusedColumn.FieldName == "CARI_ID")
                {
                    obj = e.DisplayValue;
                    if (e.DisplayValue != null) ProcessNewValue(this.gridView1, e.DisplayValue.ToString());
                }
            }
            else
            {
                if (this.gridView2.FocusedColumn == null) return;
                    obj = e.DisplayValue;
                    if (e.DisplayValue != null) ProcessNewValue(this.gridView2, e.DisplayValue.ToString());
            }
        }
        private void eventHandler()
        {
            barManager1.ItemClick += new ItemClickEventHandler(barManager_ItemClick);
            barManager2.ItemClick += new ItemClickEventHandler(barManager2_ItemClick);
            this.Load += new System.EventHandler(this.FisSablon_Load);
            this.Shown += new System.EventHandler(this.FisSablon_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FisSablonSon_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FisSablon_KeyDown);
            this.Activated += new System.EventHandler(this.FisSablonSon_Activated);
            this.controlNavigator1.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.controlNavigator1_ButtonClick);
            this.gridControl1.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl1_ProcessGridKey);
            //this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridView1_CustomDrawCell);
            this.gridView1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView1_ShowingEditor);
            this.gridView1.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(this.gridView1_ShowGridMenu);
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
             this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.gridView1.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.gridView1_FocusedColumnChanged);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView1_InvalidRowException);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            this.gridView1.CustomFilterDialog += new DevExpress.XtraGrid.Views.Grid.CustomFilterDialogEventHandler(this.gridView1_CustomFilterDialog);
            this.gridView1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView1_ValidatingEditor);
            this.gridView1.ShownEditor += new System.EventHandler(this.gridView1_ShownEditor);
            this.gridView1.AfterPrintRow += new DevExpress.XtraGrid.Views.Base.AfterPrintRowEventHandler(this.gridView1_AfterPrintRow);
             this.gridView1.CustomDrawFooter += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gridView1_CustomDrawFooter); // 03.10.2012

            //this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);

            this.printableComponentLink1.CreateReportHeaderArea += new DevExpress.XtraPrinting.CreateAreaEventHandler(this.printableComponentLink1_CreateReportHeaderArea);
            //this.gridView1.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView1_BeforeLeaveRow);
            this.tabControl1.Selecting += new DevExpress.XtraTab.TabPageCancelEventHandler(this.tabControl1_Selecting);
            this.tabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tabControl1_KeyDown);
            this.BILGI1_cmd.Click += new System.EventHandler(this.BILGI_1cmd_Click);
            this.BILGI_2cmd.Click += new System.EventHandler(this.BILGI_2cmd_Click);
            this.BILGI_3cmd.Click += new System.EventHandler(this.BILGI_3cmd_Click);

            this.controlNavigator2.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.controlNavigator2_ButtonClick);
            this.gridView2.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(this.gridView2_ShowGridMenu);
            this.gridControl2.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl2_ProcessGridKey);
            this.gridView2.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView2_InitNewRow);
            this.gridView2.ShownEditor += new System.EventHandler(this.gridView2_ShownEditor);
            this.gridView2.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView2_FocusedRowChanged);
            this.gridView2.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.gridView2_FocusedColumnChanged);
             this.gridView2.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gridView2_InvalidRowException);
            this.gridView2.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView2_ValidateRow);
            this.gridView2.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView2_ValidatingEditor);
            this.gridView2.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView2_ShowingEditor);
            this.printableComponentLink2.CreateReportHeaderArea += new DevExpress.XtraPrinting.CreateAreaEventHandler(this.printableComponentLink2_CreateReportHeaderArea);
            this.gridView2.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView2_CellValueChanged);
            this.gridView2.CustomDrawFooter += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gridView2_CustomDrawFooter);
            //this.gridView2.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.gridView2_BeforeLeaveRow);
        }
        public void satirEventKapat()
        {
            this.gridView2.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView2_ValidatingEditor);
            this.gridView2.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView2_ShowingEditor);
        }
        public void satirEventAc()
        {
            this.gridView2.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView2_ValidatingEditor);
            this.gridView2.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView2_ShowingEditor);
        }
        public void Ikinci_Tab_Ac()//yenisatirSifirli false degerine burada set ediliyor.
        {
            if (tabControl1.SelectedTabPage == tbFisGenel)
            {
                tabControl1.SelectedTabPage = tbFisSatir;
            }
            else
            {
                tabControl1.SelectedTabPage = tbFisGenel;
            }
            
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) 
        {
            YardimciIslemlerKontrols.ProgramBeklemeGoster();
            kayitSilinmeUyarisiniGosterme = true;
            kayitSilinmisUyarisi = false;
            if (tabControl1.SelectedTabPageIndex == 0)
            {
                kayitSilinmisUyarisi = true;
                kayitSilinmeUyarisiniGosterme = false;
            }
            else
            {
                if (yeniSatirSifirli == false) degisikligeBagliSayfaDoldur = false;
            }
            TabPage_Index_Changed(tabControl1.SelectedTabPageIndex);// tureyen forma gidis
            if (tabControl1.SelectedTabPageIndex == 0)
            {
                Globals.SifirliKayitKontrol = true;
            }
            currentTabEski = currentTab;
            currentTab = tabControl1.SelectedTabPageIndex; // tab seciminin tureyen formda ayarlanmasi icin konuldu
            if (currentTab == 0)
            {
                controlNavigator1.Visible = true;
                sonRow = sonRowBul(gridView1);
                //gridView2.ActiveFilterCriteria = null;06062012
            }
            else
            {
                sonRow = sonRowBul(gridView2);
            }
            if (currentTab == 1)
            {
                ColumnGenislikAyarla(gridView2);
            }
            if (tabControl1.SelectedTabPageIndex == 1)
            {
                int fRow = gridView2.FocusedRowHandle;
                FocusedRowChangedEventArgs a = new FocusedRowChangedEventArgs(fRow, fRow);
                gridView2_FocusedRowChanged(gridView2, a);
            }
            YardimciIslemlerKontrols.ProgramBeklemeDurdur();
            gridHelperYenile = true;
            //yetKiAyarla(yetki);
        }
        private void tabControl1_Selecting(object sender, DevExpress.XtraTab.TabPageCancelEventArgs e)// sifirli kayýt yeni ekleniyorsa ise tab degisimini engelliyor, tureyen sinifa gidiyor
        {
            if (e.Page != tbFisGenel)// sifirli kayitta fis yok ise satirin acilmasini engelliyor
            {
                if (SifirliKayitVarMi() == false)
                {
                    e.Cancel = true; return;
                }
                if (yeniSatirSifirli == true && sonsutunkaydet == false)
                {
                    //e.Cancel = true; return;
                    degisikligeBagliSayfaDoldur = true;
                }
                else if (yeniSatirSifirli == false && gridView1.FocusedRowHandle < 0)
                {
                    e.Cancel = true; return;
                }
                else
                {
                    controlNavigator1.Visible = false;
                }
               
                if (currentTab == 1)
                {
                    if (SatirSayiKayitKontrol() == 0)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
            else if (currentTab == 1)
            {
                if (SatirSayiKayitKontrol() == 0)
                {
                    YardimciIslemlerKontrols.ProgramBeklemeGoster();
                    kayitSilinmisUyarisi = false;
                    Sil();
                    Doldur();
                    e.Cancel = false;
                    kayitSilinmisUyarisi = true;
                    YardimciIslemlerKontrols.ProgramBeklemeDurdur();
                    return;
                }
            }
        
            TabPage_Selecting(e.Page); // tureyen forma gisi
            e.Cancel = !tabSelect; // tureyen form donusu
            if (e.Page == tbFisGenel && e.Cancel==false)// sifirli kayitta fis yok ise satirin acilmasini engelliyor
            {
                controlNavigator1.Visible = true;
            }
        }
        //5300535106
        public virtual int SatirSayiKayitKontrol()
        {
            return 1;
        }
        public virtual bool SifirliKayitVarMi()
        {
            return true;
        }
        public bool SifirliKayitSilinmisUyariKontrol()
        {
            YardimciIslemlerKontrols.ProgramBeklemeGoster();
            if (SifirliKayitVarMi() == false)
            {
                if (kayitSilinmisUyarisi == true)
                {
                    MessageBox.Show(Globals.rman.GetString("KayitSilinmisUyarisi"));
                    int eskiRow = gridView1.DataRowCount;
                    Doldur();
                    gridView1.FocusedRowHandle = eskiRow - 1;// yeni kayýt acýldýgýnda eski satýra donmesi icin konuldu.
                    gridView1.TopRowIndex = eskiRow;
                    gridControl1.Focus();
                }
                YardimciIslemlerKontrols.ProgramBeklemeDurdur();
                return false;
            }
            YardimciIslemlerKontrols.ProgramBeklemeDurdur();
            return true;
        }
        private void tabControl1_KeyDown(object sender, KeyEventArgs e)// Tanýtým sablonda var ikinci tabý insert ile kaydetmek icin kullanýyor
        {

        }
        private void FisSablonSon_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = sablonKapat;
            if (sablonKapat == false)
            {
                //bindingSourceArr = null;
                //bindingSource1 = null;
                //gridView1.Dispose();
                //gridControl1.Dispose();
                //gridView2.Dispose();
                //gridControl2.Dispose();
            }
            
        }
        public override bool KapatKontrol()// sablon kapat kontrol
        {
            if (SatirSayiKayitKontrol() == 0 && tabControl1.SelectedTabPageIndex == 1)
            {
                Sil();
                Globals.SifirliKayitKontrol = true;
            }
            sablonKapat = Form_Kapama_Islemi();
            return sablonKapat;
        }
        public override void Ekran_Yenile()
        {
            YardimciIslemlerKontrols.ProgramBeklemeGoster();
            Doldur();
            YardimciIslemlerKontrols.ProgramBeklemeDurdur();
            gridHelperYenile = true;
        }
        #region ortakolaylar virtual
        protected override void Dispose(bool disposing)
        {
            //bindingSourceArr = null;
            //bindingSource1 = null;
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
            //GC.Collect();
        }
        public virtual void Filtrele() { }
        public virtual void AltToplamYaz()
        {
        }
        public virtual void AltToplamYazSatir()
        {
        }
        public virtual void Acilis_Islemleri()
        {
        }
        public virtual void Tab_Gizle_Ekle()
        {
        }
        public virtual void TabPage_Index_Changed(int index) { }
        public virtual void Dinamik_TextBox_Olustur(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e) { }
        public virtual void Fis_KeyDown(KeyEventArgs args) { }
        public virtual bool Form_Kapama_Islemi() { return false; }
        public virtual void Doldur() { }
        public virtual void ModelDoldur() { }
        public virtual void TabPage_Selecting( DevExpress.XtraTab.XtraTabPage tb) { }
        public virtual void ProcessNewValue(GridView view,string value)//gridlookueditlerde icinde valuesu olmayan bir degerin alinip ona gore islem yapilabilmesi icin kullanýlýyor 
        {
        }
        public virtual void Sifirli_Sil_Kontrol() { }
        public void Fis_Load()
        {
            if (disaridanAc == false)
            {
                YardimciIslemlerKontrols.ProgramBeklemeGoster();
                Doldur();
                YardimciIslemlerKontrols.ProgramBeklemeDurdur();
                gridHelperYenile = true;
            }
            disaridanAc = false;
        }
        public virtual void ColumnGenislikAyarla(GridView view)
        {

        }
        public void Doldur_Islemleri()
        {
            gridControl1.DataSource = bnSifir;
            gridView1.Columns["ID"].Visible = false;
            //Filtrele();
            //if (gridView1.ActiveFilter == null) 060062012
            //{ 
            //    Filtrele();
            //}//12.02.2012' de siparis fisten acýlýsýnda filtreleme yapmiyor diye koydum. bakacagiz artýk.
            if (ilkAcilis == true)
            {
                if (disaridanAc == false)
                {
                    //Filtrele();
                }
                Acilis_Islemleri();
                AltToplamYaz();
                ModelSifirVm = gridView1.GetFocusedRow();
                //FocusedRowChanged(gridView1.FocusedRowHandle, gridView1.FocusedRowHandle); // ilk Kayýt icin
            }
            int fRow = gridView1.FocusedRowHandle;
            FocusedRowChangedEventArgs a = new FocusedRowChangedEventArgs(fRow, fRow);
            gridView1_FocusedRowChanged(gridView1, a);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }
        #endregion
        #endregion
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FisSablonSon));
            this.bindingSource2 = new System.Windows.Forms.BindingSource();
            this.controlNavigator1 = new DevExpress.XtraEditors.ControlNavigator();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemGridLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.toolTipGridview2 = new DevExpress.Utils.ToolTipController();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pnlIslemler = new DevExpress.XtraEditors.PanelControl();
            this.BILGI_2cmd = new System.Windows.Forms.Button();
            this.pnlEkIslemler = new DevExpress.XtraEditors.PanelControl();
            this.BILGI_3cmd = new System.Windows.Forms.Button();
            this.pnlArama = new DevExpress.XtraEditors.PanelControl();
            this.BILGI1_cmd = new System.Windows.Forms.Button();
            this.tabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tbFisGenel = new DevExpress.XtraTab.XtraTabPage();
            this.lblMesaj = new DevExpress.XtraEditors.LabelControl();
            this.lblBilgi = new System.Windows.Forms.Label();
            this.tbFisSatir = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlStokBilgileri = new System.Windows.Forms.Panel();
            this.controlNavigator2 = new DevExpress.XtraEditors.ControlNavigator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbFisEkbilgi = new DevExpress.XtraTab.XtraTabPage();
            this.panel2Alt = new DevExpress.XtraEditors.PanelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.controlNavigator3 = new DevExpress.XtraEditors.ControlNavigator();
            this.tbSatirBilgi = new DevExpress.XtraTab.XtraTabPage();
            this.panel3Alt = new DevExpress.XtraEditors.PanelControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.controlNavigator4 = new DevExpress.XtraEditors.ControlNavigator();
            this.tabPage5 = new DevExpress.XtraTab.XtraTabPage();
            this.panel4Alt = new DevExpress.XtraEditors.PanelControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.controlNavigator5 = new DevExpress.XtraEditors.ControlNavigator();
            this.tabPage6 = new DevExpress.XtraTab.XtraTabPage();
            this.panel5Alt = new DevExpress.XtraEditors.PanelControl();
            this.panel5 = new System.Windows.Forms.Panel();
            this.controlNavigator6 = new DevExpress.XtraEditors.ControlNavigator();
            this.tabPage7 = new DevExpress.XtraTab.XtraTabPage();
            this.panel6Alt = new DevExpress.XtraEditors.PanelControl();
            this.panel6 = new System.Windows.Forms.Panel();
            this.controlNavigator7 = new DevExpress.XtraEditors.ControlNavigator();
            this.tabPage8 = new DevExpress.XtraTab.XtraTabPage();
            this.panel7Alt = new DevExpress.XtraEditors.PanelControl();
            this.panel7 = new System.Windows.Forms.Panel();
            this.controlNavigator8 = new DevExpress.XtraEditors.ControlNavigator();
            this.tabPage9 = new DevExpress.XtraTab.XtraTabPage();
            this.panel8Alt = new DevExpress.XtraEditors.PanelControl();
            this.panel8 = new System.Windows.Forms.Panel();
            this.controlNavigator9 = new DevExpress.XtraEditors.ControlNavigator();
            this.tabPage10 = new DevExpress.XtraTab.XtraTabPage();
            this.panel9Alt = new DevExpress.XtraEditors.PanelControl();
            this.panel9 = new System.Windows.Forms.Panel();
            this.controlNavigator10 = new DevExpress.XtraEditors.ControlNavigator();
            this.tabPage11 = new DevExpress.XtraTab.XtraTabPage();
            this.panel10Alt = new DevExpress.XtraEditors.PanelControl();
            this.panel10 = new System.Windows.Forms.Panel();
            this.controlNavigator11 = new DevExpress.XtraEditors.ControlNavigator();
            this.tabPage12 = new DevExpress.XtraTab.XtraTabPage();
            this.panel11Alt = new DevExpress.XtraEditors.PanelControl();
            this.panel11 = new System.Windows.Forms.Panel();
            this.controlNavigator12 = new DevExpress.XtraEditors.ControlNavigator();
            this.tabPage13 = new DevExpress.XtraTab.XtraTabPage();
            this.panel12Alt = new DevExpress.XtraEditors.PanelControl();
            this.panel12 = new System.Windows.Forms.Panel();
            this.controlNavigator13 = new DevExpress.XtraEditors.ControlNavigator();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem();
            this.printableComponentLink1 = new DevExpress.XtraPrinting.PrintableComponentLink();
            this.printingSystem2 = new DevExpress.XtraPrinting.PrintingSystem();
            this.printableComponentLink2 = new DevExpress.XtraPrinting.PrintableComponentLink();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1dsfsd = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu();
            this.popupMenu2 = new DevExpress.XtraBars.PopupMenu();
            this.barManager2 = new DevExpress.XtraBars.BarManager();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
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
            this.tbFisGenel.SuspendLayout();
            this.tbFisSatir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.tbFisEkbilgi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel2Alt)).BeginInit();
            this.tbSatirBilgi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel3Alt)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel4Alt)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel5Alt)).BeginInit();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel6Alt)).BeginInit();
            this.tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel7Alt)).BeginInit();
            this.tabPage9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel8Alt)).BeginInit();
            this.tabPage10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel9Alt)).BeginInit();
            this.tabPage11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel10Alt)).BeginInit();
            this.tabPage12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel11Alt)).BeginInit();
            this.tabPage13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel12Alt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).BeginInit();
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
            // controlNavigator1
            // 
            this.controlNavigator1.Buttons.EndEdit.Visible = false;
            this.controlNavigator1.Buttons.ImageList = this.imageList1;
            this.controlNavigator1.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 10, true, true, "Yazdýr", "Yazdir"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 0, true, true, "Sayfa Yenile", "SayfaYenile"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem2", "Islem2"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem3", "Islem3"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem4", "Islem4"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem5", "Islem5"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem6", "Islem6"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem7", "Islem7"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem8", "Islem8"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem9", "Islem9"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem10", "Islem10"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem11", "Islem11"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem12", "Islem12"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem13", "Islem13"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem14", "Islem14"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem15", "Islem15"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem16", "Islem16"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem17", "Islem17"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem18", "Islem18"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem19", "Islem19"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem20", "Islem20")});
            this.controlNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlNavigator1.Location = new System.Drawing.Point(0, 531);
            this.controlNavigator1.Name = "controlNavigator1";
            this.controlNavigator1.NavigatableControl = this.gridControl1;
            this.controlNavigator1.ShowToolTips = true;
            this.controlNavigator1.Size = new System.Drawing.Size(958, 34);
            this.controlNavigator1.TabIndex = 7;
            this.controlNavigator1.Text = "controlNavigator1";
            this.controlNavigator1.ToolTipController = this.toolTipGridview2;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 3);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemGridLookUpEdit1,
            this.repositoryItemGridLookUpEdit2});
            this.gridControl1.Size = new System.Drawing.Size(944, 470);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ToolTipController = this.toolTipGridview2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.White;
            this.gridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.BlueViolet;
            this.gridView1.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterPanel.Options.UseFont = true;
            this.gridView1.Appearance.FilterPanel.Options.UseForeColor = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PaintStyleName = "Office2003";
            this.gridView1.ShowFilterPopupListBox += new DevExpress.XtraGrid.Views.Grid.FilterPopupListBoxEventHandler(this.gridView1_ShowFilterPopupListBox);
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F5);
            this.repositoryItemGridLookUpEdit1.DisplayMember = "AD";
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.ValueMember = "ID";
            this.repositoryItemGridLookUpEdit1.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemGridLookUpEdit2
            // 
            this.repositoryItemGridLookUpEdit2.Name = "repositoryItemGridLookUpEdit2";
            this.repositoryItemGridLookUpEdit2.View = this.repositoryItemGridLookUpEdit2View;
            // 
            // repositoryItemGridLookUpEdit2View
            // 
            this.repositoryItemGridLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit2View.Name = "repositoryItemGridLookUpEdit2View";
            this.repositoryItemGridLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // toolTipGridview2
            // 
            this.toolTipGridview2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.toolTipGridview2.Appearance.Options.UseFont = true;
            this.toolTipGridview2.AutoPopDelay = 50000;
            this.toolTipGridview2.InitialDelay = 1;
            this.toolTipGridview2.ReshowDelay = 3;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "tendermaterialunitlist.png");
            this.imageCollection1.Images.SetKeyName(1, "printer.png");
            this.imageCollection1.Images.SetKeyName(2, "documents_gear.png");
            this.imageCollection1.Images.SetKeyName(3, "OpenOffice-VistaToonPack.png");
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.pnlIslemler);
            this.panelControl1.Controls.Add(this.pnlEkIslemler);
            this.panelControl1.Controls.Add(this.pnlArama);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 506);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(958, 25);
            this.panelControl1.TabIndex = 16;
            // 
            // pnlIslemler
            // 
            this.pnlIslemler.Controls.Add(this.BILGI_2cmd);
            this.pnlIslemler.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlIslemler.Location = new System.Drawing.Point(2, -17);
            this.pnlIslemler.Name = "pnlIslemler";
            this.pnlIslemler.Size = new System.Drawing.Size(954, 20);
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
            this.BILGI_2cmd.Size = new System.Drawing.Size(950, 20);
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
            this.pnlEkIslemler.Size = new System.Drawing.Size(954, 20);
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
            this.BILGI_3cmd.Size = new System.Drawing.Size(950, 23);
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
            this.pnlArama.Size = new System.Drawing.Size(954, 21);
            this.pnlArama.TabIndex = 0;
            // 
            // BILGI1_cmd
            // 
            this.BILGI1_cmd.Dock = System.Windows.Forms.DockStyle.Top;
            this.BILGI1_cmd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BILGI1_cmd.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(162)));
            this.BILGI1_cmd.Location = new System.Drawing.Point(2, 2);
            this.BILGI1_cmd.Name = "BILGI1_cmd";
            this.BILGI1_cmd.Size = new System.Drawing.Size(950, 20);
            this.BILGI1_cmd.TabIndex = 0;
            this.BILGI1_cmd.Text = "ARAMA";
            this.BILGI1_cmd.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabPage = this.tbFisGenel;
            this.tabControl1.Size = new System.Drawing.Size(958, 506);
            this.tabControl1.TabIndex = 17;
            this.tabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tbFisGenel,
            this.tbFisSatir,
            this.tbFisEkbilgi,
            this.tbSatirBilgi,
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
            // tbFisGenel
            // 
            this.tbFisGenel.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.tbFisGenel.Appearance.Header.Options.UseFont = true;
            this.tbFisGenel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbFisGenel.Controls.Add(this.lblMesaj);
            this.tbFisGenel.Controls.Add(this.gridControl1);
            this.tbFisGenel.Controls.Add(this.lblBilgi);
            this.tbFisGenel.Font = new System.Drawing.Font("Tahoma", 10.25F, System.Drawing.FontStyle.Bold);
            this.tbFisGenel.Name = "tbFisGenel";
            this.tbFisGenel.Padding = new System.Windows.Forms.Padding(3);
            this.tbFisGenel.Size = new System.Drawing.Size(950, 476);
            this.tbFisGenel.Text = "Bilgi Giriþ";
            // 
            // lblMesaj
            // 
            this.lblMesaj.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblMesaj.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMesaj.Appearance.Options.UseFont = true;
            this.lblMesaj.Appearance.Options.UseForeColor = true;
            this.lblMesaj.Location = new System.Drawing.Point(20, 445);
            this.lblMesaj.Name = "lblMesaj";
            this.lblMesaj.Size = new System.Drawing.Size(75, 16);
            this.lblMesaj.TabIndex = 9;
            this.lblMesaj.Text = "labelControl1";
            this.lblMesaj.Visible = false;
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
            // tbFisSatir
            // 
            this.tbFisSatir.Appearance.Header.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.tbFisSatir.Appearance.Header.Options.UseFont = true;
            this.tbFisSatir.Controls.Add(this.gridControl2);
            this.tbFisSatir.Controls.Add(this.pnlStokBilgileri);
            this.tbFisSatir.Controls.Add(this.controlNavigator2);
            this.tbFisSatir.Controls.Add(this.panel1);
            this.tbFisSatir.Name = "tbFisSatir";
            this.tbFisSatir.Padding = new System.Windows.Forms.Padding(3);
            this.tbFisSatir.Size = new System.Drawing.Size(950, 476);
            this.tbFisSatir.Text = "Ek bilgiler";
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(3, 63);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(944, 376);
            this.gridControl2.TabIndex = 52;
            this.gridControl2.ToolTipController = this.toolTipGridview2;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.gridControl2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridControl2_MouseDown);
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView2.OptionsView.EnableAppearanceOddRow = true;
            this.gridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // pnlStokBilgileri
            // 
            this.pnlStokBilgileri.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlStokBilgileri.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStokBilgileri.Location = new System.Drawing.Point(3, 439);
            this.pnlStokBilgileri.Name = "pnlStokBilgileri";
            this.pnlStokBilgileri.Size = new System.Drawing.Size(944, 0);
            this.pnlStokBilgileri.TabIndex = 51;
            // 
            // controlNavigator2
            // 
            this.controlNavigator2.Buttons.EndEdit.Visible = false;
            this.controlNavigator2.Buttons.ImageList = this.imageList1;
            this.controlNavigator2.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Yazdýr", "Yazdir"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 0, true, true, "Islem1", "Islem1"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem2", "Islem2"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem3", "Islem3"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem4", "Islem4"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem5", "Islem5"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem6", "Islem6"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem7", "Islem7"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem8", "Islem8"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem9", "Islem9"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem10", "Islem10"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem11", "Islem11"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem12", "Islem12"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem13", "Islem13"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem14", "Islem14"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem15", "Islem15"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem16", "Islem16"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem17", "Islem17"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem18", "Islem18"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem19", "Islem19"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, -1, true, true, "Islem20", "Islem20")});
            this.controlNavigator2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlNavigator2.Location = new System.Drawing.Point(3, 439);
            this.controlNavigator2.Name = "controlNavigator2";
            this.controlNavigator2.NavigatableControl = this.gridControl2;
            this.controlNavigator2.ShowToolTips = true;
            this.controlNavigator2.Size = new System.Drawing.Size(944, 34);
            this.controlNavigator2.TabIndex = 50;
            this.controlNavigator2.Text = "controlNavigator2";
            this.controlNavigator2.ToolTipController = this.toolTipGridview2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 60);
            this.panel1.TabIndex = 47;
            // 
            // tbFisEkbilgi
            // 
            this.tbFisEkbilgi.Controls.Add(this.panel2Alt);
            this.tbFisEkbilgi.Controls.Add(this.panel2);
            this.tbFisEkbilgi.Controls.Add(this.controlNavigator3);
            this.tbFisEkbilgi.Name = "tbFisEkbilgi";
            this.tbFisEkbilgi.Padding = new System.Windows.Forms.Padding(3);
            this.tbFisEkbilgi.Size = new System.Drawing.Size(950, 476);
            this.tbFisEkbilgi.Text = "tabPage3";
            // 
            // panel2Alt
            // 
            this.panel2Alt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2Alt.Location = new System.Drawing.Point(3, 63);
            this.panel2Alt.Name = "panel2Alt";
            this.panel2Alt.Size = new System.Drawing.Size(944, 370);
            this.panel2Alt.TabIndex = 49;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(944, 60);
            this.panel2.TabIndex = 48;
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
            this.controlNavigator3.Location = new System.Drawing.Point(3, 433);
            this.controlNavigator3.Name = "controlNavigator3";
            this.controlNavigator3.Size = new System.Drawing.Size(944, 40);
            this.controlNavigator3.TabIndex = 1;
            this.controlNavigator3.Text = "controlNavigator3";
            this.controlNavigator3.Visible = false;
            // 
            // tbSatirBilgi
            // 
            this.tbSatirBilgi.Controls.Add(this.panel3Alt);
            this.tbSatirBilgi.Controls.Add(this.panel3);
            this.tbSatirBilgi.Controls.Add(this.controlNavigator4);
            this.tbSatirBilgi.Name = "tbSatirBilgi";
            this.tbSatirBilgi.Padding = new System.Windows.Forms.Padding(3);
            this.tbSatirBilgi.Size = new System.Drawing.Size(950, 476);
            this.tbSatirBilgi.Text = "tabPage4";
            // 
            // panel3Alt
            // 
            this.panel3Alt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3Alt.Location = new System.Drawing.Point(3, 63);
            this.panel3Alt.Name = "panel3Alt";
            this.panel3Alt.Size = new System.Drawing.Size(944, 370);
            this.panel3Alt.TabIndex = 50;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(944, 60);
            this.panel3.TabIndex = 48;
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
            this.controlNavigator4.Location = new System.Drawing.Point(3, 433);
            this.controlNavigator4.Name = "controlNavigator4";
            this.controlNavigator4.Size = new System.Drawing.Size(944, 40);
            this.controlNavigator4.TabIndex = 1;
            this.controlNavigator4.Text = "controlNavigator4";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.panel4Alt);
            this.tabPage5.Controls.Add(this.panel4);
            this.tabPage5.Controls.Add(this.controlNavigator5);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(950, 476);
            this.tabPage5.Text = "tabPage5";
            // 
            // panel4Alt
            // 
            this.panel4Alt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4Alt.Location = new System.Drawing.Point(3, 63);
            this.panel4Alt.Name = "panel4Alt";
            this.panel4Alt.Size = new System.Drawing.Size(944, 370);
            this.panel4Alt.TabIndex = 50;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(944, 60);
            this.panel4.TabIndex = 48;
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
            this.controlNavigator5.Location = new System.Drawing.Point(3, 433);
            this.controlNavigator5.Name = "controlNavigator5";
            this.controlNavigator5.Size = new System.Drawing.Size(944, 40);
            this.controlNavigator5.TabIndex = 1;
            this.controlNavigator5.Text = "controlNavigator5";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.panel5Alt);
            this.tabPage6.Controls.Add(this.panel5);
            this.tabPage6.Controls.Add(this.controlNavigator6);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(950, 476);
            this.tabPage6.Text = "tabPage6";
            // 
            // panel5Alt
            // 
            this.panel5Alt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5Alt.Location = new System.Drawing.Point(3, 63);
            this.panel5Alt.Name = "panel5Alt";
            this.panel5Alt.Size = new System.Drawing.Size(944, 370);
            this.panel5Alt.TabIndex = 50;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(944, 60);
            this.panel5.TabIndex = 48;
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
            this.controlNavigator6.Location = new System.Drawing.Point(3, 433);
            this.controlNavigator6.Name = "controlNavigator6";
            this.controlNavigator6.Size = new System.Drawing.Size(944, 40);
            this.controlNavigator6.TabIndex = 1;
            this.controlNavigator6.Text = "controlNavigator6";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.panel6Alt);
            this.tabPage7.Controls.Add(this.panel6);
            this.tabPage7.Controls.Add(this.controlNavigator7);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(950, 476);
            this.tabPage7.Text = "tabPage7";
            // 
            // panel6Alt
            // 
            this.panel6Alt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6Alt.Location = new System.Drawing.Point(3, 63);
            this.panel6Alt.Name = "panel6Alt";
            this.panel6Alt.Size = new System.Drawing.Size(944, 370);
            this.panel6Alt.TabIndex = 50;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(944, 60);
            this.panel6.TabIndex = 48;
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
            this.controlNavigator7.Location = new System.Drawing.Point(3, 433);
            this.controlNavigator7.Name = "controlNavigator7";
            this.controlNavigator7.Size = new System.Drawing.Size(944, 40);
            this.controlNavigator7.TabIndex = 1;
            this.controlNavigator7.Text = "controlNavigator7";
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.panel7Alt);
            this.tabPage8.Controls.Add(this.panel7);
            this.tabPage8.Controls.Add(this.controlNavigator8);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(950, 476);
            this.tabPage8.Text = "tabPage8";
            // 
            // panel7Alt
            // 
            this.panel7Alt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7Alt.Location = new System.Drawing.Point(3, 63);
            this.panel7Alt.Name = "panel7Alt";
            this.panel7Alt.Size = new System.Drawing.Size(944, 370);
            this.panel7Alt.TabIndex = 50;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(944, 60);
            this.panel7.TabIndex = 48;
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
            this.controlNavigator8.Location = new System.Drawing.Point(3, 433);
            this.controlNavigator8.Name = "controlNavigator8";
            this.controlNavigator8.Size = new System.Drawing.Size(944, 40);
            this.controlNavigator8.TabIndex = 1;
            this.controlNavigator8.Text = "controlNavigator8";
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.panel8Alt);
            this.tabPage9.Controls.Add(this.panel8);
            this.tabPage9.Controls.Add(this.controlNavigator9);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(950, 476);
            this.tabPage9.Text = "tabPage9";
            // 
            // panel8Alt
            // 
            this.panel8Alt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8Alt.Location = new System.Drawing.Point(3, 53);
            this.panel8Alt.Name = "panel8Alt";
            this.panel8Alt.Size = new System.Drawing.Size(944, 380);
            this.panel8Alt.TabIndex = 50;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(3, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(944, 50);
            this.panel8.TabIndex = 48;
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
            this.controlNavigator9.Location = new System.Drawing.Point(3, 433);
            this.controlNavigator9.Name = "controlNavigator9";
            this.controlNavigator9.Size = new System.Drawing.Size(944, 40);
            this.controlNavigator9.TabIndex = 1;
            this.controlNavigator9.Text = "controlNavigator9";
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.panel9Alt);
            this.tabPage10.Controls.Add(this.panel9);
            this.tabPage10.Controls.Add(this.controlNavigator10);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(950, 476);
            this.tabPage10.Text = "tabPage10";
            // 
            // panel9Alt
            // 
            this.panel9Alt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9Alt.Location = new System.Drawing.Point(3, 53);
            this.panel9Alt.Name = "panel9Alt";
            this.panel9Alt.Size = new System.Drawing.Size(944, 380);
            this.panel9Alt.TabIndex = 50;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(3, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(944, 50);
            this.panel9.TabIndex = 48;
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
            this.controlNavigator10.Location = new System.Drawing.Point(3, 433);
            this.controlNavigator10.Name = "controlNavigator10";
            this.controlNavigator10.Size = new System.Drawing.Size(944, 40);
            this.controlNavigator10.TabIndex = 1;
            this.controlNavigator10.Text = "controlNavigator10";
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.panel10Alt);
            this.tabPage11.Controls.Add(this.panel10);
            this.tabPage11.Controls.Add(this.controlNavigator11);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(950, 476);
            this.tabPage11.Text = "tabPage11";
            // 
            // panel10Alt
            // 
            this.panel10Alt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10Alt.Location = new System.Drawing.Point(3, 53);
            this.panel10Alt.Name = "panel10Alt";
            this.panel10Alt.Size = new System.Drawing.Size(944, 380);
            this.panel10Alt.TabIndex = 50;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(3, 3);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(944, 50);
            this.panel10.TabIndex = 48;
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
            this.controlNavigator11.Location = new System.Drawing.Point(3, 433);
            this.controlNavigator11.Name = "controlNavigator11";
            this.controlNavigator11.Size = new System.Drawing.Size(944, 40);
            this.controlNavigator11.TabIndex = 1;
            this.controlNavigator11.Text = "controlNavigator11";
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.panel11Alt);
            this.tabPage12.Controls.Add(this.panel11);
            this.tabPage12.Controls.Add(this.controlNavigator12);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage12.Size = new System.Drawing.Size(950, 476);
            this.tabPage12.Text = "tabPage12";
            // 
            // panel11Alt
            // 
            this.panel11Alt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11Alt.Location = new System.Drawing.Point(3, 53);
            this.panel11Alt.Name = "panel11Alt";
            this.panel11Alt.Size = new System.Drawing.Size(944, 380);
            this.panel11Alt.TabIndex = 50;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(3, 3);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(944, 50);
            this.panel11.TabIndex = 48;
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
            this.controlNavigator12.Location = new System.Drawing.Point(3, 433);
            this.controlNavigator12.Name = "controlNavigator12";
            this.controlNavigator12.Size = new System.Drawing.Size(944, 40);
            this.controlNavigator12.TabIndex = 1;
            this.controlNavigator12.Text = "controlNavigator12";
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.panel12Alt);
            this.tabPage13.Controls.Add(this.panel12);
            this.tabPage13.Controls.Add(this.controlNavigator13);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage13.Size = new System.Drawing.Size(950, 476);
            this.tabPage13.Text = "tabPage13";
            // 
            // panel12Alt
            // 
            this.panel12Alt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12Alt.Location = new System.Drawing.Point(3, 53);
            this.panel12Alt.Name = "panel12Alt";
            this.panel12Alt.Size = new System.Drawing.Size(944, 380);
            this.panel12Alt.TabIndex = 50;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(3, 3);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(944, 50);
            this.panel12.TabIndex = 48;
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
            this.controlNavigator13.Location = new System.Drawing.Point(3, 433);
            this.controlNavigator13.Name = "controlNavigator13";
            this.controlNavigator13.Size = new System.Drawing.Size(944, 40);
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
            this.printableComponentLink1.Component = this.gridControl1;
            // 
            // 
            // 
            this.printableComponentLink1.ImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink1.ImageCollection.ImageStream")));
            this.printableComponentLink1.PrintingSystem = this.printingSystem1;
            this.printableComponentLink1.PrintingSystemBase = this.printingSystem1;


            // printingSystem2
            // 
            this.printingSystem2.Links.AddRange(new object[] {
            this.printableComponentLink2});
            // 
            // printableComponentLink2
            // 
            this.printableComponentLink2.Component = this.gridControl2;
            // 
            // 
            // 
            this.printableComponentLink2.ImageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("printableComponentLink2.ImageCollection.ImageStream")));
            this.printableComponentLink2.PrintingSystem = this.printingSystem2;
            this.printableComponentLink2.PrintingSystemBase = this.printingSystem2;
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
            this.barDockControlTop.Size = new System.Drawing.Size(958, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 565);
            this.barDockControlBottom.Size = new System.Drawing.Size(958, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 565);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(958, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 565);
            // 
            // barButtonItem1dsfsd
            // 
            this.barButtonItem1dsfsd.Id = -1;
            this.barButtonItem1dsfsd.Name = "barButtonItem1dsfsd";
            // 
            // popupMenu1
            // 
            this.popupMenu1.Name = "popupMenu1";
            // 
            // popupMenu2
            // 
            this.popupMenu2.Name = "popupMenu2";
            // 
            // barManager2
            // 
            this.barManager2.DockControls.Add(this.barDockControl1);
            this.barManager2.DockControls.Add(this.barDockControl2);
            this.barManager2.DockControls.Add(this.barDockControl3);
            this.barManager2.DockControls.Add(this.barDockControl4);
            this.barManager2.Form = this;
            this.barManager2.MaxItemId = 0;
            // 
            // barDockControl1
            // 
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Size = new System.Drawing.Size(958, 0);
            // 
            // barDockControl2
            // 
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 565);
            this.barDockControl2.Size = new System.Drawing.Size(958, 0);
            // 
            // barDockControl3
            // 
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 0);
            this.barDockControl3.Size = new System.Drawing.Size(0, 565);
            // 
            // barDockControl4
            // 
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(958, 0);
            this.barDockControl4.Size = new System.Drawing.Size(0, 565);
            // 
            // FisSablonSon1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(958, 565);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.controlNavigator1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.KeyPreview = true;
            this.LookAndFeel.SkinName = "Lilian";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "FisSablonSon1";
            this.Text = "FisSablon";
            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
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
            this.tbFisGenel.ResumeLayout(false);
            this.tbFisGenel.PerformLayout();
            this.tbFisSatir.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.tbFisEkbilgi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel2Alt)).EndInit();
            this.tbSatirBilgi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel3Alt)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel4Alt)).EndInit();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel5Alt)).EndInit();
            this.tabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel6Alt)).EndInit();
            this.tabPage8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel7Alt)).EndInit();
            this.tabPage9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel8Alt)).EndInit();
            this.tabPage10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel9Alt)).EndInit();
            this.tabPage11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel10Alt)).EndInit();
            this.tabPage12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel11Alt)).EndInit();
            this.tabPage13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel12Alt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager2)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        #region SIFIR
        #region olaylar
        public void customButonIslemleri(object sender, NavigatorButtonClickEventArgs e)
        {
            YardimciIslemlerKontrols.ProgramBeklemeGoster();

            if (e.Button.Tag.ToString() == "Yazdir")
            {
                if (this.popupMenu1.Manager!=null)
                {
                    try
                    {
                        FieldInfo fi = typeof(NavigatorButtonsBase).GetField("viewInfo", BindingFlags.Instance | BindingFlags.NonPublic);
                        NavigatorButtonsViewInfo buttonsViewInfo = (NavigatorButtonsViewInfo)fi.GetValue(controlNavigator1.ViewInfo.Buttons);
                        Point mousePosition = controlNavigator1.PointToClient(Control.MousePosition);
                        NavigatorButtonViewInfo buttonViewInfo = buttonsViewInfo.ButtonViewInfoAt(mousePosition);
                        Point menuPosition = new Point(buttonViewInfo.Bounds.Left, buttonViewInfo.Bounds.Bottom);
                        menuPosition = controlNavigator1.PointToScreen(menuPosition);
                        popupMenu1.ShowPopup(menuPosition);
                    }
                    catch (Exception)
                    {
                        printableComponentLink1.CreateDocument();
                        printableComponentLink1.ShowPreview();
                    }
                    
                }
                else
                {
                    printableComponentLink1.CreateDocument();
                    printableComponentLink1.ShowPreview();
                }
            }
            else if (e.Button.Tag.ToString() == "SayfaYenile")
            {
                YardimciIslemlerKontrols.ProgramBeklemeGoster();
                baslangicFisDoldurrmaTarih = YardimciIslemler.TarihSet1900();
                int eskiRow = gridView1.FocusedRowHandle;
                Doldur();
                YardimciIslemlerKontrols.ProgramBeklemeDurdur();
                gridView1.FocusedRowHandle = eskiRow;
                gridView1.TopRowIndex = eskiRow;
            }
            else
            {
                eskiRow = 0;
                if (gridView1.FocusedRowHandle < 0)
                {
                    eskiRow = gridView1.RowCount - 1;
                }
                else
                {
                    eskiRow = gridView1.FocusedRowHandle;
                }
                Custom_Buton_Islemleri(e.Button.Tag.ToString());
                if (helperBase._donusBDeger == true)
                {
                    YardimciIslemlerKontrols.ProgramBeklemeGoster();
                    gridView1.FocusedColumn = gridView1.Columns["KULLANICI_ID"];
                    ActiveControl = (Control)this.gridControl1;
                    gridControl1.Enabled = true;
                    gridView1.OptionsSelection.EnableAppearanceFocusedCell = true;
                    Doldur();
                    YardimciIslemlerKontrols.ProgramBeklemeDurdur();
                }
                else
                {
                    DevExpress.XtraGrid.Columns.GridColumn _FocusedColumn = gridView1.FocusedColumn;
                    gridView1.RefreshData();
                    gridView1.FocusedColumn = _FocusedColumn;
                    //gridView1.FocusedRowHandle = eskiRow; // Detaylý Arama için koydum.
                }
                gridView1.TopRowIndex = eskiRow;
                ModelDoldur();
            }
            YardimciIslemlerKontrols.ProgramBeklemeDurdur();

        }
        private void printableComponentLink1_CreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
        {
            string d = this.gridView1.FilterPanelText; 
            DevExpress.XtraPrinting.TextBrick brick;
            brick = e.Graph.DrawString(tbFisGenel.Text, Color.Navy, new RectangleF(0, 0, 500, 40), DevExpress.XtraPrinting.BorderSide.None);
            brick.Font = new Font("Tahoma", 8);
            brick.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);
            DevExpress.XtraPrinting.TextBrick brick1;
            brick1 = e.Graph.DrawString(d, Color.Navy, new RectangleF(0, 30, 500, 40), DevExpress.XtraPrinting.BorderSide.None);
            brick1.Font = new Font("Tahoma", 8);
            brick1.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);
        }
        private void gridView1_AfterPrintRow(object sender, DevExpress.XtraGrid.Views.Printing.PrintRowEventArgs e)
        {
            //if ((e.RowHandle + 1) % 5 == 0)
            //{
            //    // Create a text brick and customize its appearance settings.
            //    TextBrick tb = e.PS.CreateTextBrick() as TextBrick;
            //    tb.Text = "Custom footer";
            //    tb.Font = new Font(tb.Font, FontStyle.Bold);
            //    tb.HorzAlignment = DevExpress.Utils.HorzAlignment.Near;
            //    tb.Padding = new PaddingInfo(5, 0, 0, 0);
            //    tb.BackColor = Color.LightGray;
            //    tb.ForeColor = Color.Black;
            //    // Get the client page width.
            //    SizeF clientPageSize = (e.BrickGraphics as BrickGraphics).ClientPageSize;
            //    float textBrickHeight = e.Graphics.MeasureString(tb.Text, tb.Font).Height + 4;
            //    // Calculate a rectangle for the brick and draw the brick.
            //    RectangleF textBrickRect =
            //        new RectangleF(0, e.Y, (int)clientPageSize.Width, textBrickHeight);
            //    e.BrickGraphics.DrawBrick(tb, textBrickRect);
            //    // Adjust the current Y position to print the following row below the brick.
            //    e.Y += (int)textBrickHeight;
            //}
            //// Add a page break.
            //if ((e.RowHandle + 1) % 10 == 0)
            //{
            //    e.PS.InsertPageBreak(e.Y);
            //}
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
        }//Kayittan cikista buraya giriyor . Controlnavigatora gidiyor.
        private bool Kayit(Object row, int rowHandle) // validaterow'dan cikista buraya giriyor.
        {
            if (sonsutunkaydet == true)
            {
                ModelSifirVm = row;
                KayitaGonder(true);
                if (yeniSatirSifirli == true)
                {
                    if (islemTamamDegilSifirli == false) { 
                        this.gridView1.FocusedRowHandle = rowHandle; // sifirli grdin eski satira focuslanmasý icin.
                        satirYeniKayitAc = true; // F5 yapilan kayitlarda yeni kayit acik gelmiyordu ondan kondu.
                        Ikinci_Tab_Ac();
                        //yeniSatirSifirli = false;
            //            ModelDoldur();
                    }
                }
                sonsutunkaydet = false;
            }
            else
            {
                islemTamamDegilSifirli = false;
                YardimciIslemlerKontrols.ProgramBeklemeGoster();
                this.Doldur();//Eski_Kayit_Al_Yukle
                YardimciIslemlerKontrols.ProgramBeklemeDurdur();
                //DialogResult res = MessageBox.Show("Onayla?", "Kayýt Yapýlsýn Mý", MessageBoxButtons.YesNo);
                //if (res == DialogResult.Yes)
                //{
                //    KayitaGonder(true);
                //    if (yeniSatirSifirli == true)
                //    {
                //        if (islemTamamDegilSifirli == false)
                //        {
                //            this.gridView1.FocusedRowHandle = rowHandle; // sifirli grdin eski satira focuslanmasý icin.
                //            Ikinci_Tab_Ac();
                //        }
                //    }
                //}
                //else
                //{
                //    if (yeniSatirSifirli == true)
                //    {
                //        rowHandleExcepTionMessage = ""; // yeni kayýt ise bilgilerin oldugu yerde kalmasý 
                //        return false; 
                //    }
                //    else
                //    {
                //       Eski_Kayit_Al_Yukle(rowHandle); // eski kayýt ise bilgilerin tekrar gride dolmasi icin.
                //    }
                //}
            }
            if (islemTamamDegilSifirli == true){ rowHandleExcepTionMessage = "Bilinmeyen Bir Hata Oluþtu";} return !islemTamamDegilSifirli;
        }
        string sonRowBul(GridView view)
        {
            string sonRow="";
            foreach (DevExpress.XtraGrid.Columns.GridColumn gridCol in view.Columns)
            {
                if (gridCol.OptionsColumn.AllowFocus == true)
                {
                    sonRow = gridCol.FieldName;
                }
            }
            return sonRow;
        }
       
        #endregion
        #region sifirolaylar virtual
        public virtual void Bar_Manager_Islemleri(string islem) {}
        public virtual void Custom_Buton_Islemleri(string islem) { }
        public virtual void Varsayilan_Deger_Ayarla(int focusedRow) { }
        public virtual void Kaydet() { }
        public virtual void Yeni_Kayit() { }
        public virtual void Sil() { }
        public virtual void Yazdir() { }
        public virtual void Bul() { }
        public virtual void Vazgec() { }
        public virtual void ShowingEditor() { }
        public virtual void ValidateRow(int FocusedRowHandle,object row) { }
        public virtual void ValidatingEditor(object value) { }
        public virtual void Eski_Kayit_Al_Yukle(int rowHandle) { }
        public virtual void FocusedColumnChanged(DevExpress.XtraGrid.Columns.GridColumn FocusedColumn, DevExpress.XtraGrid.Columns.GridColumn PrevFocusedColumn) { }
        public virtual void ProcessGridKey(GridView view, KeyEventArgs args, int FocusedRowHandle, DevExpress.XtraGrid.Columns.GridColumn FocusedColumn) { }
        public virtual void BagliGridDoldur(bool hepsi) { }
        public virtual void FocusedRowChanged(int focusedRow,int prevFocusedRow) { }
        public virtual void ShownEditor() { }
        public virtual void BeforeLeaveRow() { }
        #endregion
        #region kontroller
        private void controlNavigator1_ButtonClick(object sender, NavigatorButtonClickEventArgs e)// Override yeni kayýt/guncelle/sil/ilerigerisatirolustur iþlemi Yapýlýyor.
        {
            YardimciIslemlerKontrols.ProgramBeklemeGoster();
            ControlNavigator navigator = (ControlNavigator)sender;
            if (e.Button.ButtonType  == NavigatorButtonType.Custom)
            {
                customButonIslemleri(sender, e);
            }
            else if (e.Button == navigator.Buttons.Next || e.Button == navigator.Buttons.Prev || e.Button == navigator.Buttons.First || e.Button == navigator.Buttons.Last)
            {
                navigatoraBasildi = true;
            }
            else if (e.Button == navigator.Buttons.Append)
            {
                //gridView1.ActiveFilterCriteria = null;06062012
                gridView1.OptionsView.ShowAutoFilterRow = false;
                if (kayitEtme == false) { 
                    MessageBox.Show("Kayit Yetkiniz Bulunmamakatadýr");
                    e.Handled = true;
                    return; 
                }
               // e.Handled = true;
            }
            else if (e.Button == navigator.Buttons.EndEdit)
            {
                
                if (yeniSatirSifirli == false)
                {
                    Kaydet();
                }
                else
                {
                    this.Yeni_Kayit();
                    Globals.SifirliKayitKontrol = false;
                }
                e.Handled = !islemTamamDegilSifirli;
            }
            else if (e.Button == navigator.Buttons.Remove)//Sil Ýþlemi
            {
                FocusedRowChangedEventArgs a11 = new FocusedRowChangedEventArgs(gridView1.FocusedRowHandle, gridView1.FocusedRowHandle);
                gridView1_FocusedRowChanged(gridView1, a11);
                if (this.gridView1.FocusedRowHandle < 0 || controlNavigator1.Buttons.Remove.Enabled == false)
                { 
                    e.Handled = true; return; 
                }
                else
                {
                    if (silme == true)
                    {
                        bool sil = true;
                        DialogResult res = System.Windows.Forms.DialogResult.None;
                        for (int i = 0; i < 1; i++)
                        {
                            res = MessageBox.Show("Fiþ silinecek, Emin misiniz", "PRODMA ERP", MessageBoxButtons.YesNo);
                            if (res == DialogResult.No)
                            {
                                sil = false;
                                break;
                            }
                            else
                            {
                                res = MessageBox.Show("Tüm Fiþ silinecek, Emin misiniz", "PRODMA ERP", MessageBoxButtons.YesNo);
                                if (res == DialogResult.No)
                                {
                                    sil = false;
                                    break;
                                }
                            }
                        }
                        if (sil == true)
                        {

                            this.controlNavigator1.Focus();
                            this.Sil();
                            e.Handled = islemTamamDegilSifirli;
                            this.gridControl1.Focus();
                        }
                        else
                        {
                            e.Handled = true;
                            //this.gridControl1.Focus();
                            //this.gridView1.TopRowIndex = this.gridView1.FocusedRowHandle;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Silme Yetkiniz Bulunmamaktadýr");
                        e.Handled = true;
                        return;
                    }
                  
                }
            }
            else if (e.Button == navigator.Buttons.CancelEdit)//Ýptal Ýþlemi
            {
                e.Handled = false;
            }
            YardimciIslemlerKontrols.ProgramBeklemeDurdur();
        }
        #endregion
        #region grid olaylar
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
        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)//keyboard eventler
        {
            try
            {
            if (tabControl1.SelectedTabPage != tbFisGenel || this.gridControl1.Enabled == false) return;
            INavigatableControl gr = this.gridControl1;
            bool remove = gr.IsActionEnabled(NavigatorButtonType.Remove);
            GridControl grid = sender as GridControl;
            GridView view = grid.FocusedView as GridView;
            KeyEventArgs keyArgs = new KeyEventArgs(e.KeyCode);
            if (Control.ModifierKeys == Keys.Control)
            {
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
                if (view.ActiveEditor is
      DevExpress.XtraEditors.GridLookUpEdit)
                {
                    if (e.KeyCode == Keys.Y)
                    {
                        string mt = "Get" + view.FocusedColumn.FieldName;
                        if (view.FocusedColumn.FieldName == "CARI_ID")
                        {
                            ListeYapBase yp = new ListeYapBase();
                            yp.CariFiltrele(true);
                            List<IdAdVm> lst = (from k in yp.cariFiltreList
                                       select new IdAdVm
                                       {
                                           ID = k.ID,
                                           AD = k.KOD + "-" + k.AD + " Telefon :" + k.CARITUMBILGILERVM.C_TELEFON + " Adres :" + k.CARITUMBILGILERVM.FATURA_ADRES_1 + "/" + k.CARITUMBILGILERVM.FATURA_ADRES_1 + "/" + k.CARITUMBILGILERVM.FATURA_ADRES_2 + "/" + k.CARITUMBILGILERVM.FATURA_ADRES_3,
                                       }).ToList();
                            int temp=AlanAdiIndexi[view.Name + view.FocusedColumn.FieldName];
                            bindingSourceArr[temp].DataSource = lst;
                            this.repositoryItemLookUpEdit1[temp].NullText = "";
                            this.repositoryItemLookUpEdit1[temp].DataSource = bindingSourceArr[temp];
                            this.repositoryItemLookUpEdit1[temp].DisplayMember = "AD";
                            this.repositoryItemLookUpEdit1[temp].Name = view.FocusedColumn.FieldName;
                            this.repositoryItemLookUpEdit1[temp].ValueMember = "ID";
                            detayliCariListelendi = true;
                            //Doldur();
                        }
                        else
	                    {
                             bindingSourceArr[AlanAdiIndexi[view.Name + view.FocusedColumn.FieldName]].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"", "",0 );
	                    }
        
                    }
                }
                if (e.KeyCode == Keys.R)
                {
                    YardimciIslemlerKontrols.ProgramBeklemeGoster();
                    int eskiRow = gridView1.FocusedRowHandle;
                    Doldur();
                    gridView1.FocusedRowHandle = eskiRow;
                    gridView1.TopRowIndex = eskiRow;
                    YardimciIslemlerKontrols.ProgramBeklemeDurdur();
                }
                if (e.KeyCode == Keys.G && gozlem == false)
                {
                    gozlem = true;// iki kere aciliyor
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID") != null && GenelParametreSng.Nesne().kullaniciBilgileri.ROL_ID == (int)RolEn.Admin)
                    {
                        LogDetayGozlem frm = new LogDetayGozlem();
                        frm.ID = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID");
                        frm.tabloAdi = sifirliTabloAdi;
                        frm.ShowDialog();
                        gozlem = false;
                    }
                }
            }
            else
            {

                if (e.KeyCode == Keys.F5 || e.KeyCode == Keys.F4)
                {
                    try
                    {
                        bool tanitimIste = true;
                       
                        bool yeniSatirEski = yeniSatirSifirli;
                        string[] _st = Convert.ToString(view.FocusedColumn.Tag).Split('/');
                        if (_st[0].Length > 0)
                        {
                            this.gridView1.ValidateRow -= new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
                            this.gridView1.FocusedRowChanged -= new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
                            fiskodIstedi = true;
                            this.gridControl1.Enabled = false;
                            if (tanitimIste == true)
                            {
                                Type hai = Type.GetType(_st[0], true);
                                frm = (TanitimSablon)(Activator.CreateInstance(hai));
                                frm.MdiParent = this.MdiParent;
                                frm.blnKodIstemi = true;
                                frm.KodIsteyenFisSet(this, this.gridControl1, this.gridView1, this.gridView1.FocusedColumn);
                                frm.Show();
                                if (obj != null)
                                {
                                    if (e.KeyCode == Keys.F5)
                                    { frm.KodIstemiAc(Convert.ToString(obj), 1, false); }
                                    else
                                    { frm.KodIstemiAc(Convert.ToString(obj), 2, false); }
                                    obj = null;
                                }
                                else
                                {
                                    string kod = Convert.ToString(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.FocusedColumn));
                                    frm.KodIstemiAc(kod, 0, false);
                                    obj = null;
                                }
                            }
                            yeniSatirSifirli = yeniSatirEski;
                            frm.WindowState = FormWindowState.Normal;
                            return;
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
                        FocusedRowChangedEventArgs a11 = new FocusedRowChangedEventArgs(gridView1.FocusedRowHandle, gridView1.FocusedRowHandle);
                        gridView1_FocusedRowChanged(gridView1, a11);
                        if (silme == false) { MessageBox.Show("Silme Yetkiniz Bulunmamakatadýr"); return; }
                        if (gridView1Erisim == false) { return; }
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
                            else
                            {
                                // Doldur(); //14.09 da silme isleminde ayný satýrda kalsýn diye kondu
                            }
                        }
                    }
                }
                else if (e.KeyCode == Keys.Insert)
                {
                    if (kayitEtme == false) { MessageBox.Show("Kayit Yetkiniz Bulunmamakatadýr"); return; }
                    NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator1.Buttons.EndEdit);
                    controlNavigator1_ButtonClick(controlNavigator1, args);
                    if (!args.Handled)
                    {
                        controlNavigator1.NavigatableControl.DoAction(NavigatorButtonType.EndEdit);
                    }
                }
                else if (e.KeyData == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    sonRow = sonRowBul(gridView1);
                    if (view.FocusedColumn != null && view.FocusedColumn.FieldName.ToString() == sonRow)
                    {
                        sonsutunkaydet = true;
                    }
                }
                else if (e.KeyCode == Keys.F2)
                {
                    //view.ActiveFilterCriteria = null;06062012
                    view.OptionsView.ShowAutoFilterRow = false;
                    if (kayitEtme == false) { MessageBox.Show("Kayit Yetkiniz Bulunmamakatadýr"); return; }
                    //this.gridView1.OptionsBehavior.Editable = true;
                    if (view.State == DevExpress.XtraGrid.Views.Grid.GridState.Normal || view.State == DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                    {
                        f2InitRow = true;
                        NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator1.Buttons.Append);
                        controlNavigator1_ButtonClick(controlNavigator1, args);
                        if (!args.Handled)
                        {
                            controlNavigator1.NavigatableControl.DoAction(NavigatorButtonType.Append);
                        }
                    }
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    if (escape == true)
                    {
                        //NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator1.Buttons.CancelEdit);
                        //controlNavigator1_ButtonClick(controlNavigator1, args);
                        //if (!args.Handled)
                        //{
                        //    controlNavigator1.NavigatableControl.DoAction(NavigatorButtonType.CancelEdit);
                        //}
                        //escape = false;
                        YardimciIslemlerKontrols.ProgramBeklemeGoster();
                        //Doldur();         03.10.2012
                        gridView1.TopRowIndex = gridView1.FocusedRowHandle;
                        escape = false;
                        gridView2.ShowEditor();
                        YardimciIslemlerKontrols.ProgramBeklemeDurdur();

                    }
                    else
                    {
                        escape = true;
                    }
                }
                else if (Control.ModifierKeys != Keys.Shift && e.KeyCode == Keys.F3)
                {
                    if (view.OptionsView.ShowAutoFilterRow == false)
                    {
                        view.OptionsView.ShowAutoFilterRow = true;
                        if (view.FocusedRowHandle >= 0) view.FocusedRowHandle = GridControl.AutoFilterRowHandle;
                        view.FocusedColumn = view.VisibleColumns[0];
                    }
                    else
                    {
                        view.OptionsView.ShowAutoFilterRow = false;
                        gridControl2.Focus();
                        gridView2.FocusedRowHandle = 0;
                    }
                }
                else if (e.KeyCode == Keys.F10)
                {
                    if (gridView1Erisim == false) { return; }
                    if (kayitEtme == false) { MessageBox.Show("Kayit Yetkiniz Bulunmamakatadýr"); return; }
                    NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator1.Buttons.Edit);
                    controlNavigator1_ButtonClick(controlNavigator1, args);
                    if (!args.Handled)
                    {
                        controlNavigator1.NavigatableControl.DoAction(NavigatorButtonType.Edit);
                    }
                }
                else if (e.KeyCode == Keys.F8 || e.KeyCode == Keys.Enter)
                {
                    Ikinci_Tab_Ac();
                }
                else if (e.KeyCode == Keys.F9)
                {
                    if (koplalamaDurumu.ContainsKey(AlanAdiIndexi[view.Name + view.FocusedColumn.FieldName])==false)
                    {
                        if (view.FocusedRowHandle < 0)
                        {
                            view.SetRowCellValue(view.FocusedRowHandle, view.FocusedColumn.FieldName, view.GetRowCellValue(view.RowCount-2, view.FocusedColumn.FieldName));
                        }
                        else
                        {
                            view.SetRowCellValue(view.FocusedRowHandle, view.FocusedColumn.FieldName, view.GetRowCellValue(view.RowCount - 3, view.FocusedColumn.FieldName));
                        }
                    }
                    if (view.ActiveEditor != null) view.ActiveEditor.IsModified = true;
                }
            }
            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12 || e.KeyCode == Keys.Escape)
            {
                ProcessGridKey(this.gridView1, e, this.gridView1.FocusedRowHandle, this.gridView1.FocusedColumn);
            }
            else if (Control.ModifierKeys == Keys.Control || Control.ModifierKeys == Keys.Shift)
            {
                ProcessGridKey(this.gridView1, e, this.gridView1.FocusedRowHandle, this.gridView1.FocusedColumn);
            }
                     }
          catch (Exception)
          {
            gridHelperYenile = true;
          }
        }
        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)//e.g..fis no arttiriliyor 
        {
             try
            {
            if (gridView1.FocusedRowHandle == GridControl.AutoFilterRowHandle || tabControl1.SelectedTabPage != tbFisGenel || this.gridControl1.Enabled == false) return;
            if (e.FocusedColumn == null || e.PrevFocusedColumn == null) return;
            FocusedColumnChanged(e.FocusedColumn, e.PrevFocusedColumn);
                 }
          catch (Exception)
          {
            gridHelperYenile = true;
          }
        }
        public void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)// row alinýp eski row ele geciriliyor,baglý grid iþlemi
        {
            try
            {
            if (tpMesaj != null) tpMesaj.Text = "";
            if (gridView1.FocusedRowHandle == GridControl.AutoFilterRowHandle || this.gridControl1.Enabled == false) return;
            if (gridView1.FocusedRowHandle < 0) { return; }
            if (tabControl1.SelectedTabPage == tbFisGenel || navigatoraBasildi == true || tabControl1.SelectedTabPage == tbFisSatir) // || tabControl1.SelectedTabPage == tbFisSatir siparislenen kayýtýn siparislendigi belli olmuyordu. fis_satir tabýnda iken
            {
                if (tabControl1.SelectedTabPage == tbFisGenel && fiskodIstedi==false)
                {
                    if (Convert.ToInt32(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID")) > 0) yeniSatirSifirli = false;
                }
                sonRow = sonRowBul(this.gridView1);
                ModelSifirVm = this.gridView1.GetFocusedRow();
                if (ModelSifirVm != null )
                {
                    Eski_Kayit_Al_Yukle(-1);
                }
                else
                {
                    return;// ilk defa acildiginda modelsifirVm srowa set edilmedigi icin hata vermesin.
                }
                kayitEdilemez = "";
                gridView1Erisim = true;
                gridView2Erisim = true;
                gridView2Erisim_1 = false; //  update edilebilme durumu
                satirYeniKayitAc = true;//islem yapýlamayan kayýtlarýn kontrolu
                FocusedRowChanged(e.FocusedRowHandle,e.PrevFocusedRowHandle); // iþlem yapýlmasý istenmeyen satýrlarýn override islemleri
                gridView1Erisim = true;
                focusRowChangedSonrasi();
            }
                      }
          catch (Exception)
          {
            gridHelperYenile = true;
          }
        }
        public void focusRowChangedSonrasi()
        {
            //if (sinirsizYetki == true) helperBase._donusBDeger = true;
            navigatoraBasildi = false;
            //controlNavigator1.Buttons.Remove.Enabled = true;//08072012 focusrowchnaged' e giriyor.
            if (tabControl1.SelectedTabPage != tbFisSatir)
            {
                yeniSatirSatir = false;
            }
            if (tpMesaj != null)  tpMesaj.Text = helperBase._donusMesajBoxMesaj;
            if (helperBase._donusBDeger == false)
            {
                gridView1Erisim = false;
                kayitEdilemez = helperBase._donusMesajBoxMesaj;
                tpMesaj.Text = helperBase._donusMesajBoxMesaj;
                controlNavigator1.Buttons.Remove.Enabled = false;
            }
            else
            {
                controlNavigator1.Buttons.Remove.Enabled = true;//08072012 yeni kondu.
                if (yetki!=null)
                {
                    if (silme==false)
                    {
                        controlNavigator1.Buttons.Remove.Enabled = false;
                        tpMesaj.Text = "Silme Yetkiniz Bulunmamaktadýr";
                    }
                }
            }
            if (tabControl1.SelectedTabPage == tbFisSatir)//controlnavigotar'a basildiginda  //&& gridView2.RowCount>1 iki kere satir_Doldura giriyordu
            {
                if (gridView1.FocusedRowHandle > 0 && gridView2.RowCount > 1) TabPage_Index_Changed(1);
            }
        }
        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)// baglý grid iþlemi
        {
        }
        public void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)// fis de validasyon kotrolu, sablonda kayit iþlemine gonderilmesi
        {
           try
           {
            rowHandleExcepTionMessage = "";
            if (gridView1.FocusedRowHandle == GridControl.AutoFilterRowHandle || tabControl1.SelectedTabPage != tbFisGenel || this.gridControl1.Enabled == false) 
            {
                e.Valid = false; return;
            }
            if (tabControl1.SelectedTabPage == tbFisGenel && this.gridControl1.Enabled == true)
            {
                if (sonsutunkaydet == false)
                {
                    if (gridView1.FocusedColumn == gridView1.VisibleColumns[0])
                    {
                        NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator1.Buttons.CancelEdit);
                        controlNavigator1_ButtonClick(controlNavigator1, args);
                        if (!args.Handled)
                        {
                            controlNavigator1.NavigatableControl.DoAction(NavigatorButtonType.CancelEdit);//03.10.2012
                            // YardimciIslemlerKontrols.ProgramBeklemeGoster();
                            //Doldur();//12.02.2012 DE KOYDUM. BAKILACAK.
                            //YardimciIslemlerKontrols.ProgramBeklemeDurdur();
                        }
                        rowHandleExcepTionMessage = "";
                        return;
                    }
                    else
                    {
                        gridView1.FocusedColumn = gridView1.VisibleColumns[0];
                        e.Valid = false;
                        return;
                    }
                }
                else if (Globals.gnActiveForm != this.Text)
                {
                    NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator1.Buttons.CancelEdit);
                    controlNavigator1_ButtonClick(controlNavigator1, args);
                    if (!args.Handled)
                    {
                        controlNavigator1.NavigatableControl.DoAction(NavigatorButtonType.CancelEdit);
                    }
                    rowHandleExcepTionMessage = "";
                    return;
                }
                rowHandleExcepTionMessage = "";
                ValidateRow(e.RowHandle,e.Row);
                
                if (helperBase._donusMesajBoxTip == "YesNo")
                {
                    DialogResult res = MessageBox.Show(helperBase._donusMesajBoxMesaj, "PRODMA ERP", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        blnValidateRow = true;
                    }
                    else
                    {
                        blnValidateRow = false;
                    }
                }
                else
                {
                    blnValidateRow = helperBase._donusBDeger;
                    rowHandleExcepTionMessage = helperBase._donusHataMesaj;
                    gridView1.FocusedColumn = gridView1.Columns[helperBase._donusColumnDeger];
                }

                e.Valid = blnValidateRow;
                if (e.Valid == true) e.Valid = Kayit(e.Row, e.RowHandle);
            }
          }
          catch (Exception)
          {
            gridHelperYenile = true;
          }
        }
        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)// validate row gerceklesmese gosterilecek olan mesaj
        {
             
            if (Globals.gnActiveForm == this.Text)
            {
                e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;//20..09.2011 de baska bir tanýtým ekraný acýldýgýnda validaterowda takýlý kalýyor. NOActiondý
                if (rowHandleExcepTionMessage != "")
                    MessageBox.Show(rowHandleExcepTionMessage, "PRODMA ERP");
            }
            else
            {
                e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
                Globals.mFormAc = false;
            }
        }
        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)// yeni kayýt acýlýs degeri true oluyor
        {
             try
            {
            if (gridView1.FocusedRowHandle == GridControl.AutoFilterRowHandle || tabControl1.SelectedTabPage != tbFisGenel || this.gridControl1.Enabled == false) return;
            sifirliKayitId = 0;//sýfýrlý Id yi sýfýrla
            ModelSifirVm = this.gridView1.GetFocusedRow();//modeli olustur.

            if (tpMesaj != null) tpMesaj.Text = "";// fisten geldi.
            gridView1Erisim = true;// fisten geldi.
            gridView2Erisim = true;// fisten geldi.
            gridView2Erisim_1 = true;// fisten geldi.
            kayitEdilemez = "";// fisten geldi.

            Varsayilan_Deger_Ayarla(e.RowHandle);// varsayýlan degerleri modele yerlestir.
            yeniSatirSifirli = true;//yeni satýrý ac
            blnGridView1ShowingEditor = false;
            f2InitRow = false;
            arakayit = false;
                  }
          catch (Exception)
          {
            gridHelperYenile = true;
          }
        }
        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)// fis de hucre gosterimini engelliyor
        {
            try
            {
            if (kayitEtme == false)
            {
                e.Cancel = true;
                tpMesaj.Text = "Yeni Fiþ Giriþ Yetkiniz Yoktur";
                return;
            }
            if (yeniSatirSifirli==false && guncelleme==false)
            {
                e.Cancel = true;
                //tpMesaj.Text = "Güncelleme Yetkiniz Yoktur";
                return;
            }
            else if (gridView1Erisim == false)
            {
                e.Cancel = true;
                //if (tpMesaj.Text == "") tpMesaj.Text = "Yetkiniz Yoktur";
                return;
            }
            if (gridView1.FocusedRowHandle == GridControl.AutoFilterRowHandle || tabControl1.SelectedTabPage != tbFisGenel || this.gridControl1.Enabled == false) return;
            if (sEditorColumnSifirli != this.gridView1.FocusedColumn.FieldName.ToString() || sEditorRowSifirli != this.gridView1.FocusedRowHandle)
            {
                blnGridView1ShowingEditor = false;
                ShowingEditor();
                blnGridView1ShowingEditor = helperBase._donusBDegerFalse;
            }
            e.Cancel = blnGridView1ShowingEditor;
            sEditorRowSifirli = this.gridView1.FocusedRowHandle;
            sEditorColumnSifirli = this.gridView1.FocusedColumn.FieldName.ToString();
                   }
          catch (Exception)
          {
            gridHelperYenile = true;
          }
            
        }
        public void gridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)// fisde hucre validasyonunu gerceklestiriyor
        {
            try
            {
            if (gridView1.FocusedRowHandle == GridControl.AutoFilterRowHandle || tabControl1.SelectedTabPage != tbFisGenel || this.gridControl1.Enabled == false) return;
            errorTextValidatingEditor = "";
            blnValidatingEditor = true;
            if (e.Value != null) ValidatingEditor(e.Value);
            if (helperBase._donusMesajBoxMesaj != "")
            {
                DialogResult res = MessageBox.Show(helperBase._donusMesajBoxMesaj, "PRODMA ERP", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    blnValidatingEditor = true;
                    gridView1.SetRowCellValue(gridView1.FocusedRowHandle, gridView1.FocusedColumn, e.Value);
                }
                else
                {
                    blnValidatingEditor = false;
                }
            }
            else
            {
                blnValidatingEditor = helperBase._donusBDeger;
                errorTextValidatingEditor = helperBase._donusHataMesaj;
            }
            e.ErrorText = errorTextValidatingEditor;
            e.Valid = blnValidatingEditor;
               }
          catch (Exception)
          {
            gridHelperYenile = true;
          }
        }
        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e) //gride arama ekliyor.
        {
            //try
            //{
            //    int width = e.Bounds.Width;
            //    textArama[e.Column.VisibleIndex].Width = width;
            //    textArama[e.Column.VisibleIndex].Size = new System.Drawing.Size(e.Bounds.Width, e.Bounds.Height);
            //    textArama[e.Column.VisibleIndex].TabIndex = 0;
            //    textArama[e.Column.VisibleIndex].Location = new System.Drawing.Point(e.Bounds.Left, textArama[e.Column.VisibleIndex].Location.Y);
            //    //Dinamik_TextBox_Olustur(sender, e);
            //}
            //catch (Exception)
            //{
                
            //}
            
        }
        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            try
            {
            if (gridView1.FocusedRowHandle == GridControl.AutoFilterRowHandle || tabControl1.SelectedTabPage != tbFisGenel || this.gridControl1.Enabled == false) return;
            if (yeniSatirSifirli == true) gridView1.ActiveEditor.IsModified = true;
            GridView gridView = (GridView)sender;
            if (gridView.FocusedColumn.FieldName == "CARI_ADRES_ID" && gridView.ActiveEditor is
DevExpress.XtraEditors.GridLookUpEdit)
            {
               
                DevExpress.XtraEditors.GridLookUpEdit edit;
                edit = (DevExpress.XtraEditors.GridLookUpEdit)gridView.ActiveEditor;
                int introw = this.gridView1.FocusedRowHandle;
                int ust_id = Convert.ToInt32(this.gridView1.GetRowCellValue(introw, "CARI_ID"));
                edit.Properties.DataSource = ListDenemeService.GetCARI_ADRES_ID_BY_PARAM(0, ust_id);
                edit.Properties.DisplayMember = "AD";
                edit.Properties.ValueMember = "ID";
             //   edit.View.Columns[0].Visible = false;  
            }
            ShownEditor();
                   }
          catch (Exception)
          {
            gridHelperYenile = true;
          }
        }
        private void gridView1_BeforeLeaveRow(object sender, RowAllowEventArgs e)
        {
            try
            {
            YardimciIslemlerKontrols.ProgramBeklemeGoster();
            if (gridView1.FocusedRowHandle == GridControl.AutoFilterRowHandle || tabControl1.SelectedTabPage != tbFisGenel || this.gridControl1.Enabled == false) return;
            GridView view = (GridView)sender;
            if ((view.GetRowCellValue(view.FocusedRowHandle, "ID") == null || Convert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "ID")) == 0) && view.FocusedRowHandle >= 0)
            {
                Doldur();
            }
            else if (view.GetRowCellValue(view.FocusedRowHandle, "ID") != null )
            {
                if (Convert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "ID")) != sifirliKayitId)
                {
                    Doldur();
                }
            }
            YardimciIslemlerKontrols.ProgramBeklemeDurdur();
            }
            catch (Exception)
            {
                gridHelperYenile = true;
            }
            //if (yeniSatirSifirli==true) e.Allow = false;
        }
        private void gridView1_CustomDrawFooter(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
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
        private void Arama(object sender, EventArgs e)
        {
            Object aVm;
            for (int i = 0; i < this.gridView1.RowCount; i++)
            {
                aVm = this.gridView1.GetRow(i);
                //if (temp.IRSALIYE_NO != null)
                //{
                //    int result = 0;// temp.IRSALIYE_NO.CompareTo(textEdit1.Text);
                //    if (result > 0)
                //    {
                //        this.gridView1.FocusedRowHandle = i;
                //        break;
                //    }
                //}
            }
        }
        #endregion
        #endregion
        #region SATIR
        #region olaylar
        private void printableComponentLink2_CreateReportHeaderArea(object sender, DevExpress.XtraPrinting.CreateAreaEventArgs e)
        {
            string d = this.gridView2.FilterPanelText;
            DevExpress.XtraPrinting.TextBrick brick;
            brick = e.Graph.DrawString(tbFisSatir.Text, Color.Navy, new RectangleF(0, 0, 500, 40), DevExpress.XtraPrinting.BorderSide.None);
            brick.Font = new Font("Tahoma", 8);
            brick.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);
            DevExpress.XtraPrinting.TextBrick brick1;
            brick1 = e.Graph.DrawString(d, Color.Navy, new RectangleF(0, 30, 500, 40), DevExpress.XtraPrinting.BorderSide.None);
            brick1.Font = new Font("Tahoma", 8);
            brick1.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);
        }
        public void customButonIslemleriSatir(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == "Yazdir")
            {
                if (this.popupMenu2.Manager != null)
                {
                    FieldInfo fi = typeof(NavigatorButtonsBase).GetField("viewInfo", BindingFlags.Instance | BindingFlags.NonPublic);
                    NavigatorButtonsViewInfo buttonsViewInfo = (NavigatorButtonsViewInfo)fi.GetValue(controlNavigator2.ViewInfo.Buttons);
                    Point mousePosition = controlNavigator2.PointToClient(Control.MousePosition);
                    NavigatorButtonViewInfo buttonViewInfo = buttonsViewInfo.ButtonViewInfoAt(mousePosition);
                    Point menuPosition = new Point(buttonViewInfo.Bounds.Left, buttonViewInfo.Bounds.Bottom);
                    menuPosition = controlNavigator2.PointToScreen(menuPosition);
                    popupMenu2.ShowPopup(menuPosition);
                }
                else
                {
                    printableComponentLink2.CreateDocument();
                    printableComponentLink2.ShowPreview();
                }
                
            }
            else
            {
                Custom_Buton_Islemleri_Satir(e.Button.Tag.ToString());
                if (helperBase._donusBDeger == true)
                {
                    //gridView2.FocusedColumn = gridView2.Columns["STOK_ID"];
                    ActiveControl = (Control)this.gridControl2;
                    gridControl2.Enabled = true;
                    gridView2.OptionsSelection.EnableAppearanceFocusedCell = true;
                    Satir_Doldur(0);
                }
                else
                {
                    DevExpress.XtraGrid.Columns.GridColumn _FocusedColumn = gridView2.FocusedColumn;
                    if (gridYenileme==false)
                    {
                        gridView2.RefreshData();                        
                    }
                    gridView2.FocusedColumn = _FocusedColumn;
                }
                gridView2.TopRowIndex = gridView2.FocusedRowHandle;
            }
            
        }
        private void KayitaGonderSatir(bool kaydet)
        {
            if (kaydet == false)
            {
                NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator2.Buttons.CancelEdit);
                controlNavigator2_ButtonClick(controlNavigator2, args);
                if (!args.Handled)
                {
                    controlNavigator2.NavigatableControl.DoAction(NavigatorButtonType.CancelEdit);
                }
            }
            else
            {
                degisikligeBagliSayfaDoldur = true;
                NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator2.Buttons.EndEdit);
                controlNavigator2_ButtonClick(controlNavigator2, args);
                if (!args.Handled)
                {
                    controlNavigator2.NavigatableControl.DoAction(NavigatorButtonType.EndEdit);
                }
            }
        }
        private bool KayitSatir(Object row, int rowHandle)
        {
            if (sonsutunkaydetsatir == true)
            {
                KayitaGonderSatir(true);
                sonsutunkaydetsatir = false;
            }
            else
            {
                //gridView2.FocusedColumn = gridView2.Columns[sonRow];
                //return false;
                //DialogResult res = MessageBox.Show("Onayla?", "Kayýt Yapýlsýn Mý", MessageBoxButtons.YesNo);
                //if (res == DialogResult.Yes)
                //{
                //    KayitaGonderSatir(true);
                //}
                //else
                //{
                //    if (yeniSatirSatir == true)
                //    {
                //        rowHandleExcepTionMessage_Satir = ""; 
                //        return false;
                //    }
                //    else
                //    {
                //        Eski_Kayit_Al_Yukle_Satir(rowHandle);
                //    }
                //}
            }
            yeniSatirSatir = false;
            if (islemTamamDegilSatir == true) { rowHandleExcepTionMessage_Satir = "Bilinmeyen Bir Hata Oluþtu"; } return !islemTamamDegilSatir;
        }
        #endregion
        #region satirolaylar virtual
        public virtual void Custom_Buton_Islemleri_Satir(string islem) { }
        public virtual void Bar_Manager_Islemleri_Satir(string islem) { }
        public virtual void Varsayilan_Deger_Ayarla_Satir(int focusedRow) { }
        public virtual void Kaydet_Satir() { }
        public virtual void Yeni_Kayit_Satir() { }
        public virtual void Sil_Satir() { }
        public virtual void Yazdir_Satir() { }
        public virtual void Bul_Satir() { }
        public virtual void Vazgec_Satir() { }
        public virtual void ShowingEditor_Satir() { }
        public virtual void ValidateRow_Satir(int FocusedRowHandle,object row) { }
        public virtual void Eski_Kayit_Al_Yukle_Satir(int rowHandle) { }
        public virtual void ValidatingEditor_Satir(object value) { }
        public virtual void FocusedColumnChanged_Satir( DevExpress.XtraGrid.Columns.GridColumn FocusedColumn, DevExpress.XtraGrid.Columns.GridColumn PrevFocusedColumn) { }
        public virtual void ProcessGridKey_Satir(GridView view, KeyEventArgs args, int FocusedRowHandle, DevExpress.XtraGrid.Columns.GridColumn FocusedColumn) { }
        public virtual void FocusedRowChanged_Satir(int focusedRow, int prevFocusedRow) { }
        public virtual void FocusedRowChanged_Bos_Satir(int focusedRow, int prevFocusedRow) { }
        public virtual void ShownEditor_Satir() { }
        public virtual void BeforeLeaveRow_Satir(Object sender) { }
        public virtual void CellValueChanged_Satir(Object sender, CellValueChangedEventArgs e) { }
        public virtual void Satir_Doldur(int index) { }
        public virtual bool Satir_Silme_Kontrol() { return false; }
        #endregion
        #region kontroller
        public void controlNavigator2_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            YardimciIslemlerKontrols.ProgramBeklemeGoster();
            ControlNavigator navigator = (ControlNavigator)sender;
            if (e.Button.ButtonType == NavigatorButtonType.Custom)
            {
                if (e.Button.Tag.ToString() == "Yazdir")
                {
                    if (this.popupMenu2.Manager != null)
                    {
                        try
                        {
                            FieldInfo fi = typeof(NavigatorButtonsBase).GetField("viewInfo", BindingFlags.Instance | BindingFlags.NonPublic);
                            NavigatorButtonsViewInfo buttonsViewInfo = (NavigatorButtonsViewInfo)fi.GetValue(controlNavigator2.ViewInfo.Buttons);
                            Point mousePosition = controlNavigator1.PointToClient(Control.MousePosition);
                            NavigatorButtonViewInfo buttonViewInfo = buttonsViewInfo.ButtonViewInfoAt(mousePosition);
                            Point menuPosition = new Point(buttonViewInfo.Bounds.Left, buttonViewInfo.Bounds.Bottom);
                            menuPosition = controlNavigator2.PointToScreen(menuPosition);
                            popupMenu2.ShowPopup(menuPosition);
                        }
                        catch (Exception)
                        {
                            printableComponentLink2.CreateDocument();
                            printableComponentLink2.ShowPreview();
                        }
                        
                    }
                    else
                    {
                        printableComponentLink2.CreateDocument();
                        printableComponentLink2.ShowPreview();
                    }
                }
              
                else
                {
                    customButonIslemleriSatir(sender, e);
                }
            }
            else if (e.Button == navigator.Buttons.Append)// Yeni kayýda basildiginda direk kayida hazir olunmasi icin
            {
                if (kayitEtme == false)
                {
                    MessageBox.Show("Kayit Yetkiniz Bulunmamakatadýr");
                    e.Handled = true;
                    return;
                }
            }
            else if (e.Button == navigator.Buttons.EndEdit)//Kaydete basildiginda grid tabinda ise
            {
                if (yeniSatirSatir == false)
                {
                    Kaydet_Satir();
                    degisikligeBagliSayfaDoldur = true;
                }
                else
                {
                    this.Yeni_Kayit_Satir();
                    Globals.SifirliKayitKontrol = true;
                }
                e.Handled = islemTamamDegilSatir;
                //this.Satir_Doldur(0);
            }
            else if (e.Button == navigator.Buttons.Remove)//Sil Ýþlemi
            {
                FocusedRowChangedEventArgs a11 = new FocusedRowChangedEventArgs(gridView1.FocusedRowHandle, gridView1.FocusedRowHandle);
                gridView1_FocusedRowChanged(gridView1, a11);
                if (this.gridView2.FocusedRowHandle < 0 || gridView1Erisim == false)
                {
                    e.Handled = true; return;
                }
                else if (gridView2.FocusedColumn.Name == "")
                {
                    return;
                }
                else if (this.gridView2.FocusedRowHandle < 0)
                {
                    e.Handled = true; return;
                }
                else
                 {
                     if (yeniSatirSifirli==true || silme == true || Satir_Silme_Kontrol()==true)
                     {
                         DialogResult res = MessageBox.Show("Seçili Satýr kaydý silinecek, Emin misiniz ?", "PRODMA ERP", MessageBoxButtons.YesNo);
                         if (res == DialogResult.Yes)
                         {
                             this.Sil_Satir();
                             //this.controlNavigator2.Focus();
                             e.Handled = true;// islemTamamDegilSatir;
                             Satir_Doldur(0);
                             degisikligeBagliSayfaDoldur = true;
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
                }
            }
            else if (e.Button == navigator.Buttons.CancelEdit)//Ýptal Ýþlemi
            {
                e.Handled = false;
            }
            YardimciIslemlerKontrols.ProgramBeklemeDurdur();
        }
        #endregion
        #region grid olaylar
        private void gridView2_ShowGridMenu(object sender, DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs e)
        {
            GridView view = (GridView)sender;
            GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
           // if (hitInfo.InRow)
           // {
                //view.FocusedRowHandle = hitInfo.RowHandle;
                ContextMenu1Satir.Show(view.GridControl, e.Point);
           // }
        }
        private void gridControl2_ProcessGridKey(object sender, KeyEventArgs e)
        {
          try
          {
            if (tabControl1.SelectedTabPage != tbFisSatir || this.gridControl2.Enabled == false) return;
            INavigatableControl gr = this.gridControl2;
            bool remove = gr.IsActionEnabled(NavigatorButtonType.Remove);
            GridControl grid = sender as GridControl;
            GridView view = grid.FocusedView as GridView;
            KeyEventArgs keyArgs = new KeyEventArgs(e.KeyCode);

            if (Control.ModifierKeys == Keys.Control)
            {
                if (e.KeyCode == Keys.F1)
                {
                    if (gridView2.Columns["ID"].Visible == false)
                    {
                        gridView2.Columns["ID"].Visible = true;
                    }
                    else
                    {
                        gridView2.Columns["ID"].Visible = false;
                    }
                }
                else if (e.KeyCode == Keys.F5)
                {
                    if (gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "STOK_ID") != null)
                    {
                        //Stok_Ambar_Gozlem frm = new Stok_Ambar_Gozlem();
                        //frm.stokId = (int)gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "STOK_ID");
                        //frm.ShowDialog();
                        StokIliskiliListeler frm = new StokIliskiliListeler();
                        frm.stokId = (int)gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "STOK_ID");
                        frm.ShowDialog();
                        gozlem = false;
                    }
                }
                else if (e.KeyCode == Keys.Y)
                {
                    int index = gridView2.VisibleColumns.Count - 1;
                    string mt = "Get" + view.FocusedColumn.FieldName;
                    if (view.ActiveEditor is
   DevExpress.XtraEditors.GridLookUpEdit)
                    {
                        bindingSourceArr[AlanAdiIndexi[view.Name + view.FocusedColumn.FieldName]].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"", "",0 );
                    }
                }
                else if (e.KeyCode == Keys.F2)
                {
                    f2InitRow_Satir = true;
                    arakayit = true;
                    if (view.State == DevExpress.XtraGrid.Views.Grid.GridState.Normal)
                    {
                        NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator2.Buttons.Append);
                        controlNavigator2_ButtonClick(controlNavigator2, args);
                        if (!args.Handled)
                        {
                            controlNavigator2.NavigatableControl.DoAction(NavigatorButtonType.Append);
                        }
                    }
                    return;
                }
                if (e.KeyCode == Keys.R)
                {
                    Satir_Doldur(0);
                }
                if (e.KeyCode == Keys.G && gozlem == false)
                {
                    gozlem = true;// iki kere aciliyor
                    if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID") != null && GenelParametreSng.Nesne().kullaniciBilgileri.ROL_ID == (int)RolEn.Admin)
                    {
                        LogDetayGozlem frm = new LogDetayGozlem();
                        frm.ID = (int)gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ID");
                        frm.tabloAdi = satirTabloAdi;
                        frm.ShowDialog();
                        gozlem = false;
                    }
                }
            }
            else
            {

                if (e.KeyCode == Keys.F5 || e.KeyCode == Keys.F4 || (Control.ModifierKeys == Keys.Shift && e.KeyCode == Keys.F2))
                {
                    try
                    {
                        bool yeniSatirEski = yeniSatirSatir;
                        string[] _st = Convert.ToString(view.FocusedColumn.Tag).Split('/');
                        if (_st[0].Length > 0)
                        {
                            //gridView2.AddNewRow();
                            //f2InitRow_Satir = true;
                            //controlNavigator2.NavigatableControl.DoAction(NavigatorButtonType.Append);
                            this.gridView2.ValidateRow -= new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView2_ValidateRow);
                            this.gridView2.FocusedRowChanged -= new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView2_FocusedRowChanged);
                            // this.gridView2.ValidatingEditor -= new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView2_ValidatingEditor);
                            //view.FocusedRowChanged -= new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView2_FocusedRowChanged);
                            
                            fiskodIstedi = true;
                            this.gridControl2.Enabled = false;
                            Type hai = Type.GetType(_st[0], true);
                            frm = (TanitimSablon)(Activator.CreateInstance(hai));
                            frm.MdiParent = this.MdiParent;
                            frm.blnKodIstemi = true;
                            frm.KodIsteyenFisSet(this, this.gridControl2, this.gridView2, this.gridView2.FocusedColumn);
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
                                string kod = Convert.ToString(this.gridView2.GetRowCellValue(this.gridView2.FocusedRowHandle, this.gridView2.FocusedColumn));
                                frm.KodIstemiAc(kod, 0, false);//secili kayýt icin
                                obj = null;
                            }
                            yeniSatirSatir = yeniSatirEski;
                            frm.WindowState = FormWindowState.Normal;
                            return;
                        }
                    }
                    catch (Exception)
                    {
                        this.gridView2.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView2_ValidateRow);
                        this.gridView2.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView2_FocusedRowChanged);
                        this.gridControl1.Enabled = true;
                        view.OptionsSelection.EnableAppearanceFocusedCell = true;
                        view.ShowEditor();
                        ProcessGridKey(this.gridView2, e, this.gridView2.FocusedRowHandle, this.gridView2.FocusedColumn);
                    }

                }
                else if (e.KeyCode == Keys.Delete)
                {
                    if (gridView1.FocusedRowHandle != GridControl.AutoFilterRowHandle)
                    {
                        FocusedRowChangedEventArgs a11 = new FocusedRowChangedEventArgs(gridView1.FocusedRowHandle, gridView1.FocusedRowHandle);
                        gridView1_FocusedRowChanged(gridView1, a11);
                        if (gridView1Erisim == false)
                        {
                            MessageBox.Show("Seçtiðiniz Kayýt Güncellenmiþ. Silme Yapamazsýnýz");
                        }
                        if (yeniSatirSifirli == false && silme == false && Satir_Silme_Kontrol() == false) { MessageBox.Show("Silme Yetkiniz Bulunmamakatadýr"); return; }
                        if (remove == true)
                        {
                            NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator2.Buttons.Remove);
                            controlNavigator2_ButtonClick(controlNavigator2, args);
                            if (!args.Handled)
                            {
                                int fRow = gridView2.FocusedRowHandle;
                                controlNavigator2.NavigatableControl.DoAction(NavigatorButtonType.Remove);
                                Sifirli_Sil_Kontrol();
                                Satir_Doldur(0);
                                if (gridView2.RowCount == 0)
                                {
                                    Globals.SifirliKayitKontrol = false;
                                }
                                else if (gridView2.RowCount == 1)
                                {
                                    int id = Convert.ToInt32(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ID"));
                                    if (id == 0) Globals.SifirliKayitKontrol = false;
                                }
                                if (gridView2.FocusedRowHandle == 0)
                                {
                                    gridView2.FocusedRowHandle = fRow - 1;
                                    //FocusedRowChangedEventArgs a1 = new FocusedRowChangedEventArgs(fRow-1, fRow-1);
                                    //gridView2_FocusedRowChanged(gridView2, a1);
                                    gridView2.TopRowIndex = gridView2.FocusedRowHandle;
                                }
                                gridView2.TopRowIndex = gridView2.FocusedRowHandle; // 15.03.2012' de ikinci sayfa silmede bulundu satýrda gosterim kalsýn diye koydum
                            }
                        }
                    }
                }
                else if (e.KeyCode == Keys.Insert)
                {
                    if (kayitEtme == false) { MessageBox.Show("Kayit Yetkiniz Bulunmamakatadýr"); return; }
                    NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator2.Buttons.EndEdit);
                    controlNavigator2_ButtonClick(controlNavigator2, args);
                    if (!args.Handled)
                    {
                        controlNavigator2.NavigatableControl.DoAction(NavigatorButtonType.EndEdit);
                    }
                }
                else if (e.KeyData == Keys.Enter || e.KeyCode == Keys.Tab)
                {
                    if (gridView1.FocusedRowHandle != GridControl.AutoFilterRowHandle)
                    {
                        if (kayitEtme == false) { MessageBox.Show("Kayit Yetkiniz Bulunmamakatadýr"); return; }
                        sonRow = sonRowBul(gridView2);
                        if (view.FocusedColumn != null && view.FocusedColumn.FieldName.ToString() == sonRow)
                        {
                            sonsutunkaydetsatir = true;
                            if (gridView2.FocusedRowHandle < 0 || gridView2.FocusedRowHandle == gridView2.RowCount - 2)
                            {
                                NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator2.Buttons.Append);
                                controlNavigator2_ButtonClick(controlNavigator2, args);
                                if (!args.Handled)
                                {
                                    controlNavigator2.NavigatableControl.DoAction(NavigatorButtonType.Append);
                                }
                            }
                        }
                    }

                }
                else if (e.KeyCode == Keys.Escape)
                {
                        if (this.gridView1.IsDefaultState == true && gridView2.FocusedColumn==gridView2.VisibleColumns[0])
                        {
                            TabPage_Index_Changed(1);
                        }
                    //if (escape == true)
                    //{
                    //    TabPage_Index_Changed(1);
                    //    escape = false;
                    //    gridView2.ShowEditor();
                    //}
                    //else
                    //{
                    //    escape = true;
                    //}

                }
                else if (e.KeyCode == Keys.F2 && yeniSatirSatir==false)
                {
                    if (kayitEtme == false) { MessageBox.Show("Kayit Yetkiniz Bulunmamakatadýr"); return; }
                    f2InitRow_Satir = true;
                    if (view.State == DevExpress.XtraGrid.Views.Grid.GridState.Normal || view.State == DevExpress.XtraGrid.Views.Grid.GridState.Editing)
                    {
                        NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator2.Buttons.Append);
                        controlNavigator2_ButtonClick(controlNavigator2, args);
                        if (!args.Handled)
                        {
                            controlNavigator2.NavigatableControl.DoAction(NavigatorButtonType.Append);
                        }
                    }
                }
                else if (e.KeyCode == Keys.F10)
                {
                    if (kayitEtme == false) { MessageBox.Show("Kayit Yetkiniz Bulunmamakatadýr"); return; }
                    NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator2.Buttons.Edit);
                    controlNavigator2_ButtonClick(controlNavigator2, args);
                    if (!args.Handled)
                    {
                        controlNavigator2.NavigatableControl.DoAction(NavigatorButtonType.Edit);
                    }
                }
                else if (Control.ModifierKeys != Keys.Shift && e.KeyCode == Keys.F3)
                {
                    if (view.OptionsView.ShowAutoFilterRow == false)
                    {
                        view.OptionsView.ShowAutoFilterRow = true;
                        if (view.FocusedRowHandle >= 0) view.FocusedRowHandle = GridControl.AutoFilterRowHandle;
                        view.FocusedColumn = view.VisibleColumns[0];
                    }
                    else
                    {
                        view.OptionsView.ShowAutoFilterRow = false;
                        gridControl2.Focus();
                    }
                }
                else if (e.KeyCode == Keys.F9)
                {
                    if (view.FocusedRowHandle < 0)
                    {
                        view.SetRowCellValue(view.FocusedRowHandle, view.FocusedColumn.FieldName, view.GetRowCellValue(view.RowCount - 2, view.FocusedColumn.FieldName));
                    }
                    else
                    {
                        view.SetRowCellValue(view.FocusedRowHandle, view.FocusedColumn.FieldName, view.GetRowCellValue(view.RowCount - 3, view.FocusedColumn.FieldName));
                    }
                    if (view.ActiveEditor != null) view.ActiveEditor.IsModified = true;
                }
            }
            if (e.KeyCode == Keys.F1 || e.KeyCode == Keys.F5 || e.KeyCode == Keys.F6 || e.KeyCode == Keys.F7 || e.KeyCode == Keys.F8 || e.KeyCode == Keys.F9 || e.KeyCode == Keys.F11 || e.KeyCode == Keys.F12 || e.KeyCode == Keys.Escape)
            {
                ProcessGridKey_Satir(this.gridView2, e, this.gridView2.FocusedRowHandle, this.gridView2.FocusedColumn);
            }
            else if (Control.ModifierKeys == Keys.Control || Control.ModifierKeys == Keys.Shift)
            {
                ProcessGridKey_Satir(this.gridView2, e, this.gridView2.FocusedRowHandle, this.gridView2.FocusedColumn);
            }
          }
          catch (Exception)
          {
            gridHelperYenile = true;
          }
        }
        private void gridView2_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
          try
          {
           if (gridView2.FocusedRowHandle == GridControl.AutoFilterRowHandle || tabControl1.SelectedTabPage != tbFisSatir || this.gridControl2.Enabled == false) return;
           if (e.FocusedColumn == null || e.PrevFocusedColumn == null) return;
           FocusedColumnChanged_Satir(e.FocusedColumn, e.PrevFocusedColumn);
          }
          catch (Exception)
          {
            gridHelperYenile = true;
          }
           //if (yeniSatirSatir==false)
           //{
           //    FocusedRowChanged(gridView1.FocusedRowHandle, gridView1.FocusedRowHandle); // iþlem yapýlmasý istenmeyen satýrlarýn override islemleri
           //    //focusRowChangedSonrasi();
           //    if (helperBase._donusBDeger == false)
           //    {
           //        gridView1Erisim = false;
           //    }
           //    else
           //    {
           //        gridView1Erisim = true;
           //    }
           //}
        }
        public void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
          try
          {
            if (gridView2.FocusedRowHandle == GridControl.AutoFilterRowHandle || tabControl1.SelectedTabPage != tbFisSatir || this.gridControl2.Enabled == false) return;
            if (gridView2.FocusedRowHandle >= 0 && yeniSatirSatir == false) { Globals.SifirliKayitKontrol = true; }
            sonRow = sonRowBul(this.gridView2);
            ModelSatirVm = this.gridView2.GetFocusedRow();
            if (ModelSatirVm == null) { FocusedRowChanged_Bos_Satir(e.FocusedRowHandle, e.PrevFocusedRowHandle); return; }
            if (Convert.ToInt32(gridView2.GetRowCellValue(gridView2.FocusedRowHandle,"ID"))>0) yeniSatirSatir = false;
            if (ModelSatirVm != null) Eski_Kayit_Al_Yukle_Satir(-1);
            FocusedRowChanged_Satir(e.FocusedRowHandle,e.PrevFocusedRowHandle);
            if (helperBase._donusBDeger == false)
            {
                gridView2Erisim = false;
                if (helperBase._donusMesajBoxMesaj != "") tpMesaj.Text = helperBase._donusMesajBoxMesaj;
                controlNavigator2.Buttons.Remove.Enabled = false;               
            }
            else if (gridView1Erisim == false)
            {
                gridView2Erisim = false;
                controlNavigator2.Buttons.Remove.Enabled = false;         
            }
            else
            {
                controlNavigator2.Buttons.Remove.Enabled = true;
                if (yetki != null)
                {
                    if (silme == false && yeniSatirSifirli==false)
                    {
                        controlNavigator2.Buttons.Remove.Enabled = false;
                        tpMesaj.Text = "Silme Yetkiniz Bulunmamaktadýr";
                    }
                }
            }
           }
           catch (Exception)
           {
               gridHelperYenile = true;
           }
        }
        private void gridView2_ShownEditor(object sender, EventArgs e)
        {
            try
            {
                if (gridView2.ActiveEditor != null) gridView2.ActiveEditor.IsModified = true;// tum sutunlarin validateedtore girmesi icin
                focusedColumValue = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.FocusedColumn);
                ShownEditor_Satir();
            }
            catch (Exception)
            {
                gridHelperYenile = true;

            }
        }
        public void gridView2_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            try
            {
                    if (gridView2.FocusedRowHandle == GridControl.AutoFilterRowHandle || tabControl1.SelectedTabPage != tbFisSatir || this.gridControl2.Enabled == false) { e.Valid = false; return; }
                    rowHandleExcepTionMessage_Satir = "";
                    if (sonsutunkaydetsatir == false)
                    {
                        if (gridView2.FocusedColumn == gridView2.VisibleColumns[0])
                        {

                            TabPage_Index_Changed(1);
                            return;
                        }
                        else
                        {
                            gridView2.FocusedColumn = gridView2.VisibleColumns[0];
                            e.Valid = false;
                            return;
                        }
                    }
                    else if (Globals.gnActiveForm != this.Text)
                    {
                        NavigatorButtonClickEventArgs args = new NavigatorButtonClickEventArgs(controlNavigator2.Buttons.CancelEdit);
                        controlNavigator2_ButtonClick(controlNavigator2, args);
                        if (!args.Handled)
                        {
                            controlNavigator2.NavigatableControl.DoAction(NavigatorButtonType.CancelEdit);
                        }
                        rowHandleExcepTionMessage = "";
                        return;
                    }
                    rowHandleExcepTionMessage_Satir = "";
                    if (ModelSatirVm == null) return; // 12.02.2012 tarihinde eklendi. 

             
                    FocusedRowChanged(gridView1.FocusedRowHandle, gridView1.FocusedRowHandle); // iþlem yapýlmasý istenmeyen satýrlarýn override islemleri
                    //focusRowChangedSonrasi();
                    if (helperBase._donusBDeger == false)
                    {
                        gridView1Erisim = false;
                        e.Valid = false;
                        MessageBox.Show("Fiþ Giriþ Kaydý Güncellenmiþ Satýr Kayýt Ýþlemi Yapmazýnýz");
                        return;
                    }
                    else
                    {
                        gridView1Erisim = true;
                    }
                    ValidateRow_Satir(e.RowHandle,e.Row);
                    if (helperBase._donusMesajBoxTip == "YesNo")
                    {
                        DialogResult res = MessageBox.Show(helperBase._donusMesajBoxMesaj, "PRODMA ERP", MessageBoxButtons.YesNo);
                        if (res == DialogResult.Yes)
                        {
                            blnValidateRow_Satir = true;
                        }
                        else
                        {
                            blnValidateRow_Satir = false;
                        }
                    }
                    else
                    {
                        blnValidateRow_Satir = helperBase._donusBDeger;
                        rowHandleExcepTionMessage_Satir = helperBase._donusHataMesaj;
                        gridView2.FocusedColumn = gridView2.Columns[helperBase._donusColumnDeger];
                        gridView2.ShowEditor();
                    }
                    e.Valid = blnValidateRow_Satir;
                    if (e.Valid == true)
                    {
                        e.Valid = KayitSatir(e.Row, e.RowHandle);
                        if (arakayit==true)
                        {
                            this.Satir_Doldur(0);
                        }
                    }
                    arakayit = false;
            }
            catch (Exception)
            {
                blnValidateRow_Satir = false;
                rowHandleExcepTionMessage_Satir = "Bilinmeyen Bir Hata Oluþtu";
                gridHelperYenile = true;
            }
        }
        private void gridView2_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                if (gridView2.FocusedRowHandle == GridControl.AutoFilterRowHandle || tabControl1.SelectedTabPage != tbFisSatir || this.gridControl2.Enabled == false) return;
                ModelSatirVm = this.gridView2.GetFocusedRow();
                Varsayilan_Deger_Ayarla_Satir(e.RowHandle);// varsayýlan degerleri modele yerlestir. f2 ile gelmesi ile alt satir gelisi farklý yere olursa diye degiskenle gidiyor
                yeniSatirSatir = true;
                blnGridView1ShowingEditor_Satir = false;
                f2InitRow_Satir = false;
                sonRow = sonRowBul(this.gridView2);
            }
             catch (Exception)
             {
                 gridHelperYenile = true;
             }
            //arakayit = false;
        }
        private void gridView2_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            if (Globals.mFormAc == false)
            {
                e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
                if (rowHandleExcepTionMessage_Satir != "")
                    MessageBox.Show(rowHandleExcepTionMessage_Satir,"PRODMA ERP");
            }
            else
            {
                e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
                Globals.mFormAc = false; 
            }
        }
        public void gridView2_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            //if (gridView1Erisim == false)
            //{
            //    e.ErrorText = "Grid Ulaþýlamaz";
            //    e.Valid = false;
            //    return;
            //}
             try
            {
                Globals.gnActiveForm = this.Text;
                if (gridView2.FocusedRowHandle == GridControl.AutoFilterRowHandle || tabControl1.SelectedTabPage != tbFisSatir || this.gridControl2.Enabled==false) return;
                errorTextValidatingEditor_Satir = "";
                blnValidatingEditor_Satir = true;
               // if (e.Value != null) ValidatingEditor_Satir(e.Value, this.gridView2.FocusedRowHandle, this.gridView2.FocusedColumn);
                ValidatingEditor_Satir(e.Value); // faturada bos satirda gectigi icin yukardakiyle degistirildi

                if (helperBase._donusBDeger == false)
                {
                    blnValidatingEditor_Satir = helperBase._donusBDeger;
                    errorTextValidatingEditor_Satir = helperBase._donusHataMesaj;
                } 
                else if (helperBase._donusMesajBoxTip == "Yes" && helperBase._donusMesajBoxMesaj != "")
                {
                    MessageBox.Show(helperBase._donusMesajBoxMesaj);
                    blnValidatingEditor_Satir = true;
                }
                else if (helperBase._donusMesajBoxMesaj != "")
                {
                    DialogResult res = MessageBox.Show(helperBase._donusMesajBoxMesaj, "PRODMA ERP", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        blnValidatingEditor_Satir = true;
                    }
                    else
                    {
                        blnValidatingEditor_Satir = false;
                    }
                }
                else
                {
                    blnValidatingEditor_Satir = helperBase._donusBDeger;
                    errorTextValidatingEditor_Satir = helperBase._donusHataMesaj;
                }
                e.ErrorText = errorTextValidatingEditor_Satir;
                e.Valid = blnValidatingEditor_Satir;
            }
             catch (Exception)
             {
                 gridHelperYenile = true;
                 blnValidatingEditor_Satir = false;
                 errorTextValidatingEditor_Satir = "Bilinmeyen Bir Hata Oluþtu";
             }
        }
        private void gridView2_ShowingEditor(object sender, CancelEventArgs e)// fis de hucre gosterimini engelliyor
        {
            try
            {
                degisenStokId = 0;
                if (kayitEtme == false)
                {
                    e.Cancel = true;
                    return;
                }
                if (yeniSatirSifirli == false && yeniSatirSatir == false && guncelleme == false)
                {
                    e.Cancel = true;
                    return;
                }
                else if (gridView1Erisim == false)
                {
                    e.Cancel = true;
                    return;
                }
                if (gridView2.FocusedRowHandle == GridControl.AutoFilterRowHandle || tabControl1.SelectedTabPage != tbFisSatir || this.gridControl2.Enabled == false) return;
                if (sEditorColumnSatir != this.gridView2.FocusedColumn.FieldName.ToString() || sEditorRowSatir != this.gridView2.FocusedRowHandle)
                {
                    blnGridView1ShowingEditor_Satir = false;
                    ShowingEditor_Satir();
                    blnGridView1ShowingEditor_Satir = helperBase._donusBDegerFalse;
                }
                e.Cancel = blnGridView1ShowingEditor_Satir;
                sEditorRowSatir = this.gridView2.FocusedRowHandle;
                sEditorColumnSatir = this.gridView2.FocusedColumn.FieldName.ToString();
            }
            catch (Exception)
            {
                gridHelperYenile = true;

            }
        }
        private void gridView2_BeforeLeaveRow(object sender, RowAllowEventArgs e)
        {
            try
            {
                if (gridView2.FocusedRowHandle == GridControl.AutoFilterRowHandle || tabControl1.SelectedTabPage != tbFisSatir || this.gridControl2.Enabled == false) return;
                GridView view = (GridView)sender;
                if (satirYeniKayitAc == false) // sifirli kayittan acilis varsa tekrardan buraya girmemeli
                {
                    if ((view.GetRowCellValue(view.FocusedRowHandle, "ID") == null || Convert.ToInt32(view.GetRowCellValue(view.FocusedRowHandle, "ID")) == 0) && view.FocusedRowHandle >= 0)
                    {
                        Satir_Doldur(0);
                    }
                }
            }
            catch (Exception)
            {
                gridHelperYenile = true;

            }
        }
        private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
              CellValueChanged_Satir(sender, e);
            }
            catch (Exception)
            {
                gridHelperYenile = true;

            }
        }
        private void gridView2_CustomDrawFooter(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            try
            {
                e.Painter.DrawObject(e.Info);
                GridView view = sender as GridView;
                //string s = "Kayýt Listelendi";
                //if (Globals.rman.GetString("Kayýt Listelendi") != null) { s = Globals.rman.GetString("Kayýt Listelendi"); }
                string sum = string.Format("{0}", view.DataRowCount + " " + YardimciIslemler.IstenilenDileCevir("Kayýt Listelendi"));
                Point point = new Point(e.Bounds.Left + 3, e.Bounds.Top + 3);
                e.Graphics.DrawString(sum, new Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162))), Brushes.Black, point);
                e.Handled = true;
            }
            catch (Exception)
            {
                gridHelperYenile = true;

            }
        }
        public void setVerilenKod(GridView view)
        {
            try
            {

                if (fiskodIstenenId != 0 && view != null)
                {
                    string mt = "Get" + view.FocusedColumn.FieldName;
                    bindingSourceArr[AlanAdiIndexi[view.Name + view.FocusedColumn.FieldName]].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, 0, 0, "", "", 0);
                    view.SetRowCellValue(view.FocusedRowHandle, view.FocusedColumn.FieldName, fiskodIstenenId);
                    object a = ModelSatirVm;
                }
                view.ShowEditor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());   
            }
        }
        #region diger
        private void gridView1_CustomFilterDialog(object sender, CustomFilterDialogEventArgs e)
        {
            if (e.Column.FieldName == "CARI_ID" || e.Column.FieldName == "ISLEM_TIPI_ID" ||
      e.Column.FieldName == "ShippedDate")
            {
                //Create a collection of columns to display in the dialog's value combo boxes 
                GridColumnCollection cols = new GridColumnCollection(null);
                cols.AddRange(new GridColumn[] {this.gridView1.Columns["CARI_ID"], 
          this.gridView1.Columns["ISLEM_TIPI_ID"]});
                //Create an advanced Custom Filter Dialog and supply the column collection  
                DevExpress.XtraGrid.Filter.FilterCustomDialog2 dlg =
                    new DevExpress.XtraGrid.Filter.FilterCustomDialog2(e.Column, cols, false);
                //Set the Field options in the dialog to checked  
                setFieldCheckBox(dlg, true);
                //Display the dialog 
                dlg.ShowDialog();
                //The dialog sets filter criteria for the column itself based on the user's choice 
                //Set e.FilterInfo to null to prevent overriding these criteria  
                //after your event handler is performed 
                e.FilterInfo = null;
                //Prevent the standard filter dialog from displaying 
                e.Handled = true;

            }
            else if (e.Column.FieldName == "TARIH" )
            {
                //Create a collection of columns to display in the dialog's value combo boxes 
                GridColumnCollection cols = new GridColumnCollection(null);
                cols.AddRange(new GridColumn[] {this.gridView1.Columns["TARIH"]});
                //Create an advanced Custom Filter Dialog and supply the column collection  
                DevExpress.XtraGrid.Filter.FilterCustomDialog2 dlg =
                    new DevExpress.XtraGrid.Filter.FilterCustomDialog2(e.Column, cols, false);
                //Set the Field options in the dialog to checked  
                setFieldCheckBox(dlg, true);
                //Display the dialog 
                dlg.ShowDialog();
                //The dialog sets filter criteria for the column itself based on the user's choice 
                //Set e.FilterInfo to null to prevent overriding these criteria  
                //after your event handler is performed 
                e.FilterInfo = null;
                //Prevent the standard filter dialog from displaying 
                e.Handled = true;

            }
        }
        private void setFieldCheckBox(FilterCustomDialog2 dialog, bool value)
        {
            foreach (Control ctrl in dialog.Controls)
                if (ctrl is PanelControl)
                {
                    foreach (Control childCtrl in ctrl.Controls)
                        //Find the GroupBox containing the Field check boxes 
                        if (childCtrl is GroupBox)
                        {
                            foreach (Control elem in childCtrl.Controls)
                            {
                                //Find the Field check boxes 
                                if (elem is CheckEdit)
                                {
                                    ((CheckEdit)elem).Checked = value;
                                }
                            }
                            return;
                        }
                }
        }
        #endregion

        private void gridControl2_MouseDown(object sender, MouseEventArgs e)
        {
            ////BaseContainerValidateEditorEventArgs args = new BaseContainerValidateEditorEventArgs(e.value);

            //OnValidatingEditor(this, args);
        }
        #endregion

        private void gridView1_ShowFilterPopupListBox(object sender, FilterPopupListBoxEventArgs e)
        {
            if (e.Column.FieldName == "IRSALIYE_NO")
            {
                e.ComboBox.Items.Clear();
                e.ComboBox.Items.Add(new DevExpress.XtraGrid.Views.Grid.FilterItem("Complex filter",
                    new
        DevExpress.XtraGrid.Columns.ColumnFilterInfo(DevExpress.XtraGrid.Columns.ColumnFilterType.Custom,
                    null, "[IRSALIYE_NO] LIKE '%1%'", "Product name contains 'lo'")));
            }
        }
        #endregion

        public void AramaById(int id)
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
    }
}
