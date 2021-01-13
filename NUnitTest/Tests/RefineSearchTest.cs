using NUnit.Framework;
using Framework.CommonHelpers;
using Framework.Pages.Common;
using Framework.Pages.Home;
using Framework.Pages.Search.Sections;
using NUnitTest.Utils;

namespace NUnitTest.Tests
{
    [TestFixture]
    [Category("RefinedSkillSearch")]
    class RefineSearchTest: Base
    {
        [Test, Order(1), Description("Refined Search by Category")]
        public void SearchSkillbyCategory()
        {
            //Starting Extent report 
            ReportHelpers.test = ReportHelpers.extent.StartTest("Refined Search by Category");

            //Created object to interact with HomePage and SignInPage classes and their methods
            HomePage HomePageObj = new HomePage();
            SignInPage SignInPageObj = new SignInPage();
            //Called objects to run methods of these classes
            HomePageObj.Open();
            HomePageObj.OpenLoginForm();
            SignInPageObj.LogInSteps();

            //Created object to interact with SearchBar and RefineResultsPane classes and their methods
            SearchBar SearchBarObj = new SearchBar();
            RefineResultsPane RefineResultsPaneObj = new RefineResultsPane();
            //Called objects to run methods of these classes
            SearchBarObj.SkillSearch();
            RefineResultsPaneObj.RefineSearchResultsByCategory();
            RefineResultsPaneObj.ValidationRefineSearch("ListingCategory", "Programming & Tech");
        }

        [Test, Order(2), Description("Refined Search by SubCategory")]
        public void SearchSkillbySubCategory()
        {
            //Starting Extent report 
            ReportHelpers.test = ReportHelpers.extent.StartTest("Refined Search by SubCategory");

            //Created object to interact with HomePage and SignInPage classes and their methods
            HomePage HomePageObj = new HomePage();
            SignInPage SignInPageObj = new SignInPage();
            //Called objects to run methods of these classes
            HomePageObj.Open();
            HomePageObj.OpenLoginForm();
            SignInPageObj.LogInSteps();

            //Created object to interact with SearchBar and RefineResultsPane classes and their methods
            SearchBar SearchBarObj = new SearchBar();
            RefineResultsPane RefineResultsPaneObj = new RefineResultsPane();
            //Called objects to run methods of these classes
            SearchBarObj.SkillSearch();
            RefineResultsPaneObj.RefineSearchResultsByCategory();
            RefineResultsPaneObj.ValidationRefineSearch("ListingSubCategory", "QA");
        }

        [Test, Order(3), Description("Refined Search by Location type")]
        public void SearchSkillbyLocationType()
        {
            //Starting Extent report 
            ReportHelpers.test = ReportHelpers.extent.StartTest("Refined Search by Location type");

            //Created object to interact with HomePage and SignInPage classes and their methods
            HomePage HomePageObj = new HomePage();
            SignInPage SignInPageObj = new SignInPage();
            //Called objects to run methods of these classes
            HomePageObj.Open();
            HomePageObj.OpenLoginForm();
            SignInPageObj.LogInSteps();

            //Created object to interact with SearchBar and RefineResultsPane classes and their methods
            SearchBar SearchBarObj = new SearchBar();
            RefineResultsPane RefineResultsPaneObj = new RefineResultsPane();
            //Called objects to run methods of these classes
            SearchBarObj.SkillSearch();
            RefineResultsPaneObj.RefineSearchResultsByCategory();
            RefineResultsPaneObj.ValidationRefineSearch("ListingLocationType", "Online");
        }
    }
}
