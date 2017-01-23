using Framework.Elements;
using OpenQA.Selenium;

namespace CarTests.Pages
{
    public class ViewCarsComparePage : BasePage
    {
        Element engine1Lbl = new Element(By.XPath("//cars-compare-compare-info[contains(@header, 'Engine')]//span[contains(@class, 'info-data')]//p"), "Engine of the first car");
        Element engine2Lbl = new Element(By.XPath("//cars-compare-compare-info[contains(@header, 'Engine')]//span[contains(@class, 'info-data')]//p[contains(@ng-repeat, 'listItem in value track by')]"), "Engine of the second car");
        Element transmission1Lbl = new Element(By.XPath("//cars-compare-compare-info[contains(@header, 'Transmission')]//span[contains(@class, 'info-data')]//p"), "Transmission of the first car");
        Element transmission2Lbl = new Element(By.XPath("//cars-compare-compare-info[contains(@header, 'Transmission')]//span[contains(@class, 'info-data')]//p[contains(@ng-repeat, 'listItem in value track by')]"), "Transmission of the second car");

        public string GetEngineFirstCar()
        {
            return engine1Lbl.GetText();
        }

        public string GetTransmissionFirstCar()
        {
            return transmission1Lbl.GetText();
        }

        public string GetEngineSecondCar()
        {
            return engine2Lbl.GetText();
        }

        public string GetTransmissionSecondCar()
        {
            return transmission2Lbl.GetText();
        }
    }
}
