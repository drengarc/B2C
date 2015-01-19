using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;
namespace Prodma.SistemB2C.Models
{
    public class FirmaParametreVm : IViewModel
    {
        public int FIRMA_ID { get; set; }
        public byte? BARKOD_KULLANIM_E_H { get; set; }
        public string MUHASEBE_KIRILMA { get; set; }
        public string STOK_KIRILMA { get; set; }
        public string CARI_HESAP_KIRILMA { get; set; }
        public string MASRAF_YERI_KIRILMA { get; set; }
        public string BUTCE_KIRILMA { get; set; }
        public string URETIM_YERI_KIRILMA { get; set; }
        public byte? MUHASEBE_KAPALI_AY { get; set; }
        public int? MUHASEBE_KAPALI_YIL { get; set; }
        public byte? DIGER_KAPALI_AY { get; set; }
        public int? DIGER_KAPALI_YIL { get; set; }
        public int? GENEL_KDV_YUZDE_ID { get; set; }
        public byte? SATIS_FIYAT_AYRIM_KONTROL_E_H { get; set; }
        public byte? ALIS_FIYAT_AYRIM_KONTROL_E_H { get; set; }
        public int? SATIS_DOVIZ_KUR_TIP { get; set; }
        public int? ALIS_DOVIZ_KUR_TIP { get; set; }
        public byte? PLASIYER_E_H { get; set; }
        public byte? IRSALIYELI_FATURA_E_H { get; set; }
        public byte? FATURA_CARI_HESAP_VERGI_NO_KONTROL_E_H { get; set; }
        public int? STOK_MALIYET_TIP_ID { get; set; }
        public int? STOK_MIKTAR_KONTROL_TIP_ID { get; set; }
        public byte? IRSALIYE_FATURA_GUN_KONTROL_SAYISI { get; set; }
        
        public DateTime? IRSALIYE_KOCAN_DEGISIM_TARIH { get; set; }
        public string IRSALIYE_KOCAN_SERI_NUMARASI { get; set; }
        public DateTime? FATURA_KOCAN_DEGISIM_TARIH { get; set; }
        public string FATURA_KOCAN_SERI_NUMARASI { get; set; }
        public byte? FATURA_KDV_YUZDE_KONTROL_E_H { get; set; }
        public byte? IRSALIYE_DOKUM_STOK_BIRLESTIR_E_H { get; set; }
        public byte? FATURA_DOKUM_STOK_BIRLESTIR_E_H { get; set; }

        public byte? GRUP_OPERASYON_KULLANIM_E_H { get; set; }
        public byte? MUHASEBE_CIKIS_ISKONTO_TAKIP_E_H { get; set; }
        public byte? MUHASEBE_GIRIS_ISKONTO_TAKIP_E_H { get; set; }
        public byte? MANUEL_SATIS_SIPARIS_GIRIS_E_H { get; set; }
        public int? FIYAT_KONTROL_TIP_ID_PLAN { get; set; }
        public int? FIYAT_KONTROL_TIP_ID_SIPARIS { get; set; }
        public byte? STOK_SABIT_RAF_E_H { get; set; }
        public byte? MUHASEBE_ENTEGRASYON_UYARI_E_H { get; set; }
        public byte? MUHASEBE_ENTEGRASYON_GIRIS_FISTEN_E_H { get; set; }
        public byte? MUHASEBE_ENTEGRASYON_CIKIS_FISTEN_E_H { get; set; }
        public byte? MUHASEBE_ENTEGRASYON_MAHSUP_FISTEN_E_H { get; set; }
        public byte? MUHASEBE_ENTEGRASYON_CEK_FISTEN_E_H { get; set; }

        public int? MUHASEBE_ENTEGRASYON_FIS_SATIR_SAYI { get; set; }
        public byte? SATIS_SIPARIS_BAKIYE_KONTROL_E_H { get; set; }
        public byte? TOPLAM_IHTIYAC_BELIRLEME_GUN_SAYI { get; set; }
        public string BARKOD_YAZICI_AG_YOLU { get; set; }
        public string LOGO_PATH { get; set; }

        public byte? URETIM_SARF_MASRAF_YERI_E_H { get; set; }
        public byte? SIPARIS_AMBALAJ_SEVK_E_H { get; set; }
        public byte? MUSTERI_PLASIYER_E_H { get; set; }

        public int? HAMMADDE_MUHASEBE_HESAP_PLANI_ID { get; set; }
        public int? TICARI_OLMAYAN_MUHASEBE_HESAP_PLANI_ID { get; set; }

        public DateTime? INSERT_TAR { get; set; }
        public int? INSERT_KUL_ID { get; set; }
        public DateTime? UPDATE_TAR { get; set; }
        public int? UPDATE_KUL_ID { get; set; }

        public string FIRMA_ADI { get; set; }

        public byte? ITHALAT_STOKU_DOSYA_HESABINA_ENTEGRE_OLSUN_E_H { get; set; }
     
    }
}
