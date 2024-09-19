using AdvancedTaskPart1.Assertions;
using AdvancedTaskPart1.Pages;
using AdvancedTaskPart1.Pages.ProfileComponents;
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
    public class LanguageTest : CommonDriver
    {
        Language languageobj;
        LanguageAssertion languageAssertionObj;
        LanguageSteps languageStepsObj;
        List<string> LanguageToDelete;


        public LanguageTest()
        {
           languageobj = new Language();
           languageAssertionObj = new LanguageAssertion();
           languageStepsObj = new LanguageSteps();
        }



        [Test, Order(1), Description("User can able to add language")]
        public void AddlanguageTest()
        {
            languageStepsObj.addLanguageData();            
        }

        [Test, Order(2), Description("User can not create language with empty")]
        public void AddlanguageWithEmptyTest()
        {
            languageStepsObj.addLanguagewithemptyData();
        }
        [Test, Order(3), Description("User can not create duplicate language data")]
        public void AddlanguageWithDuplicateTest()
        {
            languageStepsObj.addLanguageData();

            languageStepsObj.addLanguagewithDuplicate();
        }
        [Test, Order(4), Description("User can create 4 data in languages")]
        public void CreateMultiplelanguagetest()
        {
            languageStepsObj.CreateMulitipleDataofLanguage();

        }
        [Test, Order(5), Description("User can not create invalid data in languages")]
        public void AddLanguagewithInvalidTest()
        {
            languageStepsObj.addLanguagewithInvalid();

        }
        [Test, Order(6), Description("User can not create 5th data in languages")]
        public void Create5thRecordTest()
        {
        
            languageStepsObj.add5thRecord();

        }
        [Test, Order(7), Description("User can Edit data in languages")]
        public void EditLanguageTest()
        {
            languageStepsObj.addLanguageData();
            languageStepsObj.EditLanguageData();
        }

        [Test, Order(8), Description("User can not Edit data with empty")]
        public void EditLanguageWithemptyTest()
        {
            languageStepsObj.addLanguageData();
            languageStepsObj.EditLanguageDatawithEmpty();
        }
        [Test, Order(9), Description("User can not Edit data with duplicate entry")]
        public void EditLanguageWithduplicateTest()
        {
            languageStepsObj.addLanguageData();
            languageStepsObj.EditLanguageDatawithDuplicate();
        }
        
        [Test, Order(10), Description("User can delete data which is in list")]
        public void DeleteLanguageWhichisinlistTest()
        {
            languageStepsObj.addLanguageData();
            languageStepsObj.DeleteLanguageWhichisinList();
        }

        [Test, Order(10), Description("User can delete data which is not in list")]
        public void DeleteLanguageWhichisnotinlistTest()
        {
            languageStepsObj.addLanguageData();
            languageStepsObj.DeleteLanguageWhichisnotinList();
        }
    }
}
