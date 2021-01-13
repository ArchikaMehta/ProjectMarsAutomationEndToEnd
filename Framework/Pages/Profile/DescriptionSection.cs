using NUnit.Framework;
using OpenQA.Selenium;
using Framework.CommonHelpers;
using System;

namespace Framework.Pages.Profile.Sections
{
    public class DescriptionSection :Driver
    {
        //Web element for Description tab
        private IWebElement Description => driver.FindElement(By.Name("value"));
        //Web element for Description edit button
        private IWebElement EditButton => driver.FindElement(By.XPath("//h3[.='Description']/span/i"));
        //Web element for save button
        private IWebElement SaveButton => driver.FindElement(By.XPath("//div[node()=textarea]/following-sibling::button[.='Save']"));
        //Web element for Error message
        public IWebElement Errormsg => driver.FindElement(By.CssSelector("div.ns-box.ns-growl.ns-effect-jelly.ns-type-error.ns-show"));
        //Web element for Message close
        private static IWebElement MessageClose => driver.FindElement(By.CssSelector("a.ns-close"));
        //Web element for already available Description text
        private IWebElement DesText => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/span"));
        //Variables for saving the text of Description before and after edit
        String BeforeEdit;
        String AfterEdit;

    #region Profile Description entry
        public void UpdateDescription()
        {
            //Populate data from excel
            ExcelLibHelpers.PopulateInCollection(Paths.ExcelPath, "Profile");
            //Waiting for Profile page to load after signing in
            WaitHelpers.ExplicitWait(driver, "ElementToBeClickable", "XPath", "//h3[.='Description']/span/i", 10);
            EditButton.Click();
            //Remove already available data from text area and enter new one
            Description.SendKeys(Keys.Control + "a");
            Description.SendKeys(Keys.Delete);
            Description.SendKeys(ExcelLibHelpers.ReadData(3, "Column16"));
            //Save the newly entered description
            SaveButton.Click();

            //Validate Description entry
            try
            {
                Assert.IsTrue(Description.Text.Contains(ExcelLibHelpers.ReadData(3, "Column16")));
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to verify Entering Description", ex.Message);
            }
        }
    #endregion

    #region Invalid Description Entry
        public void InvalidDescription()
        {
            //Populate data from excel
            ExcelLibHelpers.PopulateInCollection(Paths.ExcelPath, "Profile");
            //Waiting for Profile page to load after signing in
            WaitHelpers.ExplicitWait(driver, "ElementToBeClickable", "XPath", "//h3[.='Description']/span/i", 10);
            //Saving already available Description text into a String before edit
            BeforeEdit = DesText.Text;
            //Click on Description edit button
            EditButton.Click();
            //Remove already available data from text area
            Description.SendKeys(Keys.Control + "a");
            Description.SendKeys(Keys.Delete);
            //Enter Description
            Description.SendKeys(ExcelLibHelpers.ReadData(4, "Column16"));
            //Save Description
            SaveButton.Click();
        }

        public void ErrorMessage()
        {
            //Wait for error message to appear
            WaitHelpers.ExplicitWait(driver, "ElementIsVisible", "CssSelector", "div.ns-box.ns-growl.ns-effect-jelly.ns-type-error.ns-show", 10);
            //Comparing error message appeared
            Assert.IsTrue(Errormsg.Text.Contains("First character can only be digit or letters") || Errormsg.Text.Contains("Please, a description is required"));
            //Close error message
            MessageClose.Click();
        }

        public void DesValidate()
        {
            //Refreshing the web page
            driver.Navigate().Refresh();
            //Waiting for Profile page to load after signing in
            WaitHelpers.ExplicitWait(driver, "ElementToBeClickable", "XPath", "//h3[.='Description']/span/i", 10);
            //Saving already available Description text into a String after edit
            AfterEdit = DesText.Text;
            //Comparing befor and after edit Description data for validation
            Assert.IsTrue(BeforeEdit.Equals(AfterEdit));
        }
    }
    #endregion
}
