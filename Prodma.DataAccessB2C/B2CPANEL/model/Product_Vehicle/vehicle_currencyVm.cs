using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class vehicle_currencyVm : IViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string symbol { get; set; }
        public decimal parity { get; set; }
    }
}
