using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class messaging_customermessageVm : IViewModel
    {
        public int id { get; set; }
        public int customer_id { get; set; }
        public string topic { get; set; }
        public string message { get; set; }
        public int top_message_id { get; set; }
        public bool unread { get; set; }
        public DateTimeOffset time { get; set; }
        public int? staff_id { get; set; }
        public int? order_id { get; set; }
        public int? department_id { get; set; }
    }
}
