using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class discount_categoryVm : IViewModel
    {
        public int id { get; set; }
        public int discount_id { get; set; }
        public int category_id { get; set; }
    }
}
