using Fintech.DTOs;

namespace Fintech.WebApi.UseCases.GetCreditsPendding
{
    public class GetCreditsPenddingResponse
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public double? AmountRequest { get; set; }
        public string? Comments { get; set; }
        public string? IdentityNumber { get; set; }

        public GetCreditsPenddingResponse(CreditRequestDTOPending credits)
        {
            Id = credits.Id;
            Fullname = credits.Fullname;
            AmountRequest = credits.AmountRequest;
            Comments = credits.Comments;
            IdentityNumber = credits.IdentityNumber;

        }
    }

  
}
