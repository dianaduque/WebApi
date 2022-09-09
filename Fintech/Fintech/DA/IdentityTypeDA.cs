using Fintech.Domain.Model;
using Fintech.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Fintech.DA
{
    public interface IIdentityTypeDA
    {
        //Task<List<IdentityType>> GetIdentityTypes();
    }
    public class IdentityTypeDA : IIdentityTypeDA
    {
        /*
        private readonly FintechContext _context;

        public IdentityTypeDA(FintechContext context)
        {
            _context = context;
        }

        public Task<List<IdentityType>> GetIdentityTypes()
        {
            return _context.IdentityTypes.ToListAsync();
        }
        */
    }
}
