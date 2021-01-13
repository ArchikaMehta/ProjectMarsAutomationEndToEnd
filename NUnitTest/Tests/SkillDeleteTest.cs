using NUnit.Framework;
using NUnitTest.Utils;
using Framework.CommonHelpers;
using Framework.Pages.Home;
using Framework.Pages.ShareSkill;

namespace NUnitTest.Tests
{
    [TestFixture]
    [Category("SkillDelete")]
    class SkillDeleteTest:Base
    {
        [Test]
        public void DeleteShareSkill()
        {
            //Starting Extent report 
            ReportHelpers.test = ReportHelpers.extent.StartTest("Delete ShareSkill entry");

            //Created object to interact with HomePage and SignInPage classes and their methods
            HomePage HomePageObj = new HomePage();
            SignInPage SignInPageObj = new SignInPage();
            //Called objects to run methods of these classes
            HomePageObj.Open();
            HomePageObj.OpenLoginForm();
            SignInPageObj.LogInSteps();

            //Created object to interact with ManageListings class and its methods
            ListingManagementPage ListingManagementPageObj = new ListingManagementPage();
            //Called object to run DeleteListing method
            ListingManagementPageObj.OpenManageListing();
            ListingManagementPageObj.DeleteListing();
            ListingManagementPageObj.ValidateDeleteListing();
        }
    }
}
