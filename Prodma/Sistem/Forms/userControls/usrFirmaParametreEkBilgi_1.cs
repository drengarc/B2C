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
namespace Prodma.Sistem.Forms
{
    public partial class usrFirmaParametreEkBilgi_1 : usrControlSablon
    {
        public string kayitEdilemez = "";
        public FirmaParametreVm firmaParametreVm;
        private FirmaParametreCntrl firmaParametreCntrl = new FirmaParametreCntrl();
        public usrFirmaParametreEkBilgi_1()
        {
            InitializeComponent();
            Ilk_Deger_Ver();
        }

        void Ilk_Deger_Ver()
        {
            BindingSource evetHayir = new BindingSource();
            evetHayir.DataSource = ListService.GetLK_HAYIR_EVET_ID((int)ListServiceTipEn.LISTE,(int)AktifPasifTumuEn.TUMU, 0, 0, 0,"","",0);
            FATURA_KDV_YUZDE_KONTROL_E_Hcbo.Properties.DataSource = evetHayir;
            F_CARI_HESAP_KONTROLcbo.Properties.DataSource = evetHayir;
            IRSALIYE_DOKUM_STOK_BIRLESTIR_E_Hcbo.Properties.DataSource = evetHayir;
            FATURA_DOKUM_STOK_BIRLESTIRcbo.Properties.DataSource = evetHayir;
            GRUP_OPERASYON_KULLANIM_E_Hcbo.Properties.DataSource = evetHayir;
            MUHASEBE_CIKIS_ISKONTO_TAKIP_E_Hcbo.Properties.DataSource = evetHayir;
            MUHASEBE_GIRIS_ISKONTO_TAKIP_E_Hcbo.Properties.DataSource = evetHayir;
            MUH_ENTEGRASYON_CEK_FISTEN_E_Hcbo.Properties.DataSource = evetHayir;
            SATIS_SIPARIS_BAKIYE_KONTROL_E_Hcbo.Properties.DataSource = evetHayir;
            MANUEL_SATIS_SIPARIS_GIRIScbo.Properties.DataSource = evetHayir;
            STOK_SABIT_RAFcbo.Properties.DataSource = evetHayir;
            SIPARIS_AMBALAJ_SEVK_E_Hcbo.Properties.DataSource = evetHayir;
            MUHASEBE_ENTEGRASYON_UYARIcbo.Properties.DataSource = evetHayir;
            MUHASEBE_ENTEGRASYON_GIRIS_FISTENcbo.Properties.DataSource = evetHayir;
            MUHASEBE_ENTEGRASYON_CIKIS_FISTENcbo.Properties.DataSource = evetHayir;
            MUHASEBE_ENTEGRASYON_MAHSUP_FISTENcbo.Properties.DataSource = evetHayir;
            FIYAT_KONTROL_TIP_ID_PLANcbo.Properties.DataSource = evetHayir;
            FIYAT_KONTROL_TIP_ID_SIPARIScbo.Properties.DataSource = evetHayir;
            YardimciIslemler.InvokeLueContainSet("MUHASEBE_HESAP_PLANI_ID", HAMMADDE_MUHASEBE_HESAP_PLANI_IDlke);
            YardimciIslemler.InvokeLueContainSet("MUHASEBE_HESAP_PLANI_ID", TICARI_OLMAYAN_MUHASEBE_HESAP_PLANI_IDlke);
            alanlarVm = ListDenemeService.GetALANLAR("FIRMA_PARAMETRE", 2);
            //FIYAT_KONTROL_TIP_ID_PLANcbo.Properties.DataSource =
            //FIYAT_KONTROL_TIP_ID_SIPARIScbo.Properties.DataSource =
        }

        public override void Doldur()
        {
            Control_Ayarla_Kayit(this.Controls, alanlarVm, FATURA_KDV_YUZDE_KONTROL_E_Hcbo, LOGO_PATHtxt, true);
            try
            {
                firmaParametreVm = firmaParametreCntrl.Liste_Al(firmaParametreVm)[0];
            }
            catch (Exception)
            {
                firmaParametreCntrl.Ekle(firmaParametreVm);
                firmaParametreVm = firmaParametreCntrl.Liste_Al(firmaParametreVm)[0];
            }
            
            TOPLAM_IHTIYAC_BELIRLEME_GUN_SAYItxt.Text = Convert.ToString(firmaParametreVm.TOPLAM_IHTIYAC_BELIRLEME_GUN_SAYI) ?? "";
            BARKOD_YAZICI_AG_YOLUtxt.Text = Convert.ToString(firmaParametreVm.BARKOD_YAZICI_AG_YOLU) ?? "";
            LOGO_PATHtxt.Text = Convert.ToString(firmaParametreVm.LOGO_PATH) ?? "";
            MUHASEBE_ENTEGRASYON_FIS_SATIR_SAYItxt.Text = Convert.ToString(firmaParametreVm.MUHASEBE_ENTEGRASYON_FIS_SATIR_SAYI) ?? "";

           FATURA_KDV_YUZDE_KONTROL_E_Hcbo.EditValue = (int?)firmaParametreVm.FATURA_KDV_YUZDE_KONTROL_E_H ;
           F_CARI_HESAP_KONTROLcbo.EditValue = (int?)firmaParametreVm.FATURA_CARI_HESAP_VERGI_NO_KONTROL_E_H;
           IRSALIYE_DOKUM_STOK_BIRLESTIR_E_Hcbo.EditValue = (int?)firmaParametreVm.IRSALIYE_DOKUM_STOK_BIRLESTIR_E_H;
           FATURA_DOKUM_STOK_BIRLESTIRcbo.EditValue = (int?)firmaParametreVm.FATURA_DOKUM_STOK_BIRLESTIR_E_H;
           GRUP_OPERASYON_KULLANIM_E_Hcbo.EditValue = (int?)firmaParametreVm.GRUP_OPERASYON_KULLANIM_E_H;
           MUHASEBE_CIKIS_ISKONTO_TAKIP_E_Hcbo.EditValue = (int?)firmaParametreVm.MUHASEBE_CIKIS_ISKONTO_TAKIP_E_H;
           MUHASEBE_GIRIS_ISKONTO_TAKIP_E_Hcbo.EditValue = (int?)firmaParametreVm.MUHASEBE_GIRIS_ISKONTO_TAKIP_E_H;
           MUH_ENTEGRASYON_CEK_FISTEN_E_Hcbo.EditValue = (int?)firmaParametreVm.MUHASEBE_ENTEGRASYON_CEK_FISTEN_E_H;
           SATIS_SIPARIS_BAKIYE_KONTROL_E_Hcbo.EditValue = (int?)firmaParametreVm.SATIS_SIPARIS_BAKIYE_KONTROL_E_H;
           MANUEL_SATIS_SIPARIS_GIRIScbo.EditValue = (int?)firmaParametreVm.MANUEL_SATIS_SIPARIS_GIRIS_E_H;
           STOK_SABIT_RAFcbo.EditValue = (int?)firmaParametreVm.STOK_SABIT_RAF_E_H;
           SIPARIS_AMBALAJ_SEVK_E_Hcbo.EditValue = (int?)firmaParametreVm.SIPARIS_AMBALAJ_SEVK_E_H;
           MUHASEBE_ENTEGRASYON_UYARIcbo.EditValue = (int?)firmaParametreVm.MUHASEBE_ENTEGRASYON_UYARI_E_H;
           MUHASEBE_ENTEGRASYON_GIRIS_FISTENcbo.EditValue = (int?)firmaParametreVm.MUHASEBE_ENTEGRASYON_GIRIS_FISTEN_E_H;
           MUHASEBE_ENTEGRASYON_CIKIS_FISTENcbo.EditValue = (int?)firmaParametreVm.MUHASEBE_ENTEGRASYON_CIKIS_FISTEN_E_H;
           MUHASEBE_ENTEGRASYON_MAHSUP_FISTENcbo.EditValue = (int?)firmaParametreVm.MUHASEBE_ENTEGRASYON_MAHSUP_FISTEN_E_H;
           FIYAT_KONTROL_TIP_ID_PLANcbo.EditValue = (int?)firmaParametreVm.FIYAT_KONTROL_TIP_ID_PLAN;
           FIYAT_KONTROL_TIP_ID_SIPARIScbo.EditValue = (int?)firmaParametreVm.FIYAT_KONTROL_TIP_ID_SIPARIS;
           TICARI_OLMAYAN_MUHASEBE_HESAP_PLANI_IDlke.EditValue = (int?)firmaParametreVm.TICARI_OLMAYAN_MUHASEBE_HESAP_PLANI_ID;
           HAMMADDE_MUHASEBE_HESAP_PLANI_IDlke.EditValue = (int?)firmaParametreVm.HAMMADDE_MUHASEBE_HESAP_PLANI_ID;

        }

        public override void Kaydet()
        {
            firmaParametreVm.FATURA_KDV_YUZDE_KONTROL_E_H = (byte?)(int?)FATURA_KDV_YUZDE_KONTROL_E_Hcbo.EditValue; 
            firmaParametreVm.FATURA_CARI_HESAP_VERGI_NO_KONTROL_E_H = (byte?)(int?)F_CARI_HESAP_KONTROLcbo.EditValue; 
            firmaParametreVm.IRSALIYE_DOKUM_STOK_BIRLESTIR_E_H = (byte?)(int?)IRSALIYE_DOKUM_STOK_BIRLESTIR_E_Hcbo.EditValue; 
            firmaParametreVm.FATURA_DOKUM_STOK_BIRLESTIR_E_H = (byte?)(int?)FATURA_DOKUM_STOK_BIRLESTIRcbo.EditValue; 
            firmaParametreVm.GRUP_OPERASYON_KULLANIM_E_H = (byte?)(int?)GRUP_OPERASYON_KULLANIM_E_Hcbo.EditValue; 
            firmaParametreVm.MUHASEBE_CIKIS_ISKONTO_TAKIP_E_H = (byte?)(int?)MUHASEBE_CIKIS_ISKONTO_TAKIP_E_Hcbo.EditValue; 
            firmaParametreVm.MUHASEBE_GIRIS_ISKONTO_TAKIP_E_H = (byte?)(int?)MUHASEBE_GIRIS_ISKONTO_TAKIP_E_Hcbo.EditValue; 
            firmaParametreVm.MUHASEBE_ENTEGRASYON_CEK_FISTEN_E_H = (byte?)(int?)MUH_ENTEGRASYON_CEK_FISTEN_E_Hcbo.EditValue; 
            firmaParametreVm.SATIS_SIPARIS_BAKIYE_KONTROL_E_H = (byte?)(int?)SATIS_SIPARIS_BAKIYE_KONTROL_E_Hcbo.EditValue; 
            firmaParametreVm.MANUEL_SATIS_SIPARIS_GIRIS_E_H = (byte?)(int?)MANUEL_SATIS_SIPARIS_GIRIScbo.EditValue; 
            firmaParametreVm.STOK_SABIT_RAF_E_H = (byte?)(int?)STOK_SABIT_RAFcbo.EditValue;
            firmaParametreVm.SIPARIS_AMBALAJ_SEVK_E_H = (byte?)(int?)SIPARIS_AMBALAJ_SEVK_E_Hcbo.EditValue; 
            firmaParametreVm.MUHASEBE_ENTEGRASYON_UYARI_E_H = (byte?)(int?)MUHASEBE_ENTEGRASYON_UYARIcbo.EditValue; 
            firmaParametreVm.MUHASEBE_ENTEGRASYON_GIRIS_FISTEN_E_H = (byte?)(int?)MUHASEBE_ENTEGRASYON_GIRIS_FISTENcbo.EditValue; 
            firmaParametreVm.MUHASEBE_ENTEGRASYON_CIKIS_FISTEN_E_H = (byte?)(int?)MUHASEBE_ENTEGRASYON_CIKIS_FISTENcbo.EditValue; 
            firmaParametreVm.MUHASEBE_ENTEGRASYON_MAHSUP_FISTEN_E_H = (byte?)(int?)MUHASEBE_ENTEGRASYON_MAHSUP_FISTENcbo.EditValue; 
            firmaParametreVm.FIYAT_KONTROL_TIP_ID_PLAN = (byte?)(int?)FIYAT_KONTROL_TIP_ID_PLANcbo.EditValue; 
            firmaParametreVm.FIYAT_KONTROL_TIP_ID_SIPARIS = (byte?)(int?)FIYAT_KONTROL_TIP_ID_SIPARIScbo.EditValue;             
            firmaParametreVm.TOPLAM_IHTIYAC_BELIRLEME_GUN_SAYI =  TOPLAM_IHTIYAC_BELIRLEME_GUN_SAYItxt.Text !="" ? Convert.ToByte(TOPLAM_IHTIYAC_BELIRLEME_GUN_SAYItxt.Text): (byte?)(int?)null;
            firmaParametreVm.BARKOD_YAZICI_AG_YOLU = BARKOD_YAZICI_AG_YOLUtxt.Text;
            firmaParametreVm.LOGO_PATH = LOGO_PATHtxt.Text;
            firmaParametreVm.MUHASEBE_ENTEGRASYON_FIS_SATIR_SAYI = MUHASEBE_ENTEGRASYON_FIS_SATIR_SAYItxt.Text!="" ? Convert.ToInt32(MUHASEBE_ENTEGRASYON_FIS_SATIR_SAYItxt.Text): (int?)null;
            firmaParametreVm.HAMMADDE_MUHASEBE_HESAP_PLANI_ID = (int?)HAMMADDE_MUHASEBE_HESAP_PLANI_IDlke.EditValue;
            firmaParametreVm.TICARI_OLMAYAN_MUHASEBE_HESAP_PLANI_ID = (int?)TICARI_OLMAYAN_MUHASEBE_HESAP_PLANI_IDlke.EditValue;
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