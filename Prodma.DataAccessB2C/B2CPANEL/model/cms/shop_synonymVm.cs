using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class shop_synonymVm : IViewModel
    {
        public int id { get; set; }
        public string from_text { get; set; }
        public string to_text { get; set; }
    }
}
