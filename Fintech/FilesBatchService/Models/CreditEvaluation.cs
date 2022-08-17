using System;
using System.Collections.Generic;

namespace FilesBatchService.Models
{
    public partial class CreditEvaluation
    {
        public int Id { get; set; }
        public int CreditRequest { get; set; }
        public bool IsApproved { get; set; }
        public string Comments { get; set; } = null!;
    }
}
