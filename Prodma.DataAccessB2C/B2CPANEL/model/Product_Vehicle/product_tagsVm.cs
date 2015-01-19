using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class product_tagsVm : IViewModel
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public int producttag_id { get; set; }
    }
}
