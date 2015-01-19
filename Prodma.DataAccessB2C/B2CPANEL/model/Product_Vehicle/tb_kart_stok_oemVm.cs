using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class tb_kart_stok_oemVm : IViewModel
    {
        public int id { get; set; }
        public int grup_id { get; set; }
        public string oem_no { get; set; }
        public string oem_no_original { get; set; }
        public string arac_marka { get; set; }
    }
}
