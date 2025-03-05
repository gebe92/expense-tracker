using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.TransactionDetails
{
    public class CreateTransDto
    {
        [Required]
        public string transType { get; set; } = string.Empty;
        [Required]
        [MaxLength(100, ErrorMessage = "Transaction description cannot be over 100 characters")]
        public string transDesc { get; set; } = string.Empty;
        [Required]
        public string transCategory { get; set; } = string.Empty;
        [Required]
        public DateTime transDate { get; set; }
        [Required]
        [Range(0, 100000000000)]
        public decimal transAmt { get; set; }
        [Required]
        public int transUserID { get; set; }
    }
}