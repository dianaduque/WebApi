using AutoMapper;
using Fintech.Application.UseCases.CreateCredit;
using Fintech.Domain.Model;
using Fintech.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using IOutputPort = Fintech.Application.UseCases.CreateCredit.IOutputPort;

namespace Fintech.WebApi.UseCases.CreateCredit
{
    [EnableCors("_myAllowSpecificOrigins")]
    public class CreditController : Controller, IOutputPort
    {
        private readonly ICreateCreditUseCase _useCase;
        private IActionResult? _viewModel;
        private readonly IMapper _mapper;

        public CreditController(ICreateCreditUseCase createCreditUseCase, IMapper mapper)
        {
            _useCase = createCreditUseCase;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("credit")]
        public async Task<IActionResult> CreateCreditRequest([FromBody] CreateCreditRequest creditRequest)
        {
            _useCase.SetOutputPort(this);
            var creditRequestVO = _mapper.Map<CreditRequest>(creditRequest);
            var customerVO = _mapper.Map<Customer>(creditRequest.CustomerRequest);

            await _useCase.Execute(creditRequestVO, customerVO);

            return this._viewModel!;

        }


        public void Ok(CreditRequestDTO credit) => this._viewModel = this.Ok(new CreateCreditResponse(credit));

        void IOutputPort.NotFound() => this._viewModel = this.NotFound();
        public void Invalid() => this._viewModel = this.BadRequest("Not founds.");
    }
}
