using Framework.Pages.Profile.Sections;
using TechTalk.SpecFlow;

namespace SpecflowTest.StepDefinitions
{
    [Binding]
    class ProfileAvailabilitySD
    {
        AvailabilitySection AvailabilitySectionObj;

        public ProfileAvailabilitySD()
        {
            AvailabilitySectionObj = new AvailabilitySection();
        }

        [When(@"I update available hours to ""(.*)""")]
        public void WhenIUpdateAvailableHoursTo(string p0)
        {
            AvailabilitySectionObj.AvailabilityDetails();
        }

        [Then(@"available hours is updated with a message ""(.*)""")]
        public void ThenAvailableHoursIsUpdatedWithAMessage(string p0)
        {
            AvailabilitySectionObj.AvailabilityDetailsValidation();
        }
    }
}
