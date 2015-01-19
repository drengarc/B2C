using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class product_vehicleVm : IViewModel
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public int vehicle_id { get; set; }
    }
}
