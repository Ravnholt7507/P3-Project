using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Pages.AdminPage
{
    public class AdminCode : ComponentBase
    {
        public string newTitle = null;
        public string newCategory = null;
        public string CategoryToRemove = null;
        public string NewItemName = null;

        public void Remove()
        {
            foreach (Category category in Categories)
            {
                if ((category.CategoryName == CategoryToRemove))
                {
                    Categories.Remove(category);
                    CategoryToRemove = null;
                    break;
                }
                foreach (var item in category.Subcategory)
                {
                    if (item.SubcategoryName == CategoryToRemove)
                    {
                        category.Subcategory.Remove(item);
                        CategoryToRemove = null;
                        break;
                    }
                }
            }
        }

        public class Category
        {
            public string CategoryName;
            public Category(string Name)
            {
                CategoryName = Name;
            }
            public List<Subcategory> Subcategory = new List<Subcategory>();
        }

        public class Subcategory
        {
            public string SubcategoryName;
            public Subcategory(string Name)
            {
                SubcategoryName = Name;
            }
        }

        public List<Category> Categories = new List<Category>();
        public string selectedCategory = null;

        public void UpdateList()
        {
            selectedCategory = newCategory;
            Categories.Add(new Category(newCategory));
            newCategory = null;
        }

        public void Insert()
        {
            foreach (Category category in Categories)
            {
                if (category.CategoryName == selectedCategory)
                {
                    category.Subcategory.Add(new Subcategory(newTitle));
                    newTitle = null;
                }
            }
        }

        public string Visible;
        private int i = 1;

        public void Dropdownbtn()
        {
            i++;
            if (i % 2 == 0)
            {
                Visible = "block";
            }
            else
            {
                Visible = "none";
            }
        }
    }
}
