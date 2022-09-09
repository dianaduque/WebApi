namespace Fintech.Application.UseCases.UploadImagenCredit
{
    public interface IUploadImagenCreditUseCase
    {
        Task Execute(IFormFile image);

        void SetOutputPort(IOutputPort outputPort);
    }
}
