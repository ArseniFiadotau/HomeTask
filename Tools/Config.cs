using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class Config
    {
        public static int DefaultTimeoutTimeInSec = 10;

        public static string AvaTradeAppPath = Path.Combine(PathHelper.GetSolutionDirectoryInfo().FullName, "Resources", "avatrade-trading-app.apk");
        public static string AvaTradeAppId = "com.avatrade.mobile";
    }
}
