using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class ege_integration_activitylogVm : IViewModel
    {
        public int id { get; set; }
        public string event1 { get; set; }
        public string level { get; set; }
        public string message { get; set; }
        public DateTimeOffset? timestamp { get; set; }
    }
}
