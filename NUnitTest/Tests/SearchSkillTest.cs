using NUnit.Framework;
using NUnitTest.Utils;
using Framework.CommonHelpers;
using Framework.Pages.Common;
using Framework.Pages.Home;

namespace NUnitTest.Tests
{
    [TestFixture]
    [Category("SkillSearch")]
    class SearchSkillTest : Base
    {
        [Test]
        public void SearchSkill()
        {
            //Starting Extent report 
            ReportHelpers.test = ReportHelpers.extent.StartTest("Skill Searched");

            //Created object to interact with HomePage and SignInPage classes and their methods
            HomePage HomePageObj = new HomePage();
            SignInPage SignInPageObj = new SignInPage();
            //Called objects to run methods of these classes
            HomePageObj.Open();
            HomePageObj.OpenLoginForm();
            SignInPageObj.LogInSteps();

            //Created object to interact with SearchBar class and its methods
            SearchBar SearchBarObj = new SearchBar();
            //Called object to run methods of the class
            SearchBarObj.SkillSearch();
            SearchBarObj.SkillSearchValidation();
        }
    }
}
