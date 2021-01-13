using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Text;

namespace Framework.CommonHelpers
{
    public class ReportHelpers
    {
        //Declared objects for intiating extent reports in SetUp
 
        public static ExtentReports extent;
        public static ExtentTest test;

    #region ScreenShots
        public static string SaveScreenshot(IWebDriver driver, string ScreenShotFileName)
        {
            {
                //Created new folder for saving Screenshots if not available already
                var folderLocation = (Paths.ScreenshotPath);

                if (!System.IO.Directory.Exists(folderLocation))
                {
                    System.IO.Directory.CreateDirectory(folderLocation);
                }

                var ScreenShot = ((ITakesScreenshot)driver).GetScreenshot();
                var FileName = new StringBuilder(folderLocation);
                
                //Giving name to the screenshot captured with extension details
                FileName.Append(ScreenShotFileName);
                FileName.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));
                FileName.Append(".Png");
                ScreenShot.SaveAsFile(FileName.ToString(), ScreenshotImageFormat.Png);
                return FileName.ToString();
            }
        }
    #endregion
    }
}
