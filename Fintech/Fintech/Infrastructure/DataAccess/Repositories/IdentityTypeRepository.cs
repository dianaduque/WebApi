using AutoMapper;
using Fintech.Domain;
using Fintech.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Fintech.Infrastructure.DataAccess.Repositories
{
    public class IdentityTypeRepository : IIdentityTypeRepository
    {
        private readonly FintechContext _context;
        private readonly IMapper _mapper;

        public IdentityTypeRepository(FintechContext context, IMapper mapper)
        {
            this._context = context ??
                                                                      throw new ArgumentNullException(
                                                                          nameof(context));

            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<List<IdentityType>> GetIdentityTypes()
        {
            return _context.IdentityTypes.ToListAsync();
        }
    }
}
