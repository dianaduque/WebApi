namespace Fintech.Application.UseCases.GetCreditsPendding
{
    public interface IGetCreditsPenddingUseCase
    {
        Task Execute();

        void SetOutputPort(IOutputPort outputPort);
    }
}
