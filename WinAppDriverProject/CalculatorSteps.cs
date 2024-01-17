using OpenQA.Selenium.Appium.Windows;

namespace WinAppDriverProject
{
    internal class CalculatorSteps
    {

        WindowsDriver<WindowsElement> _driver;
        Reporter _report;
        public CalculatorSteps(WindowsDriver<WindowsElement> driver, Reporter report)
        {
            _driver = driver;
            _report = report;
        }


        #region locators

        private WindowsElement plus => _driver.FindElementByName("Plus");
        private WindowsElement minus => _driver.FindElementByName("Minus");
        private WindowsElement multiply => _driver.FindElementByName("Multiply by");
        private WindowsElement divide => _driver.FindElementByName("Divide by");
        private WindowsElement zero => _driver.FindElementByName("Zero");
        private WindowsElement one => _driver.FindElementByName("One");
        private WindowsElement two => _driver.FindElementByName("Two");
        private WindowsElement three => _driver.FindElementByName("Three");
        private WindowsElement four => _driver.FindElementByName("Four");
        private WindowsElement five => _driver.FindElementByName("Five");
        private WindowsElement six => _driver.FindElementByName("Six");
        private WindowsElement seven => _driver.FindElementByName("Seven");
        private WindowsElement eight => _driver.FindElementByName("Eight");
        private WindowsElement nine => _driver.FindElementByName("Nine");
        private WindowsElement equals => _driver.FindElementByName("Equals");
        private WindowsElement backspace => _driver.FindElementByName("Backspace");
        private WindowsElement clear => _driver.FindElementByName("Clear");
        private WindowsElement clearEntry => _driver.FindElementByName("Clear entry");
        private WindowsElement navigationMenu => _driver.FindElementByName("Open Navigation");
        private WindowsElement navigationMenuScientificCalculator => _driver.FindElementByName("Scientific Calculator");
        private WindowsElement navigationMenuStandardCalculator => _driver.FindElementByName("Standard Calculator");
        private WindowsElement exponent => _driver.FindElementByName("'X' to the exponent");
        private WindowsElement calculationResult => _driver.FindElementByAccessibilityId("CalculatorResults");
        private WindowsElement currentTab => (WindowsElement)_driver.FindElementByName("Calculator")
                .FindElementByAccessibilityId("NavView")
                .FindElementByClassName("Header");

        #endregion

        public void ClickEquals()
        {
            try
            {
                _report.Log("Attempting to click Equals");
                equals.Click();
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to click Equals");
            }
        }

        public void ClickZero()
        {
            try
            {
                _report.Log("Attempting to click Zero");
                zero.Click();
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to click Zero");
            }
        }

        public void ClickOne()
        {
            try
            {
                _report.Log("Attempting to click One");
                one.Click();
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to click One");
            }
        }

        public void ClickTwo()
        {
            try
            {
                _report.Log("Attempting to click Two");
                two.Click();
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to click Two");
            }
        }

        public void ClickThree()
        {
            try
            {
                _report.Log("Attempting to click Three");
                three.Click();
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to click Three");
            }
        }

        public void ClickFour()
        {
            try
            {
                _report.Log("Attempting to click Four");
                four.Click();
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to click Four");
            }
        }

        public void ClickFive()
        {
            try
            {
                _report.Log("Attempting to click Five");
                five.Click();
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to click Five");
            }
        }

        public void ClickSix()
        {
            try
            {
                _report.Log("Attempting to click Six");
                six.Click();
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to click Six");
            }
        }

        public void ClickSeven()
        {
            try
            {
                _report.Log("Attempting to click Seven");
                seven.Click();
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to click Seven");
            }
        }

        public void ClickEight()
        {
            try
            {
                _report.Log("Attempting to click Eight");
                eight.Click();
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to click Eight");
            }
        }

        public void ClickNine()
        {
            try
            {
                _report.Log("Attempting to click Nine");
                nine.Click();
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to click Nine");
            }
        }

        public void ClickBackspace()
        {
            try
            {
                _report.Log("Attempting to click Backspace");
                backspace.Click();
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to click Backspace");
            }
        }

        public void ClickClear()
        {
            try
            {
                _report.Log("Attempting to click Clear");
                clear.Click();
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to click Clear");
            }
        }

        public void ClickClearEntry()
        {
            try
            {
                _report.Log("Attempting to click Clear Entry");
                clearEntry.Click();
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to click Clear Entry");
            }
        }



        public void ClickPlus()
        {
            try
            {
                _report.Log("Attempting to click Plus");
                plus.Click();
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to click Plus");
            }
        }

        public void ClickMinus()
        {
            try
            {
                _report.Log("Attempting to click Minus");
                minus.Click();
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to click Minus");
            }
        }

        public void ClickMultiply()
        {
            try
            {
                _report.Log("Attempting to click Multiply");
                multiply.Click();
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to click Multiply");
            }
        }
        public void ClickDivide()
        {
            try
            {
                _report.Log("Attempting to click Divide");
                divide.Click();
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to click Divide");
            }
        }
        public void ClickExponent()
        {
            try
            {
                _report.Log("Attempting to click Exponent");
                exponent.Click();
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to click Exponent");
            }
        }

        public string? GetCurrentTabText()
        {
            try
            {
                _report.Log("Attempting to return the current tab name");
                return currentTab.Text;
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to get current tab text");
                return null;
            }
        }
        
        public string? GetCalculationResultText()
        {
            try
            {
                _report.Log("Attempting to get the current calculation result");
                return calculationResult.Text;
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to get calculation result text");
                return null;
            }
        }

        public void ClickNavigationTab()
        {
            try
            {
                _report.Log("Attempting to click the Navigation Tab");
                navigationMenu.Click();
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to click the Navigation Tab");
            }
        }

        public void ClickScientificCalculator()
        {
            try
            {
                _report.Log("Attempting to click Scientific Calculator on the tab menu");
                navigationMenuScientificCalculator.Click();
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to click the Scientific Calculator");
            }
        }

        public void ClickStandardCalculator()
        {
            try
            {
                _report.Log("Attempting to click Standard Calculator on the tab menu");
                navigationMenuStandardCalculator.Click();
            }
            catch (Exception)
            {
                _report.FailAndScreenShot("Failed to click the Standard Calculator");
            }
        }

    }
}
