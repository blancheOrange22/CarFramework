using CarTests.Menus;
using Framework.Elements;
using OpenQA.Selenium;

namespace CarTests.Pages
{
    public class CarModificationPage : BasePage
    {
        Element engineLbl = new Element(By.XPath("//table[contains(@class, 'overview-table')]//td[contains(@id, 'engine')]"), "Engine value");
        Element transmissionLbl = new Element(By.XPath("//table[contains(@class, 'overview-table')]//td[contains(@id, 'transmission')]"), "Transmission value");
        Element menuTrim = new Element(By.LinkText("Trims"), "Menu Trims");
        Element compareCheckbox = new Element(By.XPath("//label[@id='checkbox-trim-']"), "Checkbox Compare");
        Element compareBtn = new Element(By.XPath("//div[contains(@class, 'compare-button')]//button[contains(., 'Compare Now')]"), "Compare Button");

        Menu menu = new Menu();

        public string GetEngine()
        {
            return engineLbl.GetText();
        }

        public string GetTransmission()
        {
            return transmissionLbl.GetText();
        }

        public void GoToCompareForm()
        {
            menuTrim.Click();
            compareCheckbox.Click();
            compareBtn.Click();
        }

        public void GoToCarCatalogue()
        {
            menu.OpenItem("Buy", "Review a Car");
        }
    }
}
