using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class shipment_alternativeVm : IViewModel
    {
        public int id { get; set; }
        public int package_id { get; set; }
        public int shipmentmethod_id { get; set; }
        public decimal? fixed_price { get; set; }
        public decimal? price_by_kg { get; set; }
    }
}
