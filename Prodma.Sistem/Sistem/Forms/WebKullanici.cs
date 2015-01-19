using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Prodma.DataAccess; using Prodma.WinForms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using Prodma.Sistem.Controllers;
using Prodma.Sistem.Models;
using System.Resources;
using System.Diagnostics;
using System.Reflection;

namespace Prodma.Sistem.Forms
{
    public partial class WebKullanici : TanitimSablon
    {
        #region degiskenler
        private WebKullaniciCntrl kulcntrl = new WebKullaniciCntrl();
        #endregion
        #region Constructors
        public WebKullanici()
        {
            InitializeComponent();
            tabloAdi = "W_USER";
            this.Text = this.Text = Gridi_Olustur();  
            Tab_Gizle_Ekle();
            //this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.Dinamik_TextBox_Olustur);
        }
        private void Tab_Gizle_Ekle()
        {
            this.pnlEkIslemler.Visible = true;
            this.pnlIslemler.Visible = true;
            this.panelControl1.Size = new System.Drawing.Size(948, 65);
            tabPage1.Text = "Kullanıcı Bilgi Giriş";
            usrGridBilgi.Kart_Bilgi_Duzenle(gridView1);
            controlNavigator2.Visible = false;
            controlNavigator3.Visible = false;
            controlNavigator4.Visible = false;
            controlNavigator5.Visible = false;
            controlNavigator6.Visible = false;
            controlNavigator7.Visible = false;
            controlNavigator8.Visible = false;
            this.tabControl1.TabPages.Remove(tabPage4);
            this.tabControl1.TabPages.Remove(tabPage5);
            this.tabControl1.TabPages.Remove(tabPage6);
            this.tabControl1.TabPages.Remove(tabPage7);
            this.tabControl1.TabPages.Remove(tabPage8);
            this.tabControl1.TabPages.Remove(tabPage9);
            this.tabControl1.TabPages.Remove(tabPage10);
            this.tabControl1.TabPages.Remove(tabPage11);
            this.tabControl1.TabPages.Remove(tabPage12);
            this.tabControl1.TabPages.Remove(tabPage13);
        }
        public override void Doldur()
        {
            WebKullaniciVm k = new WebKullaniciVm();
            testInfoBindingSource.DataSource = kulcntrl.Liste_Al(null);
            base.gridControl1.DataSource = testInfoBindingSource;
            base.gridView1.Columns["ID"].Visible = false;
            base.gridView1.FocusedColumn = base.gridView1.VisibleColumns[0];
        }
        #endregion
        #region İşlemler  (override edenler)
        public override void Kaydet()
        {
            WebKullaniciVm k = (WebKullaniciVm)ModelVm;
            kulcntrl.Guncelle(k, k.ID);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;
        }
        public override void Yeni_Kayit()
        {
            WebKullaniciVm k = (WebKullaniciVm)ModelVm;
            kulcntrl.Ekle(k);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;
        }
        public override void Sil()
        {
            WebKullaniciVm k = (WebKullaniciVm)ModelVm;
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
        #region ektabislemleri
        public override void Dinamik_TextBox_Olustur(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            usrGridBilgi.Dinamik_TextBox_Olustur(sender, e); 
        }
        #endregion
        
     
    }
}