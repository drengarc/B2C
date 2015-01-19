using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class product_originalVm : IViewModel
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public string oem_no { get; set; }
        public string oem_no_original { get; set; }
        public int brand_id { get; set; }
    }
}
