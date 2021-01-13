using NUnit.Framework;
using NUnitTest.Utils;
using Framework.CommonHelpers;
using Framework.Pages.Home;
using Framework.Pages.ShareSkill;

namespace NUnitTest.Tests
{
    [TestFixture]
    [Category("ShareSkillEntry")]
    class ShareSkillEntryTest:Base
    {
        [Test]
        public void ShareSkillEntry()
        {
            //Starting Extent report 
            ReportHelpers.test = ReportHelpers.extent.StartTest("Start ShareSkill Entry");

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

            //Called object to run EnterShareSkill method
            SkillSharePageObj.OpenShareSkillPage();
            SkillSharePageObj.EnterShareSkill();
            //Called object to run ValidateShareSkillEntry method
            ListingManagementPageObj.ValidateShareSkillEntry();
        }
    }
}
