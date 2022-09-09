using System;
using System.Collections.Generic;

namespace Fintech.Domain.Model
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public int IdentityType { get; set; }
        public string IdentityNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string CellPhoneNumber { get; set; } = null!;
        public double Salary { get; set; }
    }
}
