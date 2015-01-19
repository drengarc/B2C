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
using Prodma.Sistem.Controllers;
using Prodma.Sistem.Models;
namespace Prodma.Sistem.Forms
{
    public partial class Firma: TanitimSablon
    {
        #region degiskenler
      
        private FirmaCntrl kulcntrl = new FirmaCntrl();
        #endregion
        #region Constructors
        public Firma()
        {
            InitializeComponent();
            tabloAdi = "FIRMA";
            this.Text = this.Text = Gridi_Olustur();  
            Tab_Gizle_Ekle();
            //Doldur();
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.Dinamik_TextBox_Olustur);
        }
        public override void Ikinci_Tab_Ac()//yenisatirSifirli false degerine burada set ediliyor.
        {
            yeniSatir = false;
            if (tabControl1.SelectedTabPage == tabPage1)
            {
                tabControl1.SelectedTabPage = tabPage2;
            }
            else
            {
                tabControl1.SelectedTabPage = tabPage1;
            }
        }
        private void Tab_Gizle_Ekle()
        {

            ekTabAc = true;
            tabPage1.Text = "Firma";
            tabPage2.Text = "Firma Parametreleri(F8)";
          //  tabPage3.Text = "Firma Parametreleri2(F9)";
            usrGridBilgi.Kart_Bilgi_Duzenle(gridView1);
            

          

            this.tabPage2.Controls.Remove(this.controlNavigator2);
            this.tabPage3.Controls.Remove(this.controlNavigator3);


            this.tabControl1.TabPages.Remove(tabPage3);
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
          testInfoBindingSource.DataSource = kulcntrl.Liste_Al(null);
          base.gridControl1.DataSource = testInfoBindingSource;
          gridView1.Columns["ID"].Visible = false;
          gridView1.FocusedColumn = gridView1.VisibleColumns[0];
        }
        public override void Tanitim_KeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                tabControl1.SelectedTabPage = tabPage2;
            }
            else if (e.KeyCode == Keys.F9)
            {
                tabControl1.SelectedTabPage = tabPage3;
            }
        }
        #endregion
        #region İşlemler  (override edenler)
        public override void Kaydet()
        {
            FirmaVm k = (FirmaVm)ModelVm;
            kulcntrl.Guncelle(k, k.ID);
            lblBilgi.Text = kulcntrl.MesajYaz();
              
        }
        public override void Yeni_Kayit()
        {
            FirmaVm k = (FirmaVm)ModelVm;
            kulcntrl.Ekle(k);
            lblBilgi.Text = kulcntrl.MesajYaz();
              
        }
        public override void Sil()
        {
            FirmaVm k = (FirmaVm)ModelVm;
            kulcntrl.Sil(k.ID,k);
            lblBilgi.Text = kulcntrl.MesajYaz();
            
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
        public override void Dinamik_TextBox_Olustur(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            usrGridBilgi.Dinamik_TextBox_Olustur(sender, e);
        }
        public override void TabPage_Selecting(DevExpress.XtraTab.XtraTabPage tb)
        {
            tabSelect = false;
        }
        #endregion

        #region Ek tab işlemleri
        public override void TabPage_Index_Changed(int index)
        {
            if (index == 0)
            {
                Doldur();
            }
            else if (index == 1)
            {
                TabIndex2_Ac(gridView1.FocusedRowHandle);
            }
            else if (index == 2)
            {
                TabIndex3_Ac(gridView1.FocusedRowHandle);
            }
        }


        public void TabIndex2_Ac(int index)
        {
            tabPage2.Controls.Clear();
            usrGridBilgi.Dinamik_Text_Box_Doldur(gridView1);
            usrFirmaParametreEkBilgi firmaParametreEkBilgi = new usrFirmaParametreEkBilgi();
            firmaParametreEkBilgi.escapeKapatma = true;
            firmaParametreEkBilgi.Dock = DockStyle.Top;
            tabPage2.Controls.Add(firmaParametreEkBilgi);
            usrGridBilgi.Dock = DockStyle.Top;
            tabPage2.Controls.Add(usrGridBilgi);
            FirmaVm k = (FirmaVm)ModelVm;
            firmaParametreEkBilgi.firmaParametreVm = new FirmaParametreVm();
            firmaParametreEkBilgi.firmaParametreVm.FIRMA_ID = k.ID;
            firmaParametreEkBilgi.Doldur();
        }
        public void TabIndex3_Ac(int index)
        {
            //tabPage3.Controls.Clear();
            //usrGridBilgi.Dinamik_Text_Box_Doldur(gridView1);
            //usrFirmaParametreEkBilgi_1 firmaParametreEkBilgi_1 = new usrFirmaParametreEkBilgi_1();
            //firmaParametreEkBilgi_1.escapeKapatma = true;
            //firmaParametreEkBilgi_1.Dock = DockStyle.Top;
            //tabPage3.Controls.Add(firmaParametreEkBilgi_1);
            //usrGridBilgi.Dock = DockStyle.Top;
            //tabPage3.Controls.Add(usrGridBilgi);
            //FirmaVm k = (FirmaVm)ModelVm;
            //firmaParametreEkBilgi_1.firmaParametreVm = new FirmaParametreVm();
            //firmaParametreEkBilgi_1.firmaParametreVm.FIRMA_ID = k.ID;
            //firmaParametreEkBilgi_1.Doldur();
        }

        #endregion


       

    }
}