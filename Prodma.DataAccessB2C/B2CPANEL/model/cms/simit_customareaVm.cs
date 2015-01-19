using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class simit_customareaVm : IViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string value { get; set; }
        public int type { get; set; }
        public int category_id { get; set; }
        public string extra { get; set; }
        public string description { get; set; }
    }
}
