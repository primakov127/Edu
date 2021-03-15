using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns.Patterns.Proxy
{
    public class YesterdayRate : IYesterdayRate
    {
        public int GetRate()
        {
            // Imagine it's a exchange rate
            return 500;
        }
    }
}
