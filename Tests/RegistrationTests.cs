using Tools;
using NUnit.Framework.Internal;
using static Core.Data.RegistrationEnums;
using Bogus;

namespace Tests
{
    public class RegistrationTests : BaseTest
    {
        [NonParallelizable]
        [Test, TestCaseSource(nameof(GetTestData))]
        public void RegistrationTest(PersonData data)
        {
            Console.WriteLine($"Start test for {data.Country} user");

            avaTradeHomePage.InitiateAccountRegistration();
            initialSignUpPage.FillPageDataAndCreateAccount(data);
            personalDetailsPage.FillPageDataAndContinue(data);
            financialDetailsPage.FillPageDataAndContinue(data);

            if (data.IsEducational)
            {
                tradingExpiriencePage.WaitForPageLoading();
                tradingExpiriencePage.FillPageDataAndContinue(data);
            }

            termsAndConditionsPage.WaitForPageLoading();
            termsAndConditionsPage.CompleteRegistration();

            if (warningPage.IsWarningPageDisplayed())
            {
                warningPage.WaitForPageLoading();
                warningPage.Agree();
                warningPage.CompleteRegistration();
            }

            almostTherePage.WaitForPageLoading();

            if (almostTherePage.IsVerificationButtonVisible())
            {
                almostTherePage.OpenVerificationPage();

                if (uploadDocumentsPage.IsDisplayed())
                {
                    uploadDocumentsPage.WaitForPageLoading();

                    Assert.IsTrue(uploadDocumentsPage.IsCustomerIdentityVerificationDisplayed(),
                        "Customer Identity Verification doesn't exist");
                    Assert.IsTrue(uploadDocumentsPage.IsUploadFrontIDCardDisplayed(),
                        "Other documents upload section doesn't exist");
                    Assert.IsTrue(uploadDocumentsPage.IsOtherDocumentsUploadDisplayed(),
                        "Other documents upload section doesn't exist");

                    uploadDocumentsPage.NavigateToMainPage();
                }
                else if (verifyAccountPage.IsDisplayed())
                {
                    verifyAccountPage.WaitForPageLoading();

                    Assert.IsTrue(verifyAccountPage.IsIdentityVerificationTabDisplayed(),
                        "Identity Verification tab doesn't exist");
                    Assert.IsTrue(verifyAccountPage.IsCorporateAccountDisplayed(),
                        "Corporate Account tab doesn't exist");
                    Assert.IsTrue(verifyAccountPage.IsPoaTabDisplayed(),
                        "POA tab doesn't exist");

                    verifyAccountPage.OpenMobileScanCard();
                    verifyAccountPage.WaitTillMobileScanPageElementsAreDisplayed();

                    verifyAccountPage.NavigateToMainPage();
                }
            }
            else
            {
                almostTherePage.CloseDialog();
            }

            mainPage.WaitForPageLoading();
            mainPage.CloseTutorialDialogIfAppears();

            Assert.IsTrue(mainPage.AreIconsDisplayed(), "Icons on trading page is not displayed");
        }

        /// <summary>
        /// Used for provide dynamic test data
        /// </summary>
        /// <returns>Collections of items that will be used for tests. Number of items defines number of tests to execute</returns>
        private static IEnumerable<PersonData> GetTestData()
        {
            // Faker library allowing random data generation
            // more info here: https://github.com/bchavez/Bogus
            yield return new Faker<PersonData>()
                .RuleFor(o => o.IsEducational, f => false)
                .RuleFor(o => o.FirstName, f => f.Name.FirstName())
                .RuleFor(o => o.LastName, f => f.Name.LastName())
                .RuleFor(o => o.PhoneNumber, f => f.Phone.PhoneNumber("#######"))
                // User`s age should be between 18 and 60
                .RuleFor(o => o.DateOfBirth, f => f.Date.Between(DateTime.Today.AddYears(-60), DateTime.Today.AddYears(-18)))
                .RuleFor(o => o.Country, f => "Afghanistan")
                .RuleFor(o => o.City, f => f.Address.City())
                .RuleFor(o => o.StreetName, f => f.Address.StreetName())
                .RuleFor(o => o.BuildingNumber, f => f.Address.BuildingNumber())
                .RuleFor(o => o.PostalCode, f => f.Address.ZipCode())
                .RuleFor(o => o.Email, f => f.Internet.ExampleEmail())
                .RuleFor(o => o.PrimaryOccupation, f => PrimaryOccupation.Accountancy)
                .RuleFor(o => o.EmploymentStatus, f => EmploymentStatus.Employed)
                .RuleFor(o => o.SourceOfFunds, f => SourceOfFunds.Inheritance)
                .RuleFor(o => o.EstimatedAnnualIncome, f => EstimatedAnnualIncome.FiveHundredThousandOneMillion)
                .RuleFor(o => o.EstimatedValueSavings, f => EstimatedValueSavings.OneFiveMillions)
                .RuleFor(o => o.FinancialRisk, f => FinancialRisk.FiveHundredThousandOneMillion)
                //TODO: add password generator with minimum 8 symbols, one UpperCase, one LowerCase, one numeric, one special symbol
                .RuleFor(o => o.Password, f => "$LSsvm134!bdfFS")
                .Generate();
            yield return new Faker<PersonData>()
                .RuleFor(o => o.IsEducational, f => true)
                .RuleFor(o => o.FirstName, f => f.Name.FirstName())
                .RuleFor(o => o.LastName, f => f.Name.LastName())
                .RuleFor(o => o.PhoneNumber, f => f.Phone.PhoneNumber("#######"))
                // User`s age should be between 18 and 60
                .RuleFor(o => o.DateOfBirth, f => f.Date.Between(DateTime.Today.AddYears(-60), DateTime.Today.AddYears(-18)))
                .RuleFor(o => o.Country, f => "France")
                .RuleFor(o => o.City, f => f.Address.City())
                .RuleFor(o => o.StreetName, f => f.Address.StreetName())
                .RuleFor(o => o.BuildingNumber, f => f.Address.BuildingNumber())
                .RuleFor(o => o.PostalCode, f => f.Address.ZipCode())
                .RuleFor(o => o.Email, f => f.Internet.ExampleEmail())
                .RuleFor(o => o.PrimaryOccupation, f => PrimaryOccupation.Accountancy)
                .RuleFor(o => o.EmploymentStatus, f => EmploymentStatus.Employed)
                .RuleFor(o => o.SourceOfFunds, f => SourceOfFunds.Inheritance)
                .RuleFor(o => o.EstimatedAnnualIncome, f => EstimatedAnnualIncome.FiveHundredThousandOneMillion)
                .RuleFor(o => o.EstimatedValueSavings, f => EstimatedValueSavings.OneFiveMillions)
                .RuleFor(o => o.FinancialRisk, f => FinancialRisk.FiveHundredThousandOneMillion)

                .RuleFor(o => o.TradingExperienceExtent, f => TradingExperienceExtent.ElevenTwentyFive)
                .RuleFor(o => o.EstimatedValueOfTrades, f => EstimatedValueOfTrades.LessThanTwentyFiveThousand)
                .RuleFor(o => o.TradingWithLeverageStatement, f => TradingWithLeverageStatement.RiskFree)
                .RuleFor(o => o.MaximumSizePosition, f => MaximumSizePosition.FiveThousand)
                .RuleFor(o => o.OpenPositionMayClose, f => OpenPositionMayClose.InFavorOfMyPosition)
                .RuleFor(o => o.PrimaryPurpose, f => PrimaryPurpose.HedgingOfExposure)

                //TODO: add password generator with minimum 8 symbols, one UpperCase, one LowerCase, one numeric, one special symbol
                .RuleFor(o => o.Password, f => "Q$ds2!DSfFx")
                .Generate();
        }
    }
}