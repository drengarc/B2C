using System.Collections.Generic;
using Prodma.DataAccess;
using System;

namespace B2C.Models
{
    public class cms_menuattributeVm : IViewModel
    {
        public int id { get; set; }
        public int entity_type_id { get; set; }
        public int entity_id { get; set; }
        public string value_text { get; set; }
        public double? value_float { get; set; }
        public DateTime? value_date { get; set; }
        public bool? value_bool { get; set; }
        public int schema_id { get; set; }
        public int? choice_id { get; set; }
    }
}
