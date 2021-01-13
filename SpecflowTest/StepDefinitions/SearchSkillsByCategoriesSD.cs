using Framework.Pages.Common;
using Framework.Pages.Search.Sections;
using TechTalk.SpecFlow;

namespace SpecflowTest.StepDefinitions
{
    [Binding]
    class SearchSkillsByCategoriesSD
    {
        private SearchBar SearchBarObj;
        private RefineResultsPane RefineResultsPaneObj;

        public SearchSkillsByCategoriesSD()
        {
            SearchBarObj = new SearchBar();
            RefineResultsPaneObj = new RefineResultsPane();
        }

        [Given(@"the skill search results for ""(.*)"" are shown")]
        public void GivenTheSkillSearchResultsForAreShown(string p0)
        {
            SearchBarObj.SkillSearch();
        }

        [When(@"I filter the results by category ""(.*)""")]
        public void WhenIFilterTheResultsByCategory(string p0)
        {
            RefineResultsPaneObj.RefineSearchResultsByCategory();
        }

        [Then(@"only the matching skills are displayed")]
        public void ThenOnlyTheMatchingSkillsAreDisplayed()
        {
            RefineResultsPaneObj.ValidationRefineSearch("ListingCategory", "Programming & Tech");
        }
    }
}
