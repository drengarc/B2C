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

namespace Prodma.Sistem.Forms
{
    public partial class Log : TanitimSablon
    {
        public Log()
        {
            InitializeComponent();
            tabloAdi = "LOG";
            this.Text = Gridi_Olustur();   
            Tab_Gizle_Ekle();
            //Doldur(); 
        }
        public override void Doldur()
        {
            testInfoBindingSource.DataSource = ListService.GetLog((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"", "",0 );
            base.gridControl1.DataSource = testInfoBindingSource;
            gridView1.Columns["Id"].Visible = false;
            gridView1.FocusedColumn = gridView1.VisibleColumns[0];
        }
        public override void Tanitim_KeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                tabControl1.SelectedTabPage = tabPage2;
            }
        }
        private void Tab_Gizle_Ekle()
        {


            tabPage1.Text = "Log";
            tabPage2.Text = "Giriş Silme Güncelleme Bilgileri (F8)";
            controlNavigator2.Visible = false;
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
        public override void TabPage_Index_Changed(int index)
        {
            if (index == 0)
            {
                Doldur();
            }
            else if (index == 1)
            {
                TabIndex1_Ac(gridView1.FocusedRowHandle);
            }
        }
        public override void Eski_Kayit_Al_Yukle_Satir(int rowHandle)
        {
            
                Doldur();
          
            // gridControl1.DataSource = kulcntrl.Liste_Al(null);
        }
        public void TabIndex1_Ac(int index)
        {
            //tabPage2.Controls.Clear();
            //Log_Gozlem frmYetkiMenu = new Log_Gozlem();
            //frmYetkiMenu.TopLevel = false;
            //frmYetkiMenu.ControlBox = false;
            //frmYetkiMenu.Dock = DockStyle.Fill;
            //tabPage2.Controls.Add(frmYetkiMenu);
            //usrGridBilgi.Dock = DockStyle.Top;
            //tabPage2.Controls.Add(usrGridBilgi);
            //frmYetkiMenu.Show();
           
        }
    }
}