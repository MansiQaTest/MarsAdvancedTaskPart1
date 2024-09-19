using AdvancedTaskPart1.Utils;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart1.Pages.HeaderComponents
{
    public class SearchSkills : CommonDriver
    {
        // Element locators
        private IWebElement searchtext => driver.FindElement(By.XPath("//div[@class='ui small icon input search-box']/input[@type='text']"));
        private IWebElement searchclick => driver.FindElement(By.XPath("//div[@class='ui small icon input search-box']/i[@class='search link icon']"));

        // Locator strings for wait conditions
        private string e_searchtext = "//div[@class='ui small icon input search-box']/input[@type='text']";
        private string e_searchclick = "//div[@class='ui small icon input search-box']/i[@class='search link icon']";

        // Method to perform search and select a category
        public void SearchSkillByCategory(string searchString, string category)
        {
            // Wait for the search box to be visible
            WaitUtils.WaitToBeVisible(driver, "XPath", e_searchtext, 10);

            // Enter the search text and click the search button
            searchtext.SendKeys(searchString);
            searchclick.Click();

            // Dynamically create the XPath for category selection
            string e_categoryselection = $"//a[@role='listitem' and contains(@class, 'item category') and contains(normalize-space(.), '{category}')]";

            // Wait for the category element to be visible
            WaitUtils.WaitToBeVisible(driver, "XPath", e_categoryselection, 10);

            // Locate the category element and click it
            IWebElement categoryElement = driver.FindElement(By.XPath(e_categoryselection));
            categoryElement.Click();
        }

        public void SearchSkillByCatSubCategory(string searchString, string category, string subcategory)
        { 
            Thread.Sleep(1000);
            // Wait for the search box to be visible
            WaitUtils.WaitToBeVisible(driver, "XPath", e_searchtext, 10);

            // Enter the search text and click the search button
            searchtext.SendKeys(searchString);
            searchclick.Click();

            // Dynamically create the XPath for category selection
            string e_categoryselection = $"//a[@role='listitem' and contains(@class, 'item category') and contains(normalize-space(.), '{category}')]";

            // Wait for the category element to be visible
            WaitUtils.WaitToBeVisible(driver, "XPath", e_categoryselection, 10);

            // Locate the category element and click it
            IWebElement categoryElement = driver.FindElement(By.XPath(e_categoryselection));
            categoryElement.Click();

            string e_subcategoryselection = $"//a[@role='listitem' and contains(@class, 'item subcategory') and contains(normalize-space(.), '{subcategory}')]";

            // Wait for the category element to be visible
            WaitUtils.WaitToBeVisible(driver, "XPath", e_subcategoryselection, 10);

            // Locate the category element and click it
            IWebElement subcategoryElement = driver.FindElement(By.XPath(e_subcategoryselection));
            subcategoryElement.Click();

        }

        public void SearchSkillByFilters(string searchString, string category, string subcategory, string filterOption)
        {
            // Wait for the search box to be visible
            WaitUtils.WaitToBeVisible(driver, "XPath", e_searchtext, 10);

            // Enter the search text and click the search button
            searchtext.SendKeys(searchString);
            searchclick.Click();

            // Dynamically create the XPath for category selection
            string e_categoryselection = $"//a[@role='listitem' and contains(@class, 'item category') and contains(normalize-space(.), '{category}')]";

            // Wait for the category element to be clickable
            WaitUtils.WaitToBeClickable(driver, "XPath", e_categoryselection, 10);

            // Locate the category element and click it
            IWebElement categoryElement = driver.FindElement(By.XPath(e_categoryselection));
            categoryElement.Click();

            // Dynamically create the XPath for subcategory selection
            string e_subcategoryselection = $"//a[@role='listitem' and contains(@class, 'item subcategory') and contains(normalize-space(.), '{subcategory}')]";

            // Wait for the subcategory element to be clickable
            WaitUtils.WaitToBeVisible(driver, "XPath", e_subcategoryselection, 20);

            // Locate the subcategory element and click it
            IWebElement subcategoryElement = driver.FindElement(By.XPath(e_subcategoryselection));
            subcategoryElement.Click();
            Thread.Sleep(1000);

            // Use explicit wait
            string e_filterselection = $"//button[normalize-space(text())='{filterOption}']";

            // Wait for the filter element to be clickable
            WaitUtils.WaitToBeVisible(driver, "XPath", e_filterselection, 20);

            // Locate the filter element and click it
           
                IWebElement filterElement = driver.FindElement(By.XPath(e_filterselection));
                filterElement.Click();           
           
        }

    }

}
