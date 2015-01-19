using System.Collections.Generic;
using Prodma.DataAccess;
using System;

namespace IsGuvenligi.Models
{
    public class TalimatlarList : IViewModel
    {
        public string BASLIK { get; set; }
        public string ACIKLAMA { get; set; }
        public string TEHLIKE { get; set; }
        public string ONLEM { get; set; }
        public string PERSONEL { get; set; }
        public string GOREV { get; set; }
    }
}
