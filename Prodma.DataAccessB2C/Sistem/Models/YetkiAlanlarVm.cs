using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;
namespace Prodma.SistemB2C.Models
{
    public class YetkiAlanlarVm : IViewModel
    {
        public int KULLANICI_ID { get; set; }
        public int M_ALANLAR_UST_ID { get; set; }
        public int M_ALANLAR_ID { get; set; }
        public int? M_ALANLAR_ALT_ID { get; set; }
        public int? GORMESIN_E_H { get; set; }
        public int? YAZMASIN_E_H { get; set; }
        public int LK_DURUM_ID { get; set; }
        public DateTime? INSERT_TAR { get; set; }
        public int? INSERT_KUL_ID { get; set; }
        public DateTime? UPDATE_TAR { get; set; }
        public int? UPDATE_KUL_ID { get; set; }
    }
}
