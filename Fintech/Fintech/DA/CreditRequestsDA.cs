using Fintech.Domain.Model;
using Fintech.DTOs;
using Fintech.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Fintech.DA
{
    public class CreditRequestsDA : ICreditRequestsDA
    {
       /* private readonly FintechContext _context;

        public CreditRequestsDA(FintechContext context)
        {
            _context = context;
        }

        public async Task<int> CreateCreditRequest(string imagen)
        {
            CreditRequest creditRequest = new CreditRequest();
            creditRequest.Imagen = imagen;
            creditRequest.IsCompleted = false;

            _context.Add(creditRequest);
            await _context.SaveChangesAsync();

            return creditRequest.Id;
        }

        public async Task<CreditRequest> UpdateCreditRequest(CreditRequest creditRequest, Customer customer)
        {
            var creditRequestActual = await _context.CreditRequests.FirstOrDefaultAsync(m => m.Id == creditRequest.Id);

            creditRequestActual.AmountRequest = creditRequest.AmountRequest;
            creditRequestActual.Comments = creditRequest.Comments;

            _context.Add(customer);
            await _context.SaveChangesAsync();
            creditRequestActual.Customer = customer.Id;

            _context.Update(creditRequestActual);
            await _context.SaveChangesAsync();

            return creditRequestActual;
        }

        public async Task CreateCreditEvaluation(CreditEvaluation evaluation)
        {
            _context.Add(evaluation);
            await _context.SaveChangesAsync();
        }

        public List<CreditRequestDTOPending> GetCreditRequestPenddingApproved()
        {
            //var recs1 = _context.CreditRequests.Where(x => x.IsCompleted == false && !_context.CreditEvaluations.Any(y => y.CreditRequest == x.Id));
            //var recs = _context.CreditRequests.Where(x => !_context.CreditEvaluations.Any(y => y.CreditRequest == x.Id));

            var creditRequest = (from credit in _context.CreditRequests.Where(x => x.IsCompleted == true && !_context.CreditEvaluations.Any(y => y.CreditRequest == x.Id))
                                 join customer in _context.Customers
                                     on credit.Customer equals customer.Id

                                  select new CreditRequestDTOPending()
                                  {
                                      Id = credit.Id,
                                      Fullname = customer.FullName,
                                      IdentityNumber = customer.IdentityNumber,
                                      AmountRequest = credit.AmountRequest,
                                      Comments = credit.Comments
                                  }).ToList();


            return creditRequest;

        }
       
        public async Task<CreditRequestDTOPending> GetCreditRequestDetails(int? id)
        {
            var creditRequest = await _context.CreditRequests.FirstOrDefaultAsync(m => m.Id == id);
            var customer = await _context.Customers.FirstOrDefaultAsync(m => m.Id == creditRequest.Customer);

            if (creditRequest == null || customer == null)
                return null;

            CreditRequestDTOPending creditRequestDTO = new CreditRequestDTOPending()
            {
                Id = creditRequest.Id,
                Fullname = customer.FullName,
                IdentityNumber = customer.IdentityNumber,
                AmountRequest = creditRequest.AmountRequest,
                Comments = creditRequest.Comments
            };
            return creditRequestDTO;
        }
     */ 
    }
}
