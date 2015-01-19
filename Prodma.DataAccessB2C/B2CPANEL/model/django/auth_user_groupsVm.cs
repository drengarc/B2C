using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class auth_user_groupsVm : IViewModel
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int group_id { get; set; }
    }
}
