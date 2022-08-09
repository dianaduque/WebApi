using AutoMapper;
using Fintech.Models;

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
        }
    }
}
