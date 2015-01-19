using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class vehicle_motor_typeVm : IViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
    }
}
