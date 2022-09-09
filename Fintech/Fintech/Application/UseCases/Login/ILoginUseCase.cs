namespace Fintech.Application.UseCases.Login
{
    public interface ILoginUseCase
    {
        Task Execute(string userName, string password);

        void SetOutputPort(IOutputPort outputPort);
    }
}
