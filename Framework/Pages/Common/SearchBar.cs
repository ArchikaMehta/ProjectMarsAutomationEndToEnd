using NUnit.Framework;
using OpenQA.Selenium;
using Framework.CommonHelpers;

namespace Framework.Pages.Common
{
#region Skill search and its validation
    public class SearchBar : Driver
    {
        //Web element for Search box
        private IWebElement SearchBox => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[1]/input"));
        //Web element for Search Validation text
        private IWebElement SearchValidationText => driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[1]/div"));

        public void SkillSearch()
        {
            SearchBox.Click();
            //Populate data from Excel and search for skill
            ExcelLibHelpers.PopulateInCollection(Paths.ExcelPath, "Search");
            SearchBox.SendKeys(ExcelLibHelpers.ReadData(3, "Column0") + Keys.Enter);
            //Wait for page load with search results
            WaitHelpers.ExplicitWait(driver, "ElementIsVisible", "XPath", "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[1]/div", 10);
        }

        //Validate search
        public void SkillSearchValidation()
        {
            if (SearchValidationText.Text.Contains("Results Per Page"))
            {
                Assert.Pass("Searched successfully, test passed");
            }
            else
            {
                Assert.Fail("Search failed, test failed");
            }
        }
    #endregion
    }
}

