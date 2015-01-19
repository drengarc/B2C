using System.Collections.Generic;
using Prodma.DataAccess;
using System;

namespace IsGuvenligi.Listeler.PersonelListeleri.Models
{
    public class PersonelListVm : IViewModel
    {
        public int ID { get; set; }
        public int PERSONEL_ID { get; set; }
        public string TC_KIMLIK_NO { get; set; }
        public string ADI { get; set; }
        public string SOYADI { get; set; }
        public string SICIL_NO { get; set; }
        public string TELEFON { get; set; }
        public string RESIM_URL { get; set; }
        public DateTime? ISE_GIRIS_TARIH { get; set; }
        public DateTime? DOGUM_TARIH { get; set; }
        public int? ONCEKI_YIL_PUAN { get; set; }
        public int? YIL_PUAN { get; set; }
        public decimal? PUAN_TL_KARSILIGI { get; set; }
        public int? ISTIHDAM_TIPI_TANITIM_ID { get; set; }
        public int? UNVAN_TANITIM_ID { get; set; }
        public int? MESLEK_SIGORTA_TANITIM_ID { get; set; }
        public int? MASRAF_YERI_TANITIM_ID { get; set; }
        public int? ENGELLI_GRUP_TANITIM_ID { get; set; }
        public int? SENDIKA_TANITIM_ID { get; set; }
        public int? BAKANLIK_GOREV_TANITIM_ID { get; set; }
        public int? OGRENIM_TANITIM_ID { get; set; }
        public int? FIRMA_ID { get; set; }
        public int? LK_DURUM_ID { get; set; }
    }
 
}
