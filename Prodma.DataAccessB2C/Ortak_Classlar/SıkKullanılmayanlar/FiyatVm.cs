using System.Collections.Generic;
using Prodma.DataAccess;
using System;

namespace Prodma.DataAccess
{
    public class FiyatVm : IViewModel
    {
        public int? STOK_ID { get; set; } 
        public int? DOVIZ_ID { get; set; }
        public Decimal? FIYAT { get; set; }
        public Decimal? FIYAT_2 { get; set; }
        public decimal? DOVIZ_FIYAT { get; set; }
        public decimal? MIKTAR { get; set; }
        public int? KDV_YUZDE_ID { get; set; }
        public decimal? KUR { get; set; }
        public int? FIYAT_SATIS_TIP_ID { get; set; }
        public decimal? ISKONTO { get; set; }
        public decimal? KULLANICI_EK_ISKONTO { get; set; }
        public string DONUS_MESAJ { get; set; } // iade giris ve iade cıkış icin mesaj iceriyor.
        public int? KAMPANYA_ISKONTO_YUZDE_KULLAN_E_H { get; set; }
    }
}
