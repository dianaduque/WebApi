using Fintech.DTOs;

namespace Fintech.Application.UseCases.GetCredit
{
    public interface IOutputPort
    {
        void Ok(CreditRequestDTOPending creditRequestDTOPending);
        void NotFound();
        void Invalid();
    }
}
