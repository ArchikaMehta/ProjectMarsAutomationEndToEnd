using NUnit.Framework;
using NUnitTest.Utils;
using Framework.CommonHelpers;
using Framework.Pages.Common;
using Framework.Pages.Home;

namespace NUnitTest.Tests
{
    [TestFixture]
    [Category("PasswordChange")]
    class PasswordChangeTest: Base
    {
        [Test]
        public void PasswordChange()
        {
            //Starting Extent report
            ReportHelpers.test = ReportHelpers.extent.StartTest("Password Change");
            
            //Created object to interact with HomePage and SignInPage classes and their methods
            HomePage HomePageObj = new HomePage();
            SignInPage SignInPageObj = new SignInPage();
            //Called objects to run methods of these classes
            HomePageObj.Open();
            HomePageObj.OpenLoginForm();
            SignInPageObj.LogInSteps();

            //Created object to interact with ChangePasswordPage class and its methods
            ChangePasswordPage ChangePasswordPageObj = new ChangePasswordPage();
            //Called object to run ChangePassword method
            ChangePasswordPageObj.ChangePassword();
            ChangePasswordPageObj.PasswordChangeValidation();
        }
    }
}
