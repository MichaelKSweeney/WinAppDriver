using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System.Diagnostics;

namespace WinAppDriverProject
{
    public class BaseTest
    {
        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        protected WindowsDriver<WindowsElement> driver;
        protected Reporter report;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
        }

        protected WindowsDriver<WindowsElement> CreateDriverFromPath(string appPath, string appName)
        {

            Process.Start(appPath);

            //fix this at some point
            Thread.Sleep(5000); // if app hasnt fully booted when driver tries to initialise then it shits itself

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
    }


    
}
