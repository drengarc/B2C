using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class module_pricedropalert_emailVm : IViewModel
    {
        public int id { get; set; }
        public DateTimeOffset saved_time { get; set; }
        public string email { get; set; }
        public int product_id { get; set; }
        public decimal checkpoint_price { get; set; }
    }
}
