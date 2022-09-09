using WebApplication1.Domain;

namespace WebApplication1.Application
{
    public class UserServices : IUserServices
    {
        private IUserReposity _repository;
        private IOutputPort _outputPort;

        public UserServices(IUserReposity repository)
        {
            _repository = repository;
        }

        public User GetUser(int id)
        {
            return _repository.GetUser(id);
        }


        public void SaveUser(User user)
        {
           int id = _repository.SaveUser(user);
            if (id > 0)
                _outputPort.Ok(user);
            else
                _outputPort.Invaid();
        }

        public void SetOutputPor(IOutputPort outputPort)
        {
            _outputPort = outputPort;
        }
    }
}
