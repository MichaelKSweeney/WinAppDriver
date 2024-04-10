using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WinAppDriverProject
{
    internal class ExtentReporter
    {

        public static ExtentReports extent;
        public static ExtentTest testlog;
        public static WindowsDriver<WindowsElement> _driver;

        public static string GetReportPath()
        {
            string path = Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;

            string reportPath = projectPath + "Reports\\";

            System.IO.Directory.CreateDirectory(reportPath);
            return reportPath;
        }



        public static void StartReport()
        {
            
           

            ExtentSparkReporter htmlReporter = new ExtentSparkReporter(GetReportPath()+ $"{TestContext.CurrentContext.Test.DisplayName}.html");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Tester", Environment.UserName);
            extent.AddSystemInfo("MachineName", Environment.MachineName);

            
        }

        //public static void StartTest()
        //{

        //}

        public static void EndReport()
        {
            LoggingTestStatusExtentReport();
            extent.Flush();
        }

        public static void Flush()
        {
            LoggingTestStatusExtentReport();
            extent.Flush();
        }

        public static void StartExtentTest(string testsToStart, WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
            testlog = extent.CreateTest(testsToStart);
            
        }

        public static void LoggingTestStatusExtentReport()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                //var stacktrace = string.Empty + TestContext.CurrentContext.Result.StackTrace + string.Empty;
                var errorMessage = TestContext.CurrentContext.Result.Message;
                Status logstatus;
                switch (status)
                {
                    case TestStatus.Failed:
                        logstatus = Status.Fail;
                        testlog.Log(Status.Fail, "Test steps NOT Completed for Test case " + TestContext.CurrentContext.Test.Name + " ");
                        testlog.Log(Status.Fail, "Test ended with " + Status.Fail + " – " + errorMessage);
                        break;
                    case TestStatus.Skipped:
                        logstatus = Status.Skip;
                        testlog.Log(Status.Skip, "Test ended with " + Status.Skip);
                        break;
                    default:
                        logstatus = Status.Pass;
                        testlog.Log(Status.Pass, "Test steps finished for test case " + TestContext.CurrentContext.Test.Name);
                        testlog.Log(Status.Pass, "Test ended with " + Status.Pass);
                        break;
                }
            }
            catch (WebDriverException ex)
            {
                throw ex;
            }
        }


        public static void Message(string message)
        {
            testlog.Log(Status.Info, message);
        }

        public static void Warning(string message)
        {
            testlog.Warning(message);
        }

        public static void Fail(string message)
        {
            testlog.Fail(message);

        }

        public static void Pass(string message)
        {
            testlog.Pass(message);

        }

        public static void MessageAndScreenshot(string message)
        {
            testlog.Log(Status.Info, message);
            string imagePath = GetReportPath() + message + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".png";
            _driver.GetScreenshot().SaveAsFile(imagePath, ScreenshotImageFormat.Png);
            testlog.Info("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(imagePath).Build());
            
        }

    }
}
