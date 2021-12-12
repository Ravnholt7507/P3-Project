using System;
using Xunit;
using Project.CSharpFiles;
using Project.Pages.AdminPage;
using System.Collections.Generic;

namespace TestProject1
{
    public class AdminPageTests
    {

        [Fact]
        public void InsertCategories()
        {
            //Arrange
            AdminCode adminlogic = new AdminCode();
            string CategoryNameInput = "Kvinder";

            List<Category> expected = new List<Category>() 
            { new Category("Drenge"), 
              new Category("TestCategory"),
              new Category("Kvinder")
            };

            //Act
            List<Category> actual = adminlogic.TestUpdateList(CategoryNameInput);

            //Assert
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void InsertTypes()
        {
            //Arrange
            AdminCode adminlogic = new AdminCode();
            string TypeName = "bukser";
            Subcategory expected = new Subcategory(TypeName);
            string SelectedCategory = "TestCategory";

            //Act
            Subcategory actual = adminlogic.TestInsert(SelectedCategory, TypeName);

            //Assert
            Assert.Contains(expected, adminlogic.TestCats[2].Subcategory);
            Assert.Equal(expected, actual);
        }







        [Fact]
        public void DeleteTypesOrCategories()
        {
            //Arrange
            AdminCode adminlogic = new AdminCode();
            string CategoryToRemove= "TestCategory";

            List<Category> expected = new List<Category>() 
            { new Category("Drenge"), 
              new Category("Kvinder")
            };

            //Act
            List<Category> actual = adminlogic.TestRemove(CategoryToRemove);

            //Assert
            Assert.DoesNotContain(new Category(CategoryToRemove), actual);
            Assert.Equal(expected, actual);
        }
    }
}
