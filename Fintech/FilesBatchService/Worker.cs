using FilesBatchService.DTO;
using FilesBatchService.Services;
using IronPdf;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace FilesBatchService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private const string Path_Files_PDF = "F:\\Documentos\\Imagenes\\pdf";
        private const string Path_Files_iMAGEN_WM = "F:\\Documentos\\Imagenes\\WM";

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                ProcessCredits();
                await Task.Delay(1000, stoppingToken);
            }
        }

        private void ProcessCredits()
        {
           
            DbHelper dbHelper = new DbHelper();
            List<CreditRequestpPendingDTO> credits =dbHelper.GetCreditToProcess();
            string filePdf;
            string fileImagenWM;

            foreach(CreditRequestpPendingDTO credit in credits)
            {
                filePdf = GeneratePDF(credit);
                fileImagenWM = Watermark(credit);
                dbHelper.UpdateCreditToCompleted(credit.Id, filePdf, fileImagenWM);
            }
            


            //watermark();
            //GeneratePDF();

            _logger.LogInformation("probando diana", DateTimeOffset.Now);



            //GeneratePDF();
            //watermark();

            //Hacer unquery a credit para saber que debo procesar.
            //por cada credit traer la imagen.
            // aplicar marca de agua.
            // guardar archivo.
            //actualizar registro en la bd
        }

        private string Watermark(CreditRequestpPendingDTO credit)
        {
            var watermarkedStream = new MemoryStream();
            string watermarked = credit.Fullname + " -- " + credit.IdentityNumber;
            var uniqueFileName = Guid.NewGuid().ToString() + "WM.jpg";
            string file ;

            using (var img = Image.FromFile(credit.Imagen))
            {
                using (var graphic = Graphics.FromImage(img))
                {
                    var font = new Font(FontFamily.GenericSansSerif, 20, FontStyle.Bold, GraphicsUnit.Pixel);
                    var color = Color.FromArgb(128, 255, 255, 255);
                    var brush = new SolidBrush(color);
                    var point = new Point(img.Width - 150, img.Height - 30);

                    graphic.DrawString(watermarked, font, brush, point);
                     
                    img.Save(watermarkedStream, ImageFormat.Png);

                    file = Path.Combine(Path_Files_iMAGEN_WM, uniqueFileName);

                    img.Save(file, ImageFormat.Jpeg);

                }

                
            }

            return file;

        }

        private string GeneratePDF(CreditRequestpPendingDTO credit)
        {
            var uniqueFileName = Guid.NewGuid().ToString() + "Gen.pdf";

            var Renderer = new IronPdf.ChromePdfRenderer();
            PdfDocument Pdf = Renderer.RenderHtmlAsPdf(GetHTMLString(credit.Fullname, credit.IdentityNumber, credit.Email, credit.CellPhoneNumber, credit.AmountRequest.ToString(), credit.Comments));
            string file = Path.Combine(Path_Files_PDF, uniqueFileName);
            Pdf.SaveAs(file);
            return file;

        }

        private string GetHTMLString(string fullName, string IdentityNumber, string Email, string CellPhoneNumber, string AmountRequest, string comments)
        {
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>Reporte solicitud de credito!!!</h1></div>");

            
            sb.AppendFormat(@"<label>Nombre Cliente: </label> <h>{0} </h><br></br>
                <label>Identificacion: </label> <h>{1} </h><br></br>
                <label>Email: </label> <h>{2} </h><br></br>
                <label>Celular: </label> <h>{3} </h><br></br>
                <label>Cantidad solicitada: </label> <h>{4} </h><br></br>
                <label>Comentarios: </label> <h>{5} </h><br></br>"
                , fullName, IdentityNumber, Email, CellPhoneNumber, AmountRequest, comments);

            sb.Append(@"
                            </body>
                        </html>");


            return sb.ToString();
        }
    }
}