using Framework.Elements;
using OpenQA.Selenium;

namespace CarTests.Pages
{
    public class ChooseCarModificationPage : BasePage
    {
        Element menuTrim = new Element(By.LinkText("Trims"), "Menu Trims");
        Element carModificationLnk = new Element(By.XPath("//div[contains(@class, 'listing__footer')]//div[contains(@class, 'footer_section')]//a[contains(., 'View Details')]"), "Modification car");
        Element carNameLbl = new Element(By.XPath("//div[contains(@class, 'full-headline-container')]//h1[contains(@class, 'cui-alpha')]"), "Car name label");

        public void ChooseCarMod()
        {
            menuTrim.Click();
            carModificationLnk.Click();
        }

        public bool IsCarNamePresent()
        {
            return carNameLbl.IsPresent();
        }
    }
}
