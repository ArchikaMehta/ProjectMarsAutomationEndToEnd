using NUnit.Framework;
using NUnitTest.Utils;
using Framework.CommonHelpers;
using Framework.Pages.Home;
using Framework.Pages.Profile.Sections;

namespace NUnitTest.Tests
{
    [TestFixture]
    [Category("ProfileDescription")]
    class DescriptionTest : Base
    {
        [Test]
        public void Description()
        {
            //Starting Extent report 
            ReportHelpers.test = ReportHelpers.extent.StartTest("Adding Description to the Profile");

            //Created object to interact with HomePage and SignInPage classes and their methods
            HomePage HomePageObj = new HomePage();
            SignInPage SignInPageObj = new SignInPage();
            //Called objects to run methods of these classes
            HomePageObj.Open();
            HomePageObj.OpenLoginForm();
            SignInPageObj.LogInSteps();

            //Created object to interact with DescriptionSection class and its methods
            DescriptionSection DescriptionSectionObj = new DescriptionSection();

            //Called object to run UpdateDescription method
            DescriptionSectionObj.UpdateDescription();
        }
    }
}
