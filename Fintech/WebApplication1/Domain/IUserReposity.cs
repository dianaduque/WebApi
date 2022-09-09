namespace WebApplication1.Domain
{
    public interface IUserReposity
    {

        int SaveUser(User user);
        User GetUser(int id);
    }
}
