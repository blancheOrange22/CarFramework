using Framework.Elements;
using OpenQA.Selenium;

namespace CarTests.Pages
{
    public class ChooseCarPage : BasePage
    {
        Element makeDrDwn = new Element(By.XPath("//select[contains(@name, 'makeDropDown')]"), "Option make");
        Element modelDrDwn = new Element(By.XPath("//select[contains(@name, 'modelDropDown')]"), "Option model");
        Element yearDrDwn = new Element(By.XPath("//select[contains(@name, 'yearDropDown')]"), "Option year");
        Element searchBtn = new Element(By.XPath("//div[contains(@class, 'search-button')]//a[contains(@class, 'cui-button')]"), "Btn");
        Element carYearLnk = new Element(By.XPath("//cars-breadcrumbs//a[contains(@cars-common-omniture-standard, 'back-to-model-details')]"), "Car year feature");
        Element carNameLbl = new Element(By.XPath("//div[contains(@class, 'header__title-year')]//h1[contains(@class, 'cui-alpha')]"), "Car Name Label");

        public void ChooseMakeOPtion(string make, string model, string year)
        {
            makeDrDwn.SelectOption(make);
            modelDrDwn.SelectOption(model);
            yearDrDwn.SelectOption(year);

            searchBtn.Click();
            carYearLnk.Click();
        }
    }
}
