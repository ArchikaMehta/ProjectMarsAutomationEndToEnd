using NUnit.Framework;
using Framework.CommonHelpers;
using Framework.Pages.Home;
using Framework.Pages.Profile.Sections;
using NUnitTest.Utils;

namespace NUnitTest.Tests
{
    [TestFixture]
    [Category("AvailabilityDetails")]
    class AvailabilityDetailsTest: Base
    {
        [Test]
        public void AvailabilityDetails()
        {
            //Starting Extent report 
            ReportHelpers.test = ReportHelpers.extent.StartTest("Adding Availability details in the Profile");

            //Created object to interact with HomePage and SignInPage classes and their methods
            HomePage HomePageObj = new HomePage();
            SignInPage SignInPageObj = new SignInPage();
            //Called objects to run methods of these classes
            HomePageObj.Open();
            HomePageObj.OpenLoginForm();
            SignInPageObj.LogInSteps();

            //Created object to interact with AvailabilitySection class and its methods
            AvailabilitySection AvailabilitySectionObj = new AvailabilitySection();

            //Called object to run AvailabilityDetails method
            AvailabilitySectionObj.AvailabilityDetails();
        }
    }
}
