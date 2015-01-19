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
using Prodma.DataAccessB2C; using Prodma.WinForms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Prodma.Sistem.Controllers;
using Prodma.Sistem.Models;

namespace Prodma.Sistem.Forms
{
    public partial class FaturaIrsaliyeTip : TanitimSablon
    {
        #region degiskenler
        private FaturaIsraliyeTipCntrl kulcntrl = new FaturaIsraliyeTipCntrl();
        public FaturaIrsaliyeTipVm faturaIrsaliyeTipVm;
        #endregion
        #region Constructors
        public FaturaIrsaliyeTip()
        {
            
            InitializeComponent();
            tabloAdi = "FATURA_IRSALIYE_TIP";
            this.Text = Gridi_Olustur();  
            Tab_Gizle_Ekle();
            //Doldur();
            
        }
        private void Tab_Gizle_Ekle()
        {


            tabPage1.Text =this.Text;
            tabPage2.Text = "Ek Bilgiler";

            this.tabControl1.TabPages.Remove(tabPage2);
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
            //controlNavigator13.NavigatableControl = base.gridControl1;



        }
        public override void Doldur()
        {

            testInfoBindingSource.DataSource = kulcntrl.Liste_Al(faturaIrsaliyeTipVm);
          base.gridControl1.DataSource = testInfoBindingSource;
          gridView1.Columns["ID"].Visible = false;
          gridView1.FocusedColumn = gridView1.VisibleColumns[0];
        }
       
        
        #endregion
        #region İşlemler  (override edenler)
        public override void Kaydet()
        {
            FaturaIrsaliyeTipVm k = (FaturaIrsaliyeTipVm)ModelVm;
            kulcntrl.Guncelle(k, k.ID);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Yeni_Kayit()
        {
            FaturaIrsaliyeTipVm k = (FaturaIrsaliyeTipVm)ModelVm;
            kulcntrl.Ekle(k);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Sil()
        {
            FaturaIrsaliyeTipVm k = (FaturaIrsaliyeTipVm)ModelVm;
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
            if (args.KeyCode == Keys.F9)
            {
                //YaziciAyarKopyalama frm = new YaziciAyarKopyalama();
                //frm.ShowDialog();

            }
        }
        #endregion
 
    }
}