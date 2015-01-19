using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class shop_configVm : IViewModel
    {
        public int id { get; set; }
        public string key { get; set; }
        public string value { get; set; }
    }
}
