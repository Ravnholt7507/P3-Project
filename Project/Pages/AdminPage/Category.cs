using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Pages.AdminPage
{
    public class Category
    {
        public string CategoryName;
        public Category(string Name)
        {
            CategoryName = Name;
        }
        public override bool Equals(object obj)
        {
            return this.CategoryName == ((Category)obj).CategoryName;
        }
        public List<Subcategory> Subcategory = new List<Subcategory>();
    }
}
