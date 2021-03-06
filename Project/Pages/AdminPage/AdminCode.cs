using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.IO;
using Project.CSharpFiles;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Project.Pages.AdminPage
{
    public class AdminCode : ComponentBase
    {
        DbCall _call = new DbCall();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string newTitle = null;
        public string newCategory = null;
        public string CategoryToRemove = null;
        public string NewItemName = null;

        public bool DataBaseVerify(string AccesToken)
        {
            return _call.Verify(AccesToken);
        }

        public void Remove()
        {
            //foreach (Category category in Categories)
            //{
            //    if ((category.CategoryName == CategoryToRemove))
            //    {
            //        _call.AdminPages("Remove", "Category", CategoryToRemove);
            //        Categories.Remove(category);
            //        CategoryToRemove = null;
            //        break;
            //    }
            //    foreach (var item in category.Subcategory)
            //    {
            //        if (item.SubcategoryName == CategoryToRemove)
            //        {
            //            _call.AdminPages("Remove", "Type", CategoryToRemove);
            //            category.Subcategory.Remove(item);
            //            CategoryToRemove = null;
            //            break;
            //        }
            //    }
            //}
            _call.RemoveCat(CategoryToRemove);
            NavigationManager.NavigateTo("/Categories", true);
        }

        public void RemoveTypeFromCategory(string category, string type)
        {
            _call.RemoveTypeFromCategory(category, type);
        }

        List<Category> TestCats1 = new List<Category>()
        {
            new Category("Drenge"),
            new Category("Kvinder"),
            new Category("TestCategory"),
        };


        public List<Category> Categories = new List<Category>();
        public string selectedCategory = null;

        public void UpdateList()
        {
            selectedCategory = newCategory;
            _call.AdminPages("New", "Category", selectedCategory);
            Categories.Add(new Category(newCategory));
            newCategory = null;
            NavigationManager.NavigateTo("/Categories", true);
        }
        public void Insert()
        {
            foreach (Category category in Categories)
            {
                if (category.CategoryName == selectedCategory)
                {
                    //category.Subcategory.Add(new Subcategory(newTitle));
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

        public UserInput userInput = new UserInput();
        public class UserInput
        {
            [Required]
            [StringLength(20)]
            public string name { get; set; }

            [Required]
            [Range(1, 5000)]
            public int price { get; set; }

            [Required]
            public int pris1 { get; set; }

            [Required]
            public int pris2 { get; set; }

            [Required]
            public int pris3 { get; set; }

            [Required]
            public int pris4 { get; set; }

            [Required]
            public int pris5 { get; set; }

            [Required]
            public string desc { get; set; }

            [Required]
            public string inputcat { get; set; }

            [Required]
            public string inputsubcat { get; set; }
        }

        public List<SizeAndStock> SelectedSizes = new List<SizeAndStock>();

        public string SelectedValue;
        public string Description;
        public string Price;
        public string TransportPrice;
        public string ResourcePrice;
        public string ProductionPrice;
        public string TrimPrice;
        public string MillingPrice;



        public int result;
        public bool imgState = false;
        public string SelectedSubCat;
        public string SelectedCat = null;
        public string SelectedColour = "";

        public string[] Colours = { "Lilla", "Blå", "Grå", "Rød", "Grøn", "Lyserød", "Hvid", "Sort", "Beige", "Turkis", "Gul", "Orange", "Flerfarvet" };
        public string[] Sizes = { "X-Small", "Small", "Medium", "Large", "X-Large" };

       
        public string NewItem = null;

        public List<color> MyColors = new List<color>();
        color NewColor;
        public string ChosenColor;

        public List<Category> cats = new List<Category>();


        public bool show_ektraValgMenu = false;
        public bool ShowColours = false;
        public bool IsDisabled = false;
        public bool checkboxDisabled = true;

        public bool ting = false;

        public void StartNewItem()
        {
            // Sets the fields which are inputted to the database. They get value from form when submitted.
            TransportPrice = userInput.pris1.ToString();
            ResourcePrice = userInput.pris2.ToString();
            ProductionPrice = userInput.pris3.ToString();
            MillingPrice = userInput.pris4.ToString();
            TrimPrice = userInput.pris5.ToString();
            NewItem = userInput.name;
            Price = userInput.price.ToString();
            Description = userInput.desc;
            SelectedCat = userInput.inputcat;
            SelectedSubCat = userInput.inputsubcat;
            
            ShowColours = true;
            IsDisabled = true;
        }

        public void Verify()
        {
            //If colour exist and already contains size, do this
            if (MyColors.Contains(SwitchFuntion(SelectedColour))) // && SwitchFuntion(SelectedColour).SnS.Any(size => SelectedSizes.Contains(size)))
            {
                Console.WriteLine("benis");
                SwitchFuntion(SelectedColour).SnS = SelectedSizes.ToArray();
                SelectedSizes.Clear();
                show_ektraValgMenu = true;
            }
            // If colour is does not exist yet
            if (!MyColors.Contains(SwitchFuntion(SelectedColour)) && SwitchFuntion(SelectedColour) == null)
            {
                NewColor = new color(SelectedColour);
                NewColor.SnS = SelectedSizes.ToArray();
                MyColors.Add(NewColor);
                SelectedSizes.Clear();
                NewColor = null;
                show_ektraValgMenu = true;
            }
        }

        protected override Task OnInitializedAsync()
        {
            string[][] categoryArray = _call.AdminPages("Get", "Categories");
            foreach (var category in categoryArray[0])
            {
                if (category != null)
                {
                    Category newCategory = new Category(category);
                    cats.Add(newCategory);
                    Categories.Add(newCategory);
                }
            }
            if (cats.Count > 0)
            {
                userInput.inputcat = cats[0].CategoryName;
            }
            col_numbers();
            

            return base.OnInitializedAsync();
        }
        public void CallSubcats(string selectedCat)
        {
            cats[0].Subcategory.Clear();
            string[][] typeArray = _call.AdminPages("Get", "Types", selectedCat);
            foreach (var category in cats)
            {
                foreach (var type in typeArray[0])
                {
                    if (type != null)
                    {
                        Subcategory subcategory = new Subcategory(type);
                        category.Subcategory.Add(subcategory);
                        
                    }
                }
            }

            try
            {
                SelectedSubCat = cats[0].Subcategory[0].SubcategoryName;
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public color SwitchFuntion(string colour)
        {
            return MyColors.Find(x => x.ColorName == colour);
        }

        public SizeAndStock FindSizeByName(string size)
        {
            SizeAndStock SelectedSize = Array.Find(SwitchFuntion(SelectedColour).SnS, x => x.Size == size);
            return SelectedSize;
        }

        public SizeAndStock GetSizeAndStock(string size)
        {
            SizeAndStock SelectedSize;
            SelectedSize = SelectedSizes.FirstOrDefault(x => x.Size == size);
            return SelectedSize;
        }

        public void ConfirmStock()
        {
            imgState = !imgState;
            ChosenColor = MyColors[0].ColorName;
        }

        public bool IsEmpty<T>(List<T> list)
        {
            if (list == null)
            {
                return true;
            }

            return list.Count == 0;
        }

        public void CheckboxSizes(string size, object checkvalue)
        {
            if ((bool)checkvalue)
                SelectedSizes.Add(new SizeAndStock(size));
            if (!(bool)checkvalue)
                if (SelectedSizes.Contains(GetSizeAndStock(size)))
                SelectedSizes.Remove(GetSizeAndStock(size));
        }

        public void CheckboxColours(string colour)
        {
   //            if (!MyColors.Contains(SwitchFuntion(colour)))
            SelectedSizes.Clear();
            SelectedColour = colour;

            //Disable checkbox if no colours are selected
            checkboxDisabled = false;
        }

        public void RemoveItem(int i, color Color)
        {
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

            string prodName = NewItem;
            string category = SelectedCat;
            string type = SelectedSubCat;
            if (int.TryParse(Price, out result))
            {
                int.Parse(Price);
            }
            string description = Description;
            string material = "Uld";
            string produced = "Uganda";
            string transparency = TransportPrice + "&" + ResourcePrice +"&" + ProductionPrice + "&" + TrimPrice + "&" + MillingPrice;
            foreach (var specificColour in MyColors)
            {
                string colour = specificColour.ColorName;
                string img = "";
                foreach (var image in specificColour.ImageLink)
                {
                    img += image + "&";
                }
                stockArray = stockList.ToArray();
                sizeArray = sizeList.ToArray();
                if (specificColour.ColorName == MyColors[0].ColorName)
                {
                    _call.AdminPages("New", "Product", prodName, category, type, Price, description, material, produced, transparency, colour, img, sizeArray, stockArray, "");
                }
                else
                {
                    _call.AdminPages("New", "Product", prodName, category, type, Price, description, material, produced, transparency, colour, img, sizeArray, stockArray, "same");
                }

            }
            NavigationManager.NavigateTo("/");
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