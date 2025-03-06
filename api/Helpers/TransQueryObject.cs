using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class TransQueryObject
    {
        public string? transType { get; set; } = null;
        public string? transCategory { get; set; } = null;
        public DateTime? transDate { get; set; }
        public int? transMonth { get; set; }
        public int? transYear { get; set; }
        public string? SortBy { get; set; } = null;
        public bool IsDecsending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
    }
}