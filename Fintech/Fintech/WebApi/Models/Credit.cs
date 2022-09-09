using Fintech.DTOs;

namespace Fintech.WebApi.Models
{
    public class Credit
    {
        public int Id { get; set; }
        public double? AmountRequest { get; set; }
        public string? Comments { get; set; }
        public string? Imagen { get; set; }

        public Customer? CustomerRequest { get; set; }
    }

}
