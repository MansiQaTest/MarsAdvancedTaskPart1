using AdvancedTaskPart1.Assertions;
using AdvancedTaskPart1.TestModel;
using AdvancedTaskPart1.Utils;
using ProjecrMarsOnboardingtask.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart1.Steps
{
    public class SkillsSteps : CommonDriver
    {
        Skills skillsObj;
        SkillAssertion skillAssertionObj;

        public SkillsSteps()
        {
            skillsObj = new Skills();
            skillAssertionObj = new SkillAssertion();
        }

        public void addSkillData()
        {
            string addskillFile = "AddSkills.json";
            List<SkillModel> AddSkillData = JsonUtils.ReadJsonData<SkillModel>(addskillFile);
            foreach (var item in AddSkillData)
            {
                string Skill = item.Skill;
                string Skilllevel = item.ExperienceLevel;

                skillsObj.CreateSkill(Skill, Skilllevel);
                skillAssertionObj.addskillAssertion(Skill);

            }
        }
        public void addSkillswithempty()
        {
            string addskillFile = "AddSkillWithempty.json";
            List<SkillModel> AddSkillData = JsonUtils.ReadJsonData<SkillModel>(addskillFile);
            foreach (var item in AddSkillData)
            {
                string Skill = item.Skill;
                string Skilllevel = item.ExperienceLevel;

                skillsObj.CreateSkill(Skill, Skilllevel);
                skillAssertionObj.addSkillwithemptyAssertion();

            }
        }
        public void addSkillwithDuplicate()
        {
            string addskillFile = "AddSkillwithDuplicate.json";
            List<SkillModel> AddSkillData = JsonUtils.ReadJsonData<SkillModel>(addskillFile);
            foreach (var item in AddSkillData)
            {
                string Skill = item.Skill;
                string Skilllevel = item.ExperienceLevel;
                skillsObj.CreateSkill(Skill, Skilllevel);

                skillAssertionObj.addSkillwithDuplicateAssertion(Skill);

            }
        }

        public void CreateMulitipleDataofSkill()
        {
            string addskillFile = "CreateMultipleDataofSkills.json";
            List<SkillModel> AddSkillData = JsonUtils.ReadJsonData<SkillModel>(addskillFile);
            foreach (var item in AddSkillData)
            {
                string Skill = item.Skill;
                string Skilllevel = item.ExperienceLevel;
                skillsObj.CreateSkill(Skill, Skilllevel);

            }
            skillAssertionObj.CreateMulitipleDataofSkillAssertion();

        }
        public void addSkillwithInvalid()
        {
            string addskillFile = "AddSkillwithinvalidData.json";
            List<SkillModel> AddSkillData = JsonUtils.ReadJsonData<SkillModel>(addskillFile);
            List<string> invalidSkills = new List<string>();
            foreach (var item in AddSkillData)
            {
                string Skill = item.Skill;
                string Skilllevel = item.ExperienceLevel;
                skillsObj.CreateSkill(Skill, Skilllevel);
                invalidSkills.Add(Skill);

            }
            skillAssertionObj.addaddSkillwithInvalidAssertion(invalidSkills);

        }

        public void EditSkillData()
        {
            string addskillFile = "EditSkill.json";
            List<SkillModel> AddSkillData = JsonUtils.ReadJsonData<SkillModel>(addskillFile);

            foreach (var item in AddSkillData)
            {
                string Skill = item.Skill;
                string Skilllevel = item.ExperienceLevel;

                skillsObj.UpdateSkill(Skill, Skilllevel);
                Thread.Sleep(2000);
                skillAssertionObj.editSkillAssertion(Skill);

            }

        }
        public void EditSkillDatawithEmpty()
        {
            string addskillFile = "EditSkillwithempty.json";
            List<SkillModel> AddSkillData = JsonUtils.ReadJsonData<SkillModel>(addskillFile);

            foreach (var item in AddSkillData)
            {
                string Skill = item.Skill;
                string Skilllevel = item.ExperienceLevel;

                skillsObj.UpdateSkill(Skill, Skilllevel);
                skillAssertionObj.editSkillDatawithEmptyAssertion(Skill);

            }
        }

        public void EditSkillDatawithDuplicate()
        {
            string addskillFile = "EditSkillwithduplicate.json";
            List<SkillModel> AddSkillData = JsonUtils.ReadJsonData<SkillModel>(addskillFile);

            foreach (var item in AddSkillData)
            {
                string Skill = item.Skill;
                string Skilllevel = item.ExperienceLevel;

                skillsObj.UpdateSkill(Skill, Skilllevel);
                skillAssertionObj.EditSkillDatawithDuplicateAssertion(Skill);

            }

        }

        public void DeleteSkillWhichisinList()
        {
            string addskillFile = "DeleteSkillWhichisinlist.json";
            List<SkillModel> AddSkillData = JsonUtils.ReadJsonData<SkillModel>(addskillFile);

            foreach (var item in AddSkillData)
            {
                string Skill = item.Skill;
                string Skilllevel = item.ExperienceLevel;

                skillsObj.DeleteSkill(Skill);
                skillAssertionObj.deleteskillWhichisinListAssertion(Skill);

            }

        }

        public void DeleteSkillWhichisnotinList()
        {
            string addskillFile = "DeleteSkillWhichisnotinlist.json";
            List<SkillModel> AddSkillData = JsonUtils.ReadJsonData<SkillModel>(addskillFile);

            foreach (var item in AddSkillData)
            {
                string Skill = item.Skill;
                string Skilllevel = item.ExperienceLevel;

                skillsObj.DeleteSkill(Skill);
                skillAssertionObj.deleteskillWhichisnotinListAssertion(Skill);

            }

        }
    }
}
