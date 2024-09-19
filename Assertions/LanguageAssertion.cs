using AdvancedTaskPart1.Pages;
using AdvancedTaskPart1.Pages.ProfileComponents;
using AdvancedTaskPart1.TestModel;
using AdvancedTaskPart1.Utils;
using AventStack.ExtentReports;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedTaskPart1.Steps;

namespace AdvancedTaskPart1.Assertions
{
    public class LanguageAssertion : CommonDriver
    {
        
        Language languageObj;
     
        public LanguageAssertion()
        {
            languageObj = new Language();
            
        }
        public void addLanguageAssertion(string language)
        {

            // Retrieve the added language
            string addedLanguage = languageObj.GetLanguage();

            // Log the expected and actual language values
            Console.WriteLine($"Expected Language: {language}");
            Console.WriteLine($"Actual Language: {addedLanguage}");

            // Assert that the added language matches the expected language
            Assert.That(addedLanguage == language, "Actual language and Expected language do not match");

            // Assert that the language is not null or empty, and if it is, fail the test
            Assert.That(!string.IsNullOrEmpty(addedLanguage), $"Expected language was not added. Actual language: '{addedLanguage}'");

            // Log the test as passed if all assertions succeed
            test.Log(Status.Pass, "Test passed successfully");

            // Add the language to the list for cleanup
            CommonDriver.LanguageToDelete.Add(language);

        }

        public void addLanguagewithemptyAssertion()
        {
            string message = languageObj.GetErrorMessage();
            string expectedMessage = "Please enter language and level";
            Assert.That(message, Is.EqualTo(expectedMessage), "The expected error message did not appear.");
            test.Log(Status.Pass, "Test passed successfully");
        }
        public void addLanguagewithduplicateAssertion(string language)
        {

            // Retrieve the actual error message
            string actualErrorMessage = languageObj.GetErrorMessage();

            // Assert that the actual error message matches the expected message
            Assert.That(actualErrorMessage, Is.EqualTo("This language is already exist in your language list."), "The expected error message did not appear.");

            // Assert that the error message is not null or empty, and if it is, fail the test
            Assert.That(!string.IsNullOrEmpty(actualErrorMessage), $"Expected message was not the same. Actual message: '{actualErrorMessage}'");

            // Log the test as passed if all assertions succeed
            test.Log(Status.Pass, "Test passed successfully");

            // Add the language to the list for cleanup
            CommonDriver.LanguageToDelete.Add(language);

        }
        public void createMultipleDataAssertion()
        {
            List<LanguageModel> languages = JsonConvert.DeserializeObject<List<LanguageModel>>(File.ReadAllText(@"D:\Mansi-Industryconnect\AdvancedTaskPart1\TestData\CreateMultipleDataofLanguage.json"));
            List<string> expectedLanguages = languages.Select(c => c.name).ToList();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            List<string> actualLanguages = new List<string>();

            for (int i = 0; i < expectedLanguages.Count; i++)
            {
                // Construct the XPath for each language dynamically
                string languageXPath = $"//div[@data-tab='first']//tbody[{i + 1}]/tr/td[1]";

                // Wait for each language element to be visible
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(languageXPath)));

                // Get the actual language text
                IWebElement languageElement = driver.FindElement(By.XPath(languageXPath));
                actualLanguages.Add(languageElement.Text.Trim());
            }

            // Compare actual languages with expected languages
            foreach (var expectedLanguage in expectedLanguages)
            {
                Assert.That(actualLanguages, Does.Contain(expectedLanguage),
                    $"Expected language '{expectedLanguage}' was not found in the UI. Actual languages: {string.Join(", ", actualLanguages)}");
            }

            test.Log(Status.Pass, "All languages were successfully created and verified.");

            // Add the languages to the delete list
            expectedLanguages.ForEach(language => CommonDriver.LanguageToDelete.Add(language));
        }

        public void addLanguagewithInvalidAssertion(List<string> invalidLanguages)
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
                    actualErrorMessage = languageObj.GetErrorMessage();
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
                // Add languages to delete list, if needed
                foreach (var language in invalidLanguages)
                {
                    try
                    {
                        CommonDriver.LanguageToDelete.Add(language);
                    }
                    catch (Exception ex)
                    {
                        test.Log(Status.Warning, $"Exception occurred while adding language to delete list: {ex.Message}");
                    }
                }
            }

        }

        public void add5thRecordAssertion(List<string> addedlanguages)
        {
            try
            {

                // Check if a success message is displayed
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

                try
                {
                    // Wait until the element is either visible or the timeout is reached
                    var addButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@data-tab='first']//div[@class ='ui teal button ']")));

                    // If the button is found, fail the test
                    Assert.Fail("Add button for additional language records should not be visible.");
                }
                catch (WebDriverTimeoutException)
                {
                    // If the button is not found, the test will pass
                    test.Log(Status.Pass, "Add button is not visible as expected after adding the 5th record.");

                }
                catch (NoSuchElementException)
                {

                    test.Log(Status.Pass, "Add button is not found, as expected.");
                }

            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"An unexpected error occurred: {ex.Message}");
                throw;
            }
            finally
            {
                // Add languages to delete list, if needed
                foreach (var language in addedlanguages)
                {
                    try
                    {
                        CommonDriver.LanguageToDelete.Add(language);
                    }
                    catch (Exception ex)
                    {
                        test.Log(Status.Warning, $"Exception occurred while adding language to delete list: {ex.Message}");
                    }
                }
            }

        }
        public void editLanguageAssertion(string language)
        {
            // Retrieve the updated language
            string updatedlanguage = languageObj.GetLanguage();

            // Log the expected and actual language values
            Console.WriteLine($"Expected Language: {language}");
            Console.WriteLine($"Actual Language: {updatedlanguage}");

            // Assert that the updated language matches the expected language
            Assert.That(updatedlanguage == language, "Actual language and Expected language do not match");

            // If the language was not added (empty string or null), fail the test and log the result
            Assert.That(updatedlanguage, Is.Not.Null.And.Not.Empty, $"Expected language was not added. Actual language: '{updatedlanguage}'");
            test.Log(Status.Pass, "Test passed successfully");

            // Add the language to the list for cleanup
            CommonDriver.LanguageToDelete.Add(language);


        }
        public void editLanguagewithemptyAssertion()
        {
            string message = languageObj.GetErrorMessage();
            string expectedMessage = "Please enter language and level";
            Assert.That(message, Is.EqualTo(expectedMessage), "The expected error message did not appear.");
            test.Log(Status.Pass, "Test passed successfully");
        } 


        public void editLanguagewithduplicateAssertion(string language)
        {
            string message = languageObj.GetErrorMessage();
            string expectedMessage = "This language is already added to your language list.";
            Assert.That(message, Is.EqualTo(expectedMessage), "The expected error message did not appear.");
            test.Log(Status.Pass, "Test passed successfully");
            CommonDriver.LanguageToDelete.Add(language);
        }

        public void deleteLanguageWhichisinListAssertion(string language)
        {
            try
            {

                // Verify that the degree is no longer present
                var languageAfterDeletion = languageObj.GetLanguage();
                foreach (var languages in CommonDriver.LanguageToDelete)
                {
                    if (languageAfterDeletion.Contains(language))
                    {
                        test.Log(Status.Fail, $"Degree '{language}' was not deleted successfully.");
                        Assert.Fail($"Degree '{language}' was not deleted from the UI.");
                    }
                }

                test.Log(Status.Pass, "language were successfully deleted.");

                LanguageToDelete.Clear();
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"An unexpected error occurred: {ex.Message}");
                throw; // Ensure the test fails if an exception occurs
            }
            finally
            {
                if (CommonDriver.LanguageToDelete == null || !CommonDriver.LanguageToDelete.Any())
                {
                    test.Log(Status.Info, "No data to clean up.");
                }
                else
                {
                    try
                    {
                        foreach (var languages in CommonDriver.LanguageToDelete)
                        {
                            test.Log(Status.Info, $"Attempting to delete language: {language}");
                        }
                    }
                    catch (Exception cleanupEx)
                    {
                        test.Log(Status.Fail, $"Failed during cleanup operation: {cleanupEx.Message}");
                    }
                }
            }

        }
        public void deleteLanguageWhichisnotinListAssertion(string language)
        {
            try
            {
                language = LanguageToDelete.First();

                var languageBeforeDeletionAttempt = languageObj.GetLanguage(); 

                var languageAfterDeletionAttempt = languageObj.GetLanguage();

                Assert.That(languageAfterDeletionAttempt, Is.EquivalentTo(languageAfterDeletionAttempt), "The list of degrees should remain unchanged when attempting to delete non-existent data.");
                languageObj.DeleteLanguage(language);
                           
            }
            catch (Exception ex)
            {
                test.Log(Status.Fail, $"An unexpected error occurred: {ex.Message}");
                throw; // Ensure the test fails if an exception occurs
            }

        }
    }
}

