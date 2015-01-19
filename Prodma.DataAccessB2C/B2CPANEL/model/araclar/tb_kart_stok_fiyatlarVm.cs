using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class tb_kart_stok_fiyatlarVm : IViewModel
    {
        public int artis { get; set; }
        public string stok_kodu { get; set; }
        public string tedarikci_kodu { get; set; }
        public int? paket_stok_id { get; set; }
        public double? minumum_adet { get; set; }
        public string tedarikci { get; set; }
        public string birimi { get; set; }
        public int? grup_id { get; set; }
        public double? depo1 { get; set; }
        public double? depo2 { get; set; }
        public string yeni_urun { get; set; }
        public double? fiyat { get; set; }
        public int? fiyat_doviz_id { get; set; }
        public double? kdv { get; set; }
        public double? isk1 { get; set; }
        public double? isk2 { get; set; }
        public double? isk3 { get; set; }
        public double? isk4 { get; set; }
        public double? kmp_isk { get; set; }
        public string net_fiyat_aktifmi { get; set; }
        public int? ege_stok_id { get; set; }
        public int? toptanci_id { get; set; }
    }
}
