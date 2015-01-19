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
namespace Prodma.Sistem.Forms
{
    public partial class FiyatSatisIskonto : TanitimSablon
    {
        #region degiskenler
        private FiyatSatisIskontoCntrl kulcntrl = new FiyatSatisIskontoCntrl();
        #endregion
        #region Constructors
        public FiyatSatisIskonto()
        {
            
            InitializeComponent();
            tabloAdi = "FIYAT_SATIS_ISKONTO";
            this.Text = Gridi_Olustur();   
            Tab_Gizle_Ekle();
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.Dinamik_TextBox_Olustur);

        }
        private void Tab_Gizle_Ekle()
        {
            tabPage1.Text = "Fiyat Iskonto Düzenleme";
            tabPage2.Text = "Ek Bilgiler (F8)";
            usrGridBilgi.Kart_Bilgi_Duzenle(gridView1);
            //this.tabControl1.TabPages.Remove(tabPage2);
            //controlNavigator2.NavigatableControl = base.gridControl1;
            //controlNavigator2.Visible = false;

            this.tabControl1.TabPages.Remove(tabPage3);
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
        public override void Tanitim_KeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                tabControl1.SelectedTabPage = tabPage2;
            }
            
        }
        public override void Doldur()
        {
            FiyatSatisIskontoVm k = new FiyatSatisIskontoVm();
          testInfoBindingSource.DataSource = kulcntrl.Liste_Al(null);
          base.gridControl1.DataSource = testInfoBindingSource;
          gridView1.Columns["ID"].Visible = false;
          //gridView1.Columns["M_ALANLAR_ALT_ID"].Visible = false;
          gridView1.FocusedColumn = gridView1.VisibleColumns[0];
        }
        #endregion
        #region İşlemler  (override edenler)
        public override void Kaydet()
        {
            FiyatSatisIskontoVm k = (FiyatSatisIskontoVm)ModelVm;
            kulcntrl.Guncelle(k, k.ID);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Yeni_Kayit()
        {
            FiyatSatisIskontoVm k = (FiyatSatisIskontoVm)ModelVm;
            kulcntrl.Ekle(k);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Sil()
        {
            FiyatSatisIskontoVm k = (FiyatSatisIskontoVm)ModelVm;
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
        public void TabIndex1_Ac(int index)
        {
            FiyatSatisIskontoVm k = (FiyatSatisIskontoVm)ModelVm;
            tabPage2.Controls.Clear();
            usrGridBilgi.Dinamik_Text_Box_Doldur(gridView1);
            FiyatIskontoDinamik frmYetkiAlanlarBilgiUsr = new FiyatIskontoDinamik();
            frmYetkiAlanlarBilgiUsr.TopLevel = false;
            frmYetkiAlanlarBilgiUsr.ControlBox = false;
            tabPage2.Controls.Add(frmYetkiAlanlarBilgiUsr);
            frmYetkiAlanlarBilgiUsr.Dock = DockStyle.Fill;
            usrGridBilgi.Dock = DockStyle.Top;
            tabPage2.Controls.Add(usrGridBilgi);
            frmYetkiAlanlarBilgiUsr.Show();
            frmYetkiAlanlarBilgiUsr.FiyatSatisIskontoDinamikVm.FIYAT_SATIS_ISKONTO_ID = k.ID;
            frmYetkiAlanlarBilgiUsr.Doldur();
        }
        #region ektabislemleri
        public override void Dinamik_TextBox_Olustur(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            usrGridBilgi.Dinamik_TextBox_Olustur(sender, e);
        }
        public override void TabPage_Index_Changed(int index)
        {
            if (index == 0)
            {
                this.escapeKapat = true;
            }
            else if (index == 1)
            {
                TabIndex1_Ac(gridView1.FocusedRowHandle);
            }
        }
        public override void TabPage_Selecting(DevExpress.XtraTab.XtraTabPage tb)
        {
            tabSelect = false;
        }
        #endregion
    }
}