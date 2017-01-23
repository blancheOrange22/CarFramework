using Framework.Elements;
using OpenQA.Selenium;

namespace CarTests.Pages
{
    public class CompareCarsPage : BasePage
    {
        Element addAnotherCar = new Element(By.Id("icon-div"), "Add another Car");

        Element makeDrDwn = new Element(By.Id("make-dropdown"), "Option make");
        Element modelDrDwn = new Element(By.Id("model-dropdown"), "Option model");
        Element yearDrDwn = new Element(By.Id("year-dropdown"), "Option year");
        Element doneBtn = new Element(By.XPath("//div[contains(@class, 'modal-footer')]//button[contains(@class, 'modal-button')]"), "Button Done");

        Element fPriceLbl = new Element(By.XPath("//cars-compare-compare-info//span[contains(@class, 'info-data')]//p"), "Price of the first car");
        Element sPriceLbl = new Element(By.XPath("//div[contains(@ng-switch-when, 'currency')]//p"), "Price of the second car");

        public void AddAnotherCar()
        {
            addAnotherCar.Click();
        }

        public void ChooseCarToCompare(string make, string model, string year)
        {
            makeDrDwn.SelectOption(make);
            modelDrDwn.SelectOption(model);
            yearDrDwn.SelectOption(year);

            doneBtn.Click();
        }

        public bool AreTwoPricesPresent()
        {
            if (fPriceLbl.IsPresent() && sPriceLbl.IsPresent())
                return true;
            else return false;
        }
    }
}
