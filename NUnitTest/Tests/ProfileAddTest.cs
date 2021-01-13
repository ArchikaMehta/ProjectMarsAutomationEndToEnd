using NUnit.Framework;
using NUnitTest.Utils;
using Framework.CommonHelpers;
using Framework.Pages.Home;
using Framework.Pages.Profile.Sections;

namespace NUnitTest.Tests
{
    [TestFixture]
    [Category("ProfileDetailsEntry")]
    class ProfileAddTest : Base
    {
        [Test]
        public void EnterProfileDetails()
        {
            //Starting Extent report 
            ReportHelpers.test = ReportHelpers.extent.StartTest("Entering Profile details");

            //Created object to interact with HomePage and SignInPage classes and their methods
            HomePage HomePageObj = new HomePage();
            SignInPage SignInPageObj = new SignInPage();
            //Called objects to run methods of these classes
            HomePageObj.Open();
            HomePageObj.OpenLoginForm();
            SignInPageObj.LogInSteps();

            //Created object to interact with MainProfileSection class and its methods
            MainProfileSection MainProfileSectionObj = new MainProfileSection();

            //Called object to run MainProfileSection class methods for Language tab
            MainProfileSectionObj.ProfileLanguageTab();
            MainProfileSectionObj.EnterProfileLanguage();
            MainProfileSectionObj.SuccessMessage();
            MainProfileSectionObj.VerifyEnterProfileLanguage();

            //Called object to run MainProfileSection class methods for Skill tab
            MainProfileSectionObj.ProfileSkillTab();
            MainProfileSectionObj.EnterProfileSkill();
            MainProfileSectionObj.SuccessMessage();
            MainProfileSectionObj.VerifyEnterProfileSkills();

            //Called object to run MainProfileSection class methods for Education tab
            MainProfileSectionObj.ProfileEducationTab();
            MainProfileSectionObj.EnterProfileEducation();
            MainProfileSectionObj.SuccessMessage();
            MainProfileSectionObj.VerifyEnterProfileEducation();

            //Called object to run MainProfileSection class methods for Certification tab
            MainProfileSectionObj.ProfileCertificationTab();
            MainProfileSectionObj.EnterProfileCertification();
            MainProfileSectionObj.SuccessMessage();
            MainProfileSectionObj.VerifyEnterProfileCertifications();
        }
    }
}

