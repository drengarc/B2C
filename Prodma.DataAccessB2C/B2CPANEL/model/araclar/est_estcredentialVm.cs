using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class est_estcredentialVm : IViewModel
    {
        public int id { get; set; }
        public string bank { get; set; }
        public string client_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string secret_key { get; set; }
    }
}
