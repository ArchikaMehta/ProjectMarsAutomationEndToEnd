using NUnit.Framework;
using NUnitTest.Utils;
using Framework.CommonHelpers;
using Framework.Pages.Home;

namespace NUnitTest.Tests
{
    [TestFixture]
    [Category("SignIn")]
    internal class SignInTest : Base
    {
        [Test]
        public void AppSignIn()
        {
            //Starting Extent report 
            ReportHelpers.test = ReportHelpers.extent.StartTest("Existing user LogIn");

            //Created object to interact with HomePage and SignInPage classes and their methods
            HomePage HomePageObj = new HomePage();
            SignInPage SignInPageObj = new SignInPage();

            //Called objects to run methods of these classes
            HomePageObj.Open();
            HomePageObj.OpenLoginForm();
            SignInPageObj.LogInSteps();
            SignInPageObj.LoginValidation();
        }
    }
}
