using Fintech.Domain.Model;

namespace Fintech.Application.UseCases.Login
{
    public class LoginPresenter : IOutputPort
    {
        public User? User { get; set; }
        public bool? IsNotFound { get; private set; }
        public bool? InvalidOutput { get; private set; }
        public void Invalid() => this.InvalidOutput = true;
        public void NotFound() => this.IsNotFound = true;


        public void Ok(User user)
        {
            this.User = user;
        }
    }
}
