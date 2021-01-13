using System;

namespace Framework.CommonHelpers
{
    public class Paths
    {
    #region Paths
        //Application URL
        public static string AppUrl = "http://192.168.99.100:5000";

        //General Project path
        public static string Path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        public static string ActualPath = Path.Substring(0, Path.LastIndexOf("bin"));
        public static string ProjectPath = new Uri(ActualPath).LocalPath;

        //Paths for Extent report, Screenshots and Excel data for tests
        public static string ReportPath = ProjectPath + @"../\Framework\TestReports\Reports\TestReport.html";
        public static string SpecFlowReportPath = ProjectPath + @"../\Framework\TestReports\Reports\SpecFlowTestReport.html";
        public static string ConfigPath = ProjectPath + @"../\Framework\TestReports\config.xml";
        public static string ScreenshotPath = ProjectPath + @"../\Framework\TestReports\Screenshots\";
        public static string ExcelPath = ProjectPath + @"../\Framework\TestData\Mars.xlsx";
        public static string FileUploadPath = ProjectPath + @"../\Framework\TestData\testFile.txt";
    #endregion
    }
}
