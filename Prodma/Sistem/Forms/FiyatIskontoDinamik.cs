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
    public partial class FiyatIskontoDinamik : Islemler
    {
        #region degiskenler
        private System.Windows.Forms.BindingSource testInfoBindingSource = new System.Windows.Forms.BindingSource();
        usrGridIslem usr = new usrGridIslem(GridIslemEn.Giris);
        private FiyatSatisIskontoDinamikCntrl kulcntrl = new FiyatSatisIskontoDinamikCntrl();
        public FiyatSatisIskontoDinamikVm FiyatSatisIskontoDinamikVm = new FiyatSatisIskontoDinamikVm();
        #endregion
        #region Constructors
        public FiyatIskontoDinamik()
        {
            InitializeComponent();
            usr.escapeKapatma = true;
            this.panel1.Controls.Add(usr);
            usr.Dock = DockStyle.Fill; 
            usr.tabloAdi = "FIYAT_SATIS_ISKONTO_DINAMIK";
            this.Text = usr.Gridi_Olustur();  
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
            //Control_Ayarla_Kayit(this.Controls, null, null, false);
            panelTamam.Visible = false;
            usr.controlNavigator1.Buttons.CustomButtons[2].Visible = true;
            usr.controlNavigator1.Buttons.CustomButtons[2].Tag = "Kopyala";
        }
        public void controlNavigatorButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString() == "Kopyala")
            {
                //FiyatSatisIskontoDinamikVm Vm = (FiyatSatisIskontoDinamikVm)usr.ModelVm;
                //if (Vm == null) return;
                //if (Vm.M_ALANLAR_ALT_ID ==null) return;
                //KullaniciMenuKopyalama kullaniciKopyalama = new KullaniciMenuKopyalama((int)KullaniciIslemleriTipEn.Bilgi_Bazli_Alan_Yetkileri);
                //kullaniciKopyalama.Dock = DockStyle.Fill;
                //kullaniciKopyalama.WindowState = FormWindowState.Normal;
                //kullaniciKopyalama.kaynakId = Vm.M_ALANLAR_ID;
                //kullaniciKopyalama.kaynakAlanlarAltId = (int)Vm.M_ALANLAR_ALT_ID;
                //kullaniciKopyalama.eskiKullaniciId = Vm.KULLANICI_ID;
                //kullaniciKopyalama.YetkiAlanAd = alanlarLe.Text;
                //kullaniciKopyalama.YetkiAlanAd += "-" + usr.gridView1.GetRowCellDisplayText(usr.gridView1.FocusedRowHandle, usr.gridView1.VisibleColumns[0]);
                //kullaniciKopyalama.Doldur();
                //kullaniciKopyalama.ShowDialog();
                //Doldur();
            }
        }
        public void usrDoldur(object sender, EventArgs e)
        {
            FiyatSatisIskontoDinamikVm k = new FiyatSatisIskontoDinamikVm();
            List<FiyatSatisIskontoDinamikVm> dinamikList = new List<FiyatSatisIskontoDinamikVm>();
            //k.KULLANICI_ID = Convert.ToInt16(kullaniciLe.EditValue);
            //k.M_ALANLAR_UST_ID = Convert.ToInt16(ustAlanlaLe.EditValue);
            //k.M_ALANLAR_ID = Convert.ToInt16(alanlarLe.EditValue);
            testInfoBindingSource.DataSource = kulcntrl.Liste_Al(FiyatSatisIskontoDinamikVm);
            usr.gridControl1.DataSource = testInfoBindingSource;
            //usr.gridView1.Columns["ID"].Visible = false;
            usr.gridView1.Columns["FIYAT_SATIS_ISKONTO_ID"].Visible = false;
            usr.gridView1.FocusedColumn = usr.gridView1.VisibleColumns[0];
        }
        public override void Doldur()
        {
            usrDoldur(null, null);
        }
        #endregion
        #region İşlemler  (override edenler)
        public void usrTabPage_Index_Changed(int index)
        {
            if (index != 0)
            {
                //alanlarLe.Properties.DataSource = ListDenemeService.GetM_ALANLAR_ID_BY_PARAM(0, (int)VarsayilanIdlerEn.M_Alanlar_Cari_Id);
                //ustAlanlaLe.Properties.DataSource = ListDenemeService.GetM_ALANLAR_ID_BY_PARAM(0, (int)VarsayilanIdlerEn.M_Alanlar_Stok_Id);
            }
        }
        public void usrKaydet(object sender, EventArgs e)
        {
            FiyatSatisIskontoDinamikVm k = (FiyatSatisIskontoDinamikVm)usr.ModelVm;
            kulcntrl.Guncelle(k, k.ID);
            usr.islemTamamDegil = kulcntrl.islemTamamDegilCntrl;
        }
        public void usrYeni_Kayit(object sender, EventArgs e)
        {
            FiyatSatisIskontoDinamikVm k = (FiyatSatisIskontoDinamikVm)usr.ModelVm;
            k.FIYAT_SATIS_ISKONTO_ID = FiyatSatisIskontoDinamikVm.FIYAT_SATIS_ISKONTO_ID;
            kulcntrl.Ekle(k);
            usr.islemTamamDegil = kulcntrl.islemTamamDegilCntrl;
        }
        public void usrSil(object sender, EventArgs e)
        {
            FiyatSatisIskontoDinamikVm k = (FiyatSatisIskontoDinamikVm)usr.ModelVm;
            kulcntrl.Sil(k.ID, k);
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
                    if (usr.repositoryItemLookUpEdit1[i].Name == "M_ALANLAR_ID")
                    {
                        //int ust_id = Convert.ToInt16(usr.gridView1.GetRowCellValue(usr.gridView1.FocusedRowHandle, "M_ALANLAR_UST_ID"));
                        //if (hepsi == true)
                        //    bindingSourceArr[i].DataSource = Prodma.DataAccess.ListDenemeService.GetM_ALANLAR_ID_BY_PARAM(0, ust_id);
                        //else
                        //    bindingSourceArr[i].DataSource = Prodma.DataAccess.ListService.GetM_ALANLAR_ID(0);
                        //repositoryItemLookUpEdit1[i].DataSource = bindingSourceArr[i];
                    }
                    else if (usr.repositoryItemLookUpEdit1[i].Name == "M_ALANLAR_CARI_ID")
                    {
                        // BindingSource bn = new BindingSource();
                        //string mt = "Get" + ustAlanlaLe.Text;
                        //if (hepsi == true)
                        //    usr.bindingSourceArr[i].DataSource = ListService.InvokeMethod(mt,(int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"", "",0 );
                        //else
                        //    usr.bindingSourceArr[i].DataSource = ListService.InvokeMethod(mt,(int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"", "",0 );

                        //usr.repositoryItemLookUpEdit1[i].DataSource = usr.bindingSourceArr[i];
                        //if (usr.repositoryItemLookUpEdit1[i].View.Columns.Count>0)
                        //usr.repositoryItemLookUpEdit1[i].View.Columns[0].Visible = false;
                    }
                    else if (usr.repositoryItemLookUpEdit1[i].Name == "M_ALANLAR_STOK_ID")
                    {
                        // BindingSource bn = new BindingSource();
                        //string mt = "Get" + alanlarLe.Text;
                        //if (hepsi == true)
                        //    usr.bindingSourceArr[i].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, 0, 0, "", "", 0);
                        //else
                        //    usr.bindingSourceArr[i].DataSource = ListService.InvokeMethod(mt, (int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, 0, 0, "", "", 0);

                        //usr.repositoryItemLookUpEdit1[i].DataSource = usr.bindingSourceArr[i];
                        //if (usr.repositoryItemLookUpEdit1[i].View.Columns.Count > 0)
                        //    usr.repositoryItemLookUpEdit1[i].View.Columns[0].Visible = false;
                    }
                }
            }
        }
        public void usrValidateRow(object sender, EventArgs e)
        {
            usr.blnValidateRow = true;
            if (usr.gridView1.GetRowCellValue(usr.gridView1.FocusedRowHandle, "M_ALANLAR_ID") == null) { usr.kayitTamam = false; }
        }
        #endregion
        private void alanlarLe_EditValueChanged(object sender, EventArgs e)
        {
            //usrBagliGridDoldur(true);
            //FiyatSatisIskontoDinamikVm k = new FiyatSatisIskontoDinamikVm();
            //k.KULLANICI_ID = Convert.ToInt16(kullaniciLe.EditValue);
            //k.M_ALANLAR_UST_ID = Convert.ToInt16(ustAlanlaLe.EditValue);
            //k.M_ALANLAR_ID = Convert.ToInt16(alanlarLe.EditValue);
            //testInfoBindingSource.DataSource = kulcntrl.Liste_Al(k);
            //usr.gridControl1.DataSource = testInfoBindingSource;
            //usr.gridView1.Columns["ID"].Visible = false;
            //usr.gridView1.Columns["KULLANICI_ID"].Visible = false;
            //usr.gridView1.Columns["M_ALANLAR_UST_ID"].Visible = false;
            //usr.gridView1.Columns["M_ALANLAR_ID"].Visible = false;
            //usr.gridView1.Columns["M_ALANLAR_ALT_ID"].Visible = true;
            //usr.gridView1.FocusedColumn = usr.gridView1.VisibleColumns[0];
        }
        private void ustAlanlarLe_EditValueChanged(object sender, EventArgs e)
        {
            //int ust_id = Convert.ToInt16(ustAlanlaLe.EditValue);
            //alanlarLe.Properties.DataSource = Prodma.DataAccess.ListDenemeService.GetM_ALANLAR_ID_BY_PARAM(0, ust_id);
        }
    }
}