using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class django_content_typeVm : IViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string app_label { get; set; }
        public string model { get; set; }
    }
}
