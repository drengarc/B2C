using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Prodma.Sistem.Models;
using Prodma.Sistem.Controllers;
using Prodma.DataAccess;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Prodma.Sistem.Forms
{
    public partial class IslemTipi : TanitimSablon
    {
        #region degiskenler
        private IslemTipiCntrl kulcntrl = new IslemTipiCntrl();
        public IslemTipiVm islemTipiVm;
        public usrMiktarsalIslemTipiEkBilgi usrMiktarsal = new usrMiktarsalIslemTipiEkBilgi();
        public usrParasalIslemTipiEkBilgi usrParasal = new usrParasalIslemTipiEkBilgi();
        #endregion
        #region Constructors
        public IslemTipi()
        {
            
            InitializeComponent();
            tabloAdi = "ISLEM_TIPI";
            this.Text = Gridi_Olustur();  
            Tab_Gizle_Ekle();
            //Doldur();
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.Dinamik_TextBox_Olustur);
        }
        private void Tab_Gizle_Ekle()
        {
            ekTabAc = true;
            tabPage1.Text = "Miktarsal İşlem Bilgi Giriş";
            tabPage2.Text = "Ek Bilgiler(Miktarsal)(F8)";
            tabPage3.Text = "Ek Bilgiler(Parasal)(F8)";
            tabPage4.Text = "";
            this.tabPage2.Controls.Add(usrMiktarsal);
            this.tabPage3.Controls.Add(usrParasal);
            usrGridBilgi.Kart_Bilgi_Duzenle(gridView1);

            this.tabPage4.Appearance.Header.ForeColor = System.Drawing.Color.Red;
            this.tabPage4.Appearance.Header.Options.UseBackColor = true;
            this.tabPage4.Appearance.Header.Options.UseForeColor = true;
            // this.tabPage9.Appearance.PageClient.BackColor = System.Drawing.Color.DarkRed;
            //  this.tabPage9.Appearance.PageClient.Options.UseBackColor = true;
            this.tabPage4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            //this.tabControl1.TabPages.Remove(tabPage2);
            controlNavigator2.NavigatableControl = base.gridControl1;

            //this.tabControl1.TabPages.Remove(tabPage3);
            controlNavigator3.NavigatableControl = base.gridControl1;

            //this.tabControl1.TabPages.Remove(tabPage4);
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
          base.gridView1.RefreshData();
          testInfoBindingSource.DataSource = kulcntrl.Liste_Al(islemTipiVm);
          base.gridControl1.DataSource = testInfoBindingSource;
          gridView1.Columns["ID"].Visible = false;
          gridView1.FocusedColumn = gridView1.VisibleColumns[0];
        }
        public override void Ikinci_Tab_Ac()//yenisatirSifirli false degerine burada set ediliyor.
        {
            yeniSatir = false;
            if (tabControl1.SelectedTabPage == tabPage1)
            {
                IslemTipiVm k = (IslemTipiVm)ModelVm;
                if (k.MIKTARSAL_PARASAL_ID== (int)MiktarsalParasalEn.Miktarsal)
                   tabControl1.SelectedTabPage = tabPage2;
                else
                   tabControl1.SelectedTabPage = tabPage3;
            }
            else
            {
                tabControl1.SelectedTabPage = tabPage1;
            }
        }
        public override void Tanitim_KeyDown(KeyEventArgs e)
        {
            IslemTipiVm k = (IslemTipiVm)ModelVm;
           if (e.KeyCode == Keys.F8)
            {
               if (k.MIKTARSAL_PARASAL_ID == (int)MiktarsalParasalEn.Miktarsal)
                   tabControl1.SelectedTabPage = tabPage2;
               else if (k.MIKTARSAL_PARASAL_ID == (int)MiktarsalParasalEn.Parasal)
                   tabControl1.SelectedTabPage = tabPage3;
            }
        }
      
        #endregion
        #region İşlemler  (override edenler)
        public override void Kaydet()
        {
            IslemTipiVm k = (IslemTipiVm)ModelVm;
            kulcntrl.Guncelle(k, k.ID);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Yeni_Kayit()
        {
            IslemTipiVm k = (IslemTipiVm)ModelVm;
            kulcntrl.Ekle(k);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Sil()
        {
            IslemTipiVm k = (IslemTipiVm)ModelVm;
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
        public override void Dinamik_TextBox_Olustur(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            usrGridBilgi.Dinamik_TextBox_Olustur(sender, e);
        }
        //public override void TabPage_Selecting(DevExpress.XtraTab.XtraTabPage tb)
        //{
        //    tabSelect = true;
        //    IslemTipiVm islemtipi = (IslemTipiVm)ModelVm;
        //    if (tb.Name == "tabPage2" && islemtipi.MIKTARSAL_PARASAL_ID != 1)
        //    {
        //        tabSelect = false;
        //    }
        //    else if (tb.Name == "tabPage3" && islemtipi.MIKTARSAL_PARASAL_ID != 2)
        //    {
        //        tabSelect = false;
        //    }
        //}
        public override void TabPage_Selecting(DevExpress.XtraTab.XtraTabPage tb)
        {
            tabSelect = false;
            IslemTipiVm k = (IslemTipiVm)ModelVm;
            if (k.MIKTARSAL_PARASAL_ID == (int)MiktarsalParasalEn.Miktarsal && tb.Name == "tabPage3")
            {
                tabSelect = true;
            }
            else if (k.MIKTARSAL_PARASAL_ID == (int)MiktarsalParasalEn.Parasal && tb.Name == "tabPage2")
            {
                tabSelect = true;
            }
        }
        public override void FocusedRowChanged()
        {
            gridView1.OptionsBehavior.Editable = true;
            tabPage4.Text = "";
            IslemTipiVm k = (IslemTipiVm)ModelVm;
            if (FisOrtakService.IslemTipindeHareketVarMi(k.ID) == true && tamYetki==false)
            {
                //gridView1.OptionsBehavior.Editable = false;
                //tabPage4.Text = "İşlem Tipinde Hareket Vardır";
            }
        }
        public override void TabPage_Index_Changed(int index)
        {
            if (index == 0)
            {
 
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
        public override void ValidatingEditor(object value, int FocusedRowHandle, DevExpress.XtraGrid.Columns.GridColumn FocusedColumn)
        {
            if (FocusedColumn.FieldName == "KARSILIK_ISLEM_TIPI_ID")
            {
                IslemTipiVm k1 = (IslemTipiVm)ModelVm;
                IslemTipiVm k = FisOrtakService.Islem_Tipi_Degerleri_Al(Convert.ToInt32(k1.ID));
                IslemTipiVm Vm = FisOrtakService.Islem_Tipi_Degerleri_Al(Convert.ToInt32(value));
                if (k.ISLEM_CINS_ID != Vm.ISLEM_CINS_ID)
                {
                    errorTextValidatingEditor = "İslem Cinsleri Uyumsuz";
                    blnValidatingEditor = false;
                }
                else if (k.ISLEM_TIPI_ISLEVI_ID != Vm.ISLEM_TIPI_ISLEVI_ID)
                {
                    errorTextValidatingEditor = "İslem Tipi İslevi Uyumsuz";
                    blnValidatingEditor = false;
                }
                else if (k.IC_DIS_ID != Vm.IC_DIS_ID)
                {
                    errorTextValidatingEditor = "İslem Tipi İç Dış Tipi Uyumsuz";
                    blnValidatingEditor = false;
                }
            }
        }
        public void TabIndex2_Ac(int index)
        {

            tabPage2.Controls.Clear();
            usrGridBilgi.Dinamik_Text_Box_Doldur(this.gridView1);
            usrMiktarsalIslemTipiEkBilgi usrMiktarsal = new usrMiktarsalIslemTipiEkBilgi();
            usrMiktarsal.Dock = DockStyle.Top;
            tabPage2.Controls.Add(usrMiktarsal);
            usrGridBilgi.Dock = DockStyle.Top;
            tabPage2.Controls.Add(usrGridBilgi);
            IslemTipiVm k = (IslemTipiVm)ModelVm;
            usrMiktarsal.kayitEdilemez = tabPage4.Text;
            usrMiktarsal.islemTipiVm = k;
            usrMiktarsal.Doldur();
        }
        public void TabIndex3_Ac(int index)
        {
            tabPage3.Controls.Clear();
            usrGridBilgi.Dinamik_Text_Box_Doldur(gridView1);
            usrParasalIslemTipiEkBilgi usrParasal = new usrParasalIslemTipiEkBilgi();
            usrParasal.Dock = DockStyle.Top;
            tabPage3.Controls.Add(usrParasal);
            usrGridBilgi.Dock = DockStyle.Top;
            tabPage3.Controls.Add(usrGridBilgi);

            IslemTipiVm k = (IslemTipiVm)ModelVm;
            usrParasal.kayitEdilemez = tabPage4.Text;
            usrParasal.islemTipiVm = k;
            usrParasal.Doldur();
        }
  
        #endregion
    }
}