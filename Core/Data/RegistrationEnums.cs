using Core.Helpers;

namespace Core.Data
{
    /// <summary>
    /// Enum objects that were used in Registration process
    /// </summary>
    public static class RegistrationEnums
    {
        #region Common

        public enum PrimaryOccupation
        {
            [StringValue("Accountancy")]
            Accountancy,
            [StringValue("Administrative")]
            Administrative,
            [StringValue("Agriculture")]
            Agriculture,
            [StringValue("Creative / media / marketing / PR / advertising")]
            CreativeEtc,
            [StringValue("Broker/Dealer")]
            BrokerDealer,
            [StringValue("Catering/Hospitality/Tourism")]
            CateringEtc,
            [StringValue("Construction/Real Estate")]
            ConstructionRealEstate,
            [StringValue("Education")]
            Education,
            [StringValue("Emergency Services")]
            EmergencyServices,
            [StringValue("Financial Services-Banking")]
            FinancialServicesBanking
        }

        public enum EmploymentStatus
        {
            [StringValue("Employed")]
            Employed,
            [StringValue("Self-Employed")]
            SelfEmployed,
            [StringValue("Retired")]
            Retired,
            [StringValue("Student")]
            Student,
            [StringValue("Unemployed")]
            Unemployed
        }

        public enum SourceOfFunds
        {
            [StringValue("Employment")]
            Employment,
            [StringValue("Inheritance")]
            Inheritance,
            [StringValue("Investment")]
            Investment,
            [StringValue("Real Estate")]
            RealEstate,
            [StringValue("Savings")]
            Savings,
            [StringValue("Other")]
            Other
        }

        public enum EstimatedAnnualIncome
        {
            [StringValue("More than 5 million")]
            MoreThanFiveMillion,
            [StringValue("1-5 million")]
            OneFiveMillions,
            [StringValue("500,000-999,999")]
            FiveHundredThousandOneMillion,
            [StringValue("100,000-499,999")]
            OneHundredFiveHundredThousand,
            [StringValue("50,000-99,999")]
            FiftyThousandOneHundred,
            [StringValue("Less than 50,000")]
            LessThanFiftyThousand
        }

        public enum EstimatedValueSavings
        {
            [StringValue("More than 5 million")]
            MoreThanFiveMillion,
            [StringValue("1-5 million")]
            OneFiveMillions,
            [StringValue("500,000-999,999")]
            FiveHundredThousandOneMillion,
            [StringValue("100,000-499,999")]
            OneHundredFiveHundredThousand,
            [StringValue("50,000-99,999")]
            FiftyThousandOneHundred,
            [StringValue("Less than 50,000")]
            LessThanFiftyThousand
        }

        public enum FinancialRisk
        {
            [StringValue("More than 5 million")]
            MoreThanFiveMillion,
            [StringValue("1-5 million")]
            OneFiveMillions,
            [StringValue("500,000-999,999")]
            FiveHundredThousandOneMillion,
            [StringValue("100,000-499,999")]
            OneHundredFiveHundredThousand,
            [StringValue("50,000-99,999")]
            FiftyThousandOneHundred,
            [StringValue("Less than 50,000")]
            LessThanFiftyThousand
        }

        #endregion

        //TODO: Extend enum options to match app actual dropdown options
        #region Educational

        public enum MaximumSizePosition
        {
            [StringValue("$50,000")]
            FiftyThousand,
            [StringValue("$5,000")]
            FiveThousand
            // add more types later
        }

        public enum OpenPositionMayClose
        {
            [StringValue("The market is moving against my position and I don't have enough equity to meet the margin requirement")]
            AgainstMyPosition,
            [StringValue("The market is moving in favor of my position")]
            InFavorOfMyPosition
        }

        public enum PrimaryPurpose
        {
            [StringValue("Intraday trading")]
            IntradayTrading,
            [StringValue("Speculation")]
            Speculation
            // add more types here
        }

        public enum TradingWithLeverage
        {
            [StringValue("It may increase profits or losses")]
            IncreaseProfits,
            [StringValue("Trading with leverage is risk free")]
            RiskFree
            // add more types later
        }

        #endregion
    }
}
