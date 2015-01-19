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
    public partial class Mesaj : TanitimSablon
    {
        #region degiskenler
        private LogCntrl kulcntrl = new LogCntrl();
        #endregion
        #region Constructors
        public Mesaj()
        {
            
            InitializeComponent();
            tabloAdi = "Log";
            this.Text = Gridi_Olustur();
            this.Text = "Mesaj";
            Tab_Gizle_Ekle();
            //Doldur();
        }
        private void Tab_Gizle_Ekle()
        {
            tabPage1.Text = "Prodma Mesaj";
            //tabPage2.Text = "Ek Bilgiler";

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
          Prodma.SistemB2C.Models.LogVm k = new  Prodma.SistemB2C.Models.LogVm();
          if (Globals.gnKullaniciId == 74)
          {
              k.Level = "MESAJ";
          }
          else
          {
              k.Level = "MESAJ";
              gridView1.Columns["Date"].Visible = false;
              gridView1.Columns["Logger"].Visible = false;
              k.Logger = Globals.gnKullaniciAd;
          }
          testInfoBindingSource.DataSource = kulcntrl.Liste_Al(k);
          base.gridControl1.DataSource = testInfoBindingSource;
          //gridView1.Columns["ID"].Visible = false;
          gridView1.FocusedColumn = gridView1.VisibleColumns[0];
        }
 
        #endregion
        #region İşlemler  (override edenler)
        public override void Kaydet()
        {
            Prodma.SistemB2C.Models.LogVm k = (Prodma.SistemB2C.Models.LogVm)ModelVm;
            k.Level = "MESAJ";
            k.Date = DateTime.Now;
            kulcntrl.Guncelle(k, k.Id);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Yeni_Kayit()
        {
            Prodma.SistemB2C.Models.LogVm k = (Prodma.SistemB2C.Models.LogVm)ModelVm;
            k.Level = "MESAJ";
            k.Date = DateTime.Now;
            kulcntrl.Ekle(k);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Sil()
        {
            Prodma.SistemB2C.Models.LogVm k = (Prodma.SistemB2C.Models.LogVm)ModelVm;
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