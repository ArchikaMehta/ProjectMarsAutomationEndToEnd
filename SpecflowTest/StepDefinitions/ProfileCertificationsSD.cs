using Framework.Pages.Profile.Sections;
using TechTalk.SpecFlow;

namespace SpecflowTest.StepDefinitions
{
    [Binding]
    class ProfileCertificationsSD
    {
        MainProfileSection MainProfileSectionObj;

        public ProfileCertificationsSD()
        {
            MainProfileSectionObj = new MainProfileSection();
        }

        [Given(@"I am on Certification tab")]
        public void GivenIAmOnCertificationTab()
        {
            MainProfileSectionObj.ProfileCertificationTab();
        }

        [When(@"I save Certification as follows:")]
        public void WhenISaveCertificationAsFollows(Table table)
        {
            MainProfileSectionObj.EnterProfileCertification();
        }

        [Then(@"my profile page displays the newly added Certification")]
        public void ThenMyProfilePageDisplaysTheNewlyAddedCertification()
        {
            MainProfileSectionObj.VerifyEnterProfileCertifications();
        }
    }
}
