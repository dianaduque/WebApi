using Fintech.Domain.Model;
using Fintech.DTOs;

namespace Fintech.Application.UseCases.CreateCreditEvaluation
{
    public interface IOutputPort
    {
        void Ok(CreditEvaluation creditEvaluationDTO);
        void NotFound();
        void Invalid();
    }
}
