using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class django_admin_logVm : IViewModel
    {
        public int id { get; set; }
        public DateTimeOffset action_time { get; set; }
        public int user_id { get; set; }
        public int? content_type_id { get; set; }
        public string object_id { get; set; }
        public string object_repr { get; set; }
        public short action_flag { get; set; }
        public string change_message { get; set; }
    }
}
