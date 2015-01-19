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
using Prodma.SistemB2C.Models;
using Prodma.SistemB2C.Controllers;
namespace Prodma.Sistem.Forms
{
    public partial class YetkiAlanlar : TanitimSablon
    {
        #region degiskenler
        private YetkiAlanlarCntrl kulcntrl = new YetkiAlanlarCntrl();
        public YetkiAlanlarVm yetkiAlanlarVm;
        #endregion
        #region Constructors
        public YetkiAlanlar()
        {
            //escapeKapatma = true;
            InitializeComponent();
            tabloAdi = "YETKI_ALANLAR";
            this.Text = Gridi_Olustur();   
            Tab_Gizle_Ekle();
            this.WindowState = FormWindowState.Normal;
            //Doldur();
        }
        private void Tab_Gizle_Ekle()
        {
            tabPage1.Text = "Yetki Alanlar Bilgi Giriş";

            //this.tabControl1.TabPages.Remove(tabPage2);
            //controlNavigator2.NavigatableControl = base.gridControl1;
            controlNavigator2.Visible = false;

            this.tabControl1.TabPages.Remove(tabPage2);
      //      panel2.Controls.Add(yBilgi.controlNavigator1);
           
            this.tabControl1.TabPages.Remove(tabPage3);
            //controlNavigator3.NavigatableControl = base.gridControl1;

            this.tabControl1.TabPages.Remove(tabPage4);
            controlNavigator4.NavigatableControl = base.gridControl1;

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
            //controlNavigator13.NavigatableControl = base.gridControl1;



        }
        public override void Doldur()
        {
            testInfoBindingSource.DataSource = kulcntrl.Liste_Al(yetkiAlanlarVm);
          base.gridControl1.DataSource = testInfoBindingSource;
          gridView1.Columns["ID"].Visible = false;
          gridView1.Columns["KULLANICI_ID"].Visible = false;
          gridView1.Columns["M_ALANLAR_ALT_ID"].Visible = false;
          gridView1.FocusedColumn = gridView1.VisibleColumns[0];
        }
        public override void CustomButonEkle()
        {
            int yetkiIndex = 0;
            this.controlNavigator1.CustomButtons[1].Tag = "Kopyalama";
            this.controlNavigator1.CustomButtons[1].Hint = "Kopyalama";
            this.controlNavigator1.CustomButtons[1].ImageIndex = 5;
            yetkiIndex++;
            for (int i = 0; i < 7 - yetkiIndex; i++)
            {
                this.controlNavigator1.CustomButtons.RemoveAt(yetkiIndex + 1);
            }
        }
        public override void Custom_Buton_Islemleri(string islem)
        {
           YetkiAlanlarVm Vm = (YetkiAlanlarVm)ModelVm;
           if (islem == "Kopyalama")
            {
                if (Vm == null) return;
                KullaniciMenuKopyalama kullaniciKopyalama = new KullaniciMenuKopyalama((int)KullaniciIslemleriTipEn.Alan_Yetkileri);
                kullaniciKopyalama.Dock = DockStyle.Fill;
                kullaniciKopyalama.WindowState = FormWindowState.Normal;
                kullaniciKopyalama.kaynakId = Vm.M_ALANLAR_ID;
                kullaniciKopyalama.eskiKullaniciId = Vm.KULLANICI_ID;
                kullaniciKopyalama.YetkiAlanAd = gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridView1.VisibleColumns[0]);
                kullaniciKopyalama.YetkiAlanAd += "-" + gridView1.GetRowCellDisplayText(gridView1.FocusedRowHandle, gridView1.VisibleColumns[1]);
                kullaniciKopyalama.Doldur();
                kullaniciKopyalama.ShowDialog();
                Doldur();
           }
        }
        #endregion
        #region İşlemler  (override edenler)
        public override void Kaydet()
        {
            YetkiAlanlarVm k = (YetkiAlanlarVm)ModelVm;
            k.KULLANICI_ID = yetkiAlanlarVm.KULLANICI_ID;
            kulcntrl.Guncelle(k, k.ID);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Yeni_Kayit()
        {
            YetkiAlanlarVm k = (YetkiAlanlarVm)ModelVm;
            k.KULLANICI_ID = yetkiAlanlarVm.KULLANICI_ID;
            kulcntrl.Ekle(k);
            //k.ID = kulcntrl.insertId;
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Sil()
        {
            YetkiAlanlarVm k = (YetkiAlanlarVm)ModelVm;
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
        public override void BagliGridDoldur(bool hepsi)
        {
          
                //for (int i = 0; i < 16; i++)
                //{
                //if (base.repositoryItemLookUpEdit1[i]!=null)
                //  {
                //    if (base.repositoryItemLookUpEdit1[i].Name == "M_ALANLAR_ID")
                //    {
                //        BindingSource bn = new BindingSource();
                //        int ust_id = Convert.ToInt16(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "M_ALANLAR_UST_ID"));
                //        if (hepsi == true)
                //           bn.DataSource = Prodma.DataAccessB2C.ListDenemeService.GetM_ALANLAR_ID_BY_PARAM(0,ust_id);
                //        else
                //            bn.DataSource = Prodma.DataAccess.ListService.GetM_ALANLAR_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
                //        base.repositoryItemLookUpEdit1[i].DataSource = bn;
                //    }
                //  }
                //}
        }
        public override void ValidateRow(int FocusedRowHandle) 
        {
            blnValidateRow = true;
            if (gridView1.GetRowCellValue(FocusedRowHandle, "M_ALANLAR_ID") == null) { kayitTamam = false; }
        }
        public override void ShownEditor()
        {
            if (gridView1.FocusedColumn.FieldName == "M_ALANLAR_ID" && gridView1.ActiveEditor is
DevExpress.XtraEditors.GridLookUpEdit)
            {

                DevExpress.XtraEditors.GridLookUpEdit edit;
                edit = (DevExpress.XtraEditors.GridLookUpEdit)gridView1.ActiveEditor;
                int introw = gridView1.FocusedRowHandle;
                int ust_id = Convert.ToInt16(gridView1.GetRowCellValue(introw, "M_ALANLAR_UST_ID"));
                edit.Properties.DataSource = ListDenemeService.GetM_ALANLAR_ID_BY_PARAM(0, ust_id);
                edit.Properties.DisplayMember = "AD";
                edit.Properties.ValueMember = "ID";
                //edit.View.Columns[0].Visible = false;  
            }
        }
        #endregion
    }
}