using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class tax_rateVm : IViewModel
    {
        public int id { get; set; }
        public int category_id { get; set; }
        public decimal tax_rate { get; set; }
        public DateTimeOffset date_added { get; set; }
    }
}
