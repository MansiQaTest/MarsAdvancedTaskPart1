using AdvancedTaskPart1.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart1.Pages.Components.ProfilePage
{
    public class ProfileMenuTab : CommonDriver
    {
        private IWebElement LanguageTab => driver.FindElement(By.XPath("//a[text()='Languages']"));
        private IWebElement SkillTab => driver.FindElement(By.XPath("//a[text()='Skills']"));
        private string e_languagetab = "//a[text()='Languages']";
        private string e_skilltab = "//a[text()='Skills']";

        public void ClickLanguageTab()
        {
            WaitUtils.WaitToBeClickable(driver, "XPath", e_languagetab, 10);
            LanguageTab.Click(); 
        }
        public void ClickSkillTab()
        {
            WaitUtils.WaitToBeClickable(driver, "XPath", e_skilltab, 10);
            SkillTab.Click();
        }
    }
}
