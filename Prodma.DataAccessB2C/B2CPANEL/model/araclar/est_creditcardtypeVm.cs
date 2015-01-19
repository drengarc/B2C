using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class est_creditcardtypeVm : IViewModel
    {
        public int bank_id { get; set; }
        public string image { get; set; }
        public int bin { get; set; }
        public string type { get; set; }
        public string subtype { get; set; }
    }
}
