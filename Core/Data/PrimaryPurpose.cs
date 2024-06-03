using System.ComponentModel;

namespace Core.Data
{
    public enum PrimaryPurpose
    {
        [Description("Intraday trading")]
        IntradayTrading,
        [Description("Speculation")]
        Speculation
        // add more types here
    }
}
