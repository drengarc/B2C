using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;

namespace B2C.Models
{
    public class languageVm : IViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string image { get; set; }
        public int order { get; set; }
    }
}
