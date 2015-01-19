using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class firm_parameterVm : IViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool redirect_to_basket { get; set; }
        public decimal min_price_for_cargo { get; set; }
    }
}
