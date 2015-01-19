using System.Collections.Generic;
using Prodma.DataAccessB2C;

namespace Prodma.Sistem.Models
{
    public class FiltrelerVm : IViewModel
    {
        public int KULLANICI_ID { get; set; }
        public string FORM_ADI { get; set; }
        public string RAPOR_ADI { get; set; }
        public string DEGER_ALANI { get; set; }
        public int LK_DURUM_ID { get; set; }
        public int FILTRE_OLUSTURAN_KULLANICI_ID { get; set; }
        public int FILTRE_TIP_ID { get; set; }
    }
}
