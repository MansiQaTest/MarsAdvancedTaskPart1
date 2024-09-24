using AdvancedTaskPart1.TestModel;
using AdvancedTaskPart1.Utils;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedTaskPart1.Pages.Components;

namespace AdvancedTaskPart1.Assertions
{
    public class ShareSkillAssertion : CommonDriver
    {
        ShareSkills shareSkillsObj;
        ShareSkillModel shareskillModelObj;

        public ShareSkillAssertion()
        {
            shareSkillsObj = new ShareSkills();
            shareskillModelObj = new ShareSkillModel();
        }
        public void AddShareSkillAssertion(ShareSkillModel AddShareSkill)
        {
            string addedTitle = shareSkillsObj.GetList();

            // Log the expected and actual skill title values
            Console.WriteLine($"Expected Skill Title: {AddShareSkill.Title}");
            Console.WriteLine($"Actual Skill Title: {addedTitle}");

            // Assert that the added skill matches the expected skill
            Assert.That(addedTitle == AddShareSkill.Title, "Actual skill title and Expected skill title do not match");

            // Assert that the skill is not null or empty, and if it is, fail the test
            Assert.That(!string.IsNullOrEmpty(addedTitle), $"Expected skill title was not added. Actual skill title: '{addedTitle}'");

            // Log the test as passed if all assertions succeed
            test.Log(Status.Pass, "Test passed successfully");

            // Add the skill to the list for cleanup
            // CommonDriver.SkillsToDelete.Add(Skill);


        }
        public void AddShareSkillwithemptyAssertion(ShareSkillModel AddShareSkill)
        {
            string message = shareSkillsObj.GetErrorMessage();
            string expectedMessage = "Please complete the form correctly.";
            Assert.That(message, Is.EqualTo(expectedMessage), "The expected error message did not appear.");
            test.Log(Status.Pass, "Test passed successfully");

        }

        public void AddShareSkillwithduplicateAssertion(ShareSkillModel AddShareSkill)
        {
            try
            {
                // Wait for the messages to appear
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                // Wait for the error message to be visible
                string actualErrorMessage = string.Empty;
                try
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']")));
                    actualErrorMessage = shareSkillsObj.GetErrorMessage();
                }
                catch (WebDriverTimeoutException)
                {
                    Assert.Fail("Error message not displayed.");
                }

                // Assert the error message
                Assert.That(actualErrorMessage, Is.EqualTo("This data already exist in List"), "The expected error message did not appear.");

                test.Log(Status.Pass, "Test passed successfully, error message is displayed.");


            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"An unexpected error occurred: {ex.Message}");
                throw;
            }

        }
        public void AddShareSkillwithinvalidAssertion(ShareSkillModel AddShareSkill)
        {
            try
            {
                // Wait for the messages to appear
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                // Wait for the error message to be visible
                string actualErrorMessage = string.Empty;
                try
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']")));
                    actualErrorMessage = shareSkillsObj.GetErrorMessage();
                }
                catch (WebDriverTimeoutException)
                {
                    Assert.Fail("Error message not displayed.");
                }

                // Assert the error message
                Assert.That(actualErrorMessage, Is.EqualTo("Please complete the form correctly."), "The expected error message did not appear.");

                test.Log(Status.Pass, "Test passed successfully, error message is displayed.");


            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"An unexpected error occurred: {ex.Message}");
                throw;
            }

        }
    }
}
