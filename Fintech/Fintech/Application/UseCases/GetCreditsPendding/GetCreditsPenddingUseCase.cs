using Fintech.Domain;
using Fintech.DTOs;

namespace Fintech.Application.UseCases.GetCreditsPendding
{
    public class GetCreditsPenddingUseCase : IGetCreditsPenddingUseCase
    {
        private IOutputPort _outputPort;
        private readonly ICreditRepository _creditRepository;

        public GetCreditsPenddingUseCase(ICreditRepository creditRepository)
        {
            _creditRepository = creditRepository;
            _outputPort = new GetCreditsPenddingPresenter();
        }

        public Task Execute()
        {
            return GetCreditPendding();
        }

        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        public async Task GetCreditPendding()
        {
            List<CreditRequestDTOPending> creditRequestVO = _creditRepository.GetCreditPendding();
            _outputPort.Ok(creditRequestVO);
            return;
        }
    }
}
