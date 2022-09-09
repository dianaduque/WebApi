using Fintech.Domain;
using Fintech.DTOs;

namespace Fintech.Application.UseCases.GetCredit
{
    public class GetCreditUserCase : IGetCreditUserCase
    {
        private IOutputPort _outputPort;
        private readonly ICreditRepository _creditRepository;

        public GetCreditUserCase(ICreditRepository creditRepository)
        {
            _creditRepository = creditRepository;
            _outputPort = new GetCreditPresenter();
        }
        public Task Execute(int? id)
        {
            return GetCredit(id);
        }

        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        private async Task GetCredit(int? id)
        {
            if (id == null)
            {
                _outputPort.Invalid();
                return;
            }

            CreditRequestDTOPending creditRequestDTOPending = await _creditRepository.GetCredit(id);

            if (creditRequestDTOPending != null)
            {
                _outputPort.Ok(creditRequestDTOPending);
                return;
            }

            _outputPort.NotFound();
        }
    }
}
