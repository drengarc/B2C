using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Prodma.DataAccessB2C; using Prodma.WinForms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using Prodma.SistemB2C.Controllers;
using Prodma.SistemB2C.Models;
using System.Resources;
using System.Diagnostics;
using System.Reflection;

namespace Prodma.Sistem.Forms
{
    public partial class Kullanici : TanitimSablon
    {
        #region degiskenler
        private KullaniciCntrl kulcntrl = new KullaniciCntrl();
        #endregion
        #region Constructors
        public Kullanici()
        {
            InitializeComponent();
            tabloAdi = "KULLANICI";
            this.Text = this.Text = Gridi_Olustur();  
            Tab_Gizle_Ekle();
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.Dinamik_TextBox_Olustur);
        }
        public override void CustomButonEkle()
        {
            int yetkiIndex = 0;
            List<YetkiIslemlerVm> listYetki = ListDenemeService.GetYETKI_ISLEMLER(Globals.gnKullaniciId, (int)IslemSahibiEn.KULLANICI, (int)IslemListeEn.ISLEM);
            foreach (var item in listYetki)
            {
                if (item.YETKILI_E_H == (int)EvetHayirEn.Evet)
                {
                    this.controlNavigator1.CustomButtons[yetkiIndex + 1].Tag = item.YETKIISLEMTANITIM.TAG_NAME;
                    this.controlNavigator1.CustomButtons[yetkiIndex + 1].Hint = item.YETKIISLEMTANITIM.HINT_NAME;
                    this.controlNavigator1.CustomButtons[yetkiIndex + 1].ImageIndex = Convert.ToInt32(item.YETKIISLEMTANITIM.IMAGE_NAME);
                    yetkiIndex++;
                }
            }
            for (int i = 0; i < 7 - yetkiIndex; i++)
            {
                this.controlNavigator1.CustomButtons.RemoveAt(yetkiIndex + 1);
            }
        }
        public override void Custom_Buton_Islemleri(string islem)
        {
            if (gridView1.OptionsBehavior.Editable == true)
            {
                if (islem == "KulllaniciKopyalama")
                {
                    KullaniciVm model = (KullaniciVm)ModelVm;
                    KullaniciKopyalama kullaniciKopyalama = new KullaniciKopyalama(true);
                    kullaniciKopyalama.Dock = DockStyle.Fill;
                    kullaniciKopyalama.WindowState = FormWindowState.Normal;
                    kullaniciKopyalama.kullaniciId = model.ID;
                    kullaniciKopyalama.Doldur();
                    kullaniciKopyalama.ShowDialog();
                }
            }
        }
        private void Tab_Gizle_Ekle()
        {
            this.pnlEkIslemler.Visible = true;
            this.pnlIslemler.Visible = true;
            this.panelControl1.Size = new System.Drawing.Size(948, 65);
            tabPage1.Text = "Kullanıcı Bilgi Giriş";
            tabPage2.Text = "Ek Bilgiler (F6)";
            tabPage3.Text = "Menü Yetkileri (F7)";
            tabPage4.Text = "Alan Bazlı Yetki (F8)";
            tabPage5.Text = "Bilgi Bazlı Yetki (F9)";
            tabPage6.Text = "İşlem Bazlı Yetki (F10)";
            tabPage7.Text = "Liste Bazlı Yetki (F11)";
            tabPage8.Text = "Kullanıcı Ek Dinamik Yetki (Cntrl + F11)";
            tabPage9.Text = "Kullanıcı Grid Duzenleme (F12)";
            tabPage10.Text = "Kullanıcı Ambar Tanımlama (Cntrl + F10)";
            tabPage11.Text = "Özel Listeler (Cntrl + F12)";

            usrGridBilgi.Kart_Bilgi_Duzenle(gridView1);
   
            controlNavigator2.Visible = false;

             
          
          

            //this.tabControl1.TabPages.Remove(tabPage3);
            controlNavigator3.Visible = false;
            controlNavigator4.Visible = false;
            controlNavigator5.Visible = false;
            controlNavigator6.Visible = false;
            controlNavigator7.Visible = false;
            controlNavigator8.Visible = false;
            //this.tabControl1.TabPages.Remove(tabPage4);
            //this.tabControl1.TabPages.Remove(tabPage5);
            //this.tabControl1.TabPages.Remove(tabPage6);
            //this.tabControl1.TabPages.Remove(tabPage7);
            //this.tabControl1.TabPages.Remove(tabPage8);
            this.tabControl1.TabPages.Remove(tabPage9);
            //this.tabControl1.TabPages.Remove(tabPage10);
            //this.tabControl1.TabPages.Remove(tabPage11);
            this.tabControl1.TabPages.Remove(tabPage12);
            this.tabControl1.TabPages.Remove(tabPage13);
        }
        public override void Doldur()
        {
            KullaniciVm k = new KullaniciVm();
            testInfoBindingSource.DataSource = kulcntrl.Liste_Al(null);
            base.gridControl1.DataSource = testInfoBindingSource;
            base.gridView1.Columns["ID"].Visible = false;
            base.gridView1.FocusedColumn = base.gridView1.VisibleColumns[0];
        }
        public override void Tanitim_KeyDown(KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                if (e.KeyCode == Keys.F11)
                {
                    tabControl1.SelectedTabPage = tabPage8;
                    return;
                }
                if (e.KeyCode == Keys.F12)
                {
                    tabControl1.SelectedTabPage = tabPage11;
                    return;
                }
            }
            if (e.KeyCode == Keys.F6)
            {
                tabControl1.SelectedTabPage = tabPage2;
            }
            else if (e.KeyCode == Keys.F7)
            {
                tabControl1.SelectedTabPage = tabPage3;
            }
            else if (e.KeyCode == Keys.F8)
            {
                tabControl1.SelectedTabPage = tabPage4;
            }
            else if (e.KeyCode == Keys.F9)
            {
                tabControl1.SelectedTabPage = tabPage5;
            }
            else if (e.KeyCode == Keys.F10)
            {
                tabControl1.SelectedTabPage = tabPage6;
            }
            else if (e.KeyCode == Keys.F11)
            {
                tabControl1.SelectedTabPage = tabPage7;
            }
            else if (e.KeyCode == Keys.F12)
            {
                tabControl1.SelectedTabPage = tabPage9;
            }
        }
        #endregion
        #region İşlemler  (override edenler)
        public override void Kaydet()
        {
            KullaniciVm k = (KullaniciVm)ModelVm;
            kulcntrl.Guncelle(k, k.ID);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;
        }
        public override void Yeni_Kayit()
        {
            KullaniciVm k = (KullaniciVm)ModelVm;
            kulcntrl.Ekle(k);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;
        }
        public override void Sil()
        {
            KullaniciVm k = (KullaniciVm)ModelVm;
            kulcntrl.Sil(k.ID,k);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;
        }
        public override void Yazdir()
        {
            gridControl1.ShowPrintPreview();
        }
        public override void Bul()
        {
        }
        public override void Vazgec()
        {
        }
        public override void ProcessGridKey(GridView view, KeyEventArgs args, int FocusedRowHandle, DevExpress.XtraGrid.Columns.GridColumn FocusedColumn)
        {
            if (Control.ModifierKeys == Keys.Shift)
            {
                if (args.KeyCode == Keys.F9)
                {
                   YetkiIslemlerCntrl yCntrl = new YetkiIslemlerCntrl();
                   KullaniciVm k = (KullaniciVm)ModelVm;
                   yCntrl.KullaniciIslemlerKopyala(153, k.ID);
                   MessageBox.Show("İşlem Tamam");
                }
                if (args.KeyCode == Keys.F12)
                {
                    //DataDuzeltme dz = new DataDuzeltme();
                    //dz.ShowDialog();
                }
                if (args.KeyCode == Keys.G)
                {
                    ResourceManager resman = new ResourceManager("Prodma.Resources.Resource1", Assembly.GetExecutingAssembly());
                    string a = Application.StartupPath.ToString();
                    string b = resman.GetString("Guncelleme_Yolu"); //@"C:/BOR12/";
                    FileVersionInfo myFI = FileVersionInfo.GetVersionInfo(b + "/Prodma.Satis.exe");
                    FileVersionInfo myFI1 = FileVersionInfo.GetVersionInfo(Application.StartupPath.ToString() + "/Prodma.Satis.exe");
                    DialogResult res = MessageBox.Show("Yeni Versiyon Bulundu.Güncelleme Yapılsın Mı", "", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        if (b != null && b != "")
                        {
                            MessageBox.Show("Güncelleme Yapılıyor.Program otomatik Olarak Başlatılacaktır");
                            File.Copy(b + "Prodma.DataAccessB2C.dll", a + "/Prodma.DataAccessB2C.dll", true);
                            File.Copy(b + "Prodma.Raporlar.exe", a + "/Prodma.Raporlar.exe", true);
                            File.Copy(b + "Prodma.Muhasebe.exe", a + "/Prodma.Muhasebe.exe", true);
                            File.Copy(b + "Prodma.Satis.exe", a + "/Prodma.Satis.exe", true);
                            File.Copy(b + "Logging.dll", a + "/Logging.dll", true);
                        }
                    }
                }
            }
        }

        #endregion

        #region ektabislemleri
        public override void Dinamik_TextBox_Olustur(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            usrGridBilgi.Dinamik_TextBox_Olustur(sender, e); 
        }
         
        public override void TabPage_Index_Changed(int index)
        {
            if (index == 0)
            {
                this.escapeKapat = true;
            }
            else if (index == 1)
            {
                TabIndex1_Ac(gridView1.FocusedRowHandle);
            }
            else if (index == 2)
            {
                TabIndex2_Ac(gridView1.FocusedRowHandle);
            }
            else if (index == 3)
            {
                TabIndex3_Ac(gridView1.FocusedRowHandle);
            }
            else if (index == 4)
            {
                TabIndex4_Ac(gridView1.FocusedRowHandle);
            }
            else if (index == 5)
            {
                TabIndex5_Ac(gridView1.FocusedRowHandle);
            }
            else if (index == 6)
            {
                TabIndex6_Ac(gridView1.FocusedRowHandle);
            }
            else if (index == 7)
            {
                TabIndex7_Ac(gridView1.FocusedRowHandle);
            }
            else if (index == 8)
            {
                TabIndex9_Ac(gridView1.FocusedRowHandle);
            }
            else if (index == 9)
            {
                TabIndex10_Ac(gridView1.FocusedRowHandle);
            }
            else if (index == 10)
            {
                TabIndex10_Ac(gridView1.FocusedRowHandle);
            }
        }
        public override void TabPage_Selecting(DevExpress.XtraTab.XtraTabPage tb)
        {
            tabSelect = false;
        }
        #endregion
        
        public void TabIndex1_Ac(int index)
       {
           tabPage2.Controls.Clear();
           usrGridBilgi.Dinamik_Text_Box_Doldur(gridView1);
           usrKullaniciEkBilgi usrKullaniciEkBilgi = new usrKullaniciEkBilgi();
           usrKullaniciEkBilgi.Dock = DockStyle.Top;
           tabPage2.Controls.Add(usrKullaniciEkBilgi);
           usrGridBilgi.Dock = DockStyle.Top;
           tabPage2.Controls.Add(usrGridBilgi);

           KullaniciVm k = (KullaniciVm)ModelVm;
           usrKullaniciEkBilgi.kullaniciVm = k;
           usrKullaniciEkBilgi.Doldur();
       }
        public void TabIndex2_Ac(int index)
    {
        KullaniciVm k = (KullaniciVm)ModelVm;
        tabPage3.Controls.Clear();
        usrGridBilgi.Dinamik_Text_Box_Doldur(gridView1);
        YetkiMenuler frmYetkiMenu = new YetkiMenuler();
        frmYetkiMenu.TopLevel = false;
        frmYetkiMenu.ControlBox = false;
        frmYetkiMenu.Dock = DockStyle.Fill;
        tabPage3.Controls.Add(frmYetkiMenu);
        usrGridBilgi.Dock = DockStyle.Top;
        tabPage3.Controls.Add(usrGridBilgi);
        frmYetkiMenu.Show();
       
        //frmYetkiMenu.ParentForm.KeyPreview = false;
        frmYetkiMenu.yetkiMenulerVm.KULLANICI_ID = k.ID;
        frmYetkiMenu.kullaniciLe.EditValue = k.ID;
        frmYetkiMenu.kullaniciLe.Enabled = false;
        //frmYetkiMenu.Show();
    }
        public void TabIndex3_Ac(int index)
        {
            tabPage4.Controls.Clear();
            usrGridBilgi.Dinamik_Text_Box_Doldur(gridView1);
            YetkiAlanlar frmYetkiAlanlar = new YetkiAlanlar();
            frmYetkiAlanlar.TopLevel = false;
            frmYetkiAlanlar.ControlBox = false;
            frmYetkiAlanlar.Dock = DockStyle.Fill;
            tabPage4.Controls.Add(frmYetkiAlanlar);
            usrGridBilgi.Dock = DockStyle.Top;
            tabPage4.Controls.Add(usrGridBilgi);
            frmYetkiAlanlar.Show();
        
            KullaniciVm k = (KullaniciVm)ModelVm;
            frmYetkiAlanlar.escapeKapat = false;
            frmYetkiAlanlar.yetkiAlanlarVm = new YetkiAlanlarVm();
            frmYetkiAlanlar.yetkiAlanlarVm.KULLANICI_ID = k.ID;
            //frmYetkiAlanlar.ParentForm.KeyPreview = false;
            frmYetkiAlanlar.Doldur();
            //frmYetkiAlanlar.Show();
        }
        public void TabIndex4_Ac(int index)
        {
            tabPage5.Controls.Clear();
            usrGridBilgi.Dinamik_Text_Box_Doldur(gridView1);
            YetkiAlanlarBilgiUsr frmYetkiAlanlarBilgiUsr = new YetkiAlanlarBilgiUsr();
            frmYetkiAlanlarBilgiUsr.TopLevel = false;
            frmYetkiAlanlarBilgiUsr.ControlBox = false;
            tabPage5.Controls.Add(frmYetkiAlanlarBilgiUsr);
            frmYetkiAlanlarBilgiUsr.Dock = DockStyle.Fill;
            usrGridBilgi.Dock = DockStyle.Top;
            tabPage5.Controls.Add(usrGridBilgi);
            frmYetkiAlanlarBilgiUsr.Show();
      

            KullaniciVm k = (KullaniciVm)ModelVm;
            //frmYetkiAlanlarBilgiUsr.KeyPreview = false;
            //frmYetkiAlanlarBilgiUsr.ParentForm.KeyPreview = false;
            frmYetkiAlanlarBilgiUsr.yetkiAlanlarBilgiVm.KULLANICI_ID = k.ID;
            frmYetkiAlanlarBilgiUsr.kullaniciLe.EditValue = k.ID;
            frmYetkiAlanlarBilgiUsr.kullaniciLe.Enabled = false;
        }
        public void TabIndex5_Ac(int index)
    {

        tabPage6.Controls.Clear();
        usrGridBilgi.Dinamik_Text_Box_Doldur(gridView1);
        YetkiIslemler frmYetkiIslemler = new YetkiIslemler();
        frmYetkiIslemler.TopLevel = false;
        frmYetkiIslemler.ControlBox = false;
        tabPage6.Controls.Add(frmYetkiIslemler);
        frmYetkiIslemler.Dock = DockStyle.Fill;
        usrGridBilgi.Dock = DockStyle.Top;
        tabPage6.Controls.Add(usrGridBilgi);
        
        KullaniciVm k = (KullaniciVm)ModelVm;
        frmYetkiIslemler.escapeKapat = false;
        //frmYetkiIslemler.ParentForm.KeyPreview = false;
        frmYetkiIslemler.yetkiIslemlerVm.KULLANICI_ID = k.ID;
        frmYetkiIslemler.Doldur();
        frmYetkiIslemler.Show();
    }
        public void TabIndex6_Ac(int index)
        {

            tabPage7.Controls.Clear();
            usrGridBilgi.Dinamik_Text_Box_Doldur(gridView1);
            YetkiListeler frmYetkiIslemler = new YetkiListeler();
            frmYetkiIslemler.TopLevel = false;
            frmYetkiIslemler.ControlBox = false;
            tabPage7.Controls.Add(frmYetkiIslemler);
            frmYetkiIslemler.Dock = DockStyle.Fill;
            usrGridBilgi.Dock = DockStyle.Top;
            tabPage7.Controls.Add(usrGridBilgi);

            KullaniciVm k = (KullaniciVm)ModelVm;
            frmYetkiIslemler.escapeKapat = false;
            //frmYetkiIslemler.ParentForm.KeyPreview = false;
            frmYetkiIslemler.yetkiIslemlerVm.KULLANICI_ID = k.ID;
            frmYetkiIslemler.Doldur();
            frmYetkiIslemler.Show();
        }
        public void TabIndex7_Ac(int index)
        {

            tabPage8.Controls.Clear();
            usrGridBilgi.Dinamik_Text_Box_Doldur(gridView1);
            YetkiKullaniciDinamik frmYetkiIslemler = new YetkiKullaniciDinamik();
            frmYetkiIslemler.TopLevel = false;
            frmYetkiIslemler.ControlBox = false;
            tabPage8.Controls.Add(frmYetkiIslemler);
            frmYetkiIslemler.Dock = DockStyle.Fill;
            usrGridBilgi.Dock = DockStyle.Top;
            tabPage8.Controls.Add(usrGridBilgi);

            KullaniciVm k = (KullaniciVm)ModelVm;
            frmYetkiIslemler.escapeKapat = false;
            //frmYetkiIslemler.ParentForm.KeyPreview = false;
            frmYetkiIslemler.yetkiIslemlerVm.KULLANICI_ID = k.ID;
            frmYetkiIslemler.Doldur();
            frmYetkiIslemler.Show();
        }
        public void TabIndex8_Ac(int index)
        {
            tabPage9.Controls.Clear();
            usrGridBilgi.Dinamik_Text_Box_Doldur(gridView1);
            YetkiAlanlarGrid frmYetkiAlanlarGrid = new YetkiAlanlarGrid();
            frmYetkiAlanlarGrid.TopLevel = false;
            frmYetkiAlanlarGrid.ControlBox = false;
            tabPage9.Controls.Add(frmYetkiAlanlarGrid);
            frmYetkiAlanlarGrid.Dock = DockStyle.Fill;
            usrGridBilgi.Dock = DockStyle.Top;
            tabPage9.Controls.Add(usrGridBilgi);
            frmYetkiAlanlarGrid.Show();
            KullaniciVm k = (KullaniciVm)ModelVm;
            //frmYetkiAlanlarGrid.ParentForm.KeyPreview = false;
            frmYetkiAlanlarGrid.alanlarModel.KULLANICI_ID = k.ID;
            frmYetkiAlanlarGrid.Doldur();
        }
        public void TabIndex9_Ac(int index)
        {

            //tabPage10.Controls.Clear();
            //usrGridBilgi.Dinamik_Text_Box_Doldur(gridView1);
            //Kullanici_Ambar frmYetkiIslemler = new Kullanici_Ambar();
            //frmYetkiIslemler.TopLevel = false;
            //frmYetkiIslemler.ControlBox = false;
            //tabPage10.Controls.Add(frmYetkiIslemler);
            //frmYetkiIslemler.Dock = DockStyle.Fill;
            //usrGridBilgi.Dock = DockStyle.Top;
            //tabPage10.Controls.Add(usrGridBilgi);

            //KullaniciVm k = (KullaniciVm)ModelVm;
            //frmYetkiIslemler.escapeKapat = false;
            ////frmYetkiIslemler.ParentForm.KeyPreview = false;
            //frmYetkiIslemler.KullaniciAmbarVm.KULLANICI_ID = k.ID;
            //frmYetkiIslemler.Doldur();
            //frmYetkiIslemler.Show();
        }
        public void TabIndex10_Ac(int index)
        {

            tabPage11.Controls.Clear();
            usrGridBilgi.Dinamik_Text_Box_Doldur(gridView1);
            YetkiOzelFiltreler frmYetkiOzelFiltreler = new YetkiOzelFiltreler();
            frmYetkiOzelFiltreler.TopLevel = false;
            frmYetkiOzelFiltreler.ControlBox = false;
            tabPage11.Controls.Add(frmYetkiOzelFiltreler);
            frmYetkiOzelFiltreler.Dock = DockStyle.Fill;
            usrGridBilgi.Dock = DockStyle.Top;
            tabPage11.Controls.Add(usrGridBilgi);

            KullaniciVm k = (KullaniciVm)ModelVm;
            frmYetkiOzelFiltreler.escapeKapat = false;
            //frmYetkiIslemler.ParentForm.KeyPreview = false;
            frmYetkiOzelFiltreler.FiltrelerVm.KULLANICI_ID = k.ID;
            frmYetkiOzelFiltreler.Doldur();
            frmYetkiOzelFiltreler.Show();
        }
    }
}