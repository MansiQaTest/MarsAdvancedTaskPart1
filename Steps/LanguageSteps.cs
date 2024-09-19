using AdvancedTaskPart1.Assertions;
using AdvancedTaskPart1.Pages;
using AdvancedTaskPart1.Pages.ProfileComponents;
using AdvancedTaskPart1.TestModel;
using AdvancedTaskPart1.Utils;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart1.Steps
{
    public class LanguageSteps : CommonDriver
    {
        Language languageObj;
        LanguageAssertion languageAssertionObj;
        
        public LanguageSteps()
        {
            languageObj = new Language();
            languageAssertionObj = new LanguageAssertion();
        }

        public void addLanguageData()
        {
            string addlanguageFile = "AddLanguage.json";
            List<LanguageModel> AddLanguageData = JsonUtils.ReadJsonData<LanguageModel>(addlanguageFile);
            foreach (var item in AddLanguageData)
            {
                string language = item.name;
                string languagelevel = item.level;

                languageObj.CreateLanguage(language, languagelevel);
                languageAssertionObj.addLanguageAssertion(language);
                
            }
        }

        public void addLanguagewithemptyData()
        {
            string addlanguageFile = "AddLanguagewithempty.json";
            List<LanguageModel> AddLanguageData = JsonUtils.ReadJsonData<LanguageModel>(addlanguageFile);
            foreach (var item in AddLanguageData)
            {
                string language = item.name;
                string languagelevel = item.level;

                languageObj.CreateLanguage(language, languagelevel);
                languageAssertionObj.addLanguagewithemptyAssertion();

            }
        }
        public void addLanguagewithDuplicate()
        {
            string addlanguageFile = "AddLanguagewithDuplicate.json";
            List<LanguageModel> AddLanguageData = JsonUtils.ReadJsonData<LanguageModel>(addlanguageFile);
            foreach (var item in AddLanguageData)
            {
                string language = item.name;
                string languagelevel = item.level;

                languageObj.CreateLanguage(language, languagelevel);
                languageAssertionObj.addLanguagewithduplicateAssertion(language);

            }
        }
        public void CreateMulitipleDataofLanguage()
        {
            string addlanguageFile = "CreateMultipleDataofLanguage.json";
            List<LanguageModel> AddLanguageData = JsonUtils.ReadJsonData<LanguageModel>(addlanguageFile);
            foreach (var item in AddLanguageData)
            {
                string language = item.name;
                string languagelevel = item.level;

                languageObj.CreateLanguage(language, languagelevel);

            }
            languageAssertionObj.createMultipleDataAssertion();

        }
        public void addLanguagewithInvalid()
        {
            string addlanguageFile = "AddLanguagewithinvalidData.json";
            List<LanguageModel> AddLanguageData = JsonUtils.ReadJsonData<LanguageModel>(addlanguageFile);
            List<string> invalidLanguages = new List<string>();
            foreach (var item in AddLanguageData)
            {
                string language = item.name;
                string languagelevel = item.level;

                languageObj.CreateLanguage(language, languagelevel);
                invalidLanguages.Add(language);

            }
            languageAssertionObj.addLanguagewithInvalidAssertion(invalidLanguages);

        }
        public void add5thRecord()
        {
            string addlanguageFile = "Add5thRecordinlanguage.json";
            List<LanguageModel> AddLanguageData = JsonUtils.ReadJsonData<LanguageModel>(addlanguageFile);
            
            List<string> addedlanguages = new List<string>();
            
            foreach (var item in AddLanguageData)
            {
                string language = item.name;
                string languagelevel = item.level;

                languageObj.CreateLanguage(language, languagelevel);
                Thread.Sleep(2000);
                addedlanguages.Add(language); // Populate the list with added languages

            }
            languageAssertionObj.add5thRecordAssertion(addedlanguages);

        }
        public void EditLanguageData()
        {
            string addlanguageFile = "EditLanguage.json";
            List<LanguageModel> AddLanguageData = JsonUtils.ReadJsonData<LanguageModel>(addlanguageFile);
                      

            foreach (var item in AddLanguageData)
            {
                string language = item.name;
                string languagelevel = item.level;

                languageObj.UpdateLanguage(language, languagelevel);
                Thread.Sleep(2000);
                languageAssertionObj.editLanguageAssertion(language);

            }

        }
        public void EditLanguageDatawithEmpty()
        {
            string addlanguageFile = "EditLanguagewithEmpty.json";
            List<LanguageModel> AddLanguageData = JsonUtils.ReadJsonData<LanguageModel>(addlanguageFile);


            foreach (var item in AddLanguageData)
            {
                string language = item.name;
                string languagelevel = item.level;

                languageObj.UpdateLanguage(language, languagelevel);
                languageAssertionObj.editLanguagewithemptyAssertion();

            }
        }

        public void EditLanguageDatawithDuplicate()
        {
            string addlanguageFile = "EditLanguagewithDuplicate.json";
            List<LanguageModel> AddLanguageData = JsonUtils.ReadJsonData<LanguageModel>(addlanguageFile);


            foreach (var item in AddLanguageData)
            {
                string language = item.name;
                string languagelevel = item.level;

                languageObj.UpdateLanguage(language, languagelevel);
                languageAssertionObj.editLanguagewithduplicateAssertion(language);

            }

        }

        public void DeleteLanguageWhichisinList()
        {
            string addlanguageFile = "DeleteLanguageWhichisinList.json";
            List<LanguageModel> AddLanguageData = JsonUtils.ReadJsonData<LanguageModel>(addlanguageFile);


            foreach (var item in AddLanguageData)
            {
                string language = item.name;
               
                languageObj.DeleteLanguage(language);
                languageAssertionObj.deleteLanguageWhichisinListAssertion(language);

            }

        }

        public void DeleteLanguageWhichisnotinList()
        {
            string addlanguageFile = "DeleteLanguageWhichisnotinList.json";
            List<LanguageModel> AddLanguageData = JsonUtils.ReadJsonData<LanguageModel>(addlanguageFile);


            foreach (var item in AddLanguageData)
            {
                string language = item.name;

                languageObj.DeleteLanguage(language);
                languageAssertionObj.deleteLanguageWhichisnotinListAssertion(language);

            }

        }

    }
}
