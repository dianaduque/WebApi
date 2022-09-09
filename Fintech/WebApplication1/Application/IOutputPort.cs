using WebApplication1.Domain;

namespace WebApplication1.Application
{
    public interface IOutputPort
    {

        void Ok(User user);
        void NotFound();
        void Invaid();

    }
}
