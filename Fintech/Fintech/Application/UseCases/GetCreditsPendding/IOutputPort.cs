using Fintech.DTOs;

namespace Fintech.Application.UseCases.GetCreditsPendding
{
    public interface IOutputPort
    {
        void Ok(List<CreditRequestDTOPending> credits);
        void NotFound();
        void Invalid();
    }
}
