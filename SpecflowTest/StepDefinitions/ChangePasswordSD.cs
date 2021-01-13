using Framework.Pages.Common;
using TechTalk.SpecFlow;

namespace SpecflowTest.StepDefinitions
{
    [Binding]
    class ChangePasswordSD
    {
        private ChangePasswordPage ChangePasswordPageObj;

        public ChangePasswordSD()
        {
            ChangePasswordPageObj = new ChangePasswordPage();
        }

        [Given(@"I navigate to ""(.*)"" page")]
        public void GivenINavigateToPage(string p0)
        {
            ChangePasswordPageObj.ChangePassowedClick();
        }

        [When(@"I reuse my current password")]
        public void WhenIReuseMyCurrentPassword()
        {
            ChangePasswordPageObj.PasswordChangewithSamePassword();
        }

        [Then(@"The error popup message ""(.*)"" is displayed and password is not saved")]
        public void ThenTheErrorPopupMessageIsDisplayedAndPasswordIsNotSaved(string p0)
        {
            ChangePasswordPageObj.PasswordChangeValidation();
        }
    }
}
