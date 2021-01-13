using NUnit.Framework;
using OpenQA.Selenium;
using Framework.CommonHelpers;

namespace Framework.Pages.Search.Sections
{
    public class RefineResultsPane: Driver
    {
        //Web element for Search filter by Location type
        private IWebElement FilterResultsByLocationType => driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button"));
        //Web element for Search filter by Category
        private IWebElement FilterByCategory => driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[7]"));
        //Web element for Search filter by SubCategory
        private IWebElement FilterBySubCategory => driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a"));
        //Web element for 1st Listing opened as search result
        private IWebElement OpenedListing;
        //Web element for the listing components
        public static IWebElement elementType;

    #region Refine search by Category
        public void RefineSearchResultsByCategory()
        {
            //Select Category for search
            FilterByCategory.Click();
            //Wait for the listing page updated with the refined search
            WaitHelpers.ExplicitWait(driver, "ElementIsVisible", "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/a/img", 10);
            //Open 1st listing appeared on the page as search result
            OpenedListing = driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/a/img"));
        }
    #endregion

    #region Refine search by SubCategory
        public void RefineSearchResultsBySubCategory()
        {
            //Select Category for search
            FilterByCategory.Click();
            //Select SubCategory for search
            FilterBySubCategory.Click();
            //Wait for the listing page updated with the refined search
            WaitHelpers.ExplicitWait(driver, "ElementIsVisible", "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/a/img", 10);
            //Open 1st listing appeared on the page as search result
            OpenedListing = driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/a/img"));
        }
    #endregion

    #region Refine search by LocationType
        public void RefineSearchResultsByLocationType()
        {
            //Select Category for search
            FilterByCategory.Click();
            //Select SubCategory for search
            FilterBySubCategory.Click();
            //Select Location type for search
            FilterResultsByLocationType.Click();
            //Wait for the listing page updated with the refined search
            WaitHelpers.ExplicitWait(driver, "ElementIsVisible", "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/a/img", 10);
            //Open 1st listing appeared on the page as search result
            OpenedListing = driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/a/img"));
        }
    #endregion

    #region Validation of Refined search by Category, SubCategory an Location type
        public void ValidationRefineSearch(string type, string value)
        {
            //Open the 1st listing appeared after refined search
            OpenedListing.Click();
            //Wait for the listing to be loaded
            WaitHelpers.ExplicitWait(driver, "ElementIsVisible", "XPath", "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[1]/div/div[2]", 10);

            //Validating refined search by comparing the Category, SubCategory and Location type element text 
            switch (type)
            {
                case "ListingCategory":
                    elementType = driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[1]/div/div[2]"));
                    break;
                case "ListingSubCategory":
                    elementType = driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[2]"));
                    break;
                case "ListingLocationType":
                    elementType = driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[3]"));
                    break;
            }
            Assert.IsTrue(elementType.Text.Contains(value));        
        }
    #endregion
    }
}
