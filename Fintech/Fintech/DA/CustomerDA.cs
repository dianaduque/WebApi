using Fintech.Models;

namespace Fintech.DA
{
    public interface ICustomerDA
    {
        string GetEmailCustomer(int creditRequestId);
    }

    public class CustomerDA : ICustomerDA
    {
        private readonly FintechContext _context;

        public CustomerDA(FintechContext context)
        {
            _context = context;
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
