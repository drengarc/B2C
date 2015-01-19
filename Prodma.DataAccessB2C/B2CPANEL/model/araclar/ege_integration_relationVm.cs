using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class ege_integration_relationVm : IViewModel
    {
        public int id { get; set; }
        public int content_type_id { get; set; }
        public int object_id { get; set; }
        public string ege_code { get; set; }
    }
}
