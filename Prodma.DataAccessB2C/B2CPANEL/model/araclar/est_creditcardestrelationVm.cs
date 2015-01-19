using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class est_creditcardestrelationVm : IViewModel
    {
        public int id { get; set; }
        public int bin_id { get; set; }
        public int est_cash_id { get; set; }
        public int est_installment_id { get; set; }
    }
}
