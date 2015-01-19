using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class product_pageVm : IViewModel
    {
        public int product_id { get; set; }
        public string page_title { get; set; }
        public string page_description { get; set; }
        public string keywords { get; set; }
    }
}
