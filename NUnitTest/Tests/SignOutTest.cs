using NUnit.Framework;
using NUnitTest.Utils;
using Framework.CommonHelpers;
using Framework.Pages.Common;
using Framework.Pages.Home;

namespace NUnitTest.Tests
{
    [TestFixture]
    [Category("SignOut")]
    class SignOutTest : Base
    {
        [Test]
        public void AppSignOut()
        {
            //Starting Extent report 
            ReportHelpers.test = ReportHelpers.extent.StartTest("SignOut from the application");

            //Created object to interact with HomePage and SignInPage classes and their methods
            HomePage HomePageObj = new HomePage();
            SignInPage SignInPageObj = new SignInPage();
            //Called objects to run methods of these classes
            HomePageObj.Open();
            HomePageObj.OpenLoginForm();
            SignInPageObj.LogInSteps();

            //Created object to interact with HeaderBar class and its methods
            HeaderBar HeaderBarObj = new HeaderBar();
            HeaderBarObj.DoSignOut();
        }
    }
}
