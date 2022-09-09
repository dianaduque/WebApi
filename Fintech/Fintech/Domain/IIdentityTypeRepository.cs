using Fintech.Domain.Model;

namespace Fintech.Domain
{
    public interface IIdentityTypeRepository
    {
        Task<List<IdentityType>> GetIdentityTypes();
    }
}
