using Fintech.DTOs;

namespace Fintech.WebApi.UseCases.CreateCredit
{
    public class CreateCreditResponse
    {
        public int Id { get; set; }
        public CustomerResponse? CustomerResponse { get; set; }
        public double? AmountRequest { get; set; }
        public string? Comments { get; set; }
        public string? Imagen { get; set; }

        public CreateCreditResponse(CreditRequestDTO creditRequestDTO)
        {
            Id = creditRequestDTO.Id;
            AmountRequest = creditRequestDTO.AmountRequest;
            Comments = creditRequestDTO.Comments;
            Imagen = creditRequestDTO.Imagen;
            CustomerResponse = new CustomerResponse(creditRequestDTO.CustomerDto.Id, creditRequestDTO.CustomerDto.FullName, creditRequestDTO.CustomerDto.BirthDate, creditRequestDTO.CustomerDto.IdentityType, 
                creditRequestDTO.CustomerDto.IdentityNumber, creditRequestDTO.CustomerDto.Email, creditRequestDTO.CustomerDto.CellPhoneNumber, creditRequestDTO.CustomerDto.Salary);
        }
    }

    public class CustomerResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public int IdentityType { get; set; }
        public string IdentityNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string CellPhoneNumber { get; set; } = null!;
        public double Salary { get; set; }

        public CustomerResponse(int id, string fullName, DateTime birthDate, int identityType, string identityNumber, string email, string cellPhoneNumber, double salary)
        {
            Id = id;
            FullName = fullName;
            BirthDate = birthDate;
            IdentityType = identityType;
            IdentityNumber = identityNumber;
            Email = email;
            CellPhoneNumber = cellPhoneNumber;
            Salary = salary;
        }
    }
}
