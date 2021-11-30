using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using Project.CSharpFiles;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Pages.AdminPage
{
    public class AdminCode : ComponentBase
    {
        DbCall _call = new DbCall();

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
                    _call.AdminPages("Remove", "Category", CategoryToRemove);
                    Categories.Remove(category);
                    CategoryToRemove = null;
                    break;
                }
                foreach (var item in category.Subcategory)
                {
                    if (item.SubcategoryName == CategoryToRemove)
                    {
                        _call.AdminPages("Remove", "Type", CategoryToRemove);
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
            _call.AdminPages("New", "Category", selectedCategory);
            //_call.AdminPages("Get categories");
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
                    _call.AdminPages("New", "Type", selectedCategory, newTitle);
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

        // ADMIN 2 ----------------------------------- //

        public List<string> SelectedColours = new List<string>();
        public List<SizeAndStock> SelectedSizes = new List<SizeAndStock>();
        public List<string> PlaceholderSizes = new List<string>();

        public int PHColor = 0;
        public int placeholder = 0;

        public bool[] chosenColors = { false, false, false, false };
        public bool[] chosenSizes = { false, false, false };
        public bool CheckForInput = false;



        public string SelectedValue;
        public string Description;
        public string Price;
        public bool imgState = false;

        protected bool IsDisabled { get; set; } = false;

        public string placeholderColour;
        public string SelectedColour = "";

        public string[] Colours = { "red", "blue", "yellow", "green", "Magenta", "Pink", "pisGul", "brækBrun" };
        public string[] Sizes = { "Chunky", "FatAss", "XL", "big", "medium", "small", "Esben" };

        public string SelectedCat = null;
        public string NewItem = null;

        public List<color> MyColors = new List<color>();
        color NewColor;
        public string ChosenColor;

        public List<Category> cats = new List<Category>() { new Category("Mens Clothing"), new Category("Womens clothing") };

        public void Verify()
        {
            NewColor = new color(SelectedColour);
            NewColor.SnS = SelectedSizes.ToArray();
            MyColors.Add(NewColor);
            SelectedSizes.Clear();
            placeholderColour = null;
            NewColor = null;
        }

        protected override Task OnInitializedAsync()
        {
            cats[0].Subcategory.Add(new Subcategory("Trøje"));
            cats[0].Subcategory.Add(new Subcategory("Bukser"));
            cats[1].Subcategory.Add(new Subcategory("Jakke"));
            cats[1].Subcategory.Add(new Subcategory("Sko"));
            return base.OnInitializedAsync();
        }

        public color SwitchFuntion(string colour)
        {
            switch (colour)
            {
                case "red": return MyColors.Find(x => x.ColorName == "red");
                case "blue": return MyColors.Find(x => x.ColorName == "blue");
                case "yellow": return MyColors.Find(x => x.ColorName == "yellow");
                case "green": return MyColors.Find(x => x.ColorName == "green");
                default: return null;
            }
        }

        public void ConfirmStock()
        {
            imgState = !imgState;
        }

        public void CheckboxSizes(string size, object checkvalue)
        {
            Console.WriteLine(checkvalue);
            if ((bool)checkvalue)
                SelectedSizes.Add(new SizeAndStock(size));
            if (!(bool)checkvalue)
                SelectedSizes.Remove(new SizeAndStock(size));
        }

        public void CheckboxColours(string colour)
        {
            SelectedColour = colour;
        }

        public void RemoveItem(int i, color Color)
        {
            Console.WriteLine(i);
            Color.SnS = Color.SnS.Where((source, index) => index != i).ToArray();
            if (Color.SnS.Length == 0)
            {
                MyColors.Remove(Color);
            }
        }

        public class SizeAndStock
        {
            public SizeAndStock(string InputSize)
            {
                Size = InputSize;
            }
            public int id;
            public string Size;
            public bool state = false;
            public int stock;
        }

        public class color
        {
            public color(string name)
            {
                ColorName = name;
            }
            public List<string> ImageLink = new List<string>();
            public string ColorName;
            public string Id;
            public SizeAndStock[] SnS;
        }

        public class product
        {
            public color[] Color;
            public int Id = 0;
        }
    }
}