using NUnit.Framework;
using System.Diagnostics;

namespace WinAppDriverProject
{
    public class NotepadTest : BaseTest
    {
        private const string notepadAppPath = @"C:\Windows\System32\notepad.exe";

        private NotepadSteps notepadSteps;

        [SetUp]
        public void TestSetup()
        {
            Process.GetProcesses().Where(process => process.ProcessName == "notepad").ToList().ForEach(process => process.Kill());
            CreateDriverFromPath(notepadAppPath, "Notepad");
            report = new Reporter(driver, Guid.NewGuid());
            report.InitialiseReport();
            report.Log("Booting Notepad");
            notepadSteps = new NotepadSteps(driver, report);
        }

        [TearDown]
        public void TearDown()
        {
            report.Log("Closing Notepad");
            driver.CloseApp();

            report.FinaliseReport();
        }

        [Test]
        public void InputAndDeleteText()
        {
            try
            {
                report.LogStep("Step 1");
                string inputText = "Automation Testing";
                notepadSteps.ClickTextBox();
                notepadSteps.TypeIntoTextBox(inputText);
                report.LogAndScreenShot("Notepad after text input screenshot:");
                Assert.That(notepadSteps.GetContentsOfTextBox() == inputText);

                report.LogStep("Step 2");
                notepadSteps.DeleteContentsOfTextBox();
                report.LogAndScreenShot("Notepad after deleting text input screenshot:");
                Assert.That(notepadSteps.GetContentsOfTextBox() == "");
            }
            catch (Exception e)
            {
                report.FailAndScreenShot("Test Failed - " + e.Message);
                Assert.Fail("Test Failed - " + e.Message);
            }
        }

        
    }
}