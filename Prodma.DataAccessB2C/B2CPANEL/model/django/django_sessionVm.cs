using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class django_sessionVm : IViewModel
    {
        public string session_key { get; set; }
        public string session_data { get; set; }
        public DateTimeOffset expire_date { get; set; }
    }
}
