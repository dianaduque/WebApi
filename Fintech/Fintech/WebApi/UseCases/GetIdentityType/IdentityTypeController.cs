using Fintech.Application.UseCases.GetIdentityType;
using Fintech.Domain.Model;
using Fintech.WebApi.UseCases.GetCreditsPendding;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using IOutputPort = Fintech.Application.UseCases.GetIdentityType.IOutputPort;

namespace Fintech.WebApi.UseCases.GetIdentityType
{
    [EnableCors("_myAllowSpecificOrigins")]
    public class IdentityTypeController : Controller, IOutputPort
    {
        private readonly IGetIdentityTypeUserCase _useCase;
        private IActionResult? _viewModel;

        public IdentityTypeController(IGetIdentityTypeUserCase getIdentityTypeUserCase)
        {
            _useCase = getIdentityTypeUserCase;
        }

        [HttpGet]
        [Route("IdentityType")]
        public async Task<IActionResult> GetIdentityType()
        {
            _useCase.SetOutputPort(this);
            await _useCase.Execute();

            return this._viewModel!;
        }

        public void Invalid() => this._viewModel = this.NotFound("No fount");


        public void Ok(List<IdentityType> identityTypes)
        {
            List<IdentityTypeResponse> IdentityTypePenddingResponse = new List<IdentityTypeResponse>();
            foreach (IdentityType iden in identityTypes)
            {
                IdentityTypeResponse tpm = new IdentityTypeResponse();
                tpm.Id = iden.Id;
                tpm.Name = iden.Name;

                IdentityTypePenddingResponse.Add(tpm);
            }

            this._viewModel = this.Ok(IdentityTypePenddingResponse);
        }


            void IOutputPort.NotFound() => this._viewModel = this.NotFound("No fount");
    }
}
