using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Prodma.DataAccess;
using Siparis.Fis.Models;
using Siparis.Fis.Controllers;
using Satis.StokAmbar.Models;
using Satis.StokAmbar.Controllers;
using Satis.Cari.Models;
using System.Globalization;
using Satis.Cari.Controllers;
using Prodma.Sistem.Models;
using Prodma.Sistem.Controllers;
using Prodma.Enum;
namespace Prodma.Sistem.Forms
{
    public partial class usrFirmaParametreEkBilgi : usrControlSablon
    {
        public string kayitEdilemez = "";
        public FirmaParametreVm firmaParametreVm;
        private FirmaParametreCntrl firmaParametreCntrl = new FirmaParametreCntrl();
        public usrFirmaParametreEkBilgi()
        {
            InitializeComponent();
            Ilk_Deger_Ver();
            escapeKapatma = true;
        }
        void Ilk_Deger_Ver()
        {
            YardimciIslemler.InvokeEnumSet(YardimciIslemler.EnumToList<DovizKurTipEn>(), SATIS_DOVIZ_KUR_TIPlke);
            YardimciIslemler.InvokeEnumSet(YardimciIslemler.EnumToList<DovizKurTipEn>(), ALIS_DOVIZ_KUR_TIPlke);
            
            GENEL_KDV_YUZDElke.Properties.DataSource = ListService.GetKDV_YUZDE_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            SATIS_FIYAT_AYRIM_KONTROL_E_Hlke.Properties.DataSource = ListService.GetLK_HAYIR_EVET_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            ALIS_FIYAT_AYRIM_KONTROL_E_Hlke.Properties.DataSource = ListService.GetLK_HAYIR_EVET_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            PLASIYER_E_Hlke.Properties.DataSource = ListService.GetLK_HAYIR_EVET_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            IRSALIYE_FATURA_E_Hlke.Properties.DataSource = ListService.GetLK_HAYIR_EVET_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);            
            STOK_MALIYET_TIP_IDlke.Properties.DataSource = ListService.GetSTOK_AYRI_MALIYET_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            STOK_MIKTAR_KONTROL_TIP_IDlke.Properties.DataSource = ListService.GetLK_HAYIR_EVET_ID((int)ListServiceTipEn.LISTE, (int)AktifPasifTumuEn.TUMU, 0, 0, 0, "", "", 0);
            BARKOD_KULLANIM_E_Hlke.Properties.DataSource = ListService.GetLK_HAYIR_EVET_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            MUSTERI_PLASIYER_E_Hlke.Properties.DataSource = ListService.GetLK_HAYIR_EVET_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            alanlarVm = ListDenemeService.GetALANLAR("FIRMA_PARAMETRE", 2);
            //STOK_MIKTAR_KONTROL_TIP_IDcbo.Properties.DataSource = ListService.
        }

        public override void Doldur()
        {
            Control_Ayarla_Kayit(this.Controls, alanlarVm, MUHASEBE_KIRILMAtxt, IRSALIYE_FATURA_GUN_KONTROL_SAYISItxt, true);
            try
            {
                firmaParametreVm = firmaParametreCntrl.Liste_Al(firmaParametreVm)[0];
            }
            catch (Exception)
            {
                firmaParametreCntrl.Ekle(firmaParametreVm);
                firmaParametreVm = firmaParametreCntrl.Liste_Al(firmaParametreVm)[0];
            }
            

            MUHASEBE_KIRILMAtxt.Text = Convert.ToString(firmaParametreVm.MUHASEBE_KIRILMA) ?? "";
            MUHASEBE_KIRILMAtxt.Text = Convert.ToString(firmaParametreVm.MUHASEBE_KIRILMA) ?? "";
            STOK_KIRILMAtxt.Text = Convert.ToString(firmaParametreVm.STOK_KIRILMA) ?? "";
            CARI_HESAP_KIRILMAtxt.Text = Convert.ToString(firmaParametreVm.CARI_HESAP_KIRILMA) ?? "";
            MASRAF_YERI_KIRILMAtxt.Text = Convert.ToString(firmaParametreVm.MASRAF_YERI_KIRILMA) ?? "";
            BUTCE_KIRILMAtxt.Text = Convert.ToString(firmaParametreVm.BUTCE_KIRILMA) ?? "";
            URETIM_YERI_KIRILMAtxt.Text = Convert.ToString(firmaParametreVm.URETIM_YERI_KIRILMA) ?? "";
            MUHASEBE_KAPALI_AYtxt.Text = Convert.ToString(firmaParametreVm.MUHASEBE_KAPALI_AY) ?? "";
            MUHASEBE_KAPALI_YILtxt.Text = Convert.ToString(firmaParametreVm.MUHASEBE_KAPALI_YIL) ?? "";
            DIGER_KAPALI_AYtxt.Text = Convert.ToString(firmaParametreVm.DIGER_KAPALI_AY) ?? "";
            DIGER_KAPALI_YILtxt.Text = Convert.ToString(firmaParametreVm.DIGER_KAPALI_YIL) ?? "";
            IRSALIYE_KOCAN_DEGISIM_TARIHdte.EditValue =  firmaParametreVm.IRSALIYE_KOCAN_DEGISIM_TARIH  ?? (DateTime?)null;
            IRSALIYE_KOCAN_SERI_NUMARASItxt.Text = Convert.ToString(firmaParametreVm.IRSALIYE_KOCAN_SERI_NUMARASI) ?? "";
            FATURA_KOCAN_DEGISIM_TARIHdte.EditValue = firmaParametreVm.FATURA_KOCAN_DEGISIM_TARIH  ?? (DateTime?)null;
            FATURA_KOCAN_SERI_NUMARASItxt.Text = Convert.ToString(firmaParametreVm.FATURA_KOCAN_SERI_NUMARASI) ?? "";
            IRSALIYE_FATURA_GUN_KONTROL_SAYISItxt.Text = Convert.ToString(firmaParametreVm.IRSALIYE_FATURA_GUN_KONTROL_SAYISI) ?? "";

            GENEL_KDV_YUZDElke.EditValue = (int?)firmaParametreVm.GENEL_KDV_YUZDE_ID;
            SATIS_FIYAT_AYRIM_KONTROL_E_Hlke.EditValue = (int?)firmaParametreVm.SATIS_FIYAT_AYRIM_KONTROL_E_H;
            ALIS_FIYAT_AYRIM_KONTROL_E_Hlke.EditValue = (int?)firmaParametreVm.ALIS_FIYAT_AYRIM_KONTROL_E_H;
            SATIS_DOVIZ_KUR_TIPlke.EditValue = (int?)firmaParametreVm.SATIS_DOVIZ_KUR_TIP;
            ALIS_DOVIZ_KUR_TIPlke.EditValue = (int?)firmaParametreVm.ALIS_DOVIZ_KUR_TIP;
            PLASIYER_E_Hlke.EditValue = (int?)firmaParametreVm.PLASIYER_E_H;
            IRSALIYE_FATURA_E_Hlke.EditValue = (int?)firmaParametreVm.IRSALIYELI_FATURA_E_H;
            STOK_MALIYET_TIP_IDlke.EditValue = (int?)firmaParametreVm.STOK_MALIYET_TIP_ID;
            BARKOD_KULLANIM_E_Hlke.EditValue = (int?)firmaParametreVm.BARKOD_KULLANIM_E_H;
            STOK_MIKTAR_KONTROL_TIP_IDlke.EditValue = (int?)firmaParametreVm.STOK_MIKTAR_KONTROL_TIP_ID;
            MUSTERI_PLASIYER_E_Hlke.EditValue =(int?)firmaParametreVm.MUSTERI_PLASIYER_E_H;
                
        }

        public override void Kaydet()
        {
            firmaParametreVm.GENEL_KDV_YUZDE_ID = (int?)GENEL_KDV_YUZDElke.EditValue ;
            firmaParametreVm.SATIS_FIYAT_AYRIM_KONTROL_E_H = (byte?)(int?)SATIS_FIYAT_AYRIM_KONTROL_E_Hlke.EditValue;
            firmaParametreVm.ALIS_FIYAT_AYRIM_KONTROL_E_H =(byte?)(int?)ALIS_FIYAT_AYRIM_KONTROL_E_Hlke.EditValue;  
            firmaParametreVm.SATIS_DOVIZ_KUR_TIP =(int?)SATIS_DOVIZ_KUR_TIPlke.EditValue;
            firmaParametreVm.ALIS_DOVIZ_KUR_TIP = (int?)ALIS_DOVIZ_KUR_TIPlke.EditValue;
            //if (ALIS_DOVIZ_KUR_TIPcbo.EditValue != null) { firmaParametreVm.ALIS_DOVIZ_KUR_TIP = Convert.ToByte(ALIS_DOVIZ_KUR_TIPcbo.EditValue); } else { firmaParametreVm.ALIS_DOVIZ_KUR_TIP = null; }
            firmaParametreVm.PLASIYER_E_H =(byte?)(int?)PLASIYER_E_Hlke.EditValue; 
             firmaParametreVm.IRSALIYELI_FATURA_E_H =(byte?)(int?)IRSALIYE_FATURA_E_Hlke.EditValue; 
             firmaParametreVm.STOK_MALIYET_TIP_ID =(byte?)(int?)STOK_MALIYET_TIP_IDlke.EditValue; 
             firmaParametreVm.BARKOD_KULLANIM_E_H =(byte?)(int?)BARKOD_KULLANIM_E_Hlke.EditValue;
             firmaParametreVm.STOK_MIKTAR_KONTROL_TIP_ID = (byte?)(int?)STOK_MIKTAR_KONTROL_TIP_IDlke.EditValue; 
             firmaParametreVm.MUSTERI_PLASIYER_E_H = (byte?)(int?)MUSTERI_PLASIYER_E_Hlke.EditValue; 
            firmaParametreVm.MUHASEBE_KIRILMA = MUHASEBE_KIRILMAtxt.Text;
            firmaParametreVm.STOK_KIRILMA = STOK_KIRILMAtxt.Text;
            firmaParametreVm.CARI_HESAP_KIRILMA = CARI_HESAP_KIRILMAtxt.Text;
            firmaParametreVm.MASRAF_YERI_KIRILMA = MASRAF_YERI_KIRILMAtxt.Text;
            firmaParametreVm.BUTCE_KIRILMA = BUTCE_KIRILMAtxt.Text;
            firmaParametreVm.URETIM_YERI_KIRILMA = URETIM_YERI_KIRILMAtxt.Text;

            firmaParametreVm.MUHASEBE_KAPALI_AY = MUHASEBE_KAPALI_AYtxt.Text!="" ? Convert.ToByte(MUHASEBE_KAPALI_AYtxt.Text): (byte?)(int?)null;
           firmaParametreVm.MUHASEBE_KAPALI_YIL = MUHASEBE_KAPALI_YILtxt.Text!="" ? Convert.ToInt32(MUHASEBE_KAPALI_YILtxt.Text): (int?)null;
           firmaParametreVm.DIGER_KAPALI_AY = DIGER_KAPALI_AYtxt.Text!="" ? Convert.ToByte(DIGER_KAPALI_AYtxt.Text): (byte?)(int?)null;
            firmaParametreVm.DIGER_KAPALI_YIL =DIGER_KAPALI_YILtxt.Text!="" ?  Convert.ToInt16(DIGER_KAPALI_YILtxt.Text):  (int?)null;
            firmaParametreVm.IRSALIYE_FATURA_GUN_KONTROL_SAYISI = IRSALIYE_FATURA_GUN_KONTROL_SAYISItxt.Text != "" ? Convert.ToByte(IRSALIYE_FATURA_GUN_KONTROL_SAYISItxt.Text) : (byte?)(int?)null;
            firmaParametreVm.IRSALIYE_KOCAN_DEGISIM_TARIH = (DateTime?)IRSALIYE_KOCAN_DEGISIM_TARIHdte.EditValue;
            firmaParametreVm.IRSALIYE_KOCAN_SERI_NUMARASI = IRSALIYE_KOCAN_SERI_NUMARASItxt.Text;
            firmaParametreVm.FATURA_KOCAN_DEGISIM_TARIH =  (DateTime?)FATURA_KOCAN_DEGISIM_TARIHdte.EditValue;
            firmaParametreVm.FATURA_KOCAN_SERI_NUMARASI = FATURA_KOCAN_SERI_NUMARASItxt.Text;
            firmaParametreCntrl.KayitMesajiGoster = true;
            firmaParametreCntrl.Guncelle(firmaParametreVm, firmaParametreVm.ID);
            if (firmaParametreCntrl.hataKod  !=  100)
            {
                FirmaParametreVm Vm = firmaParametreCntrl.Liste_Al(firmaParametreVm)[0];
                firmaParametreVm = Vm;
                Doldur();
            }
        }

   
    }
}