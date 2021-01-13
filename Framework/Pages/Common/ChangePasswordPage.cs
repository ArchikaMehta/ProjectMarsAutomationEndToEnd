using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Framework.CommonHelpers;

namespace Framework.Pages.Common
{
    public class ChangePasswordPage : CloseableForm
    {
        //Web element for Profile name
        private IWebElement ProfileName => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span"));
        //Web element for Password Change button
        private IWebElement ChangePasswordClick => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span/div/a[2]"));
        //Web element for Current Password text box
        private IWebElement CurrentPassword => driver.FindElement(By.Name("oldPassword"));
        //Web element for New Password text box
        private IWebElement NewPassword => driver.FindElement(By.Name("newPassword"));
        //Web element for Confirm Password text box
        private IWebElement ConfirmPassword => driver.FindElement(By.Name("confirmPassword"));
        //Web element for Save Password button
        private IWebElement SaveButton => driver.FindElement(By.XPath("//form[@autocomplete='new-password']/div/button[.='Save']"));
        string CurrentPass;
        string NewPass;

    #region Password Change entry and validation
        public void ChangePassword()
        {
            //Populate data from Excel
            ExcelLibHelpers.PopulateInCollection(Paths.ExcelPath, "ChangePassword");

            CurrentPass = (ExcelLibHelpers.ReadData(4, "Column0"));
            NewPass = (ExcelLibHelpers.ReadData(4, "Column1"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(ProfileName).Perform();
            WaitHelpers.ExplicitWait(driver, "ElementExists", "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span", 10);
            actions.MoveToElement(ChangePasswordClick).Perform();
            ChangePasswordClick.Click();

            //Enter Current, new and confirm password
            CurrentPassword.SendKeys(ExcelLibHelpers.ReadData(4, "Column0"));
            NewPassword.SendKeys(ExcelLibHelpers.ReadData(4, "Column1"));
            ConfirmPassword.SendKeys(ExcelLibHelpers.ReadData(4, "Column2"));
            SaveButton.Click();
        }
    #endregion

    #region Password Change Validation
        public void PasswordChangeValidation()
        {             
            //Password change validation
            if (CurrentPass == NewPass)
            {
                //Wait for error message to appear
                WaitHelpers.ExplicitWait(driver, "ElementIsVisible", "CssSelector", "a.ns-close", 10);
                Assert.IsTrue(GetErrorPopUpMessage()== "Current Password and New Password should not be same");
                //Close opened form for password change
                CloseForm();
                //Close error message
                MessageBoxClose();
            }
            else
            {
                //Wait for success messgae to appear
                WaitHelpers.ExplicitWait(driver, "ElementIsVisible", "CssSelector", "a.ns-close", 10);
                Assert.IsTrue(GetSuccessPopUpMessage() == "Password Changed Successfully");
                //Close success message
                MessageBoxClose();

                //Again changing the password to the older
                Actions actions = new Actions(driver);
                actions.MoveToElement(ProfileName).Perform();
                WaitHelpers.ExplicitWait(driver, "ElementExists", "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span", 10);
                actions.MoveToElement(ChangePasswordClick).Perform();
                ChangePasswordClick.Click();

                //Enter Current, new and confirm password
                CurrentPassword.SendKeys(ExcelLibHelpers.ReadData(5, "Column0"));
                NewPassword.SendKeys(ExcelLibHelpers.ReadData(5, "Column1"));
                ConfirmPassword.SendKeys(ExcelLibHelpers.ReadData(5, "Column2"));
                SaveButton.Click();
            }
        }
    #endregion

        public void ChangePassowedClick()
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(ProfileName).Perform();
            WaitHelpers.ExplicitWait(driver, "ElementExists", "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span", 10);
            actions.MoveToElement(ChangePasswordClick).Perform();
            ChangePasswordClick.Click();
        }

        public void PasswordChangewithSamePassword()
        {
            //Populate data from Excel
            ExcelLibHelpers.PopulateInCollection(Paths.ExcelPath, "ChangePassword");

            CurrentPass = (ExcelLibHelpers.ReadData(3, "Column0"));
            NewPass = (ExcelLibHelpers.ReadData(3, "Column1"));

            //Enter Current, new and confirm password
            CurrentPassword.SendKeys(ExcelLibHelpers.ReadData(3, "Column0"));
            NewPassword.SendKeys(ExcelLibHelpers.ReadData(3, "Column1"));
            ConfirmPassword.SendKeys(ExcelLibHelpers.ReadData(3, "Column2"));
            SaveButton.Click();
        }
    }
}



