using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class customer_addressVm : IViewModel
    {
        public int id { get; set; }
        public int customer_id { get; set; }
        public string address_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string address { get; set; }
        public int? postcode { get; set; }
        public string land_line { get; set; }
        public string cell_phone { get; set; }
        public int? ilce_id { get; set; }
        public int country_id { get; set; }
        public string identity_number { get; set; }
        public string tax_authority { get; set; }
        public string tax_no { get; set; }
    }
}
