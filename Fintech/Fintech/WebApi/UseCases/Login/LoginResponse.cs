using Fintech.Domain.Model;

namespace Fintech.WebApi.UseCases.Login
{
    public class LoginResponse
    {
        public int Id { get; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public LoginResponse(User user)
        {
            Id = user.Id;
            UserName = user.UserName;
            Password = user.Password;
        }
    }
}
