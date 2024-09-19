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
    public class SearchSkillsTest : CommonDriver
    {
        SearchSkillsSteps searchSkillsStepsObj;
        public SearchSkillsTest()
        { 
          searchSkillsStepsObj = new SearchSkillsSteps();
        }

        [Test, Order(1), Description("User can able to Search skill by Category")]
        public void SearchSkillsByAllCategoriesTest()
        {
            searchSkillsStepsObj.SearchSkillsByAllCategories();
        }

        [Test, Order(2), Description("User can able to Search skill by Category and subcategory")]
        public void SearchSkillsByAllCatSubCategoryTest()
        {
            searchSkillsStepsObj.SearchSkillsByCatSubCategory();
        }

        [Test, Order(3), Description("User can able to Search skill by all filters")]
        public void SearchSkillsByFiltersTest()
        {
            searchSkillsStepsObj.SearchSkillsByFilter();
        }


    }
}
