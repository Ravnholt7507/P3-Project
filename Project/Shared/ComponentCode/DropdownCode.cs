using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

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

        public List<string> InsertPages = new List<string>() { "Admin", "Admin2", "Kpi", "Products", "EditProducts" };
    }
}