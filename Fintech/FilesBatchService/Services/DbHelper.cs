
using FilesBatchService.DTO;
using FilesBatchService.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FilesBatchService.Services
{
    public class DbHelper
    {
        private FintechContext _dbContext;

        private DbContextOptions<FintechContext> GetAllOptions()
        {
            DbContextOptionsBuilder<FintechContext> optionsBuilder = new DbContextOptionsBuilder<FintechContext>();

            optionsBuilder.UseSqlServer("Server=DEV-DIANAD\\MSSQLSERVER2019;Database=Fintech;User ID=sa;Password=Bizagi2018;TrustServerCertificate=True");

            return optionsBuilder.Options;
        }

        public List<CreditRequest> GetCredit()
        {
            using (_dbContext = new FintechContext(GetAllOptions()))
            {
                try
                {
                    var credits = _dbContext.CreditRequests.Where(s => s.IsCompleted == false)
                        .ToList();

                    if (credits == null)
                        throw new InvalidOperationException("No user data is found!");

                    return credits;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<CreditRequestpPendingDTO> GetCreditToProcess()
        {
            using (_dbContext = new FintechContext(GetAllOptions()))
            {
                var creditRequest = (from credit in _dbContext.CreditRequests.Where(s => s.IsCompleted == false)
                                     join customer in _dbContext.Customers
                                         on credit.Customer equals customer.Id

                                     select new CreditRequestpPendingDTO()
                                     {
                                         Id = credit.Id,
                                         Fullname = customer.FullName,
                                         IdentityNumber = customer.IdentityNumber,
                                         Email = customer.Email,
                                         CellPhoneNumber = customer.CellPhoneNumber,
                                         AmountRequest = credit.AmountRequest,
                                         Comments = credit.Comments,
                                         Imagen = credit.Imagen
                                     }).ToList();

                return creditRequest;
            }
        }

        public async Task UpdateCreditToCompleted(int id, string filePdf, string fileImagenWM)
        {
            using (_dbContext = new FintechContext(GetAllOptions()))
            {
                var credit = await _dbContext.CreditRequests.FirstOrDefaultAsync(m => m.Id == id);
                if (credit != null)
                {
                    credit.IsCompleted = true;
                    credit.PdfGeneral = filePdf;
                    credit.ImagenWaterMark = fileImagenWM;
                    _dbContext.Update(credit);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }


    }
}
