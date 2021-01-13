using Framework.Pages.Profile.Sections;
using TechTalk.SpecFlow;

namespace SpecflowTest.StepDefinitions
{
    [Binding]
    class ProfileDescriptionSD
    {
        DescriptionSection DescriptionSectionObj;

        public ProfileDescriptionSD()
        {
            DescriptionSectionObj = new DescriptionSection();
        }

        [When(@"I modify description to ""(.*)""")]
        public void WhenIModifyDescriptionTo(string p0)
        {
            DescriptionSectionObj.InvalidDescription();
        }

        [Then(@"the error popup message ""(.*)"" is displayed for invalid description entry")]
        public void ThenTheErrorPopupMessageIsDisplayedForInvalidDescriptionEntry(string p0)
        {
            DescriptionSectionObj.ErrorMessage();
        }

        [Then(@"description is not saved")]
        public void ThenDescriptionIsNotSaved()
        {
            DescriptionSectionObj.DesValidate();
        }
    }
}
