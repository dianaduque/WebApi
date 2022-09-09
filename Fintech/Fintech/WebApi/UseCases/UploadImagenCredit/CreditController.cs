using AutoMapper;
using Fintech.Application.UseCases.UploadImagenCredit;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Fintech.WebApi.UseCases.UploadImagenCredit
{
    [EnableCors("_myAllowSpecificOrigins")]
    public class CreditController : Controller, IOutputPort
    {
        private readonly IUploadImagenCreditUseCase _useCase;
        private IActionResult? _viewModel;
        private readonly IMapper _mapper;

        public CreditController(IUploadImagenCreditUseCase uploadImagenCreditUseCase, IMapper mapper)
        {
            _useCase = uploadImagenCreditUseCase;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("credit/property")]
        public async Task<IActionResult> UploadFile()
        {
            _useCase.SetOutputPort(this);
            IFormFile file = HttpContext.Request.Form.Files[0];
            await _useCase.Execute(file);
            return this._viewModel!;
        }

        public void Invalid() => this._viewModel = this.BadRequest("Error internal.");

        public void Ok(int id) => this._viewModel = this.Ok(new UploadImagenCreditRespose(id));

        void IOutputPort.NotFound() => this._viewModel = this.BadRequest("Error internal.");
    }
}
