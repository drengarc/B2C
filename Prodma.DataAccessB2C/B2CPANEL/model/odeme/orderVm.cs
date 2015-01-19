using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class orderVm : IViewModel
    {
        public int id { get; set; }
        public DateTimeOffset? date_processed { get; set; }
        public string receipt_id { get; set; }
        public int customer_id { get; set; }
        public decimal discount { get; set; }
        public string delivery_name { get; set; }
        public string delivery_address { get; set; }
        public int delivery_city_id { get; set; }
        public string delivery_phone { get; set; }
        public string billing_name { get; set; }
        public string billing_address { get; set; }
        public int? billing_city_id { get; set; }
        public string billing_phone { get; set; }
        public string cc_owner { get; set; }
        public string cc_number_last { get; set; }
        public decimal final_price { get; set; }
        public decimal final_kdv { get; set; }
        public decimal shipment_price { get; set; }
        public int shipment_alternative_id { get; set; }
        public string comment { get; set; }
        public string cargo_no { get; set; }
        public short payment_type { get; set; }
    }
}
