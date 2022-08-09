using Fintech.DTOs;
using Fintech.Models;

namespace Fintech.DA
{
    public interface ICreditRequestsDA
    {
        Task CreateCreditRequest(CreditRequest CreditRequest, Customer customer);
        Task CreateCreditEvaluation(CreditEvaluation evaluation);
        List<CreditRequestDTO> GetCreditRequestPenddingApproved();

        Task<CreditRequestDTO> GetCreditRequestDetails(int? id);
    }
}
