using System.Collections.Generic;
using SpecFlowIntro.App.Domain;

namespace SpecFlowIntro.App
{
    public class Config
    {
        private Config()
        {
        }

        public static Config Instance = new Config();

        public IEnumerable<LifeExpectancy> LifeExpectancies { get; set; }
        public decimal MonthlyFactor { get; set; } = 1.1m;
    }
}