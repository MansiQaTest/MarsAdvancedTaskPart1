using AdvancedTaskPart1.Assertions;
using AdvancedTaskPart1.Pages.Components;
using AdvancedTaskPart1.TestModel;
using AdvancedTaskPart1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart1.Steps
{
    public class ShareSkillsSteps : CommonDriver
    {
        ShareSkills shareSkillsObj;
        ShareSkillAssertion ShareSkillAssertionObj;
        public ShareSkillsSteps()
        { 
            shareSkillsObj = new ShareSkills();
            ShareSkillAssertionObj = new ShareSkillAssertion();
        }


        public void addShareSkillData()
        {
            string addskillFile = "AddShareSkill.json";
            List<ShareSkillModel> AddSkillData = JsonUtils.ReadJsonData<ShareSkillModel>(addskillFile);
            foreach (ShareSkillModel AddShareSkill in AddSkillData)
            {
                shareSkillsObj.CreateShareSkill(AddShareSkill);
                ShareSkillAssertionObj.AddShareSkillAssertion(AddShareSkill);
               
            }
        }
        public void addShareSkillwithemptyData()
        {
            string addskillFile = "AddShareSkillWithempty.json";
            List<ShareSkillModel> AddSkillData = JsonUtils.ReadJsonData<ShareSkillModel>(addskillFile);
            foreach (ShareSkillModel AddShareSkill in AddSkillData)
            {
                shareSkillsObj.CreateShareSkill(AddShareSkill);
                ShareSkillAssertionObj.AddShareSkillwithemptyAssertion(AddShareSkill);
                
            }
        }
        public void addShareSkillwithduplicateData()
        {
            string addskillFile = "AddShareSkillWithduplicate.json";
            List<ShareSkillModel> AddSkillData = JsonUtils.ReadJsonData<ShareSkillModel>(addskillFile);
            foreach (ShareSkillModel AddShareSkill in AddSkillData)
            {
                shareSkillsObj.CreateShareSkill(AddShareSkill);
                ShareSkillAssertionObj.AddShareSkillwithduplicateAssertion(AddShareSkill);
                
            }
        }
        public void addShareSkillwithinvalidData()
        {
            string addskillFile = "AddShareSkillwithinvalid.json";
            List<ShareSkillModel> AddSkillData = JsonUtils.ReadJsonData<ShareSkillModel>(addskillFile);
            foreach (ShareSkillModel AddShareSkill in AddSkillData)
            {
                shareSkillsObj.CreateShareSkill(AddShareSkill);
                ShareSkillAssertionObj.AddShareSkillwithinvalidAssertion(AddShareSkill);
                
            }
        }
    }
}
