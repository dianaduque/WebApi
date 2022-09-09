using AutoMapper;
using Fintech.Domain;
using Fintech.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Fintech.Infrastructure.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FintechContext _context;
        private readonly IMapper _mapper;

        public UserRepository(FintechContext context, IMapper mapper)
        {
            this._context = context ??
                                                                      throw new ArgumentNullException(
                                                                          nameof(context));

            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<User> Login(string userName, string password)
        {
            User user = await _context.Users.SingleOrDefaultAsync(m => m.UserName == userName && m.Password == password);

            return user;
        }
    }
}
