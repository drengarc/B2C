using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class order_statusVm : IViewModel
    {
        public int id { get; set; }
        public DateTimeOffset time { get; set; }
        public int order_id { get; set; }
        public int order_status_type_id { get; set; }
        public string comments { get; set; }
        public int? order_product_id { get; set; }

    }
}
