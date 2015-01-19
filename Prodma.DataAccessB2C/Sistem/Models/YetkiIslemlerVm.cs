using System.Collections.Generic;
using Prodma.DataAccessB2C;
namespace Prodma.SistemB2C.Models
{
    public class YetkiIslemlerVm : IViewModel
    {
        public int KULLANICI_ID { get; set; }
        public int YETKI_ISLEM_TANTIM_ID { get; set; }
        public int YETKILI_E_H { get; set; }
        public int? SINIRLI_YETKI_E_H { get; set; }

        public YetkiIslemTanitimVm YETKIISLEMTANITIM {get;set;}
        public string YETKILI_ISLEM_SAHIBI_AD { get; set; }
    }
}
