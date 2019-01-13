using System;

namespace SpecFlowIntro.App.Domain
{
    public class Discount
    {
        public Discount(int percentageValue, DateTime expiresAt)
        {
            PercentageValue = percentageValue;
            ExpiresAt = expiresAt;
        }

        public int PercentageValue { get;}

        public DateTime ExpiresAt { get; }
    }
}