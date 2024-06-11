using Tools;
using NUnit.Framework.Internal;
using Core.Pages.AvaTrade.Registration;
using static Core.Data.RegistrationEnums;
using Core.Pages.AvaTrade.Registration.PersonalData;
using Bogus;
using Core.Helpers;

namespace Tests
{
    public class RegistrationTests : BaseTest
    {
        private readonly ATInitialSignUpPage initialSignUpPage = new ATInitialSignUpPage();
        private readonly ATBasicPersonalDetailsPage basicPersonalDetailsPage = new ATBasicPersonalDetailsPage();
        private readonly ATAddressPersonalDetailsPage addressPersonalDetailsPage = new ATAddressPersonalDetailsPage();

        [Test, TestCaseSource(nameof(GetTestData))]
        public void RegistrationTest(PersonData personData)
        {
            avaTradeGuestPage.InitiateAccountRegistration();

            initialSignUpPage.WaitForPageLoading();
            initialSignUpPage.FillPageDataAndCreateAccount(personData.Country, personData.Email, personData.Password);

            basicPersonalDetailsPage.WaitForPageLoading();
            basicPersonalDetailsPage.FillPageDataAndContinue(personData.FirstName, personData.LastName, personData.DateOfBirth, personData.PhoneNumber);

            addressPersonalDetailsPage.WaitForPageLoading();
        }

        private static IEnumerable<PersonData> GetTestData()
        {
            yield return new Faker<PersonData>()
                .StrictMode(true)
                .RuleFor(o => o.FirstName, f => f.Name.FirstName())
                .RuleFor(o => o.LastName, f => f.Name.LastName())
                .RuleFor(o => o.PhoneNumber, f => f.Phone.PhoneNumber("#######"))
                .RuleFor(o => o.DateOfBirth, f => f.Date.Between(DateTime.Today.AddYears(-60), DateTime.Today.AddYears(-18)))
                .RuleFor(o => o.Country, f => "Afghanistan")
                .RuleFor(o => o.City, f => f.Address.City())
                .RuleFor(o => o.StreetName, f => f.Address.StreetName())
                .RuleFor(o => o.BuildingNumber, f => f.Address.BuildingNumber())
                .RuleFor(o => o.PostalCode, f => f.Address.ZipCode())
                .RuleFor(o => o.Email, f => f.Internet.ExampleEmail())
                .RuleFor(o => o.PrimaryOccupation, f => PrimaryPurpose.IntradayTrading)
                .RuleFor(o => o.Password, f => "$LSsvm134!bdfFS")
                .RuleFor(o => o.PhoneNumber, f => f.Phone.PhoneNumber("#######"))
                .Generate();
        }
    }
}