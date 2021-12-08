using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.IO;
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

        public List<SizeAndStock> SelectedSizes = new List<SizeAndStock>();
        public List<string> PlaceholderSizes = new List<string>();

        public string SelectedValue;
        public string Description;
        public string Price;
        public bool imgState = false;

        public string SelectedColour = "";

        public string[] Colours = { "Lilla", "Blå", "Grå", "Rød", "Grøn", "Lyserød", "Hvid", "Sort", "Beige", "Turkis", "Gul", "Orange", "Flerfarvet" };
        public string[] Sizes = { "X-Small", "Small", "Medium", "Large", "X-Large" };

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
            NewColor = null;
        }

        protected override Task OnInitializedAsync()
        {
            string[][] categoryArray = _call.AdminPages("Get", "Categories");
            string[][] typeArray = _call.AdminPages("Get", "Types");
            col_numbers();
            return base.OnInitializedAsync();
        }

        public color SwitchFuntion(string colour)
        {
            return MyColors.Find(x => x.ColorName == colour);
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
            public string Size;
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

        public void finalize()
        {
            List<string> sizeList = new List<string>();
            List<int> stockList = new List<int>();
            string[] sizeArray;
            int[] stockArray;

            foreach (var SnS in MyColors[0].SnS)
            {
                sizeList.Add(SnS.Size);
            }

            sizeArray = sizeList.ToArray();
            
            foreach (var SnS in MyColors[0].SnS)
            {
                stockList.Add(SnS.stock);
            }

            stockArray = stockList.ToArray();

            string prodName = "test";//NewItem;
            string category = "Kvinder";
            string type = "Bukser";//SelectedCat;
            int price = 123;//int.Parse(Price);
            string description = "Test";//Description;
            string material = "Uld";
            string produced = "Uganda";
            string transparency = "transparency";
            string colour = "Blå";//SelectedColour;
            string img = "randImg";//ChosenImg;
            string[] sizeArray2 = { "X-Small", "Small", "Medium", "Large", "X-Large" };
            int[] stockArray2 = {5,4,3,2,1} ;
            ;
            
            
            _call.AdminPages("New", "Product", prodName, category, type, price, description, material, produced, transparency, colour, img, sizeArray2, stockArray2);
        }

        public double num_col;
        public double num_col2;

        public void col_numbers()
        {
            num_col2 = (double)Colours.Length/4;
            num_col=Math.Ceiling(num_col2);
        }
    }
    
}