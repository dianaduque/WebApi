using Fintech.DTOs;

namespace Fintech.WebApi.UseCases.GetCredit
{
    public class GetCreditResponse
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public double? AmountRequest { get; set; }
        public string? Comments { get; set; }
        public string? IdentityNumber { get; set; }

        public GetCreditResponse(CreditRequestDTOPending creditRequestDTOPending)
        {
            Id = creditRequestDTOPending.Id;
            Fullname = creditRequestDTOPending.Fullname;
            AmountRequest = creditRequestDTOPending.AmountRequest;
            Comments = creditRequestDTOPending.Comments;
            IdentityNumber = creditRequestDTOPending.IdentityNumber;
        }
    }
}
