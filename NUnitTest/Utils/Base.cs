using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Framework.CommonHelpers;
using RelevantCodes.ExtentReports;

namespace NUnitTest.Utils
{
    //Inititalizing driver
    public class Base
    {
        [SetUp]
        public void SetUp()
        {
            Inititalize();
        }
        public IWebDriver Inititalize()
        {
            //Created driver for running tests
            Driver.driver = new ChromeDriver();
            //Maximize windows
            Driver.driver.Manage().Window.Maximize();
            //Navigating to the App Url
            Driver.driver.Navigate().GoToUrl(Paths.AppUrl);

            //To obtain the current solution path/project path
            
            //Initializing Extent report
            ReportHelpers.extent = new ExtentReports(Paths.ReportPath, false,DisplayOrder.NewestFirst);
            //load extent configuration
            ReportHelpers.extent.LoadConfig(Paths.ConfigPath);
            
           
            return Driver.driver;
        }

        [TearDown]
        public void AfterTest()
        {           
            //StackTrace details for failed Testcases
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "<pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;
            
            if (status == TestStatus.Failed)
            {
                ReportHelpers.test.Log(LogStatus.Fail, stackTrace + errorMessage);
            }
            else
            {
                ReportHelpers.test.Log(LogStatus.Pass,"Test Passed"); 
            }

            ReportHelpers.extent.EndTest(ReportHelpers.test);

            //Flush report
            ReportHelpers.extent.Flush();
           
            //Closing driver
            Driver.driver.Close();
            Driver.driver.Quit();
        }
    }
}
