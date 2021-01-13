using NUnit.Framework;
using OpenQA.Selenium;
using Framework.CommonHelpers;

namespace Framework.Pages.Common
{
    public class HeaderBar: Driver
    {
    #region SignOut
        //Web element for Sign out button 
        private IWebElement SignOut => driver.FindElement(By.XPath("//button[.='Sign Out']"));
        //Web element for Sign out message
        private IWebElement SignOutMessage => driver.FindElement(By.XPath("//a[@class='item'][.='Sign In']"));

        public void DoSignOut()
        {
            //Click SignOut button
            SignOut.Click();

            //Validate SignOut
            Assert.IsTrue(SignOutMessage.Text.Contains("Sign In"));
        }
    #endregion
    }
}
