using BoDi;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Framework.CommonHelpers;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;
using RelevantCodes.ExtentReports;

namespace SpecflowTest.TestUtils
{
    [Binding]
    class TestBase
    {
        //IOC object container using for dependency injection
        private readonly IObjectContainer _objectContainer;

        public TestBase(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void Setup()
        {
            //launch the browser
            Initialize();
        }

        private IWebDriver Initialize()
        {
            //Defining the browser   
            Driver.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            //Implimented implicit wait
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _objectContainer.RegisterInstanceAs(Driver.driver);
            //Maximise the window
            Driver.driver.Manage().Window.Maximize();
            //Navigating to the App Url
            Driver.driver.Navigate().GoToUrl(Paths.AppUrl);

            
            //Initializing Extent report
            ReportHelpers.extent = new ExtentReports(Paths.SpecFlowReportPath, false, DisplayOrder.NewestFirst);
            //load extent configuration
            ReportHelpers.extent.LoadConfig(Paths.ConfigPath);
            ReportHelpers.test = ReportHelpers.extent.StartTest("MARS Automation Test", "Test case execution for Mars");

            return Driver.driver;
        }

        [AfterScenario]
        public void TearDown()
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
                ReportHelpers.test.Log(LogStatus.Pass, "Test Passed");
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

