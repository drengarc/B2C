using System.Collections.Generic;
using Prodma.DataAccessB2C;
namespace Prodma.SistemB2C.Models
{
    public class YetkiIslemSahibiTanitimVm : IViewModel
    {
        public string KOD { get; set; }
        public string AD { get; set; }
        public int YETKI_ISLEM_SAHIBI_TIP_ID { get; set; }
    }
}
