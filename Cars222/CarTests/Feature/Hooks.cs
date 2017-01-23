using Framework.DriverFactory;
using TechTalk.SpecFlow;

namespace CarTests.Feature
{
    [Binding]
    public sealed class Hooks
    {
        public string url = "http://www.cars.com";

        [BeforeScenario]
        public void BeforeScenario()
        {
            Driver.Initialize();
            Driver.GoToUrl(url);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Quit();
        }
    }
}
