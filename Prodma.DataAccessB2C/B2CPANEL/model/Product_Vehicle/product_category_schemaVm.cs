using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class product_category_schemaVm : IViewModel
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
        public int category_id { get; set; }
    }
}
