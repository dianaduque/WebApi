namespace Fintech.Application.Services.File
{
    public class ContextFile
    {
        private IFileStrategy _strategy;

        public ContextFile()
        { }

        public void SetStrategy(IFileStrategy strategy)
        {
            this._strategy = strategy;
        }

        public async Task<string> SaveFile(IFormFile file)
        {
            return await _strategy.Execute(file);
        }
    }
}
