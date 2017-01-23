using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.DriverFactory;
using log4net;
using Framework.LogHelper;

namespace CarTests.Tests
{
    [TestClass]
    public class BaseTest
    {
        public ILog logger = Logger.GetLogger(typeof(BaseTest));

        [TestInitialize]
        public void Initialize()
        {
            logger.Info("Start browser");
            Driver.Initialize();
        }

        [TestCleanup]
        public void CleanUp()
        {
            logger.Info("Quit browser");
            Driver.Quit();
        }
    }
}
