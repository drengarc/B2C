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
using Prodma.DataAccess; using Prodma.WinForms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Prodma.Sistem.Forms;
using Prodma.Sistem.Controllers;
using Prodma.Sistem.Models;
using DevExpress.XtraEditors;
namespace Prodma.Sistem.Forms
{
    public partial class BarkodYaziciTanitim : TanitimSablon
    {
        #region degiskenler
        private BarkodYaziciTanitimCntrl kulcntrl = new BarkodYaziciTanitimCntrl();
        public BarkodYaziciTanitimVm barkodYaziciTanitimVm;
        private usrFaturaAyar usrFaturaAyar;
        private usrBarkodDokumKoordinat usrBarkodDokumKoordinat;
        #endregion
        #region Constructors
        public BarkodYaziciTanitim()
        {
            
            InitializeComponent();
            tabloAdi = "BARKOD_YAZICI_TANITIM";
            this.Text = Gridi_Olustur();  
            Tab_Gizle_Ekle();
            //Doldur();
            
            
        }
        private void Tab_Gizle_Ekle()
        {
            tabPage1.Text ="Barkod Yazıcı Tanıtım";
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
            testInfoBindingSource.DataSource = kulcntrl.Liste_Al(barkodYaziciTanitimVm);
            base.gridControl1.DataSource = testInfoBindingSource;
            gridView1.Columns["ID"].Visible = false;
            gridView1.FocusedColumn = gridView1.VisibleColumns[0];
        }
        
        #endregion
        #region İşlemler  (override edenler)
        public override void Kaydet()
        {
            BarkodYaziciTanitimVm k = (BarkodYaziciTanitimVm)ModelVm;
            kulcntrl.Guncelle(k, k.ID);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Yeni_Kayit()
        {
            BarkodYaziciTanitimVm k = (BarkodYaziciTanitimVm)ModelVm;
            kulcntrl.Ekle(k);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Sil()
        {
            BarkodYaziciTanitimVm k = (BarkodYaziciTanitimVm)ModelVm;
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
            BarkodYaziciTanitimVm k = (BarkodYaziciTanitimVm)ModelVm;
            if (k != null)
            {
                if (usrBarkodDokumKoordinat == null)
                {
                    usrBarkodDokumKoordinat = new usrBarkodDokumKoordinat();
                    usrBarkodDokumKoordinat.barkodDokumKoordinatVm.BARKOD_YAZICI_TANITIM_ID = k.ID;
                    tabPage2.Controls.Add(usrBarkodDokumKoordinat);
                    usrBarkodDokumKoordinat.Doldur();
                }
                else
                {
                    usrBarkodDokumKoordinat.barkodDokumKoordinatVm.BARKOD_YAZICI_TANITIM_ID = k.ID;
                    usrBarkodDokumKoordinat.Doldur();
                }
            }
            else 
            {
                tabControl1.SelectedTabPageIndex = 0;
                MessageBox.Show("Öncelik olarak bir yazıcı tanıtmalısınız.");
            }

        }
        #endregion

    }
}