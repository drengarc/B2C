using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class admin_tools_dashboard_preferencesVm : IViewModel
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string data { get; set; }
        public string dashboard_id { get; set; }
    }
}
