using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;
namespace Prodma.SistemB2C.Models
{
    public class YetkiMenulerVm : IViewModel
    {
        public int KULLANICI_ID { get; set; }
        public int? M_MENU_UST_ID { get; set; }
        public int M_MENU_ID { get; set; }
        public int? OKU_E_H { get; set; }
        public int? YAZ_E_H { get; set; }
        public int? GUNCELLE_E_H { get; set; }
        public int? SIL_E_H { get; set; }
        public int? GORMESIN_E_H { get; set; }
        public int? LK_DURUM_ID { get; set; }
      
    }
}
