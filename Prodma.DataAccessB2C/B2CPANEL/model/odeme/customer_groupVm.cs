﻿using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class customer_groupVm : IViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
