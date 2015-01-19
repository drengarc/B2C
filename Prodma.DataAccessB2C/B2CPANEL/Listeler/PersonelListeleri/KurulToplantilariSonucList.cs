using System.Collections.Generic;
using Prodma.DataAccess;
using System;

namespace IsGuvenligi.Models
{
    public class KurulToplantilariSonucList : IViewModel
    {
        public string KONU { get; set; }
        public string KONU_DEGERLENDIRME { get; set; }
        public string SORUMLULAR { get; set; }
        public DateTime? BASLANGIC_TARIH { get; set; }
        public DateTime? BITIS_TARIH { get; set; }
        public List<KurulUyeleri> KURULUYELERI { get; set; }
        public List<KurulGundemi> KURULGUNDEMI { get; set; }
        public List<KurulToplantilariVm> KURULTOPLANTISI { get; set; }
    }

    public class KurulUyeleri : IViewModel
    {
        public string ADI_SOYADI { get; set; }
        public string GOREVI { get; set; }
        public string IMZA { get; set; }
    }
    public class KurulGundemi : IViewModel
    {
        public string ACIKLAMA { get; set; }
    }
}
