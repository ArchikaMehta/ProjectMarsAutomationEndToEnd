using NUnit.Framework;
using OpenQA.Selenium;
using Framework.CommonHelpers;
using Framework.Pages.Common;

namespace Framework.Pages.Home
{
#region Existing user Login and its Validation
    public class SignInPage : CloseableForm
    {
        //Web element for Email entry box
        private IWebElement Email => driver.FindElement(By.Name("email"));
        //Web element for Password entry box
        private IWebElement Password => driver.FindElement(By.Name("password"));
        //Web element for Login button
        private IWebElement LoginButton => driver.FindElement(By.XPath("//button[.='Login']"));
        //Web element for welcome message
        private IWebElement LogInMessage => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span"));

        public void LogInSteps()
        {
            //Populate data from Excel
            ExcelLibHelpers.PopulateInCollection(Paths.ExcelPath, "Login");
            //Enter Email and Password for login
            Email.SendKeys(ExcelLibHelpers.ReadData(3, "Column0"));
            Password.SendKeys(ExcelLibHelpers.ReadData(3, "Column1"));
            //Click on login button
            LoginButton.Click();
            //Wait for the Profile page to load after login
            WaitHelpers.ExplicitWait(driver, "ElementExists", "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span", 10);
        }

        //Login Validation
        public void LoginValidation()
        { 
            //Validate welcome message
            if (LogInMessage.Text.Contains("Hi")) 
            {
                Assert.Pass("Logged In successfully, test passed");
            }
            else
            {
                Assert.Fail("Login failed, test failed");
            }
        }
#endregion
    }
}




