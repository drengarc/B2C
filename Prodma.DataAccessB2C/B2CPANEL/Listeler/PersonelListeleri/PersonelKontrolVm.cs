using System.Collections.Generic;
using Prodma.DataAccess;
using System;

namespace IsGuvenligi.Listeler.PersonelListeleri.Models
{
    public class PersonelKontrolVm : ListViewModelListe
    {
        public string AD { get; set; }
        public string SOYAD { get; set; }
        public string TC_NO { get; set; }
        public int? EGITIM_SAAT { get; set; }
        public int TOPLAM_SAAT { get; set; }
        public int GEREKEN_SAAT { get; set; }
    }
 
}
