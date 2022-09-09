namespace Fintech.Application.UseCases.GetCredit
{
    public interface IGetCreditUserCase
    {
        Task Execute(int? id);

        void SetOutputPort(IOutputPort outputPort);
    }
}
