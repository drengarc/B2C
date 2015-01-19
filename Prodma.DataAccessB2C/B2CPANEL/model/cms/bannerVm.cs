using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class bannerVm : IViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public int language_id { get; set; }
        public string image { get; set; }
        public string html_text { get; set; }
        public DateTimeOffset? end_date { get; set; }
        public DateTimeOffset? start_date { get; set; }
        public DateTimeOffset date_added { get; set; }
        public bool is_active { get; set; }
        public int area_id { get; set; }
    }
}
