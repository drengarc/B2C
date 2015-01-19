using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Prodma.DataAccess;
using Prodma.Satis.Listeler;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Prodma.Parent;
using AlisSatis.Fis.Forms;
using Prodma.Sistem.Controllers;
namespace Prodma.Sistem.Forms
{
    public partial class Log_Gozlem : Islemler
    {
        bool tumAmbarlar = false;
        List<LogDetayVm> listGozlemDetay = new List<LogDetayVm>();
        usrGridIslem usr = new usrGridIslem(GridIslemEn.Bilgilendirme);
        usrGridIslem usrDetay = new usrGridIslem(GridIslemEn.Bilgilendirme);
        BindingSource bn = new BindingSource();
        public int stokId = 0;
        MDIParent mdStok;
        public Log_Gozlem(MDIParent _mdStok)
        {
            InitializeComponent();
            mdStok = _mdStok;
            initiliazeThis();
        }
        public Log_Gozlem()
        {
            InitializeComponent();
            initiliazeThis();
        }
        void initiliazeThis()
        {
            panelTamam.Visible = false;
            this.xtraTabPage1.Text = "Genel (F6)";
            this.xtraTabPage2.Text = "Detay (F6)";
            panelControlGrid.Controls.Add(usr);
            panelControlGridDetay.Controls.Add(usrDetay);
            usr.controlNavigatorButtonClick += controlNavigator1_ButtonClick;
            this.tbStokGozlem.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tbStokGozlem_SelectedPageChanged);
            this.GOSTERDETAYcmd.Click += new System.EventHandler(this.GOSTERDETAYcmd_Click);
            this.Load += new System.EventHandler(this.Stok_Gozlem_Load);
            this.Shown += new System.EventHandler(this.Stok_Gozlem_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Stok_Gozlem_KeyDown); 
            Gridi_Olustur(usr);
            usr.Dock = System.Windows.Forms.DockStyle.Fill;
            Gridi_Olustur_Detay(usrDetay);
            usrDetay.Dock = System.Windows.Forms.DockStyle.Fill;
            defaultDegerlerSet();
        }
        public void defaultDegerlerSet()
        {
            YardimciIslemler.TarihSetBugun(TARIHbas);
            YardimciIslemler.TarihSetBugun(TARIHbit);
        }
        void Gridi_Olustur(usrGridIslem usr)
        {
            List<Prodma.DataAccess.Alanlar> vmList = new List<Prodma.DataAccess.Alanlar>();
            Prodma.DataAccess.Alanlar vm = new Prodma.DataAccess.Alanlar(); vm.ALAN_AD = "Date"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TARIHTAM; vm.ALAN_SIRA = 1; vmList.Add(vm);
            vm = new Prodma.DataAccess.Alanlar(); vm.ALAN_AD = "Level"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 1; vmList.Add(vm);
            vm = new Prodma.DataAccess.Alanlar(); vm.ALAN_AD = "Message"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 2; vmList.Add(vm);
            ListHelper.Gridi_OlusturbyList(vmList, usr.gridView1, usr.gridControl1, 0, "", true);
            usr.gridView1.BestFitColumns();
            //usr.controlNavigator1.CustomButtons[1].Visible = true;
            //usr.controlNavigator1.CustomButtons[1].Tag = "Maliyet";
            //usr.controlNavigator1.CustomButtons[1].Hint = "Maliyet";
            //usr.controlNavigator1.CustomButtons[1].ImageIndex = 5;
            //usr.controlNavigator1.CustomButtons[2].Visible = true;
            //usr.controlNavigator1.CustomButtons[2].Tag = "Fatura";
            //usr.controlNavigator1.CustomButtons[2].Hint = "Fatura";
            //usr.controlNavigator1.CustomButtons[2].ImageIndex = 5;
            //usr.controlNavigator1.CustomButtons[3].Visible = true;
            //usr.controlNavigator1.CustomButtons[3].Tag = "Ikiyil";
            //usr.controlNavigator1.CustomButtons[3].Hint = "Ikiyil";
            //usr.controlNavigator1.CustomButtons[3].ImageIndex = 5;
            //usr.controlNavigator1.CustomButtons[4].Visible = true;
            //usr.controlNavigator1.CustomButtons[4].Tag = "FisAc";
            //usr.controlNavigator1.CustomButtons[4].Hint = "Fiş Aç";
            //usr.controlNavigator1.CustomButtons[4].ImageIndex = 5;
        }
        public void Gridi_Doldur()
        {
            Gridi_Olustur(usr);
            bn.DataSource = ListService.GetLog((int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, 0, 0, "", "", 0);
            usr.gridControl1.DataSource = bn;
            usr.gridView1.Focus();
        }
        private void Stok_Gozlem_Load(object sender, EventArgs e)
        {
            Control_Ayarla_Kayit(this.Controls, null, usr.gridControl1, false);
            YardimciIslemler.TarihSetBugun(TARIHbas);
            YardimciIslemler.TarihSetBugunSon(TARIHbit);
            Gridi_Doldur();
        }
        void Gridi_Olustur_Detay(usrGridIslem usr)
        {
            List<Prodma.DataAccess.Alanlar> vmList = new List<Prodma.DataAccess.Alanlar>();
            Prodma.DataAccess.Alanlar vm = new Prodma.DataAccess.Alanlar(); vm.ALAN_AD = "SILINME_TARIH"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TARIHTAM; vm.ALAN_SIRA = 1; vmList.Add(vm);
            vm = new Prodma.DataAccess.Alanlar(); vm.ALAN_AD = "KULLANICI_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 1; vmList.Add(vm);
            //vm = new Prodma.DataAccess.Alanlar(); vm.ALAN_AD = "ALAN"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 2; vmList.Add(vm);
            vm = new Prodma.DataAccess.Alanlar(); vm.ALAN_AD = "TABLO_ADI"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 3; vmList.Add(vm);
            vm = new Prodma.DataAccess.Alanlar(); vm.ALAN_AD = "CARI_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 4; vmList.Add(vm);
            ListHelper.Gridi_OlusturbyList(vmList, usr.gridView1, usr.gridControl1, 0, "", true);
            usr.gridView1.BestFitColumns();

        }
        void Gridi_Olustur_Detay1(usrGridIslem usr)
        {
            List<Prodma.DataAccess.Alanlar> vmList = new List<Prodma.DataAccess.Alanlar>();
            Prodma.DataAccess.Alanlar vm = new Prodma.DataAccess.Alanlar(); vm.ALAN_AD = "TARIH"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TARIHTAM; vm.ALAN_SIRA = 1; vmList.Add(vm);
            vm = new Prodma.DataAccess.Alanlar(); vm.ALAN_AD = "TABLO"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 1; vmList.Add(vm);
            vm = new Prodma.DataAccess.Alanlar(); vm.ALAN_AD = "ALAN"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 2; vmList.Add(vm);
            vm = new Prodma.DataAccess.Alanlar(); vm.ALAN_AD = "ALAN_2"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 3; vmList.Add(vm);
            vm = new Prodma.DataAccess.Alanlar(); vm.ALAN_AD = "ALAN_3"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 4; vmList.Add(vm);
            vm = new Prodma.DataAccess.Alanlar(); vm.ALAN_AD = "ALAN_4"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 5; vmList.Add(vm);
            vm = new Prodma.DataAccess.Alanlar(); vm.ALAN_AD = "ALAN_54"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 6; vmList.Add(vm);
            vm = new Prodma.DataAccess.Alanlar(); vm.ALAN_AD = "KULLANICI"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 7; vmList.Add(vm);
            vm = new Prodma.DataAccess.Alanlar(); vm.ALAN_AD = "ISLEM_TIP"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 8; vmList.Add(vm);
            vm = new Prodma.DataAccess.Alanlar(); vm.ALAN_AD = "ISLEM_NEDEN"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 8; vmList.Add(vm);
            ListHelper.Gridi_OlusturbyList(vmList, usr.gridView1, usr.gridControl1, 0, "", true);
            usr.gridView1.BestFitColumns();
     
        }
        public void Gridi_Doldur_Detay()
        {
            Gridi_Olustur_Detay(usrDetay);
            IptalEdilenKayitlarCntrl iptalCntrl = new IptalEdilenKayitlarCntrl();
            //listGozlemDetay = iptalCntrl.Liste_Al(null);
            bn.DataSource = iptalCntrl.Liste_Al(null);
            usrDetay.gridControl1.DataSource = bn;
            usrDetay.gridView1.Focus();
        }
        public void Gridi_Doldur_Detay1()
        {
            Gridi_Olustur_Detay1(usrDetay);
            listGozlemDetay = OrtakIslemlerService.GetLogDetay(Convert.ToDateTime(TARIHbas.EditValue), Convert.ToDateTime(TARIHbit.EditValue));
            bn.DataSource = listGozlemDetay;
            usrDetay.gridControl1.DataSource = bn;
            usrDetay.gridView1.Focus();
        }
        private void tbStokGozlem_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tbStokGozlem.SelectedTabPageIndex == 0)
            {
              //  Control_Ayarla_Kayit(xtraTabPage1.Controls, null, STOKlke, false);
              //  STOKlke.EditValue = STOKDETAYlke.EditValue;
              //  DOVIZlke.EditValue = DOVIZDetaylke.EditValue;
              //  AMBARlke.EditValue = AMBARDETAYlke.EditValue;
              ////  AMBARDETAYlke.EditValue = AMBARlke.EditValue.ToString();
              //  AMBARlke.RefreshEditValue();
                Gridi_Doldur();
            }
            else if (tbStokGozlem.SelectedTabPageIndex == 1)
                {
                    //Control_Ayarla_Kayit(xtraTabPage2.Controls, null, STOKDETAYlke, false);
                    //YardimciIslemler.TarihSetAyIlkGun(String.Format("{0,-1:00}", usr.gridView1.FocusedRowHandle + 1), TARIHbas);
                    //YardimciIslemler.TarihSetYilSonGun(TARIHbit);
                    //STOKDETAYlke.EditValue = STOKlke.EditValue;
                    //DOVIZDetaylke.EditValue = DOVIZlke.EditValue;
                    //AMBARDETAYlke.EditValue = AMBARlke.EditValue;
                    ////  AMBARDETAYlke.EditValue = AMBARlke.EditValue.ToString();
                    //AMBARDETAYlke.RefreshEditValue();
                    Gridi_Doldur_Detay1();
                }
        }
        private void GOSTERcmd_Click(object sender, EventArgs e)
        {
            Gridi_Doldur(); 
        }
        private void GOSTERDETAYcmd_Click(object sender, EventArgs e)
        {
            Gridi_Doldur_Detay1();
        }
        public void controlNavigator1_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            BindingSource bn = new BindingSource();
            if (e.Button.Tag != null)
            {
                //if (e.Button.Tag.ToString() == "Maliyet")
                //{
                //    bn.DataSource = StokBilgiService.Stok_Gozlem(Convert.ToInt32(STOKlke.EditValue), s_, Convert.ToInt32(DOVIZlke.EditValue),tumAmbarlar, Convert.ToInt32(NETBRUTlke.SelectedIndex), "Maliyet");
                //    usr.gridControl1.DataSource = bn;
                //    this.Text = " STok Gözlem (Maliyet Tutarına Göre)";
                //}
                //if (e.Button.Tag.ToString() == "Fatura")
                //{
                //    bn.DataSource = StokBilgiService.Stok_Gozlem(Convert.ToInt32(STOKlke.EditValue), s_, Convert.ToInt32(DOVIZlke.EditValue), tumAmbarlar, Convert.ToInt32(NETBRUTlke.SelectedIndex), "Fatura");
                //    usr.gridControl1.DataSource = bn;
                //    this.Text = "Stok Gözlem (Fatura)";
                //}
                //if (e.Button.Tag.ToString() == "Ikiyil")
                //{
                //    bn.DataSource = StokBilgiService.Stok_Gozlem(Convert.ToInt32(STOKlke.EditValue), s_, Convert.ToInt32(DOVIZlke.EditValue), tumAmbarlar, Convert.ToInt32(NETBRUTlke.SelectedIndex), "Ikiyil");
                //    usr.gridControl1.DataSource = bn;
                //}
                //if (e.Button.Tag.ToString() == "FisAc")
                //{
                //    FisAc();
                //}
                //if (e.Button.Tag.ToString() == "Yazdir")
                //{
                //  //  usr.gridControl1.ShowPrintPreview();
                //}
                
            }
        }
        private void Stok_Gozlem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && escapeKapatma==false)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F6)
            {
                if (tbStokGozlem.SelectedTabPageIndex == 0)
                    tbStokGozlem.SelectedTabPageIndex = 1;
                else
                    tbStokGozlem.SelectedTabPageIndex = 0;
            }
            //else if (e.KeyCode == Keys.F9)
            //{
            //    if (tbStokGozlem.SelectedTabPageIndex == 1)
            //        //FisAc();             
            //} 
        }
        //void FisAc()
        //{
        //    int id = (int)usrDetay.gridView1.GetRowCellValue(usrDetay.gridView1.FocusedRowHandle, "ID");
        //    int icDisId = (int)usrDetay.gridView1.GetRowCellValue(usrDetay.gridView1.FocusedRowHandle, "IC_DIS_TIP_ID");
        //    if (icDisId == (int)IcDisEn.DIS)
        //    {
        //        StokFis frm = new StokFis();
        //        frm.disaridanAc = true;
        //        frm.modelDisariVm = new AlisSatis.Fis.Models.StokFisSifirVm();
        //        frm.modelDisariVm.ID = id;
        //        frm.DoldurModelSet();
        //        frm.gridView1.FocusedRowHandle = frm.gridView1.RowCount - 2;
        //        frm.gridView1.TopRowIndex = frm.gridView1.RowCount - 2;
        //        frm.tabControl1.SelectedTabPageIndex = 1;
        //        frm.satirYeniKayitAc = false;
        //        frm.TabPage_Index_Changed(1);
        //        MDIParent fr = mdStok;
        //        fr.Prodma_Form_Ac(frm, 5);
        //        frm.WindowState = FormWindowState.Maximized;
        //    }
        //    else
        //    {
        //        StokIcFis frm = new StokIcFis();
        //        frm.disaridanAc = true;
        //        frm.modelDisariVm = new StokAmbarIcFisSifirVm();
        //        frm.modelDisariVm.ID = id;
        //        frm.DoldurModelSet();
        //        frm.gridView1.FocusedRowHandle = frm.gridView1.RowCount - 2;
        //        frm.gridView1.TopRowIndex = frm.gridView1.RowCount - 2;
        //        frm.tabControl1.SelectedTabPageIndex = 1;
        //        frm.satirYeniKayitAc = false;
        //        frm.TabPage_Index_Changed(1);
        //        MDIParent fr = mdStok;
        //        fr.Prodma_Form_Ac(frm, 5);
        //        frm.WindowState = FormWindowState.Maximized;
        //    }
        //}
        private void Stok_Gozlem_Shown(object sender, EventArgs e)
        {
            usr.gridControl1.Focus();
        }
    }
}