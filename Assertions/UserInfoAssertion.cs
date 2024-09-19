using AdvancedTaskPart1.Pages.ProfileComponents;
using AdvancedTaskPart1.Utils;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart1.Assertions
{
    public class UserInfoAssertion : CommonDriver
    {
        UserInformation userInformationObj;
        public UserInfoAssertion()
        { 
            userInformationObj = new UserInformation();
        }
        public void EditUserInfoAssert()
        {
            string message = userInformationObj.GetSuccessMessage();
            Assert.That(message, Is.EqualTo("Availability updated"), "The expected success message did not appear.");
            test.Log(Status.Pass, "Test passed successfully");
        }
    }
}
