using System.Collections.Generic;
using Prodma.DataAccessB2C;

namespace Prodma.DataAccessB2C
{
    public class ExcelAktarmaRowVm : IViewModel
    {
        public int? ID { get; set; }
        public string EXCEL_ALANLAR { get; set; }
        public int? TABLO_ALAN_ID { get; set; }
        public int? ALAN_TIP_ID { get; set; }
        public int? ALAN_DATA_TIP_ID { get; set; }
        public int? UZERINE_YAZMA_DURUM_TIP_ID { get; set; }
        public byte? IKINCI_TABLO_E_H { get; set; }
        public byte? ANAHTAR_ALAN { get; set; }
    }
}
