using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;
namespace Prodma.SistemB2C.Models
{
    public class MesajVm : IViewModel
    {
        public int? MESAJ_TIP_ID { get; set; }
        public int? KIMDEN_KULLANICI_ID { get; set; }
        public int? KIME_KULLANICI_ID { get; set; }
        public string MESAJ { get; set; }
        public string MESAJ_2 { get; set; }
        public string MESAJ_3 { get; set; }
        public int? OKUNDU_E_H { get; set; }
        public int? LK_DURUM_ID { get; set; }
    }
}
