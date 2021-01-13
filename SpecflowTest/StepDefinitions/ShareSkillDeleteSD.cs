using Framework.Pages.ShareSkill;
using TechTalk.SpecFlow;

namespace SpecflowTest.StepDefinitions
{
    [Binding]
    class ShareSkillDeleteSD
    {
        private SkillSharePage SkillSharePageObj;
        private ListingManagementPage ListingManagementPageObj;

        public ShareSkillDeleteSD()
        {
            SkillSharePageObj = new SkillSharePage();
            ListingManagementPageObj = new ListingManagementPage(SkillSharePageObj);
        }

        [When(@"I delete my ""(.*)"" listing")]
        public void WhenIDeleteMyListing(string p0)
        {
            ListingManagementPageObj.DeleteListing();
        }

        [Then(@"""(.*)"" is no longer found in my managed listings")]
        public void ThenIsNoLongerFoundInMyManagedListings(string p0)
        {
            ListingManagementPageObj.ValidateDeleteListing();
        }
    }
}
