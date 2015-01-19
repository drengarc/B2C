using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class simit_menuVm : IViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public int? parent_id { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public int?  page_id { get; set; }
        public string url_name { get; set; }
        public int section_id { get; set; }
        public bool is_active { get; set; }
        public int lft { get; set; }
        public int rght { get; set; }
        public int tree_id { get; set; }
        public int level { get; set; }
    }
}
