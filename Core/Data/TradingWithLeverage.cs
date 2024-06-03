using System.ComponentModel;

namespace Core.Data
{
    public enum TradingWithLeverage
    {
        [Description("It may increase profits or losses")]
        IncreaseProfits,
        [Description("Trading with leverage is risk free")]
        RiskFree
        // add more types later
    }
}
