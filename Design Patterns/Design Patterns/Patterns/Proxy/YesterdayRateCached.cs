using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns.Patterns.Proxy
{
    public class YesterdayRateCached : IYesterdayRate
    {
        private YesterdayRate _yesterdayRate;
        private int? _cachedRate;

        public YesterdayRateCached(YesterdayRate yesterdayRate)
        {
            _yesterdayRate = yesterdayRate;
        }

        public int GetRate()
        {
            if (_cachedRate == null)
            {
                _cachedRate = _yesterdayRate.GetRate();
            }
            return (int)_cachedRate;
        }
    }
}
