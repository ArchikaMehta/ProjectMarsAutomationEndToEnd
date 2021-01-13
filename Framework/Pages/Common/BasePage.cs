using OpenQA.Selenium;
using Framework.CommonHelpers;

namespace Framework.Pages.Common
{
    public abstract class BasePage : Driver
    {
        //Web element for Success message, error message and message close
        private static IWebElement SuccessPopUp => driver.FindElement(By.CssSelector("div.ns-box.ns-growl.ns-effect-jelly.ns-type-success.ns-show"));
        //Web element for Error message and message close
        private static IWebElement ErrorPopUp => driver.FindElement(By.CssSelector("div.ns-box.ns-growl.ns-effect-jelly.ns-type-error.ns-show"));
        //Web element for Message close
        private static IWebElement MessageClose => driver.FindElement(By.CssSelector("a.ns-close"));

    #region SuccessMessage
        public static string GetSuccessPopUpMessage()
        {
            return SuccessPopUp.Text;
        }
    #endregion

    #region ErrorMessage
        public static string GetErrorPopUpMessage()
        {
            return ErrorPopUp.Text;
        }
    #endregion

    #region MessageClose
        public static void MessageBoxClose()
        {
            MessageClose.Click();
        }
    #endregion
    }
}

