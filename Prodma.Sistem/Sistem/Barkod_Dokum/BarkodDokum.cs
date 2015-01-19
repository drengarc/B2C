using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Satis.StokAmbar.Controllers;
using Satis.StokAmbar.Models; 
using Prodma.DataAccess; using Prodma.WinForms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Prodma.Sistem.Forms;
using Prodma.Sistem.Controllers;
using Prodma.Sistem.Models;
using DevExpress.XtraEditors;
using System.Runtime.InteropServices;
using DevExpress.XtraBars;
using System.Drawing.Printing;
namespace Prodma.Sistem.Forms
{
    public partial class BarkodDokum : TanitimSablon
    {
        #region degiskenler
        private DevExpress.XtraBars.BarButtonItem[] EkranListeleri = new BarButtonItem[2];
        private BarkodDokumCntrl kulcntrl = new BarkodDokumCntrl();
        public BarkodDokumVm barkodDokumVm;
        DevExpress.XtraBars.BarButtonItem barButtonItem1;
        #endregion
        #region Barkod Dll Import
        [DllImport("Winppla.dll")]
        private static extern int A_Bar2d_Maxi(int x, int y, int primary, int secondary, int country, int service, char mode, int numeric, string data);
        [DllImport("Winppla.dll")]
        private static extern int A_Bar2d_Maxi_Ori(int x, int y, int ori, int primary, int secondary, int country, int service, char mode, int numeric, string data);
        [DllImport("Winppla.dll")]
        private static extern int A_Bar2d_PDF417(int x, int y, int narrow, int width, char normal, int security, int aspect, int row, int column, char mode, int numeric, string data);
        [DllImport("Winppla.dll")]
        private static extern int A_Bar2d_PDF417_Ori(int x, int y, int ori, int narrow, int width, char normal, int security, int aspect, int row, int column, char mode, int numeric, string data);
        [DllImport("Winppla.dll")]
        private static extern int A_Bar2d_DataMatrix(int x, int y, int rotation, int hor_mul, int ver_mul, int ECC, int data_format, int num_rows, int num_col, char mode, int numeric, string data);
        [DllImport("Winppla.dll")]
        private static extern void A_Clear_Memory();
        [DllImport("Winppla.dll")]
        private static extern void A_ClosePrn();
        [DllImport("Winppla.dll")]
        private static extern int A_CreatePrn(int selection, string filename);
        [DllImport("Winppla.dll")]
        private static extern int A_Del_Graphic(int mem_mode, string graphic);
        [DllImport("Winppla.dll")]
        private static extern int A_Draw_Box(char mode, int x, int y, int width, int height, int top, int side);
        [DllImport("Winppla.dll")]
        private static extern int A_Draw_Line(char mode, int x, int y, int width, int height);
        [DllImport("Winppla.dll")]
        private static extern void A_Feed_Label();
        [DllImport("Winppla.dll")]
        private static extern int A_Get_DLL_VersionA(int nShowMessage);
        [DllImport("Winppla.dll")]
        private static extern int A_Get_Graphic(int x, int y, int mem_mode, char format, string filename);
        [DllImport("Winppla.dll")]
        private static extern int A_Get_Graphic_ColorBMP(int x, int y, int mem_mode, char format, string filename);
        [DllImport("Winppla.dll")]
        private static extern int A_Initial_Setting(int Type, string Source);
        [DllImport("Winppla.dll")]
        private static extern int A_Load_Graphic(int x, int y, string graphic_name);
        [DllImport("Winppla.dll")]
        private static extern int A_Open_ChineseFont(string path);
        [DllImport("Winppla.dll")]
        private static extern int A_Print_Form(int width, int height, int copies, int amount, string form_name);
        [DllImport("Winppla.dll")]
        private static extern int A_Print_Out(int width, int height, int copies, int amount);
        [DllImport("Winppla.dll")]
        private static extern int A_Prn_Barcode(int x, int y, int ori, char type, int narrow, int width, int height, char mode, int numeric, string data);
        [DllImport("Winppla.dll")]
        private static extern int A_Prn_Text(int x, int y, int ori, int font, int type, int hor_factor, int ver_factor, char mode, int numeric, string data);
        [DllImport("Winppla.dll")]
        private static extern int A_Prn_Text_Chinese(int x, int y, int fonttype, string id_name, string data, int mem_mode);
        [DllImport("Winppla.dll")]
        private static extern int A_Prn_Text_TrueType(int x, int y, int FSize, string FType, int Fspin, int FWeight, int FItalic, int FUnline, int FStrikeOut, string id_name, string data, int mem_mode);
        [DllImport("Winppla.dll")]
        private static extern int A_Prn_Text_TrueType_W(int x, int y, int FHeight, int FWidth, string FType, int Fspin, int FWeight, int FItalic, int FUnline, int FStrikeOut, string id_name, string data, int mem_mode);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_Backfeed(int back);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_BMPSave(int nSave, string pstrBMPFName);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_Cutting(int cutting);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_Darkness(int heat);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_DebugDialog(int nEnable);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_Feed(char rate);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_Form(string formfile, string form_name, int mem_mode);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_Margin(int position, int margin);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_Prncomport(int baud, int parity, int data, int stop);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_Prncomport_PC(int nBaudRate, int nByteSize, int nParity, int nStopBits, int nDsr, int nCts, int nXonXoff);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_Sensor_Mode(char type, int continuous);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_Speed(char speed);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_Syssetting(int transfer, int cut_peel, int length, int zero, int pause);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_Unit(char unit);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_Logic(int logic);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_ProcessDlg(int nShow);
        [DllImport("Winppla.dll")]
        private static extern int A_Set_LabelVer(int centiInch);
        [DllImport("Winppla.dll")]
        private static extern int A_GetUSBBufferLen();
        [DllImport("Winppla.dll")]
        private static extern int A_EnumUSB(byte[] buf);
        [DllImport("Winppla.dll")]
        private static extern int A_CreateUSBPort(int nPort);
        [DllImport("Winppla.dll")]
        private static extern int A_CreatePort(int nPortType, int nPort, string filename);
        #endregion
          PrintDocument doc = new PrintDocument();
          Ean13Barcode2005.Ean13 barcode = new Ean13Barcode2005.Ean13();
        #region Constructors
        public BarkodDokum()
        {
            
            InitializeComponent();
            tabloAdi = "BARKOD_DOKUM";
            this.Text = Gridi_Olustur();  
            Tab_Gizle_Ekle();
            //Doldur();
            controlNavigator1.ButtonClick += new NavigatorButtonClickEventHandler(controlNavigator1_ButtonClick);
            //AddPrinter();
            doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);
        }
        private void Tab_Gizle_Ekle()
        {
            tabPage1.Text ="Barkod Döküm";
            tabPage2.Text = "Ek Bilgiler";
            tabPage2.AutoScroll = true;
            //this.tabControl1.TabPages.Remove(tabPage2);
            //controlNavigator2.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage3);
            //controlNavigator3.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage4);
            //controlNavigator4.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage5);
            //controlNavigator5.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage6);
            //controlNavigator6.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage7);
            //controlNavigator7.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage8);
            //controlNavigator8.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage9);
            //controlNavigator9.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage10);
            //controlNavigator10.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage11);
            //controlNavigator11.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage12);
            //controlNavigator12.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage13);
            AddPrinter();
            //controlNavigator13.NavigatableControl = base.gridControl1;
            //this.EkranListeleri[0] = new BarButtonItem(barManager1, "Ekran Yazdır");
            //this.EkranListeleri[0].Name = "EkranList";
            //this.EkranListeleri[1] = new BarButtonItem(barManager1, "CekFisi");
            //this.EkranListeleri[1].Name = "CekFisi";
            ////barManager1.ItemClick += new ItemClickEventHandler(barManager_ItemClick);
            //this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] 
            //{
            //new DevExpress.XtraBars.LinkPersistInfo(this.EkranListeleri[0]),
            //new DevExpress.XtraBars.LinkPersistInfo(this.EkranListeleri[1]),
            //});
            //this.popupMenu1.Manager = this.barManager1;
            //this.popupMenu1.Name = "popupMenu1";


        }
        public override void Doldur()
        {
            testInfoBindingSource.DataSource = kulcntrl.Liste_Al(barkodDokumVm);
            base.gridControl1.DataSource = testInfoBindingSource;
            gridView1.Columns["ID"].Visible = false;
            gridView1.FocusedColumn = gridView1.VisibleColumns[0];
        }

        void AddPrinter()
        {
            BarkodYaziciTanitimCntrl barkodYaziciTanitimCntrl = new BarkodYaziciTanitimCntrl();
            List<BarkodYaziciTanitimVm> modelList = barkodYaziciTanitimCntrl.Liste_Al(null);
            if (modelList != null && modelList.Count != 0)
            {
                foreach (var item in modelList)
                {
                    barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
                    barManager1.BeginInit();
                    popupMenu1.BeginInit();
                    barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            barButtonItem1});

                    barButtonItem1.Caption = item.AD;
                    barButtonItem1.Id = item.ID;
                    barButtonItem1.Name = item.AD;
                    barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barManager_ItemClick);
                    // 
                    // popupMenu1
                    // 
                    this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(barButtonItem1)});
                    this.popupMenu1.Manager = this.barManager1;
                    this.popupMenu1.Name = "popupMenu1";
                    popupMenu1.EndInit();
                    barManager1.EndInit();
                }
            }
        }

        private void controlNavigator1_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            ControlNavigator navigator = (ControlNavigator)sender;
            if (e.Button.ImageIndex == 10)
            {
                popupMenu1.ShowPopup(Control.MousePosition);
            }
        }
        private void barManager_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //BarkodDokumVm k = (BarkodDokumVm)ModelVm;
            //if (k != null)
            //{
            //    StokCntrl stokCntrl = new StokCntrl();
            //    StokVm stokVm = new StokVm();
            //    stokVm.ID = k.STOK_ID;
            //    stokVm = stokCntrl.Liste_Al(stokVm)[0];
            //    BarkodDokumKoordinatCntrl barkodDokumKoordinatCntrl = new BarkodDokumKoordinatCntrl();
            //    List<BarkodDokumKoordinatVm> barkodDokumKoordinatVm = new List<BarkodDokumKoordinatVm>();
            //    //barkodDokumKoordinatVm[0].BARKOD_YAZICI_TANITIM_ID = e.Item.Id;
            //    barkodDokumKoordinatVm = barkodDokumKoordinatCntrl.Liste_Al(new BarkodDokumKoordinatVm { BARKOD_YAZICI_TANITIM_ID = e.Item.Id });
            //    if (barkodDokumKoordinatVm.Count == 1)
            //    {
            //        A_CreatePrn(0, null);
            //        A_Clear_Memory();
            //        A_Set_Darkness(8);
            //        if (barkodDokumKoordinatVm[0].STOK_AD_CHK)
            //            A_Prn_Text(barkodDokumKoordinatVm[0].STOK_AD_X ?? 0, barkodDokumKoordinatVm[0].STOK_AD_Y ?? 0, 1, barkodDokumKoordinatVm[0].STOK_AD_FONT_SIZE ?? 0, 1, 2, 0, 'n', 1, stokVm.AD);
            //        if (barkodDokumKoordinatVm[0].STOK_KOD_CHK)
            //            A_Prn_Text(barkodDokumKoordinatVm[0].STOK_KOD_X ?? 0, barkodDokumKoordinatVm[0].STOK_KOD_Y ?? 0, 1, barkodDokumKoordinatVm[0].STOK_KOD_FONT_SIZE ?? 0, 1, 2, 0, 'n', 1, stokVm.KOD);
            //        if (barkodDokumKoordinatVm[0].STOK_AMBALAJ_MIKTAR_CHK)
            //            A_Prn_Text(barkodDokumKoordinatVm[0].STOK_AMBALAJ_MIKTAR_X ?? 0, barkodDokumKoordinatVm[0].STOK_AMBALAJ_MIKTAR_Y ?? 0, 1, barkodDokumKoordinatVm[0].STOK_AMBALAJ_MIKTAR_FONT_SIZE ?? 0, 1, 2, 0, 'n', 1, stokVm.AMBALAJ_MIKTARI.ToString());
            //        if (barkodDokumKoordinatVm[0].BARKOD_CHK)
            //            A_Prn_Barcode(barkodDokumKoordinatVm[0].BARKOD_X ?? 0, barkodDokumKoordinatVm[0].BARKOD_Y ?? 0, 1, 'A', 0, 0, 20, 'n', 1, stokVm.KOD);
            //        if (barkodDokumKoordinatVm[0].ACIKLAMA_1_CHK)
            //            A_Prn_Text(barkodDokumKoordinatVm[0].ACIKLAMA_1_X ?? 0, barkodDokumKoordinatVm[0].ACIKLAMA_1_Y ?? 0, 1, barkodDokumKoordinatVm[0].ACIKLAMA_1_FONT_SIZE ?? 0, 1, 2, 0, 'n', 1, barkodDokumKoordinatVm[0].ACIKLAMA_1);
            //        if (barkodDokumKoordinatVm[0].ACIKLAMA_2_CHK)
            //            A_Prn_Text(barkodDokumKoordinatVm[0].ACIKLAMA_2_X ?? 0, barkodDokumKoordinatVm[0].ACIKLAMA_2_Y ?? 0, 1, barkodDokumKoordinatVm[0].ACIKLAMA_2_FONT_SIZE ?? 0, 1, 2, 0, 'n', 1, barkodDokumKoordinatVm[0].ACIKLAMA_2);
            //        if (barkodDokumKoordinatVm[0].ACIKLAMA_3_CHK)
            //            A_Prn_Text(barkodDokumKoordinatVm[0].ACIKLAMA_3_X ?? 0, barkodDokumKoordinatVm[0].ACIKLAMA_3_Y ?? 0, 1, barkodDokumKoordinatVm[0].ACIKLAMA_3_FONT_SIZE ?? 0, 1, 2, 0, 'n', 1, barkodDokumKoordinatVm[0].ACIKLAMA_3);
            //        if (barkodDokumKoordinatVm[0].ACIKLAMA_4_CHK)
            //            A_Prn_Text(barkodDokumKoordinatVm[0].ACIKLAMA_4_X ?? 0, barkodDokumKoordinatVm[0].ACIKLAMA_4_Y ?? 0, 1, barkodDokumKoordinatVm[0].ACIKLAMA_4_FONT_SIZE ?? 0, 1, 2, 0, 'n', 1, barkodDokumKoordinatVm[0].ACIKLAMA_4);
            //        if (barkodDokumKoordinatVm[0].ACIKLAMA_5_CHK)
            //            A_Prn_Text(barkodDokumKoordinatVm[0].ACIKLAMA_5_X ?? 0, barkodDokumKoordinatVm[0].ACIKLAMA_5_Y ?? 0, 1, barkodDokumKoordinatVm[0].ACIKLAMA_5_FONT_SIZE ?? 0, 1, 2, 0, 'n', 1, barkodDokumKoordinatVm[0].ACIKLAMA_5);

            //        A_Print_Out(1, 1, 2, 1);

            //        A_ClosePrn();
            //    }
            //}
            //else {
            //    MessageBox.Show("Öncelikli olarak kayıt girmelisiniz");
            //}
            //bu kod barkodun ilk 2 hanesi -ülke kodu
            barcode.CountryCode = "90";

            //Bu kod üretici-imalatçı numarası -bu kısımın legal illegal gibi durumları da var
            barcode.ManufacturerCode = "1234";

            //Bu kod ürün kodu -ID si falanı felanı
            barcode.ProductCode = "000001";

            //Bu kısım boş geçilsede birşey değişmiyor EAN-13 te zaten 12 veri okuyorsunuz ,bu sayı  barkodun sonunda oluyor.
            barcode.ChecksumDigit = "5";
            doc.Print();
          
        }
        void doc_PrintPage(object sender, PrintPageEventArgs e)
        {

            e.Graphics.DrawString("FİRMA ADI", new System.Drawing.Font(new FontFamily("Arial"), 15, FontStyle.Bold), Brushes.Red, new PointF(50, 5));
            //Gerekli bir kaç bilgi veriyorum

            e.Graphics.DrawString("Telefon : (212) 123 12 12Fax : (212) 123 12 12", new System.Drawing.Font(new FontFamily("Arial"), 8, FontStyle.Bold), Brushes.Red, new PointF(18, 45));
            //Burası önemli aşağıdaki kod bakodu yazan kod
            barcode.DrawEan13Barcode(e.Graphics, (new PointF(25, 50)));
            //Aşağıdaki kodlara ek olarak ben Elektronik Tartı cihazından gelen verileri aktarmıştım

            e.Graphics.DrawString("Lot :", new System.Drawing.Font(new FontFamily("Arial"), 10, FontStyle.Bold), Brushes.Red, new PointF(20, 120));

            e.Graphics.DrawString("Brt :", new System.Drawing.Font(new FontFamily("Arial"), 10, FontStyle.Bold), Brushes.Red, new PointF(20, 145));

            e.Graphics.DrawString("Net :", new System.Drawing.Font(new FontFamily("Arial"), 10, FontStyle.Bold), Brushes.Red, new PointF(20, 165));


            //int linesPerPage = 0;
            //int charsOnPage = 0;
            //string strToPrint = "deneme";
            //e.Graphics.MeasureString(strToPrint, this.Font, e.MarginBounds.Size, StringFormat.GenericTypographic, out charsOnPage, out linesPerPage);
            //e.Graphics.DrawString(strToPrint, this.Font, Brushes.Black, e.MarginBounds, StringFormat.GenericTypographic);
            //strToPrint = strToPrint.Substring(charsOnPage);
            //e.HasMorePages = (strToPrint.Length > 0);
 
        }
        #endregion
        #region İşlemler  (override edenler)
        public override void Kaydet()
        {
            BarkodDokumVm k = (BarkodDokumVm)ModelVm;
            kulcntrl.Guncelle(k, k.ID);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Yeni_Kayit()
        {
            BarkodDokumVm k = (BarkodDokumVm)ModelVm;
            kulcntrl.Ekle(k);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Sil()
        {
            BarkodDokumVm k = (BarkodDokumVm)ModelVm;
            kulcntrl.Sil(k.ID,k);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Yazdir()
        {
            popupMenu1.ShowPopup(Control.MousePosition);
        }
        public override void Bul()
        {
        }
        public override void Vazgec()
        { 
        }
        #endregion
        #region Ek Tab İşlemeleri
        public override void TabPage_Index_Changed(int index)
        {
            if (index == 0)
            {
                this.escapeKapat = true;
            }
            else if (index == 1)
            {
                TabIndex2_Ac(gridView1.FocusedRowHandle);
            }
        }

        private void TabIndex2_Ac(int index)
        {
           // BarkodYaziciTanitimVm k = (BarkodYaziciTanitimVm)ModelVm;
        }
        #endregion

    }
}