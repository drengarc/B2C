using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class est_installmentalternativeVm : IViewModel
    {
        public int id { get; set; }
        public int package_id { get; set; }
        public int bank_id { get; set; }
        public decimal? discount_percentage { get; set; }
        public int? discount_amount { get; set; }
        public short installment { get; set; }
        public decimal? minimum_price { get; set; }
        public decimal? maximum_price { get; set; }
        public string description { get; set; }
    }
}
