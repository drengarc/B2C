using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class ege_integration_productcompetitorrelationVm : IViewModel
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public string competitor_product_code { get; set; }
        public string competitor_manufacturer_id { get; set; }
    }
}
