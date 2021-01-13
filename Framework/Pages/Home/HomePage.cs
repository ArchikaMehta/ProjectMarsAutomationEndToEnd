using OpenQA.Selenium;
using Framework.CommonHelpers;

namespace Framework.Pages.Home
{
    public class HomePage : Driver
    {
        //Web element for SignIn button
        private IWebElement SignInButton => driver.FindElement(By.XPath("//a[@class='item'][.='Sign In']"));
        //Web element for SignOut button
        private IWebElement SignUpButton => driver.FindElement(By.XPath("//button[.='Join']"));

    #region Navigation to the App Url
        public void Open()
        {
            driver.Navigate().GoToUrl(Paths.AppUrl);
        }
    #endregion

    #region SignIn process for existing user
        public SignInPage OpenLoginForm()
        {
            SignInButton.Click();
            return new SignInPage();
        }
    #endregion

    #region Registration for new user
        public RegistrationPage OpenRegistrationForm()
        {
            SignUpButton.Click();
            return new RegistrationPage();
        }
    #endregion
    }
}
