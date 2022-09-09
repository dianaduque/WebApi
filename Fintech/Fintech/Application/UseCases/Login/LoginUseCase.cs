using Fintech.Domain;
using Fintech.Domain.Model;

namespace Fintech.Application.UseCases.Login
{
    public class LoginUseCase : ILoginUseCase
    {
        private IOutputPort _outputPort;
        private readonly IUserRepository _userRepository;
        public LoginUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _outputPort = new LoginPresenter();
        }

        public Task Execute(string userName, string password)
        {
            return this.Login(userName, password);
        }

        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        private async Task Login(string userName, string password)
        {
            User user= await _userRepository.Login(userName, password);
            if (user != null)
            {
                _outputPort.Ok(user);
                return;
            }

            this._outputPort.NotFound();
        }
    }
}
