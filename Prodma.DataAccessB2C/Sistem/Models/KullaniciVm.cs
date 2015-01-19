using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;
namespace Prodma.SistemB2C.Models
{
    public class KullaniciVm : IViewModel
    {
        public int FIRMA_ID { get; set; }
        public string KULLANICI_AD { get; set; }
        public string SIFRE { get; set; }
        public string AD { get; set; }
        public string SOYAD { get; set; }
        public string MAIL { get; set; }
        public string FOTO { get; set; }
        public string LOCAL_PATH { get; set; }
        public int? ROL_ID { get; set; }
        public int? DIL_ID { get; set; }
        public int LK_DURUM_ID { get; set; }
        public byte? FIRMA_DISI_E_H { get; set; }
        public decimal? FIRMA_DISI_MAX_ISK_YUZ { get; set; }
        public int? SARF_AMBAR_ID { get; set; }
        public byte? ILERI_FIS_GIRIS_E_H { get; set; }
        public byte? GERI_FIS_GIRIS_E_H { get; set; }
        public byte? BAYI_SIPARIS_ONAY_E_H { get; set; }
        public decimal? EK_ISK_YUZ { get; set; }
        public int? CARI_PLASIYER_ID { get; set; }
        public int? CARI_SATIS_ELEMANI_ID { get; set; }
        public int? CARI_AGENT_ID { get; set; }
        public string AGENT_SIFRE { get; set; }
        public byte? BARKOD_KULLANICI_E_H { get; set; }
        public int? TEKLIF_TIP_ID { get; set; }
        public int? SIPARIS_TIP_ID { get; set; }
        public byte? KULLANICI_ALANLAR_OZEL_E_H { get; set; }
        public byte? CARI_GOZLEM_AC_E_H { get; set; }
        public int? UST_KULLANICI_ID { get; set; }
        public string ESKI_KULLANICI_KOD  { get; set; }
        public KullaniciYetkileriVm KULLANICI_YETKILERI { get; set; }
        public DateTime? INSERT_TAR { get; set; }
        public int? INSERT_KUL_ID { get; set; }
        public DateTime? UPDATE_TAR { get; set; }
        public int? UPDATE_KUL_ID { get; set; }
        public int KULLANICI_FIRMA_TIP_ID { get; set; }
        
       
    }
}
