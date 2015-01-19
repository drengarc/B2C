using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class vehicleVm : IViewModel
    {
        public int id { get; set; }
        public int brand_id { get; set; }
        public int model_id { get; set; }
        public int model_type_id { get; set; }
        public int motor_type_id { get; set; }
        public int fuel_type_id { get; set; }
        public int begin_year { get; set; }
        public int? end_year { get; set; }
        public string fulltext { get; set; }
        public int? grup_id { get; set; }
    }
}
