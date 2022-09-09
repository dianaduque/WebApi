using Fintech.DTOs;

namespace Fintech.Application.UseCases.CreateCreditEvaluation
{
    public interface ICreateCreditEvaluationUserCase 
    {
        Task Execute(CreditEvaluationDTO creditRequest);

        void SetOutputPort(IOutputPort outputPort);
    }
}
