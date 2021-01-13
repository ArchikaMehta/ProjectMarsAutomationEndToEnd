using Framework.Pages.ShareSkill;
using TechTalk.SpecFlow;

namespace SpecflowTest.StepDefinitions
{
    [Binding]
    class ShareSkillAddSD
    {
        private SkillSharePage SkillSharePageObj;
        private ListingManagementPage ListingManagementPageObj;

        public ShareSkillAddSD()
        {
            SkillSharePageObj = new SkillSharePage();
            ListingManagementPageObj = new ListingManagementPage(SkillSharePageObj);
        }

        [Given(@"I open Share Skill page")]
        public void GivenIOpenShareSkillPage()
        {
            SkillSharePageObj.OpenShareSkillPage();
        }

        [When(@"I list my ""(.*)"" skill for trade")]
        public void WhenIListMySkillForTrade(string p0)
        {
            SkillSharePageObj.EnterShareSkill();
        }

        [Then(@"""(.*)"" is found in my managed listings")]
        public void ThenIsFoundInMyManagedListings(string p0)
        {
            ListingManagementPageObj.ValidateShareSkillEntry();
        }
    }
}
