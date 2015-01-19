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
namespace Prodma.Sistem.Forms
{
    public partial class YetkiAlanlarGrid : Islemler
    {
        #region degiskenler
        private System.Windows.Forms.BindingSource testInfoBindingSource = new System.Windows.Forms.BindingSource();
        public usrGridIslem usr = new usrGridIslem(GridIslemEn.Guncelle);
        private AlanlarCntrl kulcntrl = new AlanlarCntrl();
        public AlanlarVm alanlarModel = new AlanlarVm();
        #endregion
        #region Constructors
        public YetkiAlanlarGrid()
        {

            InitializeComponent();
            usr.escapeKapatma = true;
            this.panel1.Controls.Add(usr);
            usr.Dock = DockStyle.Fill; 
            usr.tabloAdi = "M_ALANLAR";
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
            usrTabPage_Index_Changed(1);
            listKullaniciCmd.Enabled = true;
            Control_Ayarla_Kayit(this.Controls, null, listKullaniciCmd, false);
        }
        public void usrDoldur(object sender, EventArgs e)
        {
            EventArgs a = new EventArgs();
            testInfoBindingSource.DataSource = ListDenemeService.GetALANLAR_KULLANICI(alanlarModel.KULLANICI_ID);
            usr.gridControl1.DataSource = testInfoBindingSource;
            usr.gridView1.Columns["ID"].Visible = false;
            usr.gridView1.FocusedColumn = usr.gridView1.VisibleColumns[0];
            //listKullaniciCmd_Click(usr.gridView1, a);
        }
        public override void Doldur()
        {
            EventArgs a = new EventArgs();
            testInfoBindingSource.DataSource = ListDenemeService.GetALANLAR_KULLANICI(alanlarModel.KULLANICI_ID);
            usr.gridControl1.DataSource = testInfoBindingSource;
            usr.gridView1.Columns["ID"].Visible = false;
            usr.gridView1.FocusedColumn = usr.gridView1.VisibleColumns[0];
            //listKullaniciCmd_Click(usr.gridView1, a);
        }
        #endregion
        #region İşlemler  (override edenler)
        public void usrTabPage_Index_Changed(int index)
        {
            if (index != 0)
            {
                YardimciIslemler.InvokeLkeSet("M_ALANLAR_UST_ID", kullaniciLe);
            }
        }
        public void usrKaydet(object sender, EventArgs e)
        {
            AlanlarVm k = (AlanlarVm)usr.ModelVm;
            kulcntrl.Guncelle(k, k.ID);
          //  lblBilgi.Text = kulcntrl.MesajYaz();
            usr.islemTamamDegil = kulcntrl.islemTamamDegilCntrl;
           // usrDoldur();
        }
        public void usrYeni_Kayit(object sender, EventArgs e)
        {
          //  AlanlarVm k = (AlanlarVm)usr.ModelVm;
          //  k.KULLANICI_ID = Convert.ToInt16(kullaniciLe.EditValue);
          //  k.M_MENU_UST_ID = Convert.ToInt16(menuLke1.EditValue);
          ////  k.M_MENU_ID = Convert.ToInt16(menuLke2.EditValue);
          //  kulcntrl.Ekle(k);
          // // lblBilgi.Text = kulcntrl.MesajYaz();
          //  usr.islemTamamDegil = kulcntrl.islemTamamDegilCntrl;
        }
        public void usrSil(object sender, EventArgs e)
        {
           // AlanlarVm k = (AlanlarVm)usr.ModelVm;
           // kulcntrl.Sil(k.ID, k);
           //// lblBilgi.Text = kulcntrl.MesajYaz();
           // usr.islemTamamDegil = kulcntrl.islemTamamDegilCntrl;
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
        public void usrValidateRow(object sender, EventArgs e)
        {
            usr.blnValidateRow = true;
            if (usr.gridView1.GetRowCellValue(usr.gridView1.FocusedRowHandle, "M_MENU_ID") == null) { usr.kayitTamam = false; }
        }
        #endregion
        private void alanlarLe_EditValueChanged(object sender, EventArgs e)
        {
            //usrBagliGridDoldur(true);
            //AlanlarVm k = new AlanlarVm();
            //k.KULLANICI_ID = Convert.ToInt16(kullaniciLe.EditValue);
            //k.M_MENU_UST_ID = Convert.ToInt16(menuLke1.EditValue);
            //k.M_MENU_ID = Convert.ToInt16(menuLke2.EditValue);
            //testInfoBindingSource.DataSource = kulcntrl.Liste_Al(k);
            //usr.gridControl1.DataSource = testInfoBindingSource;
            //usr.gridView1.Columns["ID"].Visible = false;
            //usr.gridView1.Columns["KULLANICI_ID"].Visible = false;
            //usr.gridView1.Columns["M_ALANLAR_UST_ID"].Visible = false;
            //usr.gridView1.Columns["M_ALANLAR_ID"].Visible = false;
            //usr.gridView1.FocusedColumn = usr.gridView1.VisibleColumns[0];

        }
        private void listKullaniciCmd_Click(object sender, EventArgs e)
        {
            //if (alanlarVm.KULLANICI_ID == null) return;
            //tiklananButon = 0;
            //int ust_id = 0;
            //ust_id = Convert.ToInt16(kullaniciLe.EditValue);
            //testInfoBindingSource.DataSource = ListDenemeService.GetALANLAR_TABLO(ust_id,null);
            //if (testInfoBindingSource.Count == 0)
            //{
            //    KayitKopyala(alanlarVm);    
            //}
            KayitKopyala(alanlarModel);
            Doldur();
        }
        void KayitKopyala(AlanlarVm Vm)
        {
            int insertId = 0;
            AlanlarVm Vm1 = new AlanlarVm();
            Vm1.M_ALANLAR_ID = Convert.ToInt16(kullaniciLe.EditValue);
            List<AlanlarVm> listAlanlar = new List<AlanlarVm>();
            listAlanlar = ListDenemeService.GetALANLAR_TABLO((int)Vm1.M_ALANLAR_ID,null);
            foreach (var item in listAlanlar)
            {
                Vm1 = item;
                if (Vm1.M_ALANLAR_ID == 0)
                {
                    Vm1.KULLANICI_ID = Vm.KULLANICI_ID;
                    Vm1.M_ALANLAR_ID = 0;
                    kulcntrl.Ekle(Vm1);
                    insertId = kulcntrl.insertId;
                }
                else
                {
                    Vm1.KULLANICI_ID = Vm.KULLANICI_ID;
                    Vm1.M_ALANLAR_ID = insertId;
                    kulcntrl.Ekle(Vm1);
                }

            }

        }
        public void KayitKopyala1()
        {
            // ProdmaEntities context = new ProdmaEntities();
            //bool cekEkle=true;
            //using (context)
            //{
            //    var irsaliye = (from irs in context.M_ALANLAR
            //                    group irs by new
            //                    {
            //                        irs.CEK_TANITIM_ID
            //                    } into g
            //                    select new
            //                    {
            //                        CEK_TANITIM_ID = g.Key,
            //                        sonuc = g,
            //                    }).ToList();
            //}
        }
    }
}