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

        #region Educational

        public enum TradingExperienceExtent
        {
            [StringValue("0")]
            Zero,
            [StringValue("1-10")]
            OneTen,
            [StringValue("11-25")]
            ElevenTwentyFive,
            [StringValue("26-50")]
            TwentySixFixty,
            [StringValue("More than 50")]
            MoreThanFifty
        }

        public enum EstimatedValueOfTrades
        {
            [StringValue("0")]
            Zero,
            [StringValue("1-999")]
            LessThanThousand,
            [StringValue("1,000-24,999")]
            LessThanTwentyFiveThousand,
            [StringValue("25,000-50,000")]
            LessThanFiftyThousand,
            [StringValue("50,000-250,000")]
            LessThanTwoHundredFiftyThousand,
            [StringValue("Over 250,000")]
            OverTwoHundredFiftyThousand,
        }
        public enum TradingWithLeverageStatement
        {
            [StringValue("It may increase profits or losses")]
            IncreaseProfits,
            [StringValue("Trading with leverage is risk free")]
            RiskFree,
            [StringValue("None of the above")]
            None
        }

        public enum MaximumSizePosition
        {
            [StringValue("$50,000")]
            FiftyThousand,
            [StringValue("$5,000")]
            FiveThousand,
            [StringValue("$500,000")]
            FiveHundredThousand
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
            [StringValue("Short/medium term investments")]
            ShortMediumInvestment,
            [StringValue("Speculation")]
            Speculation,
            [StringValue("Hedging of exposure to an underlying asset")]
            HedgingOfExposure,
            [StringValue("Investment portfolio diversification")]
            InvestmentPortfolio,
            [StringValue("Buy & hold investment")]
            BuyAndHold,
            [StringValue("Capital preservation")]
            CapitalPreservation
        }

        #endregion
    }
}
