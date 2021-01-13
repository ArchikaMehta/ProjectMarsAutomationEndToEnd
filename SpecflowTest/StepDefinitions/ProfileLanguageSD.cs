using Framework.Pages.Profile.Sections;
using TechTalk.SpecFlow;

namespace SpecflowTest.StepDefinitions
{
    [Binding]
    class ProfileLanguageSD
    {
        MainProfileSection MainProfileSectionObj;

        public ProfileLanguageSD()
        {
            MainProfileSectionObj = new MainProfileSection();
        }

        [Given(@"I am on Language tab")]
        public void GivenIAmOnLanguageTab()
        {
            MainProfileSectionObj.ProfileLanguageTab();
        }

        [When(@"I save Language as follows:")]
        public void WhenISaveLanguageAsFollows(Table table)
        {
            MainProfileSectionObj.EnterProfileLanguage();
        }

        [Then(@"the success popup message ""(.*)"" is displayed")]
        public void ThenTheSuccessPopupMessageIsDisplayedAfterNewLanguageAdd(string p0)
        {
            MainProfileSectionObj.SuccessMessage();
        }

        [Then(@"my profile page displays the newly added Language")]
        public void ThenMyProfilePageDisplaysTheNewlyAddedLanguage()
        {
            MainProfileSectionObj.VerifyEnterProfileLanguage();
        }
    }
}
