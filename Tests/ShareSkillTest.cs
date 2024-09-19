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
    public class ShareSkillTest : CommonDriver
    {
        ShareSkillsSteps ShareSkillsStepsObj;

        public ShareSkillTest() 
        { 
            ShareSkillsStepsObj = new ShareSkillsSteps();
        }

        [Test, Order(1), Description("User can able to add shareskill")]
        public void AddShareSkillTest()
        {
            ShareSkillsStepsObj.addShareSkillData();
        }

        [Test, Order(2), Description("User can able to add shareskill with empty")]
        public void AddShareSkillwithemptyTest()
        {
            ShareSkillsStepsObj.addShareSkillwithemptyData();
        }
        [Test, Order(3), Description("User can not able to add shareskill with duplicate")]
        public void AddShareSkillwithduplicateTest()
        {
            ShareSkillsStepsObj.addShareSkillwithduplicateData();
        }
        [Test, Order(4), Description("User can not able to add shareskill with invalid")]
        public void AddShareSkillwithinvalidTest()
        {
            ShareSkillsStepsObj.addShareSkillwithinvalidData();
        }

    }
}
