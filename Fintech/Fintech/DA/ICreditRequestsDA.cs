﻿using Fintech.DTOs;
using Fintech.Models;

namespace Fintech.DA
{
    public interface ICreditRequestsDA
    {
        Task<int> CreateCreditRequest(string imagen);
        Task<CreditRequest> UpdateCreditRequest(CreditRequest CreditRequest, Customer customer);
        Task CreateCreditEvaluation(CreditEvaluation evaluation);
        List<CreditRequestDTOPending> GetCreditRequestPenddingApproved();

        Task<CreditRequestDTOPending> GetCreditRequestDetails(int? id);
    }
}
