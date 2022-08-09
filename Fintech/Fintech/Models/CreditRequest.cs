using System;
using System.Collections.Generic;

namespace Fintech.Models
{
    public partial class CreditRequest
    {
        public int Id { get; set; }
        public int Customer { get; set; }
        public double AmountRequest { get; set; }
        public string Comments { get; set; } = null!;
    }
}
