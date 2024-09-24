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
    public class SearchSkillsSteps : CommonDriver
    {
        SearchSkills searchSkillsObj;
        SearchSkillsAssertion searchSkillsAssertionObj;

        public SearchSkillsSteps() 
        { 
            searchSkillsObj = new SearchSkills();
            searchSkillsAssertionObj = new SearchSkillsAssertion();
        }

        public void SearchSkillsByAllCategories()
        {
            string addsearchskillFile = "SearchSkillbyCategory.json";
            List<SearchSkillsModel> AddData = JsonUtils.ReadJsonData<SearchSkillsModel>(addsearchskillFile);
            foreach (var item in AddData)
            {
                string searchString = item.searchString;
                string Category = item.Category;

                  searchSkillsObj.SearchSkillByCategory(searchString, Category);
                  searchSkillsAssertionObj.SearchSkillByAllCategoriesAssertion(Category, searchString);

            }
        }
        public void SearchSkillsByCatSubCategory()
        {
            string addsearchskillFile = "SearchSkillbyCatSubCat.json";
            List<SearchSkillbyCatSubCatModel> AddData = JsonUtils.ReadJsonData<SearchSkillbyCatSubCatModel>(addsearchskillFile);
            foreach (var item in AddData)
            {
                string searchString = item.searchString;
                string Category = item.Category;
                string subcategory = item.subcategory;

                searchSkillsObj.SearchSkillByCatSubCategory(searchString, Category, subcategory);
                searchSkillsAssertionObj.SearchSkillByCatSubCategoryAssertion(Category, subcategory ,searchString);

            }

        }
        public void SearchSkillsByFilter() 
        {
            string addsearchskillFile = "SearchSkillbyFilters.json";
            List<SearchSkillbyFiltersModel> AddData = JsonUtils.ReadJsonData<SearchSkillbyFiltersModel>(addsearchskillFile);

            foreach (var item in AddData)
            {
                string searchString = item.searchString;
                string Category = item.Category;
                string subcategory = item.subcategory;
                string filterOption = item.filterOption;

                searchSkillsObj.SearchSkillByFilters(searchString, Category, subcategory, filterOption);
                searchSkillsAssertionObj.SearchSkillByFilterAssertion(searchString, Category, subcategory, filterOption);

            }

        }
    }
}
