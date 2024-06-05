using Tools;
using NUnit.Framework.Internal;
using Core.Pages.AvaTrade.Registration;
using Core.Pages;
using static Core.Data.RegistrationEnums;

namespace Tests
{
    public class RegistrationTests : BaseTest
    {
        private readonly ATInitialSignUpPage initialSignUpPage = new ATInitialSignUpPage();
        private readonly ATGuestPage guestPage = new ATGuestPage();

        [Test, TestCaseSource(nameof(GetTestData))]
        public void RegistrationTest(Person personData)
        {
            guestPage.InitiateAccountRegistration();

            initialSignUpPage.WaitForPageLoading();
            
            Assert.IsTrue(initialSignUpPage.IsCountryDropdownVisible(), "Country dropdown is not displayed");

            initialSignUpPage.FulfillInitialInformation(personData.Country, personData.Email, personData.Password);
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