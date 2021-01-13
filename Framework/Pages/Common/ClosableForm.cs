using OpenQA.Selenium;

namespace Framework.Pages.Common
{
    public class CloseableForm : BasePage
    {
        public static void CloseForm()
        {
            //Close the opened pop up form during Registration, Login and Password change
            driver.FindElement(By.XPath("//body")).SendKeys(Keys.Escape);
        }
    }
}

