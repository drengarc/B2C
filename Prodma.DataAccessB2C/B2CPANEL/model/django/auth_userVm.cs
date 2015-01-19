using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class auth_userVm : IViewModel
    {
        public int id { get; set; }
        public string password { get; set; }
        public DateTimeOffset last_login { get; set; }
        public bool is_superuser { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public bool is_staff { get; set; }
        public bool is_active { get; set; }
        public DateTimeOffset date_joined { get; set; }
        public short? gender { get; set; }
        public int? default_shipment_address_id { get; set; }
        public int? default_invoice_address_id { get; set; }
        public string phone { get; set; }
        public int? group_id { get; set; }
    }
}
