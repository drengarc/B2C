using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class auth_permissionVm : IViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int content_type_id { get; set; }
        public string codename { get; set; }
    }
}
