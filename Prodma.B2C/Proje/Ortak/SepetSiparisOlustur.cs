using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Prodma.DataAccessB2C;
//using Prodma.DataAccessB2C;
using Prodma.SistemB2C.Controllers;
using Prodma.WinForms;
using B2C.Models;

namespace B2C.Forms
{
    public partial class SepetSiparisOlustur : SecimGridSablon
    {
        public orderVm orderVm;
        int orderId=0;
        public SepetSiparisOlustur()
        {
            InitializeComponent();
            usr.controlNavigator1.CustomButtons[0].Visible = false;
            usr.controlNavigator1.CustomButtons[1].Visible = false;
            usr.controlNavigator1.CustomButtons[2].Visible = false;
            usr.controlNavigator1.CustomButtons[3].Visible = false;
            usr.controlNavigator1.CustomButtons[5].Visible = false;
            EkranEnterleKapat = true;
            YardimciIslemlerKontrols.InvokeLueContainSet("order_id", orderlke);
            //YardimciIslemlerKontrols.InvokeLueContainSet("LK_HAYIR_EVET_ID", LK_ONAY_E_Hlke);
            YardimciIslemlerKontrols.InvokeEnumSet(YardimciIslemlerKontrols.EnumToList<SepetSecimiEn>(), SepetSecimilke);
            this.Shown += new System.EventHandler(this.SiparisOlustur_Shown);
            Gridi_Olustur(usr);
            this.Text = " B2C Sipariş Entegrasyonu";
        }
        public override bool KapatKontrol()
        {
            if (outputParametreler.Count == 0) return false;
            return true;
        }
        private void SiparisOlustur_Shown(object sender, EventArgs e)
        {
            SepetSecimilke.Focus();
        }
        void ParametreDoldur()
        {
           
            Control_Ayarla_Islemler(this.Controls, SepetSecimilke);
            //LK_ONAY_E_Hlke.EnterMoveNextControl = false;
            //YardimciIslemlerKontrols.TarihSetBugun(TARIHtxt);
            //LK_ONAY_E_Hlke.EditValue = (int)EvetHayirEn.Evet;
            SepetSecimilke.EditValue = 1;
            int id = 1;// Convert.ToInt32(inputParametreler["SIFIRLI_ID"]);
            Gridi_Doldur(B2cIslemlerService.getB2COrders((int)SepetSecimiEn.SiparisAlindiOdemeBekleniyor));
            TAMAMcmd.Visible = false;
        }
        void Gridi_Doldur(List<SepetGosterimVm> list)
        {
            bindingSource1 = new BindingSource();
            bindingSource1.DataSource = list;
            usr.gridControl1.DataSource = bindingSource1;
            usr.gridView1.OptionsSelection.EnableAppearanceFocusedCell = true;
            selection.CheckMarkColumn.VisibleIndex = 0;
        }
        void Gridi_Olustur(usrGridIslem usr)
        {
            List<Alanlar> vmList = new List<Alanlar>();
            Alanlar vm = new Alanlar(); vm.ALAN_AD = "ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TAMSAYI; vm.GORMESIN_E_H = 1; vm.ALAN_SIRA = 1; vmList.Add(vm);
            //vm = new Alanlar(); vm.ALAN_AD = "SIFIRLI_ID"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.GORMESIN_E_H = true; vm.ALAN_SIRA = 1; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "order"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 1; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "product_code"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 2; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "product_name"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 3; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "quantity"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.DECIMAL; vm.ALAN_UZUNLUK = "10"; vm.ALAN_DECIMAL = "0"; vm.ALAN_SIRA = 4; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "siparis_miktar"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.DECIMAL; vm.ALAN_SIRA = 5; vm.M_TABLO_TIP_ID = 2; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "gonderilecek_miktar"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.DECIMAL; vm.GORMESIN_E_H = 1; vm.ALAN_SIRA = 6; vm.M_TABLO_TIP_ID = 2; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "gonderilen_miktar"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.DECIMAL; vm.ALAN_SIRA = 7; vm.M_TABLO_TIP_ID = 2; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "SIPARIS_NO"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 8; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "MUSTERI_SIPARIS_NO"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA =9; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "ambar_miktar"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.DECIMAL; vm.ALAN_UZUNLUK = "10"; vm.ALAN_DECIMAL = "2"; vm.ALAN_SIRA =10; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "vehicle_toptanci_id"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 11; vm.M_TABLO_TIP_ID = 2; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "ALIS_FIYAT"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.DECIMAL; vm.ALAN_UZUNLUK = "10"; vm.ALAN_DECIMAL = "2"; vm.ALAN_SIRA =12; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "SATIS_FIYAT"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.DECIMAL; vm.ALAN_UZUNLUK = "10"; vm.ALAN_DECIMAL = "2"; vm.ALAN_SIRA = 13; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "KAR_ORAN"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.DECIMAL; vm.ALAN_UZUNLUK = "10"; vm.ALAN_DECIMAL = "2"; vm.ALAN_SIRA = 14; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "order_product_id"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.GORMESIN_E_H = 1; vm.ALAN_SIRA = 15; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "order_status_type_id"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.GORMESIN_E_H = 1; vm.ALAN_SIRA = 16; vm.M_TABLO_TIP_ID = 2; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "delivery_address"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.GORMESIN_E_H = 1; vm.ALAN_SIRA = 17; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "billing_address"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.GORMESIN_E_H = 1; vm.ALAN_SIRA = 18; vmList.Add(vm);//  vm = new Alanlar(); vm.ALAN_AD = "TUTAR"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.DECIMAL; vm.ALAN_UZUNLUK = "10"; vm.ALAN_DECIMAL = "2"; vm.ALAN_SIRA = 8; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "auth_user_id"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.GORMESIN_E_H = 1; vm.ALAN_SIRA = 1; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "IRSALIYE_NO"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 31; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "cargo_no"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 32; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "doviz_id"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 33; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "kur"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 34; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "bakiye"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.TEXTBOX; vm.ALAN_SIRA = 35; vmList.Add(vm);
            vm = new Alanlar(); vm.ALAN_AD = "payment_type"; vm.M_ALAN_TIP_ID = (int)AlanTipEn.COMBOBOX; vm.ALAN_SIRA = 36; vmList.Add(vm);
            YardimciIslemlerKontrols.Gridi_OlusturbyList(vmList, usr.gridView1, usr.gridControl1, 0, "", false);
            if (SepetSecimilke.EditValue != null)
            {
                //usr.gridView1.OptionsView.ShowGroupPanel = true;
                //usr.gridView1.Columns[0].GroupIndex = 1;
                //usr.gridView1.AppearancePrint.GroupRow.ForeColor = Color.Blue;
                //usr.gridView1.GroupFormat = "[#image]{1} {2}";
                //usr.gridView1.OptionsView.ColumnAutoWidth = true;
            }
        }
        public override void ParametreSet()
        {
            //outputParametreler.Add("TARIH", TARIHtxt.Text.ToString());
            //if (orderlke.EditValue!=null) outputParametreler.Add("order_id", orderlke.EditValue.ToString());
            //if (LK_ONAY_E_Hlke.EditValue != null) outputParametreler.Add("LK_ONAY_E_H", LK_ONAY_E_Hlke.EditValue.ToString());
            //KontrolVm kontrolVm = B2cIslemlerService.Alis_Siparis_Fis_Olustur(Value, outputParametreler, orderVm);
        }
        private void SiparisOlustur_Load(object sender, EventArgs e)
        {
            ParametreDoldur();
            usr.gridView1.OptionsView.ShowGroupPanel = true;
            usr.gridView1.Columns[1].GroupIndex = 1;
            usr.gridView1.AppearancePrint.GroupRow.ForeColor = Color.Blue;
            usr.gridView1.GroupFormat = "[#image]{1} {2}";
            usr.gridView1.OptionsView.ColumnAutoWidth = true;
            //usr.gridView1.Appearance.Row.Font = new Font("GenericSansSerif", 13);
        }
        private void orderlke_EditValueChanged(object sender, EventArgs e)
        {
           if (bindingSource1!=null)
               bindingSource1.DataSource = B2cIslemlerService.getB2COrders(Convert.ToInt32(orderlke.EditValue));  
        }
        public override void butonMenuOlustur()
        {
           //List<SepetGosterimVm> listOrderProduct = new List<SepetGosterimVm>();
           // SepetGosterimVm vm =  new SepetGosterimVm();
           // vm.product_code = "0 221 119 027";
           // vm.tedarikci = "Bosch";
           // vm.siparis_miktar = 1;
           // listOrderProduct.Add(vm);
           // B2cIslemlerService.setOzceteSiparis(listOrderProduct);
            int yetkiIndex = 0;
            if (Convert.ToInt32(SepetSecimilke.EditValue) == (int)SepetSecimiEn.SiparisAlindiOdemeBekleniyor ||  SepetSecimilke.EditValue == null)
            {
                usr.controlNavigator1.CustomButtons[6].Tag = "OdemeleriOnayla";
                usr.controlNavigator1.CustomButtons[6].Hint = YardimciIslemlerKontrols.IsimAl("OdemeleriOnayla",(int)Dil.Turkce);
                usr.controlNavigator1.CustomButtons[6].ImageIndex = 11;
                usr.controlNavigator1.CustomButtons[6].Visible = true;
                usr.controlNavigator1.CustomButtons[7].Tag = "SiparisIptalEdildi";
                usr.controlNavigator1.CustomButtons[7].Hint = YardimciIslemlerKontrols.IsimAl("SiparisIptalEdildi", (int)Dil.Turkce);
                usr.controlNavigator1.CustomButtons[7].ImageIndex = 11;
                usr.controlNavigator1.CustomButtons[7].Visible = true;
                usr.controlNavigator1.CustomButtons[8].Tag = "GeriOdemeTamamlandi";
                usr.controlNavigator1.CustomButtons[8].Hint = YardimciIslemlerKontrols.IsimAl("GeriOdemeTamamlandi", (int)Dil.Turkce);
                usr.controlNavigator1.CustomButtons[8].ImageIndex = 11;
                usr.controlNavigator1.CustomButtons[8].Visible = true;
                usr.controlNavigator1.CustomButtons[9].Tag = "Iptal";
                usr.controlNavigator1.CustomButtons[9].Hint = YardimciIslemlerKontrols.IsimAl("Iptal", (int)Dil.Turkce);
                usr.controlNavigator1.CustomButtons[9].ImageIndex = 11;
                usr.controlNavigator1.CustomButtons[9].Visible = true;
                yetkiIndex =10;
            }
            else if (Convert.ToInt32(SepetSecimilke.EditValue) == (int)SepetSecimiEn.OdemeIslemiTamamlandi )
            {
                 usr.controlNavigator1.CustomButtons[6].Tag = "AlisSiparisOlustur";
                 usr.controlNavigator1.CustomButtons[6].Hint =  YardimciIslemlerKontrols.IsimAl("AlisSiparisOlustur",(int)Dil.Turkce);
                 usr.controlNavigator1.CustomButtons[6].ImageIndex = 11;
                 usr.controlNavigator1.CustomButtons[6].Visible = false;
                
                usr.controlNavigator1.CustomButtons[7].Tag =  YardimciIslemlerKontrols.IsimAl("SiparisDurumunuGoster",(int)Dil.Turkce); 
                usr.controlNavigator1.CustomButtons[7].Hint = "SiparisDurumunuGoster";
                 usr.controlNavigator1.CustomButtons[7].ImageIndex = 11;
                 usr.controlNavigator1.CustomButtons[7].Visible = false;

                 usr.controlNavigator1.CustomButtons[8].Tag = YardimciIslemlerKontrols.IsimAl("SiparisTedarikSurecindeIsaretle",(int)Dil.Turkce);
                 usr.controlNavigator1.CustomButtons[8].Hint = "SiparisTedarikSurecindeIsaretle";
                 usr.controlNavigator1.CustomButtons[8].ImageIndex = 11;
                 usr.controlNavigator1.CustomButtons[8].Visible = true;

                 usr.controlNavigator1.CustomButtons[9].Tag = YardimciIslemlerKontrols.IsimAl("AlisSiparisGuncelle",(int)Dil.Turkce); 
                 usr.controlNavigator1.CustomButtons[9].Hint = "AlisSiparisGuncelle";
                 usr.controlNavigator1.CustomButtons[9].ImageIndex = 11;
                 usr.controlNavigator1.CustomButtons[9].Visible = false;
                 usr.controlNavigator1.CustomButtons[10].Tag = "SiparisIptalEdildi";
                 usr.controlNavigator1.CustomButtons[10].Hint = YardimciIslemlerKontrols.IsimAl("SiparisIptalEdildi", (int)Dil.Turkce);
                 usr.controlNavigator1.CustomButtons[10].ImageIndex = 11;
                 usr.controlNavigator1.CustomButtons[10].Visible = true;
                 usr.controlNavigator1.CustomButtons[11].Tag = "GeriOdemeTamamlandi";
                 usr.controlNavigator1.CustomButtons[11].Hint = YardimciIslemlerKontrols.IsimAl("GeriOdemeTamamlandi", (int)Dil.Turkce);
                 usr.controlNavigator1.CustomButtons[11].ImageIndex = 11;
                 usr.controlNavigator1.CustomButtons[11].Visible = true;
                 usr.controlNavigator1.CustomButtons[12].Tag = "Iptal";
                 usr.controlNavigator1.CustomButtons[12].Hint = YardimciIslemlerKontrols.IsimAl("Iptal", (int)Dil.Turkce);
                 usr.controlNavigator1.CustomButtons[12].ImageIndex = 11;
                 usr.controlNavigator1.CustomButtons[12].Visible = true;
                 yetkiIndex = 13;
            }
            else if (Convert.ToInt32(SepetSecimilke.EditValue) == (int)SepetSecimiEn.SiparisTedarikSurecinde)
            {
              
                usr.controlNavigator1.CustomButtons[6].Tag = YardimciIslemlerKontrols.IsimAl("AlisIrsaliyeOlustur",(int)Dil.Turkce); 
                usr.controlNavigator1.CustomButtons[6].Hint = Globals.rman.GetString("AlisIrsaliyeOlustur");
                usr.controlNavigator1.CustomButtons[6].ImageIndex = 11;
                usr.controlNavigator1.CustomButtons[6].Visible = false;
                
                usr.controlNavigator1.CustomButtons[7].Tag = YardimciIslemlerKontrols.IsimAl("SiparisHazirlandiIsaretle",(int)Dil.Turkce);
                usr.controlNavigator1.CustomButtons[7].Hint = "SiparisHazirlandiIsaretle";
                usr.controlNavigator1.CustomButtons[7].ImageIndex = 11;
                usr.controlNavigator1.CustomButtons[7].Visible = true;

                usr.controlNavigator1.CustomButtons[8].Tag =YardimciIslemlerKontrols.IsimAl("SiparisDurumunuUpdate",(int)Dil.Turkce);  
                usr.controlNavigator1.CustomButtons[8].Hint = "SiparisDurumunuUpdate";
                usr.controlNavigator1.CustomButtons[8].ImageIndex = 11;
                usr.controlNavigator1.CustomButtons[8].Visible = false;

                usr.controlNavigator1.CustomButtons[9].Tag =YardimciIslemlerKontrols.IsimAl("AlisSiparisBilgilerCek",(int)Dil.Turkce); 
                usr.controlNavigator1.CustomButtons[9].Hint = "AlisSiparisBilgilerCek";
                usr.controlNavigator1.CustomButtons[9].ImageIndex = 11;
                usr.controlNavigator1.CustomButtons[9].Visible = false;

                usr.controlNavigator1.CustomButtons[10].Tag = YardimciIslemlerKontrols.IsimAl("AlisIrsaliyeOlusturGirisFaturaOlustur",(int)Dil.Turkce);
                usr.controlNavigator1.CustomButtons[10].Hint = Globals.rman.GetString("AlisIrsaliyeOlusturGirisFaturaOlustur");
                usr.controlNavigator1.CustomButtons[10].ImageIndex = 11;
                usr.controlNavigator1.CustomButtons[10].Visible = false;

                usr.controlNavigator1.CustomButtons[11].Tag = "SiparisIptalEdildi";
                usr.controlNavigator1.CustomButtons[11].Hint = YardimciIslemlerKontrols.IsimAl("SiparisIptalEdildi", (int)Dil.Turkce);
                usr.controlNavigator1.CustomButtons[11].ImageIndex = 11;
                usr.controlNavigator1.CustomButtons[11].Visible = true;
                usr.controlNavigator1.CustomButtons[12].Tag = "GeriOdemeTamamlandi";
                usr.controlNavigator1.CustomButtons[12].Hint = YardimciIslemlerKontrols.IsimAl("GeriOdemeTamamlandi", (int)Dil.Turkce);
                usr.controlNavigator1.CustomButtons[12].ImageIndex = 11;
                usr.controlNavigator1.CustomButtons[12].Visible = true;
                usr.controlNavigator1.CustomButtons[13].Tag = "Iptal";
                usr.controlNavigator1.CustomButtons[13].Hint = YardimciIslemlerKontrols.IsimAl("Iptal", (int)Dil.Turkce);
                usr.controlNavigator1.CustomButtons[13].ImageIndex = 11;
                usr.controlNavigator1.CustomButtons[13].Visible = true;
                yetkiIndex =14;

            }
            else if (Convert.ToInt32(SepetSecimilke.EditValue) == (int)SepetSecimiEn.SiparisHazirlandi)
            {
                usr.controlNavigator1.CustomButtons[6].Tag = YardimciIslemlerKontrols.IsimAl("SatisIrsaliyeOlustur",(int)Dil.Turkce);
                usr.controlNavigator1.CustomButtons[6].Hint = Globals.rman.GetString("SatisIrsaliyeOlustur");
                usr.controlNavigator1.CustomButtons[6].ImageIndex = 11;
                usr.controlNavigator1.CustomButtons[6].Visible = false;
                usr.controlNavigator1.CustomButtons[7].Tag = YardimciIslemlerKontrols.IsimAl("SatisGonderildiOlarakIsaretle",(int)Dil.Turkce); 
                usr.controlNavigator1.CustomButtons[7].Hint = "SatisGonderildiOlarakIsaretle";
                usr.controlNavigator1.CustomButtons[7].ImageIndex = 11;
                usr.controlNavigator1.CustomButtons[7].Visible = true; 
                usr.controlNavigator1.CustomButtons[8].Tag = YardimciIslemlerKontrols.IsimAl("SatisIrsaliyeOlusturSatisFaturaOlustur",(int)Dil.Turkce); 
                usr.controlNavigator1.CustomButtons[8].Hint = Globals.rman.GetString("SatisIrsaliyeOlusturSatisFaturaOlustur");
                usr.controlNavigator1.CustomButtons[8].ImageIndex = 11;
                usr.controlNavigator1.CustomButtons[8].Visible = false;
                usr.controlNavigator1.CustomButtons[9].Tag = "SiparisIptalEdildi";
                usr.controlNavigator1.CustomButtons[9].Hint = YardimciIslemlerKontrols.IsimAl("SiparisIptalEdildi", (int)Dil.Turkce);
                usr.controlNavigator1.CustomButtons[9].ImageIndex = 11;
                usr.controlNavigator1.CustomButtons[9].Visible = true;
                usr.controlNavigator1.CustomButtons[10].Tag = "GeriOdemeTamamlandi";
                usr.controlNavigator1.CustomButtons[10].Hint = YardimciIslemlerKontrols.IsimAl("GeriOdemeTamamlandi", (int)Dil.Turkce);
                usr.controlNavigator1.CustomButtons[10].ImageIndex = 11;
                usr.controlNavigator1.CustomButtons[10].Visible = true;
                usr.controlNavigator1.CustomButtons[11].Tag = "Iptal";
                usr.controlNavigator1.CustomButtons[11].Hint = YardimciIslemlerKontrols.IsimAl("Iptal", (int)Dil.Turkce);
                usr.controlNavigator1.CustomButtons[11].ImageIndex = 11;
                usr.controlNavigator1.CustomButtons[11].Visible = true;
                yetkiIndex =12;
            }
            if (yetkiIndex==0) return;
            //yetkiIndex = 7;
            for (int i = 11; i >=  yetkiIndex;)
            {
                if (usr.controlNavigator1.CustomButtons[yetkiIndex] != null)
                {
                    usr.controlNavigator1.CustomButtons[yetkiIndex].Visible = false; yetkiIndex++;
                }
            }
        }
        public override void  MenuClick(string islem)
        {
            int yetkiIndex = 0;
            if (islem == "OdemeleriOnayla")
            {
                SepetGosterimVm listOrderProduct = new SepetGosterimVm();
                for (int i = 0; i < selection.SelectedCount; i++)
                {
                    listOrderProduct = (SepetGosterimVm)selection.GetSelectedRow(i);
                }
                if (YardimciIslemlerKontrols.UyariVer(listOrderProduct.order +  " Siparişin Ödeme İşleminin Tamamlandığını Onaylıyor Musunuz? Siparişin Tüm Kayıtları için Ödeme Onaylanmış Olacaktır") == true)
                {
                    B2cIslemlerService.OrderStatusSet(Value, (int)SepetSecimiEn.OdemeIslemiTamamlandi);
                    bindingSource1.DataSource = B2cIslemlerService.getB2COrders(Convert.ToInt32(orderlke.EditValue));  
                }
            }
            else if (islem == "AlisSiparisOlustur")
            {
                List<SepetGosterimVm> listOrderProduct = new List<SepetGosterimVm>();
                for (int i = 0; i < Value.SelectedCount; i++)
                {
                    listOrderProduct.Add((SepetGosterimVm)Value.GetSelectedRow(i));
                }
           //     listOrderProduct = listOrderProduct.OrderBy(o => o.vehicle_toptanci_id).ToList();
                var list = (from l in listOrderProduct select l.vehicle_toptanci_id).Distinct().ToList();
                foreach (var item in list)
                {
                    var list1 = (from l in listOrderProduct select l).Where(l=>l.vehicle_toptanci_id==item).ToList();
                    string siparisNo = "160556";
                    if (list1 != null && list1.Count > 0 && list1[0].ALIS_FIYAT > 0 && list1[0].siparis_miktar > 0)
                    {
                        siparisNo = B2cIslemlerService.Alis_Servis_Siparis_Olustur(Convert.ToInt32(item), list1);
                        if (YardimciIslemlerKontrols.UyariVer(siparisNo + " Sipariş numarası ile Siparişiniz Toptancıda oluşturuldu, Erpnin Sipariş oluşturmasını Olduğunu Onaylıyor Musunuz? ") == true)
                        {
                            outputParametreler.Clear();
                            outputParametreler.Add("TARIH", DateTime.Today.ToShortDateString());
                            if (orderlke.EditValue != null) outputParametreler.Add("order_id", orderlke.EditValue.ToString());
                            outputParametreler.Add("LK_ONAY_E_H", Convert.ToString((int)EvetHayirEn.Evet));
                            outputParametreler.Add("MUSTERI_SIPARIS_NO", siparisNo);
                            KontrolVm kontrolVm = B2cIslemlerService.Alis_Siparis_Fis_Olustur(list1, outputParametreler, orderVm);
                            if (kontrolVm.DONUS_INT_DEGER==1)
                            {
                                if (YardimciIslemlerKontrols.UyariVer(kontrolVm.DONUS_MESAJ + " olarak Siparişlenmiştir. Sipariş Tedarik Sürecinde Olarak İşaretlensin Mi?") == true)
                                {
                                    B2cIslemlerService.OrderStatusSet(Value, (int)SepetSecimiEn.SiparisTedarikSurecinde);
                                }    
                            }
                            else
                            {
                                MessageBox.Show(kontrolVm.DONUS_MESAJ);
                            }
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("Alış Sipariş Oluşturulamadı!");
                    }
                }
                bindingSource1.DataSource = B2cIslemlerService.getB2COrders(Convert.ToInt32(orderlke.EditValue));
            }
            else if (islem == "AlisSiparisGuncelle")
            {
                //object A = B2cIslemlerService.getEgeYazilim();
                bindingSource1 = new BindingSource();
                B2cIslemlerService.AlisFiyatGuncelle(Value, bindingSource1, (int)SepetSecimilke.EditValue);
                usr.gridControl1.DataSource = bindingSource1;
                usr.gridView1.OptionsSelection.EnableAppearanceFocusedCell = true;
                selection.CheckMarkColumn.VisibleIndex = 0;
                usr.gridView1.RefreshData();
            }
            else if (islem == "SiparisDurumunuGoster")
            {
                SepetGosterimVm listOrderProduct = new SepetGosterimVm();
                for (int i = 0; i < selection.SelectedCount; i++)
                {
                    listOrderProduct = (SepetGosterimVm)selection.GetSelectedRow(i);
                }
                MessageBox.Show(B2cIslemlerService.SiparisDurumunuGoster(listOrderProduct.order_product_id));
            }
            else if (islem == "SiparisDurumunuUpdate")
            {
                List<SepetGosterimVm> listOrderProduct = new List<SepetGosterimVm>();
                for (int i = 0; i < selection.SelectedCount; i++)
                {
                    listOrderProduct.Add((SepetGosterimVm)selection.GetSelectedRow(i));
                }
                B2cIslemlerService.SiparisDurumunuUpdate(listOrderProduct);
                Gridi_Doldur(listOrderProduct);
            }
            else if (islem == "SiparisTedarikSurecindeIsaretle")
            {
                SepetGosterimVm listOrderProduct = new SepetGosterimVm();
                for (int i = 0; i < selection.SelectedCount; i++)
                {
                    listOrderProduct = (SepetGosterimVm)selection.GetSelectedRow(i);
                }
                if (YardimciIslemlerKontrols.UyariVer(listOrderProduct.order + " Siparişin Tedarik Sürecinde Olduğunu Onaylıyor Musunuz? ") == true)
                {
                    B2cIslemlerService.OrderStatusSet(Value, (int)SepetSecimiEn.SiparisTedarikSurecinde);
                    bindingSource1.DataSource = B2cIslemlerService.getB2COrders(Convert.ToInt32(orderlke.EditValue));
                }
            }
            else if (islem == "SiparisIptalEdildi")
            {
                SepetGosterimVm listOrderProduct = new SepetGosterimVm();
                for (int i = 0; i < selection.SelectedCount; i++)
                {
                    listOrderProduct = (SepetGosterimVm)selection.GetSelectedRow(i);
                }
                if (YardimciIslemlerKontrols.UyariVer(listOrderProduct.order + " Siparişin İptal Edildiğini Onaylıyor Musunuz? ") == true)
                {
                    B2cIslemlerService.OrderStatusSet(Value, (int)SepetSecimiEn.SiparisIptalEdildi);
                    bindingSource1.DataSource = B2cIslemlerService.getB2COrders(Convert.ToInt32(orderlke.EditValue));
                }
            }
            else if (islem == "GeriOdemeTamamlandi")
            {
                SepetGosterimVm listOrderProduct = new SepetGosterimVm();
                for (int i = 0; i < selection.SelectedCount; i++)
                {
                    listOrderProduct = (SepetGosterimVm)selection.GetSelectedRow(i);
                }
                if (YardimciIslemlerKontrols.UyariVer(listOrderProduct.order + " Geri Ödemenin Tamamlandığını Onaylıyor Musunuz? ") == true)
                {
                    B2cIslemlerService.OrderStatusSet(Value, (int)SepetSecimiEn.GeriOdemeTamamlandi);
                    bindingSource1.DataSource = B2cIslemlerService.getB2COrders(Convert.ToInt32(orderlke.EditValue));
                }
            }
            else if (islem == "GeriOdemeTamamlandi")
            {
                SepetGosterimVm listOrderProduct = new SepetGosterimVm();
                for (int i = 0; i < selection.SelectedCount; i++)
                {
                    listOrderProduct = (SepetGosterimVm)selection.GetSelectedRow(i);
                }
                if (YardimciIslemlerKontrols.UyariVer(listOrderProduct.order + " Geri Ödemenin Tamamlandığını Onaylıyor Musunuz? ") == true)
                {
                    B2cIslemlerService.OrderStatusSet(Value, (int)SepetSecimiEn.GeriOdemeTamamlandi);
                    bindingSource1.DataSource = B2cIslemlerService.getB2COrders(Convert.ToInt32(orderlke.EditValue));
                }
            }
            else if (islem == "AlisSiparisBilgilerCek")
            {
                List<SepetGosterimVm> listOrderProduct = new List<SepetGosterimVm>();
                for (int i = 0; i < selection.SelectedCount; i++)
                {
                    listOrderProduct.Add((SepetGosterimVm)selection.GetSelectedRow(i));
                }
                //B2cIslemlerService.getAlisSiparisBilgilerCek(listOrderProduct);
                usr.gridView1.RefreshData();
            }
            else  if (islem == "AlisSiparisOlusturGonder")
            {
                //string sonuc = B2cIslemlerService.getOzceteFiyat();
                MessageBox.Show("Alış Siparişi Oluşturulacak, Toptancıya Gönderilecek");
            }
            else if (islem == "AlisIrsaliyeOlustur")
            {
                Dictionary<string, string> parametreler = new Dictionary<string,string>();
                parametreler.Add("TARIH", Convert.ToString(DateTime.Today));
                //parametreler.Add("ISLEM_TIPI_ID", Convert.ToString((int)VarsayilanIdlerEn.IrsaliyeAlisIslemTipi));
                //parametreler.Add("AMBAR_ID", Convert.ToString((int)VarsayilanIdlerEn.Ambar));
                List<SepetGosterimVm> listOrderProduct = new List<SepetGosterimVm>();
                for (int i = 0; i < selection.SelectedCount; i++)
                {
                    listOrderProduct.Add((SepetGosterimVm)selection.GetSelectedRow(i));
                }
                parametreler.Add("IRSALIYE_NO", listOrderProduct[0].IRSALIYE_NO);
                if (listOrderProduct!=null && listOrderProduct.Count>0  && Convert.ToString(listOrderProduct[0].IRSALIYE_NO)  !="" && Convert.ToDecimal(listOrderProduct[0].gonderilen_miktar)>0)
                {
                   B2cIslemlerService.AlisIrsaliyeOlustur(listOrderProduct, parametreler);                 
                }
                else
	            {
                    MessageBox.Show("Alış İrsaliye Oluşturulması İçin Parametreler Eksik");
	            }
            }
            else if (islem == "SiparisHazirlandiIsaretle")
            {
                SepetGosterimVm listOrderProduct = new SepetGosterimVm();
                for (int i = 0; i < Value.SelectedCount; i++)
                {
                    listOrderProduct = (SepetGosterimVm)Value.GetSelectedRow(i);
                }
                if (YardimciIslemlerKontrols.UyariVer(listOrderProduct.order + " Siparişin Hazırlandı Olarak Onaylıyor Musunuz? ") == true)
                {
                    B2cIslemlerService.OrderStatusSet(Value, (int)SepetSecimiEn.SiparisHazirlandi);
                    bindingSource1.DataSource = B2cIslemlerService.getB2COrdersFromSiparis();
                }

            }
            else if (islem =="SatisGonderildiOlarakIsaretle")
            {
                List<SepetGosterimVm> listOrderProduct = new List<SepetGosterimVm>();
                for (int i = 0; i < selection.SelectedCount; i++)
                {
                    listOrderProduct.Add((SepetGosterimVm)selection.GetSelectedRow(i));
                }
                if (Convert.ToString(listOrderProduct[0].cargo_no)==null)
                {
                    MessageBox.Show("Kargo Numarası Giriniz");
                }
                else
                {
                    if (YardimciIslemlerKontrols.UyariVer(listOrderProduct[0].order + " Siparişini Gönderildi Olarak Onaylıyor Musunuz? ") == true)
                    {
                        B2cIslemlerService.KargoNumarasiSet(listOrderProduct);
                        B2cIslemlerService.OrderStatusSet(Value, (int)SepetSecimiEn.SiparisGonderildi);
                        bindingSource1.DataSource = B2cIslemlerService.getB2COrders(Convert.ToInt32(orderlke.EditValue));
                    }
                }

            }
            else if (islem == "AlisIrsaliyeOlusturGirisFaturaOlustur")
            {
                MessageBox.Show("Alış İrsaliye  Oluşturulacak, Faturalandırılacak.");
            }
            else if (islem == "SatisIrsaliyeOlustur")
            {
                Dictionary<string, string> parametreler = new Dictionary<string, string>();
                parametreler.Add("TARIH", Convert.ToString(DateTime.Today));
                //parametreler.Add("ISLEM_TIPI_ID", Convert.ToString((int)VarsayilanIdlerEn.IrsaliyeSatisIslemTipi));
                //parametreler.Add("AMBAR_ID", Convert.ToString((int)VarsayilanIdlerEn.Ambar));
                //parametreler.Add("IRSALIYE_NO", AlisSatis.Fis.Services.FisControlService.GetMax_Irsaliye_No(null, "WE"));
                List<SepetGosterimVm> listOrderProduct = new List<SepetGosterimVm>();
                for (int i = 0; i < selection.SelectedCount; i++)
                {
                    listOrderProduct.Add((SepetGosterimVm)selection.GetSelectedRow(i));
                }
                B2cIslemlerService.SatisIrsaliyeOlustur(listOrderProduct, parametreler);
            }
            else if (islem == "SatisIrsaliyeOlusturSatisFaturaOlustur")
            {
                MessageBox.Show("Satış İrsaliye  Oluşturulacak, Kargo numarası istenecek ,Satış Faturası Oluşturulacak");
            }
        }
        private void SepetSecimilke_EditValueChanged(object sender, EventArgs e)
        {
            int count = 0;
            selection.ClearSelection();
            if (Convert.ToInt32(SepetSecimilke.EditValue) == (int)SepetSecimiEn.SiparisAlindiOdemeBekleniyor )
            {
                usr.gridView1.Columns[5].Visible = false;
                usr.gridView1.Columns[6].Visible = false;
                usr.gridView1.Columns[7].Visible = false;
                usr.gridView1.Columns[8].Visible = false;
                usr.gridView1.Columns[9].Visible = false;
                usr.gridView1.Columns[10].Visible = false;
                usr.gridView1.Columns[11].Visible = false;
                usr.gridView1.Columns[12].Visible = false;
                usr.gridView1.Columns[13].Visible = false;
                usr.gridView1.Columns[14].Visible = false;
                usr.gridView1.Columns[15].Visible = false;
                usr.gridView1.Columns[16].Visible = false;
                usr.gridView1.Columns[17].Visible = false;
                usr.gridView1.Columns[18].Visible = false;
                usr.gridView1.Columns[19].Visible = false;
                usr.gridView1.Columns[20].Visible = false;
                usr.gridView1.Columns[21].Visible = false;
                usr.gridView1.Columns[22].Visible = false;
                usr.gridView1.Columns[23].Visible = false;
                usr.gridView1.Columns[24].Visible = false;
                Gridi_Doldur( B2cIslemlerService.getB2COrders(Convert.ToInt32(SepetSecimilke.EditValue)));
             }
             else if (  Convert.ToInt32(SepetSecimilke.EditValue) == (int)SepetSecimiEn.OdemeIslemiTamamlandi)
             {
                usr.gridView1.Columns[5].Visible = true;
                usr.gridView1.Columns[6].Visible = false; 
                usr.gridView1.Columns[7].Visible = false;  
                usr.gridView1.Columns[8].Visible = false;  
                usr.gridView1.Columns[9].Visible = false;  
                usr.gridView1.Columns[10].Visible = true;
                usr.gridView1.Columns[11].Visible = true;
                usr.gridView1.Columns[12].Visible = true;
                usr.gridView1.Columns[13].Visible = true;
                usr.gridView1.Columns[14].Visible = true;
                usr.gridView1.Columns[15].Visible = false;  
                usr.gridView1.Columns[16].Visible = false;  
                usr.gridView1.Columns[17].Visible = false;  
                usr.gridView1.Columns[18].Visible = false; 
                usr.gridView1.Columns[19].Visible = false;  
                usr.gridView1.Columns[20].Visible = false;
                usr.gridView1.Columns[21].Visible = false;
                usr.gridView1.Columns[22].Visible = false;
                usr.gridView1.Columns[23].Visible = false;
                usr.gridView1.Columns[24].Visible = false;
                Gridi_Doldur(B2cIslemlerService.getB2COrders(Convert.ToInt32(SepetSecimilke.EditValue)));
             }
             else if (Convert.ToInt32(SepetSecimilke.EditValue) == (int)SepetSecimiEn.SiparisTedarikSurecinde)
             {
                 usr.gridView1.Columns[5].Visible = true;
                 usr.gridView1.Columns[6].Visible = false; 
                 usr.gridView1.Columns[7].Visible = true; 
                 usr.gridView1.Columns[8].Visible = true;  
                 usr.gridView1.Columns[9].Visible = true; 
                 usr.gridView1.Columns[10].Visible = false;  
                 usr.gridView1.Columns[11].Visible = true;
                 usr.gridView1.Columns[12].Visible = true;
                 usr.gridView1.Columns[13].Visible = false;
                 usr.gridView1.Columns[14].Visible = false;
                 usr.gridView1.Columns[15].Visible = false;  
                 usr.gridView1.Columns[16].Visible = false; 
                 usr.gridView1.Columns[17].Visible = false;  
                 usr.gridView1.Columns[18].Visible = false; 
                 usr.gridView1.Columns[19].Visible = false;  
                 usr.gridView1.Columns[20].Visible = true;
                 usr.gridView1.Columns[21].Visible = false;
                 usr.gridView1.Columns[22].Visible = false;
                 usr.gridView1.Columns[23].Visible = false;
                 usr.gridView1.Columns[24].Visible = true;
                 Gridi_Doldur(B2cIslemlerService.getB2COrders(Convert.ToInt32(SepetSecimilke.EditValue)));
                 //List<SepetGosterimVm> listOrderProduct = new List<SepetGosterimVm>();
                 //for (int i = 0; i < selection.SelectedCount; i++)
                 //{
                 //   listOrderProduct.Add((SepetGosterimVm)selection.GetSelectedRow(i));
                 //}
                 //B2cIslemlerService.SiparisDurumunuUpdate(listOrderProduct);
                 //Gridi_Doldur(listOrderProduct);
              }
              else if (Convert.ToInt32(SepetSecimilke.EditValue)==(int)SepetSecimiEn.SiparisHazirlandi)
              {
                usr.gridView1.Columns[5].Visible = false;
                usr.gridView1.Columns[6].Visible = true;
                usr.gridView1.Columns[7].Visible = false;
                usr.gridView1.Columns[8].Visible = false;
                usr.gridView1.Columns[9].Visible = false;
                usr.gridView1.Columns[10].Visible = false;
                usr.gridView1.Columns[11].Visible = false;
                usr.gridView1.Columns[12].Visible = false;
                usr.gridView1.Columns[13].Visible = false;
                usr.gridView1.Columns[14].Visible = false;
                usr.gridView1.Columns[15].Visible = false;
                usr.gridView1.Columns[16].Visible = false;
                usr.gridView1.Columns[17].Visible = false;
                usr.gridView1.Columns[18].Visible = false;
                usr.gridView1.Columns[19].Visible = false;
                usr.gridView1.Columns[20].Visible = true;
                usr.gridView1.Columns[21].Visible = true;
                usr.gridView1.Columns[22].Visible = false;
                usr.gridView1.Columns[23].Visible = false;
                usr.gridView1.Columns[24].Visible = false;
                Gridi_Doldur(B2cIslemlerService.getB2COrders(Convert.ToInt32(SepetSecimilke.EditValue)));
            }
            else  
            {
                Gridi_Doldur(B2cIslemlerService.getB2COrders(Convert.ToInt32(SepetSecimilke.EditValue)));
            }
            for (int i = 5; i < 23; i++)
            {
                if (usr.gridView1.Columns[i].Visible==true)
                {
                    usr.gridView1.Columns[i].VisibleIndex = i;                    
                }
                else
                {
                    usr.gridView1.Columns[i].VisibleIndex = -1;                    
                }
            }
            butonMenuOlustur();
            int index = 0;
            usr.ContextMenu1.MenuItems.Clear();
            foreach (var buttons in usr.controlNavigator1.Buttons.CustomButtons)
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)buttons;
                if (btn.Tag != null && btn.Visible == true)
                {
                    usr.contextMenuItems[index] = new MenuItem();
                    usr.contextMenuItems[index].Text = btn.Hint;
                    usr.contextMenuItems[index].Tag = btn.Tag;
                    usr.ContextMenu1.MenuItems.Add(usr.contextMenuItems[index]);
                    usr.contextMenuItems[index].Click += new System.EventHandler(usr.MenuItem1_Click);
                    index++;
                }
            }
          //  butonMenuOlustur();
            //if (bindingSource1 != null)
            //{
            //    orderlke.Properties.DataSource = B2cIslemlerService.getB2COrders((int)SepetSecimilke.EditValue);
            //    orderlke.Properties.NullText = "";
            //    orderlke.Properties.ValueMember = "ID";
            //    orderlke.Properties.DisplayMember = "AD";
            //    orderlke.Properties.ForceInitialize();
            //    orderlke.Properties.PopulateColumns();
            //    for (int i = 0; i < orderlke.Properties.Columns.Count; i++)
            //    {
            //        if (orderlke.Properties.Columns[i].FieldName != "AD")
            //            orderlke.Properties.Columns[i].Visible = false;
            //    }
            //}
        }
     
    }
}