using Fintech.Domain.Model;

namespace Fintech.Application.UseCases.CreateCredit
{
    public interface ICreateCreditUseCase
    {
        Task Execute(CreditRequest creditRequest, Customer customer);

        void SetOutputPort(IOutputPort outputPort);
    }
}
