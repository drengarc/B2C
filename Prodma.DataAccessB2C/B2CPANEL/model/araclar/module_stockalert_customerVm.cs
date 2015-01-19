using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class module_stockalert_customerVm : IViewModel
    {
        public int id { get; set; }
        public DateTimeOffset saved_time { get; set; }
        public int customer_id { get; set; }
        public int product_id { get; set; }
    }
}
