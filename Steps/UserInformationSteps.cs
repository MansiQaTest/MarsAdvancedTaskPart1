using AdvancedTaskPart1.Assertions;
using AdvancedTaskPart1.Pages.Components.ProfilePage;
using AdvancedTaskPart1.TestModel;
using AdvancedTaskPart1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart1.Steps
{
    public class UserInformationSteps : CommonDriver
    {
        UserInformation userInformtionObj;
        UserInfoAssertion userInfoassertionObj;

        public UserInformationSteps()
        {
            userInformtionObj = new UserInformation();
            userInfoassertionObj = new UserInfoAssertion();

        }
        public void EnterUserDetails()
        {
            string addUserFile = "UserData.json";
            List<UserDataModel> AddUserData = JsonUtils.ReadJsonData<UserDataModel>(addUserFile);
            foreach (var item in AddUserData)
            {
                string availabilityType = item.AvailabilityType;
                string availableHours = item.AvailableHours;
                string earntarget = item.EarnTarget;

                userInformtionObj.editAvailabilityOfUser(availabilityType);
                userInfoassertionObj.EditUserInfoAssert();

                userInformtionObj.editHoursOfUser(availableHours);
                userInfoassertionObj.EditUserInfoAssert();

                userInformtionObj.editEarnTargetOfUser(earntarget);
                userInfoassertionObj.EditUserInfoAssert();
            }
        }
    }
}
