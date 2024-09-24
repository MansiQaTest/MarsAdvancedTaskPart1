using AdvancedTaskPart1.Pages;
using AdvancedTaskPart1.Utils;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart1.Steps
{
    public class LoginSteps : CommonDriver
    {
        LoginPage loginPageObj;
        public LoginSteps()
        {
            loginPageObj = new LoginPage();
        }
        public void LoginActions()
        {
            string loginFile = @"D:\Mansi-Industryconnect\AdvancedTaskPart1\TestData\login.json";
            List<TestModel.TestCaseData> testCases = JsonUtils.ReadJsonData<TestModel.TestCaseData>(loginFile);


            foreach (var testCase in testCases)
            {
                if (testCase.TestCase == "LoginData")
                {
                    var loginData = testCase.Data;
                    string email = loginData.Email;
                    string password = loginData.Password;
                    loginPageObj.LoginAction( driver, email, password);

                }
            }
        }
        
    }
}
