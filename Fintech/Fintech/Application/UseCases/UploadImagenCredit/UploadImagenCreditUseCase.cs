using Fintech.Application.Services;
using Fintech.Application.Services.File;
using Fintech.Domain;

namespace Fintech.Application.UseCases.UploadImagenCredit
{
    public class UploadImagenCreditUseCase : IUploadImagenCreditUseCase
    {
        private IOutputPort _outputPort;
        private readonly ICreditRepository _creditRepository;
        private readonly IFileService _fileService;

        public UploadImagenCreditUseCase(ICreditRepository creditRepository, IFileService fileService)
        {
            _creditRepository = creditRepository;
            _outputPort = new UploadImagenCreditPresenter();
            _fileService = fileService;
        }
        public Task Execute(IFormFile image)
        {
            return this.CreateCredit(image);
        }

        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        private async Task<string> SaveFile(IFormFile image)
        {
            ContextFile contextFile = new ContextFile();
            contextFile.SetStrategy(new LocalStrategy());
            return await contextFile.SaveFile(image);
            //return await _fileService.SaveFile(image); ;
        }

        private async Task CreateCredit(IFormFile image)
        {
            string ImagePath = await SaveFile(image);

            if (!String.IsNullOrEmpty(ImagePath))
            {
                int id = await _creditRepository.CreateCredit(ImagePath);

                if (id > 0)
                {
                    _outputPort.Ok(id);
                    return;
                }
            }

            this._outputPort.Invalid();
        }
    }
}
