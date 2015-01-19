using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;
namespace Prodma.SistemB2C.Models
{
    public class FirmaVm : IViewModel
    {
        public int ID { get; set; }
        public int FIRMA_ID { get; set; }
        public string AD { get; set; }
        public string ADR1 { get; set; }
        public string ADR2 { get; set; }
        public string ADR3 { get; set; }
        public string VERGI_DAIRE { get; set; }
        public string VERGI_NO { get; set; }
        public string TEL { get; set; }
        public string FAX { get; set; }
        public string MAIL { get; set; }
        public string WEB_ADRES { get; set; }
        public int? FIRMA_TIP_ID { get; set; }
        public int? FIRMA_TEHLIKE_TIP_ID { get; set; }
        public int? ASIL_FIRMA_ID { get; set; }
        public string ESKI_KOD { get; set; }
        public int LK_DURUM_ID { get; set; }
        public string LOGO_PATH { get; set; }
        public string RESIM_PATH { get; set; }
        public string GUNCELLEME_PATH { get; set; }
        public string RAPOR_PATH { get; set; }
        public int? DESTEK_ELEMAN_SAYISI { get; set; }
        public int? ACIL_DURUM_YENILEME_PERIYOD { get; set; }
        public int? YILLIK_EGITIM_YENILEME_PERIYOD { get; set; }
        public int? PERIYODIK_EGITIM_DAKIKA { get; set; }
        public string ARSIV_PATH { get; set; }
       
    }
}
