namespace Fintech.Application.Services.File
{
    public class LocalStrategy : IFileStrategy
    {
        private const string Path_Files = "F:\\Documentos\\Imagenes";

        public async Task<string> Execute(IFormFile file)
        {
            //Strip out any path specifiers (ex: /../)
            var originalFileName = Path.GetFileName(file.FileName);

            //Create a unique file path
            var uniqueFileName = Guid.NewGuid().ToString() + originalFileName;
            var uniqueFilePath = Path.Combine(Path_Files, uniqueFileName);

            //Save the file to disk
            using (var stream = System.IO.File.Create(uniqueFilePath))
            {
                await file.CopyToAsync(stream);
            }

            return uniqueFilePath;
        }

    }
}
