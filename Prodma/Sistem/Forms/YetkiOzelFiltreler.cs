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
    public partial class YetkiOzelFiltreler : TanitimSablon
    {
        #region degiskenler
        private FiltrelerCntrl kulcntrl = new FiltrelerCntrl();
        public FiltrelerVm FiltrelerVm = new FiltrelerVm();
        #endregion
        #region Constructors
        public YetkiOzelFiltreler()
        {
            InitializeComponent();
            tabloAdi = "FILTRELER";
            this.Text = Gridi_Olustur();   
            Tab_Gizle_Ekle();
            this.WindowState = FormWindowState.Normal;
        }
        public override void CustomButonEkle()
        {
            int yetkiIndex = 0;
            this.controlNavigator1.CustomButtons[1].Tag = "Kopyalama";
            this.controlNavigator1.CustomButtons[1].Hint = "Kopyalama";
            this.controlNavigator1.CustomButtons[1].ImageIndex = 5;
            yetkiIndex++;
            for (int i = 0; i < 7 - yetkiIndex; i++)
            {
                this.controlNavigator1.CustomButtons.RemoveAt(yetkiIndex + 1);
            }
        }
        public override void Custom_Buton_Islemleri(string islem)
        {
            if (islem == "Kopyalama")
            {
                FiltrelerVm Vm = (FiltrelerVm)ModelVm;
                if (Vm == null) return;
                //if (Vm.M_ALANLAR_ALT_ID == null) return;
                KullaniciMenuKopyalama kullaniciKopyalama = new KullaniciMenuKopyalama((int)KullaniciIslemleriTipEn.Ozel_Listeler);
                kullaniciKopyalama.Dock = DockStyle.Fill;
                kullaniciKopyalama.WindowState = FormWindowState.Normal;
                kullaniciKopyalama.eskiKullaniciId = Vm.KULLANICI_ID;
                kullaniciKopyalama.YetkiAlanAd = Vm.FORM_ADI;
                kullaniciKopyalama.YetkiAlanAd += "-" + Vm.RAPOR_ADI;
                kullaniciKopyalama.Doldur();
                kullaniciKopyalama.ShowDialog();
                Doldur();
                
            }
        }

        private void Tab_Gizle_Ekle()
        {
            tabPage1.Text = "Yetki Alanlar Bilgi Giriş";

            //this.tabControl1.TabPages.Remove(tabPage2);
            //controlNavigator2.NavigatableControl = base.gridControl1;
            controlNavigator2.Visible = false;

             this.tabControl1.TabPages.Remove(tabPage2);
          //  panel2.Controls.Add(yBilgi.controlNavigator1);
           
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
            controlNavigator1.Buttons.Append.Visible = false;
            controlNavigator1.Buttons.CancelEdit.Visible = false;
            controlNavigator1.Buttons.EndEdit.Visible = false;
            gridView1.OptionsBehavior.Editable = true;


        }
        public override void Doldur()
        {
          FiltrelerVm.ListeFiltresi = "1";
          testInfoBindingSource.DataSource = kulcntrl.Liste_Al(FiltrelerVm);
          gridControl1.DataSource = testInfoBindingSource;
          gridView1.Columns["ID"].Visible = false;
          gridView1.Columns["KULLANICI_ID"].Visible = false;
          gridView1.FocusedColumn = gridView1.VisibleColumns[0];
        }
        #endregion
        #region İşlemler  (override edenler)
        public override void Kaydet()
        {
            FiltrelerVm k = (FiltrelerVm)ModelVm;
            k.KULLANICI_ID = FiltrelerVm.KULLANICI_ID;
            kulcntrl.Guncelle(k, k.ID);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Yeni_Kayit()
        {
            FiltrelerVm k = (FiltrelerVm)ModelVm;
            k.KULLANICI_ID = FiltrelerVm.KULLANICI_ID;
            kulcntrl.Ekle(k);
            lblBilgi.Text = kulcntrl.MesajYaz();
            islemTamamDegil = kulcntrl.islemTamamDegilCntrl;  
        }
        public override void Sil()
        {
            FiltrelerVm k = (FiltrelerVm)ModelVm;
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
        public override void ValidateRow(int FocusedRowHandle) 
        {
            blnValidateRow = true;
        }
        public override void ShownEditor()
        {
        }
        #endregion
    }
}