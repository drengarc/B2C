using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class shipment_methodVm : IViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool is_active { get; set; }
        public string image { get; set; }
    }
}
