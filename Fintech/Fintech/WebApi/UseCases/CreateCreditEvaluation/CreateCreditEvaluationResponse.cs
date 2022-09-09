namespace Fintech.WebApi.UseCases.CreateCreditEvaluation
{
    public class CreateCreditEvaluationResponse
    {
        public int Id { get; set; }
        public int CreditRequest { get; set; }
        public bool IsApproved { get; set; }
        public string Comments { get; set; } = null!;
    }
}
