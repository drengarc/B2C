using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class est_transactionVm : IViewModel
    {
        public int id { get; set; }
        public DateTimeOffset date { get; set; }
        public int ip { get; set; }
        public Int16 type { get; set; }
        public int customer_id { get; set; }
        public string order_id { get; set; }
        public int? est_id { get; set; }
        public decimal amount { get; set; }
        public string error_message { get; set; }
    }
}
