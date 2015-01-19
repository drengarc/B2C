using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;
namespace Prodma.SistemB2C.Models
{
    public class KullaniciFirmaTipVm : IViewModel
    {
        
        public string AD { get; set; }
       
        public int LK_DURUM_ID { get; set; }
        
        public DateTime? INSERT_TAR { get; set; }
        public int? INSERT_KUL_ID { get; set; }
        public DateTime? UPDATE_TAR { get; set; }
        public int? UPDATE_KUL_ID { get; set; }
       
        
       
    }
}
