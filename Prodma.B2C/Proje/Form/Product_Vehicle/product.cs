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
    public partial class product : TanitimSablon
    {
        #region degiskenler
        private productCntrl kulcntrl = new productCntrl();
        #endregion
        #region Constructors
        public product()
        {
            //EvetHayirEn
            InitializeComponent();
            tabloAdi = "product";
            this.Text =  Gridi_Olustur();   
            Tab_Gizle_Ekle();
            //Doldur();
        }
        private void Tab_Gizle_Ekle()
        {


            tabPage1.Text = this.Text;
            tabPage2.Text = "Ürün Araçları";
            usrGridBilgi.Kart_Bilgi_Duzenle(gridView1);
           // this.tabControl1.TabPages.Remove(tabPage2);
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
          productVm k = new productVm();
          k.id = 1169659;
          testInfoBindingSource.DataSource = kulcntrl.Liste_Al(null);
          base.gridControl1.DataSource = testInfoBindingSource;
          gridView1.Columns["id"].Visible = false;
          gridView1.FocusedColumn = gridView1.VisibleColumns[0];
        }
        #endregion
        #region İşlemler  (override edenler)
        public override void Kaydet()
        {
            productVm k = (productVm)ModelVm;
            kulcntrl.Guncelle(k, k.id);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;
        }
        public override void Yeni_Kayit()
        {
            productVm k = (productVm)ModelVm;
            kulcntrl.Ekle(k);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;
        }
        public override void Sil()
        {
            productVm k = (productVm)ModelVm;
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
            productVm k = (productVm)ModelVm;
            tabPage2.Controls.Clear();
            usrGridBilgi.Dinamik_Text_Box_Doldur(gridView1);
            product_vehicle_tree frmproduct_vehicle_tree = new product_vehicle_tree();
            frmproduct_vehicle_tree.TopLevel = false;
            frmproduct_vehicle_tree.ControlBox = false;
            frmproduct_vehicle_tree.Dock = DockStyle.Fill;
            tabPage2.Controls.Add(frmproduct_vehicle_tree);
            usrGridBilgi.Dock = DockStyle.Top;
            tabPage2.Controls.Add(usrGridBilgi);
            frmproduct_vehicle_tree.Show();

            frmproduct_vehicle_tree.escapeKapat = false;
            frmproduct_vehicle_tree.vmVehicle = new vehicleVm();
            frmproduct_vehicle_tree.vmVehicle.grup_id = k.grup_id;
            //frmYetkiAlanlar.ParentForm.KeyPreview = false;
            frmproduct_vehicle_tree.Doldur();
        }
        public override void Dinamik_TextBox_Olustur(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            usrGridBilgi.Dinamik_TextBox_Olustur(sender, e);
        }
    }
}