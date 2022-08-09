namespace Fintech.DTOs
{
    public class CreditRequestDTO
    {
        public int Id { get; set; }
        public CustomerDTO CustomerDto { get; set; } = null!;
        public double AmountRequest { get; set; }
        public string Comments { get; set; } = null!;

    }
}
