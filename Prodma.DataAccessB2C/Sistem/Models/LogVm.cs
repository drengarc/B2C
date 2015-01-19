using System.Collections.Generic;
using Prodma.DataAccessB2C;
using System;
namespace Prodma.SistemB2C.Models
{
    public class LogVm : IViewModel
    {
        public int Id { get; set; }
        public DateTimeOffset? Date { get; set; }
        public string Thread { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }
}
