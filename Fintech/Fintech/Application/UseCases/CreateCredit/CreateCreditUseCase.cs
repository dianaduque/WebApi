using Fintech.Domain;
using Fintech.Domain.Model;
using Fintech.DTOs;

namespace Fintech.Application.UseCases.CreateCredit
{
    public class CreateCreditUseCase : ICreateCreditUseCase
    {
        private IOutputPort _outputPort;
        private readonly ICreditRepository _creditRepository;

        public CreateCreditUseCase(ICreditRepository creditRepository)
        {
            _creditRepository = creditRepository;
            _outputPort = new CreateCreditPresenter();
        }

        public Task Execute(CreditRequest creditRequest, Customer customer)
        {
            return CreateCreditRequest(creditRequest, customer);
        }

        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        private async Task CreateCreditRequest(CreditRequest creditRequest, Customer customer)
        {
            CreditRequestDTO credit = await _creditRepository.UpdateCreditRequest(creditRequest, customer);

            if (credit.CustomerDto.Id > 0)
            {
                _outputPort.Ok(credit);
                return;
            }

            this._outputPort.Invalid();
        }
    }
}
