using AutoMapper;
using Fintech.Domain;

namespace Fintech.Infrastructure.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly FintechContext _context;
        private readonly IMapper _mapper;

        public CustomerRepository(FintechContext context, IMapper mapper)
        {
            this._context = context ??
                                                                      throw new ArgumentNullException(
                                                                          nameof(context));

            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public string GetEmailCustomer(int creditRequestId)
        {
            var email = (from credit in _context.CreditRequests
                         join customer in _context.Customers
                             on credit.Customer equals customer.Id
                         where credit.Id == creditRequestId
                         select new
                         {
                             customer.Email
                         }).SingleOrDefault();

            return email.Email;
        }
    }
}
