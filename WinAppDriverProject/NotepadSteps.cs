using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace WinAppDriverProject
{
    internal class NotepadSteps
    {
        WindowsDriver<WindowsElement> _driver;
        Reporter _report;
        public NotepadSteps(WindowsDriver<WindowsElement> driver, Reporter report)
        {
            _driver = driver;
            _report = report;
        }


        public void ClickTextBox()
        {
            try
            {
                _report.Log("Attempting to click text box");
                textField.Click();
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to click text box");
            }
        }

        public void TypeIntoTextBox(string input)
        {
            try
            {
                _report.Log($"Attempting to type '{input}' into text box");
                textField.SendKeys(input);
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to type into text box");
            }
        }

        public void DeleteContentsOfTextBox()
        {
            try
            {
                _report.Log($"Attempting to delete contents of text box");
                int characterCount = textField.Text.Length;
                for (int i = 0; i < characterCount; i++)
                {
                    textField.SendKeys(Keys.Backspace);
                }
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to delete content of text box");
            }
        }

        public string GetContentsOfTextBox()
        {
            try
            {
                _report.Log($"Attempting to get contents of text box");
                return textField.Text;
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to delete content of text box");
                return null;
            }
        }

        private WindowsElement textField => _driver.FindElementByName("Text Editor");
    }
}
