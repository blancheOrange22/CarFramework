using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Framework.Config;
using System;

namespace Framework.DriverFactory
{
    public class Driver
    {
        private static XMLReader mydata = new XMLReader();
        public static IWebDriver driver = null;

        public static void Initialize()
        {
            Driver d = new Driver();
            if (driver == null)
            {
                if (mydata.browser == "Chrome")
                {
                    driver = new ChromeDriver();
                }
                else if (mydata.browser == "Firefox")
                {
                    driver = new FirefoxDriver();
                }
            }

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(mydata.timeWait));
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(mydata.timeWait));
            driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(mydata.timeWait));
        }

        //public static void WaitAjax()
        //{
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(mydata.timeWait));
        //    wait.Until(driver =>
        //    {
        //        return (bool)(driver as IJavaScriptExecutor).ExecuteScript("return $.active == 0");
        //    });
        //}

        public static void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static string GetTitle()
        {
            return driver.Title;
        }

        public static void Quit()
        {
            if (driver != null)
                driver.Quit();
        }
    }
}
