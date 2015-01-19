using System.Collections.Generic;
using Prodma.DataAccessB2C;
namespace Prodma.SistemB2C.Models
{
    public class YetkiIslemTanitimVm : IViewModel
    {
        public int? YETKI_ISLEM_SAHIBI_TANITIM_ID { get; set; }
        public string KOD { get; set; }
        public string AD { get; set; }
        public string TAG_NAME { get; set; }
        public string HINT_NAME { get; set; }
        public string IMAGE_NAME { get; set; }
        public int? YETKI_ISLEM_SAHIBI_TIP_ID { get; set; }
        public int? LK_DURUM_ID { get; set; }
    }
}
