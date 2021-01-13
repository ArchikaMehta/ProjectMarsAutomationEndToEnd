using Framework.Pages.Profile.Sections;
using TechTalk.SpecFlow;

namespace SpecflowTest.StepDefinitions
{
    [Binding]
    class ProfileSkillSD
    {
        MainProfileSection MainProfileSectionObj;

        public ProfileSkillSD()
        {
            MainProfileSectionObj = new MainProfileSection();
        }

        [Given(@"I am on Skill tab")]
        public void GivenIAmOnSkillTab()
        {
            MainProfileSectionObj.ProfileSkillTab();
        }

        [When(@"I save Skill as follows:")]
        public void WhenISaveSkillAsFollows(Table table)
        {
            MainProfileSectionObj.EnterProfileSkill();
        }

        [Then(@"my profile page displays the newly added Skill")]
        public void ThenMyProfilePageDisplaysTheNewlyAddedSkill()
        {
            MainProfileSectionObj.VerifyEnterProfileSkills();
        }
    }
}
