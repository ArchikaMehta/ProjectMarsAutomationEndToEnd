using NUnit.Framework;
using OpenQA.Selenium;
using Framework.CommonHelpers;
using System.Collections.Generic;

namespace Framework.Pages.ShareSkill
{
    public class ListingManagementPage : SkillSharePage
    {
        public override string Url => "http://localhost:5000/Home/ListingManagement";

        //Created class reference variable and constructor to interact with ShareSkill class
        SkillSharePage ShareSkillRefObj;

        public ListingManagementPage(SkillSharePage _ShareSkillRefObj) : base()
        {
            this.ShareSkillRefObj = _ShareSkillRefObj;
        }

        public ListingManagementPage()
        {
        }

        //Web element for Manage Listings Link
        private IWebElement manageListingsLink => driver.FindElement(By.LinkText("Manage Listings"));

        //Web element for Listings table
        private IWebElement ListingsTable => driver.FindElement(By.XPath("//table[1]/tbody[1]"));

        //Web element for View the listing
        private IWebElement view => driver.FindElement(By.XPath("(//i[@class='eye icon'])[1]"));

        //Web element for Delete the listing
        private IWebElement delete => driver.FindElement(By.XPath("(//i[@class='remove icon'])[1]"));

        //Web element for Edit the listing
        private IWebElement edit => driver.FindElement(By.XPath("(//i[@class='outline write icon'])[1]"));

        //Web element for Listing title
        private IWebElement listingTitle => driver.FindElement(By.XPath("//table[1]/tbody[1]/tr[1]/td[3]"));

        //Web element for Click on Yes or No
        private IList<IWebElement> clickActionsButton => driver.FindElements(By.XPath("//div[@class='actions']/button"));

        string beforedelete;

    #region Validation of Skill add and edit entries
        public void ValidateShareSkillEntry()
        {
            //Validating Share Skill entry and edit
            Assert.IsTrue(ListingsTable.Text.Contains(ShareSkillRefObj.TimeStamp));
        }
    #endregion

    #region Open Manage Lisitng tab
        public void OpenManageListing()
        {
            //Waiting for Profile page to load after signing in
            WaitHelpers.ExplicitWait(driver, "ElementToBeClickable", "LinkText", "Manage Listings", 10);
            //Click on Manage Listings tab
            manageListingsLink.Click();
            //Waiting for Manage Listing page to load
            WaitHelpers.ExplicitWait(driver, "ElementIsVisible", "XPath", "//table[1]/tbody[1]", 10);
        }
    #endregion

    #region Edit Listing
        public void EditShareSkill()
        {            
            //Click on edit button
            edit.Click();
        }
    #endregion

    #region Delete Listing
        public void DeleteListing()
        {
            //Populate data from Excel Sheet
            ExcelLibHelpers.PopulateInCollection(Paths.ExcelPath, "ManageListings");

            //Saving the Title of to be deleted listing for validation
            beforedelete = listingTitle.Text;

            //Click on delete button
            delete.Click();

            //Confirm the action while reading the data from excel sheet
            switch ((ExcelLibHelpers.ReadData(3, "Column1")))
            {
                case "Yes":
                    //Select Yes option
                    clickActionsButton[1].Click();
                    break;

                case "No":
                    //Select No option
                    clickActionsButton[0].Click();
                    break;
            }
        }

        public void ValidateDeleteListing()
        { 
            //Refreshing the page after listing deletion
            driver.Navigate().Refresh();
            //Waiting for Manage Listing page to load
            WaitHelpers.ExplicitWait(driver, "ElementIsVisible", "XPath", "//table[1]/tbody[1]", 10);
            //Validation of listing delete
            Assert.IsTrue(!ListingsTable.Text.Contains(beforedelete));
        }
    #endregion
    }
}
    
