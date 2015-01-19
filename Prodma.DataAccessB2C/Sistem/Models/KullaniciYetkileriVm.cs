using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;
namespace Prodma.SistemB2C.Models
{
    public class KullaniciYetkileriVm : IViewModel
    {
        public int KULLANICI_ID { get; set; }
        public int KULLANICI_YETKI_TIP_ID { get; set; }
        public int?  FIS_SON_GUN { get; set; }
        public int? FIS_KENDISININ_E_H { get; set; }
        public int? FIS_SIRALAMA_TARIH_ARTAN_E_H { get; set; }
        public int? LK_GIRIS_CIKIS_ID { get; set; }
        public int? KULLANICI_VARSAYILAN_AMBAR_ID { get; set; }
        public string KULLANICI_VARSAYILAN_AMBAR_KOD { get; set; }
        public int CARI_GOZLEM_AC_E_H { get; set; }
        public int IRSALIYE_ACILIS_UYARI_E_H { get; set; }
        public int FATURALANMAMIS_IRSALIYE_GOSTER_E_H { get; set; }
        public int SIPARIS_BAKIYE_KONTROL_E_H { get; set; }
        public int ALIS_FIYAT_GOR_E_H { get; set; }
        public int SATIS_FIYAT_GOR_E_H { get; set; }
        public int SIGORTA_KULLANICISI_E_H { get; set; }
        public int ALT_KULLANICI_ISLEM_YAP_E_H { get; set; }
        public int TEKLIF_FIYAT_DEGISTIR_E_H { get; set; }
        public int SIPARIS_FIYAT_DEGISTIR_E_H { get; set; }
        public int IRSALIYE_FIYAT_DEGISTIR_E_H { get; set; }
        public int SIPARIS_TESLIM_TARIHI_UYARISI_E_H { get; set; }
        public int FIS_GOSTERIM_SINIRLA_E_H { get; set; }
        public int CEK_MUHASEBE_ENTEGRASYON_E_H { get; set; }
        public int MAHSUP_MUHASEBE_ENTEGRASYON_E_H { get; set; }
        public int FATURA_MUHASEBE_ENTEGRASYON_E_H { get; set; }
        public int INTERNET_SIPARISLERI_E_H { get; set; }
        public int PLASIYER_KULLANICI_E_H { get; set; }
        public int TEKLIF_MUSTERI_OZEL_FIYAT_DEGISTIR_E_H { get; set; }
        public int MUSTERI_OZEL_FIYAT_OLUSTUR_E_H { get; set; }
        public DateTime? INSERT_TAR { get; set; }
        public int? INSERT_KUL_ID { get; set; }
        public DateTime? UPDATE_TAR { get; set; }
        public int? UPDATE_KUL_ID { get; set; }
        
        
       
    }
}
