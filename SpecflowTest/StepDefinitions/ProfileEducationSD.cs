using Framework.Pages.Profile.Sections;
using TechTalk.SpecFlow;

namespace SpecflowTest.StepDefinitions
{
    [Binding]
    class ProfileEducationSD
    {
        MainProfileSection MainProfileSectionObj;

        public ProfileEducationSD()
        {
            MainProfileSectionObj = new MainProfileSection();
        }

        [Given(@"I am on ""(.*)"" tab")]
        public void GivenIAmOnTab(string p0)
        {
            MainProfileSectionObj.ProfileEducationTab();
        }

        [When(@"I save '(.*)' as follows:")]
        public void WhenISaveAsFollows(string p0, Table table)
        {
            MainProfileSectionObj.EnterProfileEducation();
        }

        [Then(@"my profile page displays the newly added Education")]
        public void ThenMyProfilePageDisplaysTheNewlyAddedEducation()
        {
            MainProfileSectionObj.VerifyEnterProfileEducation();
        }
    }
}
