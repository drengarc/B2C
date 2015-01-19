using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class product_variation_optionVm : IViewModel
    {
        public int id { get; set; }
        public int product_variation_id { get; set; }
        public int variation_id { get; set; }
        public string value { get; set; }
    }
}
