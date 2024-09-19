using AdvancedTaskPart1.Assertions;
using AdvancedTaskPart1.Steps;
using AdvancedTaskPart1.Utils;
using NUnit.Framework;
using ProjecrMarsOnboardingtask.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart1.Tests
{
    public class SkillTest : CommonDriver
    {
        Skills skillObj;
        SkillAssertion skillAssertionObj;
        SkillsSteps skillsStepsObj;
        List<string> SkillsToDelete;

        public SkillTest()
        {
            skillObj = new Skills();
            skillAssertionObj = new SkillAssertion();
            skillsStepsObj = new SkillsSteps();
        }

        [Test, Order(1), Description("User can able to add skills")]
        public void addSkillsData()
        {
            skillsStepsObj.addSkillData();
        }

        [Test, Order(2), Description("User can not able to add skills with empty")]
        public void addSkillswithempty()
        {
            skillsStepsObj.addSkillswithempty();
        }
        [Test, Order(3), Description("User can not able to add skills with empty")]
        public void addSkillswithduplicate()
        {
            skillsStepsObj.addSkillData();
            skillsStepsObj.addSkillwithDuplicate();
        }
        [Test, Order(4), Description("User can create multiple data in Skills")]
        public void CreateMultipleskilltest()
        {
            skillsStepsObj.CreateMulitipleDataofSkill();

        }
        [Test, Order(5), Description("User can not create invalid data in skills")]
        public void AddSkillwithInvalidTest()
        {
            skillsStepsObj.addSkillwithInvalid();

        }
        [Test, Order(6), Description("User can Edit data in skills")]
        public void EditSkillTest()
        {
            skillsStepsObj.addSkillData();
            skillsStepsObj.EditSkillData();
        }
        [Test, Order(7), Description("User can not Edit data with empty")]
        public void EditSkillWithemptyTest()
        {
            skillsStepsObj.addSkillData();
            skillsStepsObj.EditSkillDatawithEmpty();
        }
        [Test, Order(8), Description("User can not Edit data with duplicate entry")]
        public void EditSkillWithduplicateTest()
        {
            skillsStepsObj.addSkillData();
            skillsStepsObj.EditSkillDatawithDuplicate();
        }
        [Test, Order(9), Description("User can delete data which is in list")]
        public void DeleteSkillWhichisinlistTest()
        {
            skillsStepsObj.addSkillData();
            skillsStepsObj.DeleteSkillWhichisinList();
        }
        [Test, Order(10), Description("User can delete data which is not in list")]
        public void DeleteLanguageWhichisnotinlistTest()
        {
            skillsStepsObj.addSkillData();
            skillsStepsObj.DeleteSkillWhichisnotinList();
        }

    }
}
