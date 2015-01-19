using System.Collections.Generic;
using System;
using System.Windows.Forms;

namespace Prodma.DataAccessB2C
{
    public class KontrolVm : IViewModel
    {
        public int DONUS_TIP { get; set; }
        public string DONUS_MESAJ { get; set; }
        public string DONUS_MESAJ_TIP { get; set; }
        public int? DONUS_INT_DEGER { get; set; }
        public Control FOCUS { get; set; }
        public string DONUS_METOD_DEGER { get; set; }
        public decimal? DONUS_DECIMAL_DEGER { get; set; }
        public List<KodAdVm> KodAdList { get; set; }
        public object GERI_DONUS_LIST { get; set; }
        public int ISLEM_YAPILAN_KAYIT_SAYISI { get; set; }

    }
    public class LogIlkVm
    {
        public string Message { get; set; }
        public string Level { get; set; }
        public string Kullanici { get; set; }
        public string Tablo { get; set; }
        public DateTimeOffset? Date { get; set; }
        public int id { get; set; }
    }
}
