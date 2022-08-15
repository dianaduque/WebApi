namespace Fintech.DTOs
{
    public class CreditRequestDTOPending
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public double? AmountRequest { get; set; }
        public string? Comments { get; set; }
        public string? IdentityNumber { get; set; }
    }
}
