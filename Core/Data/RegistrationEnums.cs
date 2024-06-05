using System.ComponentModel;

namespace Core.Data
{
    public class RegistrationEnums
    {
        public enum EmploymentStatus
        {
            [Description("Employed")]
            Employed,
            [Description("Self-Employed")]
            SelfEmployed
            // add more types later
        }

        public enum EstimatedAnnualIncome
        {
            [Description("More than 5 million")]
            MoreThanFiveMillion,
            [Description("1-5 million")]
            LessThanFiveMillion
            // add more types later
        }

        public enum EstimatedValueSavings
        {
            [Description("More than 5 million")]
            MoreThanFiveMillion,
            [Description("1-5 million")]
            LessThanFiveMillion
            // add more types later
        }

        public enum FinancialRisk
        {
            [Description("More than 5 million")]
            MoreThanFiveMillion,
            [Description("1-5 million")]
            LessThanFiveMillion
            // add more types later
        }

        public enum MaximumSizePosition
        {
            [Description("$50,000")]
            FiftyThousand,
            [Description("$5,000")]
            FiveThousand
            // add more types later
        }

        public enum Occupation
        {
            [Description("Accountancy")]
            Accountancy,
            [Description("Accountancy")]
            Administrative
            // add more types later
        }

        public enum OpenPositionMayClose
        {
            [Description("The market is moving against my position and I don't have enough equity to meet the margin requirement")]
            AgainstMyPosition,
            [Description("The market is moving in favor of my position")]
            InFavorOfMyPosition
        }

        public enum PrimaryPurpose
        {
            [Description("Intraday trading")]
            IntradayTrading,
            [Description("Speculation")]
            Speculation
            // add more types here
        }

        public enum EstimatedSavingsAndInvestments
        {
            [Description("Employment")]
            Employment,
            [Description("Inheritance")]
            Inheritance
            // add more types later
        }

        public enum TradingWithLeverage
        {
            [Description("It may increase profits or losses")]
            IncreaseProfits,
            [Description("Trading with leverage is risk free")]
            RiskFree
            // add more types later
        }
    }
}
