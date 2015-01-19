﻿using System.Collections.Generic;
using Prodma.DataAccess;
using System;

namespace B2C.Models
{
    public class cms_menuattributeschemaVm : IViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public string help_text { get; set; }
        public string datatype { get; set; }
        public bool required { get; set; }
        public bool searched { get; set; }
        public bool filtered { get; set; }
        public bool sortable { get; set; }
    }
}
