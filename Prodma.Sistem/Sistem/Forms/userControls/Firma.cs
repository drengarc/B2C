using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Prodma.DataAccessB2C;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Prodma.SistemB2C.Models;
using Prodma.SistemB2C.Controllers;
using Prodma.WinForms;
namespace Prodma.Sistem.Forms
{
    public partial class Firma : TanitimSablon
    {
        #region degiskenler
        private int idint;
        private FirmaCntrl kulcntrl = new FirmaCntrl();
        private FirmaVm FirmaVm;
        private usrFirmaEkBilgi FirmaEkBilgi;
        #endregion
        #region Constructors
        public Firma()
        {
            InitializeComponent();
            tabloAdi = "FIRMA";
            this.Text = Gridi_Olustur();   
            Tab_Gizle_Ekle();
            //Doldur();
        }
        private void Tab_Gizle_Ekle()
        {


            tabPage1.Text = "Firma Giriş";
            tabPage2.Text = "Ek Bilgiler";

            //this.tabControl1.TabPages.Remove(tabPage2);
            //controlNavigator2.NavigatableControl = base.gridControl1;
            this.tabPage2.Controls.Remove(this.controlNavigator2);

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
            //controlNavigator13.NavigatableControl = base.gridControl1;



        }
        public override void Doldur()
        {
            testInfoBindingSource.DataSource = kulcntrl.Liste_Al(FirmaVm);
            base.gridControl1.DataSource = testInfoBindingSource;
            gridView1.Columns["ID"].Visible = false;
            gridView1.FocusedColumn = gridView1.VisibleColumns[0];
        }
        #endregion
        #region İşlemler  (override edenler)
        public override void Kaydet()
        {
            FirmaVm k = (FirmaVm)ModelVm;
            kulcntrl.Guncelle(k, k.ID);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;
        }
        public override void Yeni_Kayit()
        {
            FirmaVm k = (FirmaVm)ModelVm;
            kulcntrl.Ekle(k);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;
        }
        public override void Sil()
        {
            FirmaVm k = (FirmaVm)ModelVm;
            kulcntrl.Sil(k.ID,k);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Yazdir()
        {
        }
        public override void Bul()
        {
        }
        public override void Vazgec()
        { 
        }
        #endregion
        #region Ek Tab İşlemleri
        public override void TabPage_Index_Changed(int index)
        {
            if (index == 0)
            {
                this.escapeKapat = true;
            }
            else if (index == 1)
            {
                TabIndex2_Ac(index);
            }
            //else if (index == 2)
            //{
            //    TabIndex3_Ac(index);
            //}
        }

        public void TabIndex2_Ac(int index)
        {
            //tabPage2.Controls.Clear();
        //    usrGridBilgi.Dinamik_Text_Box_Doldur(gridView1);
            if (FirmaEkBilgi == null)
            {
                FirmaEkBilgi = new usrFirmaEkBilgi();
                FirmaEkBilgi.Dock = DockStyle.Top;
                tabPage2.Controls.Add(FirmaEkBilgi);
            }
            usrGridBilgi.Dock = DockStyle.Top;
            tabPage2.Controls.Add(usrGridBilgi);
            FirmaVm k = (FirmaVm)ModelVm;
            FirmaEkBilgi.sifirliVm = k;
            FirmaEkBilgi.Doldur();
        }

        public void TabIndex3_Ac(int index)
        {
            //usrGridBilgi.Dinamik_Text_Box_Doldur(gridView1);

            //if (FirmaOdeme == null)
            //{
            //    FirmaOdeme = new FirmaOdeme();
            //    FirmaOdeme.Dock = DockStyle.Top;
            //    tabPage3.Controls.Add(FirmaOdeme);
            //}

            //usrGridBilgi.Dock = DockStyle.Top;
            //tabPage3.Controls.Add(usrGridBilgi);
            //FirmaVm k = (FirmaVm)ModelVm;

            //FirmaOdeme.FirmaOdemeVm = new FirmaOdemeVm();
            //FirmaOdeme.FirmaOdemeVm.SABIT_KIYMET_ID = k.ID;
            //FirmaOdeme.Doldur();
        }
        #endregion
    }
}