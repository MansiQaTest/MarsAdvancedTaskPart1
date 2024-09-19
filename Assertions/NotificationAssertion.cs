using AdvancedTaskPart1.Utils;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedTaskPart1.Pages;
using AdvancedTaskPart1.Pages.HeaderComponents;
using System.Reactive;
using System.ComponentModel;

namespace AdvancedTaskPart1.Assertions
{
    public class NotificationAssertion : CommonDriver
    {
        private IWebElement message => driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']"));
        private string e_message = "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']";
        public void SelectAllNotificationAssertion()
        {
            bool isClicked = clicked();
            Assert.That(clicked, Is.True);
            Console.WriteLine("Notifications Select All Clicked", clicked);
            test.Log(Status.Pass, "Notifications Select All Clicked :Test Passed");
        }
        public void UnSelectAllNotificationAssertion()
        {
            bool isUnClicked = Unclicked();
            Assert.That(Unclicked, Is.True);
            Console.WriteLine("Notifications UnSelect All Clicked", Unclicked);
            test.Log(Status.Pass, "Notifications UnSelect All Clicked :Test Passed");
        }

        public void MarkasReadNotificationAssertion()
        {
            WaitUtils.WaitToBeClickable(driver, "XPath", e_message, 10);
            string actualmessage = message.Text;
            string expectedMessage = "Notification updated";
            Assert.That(actualmessage, Is.EqualTo(expectedMessage), "The expected error message did not appear.");
            Console.WriteLine("Notifications read");
            test.Log(Status.Pass, "Notifications read :Test Passed");

        }

        public void LoadMoreNotificationAssertion()
        {
            bool isLoadMoreClicked = LoadMoreClicked();
            Assert.That(LoadMoreClicked, Is.True);
            Console.WriteLine("Loadmore Clicked", LoadMoreClicked);
            test.Log(Status.Pass, "Loadmore Clicked :Test Passed");
        }

        public void ShowLessNotificationAssertion()
        {
            bool isShowLessClicked = ShowLessClicked();
            Assert.That(ShowLessClicked, Is.True);
            Console.WriteLine("ShowLess Clicked", ShowLessClicked);
            test.Log(Status.Pass, "ShowLess Clicked :Test Passed");
        }

        public void DeleteNotificationAssertion() 
        {
            WaitUtils.WaitToBeClickable(driver, "XPath", e_message, 10);
            string actualmessage = message.Text;
            string expectedMessage = "Notification updated";
            Assert.That(actualmessage, Is.EqualTo(expectedMessage), "The expected error message did not appear.");
            Console.WriteLine("Notifications deleted");
            test.Log(Status.Pass, "Notifications deleted :Test Passed");
        }

        private bool clicked()
        {
            try
            {
                // Wait for the "Select All" button to be visible (adjust XPath if necessary)
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement selectAllButton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//i[@class='mouse pointer icon']")));

                // Click the "Select All" button
                selectAllButton.Click();

                // Optionally check a visual or functional confirmation that the button was clicked
                // For example, check if a certain element becomes visible after clicking
                // Return true if the button was clicked successfully
                return true;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Select All button not found: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while clicking 'Select All': {ex.Message}");
                return false;
            }
        }
        private bool Unclicked()
        {
            try
            {
                
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement selectAllButton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//i[@class='mouse pointer icon']")));

                
                selectAllButton.Click();
               
                IWebElement UnselectAllButton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@data-tooltip='Unselect all']")));

                UnselectAllButton.Click();

                
                return true;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Select All button not found: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while clicking 'Select All': {ex.Message}");
                return false;
            }
        }
        private bool LoadMoreClicked()
        {
            try
            {
                driver.Navigate().Refresh();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement Loadmore = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[6]/div/center/a")));
                Loadmore.Click();

                return true;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Select All button not found: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while clicking 'Select All': {ex.Message}");
                return false;
            }
        }
        private bool ShowLessClicked()
        {
            try
            {
                driver.Navigate().Refresh();

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement Loadmore = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[6]/div/center/a")));
                Loadmore.Click();
                
                IWebElement Showless = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[7]/div[1]/center/a")));
                Showless.Click();


                return true;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Select All button not found: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while clicking 'Select All': {ex.Message}");
                return false;
            }
        }
    }
}
