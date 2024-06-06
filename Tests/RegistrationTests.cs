using Tools;
using NUnit.Framework.Internal;
using Core.Pages.AvaTrade.Registration;
using static Core.Data.RegistrationEnums;

namespace Tests
{
    public class RegistrationTests : BaseTest
    {
        private readonly ATInitialSignUpPage initialSignUpPage = new ATInitialSignUpPage();
        private readonly ATPersonalDetails25Page personalDetails25 = new ATPersonalDetails25Page();

        [Test, TestCaseSource(nameof(GetTestData))]
        public void RegistrationTest(Person personData)
        {
            avaTradeGuestPage.InitiateAccountRegistration();

            initialSignUpPage.WaitForPageLoading();
            initialSignUpPage.FulfillInitialInformation(personData.Country, personData.Email, personData.Password);

            personalDetails25.WaitForPageLoading();
        }

        private static IEnumerable<Person> GetTestData()
        {
            yield return new Person
            {
                FirstName = Faker.Name.First(),
                LastName = Faker.Name.Last(),
                PhoneNumber = Faker.Phone.Number(),
                DateOfBirth = Faker.Identification.DateOfBirth(),
                Country = "Afghanistan",
                City = Faker.Address.City(),
                StreetName = Faker.Address.StreetName(),
                HouseNumbur = Faker.RandomNumber.Next(100),
                PostalCode = Faker.RandomNumber.Next(4000, 6000).ToString(),
                Email = Faker.Internet.Email(),
                PrimaryOccupation = PrimaryPurpose.IntradayTrading,
                Password = "P@$$w0rd"
            };
        }
    }
}