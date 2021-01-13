using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Framework.CommonHelpers;
using System;

namespace Framework.Pages.Profile.Sections
{
    public class AvailabilitySection : Driver
    {
        //Web element for Availability Edit button
        private IWebElement AvailabilityTimeEdit => driver.FindElement(By.XPath("//span[contains(text(),'Time')]/i"));

        //Web element for Availability Time dropdown
        private IWebElement AvailabilityTime => driver.FindElement(By.Name("availabiltyType"));

        //Web element for Availability Hour Edit button
        private IWebElement AvailabilityHoursEdit => driver.FindElement(By.XPath("//span[contains(text(),'30hours') or contains(text(),'As needed')]/i"));

        //Web element for Availability Hour dropdown
        private IWebElement AvailabilityHours => driver.FindElement(By.Name("availabiltyHour"));

        //Web element for Salary Edit button
        private IWebElement SalaryEdit => driver.FindElement(By.XPath("//span[contains(text(),'per month')]/i"));

        //Web element for Salary dropdown
        private IWebElement Salary => driver.FindElement(By.Name("availabiltyTarget"));

        public void AvailabilityDetails()
        {
            //Populate data from Excel
            ExcelLibHelpers.PopulateInCollection(Paths.ExcelPath, "Profile");

        #region Availability Type details entry
            //Waiting for Profile page to load after signing in
            WaitHelpers.ExplicitWait(driver, "ElementToBeClickable", "XPath", "//span[contains(text(),'Time')]/i", 10);
            // Click Edit icon
            AvailabilityTimeEdit.Click();
            // Click dropdown menu
            AvailabilityTime.Click();
            // Choose Availability parttime; fulltime
            new SelectElement(AvailabilityTime).SelectByText(ExcelLibHelpers.ReadData(3, "Column20"));
        #endregion

        #region Availability Time details entry 
            //Enter Availability Hours
            AvailabilityHoursEdit.Click();
            // Click dropdown menu
            AvailabilityHours.Click();
            // Select Hours 0-less than 30h; 1-more than 30h 2-as needed
            new SelectElement(AvailabilityHours).SelectByText(ExcelLibHelpers.ReadData(3, "Column21"));
        #endregion

        #region Salary details entry 
            //Enter Earn Target
            SalaryEdit.Click();
            // Click dropdown menu
            Salary.Click();
            // Click earn 0-less than 500; 1-500~1000; 2-more than 1000
            new SelectElement(Salary).SelectByText(ExcelLibHelpers.ReadData(3, "Column22"));
        #endregion
        }

        #region Availability Type details Validation
        public void AvailabilityDetailsValidation()
        {
            //Validation of avaibility type details
            try
            {
                Assert.IsTrue(AvailabilityTime.Text.Contains(ExcelLibHelpers.ReadData(3, "Column20")));
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to verify Entering Availability Type", ex.Message);
            }

            //Validation of avaibility time details
            try
            {
                Assert.IsTrue(AvailabilityHours.Text.Contains(ExcelLibHelpers.ReadData(3, "Column21")));
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to verify Entering Availability Hours", ex.Message);
            }

            //Validation of salary details
            try
            {
                Assert.IsTrue(Salary.Text.Contains(ExcelLibHelpers.ReadData(3, "Column22")));
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed to verify Entering Earn Target", ex.Message);
            }
        }
        #endregion
    }
}


