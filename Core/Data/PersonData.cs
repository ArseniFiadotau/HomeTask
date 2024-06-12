using static Core.Data.RegistrationEnums;

namespace Tools
{
    /// <summary>
    /// User data class. Used to contain all the required info for register user.
    /// Field 'IsEducational' can be used to specify Dynamic behavior
    /// </summary>
    public class PersonData
    {
        public bool IsEducational { get; set; }

        //'required' is a new C# modifier that won't allow compilation if the field will not be defined
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string PhoneNumber { get; set; }

        public required string Country { get; set; } 
        public required string City { get; set; } 
        public required string StreetName { get; set; } 
        public required string BuildingNumber { get; set; } 
        public required string PostalCode { get; set; } 
        public required string Email { get; set; }
        public required string Password { get; set; }

        public required DateTime DateOfBirth { get; set; }

        public required PrimaryOccupation PrimaryOccupation;
        public required EmploymentStatus EmploymentStatus;
        public required SourceOfFunds SourceOfFunds;
        public required EstimatedAnnualIncome EstimatedAnnualIncome;

        public required EstimatedValueSavings EstimatedValueSavings;
        public required FinancialRisk FinancialRisk;

    }
}
