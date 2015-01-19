using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class discountVm : IViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int? percentage { get; set; }
        public decimal? amount { get; set; }
        public DateTimeOffset date_added { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public bool is_active { get; set; }
        public decimal? minimum_order_price { get; set; }
    }
}
