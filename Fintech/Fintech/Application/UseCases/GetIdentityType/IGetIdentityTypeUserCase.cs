namespace Fintech.Application.UseCases.GetIdentityType
{
    public interface IGetIdentityTypeUserCase
    {
        Task Execute();
        void SetOutputPort(IOutputPort outputPort);
    }
}
