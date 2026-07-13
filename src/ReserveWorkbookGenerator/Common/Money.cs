using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveWorkbookGenerator.Common
{
    public static class Money
    {
        public static decimal Round(decimal value)
        {
            return Math.Round(
                value,
                2,
                MidpointRounding.AwayFromZero);
        }
        public static decimal Divide(decimal numerator, decimal denominator)
        {
            if (denominator == 0)
                return 0m;

            return numerator / denominator;
        }
        public static decimal Percent(decimal value, decimal total)
        {
            return Divide(value, total);
        }
    }
}
