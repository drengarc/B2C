using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class productVm : IViewModel
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public string name { get; set; }
        public int category_id { get; set; }
        public decimal price { get; set; }
        public DateTimeOffset date_added { get; set; }
        public decimal? discount_price { get; set; }
        public decimal? cargo_price { get; set; }
        public DateTimeOffset last_modified { get; set; }
        public bool active { get; set; }
        public int manufacturer_id { get; set; }
        public string description { get; set; }
        public string fulltext { get; set; }
        public string attr { get; set; }
        public bool sync_ege { get; set; }
        public short minimum_order_amount { get; set; }
        public int grup_id { get; set; }
        public int? toptanci_id { get; set; }
        public int kdv { get; set; }
        public decimal? volume { get; set; }
        public decimal? weight { get; set; }
        public string partner_code { get; set; }
    }
}
