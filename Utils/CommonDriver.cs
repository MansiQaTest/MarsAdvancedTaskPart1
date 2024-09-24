using AdvancedTaskPart1.Pages;
using AdvancedTaskPart1.Pages.Components;
using AdvancedTaskPart1.Pages.Components.ProfilePage;
using AdvancedTaskPart1.Steps;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reactive;


namespace AdvancedTaskPart1.Utils
{
    public class CommonDriver
    {
        CommonDriver commonDriverObj;
        LoginPage loginPageObj;
        LoginSteps loginStepsObj;
        UserInformation userInformationObj;
        ProfileTabLanguage profileTabLanguageObj;
        ProfileTabSkills skillObj;
        ShareSkills shareSkillsObj;
        SearchSkills searchSkillsObj;
        Notifications notificationsObj;
        NotificationSteps notificationStepsObj;
        Homepage homepageObj;
        Homepagesteps homestepsObj;


        public static IWebDriver driver;
        public static ExtentReports extent;
        public static ExtentTest test;
        public static List<string> LanguageToDelete { get; set; } = new List<string>();
        public static List<string> SkillsToDelete { get;set; } = new List<string>();


        [OneTimeSetUp]
        public void ExtentReportSetup()
        {
            try
            {               

                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                var sparkReporter = new ExtentSparkReporter(@"D:\Mansi-Industryconnect\AdvancedTaskPart1\Reports\extentReport.html");
                extent = new ExtentReports();
                extent.AttachReporter(sparkReporter);
                driver.Navigate().GoToUrl("http://localhost:5000/Home");
                loginPageObj = new LoginPage();
                loginStepsObj = new LoginSteps();
                loginStepsObj.LoginActions();
                cleanLangSkillData();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        [SetUp]
        public void Initialization()
        {
           
            homestepsObj = new Homepagesteps();  
            var testName = TestContext.CurrentContext.Test.Name;
            test = extent.CreateTest(testName);
        }

        public void cleanLangSkillData() 
        {
            profileTabLanguageObj = new ProfileTabLanguage();
            skillObj = new ProfileTabSkills();
            profileTabLanguageObj.CleanLanguageData();
            skillObj.CleanSkillData();

        }

        [TearDown]
        public void Cleanup()
        {
            try
            {
                //Cleanup the testData
                foreach (var language in LanguageToDelete)
                {
                    try
                    {
                        profileTabLanguageObj.DeleteLanguage(language);
                        test.Log(Status.Info, $"Deleted language name '{language}' from the UI.");
                    }
                    catch (Exception cleanupEx)
                    {
                        test.Log(Status.Fail, $"Failed to delete language name during cleanup: {cleanupEx.Message}");
                    }
                }
                foreach (var Skill in SkillsToDelete)
                {
                    try
                    {
                        skillObj.DeleteSkill(Skill);
                        test.Log(Status.Info, $"Deleted skill name '{Skill}' from the UI.");
                    }
                    catch (Exception cleanupEx)
                    {
                        test.Log(Status.Fail, $"Failed to delete skill name during cleanup: {cleanupEx.Message}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred during cleanup: {e.Message}");
            }

        }

        [OneTimeTearDown]
        public void TeardownReport()
        {
            try
            {
                extent.Flush();

            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred during final teardown: {e.Message}");
            }

            finally
            {
                // Ensure WebDriver is disposed if not already
                if (driver != null)
                {
                    driver.Quit();
                    driver.Dispose();
                }
            }

        }
    }
}