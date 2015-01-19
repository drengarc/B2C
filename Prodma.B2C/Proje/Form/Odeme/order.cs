using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using B2C.Controllers;
using B2C.Models; 
using Prodma.DataAccessB2C;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Prodma.WinForms;
namespace B2C.Forms
{
    public partial class order : TanitimSablon
    {
        #region degiskenler
        private orderCntrl kulcntrl = new orderCntrl();
        #endregion
        #region Constructors
        public order()
        {
            InitializeComponent();
            tabloAdi = "order";
            this.Text =  Gridi_Olustur();   
            Tab_Gizle_Ekle();
            //Doldur();
        }
        private void Tab_Gizle_Ekle()
        {


            tabPage1.Text = this.Text;
            tabPage2.Text = "Sipariş Detayları";
            usrGridBilgi.Kart_Bilgi_Duzenle(gridView1);
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
          orderVm k = new orderVm();
          testInfoBindingSource.DataSource = kulcntrl.Liste_Al(null);
          base.gridControl1.DataSource = testInfoBindingSource;
          gridView1.Columns["id"].Visible = false;
          gridView1.FocusedColumn = gridView1.VisibleColumns[0];
        }
        #endregion
        #region İşlemler  (override edenler)
        public override void Kaydet()
        {
            //orderVm k = (orderVm)ModelVm;
            //kulcntrl.Guncelle(k, k.id);
            //lblBilgi.Text = kulcntrl.MesajYaz();
            //islemTamamDegil = kulcntrl.islemTamamDegilCntrl;
        }
        public override void Yeni_Kayit()
        {
            //orderVm k = (orderVm)ModelVm;
            //kulcntrl.Ekle(k);
            //lblBilgi.Text = kulcntrl.MesajYaz();
            //islemTamamDegil = kulcntrl.islemTamamDegilCntrl;
        }
        public override void Sil()
        {
            //orderVm k = (orderVm)ModelVm;
            //kulcntrl.Sil(k.ID,k);
            //lblBilgi.Text = kulcntrl.MesajYaz();
            //islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
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
        public override void TabPage_Index_Changed(int index)
        {
            Globals.escapeTabDegistir = true;
            if (index == 0)
            {
                this.escapeKapat = true;
                // Doldur();
            }
            else if (index == 1)
            {
                TabIndex2_Ac(gridView1.FocusedRowHandle);
            }
        }
        public void TabIndex2_Ac(int index)
        {
            orderVm k = (orderVm)ModelVm;
            tabPage2.Controls.Clear();
            usrGridBilgi.Dinamik_Text_Box_Doldur(gridView1);
            order_product frmorder_product = new order_product();
            frmorder_product.TopLevel = false;
            frmorder_product.ControlBox = false;
            frmorder_product.Dock = DockStyle.Fill;
            tabPage2.Controls.Add(frmorder_product);
            usrGridBilgi.Dock = DockStyle.Top;
            tabPage2.Controls.Add(usrGridBilgi);
            frmorder_product.Show();

            frmorder_product.escapeKapat = false;
            frmorder_product.vmOrderProduct = new order_productVm();
            frmorder_product.vmOrderProduct.order_id = k.id;
            //frmYetkiAlanlar.ParentForm.KeyPreview = false;
            frmorder_product.Doldur();
        }
        public override void Dinamik_TextBox_Olustur(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            usrGridBilgi.Dinamik_TextBox_Olustur(sender, e);
        }
    }
}