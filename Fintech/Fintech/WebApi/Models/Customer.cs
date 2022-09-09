namespace Fintech.WebApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public int IdentityType { get; set; }
        public string IdentityNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string CellPhoneNumber { get; set; } = null!;
        public double Salary { get; set; }

        public Customer(int id, string fullName, DateTime birthDate, int identityType, string identityNumber, string email, string cellPhoneNumber, double salary)
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
