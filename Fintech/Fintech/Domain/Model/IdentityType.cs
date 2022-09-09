using System;
using System.Collections.Generic;

namespace Fintech.Domain.Model
{
    public partial class IdentityType
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
