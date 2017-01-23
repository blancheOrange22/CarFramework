using Framework.DriverFactory;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using Framework.LogHelper;
using Framework.Config;

namespace Framework.Elements
{
    public class Element
    {
        private readonly By locator;
        private readonly string name;
        XMLReader mydata = new XMLReader();

        public Element(By locator, string name)
        {
            this.locator = locator;
            this.name = name;
        }

        public void Click()
        {
            Logger.logger.Info("Click by " + name);
            WebDriverWait wait = new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(mydata.timeWait));
            wait.Until(driver => {
                try
                {
                    IReadOnlyCollection<IWebElement> el = Driver.driver.FindElements(locator);
                    Logger.logger.Info("Found " + el.Count + " by locator " + locator);
                    var element = el.ElementAt<IWebElement>(0);
                    if (element.Displayed && element.Enabled)
                    {
                        element.Click();
                        return true;
                    }
                    return false;
                }
                catch (Exception e)
                {
                    Logger.logger.Info("There was an exception during click by element: " + e.Message);
                    return false;
                }
            });
        }

        public void SelectOption(string text)
        {
            IWebElement element = Driver.driver.FindElement(locator);
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(text);
        }

        public string GetText()
        {
            return Driver.driver.FindElement(locator).Text;
        }

        public bool IsPresent()
        {
            IWebElement element = Driver.driver.FindElement(locator);
            return element.Displayed;
        }
    }
}
