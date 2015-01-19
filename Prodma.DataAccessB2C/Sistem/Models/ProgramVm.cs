using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;
namespace Prodma.SistemB2C.Models
{
    public class ProgramVm : IViewModel
    {
        public int PROGRAM_ID    { get; set; }
        public int KULLANICI_ID { get; set; }
        public string BILGISYAR { get; set; }
        public string PROGRAM_ADI { get; set; }
        public DateTime TARIH { get; set; }
        public decimal CALISMA_SURESI { get; set; }
        public int LK_DURUM_ID { get; set; }
    }
}
