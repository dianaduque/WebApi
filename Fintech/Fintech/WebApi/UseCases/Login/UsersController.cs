using Fintech.Application.UseCases.Login;
using Fintech.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Fintech.WebApi.UseCases.Login
{

    public class UsersController : Controller, IOutputPort
    {
        private readonly ILoginUseCase _useCase;
        private IActionResult? _viewModel;

        public UsersController(ILoginUseCase loginUseCase)
        {
            _useCase = loginUseCase;
        }

        public void Invalid() => this._viewModel = this.BadRequest("Not founds.");

        [HttpPost]
        [Route("user/Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            _useCase.SetOutputPort(this);
            await _useCase.Execute(loginRequest.UserName, loginRequest.Password);
            return this._viewModel!;
        }

        public void Ok(User user) => this._viewModel = this.Ok(new LoginResponse(user));

        void IOutputPort.NotFound() => this._viewModel = this.NotFound();
    }
}
