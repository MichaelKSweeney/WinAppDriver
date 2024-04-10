using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System.Diagnostics;
using System.Reflection;

namespace WinAppDriverProject
{
    public class BaseTest
    {
        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        protected WindowsDriver<WindowsElement> driver;
        protected Reporter report;

      
      
       

        protected WindowsDriver<WindowsElement> CreateDriverFromPath(string appPath, string appName)
        {

            Process.Start(appPath);

            //fix this at some point
            Thread.Sleep(5000); // if app hasnt fully booted when driver tries to initialise then it shits itself


            //this logic i think is dumb, i think booting from a path can be done via appCapabilities but it was being awkward for me
            IntPtr appTopLevelWindowHandle = new IntPtr();
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.IndexOf(appName, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    clsProcess.MainWindowTitle.IndexOf(appName, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    appTopLevelWindowHandle = clsProcess.MainWindowHandle;
                    break;
                }
            }
            var appTopLevelWindowHandleHex = appTopLevelWindowHandle.ToString("x"); //convert number to hex string

            AppiumOptions appCapabilities = new AppiumOptions();
            appCapabilities.AddAdditionalCapability("appTopLevelWindow", appTopLevelWindowHandleHex);
            driver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);
            return driver;
        }


        protected WindowsDriver<WindowsElement> CreateDriverFromAppId(string appId)
        {
            AppiumOptions appCapabilities = new AppiumOptions();
            appCapabilities.AddAdditionalCapability("app", appId);

            driver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 10);
            return driver;
        }

        [OneTimeSetUp]
        public void Setup()
        {
            ExtentReporter.StartReport();
        }


        [OneTimeTearDown] 
        public void OneTimeTearDown()
        {
        }

    }




}
