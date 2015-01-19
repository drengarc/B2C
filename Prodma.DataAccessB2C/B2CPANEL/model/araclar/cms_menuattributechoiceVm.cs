using System.Collections.Generic;
using Prodma.DataAccess;
using System;

namespace B2C.Models
{
    public class cms_menuattributechoiceVm : IViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public int schema_id { get; set; }
    }
}
