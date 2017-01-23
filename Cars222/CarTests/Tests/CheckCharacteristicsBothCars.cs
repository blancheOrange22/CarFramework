using Framework.DriverFactory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarTests.Pages;                                 
using System.Collections.Generic;

namespace CarTests.Tests
{
    [TestClass]
    public class CheckCharacteristicsBothCars : BaseTest
    {
        [TestMethod]
        public void CheckCharacteristics()
        {
            Dictionary<string, string> expectedTitles = new Dictionary<string, string>();
            expectedTitles["mainPage"] = "New Cars, Used Cars, Trucks For Sale, Auto Reviews | Cars.com";
            expectedTitles["homePage"] = "New Car Reviews | Cars.com";
            expectedTitles["choosePage1"] = "2010 Ford Explorer Reviews, Specs and Prices | Cars.com";
            expectedTitles["modPage"] = "2010 Ford Explorer XLT 4dr 4x2 | Cars.com";
            expectedTitles["choosePage2"] = "2015 BMW 228 Reviews, Specs and Prices | Cars.com";

            Dictionary<string, string> expCarFeatures = new Dictionary<string, string>();
            expCarFeatures["engine1"] = "210-hp, 4.0-liter V-6 (regular gas)";
            expCarFeatures["transmission1"] = "5-speed automatic w/OD";
            expCarFeatures["engine2"] = "240-hp, 2.0-liter I-4 (premium)";
            expCarFeatures["transmission2"] = "6-speed manual w/OD";

            Dictionary<string, string> actCarFeatures = new Dictionary<string, string>();
            string menuItem = "Buy", subMenuItem = "Review a Car";

            string baseUrl = "http://www.cars.com";
            Driver.GoToUrl(baseUrl);
            logger.Info("Go to url " + baseUrl);
            Assert.AreEqual(expectedTitles["mainPage"], Driver.GetTitle());

            HomePage homePage = new HomePage();
            logger.Info("Choose inset Buy and Review Car");
            homePage.GoToCarCatalogue(menuItem, subMenuItem);

            Assert.AreEqual(expectedTitles["homePage"], Driver.GetTitle());

            ChooseCarPage choosePage = new ChooseCarPage();
            actCarFeatures["make1"] = "Ford";
            actCarFeatures["model1"] = "Explorer";
            actCarFeatures["year1"] = "2010";
            logger.Info("Choose options make " + actCarFeatures["make1"] + ", model " + actCarFeatures["model1"] + ", year " + actCarFeatures["year1"]);
            choosePage.ChooseMakeOPtion(actCarFeatures["make1"], actCarFeatures["model1"], actCarFeatures["year1"]);

            Assert.AreEqual(expectedTitles["choosePage1"], Driver.GetTitle());

            ChooseCarModificationPage modPage = new ChooseCarModificationPage();
            logger.Info("Choose first available trim");
            modPage.ChooseCarMod();

            Assert.AreEqual(expectedTitles["modPage"], Driver.GetTitle());

            CarModificationPage fCarPage = new CarModificationPage();
            actCarFeatures["engine1"] = fCarPage.GetEngine();
            actCarFeatures["transmission1"] = fCarPage.GetTransmission();
            logger.Info("Get value of engine " + actCarFeatures["engine1"] + " and transmission " + actCarFeatures["transmission1"] + " of the first car");

            Assert.AreEqual(expCarFeatures["engine1"], actCarFeatures["engine1"]);
            Assert.AreEqual(expCarFeatures["transmission1"], actCarFeatures["transmission1"]);

            logger.Info("Choose options of the second car");
            fCarPage.GoToCarCatalogue();

            actCarFeatures["make2"] = "BMW";
            actCarFeatures["model2"] = "228";
            actCarFeatures["year2"] = "2015";
            choosePage.ChooseMakeOPtion(actCarFeatures["make2"], actCarFeatures["model2"], actCarFeatures["year2"]);
            logger.Info("Choose options make " + actCarFeatures["make2"] + ", model " + actCarFeatures["model2"] + ", year " + actCarFeatures["year2"]);

            Assert.AreEqual(expectedTitles["choosePage2"], Driver.GetTitle());

            modPage.ChooseCarMod();

            actCarFeatures["engine2"] = fCarPage.GetEngine();
            actCarFeatures["transmission2"] = fCarPage.GetTransmission();
            logger.Info("Get value of engine " + actCarFeatures["engine2"] + " and transmission " + actCarFeatures["transmission2"] + " of the first car");

            Assert.AreEqual(expCarFeatures["engine2"], actCarFeatures["engine2"]);
            Assert.AreEqual(expCarFeatures["transmission2"], actCarFeatures["transmission2"]);

            fCarPage.GoToCompareForm();

            CompareCarsPage comparePage = new CompareCarsPage();
            comparePage.AddAnotherCar();
            comparePage.ChooseCarToCompare(actCarFeatures["make1"], actCarFeatures["model1"], actCarFeatures["year1"]);
            logger.Info("Choose options make " + actCarFeatures["make1"] + ", model " + actCarFeatures["model1"] + ", year " + actCarFeatures["year1"]);

            Assert.IsTrue(comparePage.AreTwoPricesPresent());

            string expectedResult = expCarFeatures["engine1"] + ", " + expCarFeatures["engine2"] + ", " + expCarFeatures["transmission1"] + ", " + expCarFeatures["transmission2"];
            string actualResult = actCarFeatures["engine1"] + ", " + actCarFeatures["engine2"] + ", " + actCarFeatures["transmission1"] + ", " + actCarFeatures["transmission2"];

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
