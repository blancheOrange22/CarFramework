using CarTests.Pages;
using Framework.DriverFactory;
using Framework.LogHelper;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace CarTests
{
    [Binding]
    public class CompareTwoCarsSteps
    {
        Dictionary<string, string> expectedTitles = new Dictionary<string, string>();
        Dictionary<string, string> expCarFeatures = new Dictionary<string, string>();
        Dictionary<string, string> actCarFeatures = new Dictionary<string, string>();
        Dictionary<string, string> result = new Dictionary<string, string>();

        HomePage homePage = new HomePage();
        ChooseCarPage choosePage = new ChooseCarPage();
        ChooseCarModificationPage modPage = new ChooseCarModificationPage();
        CarModificationPage fCarPage = new CarModificationPage();
        CompareCarsPage comparePage = new CompareCarsPage();

        public readonly ILog logger = Logger.GetLogger(typeof(CompareTwoCarsSteps));

        [Given(@"I have expected mainPage title '(.*)'")]
        public void GivenIHaveExpectedMainPageTitle(string expTitle)
        {
            expectedTitles["mainPage"] = expTitle;
        }
        
        [Given(@"I have expected homePage title '(.*)'")]
        public void GivenIHaveExpectedHomePageTitle(string expTitle)
        {
            expectedTitles["homePage"] = expTitle;
        }
        
        [Given(@"I have expected choosePage title '(.*)'")]
        public void GivenIHaveExpectedChoosePageTitle(string expTitle)
        {
            expectedTitles["choosePage1"] = expTitle;
        }
        
        [Given(@"I have make '(.*)', model '(.*)', year '(.*)' of the first car")]
        public void GivenIHaveMakeModelYearOfTheFirstCar(string make, string model, string year)
        {
            actCarFeatures["make1"] = make;
            actCarFeatures["model1"] = model;
            actCarFeatures["year1"] = year;
        }
        
        [Given(@"I have expected modPage title '(.*)'")]
        public void GivenIHaveExpectedModPageTitle(string expTitle)
        {
            expectedTitles["modPage"] = expTitle;
        }
        
        [Given(@"I have expected engine '(.*)', transmission '(.*)' of the first car")]
        public void GivenIHaveExpectedEngineTransmissionOfTheFirstCar(string engine, string transmission)
        {
            expCarFeatures["engine1"] = engine;
            expCarFeatures["transmission1"] = transmission;
        }
        
        [Given(@"I have the expected choosePage title '(.*)'")]
        public void GivenIHaveTheExpectedChoosePageTitle(string expTitle)
        {
            expectedTitles["choosePage2"] = expTitle;
        }
        
        [Given(@"I have make '(.*)', model '(.*)', year '(.*)' of the second car")]
        public void GivenIHaveMakeModelYearOfTheSecondCar(string make, string model, string year)
        {
            actCarFeatures["make2"] = make;
            actCarFeatures["model2"] = model;
            actCarFeatures["year2"] = year;
        }
        
        [Given(@"I have expected engine '(.*)', transmission '(.*)' of the second car")]
        public void GivenIHaveExpectedEngineTransmissionOfTheSecondCar(string engine, string transmission)
        {
            expCarFeatures["engine2"] = engine;
            expCarFeatures["transmission2"] = transmission;
        }
        
        [When(@"I go to baseUrl '(.*)'")]
        public void WhenIGoToBaseUrl(string baseUrl)
        {
            Driver.GoToUrl(baseUrl);
        }
        
        [When(@"I choose inset '(.*)' in menu and inset '(.*)' in submenu")]
        public void WhenIChooseInsetInMenuAndInsetInSubmenu(string menuItem, string subMenuItem)
        {
            logger.Info("Choose inset Buy and Review Car");
            homePage.GoToCarCatalogue(menuItem, subMenuItem);
        }
        
        [When(@"I choose all these characteristics")]
        public void WhenIChooseAllTheseCharacteristics()
        {
            logger.Info("Choose options make " + actCarFeatures["make1"] + ", model " + actCarFeatures["model1"] + ", year " + actCarFeatures["year1"]);
            choosePage.ChooseMakeOPtion(actCarFeatures["make1"], actCarFeatures["model1"], actCarFeatures["year1"]);
        }
        
        [When(@"I press Trims and View Details")]
        public void WhenIPressTrimsAndViewDetails()
        {
            logger.Info("Choose first available trim");
            modPage.ChooseCarMod();
        }
        
        [When(@"I take actual values of engine and transmission of the first car from the page")]
        public void WhenITakeActualValuesOfEngineAndTransmissionOfTheFirstCarFromThePage()
        {
            actCarFeatures["engine1"] = fCarPage.GetEngine();
            actCarFeatures["transmission1"] = fCarPage.GetTransmission();
            logger.Info("Get value of engine " + actCarFeatures["engine1"] + " and transmission " + actCarFeatures["transmission1"] + " of the first car");
        }
        
        [When(@"I go to car catalogue")]
        public void WhenIGoToCarCatalogue()
        {
            logger.Info("Choose options of the second car");
            fCarPage.GoToCarCatalogue();
        }
        
        [When(@"choose all options of the second car")]
        public void WhenChooseAllOptionsOfTheSecondCar()
        {
            choosePage.ChooseMakeOPtion(actCarFeatures["make2"], actCarFeatures["model2"], actCarFeatures["year2"]);
            logger.Info("Choose options make " + actCarFeatures["make2"] + ", model " + actCarFeatures["model2"] + ", year " + actCarFeatures["year2"]);
        }
        
        [When(@"I take actual values of engine and transmission of the second car from the page")]
        public void WhenITakeActualValuesOfEngineAndTransmissionOfTheSecondCarFromThePage()
        {
            modPage.ChooseCarMod();

            actCarFeatures["engine2"] = fCarPage.GetEngine();
            actCarFeatures["transmission2"] = fCarPage.GetTransmission();
            logger.Info("Get value of engine " + actCarFeatures["engine2"] + " and transmission " + actCarFeatures["transmission2"] + " of the first car");
        }
        
        [When(@"I click inset Trims, choose View Details")]
        public void WhenIClickInsetTrimsChooseViewDetails()
        {
            fCarPage.GoToCompareForm();
        }
        
        [When(@"I click Add another car")]
        public void WhenIClickAddAnotherCar()
        {
            comparePage.AddAnotherCar();
        }
        
        [When(@"I choose all characteristics of the first car to compare")]
        public void WhenIChooseAllCharacteristicsOfTheFirstCarToCompare()
        {
            comparePage.ChooseCarToCompare(actCarFeatures["make1"], actCarFeatures["model1"], actCarFeatures["year1"]);
            logger.Info("Choose options make " + actCarFeatures["make1"] + ", model " + actCarFeatures["model1"] + ", year " + actCarFeatures["year1"]);
        }
        
        [When(@"I compare actual and expected values of engine, transmission of both cars")]
        public void WhenICompareActualAndExpectedValuesOfEngineTransmissionOfBothCars()
        {
            result["expected"] = expCarFeatures["engine1"] + ", " + expCarFeatures["engine2"] + ", " + expCarFeatures["transmission1"] + ", " + expCarFeatures["transmission2"];
            result["actual"] = actCarFeatures["engine1"] + ", " + actCarFeatures["engine2"] + ", " + actCarFeatures["transmission1"] + ", " + actCarFeatures["transmission2"];
        }

        [Then(@"the expected title is equal the actual title")]
        public void ThenTheExpectedTitleIsEqualTheActualTitle()
        {
            Assert.AreEqual(expectedTitles["mainPage"], Driver.GetTitle());
        }


        [Then(@"the expected homePage title is equal the actual title")]
        public void ThenTheExpectedHomePageTitleIsEqualTheActualTitle()
        {
            Assert.AreEqual(expectedTitles["homePage"], Driver.GetTitle());
        }
        
        [Then(@"the expected choosePage title is equal the actual title")]
        public void ThenTheExpectedChoosePageTitleIsEqualTheActualTitle()
        {
            Assert.AreEqual(expectedTitles["choosePage1"], Driver.GetTitle());
        }
        
        [Then(@"the expected modPage title is equal the actual title")]
        public void ThenTheExpectedModPageTitleIsEqualTheActualTitle()
        {
            Assert.AreEqual(expectedTitles["modPage"], Driver.GetTitle());
        }
        
        [Then(@"the expected and actual values are the same")]
        public void ThenTheExpectedAndActualValuesAreTheSame()
        {
            Assert.AreEqual(expCarFeatures["engine1"], actCarFeatures["engine1"]);
            Assert.AreEqual(expCarFeatures["transmission1"], actCarFeatures["transmission1"]);
        }
        
        [Then(@"the expected choosePage title is equal the actual")]
        public void ThenTheExpectedChoosePageTitleIsEqualTheActual()
        {
            Assert.AreEqual(expectedTitles["choosePage2"], Driver.GetTitle());
        }
        
        [Then(@"the expected and actual values are equal")]
        public void ThenTheExpectedAndActualValuesAreEqual()
        {
            Assert.AreEqual(expCarFeatures["engine2"], actCarFeatures["engine2"]);
            Assert.AreEqual(expCarFeatures["transmission2"], actCarFeatures["transmission2"]);
        }
        
        [Then(@"there are two prices of these cars on the page")]
        public void ThenThereAreTwoPricesOfTheseCarsOnThePage()
        {
            Assert.IsTrue(comparePage.AreTwoPricesPresent());
        }
        
        [Then(@"the values are the same")]
        public void ThenTheValuesAreTheSame()
        {
            Assert.AreEqual(result["expected"], result["actual"]);
        }
    }
}
