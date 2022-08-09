using Fintech.DTOs;
using Fintech.Models;
using Microsoft.EntityFrameworkCore;

namespace Fintech.DA
{
    public class CreditRequestsDA : ICreditRequestsDA
    {
        private readonly FintechContext _context;

        public CreditRequestsDA(FintechContext context)
        {
            _context = context;
        }

        public async Task CreateCreditRequest(CreditRequest CreditRequest, Customer customer)
        {

            _context.Add(customer);
            await _context.SaveChangesAsync();
            CreditRequest.Customer = customer.Id;

            _context.Add(CreditRequest);
            await _context.SaveChangesAsync();

        }

        public async Task CreateCreditEvaluation(CreditEvaluation evaluation)
        {

            _context.Add(evaluation);
            await _context.SaveChangesAsync();

        }

        public List<CreditRequestDTO> GetCreditRequestPenddingApproved()
        {
            var creditRequest = (from credit in _context.CreditRequests
                                 join evaluation in _context.CreditEvaluations
                                    on credit.Id equals evaluation.CreditRequest into j1
                                 from r in j1.DefaultIfEmpty()
                                 join customer in _context.Customers
                                    on credit.Customer equals customer.Id
                                 select new CreditRequestDTO()
                                 {
                                     Id = credit.Id,
                                     CustomerDto = new (credit.Customer, customer.FullName, customer.BirthDate, customer.IdentityType, customer.IdentityNumber, customer.Email, customer.CellPhoneNumber, customer.Salary),
                                     AmountRequest = credit.AmountRequest,
                                     Comments = credit.Comments
                                 }).ToList();

            return creditRequest;


        }
       
        public async Task<CreditRequestDTO> GetCreditRequestDetails(int? id)
        {
            var creditRequest = await _context.CreditRequests.FirstOrDefaultAsync(m => m.Id == id);
            var customer = await _context.Customers.FirstOrDefaultAsync(m => m.Id == creditRequest.Customer);

            if (creditRequest == null || customer == null)
                return null;

            CreditRequestDTO creditRequestDTO = new CreditRequestDTO()
            {
                Id = creditRequest.Id,
                CustomerDto = new(creditRequest.Customer, customer.FullName, customer.BirthDate, customer.IdentityType, customer.IdentityNumber, customer.Email, customer.CellPhoneNumber, customer.Salary),
                AmountRequest = creditRequest.AmountRequest,
                Comments = creditRequest.Comments
            };

            return creditRequestDTO;
        }
    }
}
