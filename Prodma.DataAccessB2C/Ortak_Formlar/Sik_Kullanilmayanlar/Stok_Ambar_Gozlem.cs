using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Prodma.DataAccess;
using Prodma.WinForms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
namespace Prodma.WinForms
{
    public partial class Stok_Ambar_Gozlem : Islemler
    {
        usrGridIslem usr = new usrGridIslem(GridIslemEn.Bilgilendirme);
        BindingSource bn = new BindingSource();
        public int stokId = 0;
        public Stok_Ambar_Gozlem()
        {
            InitializeComponent();
            YardimciIslemlerKontrols.TarihSetIlkGun(TARIHdtbas);
            YardimciIslemlerKontrols.TarihSetBugun(TARIHdtbit);
            this.GOSTERcmd.Click += new System.EventHandler(this.GOSTERcmd_Click);
            YardimciIslemlerKontrols.InvokeLueContainSet("STOK_ID", STOKlke);
            this.Text = "Stok İşlem Bilgileri";
            panelControlGrid.Controls.Add(usr);
            usr.controlNavigatorButtonClick += controlNavigator1_ButtonClick;
            usr.gridView1.OptionsView.ShowGroupPanel = true;
            usr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GOZLEM_TIPcbo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.GOZLEM_TIPcbo.Properties.Items.AddRange(new object[] {
            "Stok Ambar Dagılım",
            "Teklif Gözlem",
            "Sipariş Gözlem",
            "İrsailye Gözlem",
            "Stok Siparis Bakiye",
            "Cari Sipariş",
            "Cari Bakiye Gözlem"});
            this.GOZLEM_TIPcbo.Properties.NullText = "Seçiniz";
        }
        private void GOSTERcmd_Click(object sender, EventArgs e)
        {
            Gridi_Doldur();
        }
        void Gridi_Olustur(usrGridIslem usr)
        {
            List<Alanlar> vmList = new List<Alanlar>();
            Alanlar vm = new Alanlar();
            vm = new Alanlar(); vm.ALAN_AD = "AMBAR_ADI"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 1; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "BAKIYE"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.DECIMAL; vm.ALAN_UZUNLUK = "10"; vm.ALAN_DECIMAL = "0"; vm.M_ALAN_ALT_BILGI = 1; vm.ALAN_SIRA = 2; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "BIRIMI"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 3; vmList.Add(vm);
            ListHelper.Gridi_OlusturbyList(vmList, usr.gridView1, usr.gridControl1, 0, "", true);
        }
        void Gridi_Olustur_Teklif(usrGridIslem usr)
        {
            List<Alanlar> vmList = new List<Alanlar>();
            Alanlar vm = new Alanlar();
            vm = new Alanlar(); vm.ALAN_AD = "TEKLIF_TIP_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 1; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "TARIH"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TARIH; vm.ALAN_SIRA = 2; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "KULLANICI_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 3; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "FIS_NO"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 4; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "CARI_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 5; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "CARI_AYRIM_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 6; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "CARI_ADRES_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 7; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "DOVIZ_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 8; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "CARI_PLASIYER_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 9; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "CARI_SATIS_ELEMANI_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 10; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "MIKTAR"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.DECIMAL; vm.ALAN_UZUNLUK = "10"; vm.ALAN_DECIMAL = "0"; vm.M_ALAN_ALT_BILGI = 1; vm.ALAN_SIRA = 11; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "FIYAT"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.DECIMAL; vm.ALAN_UZUNLUK = "10"; vm.ALAN_DECIMAL = "5"; vm.M_ALAN_ALT_BILGI = 1; vm.ALAN_SIRA = 12; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "TUTAR"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.DECIMAL; vm.ALAN_UZUNLUK = "10"; vm.ALAN_DECIMAL = "2"; vm.M_ALAN_ALT_BILGI = 1; vm.ALAN_SIRA = 13; vmList.Add(vm);
            ListHelper.Gridi_OlusturbyList(vmList, usr.gridView1, usr.gridControl1, 0, "", true);
        }
        void Gridi_Olustur_Siparis(usrGridIslem usr)
        {
            List<Alanlar> vmList = new List<Alanlar>();
            Alanlar vm = new Alanlar();
            vm = new Alanlar(); vm.ALAN_AD = "LK_ALIS_SATIS_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 1; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "TARIH"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TARIH; vm.ALAN_SIRA = 2; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "KULLANICI_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 3; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "FIS_NO"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 4; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "CARI_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 5; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "CARI_AYRIM_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 6; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "CARI_ADRES_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 7; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "DOVIZ_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 8; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "CARI_PLASIYER_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 9; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "CARI_SATIS_ELEMANI_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 10; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "MIKTAR"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.DECIMAL; vm.M_ALAN_ALT_BILGI = 1; vm.ALAN_SIRA = 11; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "FIYAT"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.DECIMAL; vm.M_ALAN_ALT_BILGI = 1; vm.ALAN_SIRA = 12; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "TUTAR"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.DECIMAL; vm.ALAN_UZUNLUK = "10"; vm.ALAN_DECIMAL = "2"; vm.M_ALAN_ALT_BILGI = 1; vm.ALAN_SIRA = 13; vmList.Add(vm);
            ListHelper.Gridi_OlusturbyList(vmList, usr.gridView1, usr.gridControl1, 0, "", true);
        }
        void Gridi_Olustur_Irsaliye(usrGridIslem usr)
        {
            List<Alanlar> vmList = new List<Alanlar>();
            Alanlar vm = new Alanlar();
            vm = new Alanlar(); vm.ALAN_AD = "TARIH"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TARIH; vm.ALAN_SIRA = 1; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "KULLANICI_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 2; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "FIS_NO"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 3; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "CARI_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 4; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "CARI_AYRIM_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 5; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "CARI_ADRES_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 6; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "AMBAR_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.DECIMAL;  vm.ALAN_SIRA = 7; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "ISLEM_TIPI_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 8; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "CARI_PLASIYER_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 9; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "CARI_SATIS_ELEMANI_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 10; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "DOVIZ_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 11; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "MIKTAR_IC"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.DECIMAL; vm.M_ALAN_ALT_BILGI = 1; vm.ALAN_SIRA = 12; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "FIYAT"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.DECIMAL; vm.M_ALAN_ALT_BILGI = 1; vm.ALAN_SIRA = 13; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "TUTAR"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.DECIMAL; vm.ALAN_UZUNLUK = "10"; vm.ALAN_DECIMAL = "2"; vm.M_ALAN_ALT_BILGI = 1; vm.ALAN_SIRA = 14; vmList.Add(vm);
            ListHelper.Gridi_OlusturbyList(vmList, usr.gridView1, usr.gridControl1, 0, "", true);
        }
        void Gridi_Olustur_Cari_Bakiye(usrGridIslem usr)
        {
            List<Alanlar> vmList = new List<Alanlar>();
            Alanlar vm = new Alanlar();
            vm = new Alanlar(); vm.ALAN_AD = "CARI_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 4; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "BAKIYE"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.DECIMAL; vm.ALAN_UZUNLUK = "10"; vm.ALAN_DECIMAL = "0"; vm.M_ALAN_ALT_BILGI = 1; vm.ALAN_SIRA = 14; vmList.Add(vm);
            ListHelper.Gridi_OlusturbyList(vmList, usr.gridView1, usr.gridControl1, 0, "", true);
        }
        void Gridi_Olustur_Stok_Siparis_Bakiye(usrGridIslem usr)
        {
            List<Alanlar> vmList = new List<Alanlar>();
            Alanlar vm = new Alanlar();
            vm = new Alanlar(); vm.ALAN_AD = "STOK_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 4; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "BAKIYE_MIKTAR"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.DECIMAL; vm.ALAN_UZUNLUK = "10"; vm.ALAN_DECIMAL = "0"; vm.M_ALAN_ALT_BILGI = 1; vm.ALAN_SIRA = 14; vmList.Add(vm);
            ListHelper.Gridi_OlusturbyList(vmList, usr.gridView1, usr.gridControl1, 0, "", true);
        }
        void Gridi_Olustur_Cari_Siparis_Bakiye(usrGridIslem usr)
        {
            List<Alanlar> vmList = new List<Alanlar>();
            Alanlar vm = new Alanlar();
            vm = new Alanlar(); vm.ALAN_AD = "CARI_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 4; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "STOK_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 4; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "BAKIYE_MIKTAR"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.DECIMAL; vm.ALAN_UZUNLUK = "10"; vm.ALAN_DECIMAL = "0"; vm.M_ALAN_ALT_BILGI = 1; vm.ALAN_SIRA = 14; vmList.Add(vm);
            ListHelper.Gridi_OlusturbyList(vmList, usr.gridView1, usr.gridControl1, 0, "", true);
        }
        public void Gridi_Doldur()
        {
            if (GOZLEM_TIPcbo.SelectedIndex == 0)
            {
                bn.DataSource = FisOrtakService.GetStokAmbarDurum((int)STOKlke.EditValue, Convert.ToDateTime(TARIHdtbas.EditValue), Convert.ToDateTime(TARIHdtbit.EditValue));
            }
            else if (GOZLEM_TIPcbo.SelectedIndex == 1)
            {
                bn.DataSource = FisOrtakService.GetTeklifHareket((int)STOKlke.EditValue, Convert.ToDateTime(TARIHdtbas.EditValue), Convert.ToDateTime(TARIHdtbit.EditValue));
            }
            else if (GOZLEM_TIPcbo.SelectedIndex == 2)
            {
                bn.DataSource = FisOrtakService.GetSiparisHareket((int)STOKlke.EditValue, Convert.ToDateTime(TARIHdtbas.EditValue), Convert.ToDateTime(TARIHdtbit.EditValue));
            }
            else if (GOZLEM_TIPcbo.SelectedIndex == 3)
            {
                bn.DataSource = FisOrtakService.GetIrsaliyeHareket((int)STOKlke.EditValue, Convert.ToDateTime(TARIHdtbas.EditValue), Convert.ToDateTime(TARIHdtbit.EditValue));
            }
            else if (GOZLEM_TIPcbo.SelectedIndex == 4)
            {
                ListeYapBase yapBase = new ListeYapBase(true);
                yapBase.SiparisBakiyeBul();
                List<SiparisBakiyeListVm> Vm = yapBase.siparisBakiyeFiltreList;
                bn.DataSource = Vm;
            }
            else if (GOZLEM_TIPcbo.SelectedIndex == 5)
            {
                ListeYapBase yapBase = new ListeYapBase(true);
                yapBase.SiparisBakiyeCariBul();
                List<SiparisBakiyeCariListVm> Vm = yapBase.siparisBakiyeCariFiltreList;
                bn.DataSource = Vm;
            }
            else if (GOZLEM_TIPcbo.SelectedIndex == 6)
            {
                ListeYapBase yapBase = new ListeYapBase(true);
                yapBase.CariBakiyeBul(0);
                List<CariBakiyeVm> Vm = yapBase.cariBakiyeList;
                bn.DataSource = Vm;
            }
            usr.gridControl1.DataSource = bn;
        }
        private void Stok_Gozlem_Load(object sender, EventArgs e)
        {
           
            Control_Ayarla_Kayit(this.Controls, null, STOKlke, false);
            YardimciIslemlerKontrols.TarihSetIlkGun(TARIHdtbas);
            YardimciIslemlerKontrols.TarihSetBugun(TARIHdtbit);
            STOKlke.EditValue = stokId;
            GOZLEM_TIPcbo.SelectedIndex = 0;
           
        }
        public void controlNavigator1_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
        }
        private void Stok_Gozlem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        private void Stok_Gozlem_Shown(object sender, EventArgs e)
        {
            usr.gridControl1.Focus();
        }
        public void gridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
        }
        private void STOKlke_EditValueChanged(object sender, EventArgs e)
        {
            Gridi_Doldur();
        }

        private void GOZLEM_TIPcbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            usr.gridView1.Columns.Clear();
            if (GOZLEM_TIPcbo.SelectedIndex == 0)
            {
                Gridi_Olustur(usr);
            }
            else if (GOZLEM_TIPcbo.SelectedIndex == 1)
            {
                Gridi_Olustur_Teklif(usr);
            }
            else if (GOZLEM_TIPcbo.SelectedIndex == 2)
            {
                Gridi_Olustur_Siparis(usr);
            }
            else if (GOZLEM_TIPcbo.SelectedIndex == 3)
            {
                Gridi_Olustur_Irsaliye(usr);
            }
            else if (GOZLEM_TIPcbo.SelectedIndex == 4)
            {
                Gridi_Olustur_Stok_Siparis_Bakiye(usr);
            }
            else if (GOZLEM_TIPcbo.SelectedIndex == 5)
            {
                Gridi_Olustur_Cari_Siparis_Bakiye(usr);
            }
            else if (GOZLEM_TIPcbo.SelectedIndex == 6)
            {
                Gridi_Olustur_Cari_Bakiye(usr);
            }
            Gridi_Doldur();
        }
    }
}