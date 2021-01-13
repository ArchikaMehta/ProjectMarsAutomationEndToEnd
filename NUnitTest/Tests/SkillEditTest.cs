using NUnit.Framework;
using NUnitTest.Utils;
using Framework.CommonHelpers;
using Framework.Pages.Home;
using Framework.Pages.ShareSkill;

namespace NUnitTest.Tests
{
    [TestFixture]
    [Category("ShareSkillEdit")]
    class SkillEditTest:Base
    {
        [Test]
        public void EditShareSkill()
        {
            //Starting Extent report 
            ReportHelpers.test = ReportHelpers.extent.StartTest("Edit ShareSkill entry");

            //Created object to interact with HomePage and SignInPage classes and their methods
            HomePage HomePageObj = new HomePage();
            SignInPage SignInPageObj = new SignInPage();
            //Called objects to run methods of these classes
            HomePageObj.Open();
            HomePageObj.OpenLoginForm();
            SignInPageObj.LogInSteps();

            //Created object to interact with ShareSkill and ManageListings classes and their methods
            SkillSharePage SkillSharePageObj = new SkillSharePage();
            ListingManagementPage ListingManagementPageObj = new ListingManagementPage(SkillSharePageObj);

            //Called objects to run OpenManageListing and EditShareSkill methods
            ListingManagementPageObj.OpenManageListing();
            ListingManagementPageObj.EditShareSkill();
            //Called objects to run EditShareSkill method
            SkillSharePageObj.EditShareSkill();
            //Called objects to run ValidateShareSkillEntry method
            ListingManagementPageObj.ValidateShareSkillEntry();
        }
    }
}
