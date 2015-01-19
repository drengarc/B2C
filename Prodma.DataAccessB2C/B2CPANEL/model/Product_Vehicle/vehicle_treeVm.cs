using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class vehicle_treeVm : IViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string slug { get; set; }
        public int? marka_id { get; set; }
        public int? model_id { get; set; }
        public int? parent_id { get; set; }
        public string description { get; set; }
        public int lft { get; set; }
        public int rght { get; set; }
        public int tree_id { get; set; }
        public short level { get; set; }
    }
}
