using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class TransactionDetails
    {
        [Key]
        public int transID { get; set; }
        public string transType { get; set; } = string.Empty;
        public string transDesc { get; set; } = string.Empty;
        public string transCategory { get; set; } = string.Empty;
        public DateTime transDate { get; set; }
        [Column(TypeName = "decimal(12, 2)")]
        public decimal transAmt { get; set; }
        public int transUserID { get; set; }
    }
}