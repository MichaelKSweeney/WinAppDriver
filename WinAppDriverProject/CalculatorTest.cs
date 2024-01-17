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
            report.Log("Closing Calculator");
            driver.CloseApp();
            report.FinaliseReport();
        }

        [Test]
        public void Addition()
        {
            
            try
            {
                report.LogStep("Step 1");
                CalculatorSteps.ClickNine();

                report.LogStep("Step 2");
                CalculatorSteps.ClickPlus();

                report.LogStep("Step 3");
                CalculatorSteps.ClickOne();

                report.LogStep("Step 4");
                CalculatorSteps.ClickEquals();

                report.LogAndScreenShot("Equation Result Screenshot");
                var calculationResult = CalculatorSteps.GetCalculationResultText();

                Assert.That(calculationResult.Replace("Display is ", "") == "10");
            }
            catch (Exception e)
            {
                report.FailAndScreenShot("Test Failed - " + e.Message);
                Assert.Fail("Test Failed - " + e.Message);
            }
        }

        [Test]
        public void Subtraction()
        {
            try
            {
                report.LogStep("Step 1");
                CalculatorSteps.ClickNine();

                report.LogStep("Step 2");
                CalculatorSteps.ClickMinus();

                report.LogStep("Step 3");
                CalculatorSteps.ClickOne();

                report.LogStep("Step 4");
                CalculatorSteps.ClickEquals();

                report.LogAndScreenShot("Equation Result Screenshot");
                var calculationResult = CalculatorSteps.GetCalculationResultText();

                Assert.That(calculationResult.Replace("Display is ", "") == "8");
            }
            catch (Exception e)
            {
                report.FailAndScreenShot("Test Failed - " + e.Message);
                Assert.Fail("Test Failed - " + e.Message);
            }
        }

        [Test]
        public void Multiply()
        {
            
            try
            {
                report.LogStep("Step 1");
                CalculatorSteps.ClickNine();

                report.LogStep("Step 2");
                CalculatorSteps.ClickMultiply();

                report.LogStep("Step 3");
                CalculatorSteps.ClickTwo();

                report.LogStep("Step 4");
                CalculatorSteps.ClickEquals();

                report.LogAndScreenShot("Equation Result Screenshot");
                var calculationResult = CalculatorSteps.GetCalculationResultText();

                Assert.That(calculationResult.Replace("Display is ", "") == "18");
            }
            catch (Exception e)
            {
                report.FailAndScreenShot("Test Failed - " + e.Message);
                Assert.Fail("Test Failed - " + e.Message);
            }
        }

        [Test]
        public void Divide()
        {
            
            try
            {
                report.LogStep("Step 1");
                CalculatorSteps.ClickNine();

                report.LogStep("Step 2");
                CalculatorSteps.ClickDivide();

                report.LogStep("Step 3");
                CalculatorSteps.ClickThree();

                report.LogStep("Step 4");
                CalculatorSteps.ClickEquals();

                report.LogAndScreenShot("Equation Result Screenshot");
                var calculationResult = CalculatorSteps.GetCalculationResultText();

                Assert.That(calculationResult.Replace("Display is ", "") == "3");
            }
            catch (Exception e)
            {
                report.FailAndScreenShot("Test Failed - " + e.Message);
                Assert.Fail("Test Failed - " + e.Message);
            }
        }


        [Test]
        public void Backspace()
        {
            
            try
            {
                report.LogStep("Step 1");
                CalculatorSteps.ClickNine();

                report.LogStep("Step 2");
                CalculatorSteps.ClickSeven();

                report.LogStep("Step 3");
                CalculatorSteps.ClickBackspace();

                report.LogAndScreenShot("Equation Result Screenshot");
                var calculationResult = CalculatorSteps.GetCalculationResultText();
                Assert.That(calculationResult.Replace("Display is ", "") == "9");
            }
            catch (Exception e)
            {
                report.FailAndScreenShot("Test Failed - " + e.Message);
                Assert.Fail("Test Failed - " + e.Message);
            }
        }

        [Test]
        public void Clear()
        {
            
            try
            {
                report.LogStep("Step 1");
                CalculatorSteps.ClickNine();

                report.LogStep("Step 2");
                CalculatorSteps.ClickOne();

                report.LogStep("Step 3");
                CalculatorSteps.ClickClear();

                report.LogAndScreenShot("Equation Result Screenshot");
                var calculationResult = CalculatorSteps.GetCalculationResultText();
                Assert.That(calculationResult.Replace("Display is ", "") == "0");
            }
            catch (Exception e)
            {
                report.FailAndScreenShot("Test Failed - " + e.Message);
                Assert.Fail("Test Failed - " + e.Message);
            }
        }

        [Test]
        public void ClearEntry()
        {
            try
            {
                report.LogStep("Step 1");
                CalculatorSteps.ClickTwo();

                report.LogStep("Step 2");
                CalculatorSteps.ClickOne();

                report.LogStep("Step 3");
                CalculatorSteps.ClickClearEntry();

                report.LogAndScreenShot("Equation Result Screenshot");
                var calculationResult = CalculatorSteps.GetCalculationResultText();

                Assert.That(calculationResult.Replace("Display is ", "") == "0");
            }
            catch (Exception e)
            {
                report.FailAndScreenShot("Test Failed - " + e.Message);
                Assert.Fail("Test Failed - " + e.Message);
            }
        }


        [Test]
        public void SwitchToScientificCalculatorAndCalculateExponents()
        {
            try
            {
                report.LogStep("Step 1");
                CalculatorSteps.ClickNavigationTab();
                CalculatorSteps.ClickScientificCalculator();

                report.LogStep("Step 2");
                CalculatorSteps.ClickFive();

                report.LogStep("Step 3");
                CalculatorSteps.ClickExponent();

                report.LogStep("Step 4");
                CalculatorSteps.ClickOne();

                report.LogStep("Step 5");
                CalculatorSteps.ClickZero();

                report.LogStep("Step 6");
                CalculatorSteps.ClickEquals();

                report.LogAndScreenShot("Equation Result Screenshot");
                var calculationResult = CalculatorSteps.GetCalculationResultText();

                Assert.That(calculationResult.Replace("Display is ", "") == "9,765,625");
            }
            catch (Exception e)
            {
                report.FailAndScreenShot("Test Failed - " + e.Message);
                Assert.Fail("Test Failed - " + e.Message);
            }

            
        }

    }
}