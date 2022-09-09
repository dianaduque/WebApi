using Fintech.Domain.Model;

namespace Fintech.Application.UseCases.GetIdentityType
{
    public class GetIdentityTypePresenter : IOutputPort
    {
        public void Invalid()
        {
            throw new NotImplementedException();
        }

        public void NotFound()
        {
            throw new NotImplementedException();
        }

        public void Ok(List<IdentityType> identityType)
        {
            throw new NotImplementedException();
        }
    }
}
