using SpecFlowIntro.App;

namespace SpecFlowIntro.Tests
{
    public class BasicContext
    {
        public Facade Facade { get; } = Facade.Instance;

        public Config Config { get; } = Config.Instance;
    }
}
