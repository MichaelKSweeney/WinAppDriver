using AventStack.ExtentReports;
using NUnit.Framework;
using System.Diagnostics;

namespace WinAppDriverProject
{
    [TestFixture]
    public class CalculatorTest : BaseTest
    {
        private const string CalculatorAppId = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";
        private const string CalculatorAppPath = @"C:\Windows\System32\calc.exe";
        bool bootViaPath = false;
        CalculatorSteps CalculatorSteps;

        [SetUp]
        public void TestSetup()
        {
            
            Process.GetProcesses().Where(process => process.ProcessName == "CalculatorApp" ).ToList().ForEach(process => process.Kill());
            if (bootViaPath)
            {
                CreateDriverFromPath(CalculatorAppPath, "Calculator");
            }
            else
            {
                CreateDriverFromAppId(CalculatorAppId);
            }
            ExtentReporter.StartExtentTest(TestContext.CurrentContext.Test.Name, driver);
            report = new Reporter(driver, Guid.NewGuid());
            report.InitialiseReport();
            report.Log("Booting Calculator");

            CalculatorSteps = new CalculatorSteps(driver, report);

            //reset calculator type as calculator retains its previous tab on each boot
            CalculatorSteps.ClickNavigationTab();
            CalculatorSteps.ClickStandardCalculator();
        }

        [TearDown]
        public void TearDown() 
        {
            driver.CloseApp();
            ExtentReporter.Flush();
        }

        [Test]
        public void Addition()
        {
            
            try
            {
                
                ExtentReporter.Message("Step 1");
                CalculatorSteps.ClickNine();
                ExtentReporter.MessageAndScreenshot("Clicked Nine");

                ExtentReporter.Message("Step 2");
                CalculatorSteps.ClickPlus();
                ExtentReporter.MessageAndScreenshot("Clicked Plus");

                ExtentReporter.Message("Step 3");
                CalculatorSteps.ClickOne();
                ExtentReporter.MessageAndScreenshot("Clicked One");

                ExtentReporter.Message("Step 4");
                CalculatorSteps.ClickEquals();
                ExtentReporter.MessageAndScreenshot("Clicked Equals");
                var calculationResult = CalculatorSteps.GetCalculationResultText();

                Assert.That(calculationResult.Replace("Display is ", "") == "10");
                
            }
            catch (Exception e)
            {
                Assert.Fail("Test Failed - " + e.Message);
            }
        }

        [Test]
        public void Subtraction()
        {
            try
            {
                ExtentReporter.Message("Step 1");
                CalculatorSteps.ClickNine();
                ExtentReporter.MessageAndScreenshot("Clicked Nine");

                ExtentReporter.Message("Step 2");
                CalculatorSteps.ClickMinus();
                ExtentReporter.MessageAndScreenshot("Clicked Minus");

                ExtentReporter.Message("Step 3");
                CalculatorSteps.ClickOne();
                ExtentReporter.MessageAndScreenshot("Clicked One");

                ExtentReporter.Message("Step 4");
                CalculatorSteps.ClickEquals();
                ExtentReporter.MessageAndScreenshot("Clicked Equals");

                var calculationResult = CalculatorSteps.GetCalculationResultText();

                Assert.That(calculationResult.Replace("Display is ", "") == "8");
            }
            catch (Exception e)
            {
                Assert.Fail("Test Failed - " + e.Message);
            }
        }

        [Test]
        public void Multiply()
        {
            
            try
            {
                ExtentReporter.Message("Step 1");
                CalculatorSteps.ClickNine();
                ExtentReporter.MessageAndScreenshot("Clicked Nine");

                ExtentReporter.Message("Step 2");
                CalculatorSteps.ClickMultiply();
                ExtentReporter.MessageAndScreenshot("Clicked Multiply");

                ExtentReporter.Message("Step 3");
                CalculatorSteps.ClickTwo();
                ExtentReporter.MessageAndScreenshot("Clicked Two");

                ExtentReporter.Message("Step 4");
                CalculatorSteps.ClickEquals();
                ExtentReporter.MessageAndScreenshot("Clicked Equals");

                var calculationResult = CalculatorSteps.GetCalculationResultText();

                Assert.That(calculationResult.Replace("Display is ", "") == "18");
            }
            catch (Exception e)
            {
                Assert.Fail("Test Failed - " + e.Message);
            }
        }

        [Test]
        public void Divide()
        {
            
            try
            {
                ExtentReporter.Message("Step 1");
                CalculatorSteps.ClickNine();
                ExtentReporter.MessageAndScreenshot("Clicked Minus");

                ExtentReporter.Message("Step 2");
                CalculatorSteps.ClickDivide();
                ExtentReporter.MessageAndScreenshot("Clicked Divide");

                ExtentReporter.Message("Step 3");
                CalculatorSteps.ClickThree();
                ExtentReporter.MessageAndScreenshot("Clicked Three");

                ExtentReporter.Message("Step 4");
                CalculatorSteps.ClickEquals();
                ExtentReporter.MessageAndScreenshot("Clicked Equals");

                var calculationResult = CalculatorSteps.GetCalculationResultText();

                //Assert.That(calculationResult.Replace("Display is ", "") == "3");
                ExtentReporter.Warning("Result does not equal 3");
                Assert.That(calculationResult.Replace("Display is ", "") == "4"); // intentional fail to sho
            }
            catch (Exception e)
            {
                Assert.Fail("Test Failed - " + e.Message);
            }
        }


        [Test]
        public void Backspace()
        {
            
            try
            {
                ExtentReporter.Message("Step 1");
                CalculatorSteps.ClickNine();
                ExtentReporter.MessageAndScreenshot("Clicked Nine");

                ExtentReporter.Message("Step 2");
                CalculatorSteps.ClickSeven();
                ExtentReporter.MessageAndScreenshot("Clicked Seven");

                ExtentReporter.Message("Step 3");
                CalculatorSteps.ClickBackspace();
                ExtentReporter.MessageAndScreenshot("Clicked Backspace");

                var calculationResult = CalculatorSteps.GetCalculationResultText();
                Assert.That(calculationResult.Replace("Display is ", "") == "9");
            }
            catch (Exception e)
            {
                Assert.Fail("Test Failed - " + e.Message);
            }
        }

        [Test]
        public void Clear()
        {
            
            try
            {
                ExtentReporter.Message("Step 1");
                CalculatorSteps.ClickNine();
                ExtentReporter.MessageAndScreenshot("Clicked Nine");

                ExtentReporter.Message("Step 2");
                CalculatorSteps.ClickOne();
                ExtentReporter.MessageAndScreenshot("Clicked One");

                ExtentReporter.Message("Step 3");
                CalculatorSteps.ClickClear();
                ExtentReporter.MessageAndScreenshot("Clicked Clear");

                var calculationResult = CalculatorSteps.GetCalculationResultText();
                Assert.That(calculationResult.Replace("Display is ", "") == "0");
            }
            catch (Exception e)
            {
                Assert.Fail("Test Failed - " + e.Message);
            }
        }

        [Test]
        public void ClearEntry()
        {
            try
            {
                ExtentReporter.Message("Step 1");
                CalculatorSteps.ClickTwo();
                ExtentReporter.MessageAndScreenshot("Clicked Two");

                ExtentReporter.Message("Step 2");
                CalculatorSteps.ClickOne();
                ExtentReporter.MessageAndScreenshot("Clicked One");

                ExtentReporter.Message("Step 3");
                CalculatorSteps.ClickClearEntry();
                ExtentReporter.MessageAndScreenshot("Clicked Clear Entry");

                var calculationResult = CalculatorSteps.GetCalculationResultText();

                Assert.That(calculationResult.Replace("Display is ", "") == "0");
            }
            catch (Exception e)
            {
                Assert.Fail("Test Failed - " + e.Message);
            }
        }


        [Test]
        public void SwitchToScientificCalculatorAndCalculateExponents()
        {
            try
            {
                ExtentReporter.Message("Step 1");
                CalculatorSteps.ClickNavigationTab();
                CalculatorSteps.ClickScientificCalculator();
                ExtentReporter.MessageAndScreenshot("Clicked Scientific Calculator");

                ExtentReporter.Message("Step 2");
                CalculatorSteps.ClickFive();
                ExtentReporter.MessageAndScreenshot("Clicked Five");

                ExtentReporter.Message("Step 3");
                CalculatorSteps.ClickExponent();
                ExtentReporter.MessageAndScreenshot("Clicked Exponent");

                ExtentReporter.Message("Step 4");
                CalculatorSteps.ClickOne();
                ExtentReporter.MessageAndScreenshot("Clicked One");

                ExtentReporter.Message("Step 5");
                CalculatorSteps.ClickZero();
                ExtentReporter.MessageAndScreenshot("Clicked Zero");

                ExtentReporter.Message("Step 6");
                CalculatorSteps.ClickEquals();
                ExtentReporter.MessageAndScreenshot("Clicked Equals");

                var calculationResult = CalculatorSteps.GetCalculationResultText();

                Assert.That(calculationResult.Replace("Display is ", "") == "9,765,625");
            }
            catch (Exception e)
            {
                Assert.Fail("Test Failed - " + e.Message);
            }

            
        }

    }
}