using AdvancedTaskPart1.Pages;
using AdvancedTaskPart1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart1.Steps
{
    public class Homepagesteps : CommonDriver
    {
        Homepage homepageObj;
        public Homepagesteps() 
        {
           homepageObj = new Homepage();
        }
        public void clickOnProfileTab()
        {
            homepageObj.clickprofiletab();
        }
        public void clickonshareskill() 
        {
         homepageObj.clickshareskill();
        }
        public void clickonsearchskill() 
        {
            homepageObj.clicksearchskill();        
        }

        public void clickonNotification() 
        {
          homepageObj.clickNotificationPanel();
        }
    }
}
