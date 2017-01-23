using OpenQA.Selenium.Support.PageObjects;
using Framework.DriverFactory;

namespace CarTests.Pages
{
    public class BasePage
    {
        public BasePage()
        {
            PageFactory.InitElements(Driver.driver, this);
        }
    }
}
