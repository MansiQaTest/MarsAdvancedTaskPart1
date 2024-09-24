using AdvancedTaskPart1.Utils;
using AdvancedTaskPart1.TestModel;
using AdvancedTaskPart1.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart1.Pages
{
    public class LoginPage : CommonDriver
    {
        private IWebElement signinButton => driver.FindElement(By.XPath("//a[text()='Sign In']"));
        private IWebElement Username => driver.FindElement(By.XPath("//input[@name='email']"));
        private IWebElement Password => driver.FindElement(By.XPath("//input[@name='password']"));
        private IWebElement loginButton => driver.FindElement(By.XPath("//button[text()='Login']"));

        private string e_signin = "//a[text()='Sign In']";

        public void LoginAction(IWebDriver driver, string email, string password)
        {
            WaitUtils.WaitToBeVisible(driver, "XPath", "//a[text()='Sign In']", 100);
            signinButton.Click();

            Username.SendKeys(email);
            Password.SendKeys(password);
            loginButton.Click();

        }
       
    }
}