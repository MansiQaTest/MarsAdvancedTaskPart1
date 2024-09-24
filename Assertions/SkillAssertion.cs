using AdvancedTaskPart1.TestModel;
using AdvancedTaskPart1.Utils;
using AventStack.ExtentReports;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedTaskPart1.Pages.Components.ProfilePage;

namespace AdvancedTaskPart1.Assertions
{
    public class SkillAssertion : CommonDriver
    {
        ProfileTabSkills skillObj;
        private IWebElement errormessage => driver.FindElement(By.XPath(e_errorMessageXPath));
        private string e_errorMessageXPath = "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']";

        public SkillAssertion()
        {
            skillObj = new ProfileTabSkills();

        }
        public void addskillAssertion(string Skill)
        {

            // Retrieve the added skill
            string addedSkill = skillObj.GetSkill();

            // Log the expected and actual skill values
            Console.WriteLine($"Expected Skill: {Skill}");
            Console.WriteLine($"Actual Skill: {addedSkill}");

            // Assert that the added skill matches the expected skill
            Assert.That(addedSkill == Skill, "Actual skill and Expected skill do not match");

            // Assert that the skill is not null or empty, and if it is, fail the test
            Assert.That(!string.IsNullOrEmpty(addedSkill), $"Expected skill was not added. Actual skill: '{addedSkill}'");

            // Log the test as passed if all assertions succeed
            test.Log(Status.Pass, "Test passed successfully");

            // Add the skill to the list for cleanup
            SkillsToDelete.Add(Skill);

        }
        public void addSkillwithemptyAssertion()
        {
            string message = skillObj.GetErrorMessage();
            string expectedMessage = "Please enter skill and experience level";
            Assert.That(message, Is.EqualTo(expectedMessage), "The expected error message did not appear.");
            test.Log(Status.Pass, "Test passed successfully");
        }
        public void addSkillwithDuplicateAssertion(string Skill)
        {

            // Retrieve the actual error message
            string actualErrorMessage = skillObj.GetErrorMessage();

            // Assert that the actual error message matches the expected message
            Assert.That(actualErrorMessage, Is.EqualTo("This skill is already exist in your skill list."), "The expected error message did not appear.");

            // Assert that the error message is not null or empty, and if it is, fail the test
            Assert.That(!string.IsNullOrEmpty(actualErrorMessage), $"Expected message was not the same. Actual message: '{actualErrorMessage}'");

            // Log the test as passed if all assertions succeed
            test.Log(Status.Pass, "Test passed successfully");

            // Add the skill to the list for cleanup
            SkillsToDelete.Add(Skill);

        }

        public void CreateMulitipleDataofSkillAssertion()
        {
            List<SkillModel> Skills = JsonConvert.DeserializeObject<List<SkillModel>>(File.ReadAllText(@"D:\Mansi-Industryconnect\AdvancedTaskPart1\TestData\CreateMultipleDataofSkills.json"));
            List<string> expectedSkills = Skills.Select(c => c.Skill).ToList();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            List<string> actualSkills = new List<string>();

            for (int i = 0; i < expectedSkills.Count; i++)
            {
                // Construct the XPath for each skill dynamically
                string skillXPath = $"//div[@data-tab='second']//tbody[{i + 1}]/tr/td[1]";

                // Wait for each skill element to be visible
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(skillXPath)));

                // Get the actual Skill text
                IWebElement skillElement = driver.FindElement(By.XPath(skillXPath));
                actualSkills.Add(skillElement.Text.Trim());
            }

            // Compare actual Skill with expected skills
            foreach (var expectedLSkill in expectedSkills)
            {
                Assert.That(actualSkills, Does.Contain(expectedLSkill),
                    $"Expected Skills '{expectedLSkill}' was not found in the UI. Actual Skills: {string.Join(", ", actualSkills)}");
            }

            test.Log(Status.Pass, "All Skills were successfully created and verified.");

            // Add the skills to the delete list
            expectedSkills.ForEach(Skill => SkillsToDelete.Add(Skill));
        }

        public void addaddSkillwithInvalidAssertion(List<string> invalidSkills)
        {

            try
            {
                // Wait for the messages to appear
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                // Check if a success message is displayed
                try
                {
                    if (wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"))) != null)
                    {
                        Assert.Fail("Success message displayed instead of error message.");
                    }
                }
                catch (WebDriverTimeoutException)
                {
                    // Expected outcome, as we are looking for an error message
                }

                // Wait for the error message to be visible
                string actualErrorMessage = string.Empty;
                try
                {
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']")));
                    actualErrorMessage = skillObj.GetErrorMessage();
                }
                catch (WebDriverTimeoutException)
                {
                    Assert.Fail("Error message not displayed within the timeout period.");
                }

                // Assert the error message
                Assert.That(actualErrorMessage, Is.EqualTo("Please enter Valid data"), "The expected error message did not appear.");

                test.Log(Status.Pass, "Test passed successfully, error message is displayed.");


            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"An unexpected error occurred: {ex.Message}");
                throw;
            }
            finally
            {
                // Add skills to delete list, if needed
                foreach (var Skill in invalidSkills)
                {
                    try
                    {
                        SkillsToDelete.Add(Skill);
                    }
                    catch (Exception ex)
                    {
                        test.Log(Status.Warning, $"Exception occurred while adding skill to delete list: {ex.Message}");
                    }
                }
            }

        }

        public void editSkillAssertion(string Skill)
        {
            // Retrieve the updated skill
            string updatedSkill = skillObj.GetSkill();

            // Log the expected and actual skill values
            Console.WriteLine($"Expected Skill: {Skill}");
            Console.WriteLine($"Actual Skill: {updatedSkill}");

            // Assert that the updated skill matches the expected skill
            Assert.That(updatedSkill == Skill, "Actual skill and Expected skill do not match");

            // If the skill was not added (empty string or null), fail the test and log the result
            Assert.That(updatedSkill, Is.Not.Null.And.Not.Empty, $"Expected skill was not added. Actual skill: '{updatedSkill}'");
            test.Log(Status.Pass, "Test passed successfully");

            // Add the skill to the list for cleanup
            SkillsToDelete.Add(Skill);

        }

        public void editSkillDatawithEmptyAssertion(string Skill)
        {
            string message = string.Empty;

            try
            {
                WaitUtils.WaitToBeClickable(driver, "XPath", e_errorMessageXPath, 10);

                message = errormessage.Text;
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Error message did not appear within the expected time.");
            }

            // If the message is captured, assert its content
            string expectedMessage = "Please enter skill and experience level";
            Assert.That(message, Is.EqualTo(expectedMessage), "The expected error message did not appear.");

            test.Log(Status.Pass, "Test passed successfully");

            SkillsToDelete.Add(Skill);
        }

        public void EditSkillDatawithDuplicateAssertion(string Skill)
        {
            string message = skillObj.GetErrorMessage();
            string expectedMessage = "This skill is already added to your skill list.";
            Assert.That(message, Is.EqualTo(expectedMessage), "The expected error message did not appear.");
            test.Log(Status.Pass, "Test passed successfully");
            SkillsToDelete.Add(Skill);
        }
        public void deleteskillWhichisinListAssertion(string Skill)
        {
            try
            {

                // Verify that the skill is no longer present
                var skillAfterDeletion = skillObj.GetSkill();
                foreach (var Skills in SkillsToDelete)
                {
                    if (skillAfterDeletion.Contains(Skill))
                    {
                        test.Log(Status.Fail, $"Skill '{Skill}' was not deleted successfully.");
                        Assert.Fail($"Skill '{Skill}' was not deleted from the UI.");
                    }
                }

                test.Log(Status.Pass, "Skill were successfully deleted.");

                SkillsToDelete.Clear();
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"An unexpected error occurred: {ex.Message}");
                throw; // Ensure the test fails if an exception occurs
            }
            finally
            {
                if (SkillsToDelete == null || !SkillsToDelete.Any())
                {
                    test.Log(Status.Info, "No data to clean up.");
                }
                else
                {
                    try
                    {
                        foreach (var Skills in SkillsToDelete)
                        {
                            test.Log(Status.Info, $"Attempting to delete skill: {Skill}");
                        }
                    }
                    catch (Exception cleanupEx)
                    {
                        test.Log(Status.Fail, $"Failed during cleanup operation: {cleanupEx.Message}");
                    }
                }
            }

        }

        public void deleteskillWhichisnotinListAssertion(string Skill)
        {
            try
            {
                Skill = SkillsToDelete.First();

                var SkillBeforeDeletionAttempt = skillObj.GetSkill();

                var SkillAfterDeletionAttempt = skillObj.GetSkill();

                Assert.That(SkillAfterDeletionAttempt, Is.EquivalentTo(SkillAfterDeletionAttempt), "The list of skills should remain unchanged when attempting to delete non-existent data.");
                skillObj.DeleteSkill(Skill);

            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"An unexpected error occurred: {ex.Message}");
                throw; // Ensure the test fails if an exception occurs
            }

        }

    }
}
