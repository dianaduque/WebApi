using Fintech.Application.UseCases.GetCreditsPendding;
using Fintech.DTOs;
using Fintech.WebApi.UseCases.UploadImagenCredit;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Fintech.WebApi.UseCases.GetCreditsPendding
{
    [EnableCors("_myAllowSpecificOrigins")]
    public class CreditController : Controller, IOutputPort
    {
        private readonly IGetCreditsPenddingUseCase _useCase;
        private IActionResult? _viewModel;

        public CreditController(IGetCreditsPenddingUseCase getCreditsPenddingUseCase)
        {
            _useCase = getCreditsPenddingUseCase;
        }
        [HttpGet]
        [Route("credit/analyst")]
        public async Task<IActionResult> CreditRequestPenddingApproved()
        {
            _useCase.SetOutputPort(this);
            await _useCase.Execute();

            return this._viewModel!;
        }
        


        public void Invalid() => this._viewModel = this.BadRequest("Error internal.");

        public void Ok(List<CreditRequestDTOPending> credits)
        {
            List<GetCreditsPenddingResponse> getCreditsPenddingResponse = new List<GetCreditsPenddingResponse>();
            foreach (CreditRequestDTOPending credit in credits)
            {
                getCreditsPenddingResponse.Add(new GetCreditsPenddingResponse(credit));
            }
            
            this._viewModel =  this.Ok(getCreditsPenddingResponse);
        }

        void IOutputPort.NotFound() => this._viewModel = this.BadRequest("Error internal.");
    }
}
