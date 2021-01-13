using Framework.Pages.Common;
using Framework.Pages.Search.Sections;
using TechTalk.SpecFlow;

namespace SpecflowTest.StepDefinitions
{
    [Binding]
    class SearchSkillsByFiltersSD
    {
        private RefineResultsPane RefineResultsPaneObj;

        public SearchSkillsByFiltersSD()
        {
            RefineResultsPaneObj = new RefineResultsPane();
        }

        [When(@"I filter the results with ""(.*)"" location filter")]
        public void WhenIFilterTheResultsWithLocationFilter(string p0)
        {
            RefineResultsPaneObj.RefineSearchResultsByLocationType();
        }

        [Then(@"only the matching skills are displayed for location filter")]
        public void ThenOnlyTheMatchingSkillsAreDisplayedForLocationFilter()
        {
            RefineResultsPaneObj.ValidationRefineSearch("ListingLocationType", "Online");
        }
    }
}
