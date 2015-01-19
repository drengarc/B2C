using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class order_productVm : IViewModel
    {
        public int id { get; set; }
        public int order_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public decimal discount { get; set; }
        public string sase_code { get; set; }
        public int? vehicle_toptanci_id { get; set; }
        public productVm STOK { get; set; }
        public orderVm SIFIRLI { get; set; }
        public string product_code { get; set; }
        public string product_name { get; set; }
        public int? order_status_id { get; set; }
    }

    public class SepetGosterimV1m : IViewModel
    {
        public int id { get; set; }
        public int order_id { get; set; }
        public string order { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public decimal discount { get; set; }
        public int? vehicle_toptanci_id { get; set; }
        public decimal? siparis_miktar { get; set; }
        public decimal? onaylanan_miktar { get; set; }
        public string product_code { get; set; }
        public string product_name { get; set; }
        public string tedarikci { get; set; }
        public int? order_status_id { get; set; }
        public int? order_status_type_id { get; set; }
        public double? ambar_miktar { get; set; }
        public decimal? ALIS_FIYAT { get; set; }
        public decimal? SATIS_FIYAT { get; set; }
        public int? order_product_id { get; set; }
        public string delivery_name { get; set; }
        public string delivery_address { get; set; }
        public int? delivery_city_id { get; set; }
        public string delivery_phone { get; set; }
        public string billing_name { get; set; }
        public string billing_address { get; set; }
        public int? billing_city_id { get; set; }
        public string billing_phone { get; set; }
        public string SIPARIS_NO { get; set; }
    }

    public class OrderStatusList : IViewModel
    {
        public int order_id { get; set; }
        public DateTimeOffset time { get; set; }
        public int order_status_type_id { get; set; }
    }
}
