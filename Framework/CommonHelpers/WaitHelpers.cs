using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Framework.CommonHelpers
{
#region Explicit Wait Helpers
    class WaitHelpers
    {
        public static void ImplicitWait(IWebDriver driver, int time)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);
        }

        //Implementing Explicit wait with expexted condition "ElementExists" for different locators
        public static void ExplicitWait(IWebDriver driver, string ExpectedCondition, string Key, string Value, int Seconds)
        {
            if (ExpectedCondition == "ElementExists")
                try
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, Seconds));

                    if (Key == "Id")
                    {
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(Value)));
                    }
                    if (Key == "CssSelector")
                    {
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(Value)));
                    }
                    if (Key == "XPath")
                    {
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(Value)));
                    }
                    if (Key == "ClassName")
                    {
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.ClassName(Value)));
                    }
                    if (Key == "Name")
                    {
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name(Value)));
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail("Test failed to wait element-exist", ex.Message);
                }

            //Implementing Explicit wait with expexted condition "ElementToBeClickable" for different locators
            else if (ExpectedCondition == "ElementToBeClickable")
                try
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, Seconds));

                    if (Key == "Id")
                    {
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(Value)));
                    }
                    if (Key == "CssSelector")
                    {
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(Value)));
                    }
                    if (Key == "XPath")
                    {
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(Value)));
                    }
                    if (Key == "ClassName")
                    {
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName(Value)));
                    }
                    if (Key == "Name")
                    {
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name(Value)));
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail("Test failed to wait element-clickable", ex.Message);
                }

            //Implementing Explicit wait with expexted condition "ElementIsVisible" for different locators
            else if (ExpectedCondition == "ElementIsVisible")
                try
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, Seconds));

                    if (Key == "Id")
                    {
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(Value)));
                    }
                    if (Key == "CssSelector")
                    {
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(Value)));
                    }
                    if (Key == "XPath")
                    {
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(Value)));
                    }
                    if (Key == "ClassName")
                    {
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(Value)));
                    }
                    if (Key == "Name")
                    {
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name(Value)));
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail("Test failed to wait element-visible", ex.Message);
                }
        }

        //Implementing Explicit wait with expexted condition "For Text Present In Element"
        public static void WaitForTextPresentInElement(IWebDriver driver, IWebElement element, string text, int seconds)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(element, text));
        }

        internal static void ExplicitWait(IWebDriver driver, By by, int v)
        {
            throw new NotImplementedException();
        }
#endregion
    }
}
