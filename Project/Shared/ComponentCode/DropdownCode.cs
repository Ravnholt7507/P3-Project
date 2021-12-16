using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using Project.CSharpFiles;
using System.Threading.Tasks;

namespace Project.Shared.ComponentCode
{
    public class DropdownCode : ComponentBase
    {
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

        DbCall call = new DbCall();
        DbCall _call = new DbCall();
        public List<string> categories = new List<string>();
        public List<string> types = new List<string>();

        public string[][] categoryArray;
        public string[][] typeArray;
        protected override Task OnInitializedAsync()
        {
            categoryArray = _call.AdminPages("Get", "Categories");

            foreach (string cat in categoryArray[0])
            {
                if (cat != null)
                    categories.Add(cat);
            }
            return base.OnInitializedAsync();
        }

        public void CallSubcats(string selectedCat)
        {         
            typeArray = _call.AdminPages("Get", "Types", selectedCat);

            foreach (string type in typeArray[0])
            {
                if (type != null)
                    types.Add(type);
            }
        }
    }
}