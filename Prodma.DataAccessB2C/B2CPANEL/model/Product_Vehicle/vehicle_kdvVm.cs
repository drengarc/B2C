﻿using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class vehicle_kdvVm : IViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal value { get; set; }
    }
}
