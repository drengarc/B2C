using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class newsletterVm : IViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTimeOffset date_added { get; set; }
        public DateTimeOffset? date_sent { get; set; }
        public bool is_active { get; set; }
        public int language_id { get; set; }
    }
}
