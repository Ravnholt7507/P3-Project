using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using Project.CSharpFiles;
using System.Threading.Tasks;

namespace Project.Shared.ComponentCode
{
    public class DropdownCode : ComponentBase
    {
        public string selectedCat;
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
        public List<string> Pages = new List<string>();

        DbCall _call = new DbCall();
        public string[][] categoryArray;
        protected override Task OnInitializedAsync()
        {
            categoryArray = _call.AdminPages("Get", "Categories");
            System.Console.WriteLine(categoryArray[0][0]);
            return base.OnInitializedAsync();
        }
        public string[][] typeArray;
        public void CallSubcats(string selectedCat)
        {
            System.Console.WriteLine("asdfas" + selectedCat);
            typeArray = _call.AdminPages("Get", "Types", selectedCat);
            
        }
    }
}