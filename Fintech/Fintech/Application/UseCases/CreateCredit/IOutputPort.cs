using Fintech.DTOs;

namespace Fintech.Application.UseCases.CreateCredit
{
    public interface IOutputPort
    {
        void Ok(CreditRequestDTO credit);
        void NotFound();
        void Invalid();
    }
}
