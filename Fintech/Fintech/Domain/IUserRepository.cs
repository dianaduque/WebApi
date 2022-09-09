using Fintech.Domain.Model;

namespace Fintech.Domain
{
    public interface IUserRepository
    {
        Task<User> Login(string userName, string password);
    }
}
