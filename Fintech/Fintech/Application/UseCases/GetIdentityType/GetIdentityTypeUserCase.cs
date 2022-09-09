using Fintech.Domain;
using Fintech.Domain.Model;

namespace Fintech.Application.UseCases.GetIdentityType
{
    public class GetIdentityTypeUserCase : IGetIdentityTypeUserCase
    {
        private IOutputPort _outputPort;
        private readonly IIdentityTypeRepository _identityTypeRepository;

        public GetIdentityTypeUserCase(IIdentityTypeRepository identityTypeRepository)
        {
            _identityTypeRepository = identityTypeRepository;
            _outputPort = new GetIdentityTypePresenter();
        }

        public Task Execute()
        {
            return GetIdentityTypes();
        }

        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        private async Task  GetIdentityTypes()
        {
            List<IdentityType> identityTypes =  await _identityTypeRepository.GetIdentityTypes();

            if (identityTypes != null && identityTypes.Count > 0)
            {
                _outputPort.Ok(identityTypes);
                return;
            }

            _outputPort.NotFound();
        }
    }
}
