using AutoMapper;
using Fintech.Domain.Model;
using Fintech.WebApi.UseCases.CreateCredit;
using Fintech.WebApi.UseCases.CreateCreditEvaluation;

namespace Fintech.DTOs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreditRequestDTO, CreditRequest>().ReverseMap();
            CreateMap<CustomerDTO, Customer>().ReverseMap();
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<CreditEvaluationDTO, CreditEvaluation>().ReverseMap();

            //nuevo
            CreateMap<CreateCreditRequest, CreditRequest>().ReverseMap();
            CreateMap<Fintech.WebApi.Models.Customer, Customer>().ReverseMap();
             CreateMap<Fintech.WebApi.Models.Customer, Customer>().ReverseMap();
            CreateMap<CreateCreditEvaluationRequest, CreditEvaluationDTO>().ReverseMap();
            CreateMap<CreateCreditEvaluationResponse, CreditEvaluation>().ReverseMap();
            

        }
    }
}
