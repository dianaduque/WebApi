using WebApplication1.Domain;

namespace WebApplication1.Application
{
    public interface IUserServices
    {
        void SaveUser(User user);
        void SetOutputPor(IOutputPort outputPort);
    }
}
