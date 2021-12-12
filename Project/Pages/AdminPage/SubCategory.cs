using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Pages.AdminPage
{
    public class Subcategory
    {
        public string SubcategoryName;
        public Subcategory(string Name)
        {
            SubcategoryName = Name;
        }
        public override bool Equals(object obj)
        {
            return this.SubcategoryName == ((Subcategory)obj).SubcategoryName;
        }
    }

}
