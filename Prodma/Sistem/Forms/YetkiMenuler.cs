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
using Prodma.Sistem.Models;
using Prodma.Sistem.Controllers;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
namespace Prodma.Sistem.Forms
{
    public partial class YetkiMenuler : Islemler
    {
        #region degiskenler
        int menuId = 0;
        byte tiklananButon = 0;
        private System.Windows.Forms.BindingSource testInfoBindingSource = new System.Windows.Forms.BindingSource();
        public usrGridIslem usr = new usrGridIslem(GridIslemEn.Giris);
        private YetkiMenulerCntrl kulcntrl = new YetkiMenulerCntrl();
        public YetkiMenulerVm yetkiMenulerVm = new YetkiMenulerVm();
        #endregion
        #region Constructors
        public YetkiMenuler()
        {

            InitializeComponent();
            usr.escapeKapatma = true;
            this.panel1.Controls.Add(usr);
            usr.Dock = DockStyle.Fill; 
            usr.tabloAdi = "YETKI";
            usr.Gridi_Olustur(); 
            EventArgs eArgs = new EventArgs();
            usrDoldur(usr.gridView1, eArgs);
            usr.Doldur += usrDoldur;
            usr.Kaydet += usrKaydet;
            usr.Yeni_Kayit += usrYeni_Kayit;
            usr.Sil += usrSil;
            usr.Yazdir += usrYazdir;
            usr.Bul += usrBul;
            usr.Vazgec += usrVazgec;
            usr.ValidateRow  += usrValidateRow;
            usr.controlNavigatorButtonClick += controlNavigatorButtonClick;
            usrTabPage_Index_Changed(1);
            Control_Ayarla_Kayit(this.Controls, null, menuLke1, false);
            listKullaniciCmd.Enabled = true;
            this.Text = "Menu Yetkileri";
            UYGULAcmd.Visible = true;
            panelTamam.Visible = false;
            usr.controlNavigator1.Buttons.CustomButtons[2].Visible = true;
            usr.controlNavigator1.Buttons.CustomButtons[2].Tag = "Kopyala";
            usr.controlNavigator1.Buttons.CustomButtons[2].ImageIndex = 5;
        }
        public void usrDoldur(object sender, EventArgs e)
        {
            EventArgs a = new EventArgs();
            if (tiklananButon == 0)
            {
                listKullaniciCmd_Click(usr.gridView1, a);
            }
            else if (tiklananButon == 1)
            {
                listMenu1cmd_Click(usr.gridView1, a);
            }
            else if (tiklananButon == 2)
            {
                listMenu2cmd_Click(usr.gridView1, a);
            }
        }
        #endregion
        #region İşlemler  (override edenler)
        public void usrTabPage_Index_Changed(int index)
        {
            if (index != 0)
            {
                YardimciIslemler.InvokeLkeSet("KULLANICI_ID", kullaniciLe);
                YardimciIslemler.InvokeLkeSet("M_MENU_UST_ID", menuLke1);
                menuLke2.Properties.DataSource = ListDenemeService.GetM_MENU_ID_BY_PARAM(0, 0);
            }
        }
        public void usrKaydet(object sender, EventArgs e)
        {
            YetkiMenulerVm k = (YetkiMenulerVm)usr.ModelVm;
            kulcntrl.Guncelle(k, k.ID);
          //  lblBilgi.Text = kulcntrl.MesajYaz();
            usr.islemTamamDegil = kulcntrl.islemTamamDegilCntrl;
           // usrDoldur();
        }
        public void usrYeni_Kayit(object sender, EventArgs e)
        {
            YetkiMenulerVm k = (YetkiMenulerVm)usr.ModelVm;
            k.KULLANICI_ID = Convert.ToInt16(kullaniciLe.EditValue);
            k.M_MENU_UST_ID = Convert.ToInt16(menuLke1.EditValue);
          //  k.M_MENU_ID = Convert.ToInt16(menuLke2.EditValue);
            kulcntrl.Ekle(k);
           // lblBilgi.Text = kulcntrl.MesajYaz();
            usr.islemTamamDegil = kulcntrl.islemTamamDegilCntrl;
        }
        public void usrSil(object sender, EventArgs e)
        {
            YetkiMenulerVm k = (YetkiMenulerVm)usr.ModelVm;
            kulcntrl.Sil(k.ID, k);
           // lblBilgi.Text = kulcntrl.MesajYaz();
            usr.islemTamamDegil = kulcntrl.islemTamamDegilCntrl;
        }
        public void usrYazdir(object sender, EventArgs e)
        {
           // lblBilgi.Text = kulcntrl.MesajYaz();
            usr.gridControl1.ShowPrintPreview();
        }
        public void usrBul(object sender, EventArgs e)
        {
        }
        public void usrVazgec(object sender, EventArgs e)
        {
        }
        public void usrBagliGridDoldur(bool hepsi)
        {

            for (int i = 0; i < 16; i++)
            {
                if (usr.repositoryItemLookUpEdit1[i] != null)
                {
                    if (usr.repositoryItemLookUpEdit1[i].Name == "M_MENU_ID")
                    {
                        menuId = i;
                        // BindingSource bn = new BindingSource();
                        
                    }
                }
            }
        }
        public void usrValidateRow(object sender, EventArgs e)
        {
            usr.blnValidateRow = true;
            if (usr.gridView1.GetRowCellValue(usr.gridView1.FocusedRowHandle, "M_MENU_ID") == null) { usr.kayitTamam = false; }
        }
        public void controlNavigatorButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == "Kopyala")
            {
                YetkiMenulerVm Vm = (YetkiMenulerVm)usr.ModelVm;
                if (Vm == null) return;
                KullaniciMenuKopyalama kullaniciKopyalama = new KullaniciMenuKopyalama((int)KullaniciIslemleriTipEn.Menu_Yetkileri);
                kullaniciKopyalama.Dock = DockStyle.Fill;
                kullaniciKopyalama.WindowState = FormWindowState.Normal;
                kullaniciKopyalama.kaynakId = Vm.M_MENU_ID;
                kullaniciKopyalama.eskiKullaniciId = Vm.KULLANICI_ID;
                kullaniciKopyalama.Doldur();
                kullaniciKopyalama.ShowDialog();
                Doldur();
            }
        }
        #endregion
        private void alanlarLe_EditValueChanged(object sender, EventArgs e)
        {
            usrBagliGridDoldur(true);
            YetkiMenulerVm k = new YetkiMenulerVm();
            k.KULLANICI_ID = Convert.ToInt16(kullaniciLe.EditValue);
            k.M_MENU_UST_ID = Convert.ToInt16(menuLke1.EditValue);
            k.M_MENU_ID = Convert.ToInt16(menuLke2.EditValue);
            testInfoBindingSource.DataSource = kulcntrl.Liste_Al(k);
            usr.gridControl1.DataSource = testInfoBindingSource;
            usr.gridView1.Columns["ID"].Visible = false;
            usr.gridView1.Columns["KULLANICI_ID"].Visible = false;
            usr.gridView1.Columns["M_ALANLAR_UST_ID"].Visible = false;
            usr.gridView1.Columns["M_ALANLAR_ID"].Visible = false;
            usr.gridView1.FocusedColumn = usr.gridView1.VisibleColumns[0];

        }
        private void menuLke1_EditValueChanged(object sender, EventArgs e)
        {
            int ust_id = Convert.ToInt16(menuLke1.EditValue);
            menuLke2.Properties.DataSource = Prodma.DataAccess.ListDenemeService.GetM_MENU_ID_BY_PARAM(0, ust_id);
        }
        private void menuLke2_EditValueChanged(object sender, EventArgs e)
        {
            int ust_id = Convert.ToInt16(menuLke2.EditValue);
            menuLke3.Properties.DataSource = Prodma.DataAccess.ListDenemeService.GetM_MENU_ID_BY_PARAM(0, ust_id);
        }
        private void menuLke3_EditValueChanged(object sender, EventArgs e)
        {
         
        }
        private void listKullaniciCmd_Click(object sender, EventArgs e)
        {
            tiklananButon = 0;
            usrBagliGridDoldur(true);
            usr.bindingSourceArr[menuId].DataSource = ListDenemeService.GetM_MENU_ID_BY_PARAM(0, 0);
            usr.repositoryItemLookUpEdit1[menuId].DataSource = usr.bindingSourceArr[menuId];
            yetkiMenulerVm.KULLANICI_ID = Convert.ToInt16(kullaniciLe.EditValue);
            yetkiMenulerVm.M_MENU_UST_ID = Convert.ToInt16(menuLke1.EditValue);
            yetkiMenulerVm.M_MENU_ID = 0;
            yetkiMenulerVm.ListeFiltresi = "1";
            testInfoBindingSource.DataSource = kulcntrl.Liste_Al(yetkiMenulerVm);
            usr.gridControl1.DataSource = testInfoBindingSource;
            usr.gridView1.Columns["ID"].Visible = false;
            usr.gridView1.Columns["KULLANICI_ID"].Visible = false;
            usr.gridView1.FocusedColumn = usr.gridView1.VisibleColumns[0];
        }
        private void listMenu1cmd_Click(object sender, EventArgs e)
        {
            tiklananButon = 1;
            int ust_id = 0;
            ust_id = Convert.ToInt16(menuLke1.EditValue);
            usr.bindingSourceArr[menuId].DataSource = ListDenemeService.GetM_MENU_ID_BY_PARAM(0, ust_id);
            usr.repositoryItemLookUpEdit1[menuId].DataSource = usr.bindingSourceArr[menuId];
            yetkiMenulerVm.KULLANICI_ID = Convert.ToInt16(kullaniciLe.EditValue);
            yetkiMenulerVm.M_MENU_UST_ID = Convert.ToInt16(menuLke1.EditValue);
            yetkiMenulerVm.M_MENU_ID = Convert.ToInt16(menuLke1.EditValue);
            testInfoBindingSource.DataSource = kulcntrl.Liste_Al(yetkiMenulerVm);
            usr.gridControl1.DataSource = testInfoBindingSource;
            usr.gridView1.Columns["ID"].Visible = false;
            usr.gridView1.Columns["KULLANICI_ID"].Visible = false;
            usr.gridView1.FocusedColumn = usr.gridView1.VisibleColumns[0];
        }
        private void listMenu2cmd_Click(object sender, EventArgs e)
        {
            tiklananButon = 2;
            int ust_id = 0;
            ust_id = Convert.ToInt16(menuLke2.EditValue);
            usr.bindingSourceArr[menuId].DataSource = ListDenemeService.GetM_MENU_ID_BY_PARAM(0, ust_id);
            usr.repositoryItemLookUpEdit1[menuId].DataSource = usr.bindingSourceArr[menuId];
            yetkiMenulerVm.KULLANICI_ID = Convert.ToInt16(kullaniciLe.EditValue);
            yetkiMenulerVm.M_MENU_UST_ID = Convert.ToInt16(menuLke1.EditValue);
            yetkiMenulerVm.M_MENU_ID = Convert.ToInt16(menuLke2.EditValue);
            testInfoBindingSource.DataSource = kulcntrl.Liste_Al(yetkiMenulerVm);
            usr.gridControl1.DataSource = testInfoBindingSource;
            usr.gridView1.Columns["ID"].Visible = false;
            usr.gridView1.Columns["KULLANICI_ID"].Visible = false;
            usr.gridView1.FocusedColumn = usr.gridView1.VisibleColumns[0];
        }
        private void listmenu3cmd_Click(object sender, EventArgs e)
        {

        }

        private void UYGULAcmd_Click(object sender, EventArgs e)
        {
            YetkiMenulerVm k = (YetkiMenulerVm)usr.ModelVm;
            OrtakIslemlerService.MenuYetkileriniKopyala(k);
            MessageBox.Show("İşlem Tamamlandı");
        }

        
    }
}