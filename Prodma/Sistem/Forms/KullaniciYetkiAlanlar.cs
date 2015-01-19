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
//using Prodma.Sistem.Models;
using Prodma.Sistem.Controllers;
using Prodma.Sistem.Models;
namespace Prodma.Sistem.Forms
{
    public partial class KullaniciYetkiAlanlar : TanitimSablon
    {
        #region degiskenler

        private YetkiAlanlarCntrl kulcntrl = new YetkiAlanlarCntrl();
        #endregion
        #region Constructors
        public KullaniciYetkiAlanlar()
        {
            
            InitializeComponent();
            tabloAdi = "YETKI_ALANLAR";
            this.Text = Gridi_Olustur();   
            Tab_Gizle_Ekle();
            //Doldur();
        }
        public override void CustomButonEkle()
        {
            int yetkiIndex = 0;
            this.controlNavigator1.CustomButtons[1].Tag = "AlanBazli";
            this.controlNavigator1.CustomButtons[1].Hint = "Alan Bazlı Bilgiler";
            this.controlNavigator1.CustomButtons[1].ImageIndex = 5;
            yetkiIndex++;
            this.controlNavigator1.CustomButtons[2].Tag = "BilgiBazli";
            this.controlNavigator1.CustomButtons[2].Hint = "Alan Bilgi Bazlı Bilgiler";
            this.controlNavigator1.CustomButtons[2].ImageIndex = 5;
            yetkiIndex++;
            for (int i = 0; i < 7 - yetkiIndex; i++)
            {
                this.controlNavigator1.CustomButtons.RemoveAt(yetkiIndex + 1);
            }
        }
        public override void Custom_Buton_Islemleri(string islem)
        {
            YetkiAlanlarVm Vm = (YetkiAlanlarVm)ModelVm;
            if (islem == "AlanBazli")
            {
                YetkiAlanlarVm k = new YetkiAlanlarVm();
                k.ListeFiltresi = "Kullanıcı";
                List<YetkiAlanlarVm> list  = kulcntrl.Liste_Al(k).ToList();
                List<YetkiAlanlarVm> list1 = list.Where(w => w.M_ALANLAR_ALT_ID == null).ToList();  
                //testInfoBindingSource.DataSource = kulcntrl.Liste_Al(k).Where(w => w.M_ALANLAR_ALT_ID == null).ToList();
                base.gridControl1.DataSource = list1;
                gridView1.Columns["ID"].Visible = false;
                gridView1.FocusedColumn = gridView1.VisibleColumns[0];
            }
            if (islem == "BilgiBazli")
            {
                YetkiAlanlarVm k = new YetkiAlanlarVm();
                k.ListeFiltresi = "Kullanıcı";
                List<YetkiAlanlarVm> list = kulcntrl.Liste_Al(k).ToList();
                List<YetkiAlanlarVm> list1 = list.Where(w => w.M_ALANLAR_ALT_ID != null).ToList();
                base.gridControl1.DataSource = list1;
                gridView1.Columns["ID"].Visible = false;
                gridView1.FocusedColumn = gridView1.VisibleColumns[0];
            }
        }
        private void Tab_Gizle_Ekle()
        {
            tabPage1.Text = "YetkiAlanlar Bilgi Giriş";

            this.tabControl1.TabPages.Remove(tabPage2);
            controlNavigator2.NavigatableControl = base.gridControl1;

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
          YetkiAlanlarVm k = new YetkiAlanlarVm();
          k.ListeFiltresi = "Kullanıcı";
          testInfoBindingSource.DataSource = kulcntrl.Liste_Al(k);
          base.gridControl1.DataSource = testInfoBindingSource;
          gridView1.Columns["ID"].Visible = false;
          gridView1.FocusedColumn = gridView1.VisibleColumns[0];
        }
 
        #endregion
        #region İşlemler  (override edenler)
        public override void Kaydet()
        {
            YetkiAlanlarVm k = (YetkiAlanlarVm)ModelVm;
            kulcntrl.Guncelle(k, k.ID);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Yeni_Kayit()
        {
            YetkiAlanlarVm k = (YetkiAlanlarVm)ModelVm;
            kulcntrl.Ekle(k);
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
 
      
        #endregion
    }
}