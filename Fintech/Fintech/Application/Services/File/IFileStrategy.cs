namespace Fintech.Application.Services.File
{
    public interface IFileStrategy
    {
        Task<string> Execute(IFormFile file);
    }
}
