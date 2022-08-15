namespace Fintech.DTOs
{
    public class CreditEvaluationDTO
    {
        public int Id { get; set; }
        public int CreditRequest { get; set; }
        public bool IsApproved { get; set; }
        public string Comments { get; set; } = null!;
    }
}
