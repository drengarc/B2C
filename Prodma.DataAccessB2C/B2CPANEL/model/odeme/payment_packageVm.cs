using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class payment_packageVm : IViewModel
    {
        public int id { get; set; }
        public decimal? money_order_amount { get; set; }
        public int? money_order_percentage { get; set; }
        public string name { get; set; }
    }
}
