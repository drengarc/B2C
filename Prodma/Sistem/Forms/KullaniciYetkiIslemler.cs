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
    public partial class KullaniciYetkiIslemler : TanitimSablon
    {
        #region degiskenler

        private YetkiIslemlerCntrl kulcntrl = new YetkiIslemlerCntrl();
        #endregion
        #region Constructors
        public KullaniciYetkiIslemler()
        {
            
            InitializeComponent();
            tabloAdi = "YETKI_ISLEMLER";
            this.Text = Gridi_Olustur();   
            Tab_Gizle_Ekle();
            //Doldur();
        }
        private void Tab_Gizle_Ekle()
        {
            tabPage1.Text = "Yetki İşlemler Bilgi Giriş";

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
          YetkiIslemlerVm k = new YetkiIslemlerVm();
          k.ListeFiltresi = "";
          testInfoBindingSource.DataSource = kulcntrl.Liste_Al(k);
          base.gridControl1.DataSource = testInfoBindingSource;
          gridView1.Columns["ID"].Visible = false;
          gridView1.FocusedColumn = gridView1.VisibleColumns[0];
        }
 
        #endregion
        #region İşlemler  (override edenler)
        public override void Kaydet()
        {
            YetkiIslemlerVm k = (YetkiIslemlerVm)ModelVm;
            kulcntrl.Guncelle(k, k.ID);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Yeni_Kayit()
        {
            YetkiIslemlerVm k = (YetkiIslemlerVm)ModelVm;
            kulcntrl.Ekle(k);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Sil()
        {
            YetkiIslemlerVm k = (YetkiIslemlerVm)ModelVm;
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