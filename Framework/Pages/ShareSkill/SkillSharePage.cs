using OpenQA.Selenium;
using Framework.CommonHelpers;
using Framework.Pages.Common;
using System;
using System.Collections.Generic;

namespace Framework.Pages.ShareSkill
{
    public class SkillSharePage : NavigatableBasePage
    {
        public override string Url => "http://192.168.99.100:5000/Home/ServiceListing";

        //Web element for ShareSkill Button
        private IWebElement ShareSkillButton => driver.FindElement(By.LinkText("Share Skill"));

        //Web element for  Enter the Title in textbox
        private IWebElement Title => driver.FindElement(By.Name("title"));

        //Generate unique description using current timestamp
        internal String TimeStamp = (DateTime.Now.ToString("yyyyMMddHHmmssfff"));

        //Web element for Enter the Description in textbox
        private IWebElement Description => driver.FindElement(By.Name("description"));

        //Web element for Click on Category Dropdown
        private IWebElement CategoryDropDown => driver.FindElement(By.Name("categoryId"));

        //Web element for Click on SubCategory Dropdown
        private IWebElement SubCategoryDropDown => driver.FindElement(By.Name("subcategoryId"));

        //Web element for Enter Tag names in textbox
        private IWebElement Tags => driver.FindElement(By.XPath("//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]"));

        //List of Web elements for Select the Service type
        private IList<IWebElement> ServiceTypeOptions => driver.FindElements(By.XPath("//form/div[5]/div[@class='twelve wide column']/div/div/div/input"));

        //List of Web elements for Select the Location Type
        private IList<IWebElement> LocationTypeOption => driver.FindElements(By.XPath("//form/div[6]/div[@class='twelve wide column']/div/div/div/input"));

        //Web element for Click on Start Date dropdown
        private IWebElement StartDateDropDown => driver.FindElement(By.Name("startDate"));

        //Web element for Click on End Date dropdown
        private IWebElement EndDateDropDown => driver.FindElement(By.Name("endDate"));

        //List of Web elements for Storing the table of available days
        private IList<IWebElement> Days => driver.FindElements(By.XPath("//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]/div/div/div/input"));

        //List of Web elements for Storing the starttime
        private IList<IWebElement> StartTime => driver.FindElements(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div/div[2]/input"));

        //List of Web elements for Click on StartTime dropdown
        private IList<IWebElement> StartTimeDropDown => driver.FindElements(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div/div[2]/input"));

        //List of Web elements for Click on EndTime dropdown
        private IList<IWebElement> EndTimeDropDown => driver.FindElements(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div/div[3]/input"));

        //Web element for Click on Skill Trade option
        private IList<IWebElement> SkillTradeOption => driver.FindElements(By.XPath("//form/div[8]/div[@class='twelve wide column']/div/div/div/input"));

        //Web element for Enter Skill Exchange
        private IWebElement SkillExchange => driver.FindElement(By.XPath("//div[@class='form-wrapper']//input[@placeholder='Add new tag']"));

        //Web element for Enter the amount for Credit
        private IWebElement CreditAmount => driver.FindElement(By.XPath("//input[@placeholder='Amount']"));

        //List of Web elements for Active/Hidden option
        private IList<IWebElement> ActiveOption => driver.FindElements(By.XPath("//form/div[10]/div[@class='twelve wide column']/div/div/div/input"));

        //Web element for Add Work sample file option
        private IWebElement FileAdd => driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));

        //Web element for Add Work sample file upload
        private IWebElement FileUpload => driver.FindElement(By.XPath("//input[@id='selectFile']"));

        //Web element for Click on Save button
        private IWebElement Save => driver.FindElement(By.XPath("//input[@value='Save']"));

    #region Share skill entry
        public void OpenShareSkillPage()
        {
            //Waiting for Profile page to load
            WaitHelpers.ExplicitWait(driver, "ElementExists", "LinkText", "Share Skill", 10);

            //Click on Share Skill button
            ShareSkillButton.Click();

            //Waiting for Share Skill page to load
            WaitHelpers.ExplicitWait(driver, "ElementToBeClickable", "Name", "title", 10);
        }

        public void EnterShareSkill()
        {
            //PopulatePopulate data from Excel 
            ExcelLibHelpers.PopulateInCollection(Paths.ExcelPath, "ShareSkill");            

            //Enter Title
            Title.SendKeys(ExcelLibHelpers.ReadData(3, "Column0") + TimeStamp);

            //Enter Description
            Description.SendKeys(ExcelLibHelpers.ReadData(3, "Column1"));

            //Select Category from DropDown
            CategoryDropDown.SendKeys(ExcelLibHelpers.ReadData(3, "Column2"));

            //Select SubCategory from DropDown
            SubCategoryDropDown.SendKeys(ExcelLibHelpers.ReadData(3, "Column3"));

            //Enter Tags
            Tags.SendKeys(ExcelLibHelpers.ReadData(3, "Column4") + Keys.Enter);

            //Select ServiceType from Option
            switch ((ExcelLibHelpers.ReadData(3, "Column5")))
            {
                case "Hourly basis service":
                    //Select Hourly basis service from options
                    ServiceTypeOptions[0].Click();
                    break;

                case "One-off service":
                    //Select One-off service from options
                    ServiceTypeOptions[1].Click();
                    break;
            }

            //Select LocationType from Option
            switch ((ExcelLibHelpers.ReadData(3, "Column6")))
            {
                case "On-site":
                    //Select On-site from location options
                    LocationTypeOption[0].Click();
                    break;

                case "Online":
                    //Select Online from location options
                    LocationTypeOption[1].Click();
                    break;
            }

            //Enter StartDate from DropDown
            StartDateDropDown.SendKeys(ExcelLibHelpers.ReadData(3, "Column7"));

            //Enter EndDate from DropDown
            EndDateDropDown.SendKeys(ExcelLibHelpers.ReadData(3, "Column8"));

            //Select Days and enter Start and End time
            if ((ExcelLibHelpers.ReadData(3, "Column9")) == "Sun")
            {
                //Select Sunday
                Days[0].Click();
                //Enter StartTime from DropDown
                StartTimeDropDown[1].SendKeys(ExcelLibHelpers.ReadData(3, "Column10"));
                //Enter EndTime from DropDown
                EndTimeDropDown[0].SendKeys(ExcelLibHelpers.ReadData(3, "Column11"));
            }
            else if ((ExcelLibHelpers.ReadData(3, "Column9")) == "Mon")
            {
                //Select Monday
                Days[1].Click();
                //Enter StartTime from DropDown
                StartTimeDropDown[2].SendKeys(ExcelLibHelpers.ReadData(3, "Column10"));
                //Enter EndTime from DropDown
                EndTimeDropDown[1].SendKeys(ExcelLibHelpers.ReadData(3, "Column11"));
            }
            else if ((ExcelLibHelpers.ReadData(3, "Column9")) == "Tue")
            {
                //Select Tuesday
                Days[2].Click();
                //Enter StartTime from DropDown
                StartTimeDropDown[3].SendKeys(ExcelLibHelpers.ReadData(3, "Column10"));
                //Enter EndTime from DropDown
                EndTimeDropDown[2].SendKeys(ExcelLibHelpers.ReadData(3, "Column11"));
            }
            else if ((ExcelLibHelpers.ReadData(3, "Column9")) == "Wed")
            {
                //Select Wednesday
                Days[3].Click();
                //Enter StartTime from DropDown
                StartTimeDropDown[4].SendKeys(ExcelLibHelpers.ReadData(3, "Column10"));
                //Enter EndTime from DropDown
                EndTimeDropDown[3].SendKeys(ExcelLibHelpers.ReadData(3, "Column11"));
            }
            else if ((ExcelLibHelpers.ReadData(3, "Column9")) == "Thu")
            {
                //Select Thursday
                Days[4].Click();
                //Enter StartTime from DropDown
                StartTimeDropDown[5].SendKeys(ExcelLibHelpers.ReadData(3, "Column10"));
                //Enter EndTime from DropDown
                EndTimeDropDown[4].SendKeys(ExcelLibHelpers.ReadData(3, "Column11"));
            }
            else if ((ExcelLibHelpers.ReadData(3, "Column9")) == "Fri")
            {
                //Select Friday
                Days[5].Click();
                //Enter StartTime from DropDown
                StartTimeDropDown[6].SendKeys(ExcelLibHelpers.ReadData(3, "Column10"));
                //Enter EndTime from DropDown
                EndTimeDropDown[5].SendKeys(ExcelLibHelpers.ReadData(3, "Column11"));
            }
            else if ((ExcelLibHelpers.ReadData(3, "Column9")) == "Sat")
            {
                //Select Saturday
                Days[6].Click();
                //Enter StartTime from DropDown
                StartTimeDropDown[7].SendKeys(ExcelLibHelpers.ReadData(3, "Column10"));
                //Enter EndTime from DropDown
                EndTimeDropDown[6].SendKeys(ExcelLibHelpers.ReadData(3, "Column11"));
            }

            //Select Skill Trade from options
            if ((ExcelLibHelpers.ReadData(3, "Column12")) == "Skill-Exchange")
            {
                //Select Skill-exchange from available options
                SkillTradeOption[0].Click();
                //Enter SkillExchange
                SkillExchange.SendKeys(ExcelLibHelpers.ReadData(3, "Column13") + Keys.Enter);
            }
            else if ((ExcelLibHelpers.ReadData(3, "Column12")) == "Credit")
            {
                //Select Credit from available options
                SkillTradeOption[1].Click();
                //Enter Credit Amount
                CreditAmount.SendKeys(ExcelLibHelpers.ReadData(3, "Column14"));
            }

            //Select ActiveOption
            switch ((ExcelLibHelpers.ReadData(3, "Column15")))
            {
                case "Active":
                    //Select Active status
                    ActiveOption[0].Click();
                    break;

                case "Hidden":
                    //Select Hidden status
                    ActiveOption[1].Click();
                    break;
            }

            //Click on work sample file add icon
            //FileAdd.Click();
            //FileUpload.SendKeys(Paths.FileUploadPath);
            
            //Click on Save button
            Save.Click();
            //Waiting for Manage Listing page to load
            WaitHelpers.ExplicitWait(driver, "ElementIsVisible","XPath","//table[1]/tbody[1]", 10);
        }
    #endregion

    #region Share Skill edit
        public void EditShareSkill()
        {
            //Populate data from excel 
            ExcelLibHelpers.PopulateInCollection(Paths.ExcelPath, "EditShareSkill");

            //Waiting for Manage Listing page to load
            WaitHelpers.ExplicitWait(driver, "ElementIsClickable", "Name", "title", 10);
            //Clear the existing Title and Enter new Title
            Title.Clear();
            Title.SendKeys(ExcelLibHelpers.ReadData(3, "Column0") + TimeStamp);

            //Enter Tags
            Tags.SendKeys(ExcelLibHelpers.ReadData(3, "Column4") + Keys.Enter);

            //Disselect already entered day and time
            for (int i = 0; i < Days.Count; i++)
            {
                if (Days[i].Selected)
                {
                    Days[i].Click();
                    StartTimeDropDown[i + 1].Clear();
                    EndTimeDropDown[i].Clear();
                }
            }

        //Select Days and enter Start and End time
        if ((ExcelLibHelpers.ReadData(3, "Column9")) == "Sun")
        {
            //Select Sunday
            Days[0].Click();
            //Enter StartTime from DropDown
            StartTimeDropDown[1].SendKeys(ExcelLibHelpers.ReadData(3, "Column10"));
            //Enter EndTime from DropDown
            EndTimeDropDown[0].SendKeys(ExcelLibHelpers.ReadData(3, "Column11"));
        }
        else if ((ExcelLibHelpers.ReadData(3, "Column9")) == "Mon")
        {
            //Select Monday
            Days[1].Click();
            //Enter StartTime from DropDown
            StartTimeDropDown[2].SendKeys(ExcelLibHelpers.ReadData(3, "Column10"));
            //Enter EndTime from DropDown
            EndTimeDropDown[1].SendKeys(ExcelLibHelpers.ReadData(3, "Column11"));
        }
        else if ((ExcelLibHelpers.ReadData(3, "Column9")) == "Tue")
        {
            //Select Tuesday
            Days[2].Click();
            //Enter StartTime from DropDown
            StartTimeDropDown[3].SendKeys(ExcelLibHelpers.ReadData(3, "Column10"));
            //Enter EndTime from DropDown
            EndTimeDropDown[2].SendKeys(ExcelLibHelpers.ReadData(3, "Column11"));
        }
        else if ((ExcelLibHelpers.ReadData(3, "Column9")) == "Wed")
        {
            //Select Wednesday
            Days[3].Click();
            //Enter StartTime from DropDown
            StartTimeDropDown[4].SendKeys(ExcelLibHelpers.ReadData(3, "Column10"));
            //Enter EndTime from DropDown
            EndTimeDropDown[3].SendKeys(ExcelLibHelpers.ReadData(3, "Column11"));
        }
        else if ((ExcelLibHelpers.ReadData(3, "Column9")) == "Thu")
        {
            //Select Thursday
            Days[4].Click();
            //Enter StartTime from DropDown
            StartTimeDropDown[5].SendKeys(ExcelLibHelpers.ReadData(3, "Column10"));
            //Enter EndTime from DropDown
            EndTimeDropDown[4].SendKeys(ExcelLibHelpers.ReadData(3, "Column11"));
        }
        else if ((ExcelLibHelpers.ReadData(3, "Column9")) == "Fri")
        {
            //Select Friday
            Days[5].Click();
            //Enter StartTime from DropDown
            StartTimeDropDown[6].SendKeys(ExcelLibHelpers.ReadData(3, "Column10"));
            //Enter EndTime from DropDown
            EndTimeDropDown[5].SendKeys(ExcelLibHelpers.ReadData(3, "Column11"));
        }
        else if ((ExcelLibHelpers.ReadData(3, "Column9")) == "Sat")
        {
            //Select Saturday
            Days[6].Click();
            //Enter StartTime from DropDown
            StartTimeDropDown[7].SendKeys(ExcelLibHelpers.ReadData(3, "Column10"));
            //Enter EndTime from DropDown
            EndTimeDropDown[6].SendKeys(ExcelLibHelpers.ReadData(3, "Column11"));
        }

        //Select Skill Trade from options
        if ((ExcelLibHelpers.ReadData(3, "Column11")) == "Skill-Exchange")
            {
                //Select Skill-exchange from available options
                SkillTradeOption[0].Click();
                //Enter SkillExchange
                SkillExchange.SendKeys(ExcelLibHelpers.ReadData(3, "Column13") + Keys.Enter);
            }
            else if ((ExcelLibHelpers.ReadData(3, "Column11")) == "Credit")
            {
                //Select Credit from available options
                SkillTradeOption[1].Click();
                //Enter Credit Amount
                CreditAmount.SendKeys(ExcelLibHelpers.ReadData(3, "Column14"));
            }

            //Select ActiveOption
            switch ((ExcelLibHelpers.ReadData(3, "Column15")))
            {
                case "Active":
                    //Select Active status
                    ActiveOption[0].Click();
                    break;

                case "Hidden":
                    //Select Hidden status
                    ActiveOption[1].Click();
                    break;
            }

            //Click on Save button
            Save.Click();

            //Waiting for Manage Listing page to load
            WaitHelpers.ExplicitWait(driver, "ElementIsVisible", "XPath", "//table[1]/tbody[1]", 10);
        }
    #endregion
    }
}


