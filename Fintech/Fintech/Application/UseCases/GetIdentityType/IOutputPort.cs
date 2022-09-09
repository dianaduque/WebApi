using Fintech.Domain.Model;

namespace Fintech.Application.UseCases.GetIdentityType
{
    public interface IOutputPort
    {
        void Ok(List<IdentityType> identityType);
        void NotFound();
        void Invalid();
    }
}
