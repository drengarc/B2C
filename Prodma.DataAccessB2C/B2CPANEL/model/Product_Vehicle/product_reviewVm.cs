using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class product_reviewVm : IViewModel
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public int user_id { get; set; }
        public short? rating { get; set; }
        public DateTimeOffset? date_added { get; set; }
        public int status { get; set; }
        public int language_id { get; set; }
        public string text { get; set; }
    }
}
