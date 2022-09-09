using AutoMapper;
using Fintech.Application.UseCases.CreateCreditEvaluation;
using Fintech.Domain.Model;
using Fintech.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Fintech.WebApi.UseCases.CreateCreditEvaluation
{
    [EnableCors("_myAllowSpecificOrigins")]
    public class CreditController : Controller, IOutputPort
    {
        private readonly ICreateCreditEvaluationUserCase _useCase;
        private IActionResult? _viewModel;
        private readonly IMapper _mapper;

        public CreditController(ICreateCreditEvaluationUserCase createCreditEvaluationUserCase, IMapper mapper)
        {
            _useCase = createCreditEvaluationUserCase;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("credit/evaluate")]
        public async Task<IActionResult> CreateCreditEvaluation([FromBody] CreateCreditEvaluationRequest creditRequest)
        {
            var ceditEvaluationVO = _mapper.Map<CreditEvaluationDTO>(creditRequest);

            _useCase.SetOutputPort(this);
            await _useCase.Execute(ceditEvaluationVO);

            return this._viewModel!;
        }

        void IOutputPort.NotFound() => this._viewModel = this.NotFound();
        public void Invalid() => this._viewModel = this.BadRequest("Not founds.");
        public void Ok(CreditEvaluation creditEvaluationDTO) => this._viewModel = this.Ok(_mapper.Map<CreateCreditEvaluationResponse>(creditEvaluationDTO));


    }
}
