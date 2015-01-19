using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class discount_product_tagVm : IViewModel
    {
        public int id { get; set; }
        public int discount_id { get; set; }
        public int producttag_id { get; set; }
    }
}
