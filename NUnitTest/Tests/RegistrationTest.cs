using NUnit.Framework;
using NUnitTest.Utils;
using Framework.CommonHelpers;
using Framework.Pages.Home;

namespace NUnitTest.Tests
{
    [TestFixture]
    [Category("Registration")]
    class RegistrationTest: Base
    {
        [Test]
        public void Registration()
        {
            //Starting Extent report 
            ReportHelpers.test = ReportHelpers.extent.StartTest("New user Registration");

            //Created object to interact with HomePage and RegistrationPage classes and their methods
            HomePage HomePageObj = new HomePage();
            RegistrationPage RegistrationPageObj = new RegistrationPage();
            //Called objects to run methods of these classes
            HomePageObj.Open();
            HomePageObj.OpenRegistrationForm();
            RegistrationPageObj.Register();
        }
    }
}
