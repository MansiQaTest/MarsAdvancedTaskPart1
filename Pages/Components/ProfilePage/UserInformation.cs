using AdvancedTaskPart1.Steps;
using AdvancedTaskPart1.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AdvancedTaskPart1.Pages.Components.ProfilePage
{
    public class UserInformation : CommonDriver
    {
        Homepagesteps HomepagestepsObj;
        private IWebElement editAvailability => driver.FindElement(By.XPath("(//div[@class='item']//div[@class='right floated content']//i[@class='right floated outline small write icon'])[1]"));
        private IWebElement editHours => driver.FindElement(By.XPath("(//div[@class='item']//div[@class='right floated content']//i[@class='right floated outline small write icon'])[2]"));
        private IWebElement editEarnTarget => driver.FindElement(By.XPath("(//div[@class='item']//div[@class='right floated content']//i[@class='right floated outline small write icon'])[3]"));
        private IWebElement DropDownofAvailability => driver.FindElement(By.XPath("//div[@class='item']//select[@name='availabiltyType']"));
        private IWebElement DropDownofAvailableHour => driver.FindElement(By.XPath("//div[@class='item']//select[@name='availabiltyHour']"));
        private IWebElement DropDownofEarningTarget => driver.FindElement(By.XPath("//div[@class='item']//select[@name='availabiltyTarget']"));
        private IWebElement errormessage => driver.FindElement(By.XPath(e_errormessage));
        private IWebElement successmessage => driver.FindElement(By.XPath(e_successmessage));

        private string e_EditAvailability = "(//div[@class='item']//div[@class='right floated content']//i[@class='right floated outline small write icon'])[1]";
        private string e_EditHours = "(//div[@class='item']//div[@class='right floated content']//i[@class='right floated outline small write icon'])[2]";
        private string e_EditEarnTarget = "(//div[@class='item']//div[@class='right floated content']//i[@class='right floated outline small write icon'])[3]";
        private string e_errormessage = "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']";
        private string e_successmessage = "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']";
        private string e_dropdownavailability = "//div[@class='item']//select[@name='availabiltyType']";
        private string e_dropdownAvailableHours = "//div[@class='item']//select[@name='availabiltyHour']";
        private string e_dropdownearntarget = "//div[@class='item']//select[@name='availabiltyTarget']";
        public UserInformation()
        {
            HomepagestepsObj = new Homepagesteps();
           
        }
        public void editAvailabilityOfUser(string availabilityType)
        {
            //WaitForPopupToDisappear();
            HomepagestepsObj.clickOnProfileTab();

            WaitUtils.WaitToBeClickable(driver, "XPath", e_EditAvailability, 10);
            editAvailability.Click();

            WaitUtils.WaitToBeClickable(driver, "XPath", e_dropdownavailability, 10);
            DropDownofAvailability.Click();

            var selectAvailabilityDropdown = new SelectElement(DropDownofAvailability);
            selectAvailabilityDropdown.SelectByValue(availabilityType);

        }

        public void editHoursOfUser(string availableHours)
        {
            HomepagestepsObj.clickOnProfileTab();
            WaitForPopupToDisappear();

            WaitUtils.WaitToBeClickable(driver, "XPath", e_EditHours, 10);
            editHours.Click();

            WaitUtils.WaitToBeClickable(driver, "XPath", e_dropdownAvailableHours, 10);
            DropDownofAvailableHour.Click();

            var selectHoursDropdown = new SelectElement(DropDownofAvailableHour);
            selectHoursDropdown.SelectByValue(availableHours);


        }

        public void editEarnTargetOfUser(string earntarget)
        {
            WaitForPopupToDisappear();
            HomepagestepsObj.clickOnProfileTab();
            WaitUtils.WaitToBeClickable(driver, "XPath", e_EditEarnTarget, 10);
            editEarnTarget.Click();

            WaitUtils.WaitToBeClickable(driver, "XPath", e_dropdownearntarget, 10);
            DropDownofEarningTarget.Click();

            var selectEarningDropdown = new SelectElement(DropDownofEarningTarget);
            selectEarningDropdown.SelectByValue(earntarget);

        }
        public string GetErrorMessage()
        {
            WaitUtils.WaitToBeVisible(driver, "XPath", e_errormessage, 1);
            return errormessage.Text;

        }
        public string GetSuccessMessage()
        {
            WaitUtils.WaitToBeVisible(driver, "XPath", e_successmessage, 10);
            return successmessage.Text;
        }
        private void WaitForPopupToDisappear()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='ns-box-inner']")));
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("The popup did not disappear within the expected time.");
            }
        }
    }
}
