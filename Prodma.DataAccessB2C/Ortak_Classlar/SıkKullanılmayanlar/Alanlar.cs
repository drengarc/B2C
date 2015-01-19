using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prodma.DataAccessB2C
{
    public class Alanlar : IViewModel
    {
        public int? M_ALANLAR_ID { get; set; }
        public string ALAN_AD { get; set; }
        public string ALAN_LISTE_AD { get; set; }
        public int? ALAN_LISTE_GENISLIK { get; set; }
        public string ALAN_UZUNLUK { get; set; }
        public string ALAN_DECIMAL { get; set; }
        public string M_ALAN_CLASS_NAME { get; set; }
        public int? ALAN_SIRA { get; set; }
        public int? M_ALAN_TIP_ID { get; set; }
        public int? M_ALAN_TIP_2 { get; set; }
        public int? M_ALAN_GOSTERILEN_ID { get; set; }
        public int? M_TABLO_TIP_ID { get; set; }
        public int? LK_DURUM_ID { get; set; }
        public int? M_ALAN_ALT_BILGI { get; set; }
        public int? M_ALANLAR_ALT_ID { get; set; }
        public int? GORMESIN_E_H { get; set; }
        public int? YAZMASIN_E_H { get; set; }
        public int? M_ALAN_KOPYALAMA_E_H { get; set; }
        public int? KULLANICI_ID { get; set; }
        public int? YETKI_KULLANICI_ID { get; set; }


        public int? KIRLIM_TIP_ID { get; set; }
        public int? M_ALAN_ARAMA_TIP_ID { get; set; }
    }
}
