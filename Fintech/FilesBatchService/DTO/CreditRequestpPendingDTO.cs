using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesBatchService.DTO
{
    public class CreditRequestpPendingDTO
    {
        public int Id { get; set; }
        public double? AmountRequest { get; set; }
        public string? Comments { get; set; }
        public string? Imagen { get; set; }
        public string? Fullname { get; set; }
        public string Email { get; set; } = null!;
        public string CellPhoneNumber { get; set; } = null!;
        public string IdentityNumber { get; set; } = null!;
    }
}
