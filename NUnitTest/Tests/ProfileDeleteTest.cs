using NUnit.Framework;
using NUnitTest.Utils;
using Framework.CommonHelpers;
using Framework.Pages.Home;
using Framework.Pages.Profile.Sections;

namespace NUnitTest.Tests
{
    [TestFixture]
    [Category("ProfileEntryDelete")]
    class ProfileDeleteTest:Base
    {
        [Test]
        public void DeleteProfile()
        {
            //Starting Extent report
            ReportHelpers.test = ReportHelpers.extent.StartTest("Deleting Profile entries");

            //Created object to interact with HomePage and SignInPage classes and their methods
            HomePage HomePageObj = new HomePage();
            SignInPage SignInPageObj = new SignInPage();
            //Called objects to run methods of these classes
            HomePageObj.Open();
            HomePageObj.OpenLoginForm();
            SignInPageObj.LogInSteps();

            //Created object to interact with ManageListings class and its methods
            MainProfileSection MainProfileSectionObj = new MainProfileSection();

            //Called object to run DeleteProfile and VerifyDeleteProfile methods
            MainProfileSectionObj.DeleteProfile();
            MainProfileSectionObj.VerifyDeleteProfile();
        }
    }
}
