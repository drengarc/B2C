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
using Prodma.DataAccess;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Prodma.Sistem.Forms;
using Prodma.Sistem.Controllers;
using Prodma.Sistem.Models;
namespace Prodma.Sistem.Forms
{
    public partial class IrsaliyeAyarTip : TanitimSablon
    {
        #region degiskenler
        private FaturaIsraliyeAyarTipCntrl kulcntrl = new FaturaIsraliyeAyarTipCntrl();
        public FaturaIrsaliyeAyarTipVm faturaIrsaliyeAyarTipVm;
        private usrFaturaAyar usrFaturaAyar;
        private usrIrsaliyeYaziciAyar usrIrsaliyeYaziciAyar;
        #endregion
        #region Constructors
        public IrsaliyeAyarTip()
        {
            
            InitializeComponent();
            tabloAdi = "FATURA_IRSALIYE_AYAR_TIP";
            this.Text = Gridi_Olustur();  
            Tab_Gizle_Ekle();
            //Doldur();
            
        }
        private void Tab_Gizle_Ekle()
        {


            tabPage1.Text ="Fatura İrsaliye Ayar Tip";
            tabPage2.Text = "Ek Bilgiler";
            tabPage2.AutoScroll = true;
            //this.tabControl1.TabPages.Remove(tabPage2);
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
          faturaIrsaliyeAyarTipVm = new FaturaIrsaliyeAyarTipVm();
          faturaIrsaliyeAyarTipVm.FATURA_IRSALIYE_TIP_ID = (int)FaturaIrsaliyeAyarTipEn.IRSALIYE; 
          testInfoBindingSource.DataSource = kulcntrl.Liste_Al(faturaIrsaliyeAyarTipVm);
          base.gridControl1.DataSource = testInfoBindingSource;
          gridView1.Columns["ID"].Visible = false;
          gridView1.FocusedColumn = gridView1.VisibleColumns[0];
        }
       
        
        #endregion
        #region İşlemler  (override edenler)
        public override void Kaydet()
        {
            FaturaIrsaliyeAyarTipVm k = (FaturaIrsaliyeAyarTipVm)ModelVm;
            kulcntrl.Guncelle(k, k.ID);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Yeni_Kayit()
        {
            FaturaIrsaliyeAyarTipVm k = (FaturaIrsaliyeAyarTipVm)ModelVm;
            k.FATURA_IRSALIYE_TIP_ID = (int)FaturaIrsaliyeAyarTipEn.IRSALIYE; 
            kulcntrl.Ekle(k);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Sil()
        {
            FaturaIrsaliyeAyarTipVm k = (FaturaIrsaliyeAyarTipVm)ModelVm;
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
                YaziciAyarKopyalama frm = new YaziciAyarKopyalama();
                frm.ShowDialog();

            }
        }
        #endregion
        #region Ek Tab İşlemeleri
        public override void TabPage_Index_Changed(int index)
        {
            if (index == 0)
            {
                this.escapeKapat = true;
            }
            else if (index == 1)
            {
                TabIndex2_Ac(gridView1.FocusedRowHandle);
            }
        }

        private void TabIndex2_Ac(int index)
        {
            FaturaIrsaliyeAyarTipVm k = (FaturaIrsaliyeAyarTipVm)ModelVm;
                if (usrIrsaliyeYaziciAyar == null)
                {
                    usrIrsaliyeYaziciAyar = new usrIrsaliyeYaziciAyar();
                }
                usrIrsaliyeYaziciAyar.faturaIrsaliyeAyarID = k.ID;
                usrIrsaliyeYaziciAyar.Doldur();
                this.tabPage2.Controls.Clear();
                this.tabPage2.Controls.Add(this.usrIrsaliyeYaziciAyar);
        }
        #endregion

    }
}