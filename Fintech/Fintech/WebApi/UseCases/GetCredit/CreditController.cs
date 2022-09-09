using Fintech.Application.UseCases.GetCredit;
using Fintech.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Fintech.WebApi.UseCases.GetCredit
{
    [EnableCors("_myAllowSpecificOrigins")]
    public class CreditController : Controller, IOutputPort
    {
        private readonly IGetCreditUserCase _useCase;
        private IActionResult? _viewModel;

        public CreditController(IGetCreditUserCase getCreditUserCase)
        {
            _useCase = getCreditUserCase;
        }

        [Route("credit/{id}")]
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            _useCase.SetOutputPort(this);
            await _useCase.Execute(id);
            return this._viewModel!;
        }


        public void Invalid() => this._viewModel = this.BadRequest("Error internal.");

        public void Ok(CreditRequestDTOPending creditRequestDTOPending) => this._viewModel = this.Ok(new GetCreditResponse(creditRequestDTOPending));

        void IOutputPort.NotFound() => this._viewModel = this.BadRequest("Error internal.");
    }
}
