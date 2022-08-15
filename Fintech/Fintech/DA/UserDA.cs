using Fintech.Models;
using Microsoft.EntityFrameworkCore;

namespace Fintech.DA
{
    public class UserDA: IUserDA
    {
        private readonly FintechContext _context;

        public UserDA(FintechContext context)
        {
            _context = context;
        }

        public async Task<User> Login(string userName, string password)
        {
            return await _context.Users.SingleOrDefaultAsync(m => m.UserName == userName && m.Password == password);
        }
    }
}
