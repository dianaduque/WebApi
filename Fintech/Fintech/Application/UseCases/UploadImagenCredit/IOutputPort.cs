namespace Fintech.Application.UseCases.UploadImagenCredit
{
    public interface IOutputPort
    {
        void Ok(int id);
        void NotFound();
        void Invalid();
    }
}
