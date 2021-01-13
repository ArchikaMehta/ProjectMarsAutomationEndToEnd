using Framework.Pages.Home;
using TechTalk.SpecFlow;

namespace SpecflowTest.StepDefinitions
{
    [Binding]
    class LogInSD
    {
        private HomePage HomeObj;
        private SignInPage LogInObj;

        public LogInSD()
        {
            HomeObj = new HomePage();
            LogInObj = new SignInPage();
        }
        [Given(@"I am on the application homepage")]
        public void GivenIAmOnTheApplicationHomepage()
        {
            HomeObj.Open();
        }

        [Given(@"I am a registered user")]
        public void GivenIAmARegisteredUser()
        {
            HomeObj.OpenLoginForm();
        }

        [When(@"I login")]
        public void WhenILogin()
        {
            LogInObj.LogInSteps();
        }

        [Then(@"my profile page is displayed")]
        public void ThenMyProfilePageIsDisplayed()
        {
            LogInObj.LoginValidation();
        }
    }
}
