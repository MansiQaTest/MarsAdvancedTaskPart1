using AdvancedTaskPart1.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart1.Pages.HeaderComponents
{
    public class Notifications : CommonDriver
    {
        private IWebElement notificationDropdown => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div"));
        private IWebElement seeallnoficationlink => driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[1]/div[2]/div/div/div/span/div/div[2]/div/center/a"));
        private IWebElement SelectAll => driver.FindElement(By.XPath("//i[@class='mouse pointer icon']"));
        private IWebElement UnselectAll => driver.FindElement(By.XPath("//div[@data-tooltip='Unselect all']"));
        private IWebElement DeleteSection => driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[3]"));
        private IWebElement MarkasRead => driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[4]/i"));
        private IWebElement Loadmore => driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[6]/div/center/a"));
        private IWebElement ShowLess => driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[7]/div[1]/center/a"));
        private IWebElement errormessage => driver.FindElement(By.XPath(e_errormessage));
        private IWebElement successmessage => driver.FindElement(By.XPath(e_successmessage));
        private IWebElement deleteIcon => driver.FindElement(By.XPath("//i[@class='trash icon']"));
        private IWebElement selectCheckBoxIcon => driver.FindElement(By.XPath("//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[3]/input"));


        private string e_notificationDropdown => "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/div";
        private string e_seeallnotificationlink => "//*[@id=\"notification-section\"]/div[1]/div[2]/div/div/div/span/div/div[2]/div/center/a";
        private string e_selectall => "//i[@class='mouse pointer icon']";
        private string e_unselectall => "//div[@data-tooltip='Unselect all']";
        private string e_loadmore => "//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[6]/div/center/a";
        private string e_showless => "//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[7]/div[1]/center/a";
        private string e_markasread => "//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[1]/div[4]/i";
        private string e_errormessage = "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']";
        private string e_successmessage = "//div[@class='ns-box ns-growl ns-effect-jelly ns-type-success ns-show']";
        private string e_delete = "//i[@class='trash icon']";
        private string e_selectCheckBoxIcon = "//*[@id=\"notification-section\"]/div[2]/div/div/div[3]/div[2]/span/span/div/div[1]/div/div/div[3]/input";

        public void SelectAllNotification()
        {
            Thread.Sleep(2000);
            
            WaitUtils.WaitToBeClickable(driver, "XPath", e_selectall, 10);
            SelectAll.Click();

        }
        public void UnSelectAllNotification()
        {
            Thread.Sleep(2000);

            WaitUtils.WaitToBeClickable(driver, "XPath", e_selectall, 10);
            SelectAll.Click();
            Thread.Sleep(20000);

            WaitUtils.WaitToBeClickable(driver, "XPath", e_unselectall, 20);
            UnselectAll.Click();
            Thread.Sleep(2000);
        }

        public void MarkasReadNotification()
        {
            Thread.Sleep(2000);
            
            WaitUtils.WaitToBeClickable(driver, "XPath", e_selectall, 10);
            SelectAll.Click();
            Thread.Sleep(20000);

            WaitUtils.WaitToBeClickable(driver, "XPath", e_markasread, 20);
            MarkasRead.Click();
         
        }

        public void LoadmoreNotification()
        {
            Thread.Sleep(2000);
            
            WaitUtils.WaitToBeClickable(driver, "XPath", e_loadmore, 10);
            Loadmore.Click();
        }

        public void ShowLessNotification()
        {
            Thread.Sleep(2000);
          
            WaitUtils.WaitToBeClickable(driver, "XPath", e_loadmore, 10);
            Loadmore.Click();

            WaitUtils.WaitToBeClickable(driver, "XPath", e_showless, 10);
            ShowLess.Click();

        }

        public void DeleteNotification()
        {
            Thread.Sleep(2000);
            
            WaitUtils.WaitToBeClickable(driver, "XPath", e_selectCheckBoxIcon, 10);
            selectCheckBoxIcon.Click();

            WaitUtils.WaitToBeClickable(driver, "XPath", e_delete, 10);
            deleteIcon.Click();

        }


    }
}
