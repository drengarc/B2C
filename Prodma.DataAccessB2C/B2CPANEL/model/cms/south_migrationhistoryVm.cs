using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class south_migrationhistoryVm : IViewModel
    {
        public int id { get; set; }
        public string app_name { get; set; }
        public string migration { get; set; }
        public DateTimeOffset applied { get; set; }
    }
}
