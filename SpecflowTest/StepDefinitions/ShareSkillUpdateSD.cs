using Framework.Pages.ShareSkill;
using TechTalk.SpecFlow;

namespace SpecflowTest.StepDefinitions
{
    [Binding]
    class ShareSkillUpdateSD
    {
        private SkillSharePage SkillSharePageObj;
        private ListingManagementPage ListingManagementPageObj;

        public ShareSkillUpdateSD()
        {
            SkillSharePageObj = new SkillSharePage();
            ListingManagementPageObj = new ListingManagementPage(SkillSharePageObj);
        }

        [Given(@"I am on Listing Management page")]
        public void GivenIAmOnListingManagementPage()
        {
            ListingManagementPageObj.OpenManageListing();
        }

        [When(@"I update my ""(.*)"" listing")]
        public void WhenIUpdateMyListing(string p0)
        {
            ListingManagementPageObj.EditShareSkill();
            SkillSharePageObj.EditShareSkill();
        }

        [Then(@"""(.*)"" is updated successfully")]
        public void ThenIsUpdatedSuccessfully(string p0)
        {
            ListingManagementPageObj.ValidateShareSkillEntry();
        }
    }
}
