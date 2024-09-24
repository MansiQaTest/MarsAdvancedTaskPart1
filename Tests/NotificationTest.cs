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
    public class NotificationTest : CommonDriver
    {
        NotificationSteps notificationStepsObj;
        public NotificationTest()
        {
        notificationStepsObj = new NotificationSteps();
        }

        [Test, Order(1), Description("User can able test select feature in notifications")]
        public void NotificationSelectTest()
        {
            notificationStepsObj.NotificationSelectAll();
        }

        [Test, Order(2), Description("User can able test Unselect feature in notifications")]
        public void NotificationUnSelectTest()
        {
            notificationStepsObj.NotificationUnSelectAll();
        }

        [Test, Order(3), Description("User can able test load more feature in notifications")]
        public void NotificationLoadmoreTest()
        {
            notificationStepsObj.NotificationLoadmore();
        }

        [Test, Order(4), Description("User can able to test show less feature in notifications")]
        public void NotificationShowLessTest()
        {
            notificationStepsObj.NotificationShowLess();
        }

        [Test, Order(5), Description("User can able test Mark as Read feature in notification")]
        public void NotificationMarkasReadTest()
        {
            notificationStepsObj.NotificationMarkasRead();
        }

        [Test, Order(6), Description("User can able test Delete feature in notifications")]
        public void DeleteNotificationTest()
        {
            notificationStepsObj.NotificationDelete();
        }

       

       

        
    }
}
