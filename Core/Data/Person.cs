using static Core.Data.RegistrationEnums;

namespace Tools
{
    public class Person
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string PhoneNumber { get; set; }

        public required string Country { get; set; } 
        public required string City { get; set; } 
        public required string StreetName { get; set; } 
        public required int HouseNumbur { get; set; } 
        public required string PostalCode { get; set; } 
        public required string Email { get; set; }
        public required string Password { get; set; }

        public required DateTime DateOfBirth { get; set; }

        public required PrimaryPurpose PrimaryOccupation;

    }
}
