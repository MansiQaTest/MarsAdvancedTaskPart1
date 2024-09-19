using AdvancedTaskPart1.Assertions;
using AdvancedTaskPart1.Pages.HeaderComponents;
using AdvancedTaskPart1.TestModel;
using AdvancedTaskPart1.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart1.Steps
{
    public class NotificationSteps : CommonDriver
    {
        Notifications notificationsObj;
        NotificationAssertion notificationAssertionObj;
        private IWebElement notificationDropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div"));
        private IWebElement seeallnoficationlink => driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[1]/div[2]/div/div/div/span/div/div[2]/div/center/a/"));

        private string e_notificationDropdown => "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div";
        private string e_seeallnotificationlink => "//*[@id=\"notification-section\"]/div[1]/div[2]/div/div/div/span/div/div[2]/div/center/a";

        public NotificationSteps()
        {
            notificationsObj = new Notifications();
            notificationAssertionObj = new NotificationAssertion();
        }
        public void Gotonotificationpage()
        {
            WaitUtils.WaitToBeVisible(driver, "XPath", e_notificationDropdown, 10);
            notificationDropdown.Click();

            IWebElement dashboardNotification = driver.FindElement(By.LinkText("Dashboard"));
            dashboardNotification.Click();
        }
        public void NotificationSelectAll()
        {           
           notificationsObj.SelectAllNotification();
           notificationAssertionObj.SelectAllNotificationAssertion();

        }
        public void NotificationUnSelectAll()
        {
            notificationsObj.UnSelectAllNotification();
            notificationAssertionObj.UnSelectAllNotificationAssertion();

        }
        public void NotificationMarkasRead() 
        {

            notificationsObj.MarkasReadNotification();
            notificationAssertionObj.MarkasReadNotificationAssertion();
        }

        public void NotificationLoadmore()
        {
            notificationsObj.LoadmoreNotification();
            notificationAssertionObj.LoadMoreNotificationAssertion();
        }

        public void NotificationShowLess() 
        {
            notificationsObj.ShowLessNotification();
            notificationAssertionObj.ShowLessNotificationAssertion();
        }

        public void NotificationDelete() 
        {
            notificationsObj.DeleteNotification();
            notificationAssertionObj.DeleteNotificationAssertion();
        }
    }
}
