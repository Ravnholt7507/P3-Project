using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<string> InsertPages = new List<string>() { "Counter", "Admin", "Jackets", "Andreas", "Products" };       
    }
}
