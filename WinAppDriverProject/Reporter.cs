using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System.Text;

namespace WinAppDriverProject
{
    public class Reporter
    {
        StringBuilder sb = new StringBuilder();
        string baseReportPath = @"C:\Users\Admin\Documents\WinAppDriverReports\"; // change to whatever directory you want to store results
        Guid testGuid;
        string _testName;
        WindowsDriver<WindowsElement> _driver;


        public Reporter(WindowsDriver<WindowsElement> driver, Guid guid)
        {
            _testName = TestContext.CurrentContext.Test.Name;
            testGuid = guid;
            _driver = driver;

            if (!Directory.Exists(baseReportPath))
            {
                Directory.CreateDirectory(baseReportPath);
            }
            Directory.CreateDirectory(baseReportPath + _testName + testGuid.ToString());
        }

        public void InitialiseReport()
        {
            
            sb.Append("<html><head><meta charset='utf-8'/>");
            sb.Append("<style>ul li{list-style:none;margin-top:3px;margin-bottom:3px;}");
            sb.Append("h1{font-size: 23px;margin-bottom: 0px;margin-top: 0px;");
            sb.Append("font-weight: normal;font-family: Arial;}");
            sb.Append("h2{margin: 3px;margin-left: 0px;font-size: 16px;}");
            sb.Append("h3{margin: 3px;font-size: 16px;}");
            sb.Append("h4{margin: 3px;margin-left: 0px;font-size: 13px;}");
            sb.Append("h5{margin: 3px;font-size: 11px;font-weight: normal;font-family: Arial;}");
            sb.Append("</style>");
            sb.Append("</head>");
            sb.Append("<body style='text-align: center;margin:auto;margin-top:0px;margin-bottom:5px;'>");
            sb.Append("Starting Report");
            
        }

        public void Log(string message, bool failMessage = false) 
        {
            sb.Append("<br/>");
            sb.AppendLine(failMessage ? $"<p style=\"color:red;\">{message}</p>" : message);
        }

        public void LogStep(string message)
        {
            sb.Append("<br/>");
            sb.AppendLine($"<p style=\"color:blue;\">{message}</p>");
        }

        public void LogAndScreenShot(string message)
        {
            Log(message);
            string fileName = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".png";
            string path = baseReportPath + _testName + testGuid.ToString() + @$"\{fileName}";
            _driver.GetScreenshot().SaveAsFile(path, ScreenshotImageFormat.Png);

            sb.Append("<br/>");
            sb.Append("<img src='" + fileName + "' alt='Image'>");
        }

        public void FailAndScreenShot(string message)
        {
            Log(message, true);
            string fileName = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".png";
            string path = baseReportPath + _testName + testGuid.ToString() + @$"\{fileName}";
            _driver.GetScreenshot().SaveAsFile(path, ScreenshotImageFormat.Png);

            sb.Append("<br/>");
            sb.Append("<img src='" + fileName + "' alt='Image'>");
        }

        public void FinaliseReport()
        {
            sb.Append("</body>");
            sb.Append("</html>");

            StreamWriter sw1 = new StreamWriter(baseReportPath + _testName + testGuid.ToString() + @"\report.html");
            sw1.Write(sb);

            sw1.Flush();
            sw1.Close();
            sw1.Dispose();
        }
    }
}
