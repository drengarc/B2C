using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class auth_group_permissionsVm : IViewModel
    {
        public int id { get; set; }
        public int group_id { get; set; }
        public int permission_id { get; set; }
    }
}
