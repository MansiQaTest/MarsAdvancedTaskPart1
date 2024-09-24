using AdvancedTaskPart1.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart1.Pages
{
    public class Homepage : CommonDriver
    {
        private IWebElement profileTab => driver.FindElement(By.XPath("//a[text()='Profile']"));
        private IWebElement ProfileDropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span/div/a[1]"));
        private IWebElement shareSkill => driver.FindElement(By.XPath("//a[contains(text(),'Share Skill')]"));
        private IWebElement searchSkill => driver.FindElement(By.XPath("//i[@class='search link icon']"));
        private IWebElement notification => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div"));
        private IWebElement dashboardNotification => driver.FindElement(By.XPath("//a[text()='Dashboard']"));
        private string e_profiledropdown = "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span/div/a[1]";
        private string e_profileTab = "//a[text()='Profile']";
        private string e_shareskill = "//a[contains(text(),'Share Skill')]";
        private string e_searchskill = "//i[@class='search link icon']";
        private string e_notification = "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div";
        private string e_dashboardnotification = "//a[text()='Dashboard']";
        public void clickprofiletab()
        {
           // WaitUtils.WaitToBeClickable(driver, "XPath", e_profiledropdown, 10);
            //ProfileDropdown.Click();

            WaitUtils.WaitToBeClickable(driver, "XPath", e_profileTab, 10);
            profileTab.Click();
        }

        public void clickshareskill()
        {
            WaitUtils.WaitToBeClickable(driver, "XPath", e_shareskill, 10);
            shareSkill.Click();
        }
        public void clicksearchskill() 
        {
            WaitUtils.WaitToBeClickable(driver, "XPath", e_searchskill, 10);
            searchSkill.Click();
        }

        public void clickNotificationPanel()
        {
            WaitUtils.WaitToBeClickable(driver, "XPath", e_notification, 10);
            notification.Click();
            WaitUtils.WaitToBeClickable(driver, "XPath", e_dashboardnotification, 10);
            dashboardNotification.Click();
        }
    }
}
