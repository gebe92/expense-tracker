using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.TransactionDetails
{
    public class TransDto
    {
        public int transID { get; set; }
        public string transType { get; set; } = string.Empty;
        public string transDesc { get; set; } = string.Empty;
        public string transCategory { get; set; } = string.Empty;
        public DateTime transDate { get; set; }
        public decimal transAmt { get; set; }
        public int transUserID { get; set; }
    }
}