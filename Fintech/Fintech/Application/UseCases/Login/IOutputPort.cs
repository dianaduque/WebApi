using Fintech.Domain.Model;

namespace Fintech.Application.UseCases.Login
{
    public interface IOutputPort
    {
        void Ok(User user);
        void NotFound();
        void Invalid();
    }
}
