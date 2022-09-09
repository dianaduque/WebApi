using Fintech.Domain.Model;
using Fintech.DTOs;

namespace Fintech.Domain
{
    public interface ICreditRepository
    {
        Task<int> CreateCredit(string imagen);
        Task<CreditRequestDTO> UpdateCreditRequest(CreditRequest creditRequest, Customer customer);
        List<CreditRequestDTOPending> GetCreditPendding();
        Task<CreditRequestDTOPending> GetCredit(int? id);
        Task<CreditEvaluation> CreateCreditEvaluation(CreditEvaluation evaluation);
    }
}
