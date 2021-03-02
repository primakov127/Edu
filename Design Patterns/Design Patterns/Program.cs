using Design_Patterns.Patterns.Proxy;
using System;

namespace Design_Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            YesterdayRate yesterdayRate = new YesterdayRate();
            IYesterdayRate yesterdayRateCached = new YesterdayRateCached(yesterdayRate);
            Console.WriteLine(yesterdayRateCached.GetRate());
        }
    }
}
