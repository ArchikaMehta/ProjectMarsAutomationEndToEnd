using NUnit.Framework;
using OpenQA.Selenium;
using Framework.CommonHelpers;
using System;

namespace Framework.Pages.Home
{
#region New user Registration
    public class RegistrationPage : SignInPage
    {
        //Web element for First name
        private IWebElement FirstName => driver.FindElement(By.Name("firstName"));
        //Web element for Last name
        private IWebElement LastName => driver.FindElement(By.Name("lastName"));
        //Web element for Email address
        private IWebElement EmailAddress => driver.FindElement(By.Name("email"));
        //Generate unique email address using current timestamp for creating unique record
        private String TimeStamp = (DateTime.Now.ToString("yyyyMMddHHmmssfff"));
        //Web element for Password
        private IWebElement Password => driver.FindElement(By.Name("password"));
        //Web element for Confirm Password
        private IWebElement ConfirmPassword => driver.FindElement(By.Name("confirmPassword"));
        //Web element for Terms and Conditions  
        private IWebElement TermsAndConditions => driver.FindElement(By.Name("terms"));
        //Web element for Join button
        private IWebElement JoinButton => driver.FindElement(By.Id("submit-btn"));
        private IWebElement ErrorMessage => driver.FindElement(By.XPath("/html/body/div[2]/div/div/form/div[3]/div"));

        public void Register()
        {
            //Populate data from Excel
            ExcelLibHelpers.PopulateInCollection(Paths.ExcelPath, "Registration");
            //Enter details for new user registration
            FirstName.SendKeys(ExcelLibHelpers.ReadData(3, "Column0"));
            LastName.SendKeys(ExcelLibHelpers.ReadData(3, "Column1"));
            EmailAddress.SendKeys(TimeStamp + ExcelLibHelpers.ReadData(3, "Column2"));
            Password.SendKeys(ExcelLibHelpers.ReadData(3, "Column3"));
            ConfirmPassword.SendKeys(ExcelLibHelpers.ReadData(3, "Column4"));
            TermsAndConditions.Click();
            JoinButton.Click();                     
        }

        public void FailedRegistration()
        {
            //Populate data from Excel
            ExcelLibHelpers.PopulateInCollection(Paths.ExcelPath, "Registration");
            //Enter details for new user registration
            FirstName.SendKeys(ExcelLibHelpers.ReadData(4, "Column0"));
            LastName.SendKeys(ExcelLibHelpers.ReadData(4, "Column1"));
            EmailAddress.SendKeys(ExcelLibHelpers.ReadData(4, "Column2"));
            Password.SendKeys(ExcelLibHelpers.ReadData(4, "Column3"));
            ConfirmPassword.SendKeys(ExcelLibHelpers.ReadData(4, "Column4"));
            TermsAndConditions.Click();
            JoinButton.Click();
        }

        public void ValidationFailedRegistration()
        {
            //Wait for error message to appear
            WaitHelpers.ExplicitWait(driver, "ElementIsVisible", "XPath", "/html/body/div[2]/div/div/form/div[3]/div", 10);
            Assert.IsTrue(ErrorMessage.Text.Contains("This email has already been used to register an account."));
            //Close opened form for password change
            CloseForm();
        }
#endregion
    }
}

