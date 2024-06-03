using Tools;
using NUnit.Framework.Internal;
using Core.Data;
using Core.Pages.AvaTrade.Registration;

namespace Tests
{
    public class RegistrationTests : BaseTest
    {
        private readonly ATInitialSignUpPage initialSignUpPage = new ATInitialSignUpPage();

        [Test, TestCaseSource(nameof(GetTestData))]
        public void RegistrationTest(Person personData)
        {
            avaTradeHomePage.InitiateAccountRegistration();

            initialSignUpPage.WaitForPageLoading();
            
            Assert.IsTrue(initialSignUpPage.IsCountryDropdownVisible(), "Country dropdown is not displayed");

            initialSignUpPage.FulfillInitialInformation(personData.Country, personData.Email, personData.Password);
        }

        public static IEnumerable<Person> GetTestData()
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