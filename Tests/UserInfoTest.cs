using AdvancedTaskPart1.Pages.Components.ProfilePage;
using AdvancedTaskPart1.Steps;
using AdvancedTaskPart1.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart1.Tests
{
    [TestFixture]

    public class UserInfoTest : CommonDriver
    {
        UserInformation userInfomationObj;
        UserInformationSteps userInformationStepsObj;

         public UserInfoTest() 
        {
            userInfomationObj = new UserInformation();
            userInformationStepsObj = new UserInformationSteps();
        }

   
        
        [Test, Order(1), Description("This test edits the user details")]
        public void TestUserInfo()
        {
            userInformationStepsObj.EnterUserDetails();
        }

    }
}
