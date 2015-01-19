using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class customer_basketVm : IViewModel
    {
        public int id { get; set; }
        public int customer_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
        public productVm STOK { get; set; }
        public DateTimeOffset date_added { get; set; }
    }
}
