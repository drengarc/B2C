﻿using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class product_category_choiceVm : IViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public int schema_id { get; set; }
    }
}
