using AdvancedTaskPart1.TestModel;
using AdvancedTaskPart1.Utils;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart1.Assertions
{
    public class SearchSkillsAssertion : CommonDriver
    {
        private IWebElement verifySkill => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/div[1]/a[2]"));
        private IWebElement category => driver.FindElement(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[1]/div/div[2]"));
        private IWebElement screenmessage => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/h3"));
        private IWebElement invMsg => driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/h3")); 
        private string e_chkCategory => "//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[1]/div/div[2]";
        private string e_screenmessage => "//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/h3";
        private string e_invMsg = "No results found, please select a new category!";
        
        public void SearchSkillByAllCategoriesAssertion(string Category, string searchString)
        {
            try
            {
                Thread.Sleep(1000);
                // Check if an error message is displayed for invalid input before clicking verifySkill
                if (IsErrorMessageDisplayed())
                {
                    // Log if the error message is displayed due to invalid input
                    test.Log(Status.Pass, $"Invalid search input '{searchString}', error message displayed.");
                    Console.WriteLine($"Invalid search input '{searchString}', error message displayed.");
                    return; // Exit the method as there's no point in proceeding further
                }

                // Proceed to click verifySkill only if no error message was displayed
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                var verifySkillElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/div[1]/a[2]")));
                verifySkillElement.Click();

                // Wait for the category element to be visible and get the text
                var categoryElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[1]/div/div[2]")));
                string e_chkCategory = categoryElement.Text;

                // Compare the category and log results
                if (e_chkCategory == Category)
                {
                    test.Log(Status.Pass, $"SearchSkill By Category '{Category}' Verified Successfully for search string '{searchString}'");
                    Console.WriteLine($"SearchSkill By Category '{Category}' Verified Successfully for search string '{searchString}'");
                }
                else
                {
                    test.Log(Status.Fail, $"Required Skill doesn't exist in the category '{Category}' for search string '{searchString}'");
                    Console.WriteLine($"Required Skill doesn't exist in the category '{Category}' for search string '{searchString}'");
                }
            }
            catch (Exception ex)
            {
                // Log if there's an exception during the search
                test.Log(Status.Fail, $"An error occurred during the search: {ex.Message}");
                Console.WriteLine($"An error occurred during the search: {ex.Message}");
            }
        }

        // Helper method to check if error message is displayed
        public bool IsErrorMessageDisplayed()
        {
            try
            {
                // Example selector for error message, change according to your actual UI
                var errorMessageElement = driver.FindElement(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/h3"));
                return errorMessageElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                // Error message not found, return false
                return false;
            }
        }

        public void SearchSkillByCatSubCategoryAssertion(string Category, string subcategory ,string searchString)
        {
            try
            {
                Thread.Sleep(1000);
                // Check if an error message is displayed for invalid input before clicking verifySkill
                if (IsErrorMessageDisplayed())
                {
                    // Log if the error message is displayed due to invalid input
                    test.Log(Status.Pass, $"Invalid search input '{searchString}', error message displayed.");
                    Console.WriteLine($"Invalid search input '{searchString}', error message displayed.");
                    return; // Exit the method as there's no point in proceeding further
                }

                // Proceed to click verifySkill only if no error message was displayed
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                var verifySkillElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/div[1]/a[2]")));
                verifySkillElement.Click();

                // Wait for the category element to be visible and get the text
                var categoryElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[1]/div/div[2]")));
                string e_chkCategory = categoryElement.Text;
                // Wait for the subcategory element to be visible and get the text
                var subcategoryElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[2]/div/div[2]")));
                string e_chkSubcategory = subcategoryElement.Text;

                // Compare the category and log results
                if (e_chkCategory == Category && e_chkSubcategory == subcategory)
                {
                    test.Log(Status.Pass, $"SearchSkill By Category '{Category}' and Subcategory '{subcategory}' Verified Successfully for search string '{searchString}'");
                    Console.WriteLine($"SearchSkill By Category '{Category}' and Subcategory '{subcategory}' Verified Successfully for search string '{searchString}'");
                }
                else
                {
                    test.Log(Status.Fail, $"Required Skill doesn't exist in the category '{Category}' or subcategory '{subcategory}' for search string '{searchString}'");
                    Console.WriteLine($"Required Skill doesn't exist in the category '{Category}' or subcategory '{subcategory}' for search string '{searchString}'");
                }
            }
            catch (Exception ex)
            {
                // Log if there's an exception during the search
                test.Log(Status.Fail, $"An error occurred during the search: {ex.Message}");
                Console.WriteLine($"An error occurred during the search: {ex.Message}");
            }

        }

        public void SearchSkillByFilterAssertion(string searchString, string Category, string subcategory, string filterOption)
        {
            try
            {
                Thread.Sleep(1000);
                // Check if an error message is displayed for invalid input before clicking verifySkill
                if (IsErrorMessageDisplayed())
                {
                    // Log if the error message is displayed due to invalid input
                    test.Log(Status.Pass, $"Invalid search input '{searchString}', error message displayed.");
                    Console.WriteLine($"Invalid search input '{searchString}', error message displayed.");
                    return; // Exit the method as there's no point in proceeding further
                }

                // Proceed to click verifySkill only if no error message was displayed
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                var verifySkillElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"service-search-section\"]/div[2]/div/section/div/div[2]/div/div[2]/div/div/div[1]/div[1]/a[2]")));
                verifySkillElement.Click();

                // Wait for the category element to be visible and get the text
                var categoryElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[1]/div/div[2]")));
                string e_chkCategory = categoryElement.Text;

                // Wait for the subcategory element to be visible and get the text
                var subcategoryElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[2]/div/div[2]")));
                string e_chkSubcategory = subcategoryElement.Text;

                // Wait for the filteroption element to be visible and get the text
                var filterElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"service-detail-section\"]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[3]/div/div[2]")));
                string e_chkFilter = filterElement.Text;

                // Compare the category and log results
                if (e_chkCategory == Category && e_chkSubcategory == subcategory && e_chkFilter == filterOption)
                {
                    test.Log(Status.Pass, $"SearchSkill By Category '{Category}' Subcategory '{subcategory}' and Filter '{filterOption}' Verified Successfully for search string '{searchString}'");
                    Console.WriteLine($"SearchSkill By Category '{Category}' Subcategory '{subcategory}' and Filter '{filterOption}' Verified Successfully for search string '{searchString}'");
                }
                else
                {
                    test.Log(Status.Fail, $"Required Skill doesn't exist in the category '{Category}' subcategory '{subcategory}' or Filter '{filterOption}' for search string '{searchString}'");
                    Console.WriteLine($"Required Skill doesn't exist in the category '{Category}' subcategory '{subcategory}' or Filter '{filterOption}' for search string '{searchString}'");
                }
            }
            catch (Exception ex)
            {
                // Log if there's an exception during the search
                test.Log(Status.Fail, $"An error occurred during the search: {ex.Message}");
                Console.WriteLine($"An error occurred during the search: {ex.Message}");
            }

        }
    }
}
