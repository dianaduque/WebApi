using Fintech.Models;

namespace Fintech.DA
{
    public interface IUserDA
    {
        Task<User> Login(string userName, string password);
    }
}
