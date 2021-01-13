using Framework.Pages.Home;
using TechTalk.SpecFlow;

namespace SpecflowTest.StepDefinitions
{
    [Binding]
    class RegistrationSD
    {
        private HomePage HomeRegObj;
        private RegistrationPage RegistrationObj;
        
        public RegistrationSD()
        {
            HomeRegObj = new HomePage();
            RegistrationObj = new RegistrationPage();
        }
        [When(@"I register with a registered email address")]
        public void WhenIRegisterWithARegisteredEmailAddress()
        {
            HomeRegObj.OpenRegistrationForm();
            RegistrationObj.FailedRegistration();
        }

        [Then(@"registration is not successful and the failure message ""(.*)"" is displayed")]
        public void ThenRegistrationIsNotSuccessfulAndTheFailureMessageIsDisplayed(string p0)
        {
            RegistrationObj.ValidationFailedRegistration();
        }
    }
}
