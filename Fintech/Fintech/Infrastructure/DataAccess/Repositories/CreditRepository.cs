using AutoMapper;
using Fintech.Domain;
using Fintech.Domain.Model;
using Fintech.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Fintech.Infrastructure.DataAccess.Repositories
{
    public class CreditRepository : ICreditRepository
    {
        private readonly FintechContext _context;
        private readonly IMapper _mapper;

        public CreditRepository(FintechContext context, IMapper mapper)
        {
            this._context = context ??
                                                                      throw new ArgumentNullException(
                                                                          nameof(context));

            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> CreateCredit(string imagen)
        {
            CreditRequest creditRequest = new CreditRequest();
            creditRequest.Imagen = imagen;
            creditRequest.IsCompleted = false;

            _context.Add(creditRequest);
            await _context.SaveChangesAsync();

            return creditRequest.Id;
        }

        public async Task<CreditRequestDTO> UpdateCreditRequest(CreditRequest creditRequest, Customer customer)
        {
            var creditRequestActual = await _context.CreditRequests.FirstOrDefaultAsync(m => m.Id == creditRequest.Id);

            creditRequestActual.AmountRequest = creditRequest.AmountRequest;
            creditRequestActual.Comments = creditRequest.Comments;

            _context.Add(customer);
            await _context.SaveChangesAsync();
            creditRequestActual.Customer = customer.Id;

            _context.Update(creditRequestActual);
            await _context.SaveChangesAsync();

            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            var creditRequestDTO = _mapper.Map<CreditRequestDTO>(creditRequestActual);
            creditRequestDTO.CustomerDto = customerDTO;

            return creditRequestDTO;
        }

        public List<CreditRequestDTOPending> GetCreditPendding()
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

        public async Task<CreditRequestDTOPending> GetCredit(int? id)
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

        public async Task<CreditEvaluation> CreateCreditEvaluation(CreditEvaluation evaluation)
        {
            _context.Add(evaluation);
            await _context.SaveChangesAsync();
            return evaluation;
        }
    }
}
