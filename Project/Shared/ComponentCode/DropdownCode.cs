using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using Project.CSharpFiles;

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
        public List<string> Pages = new List<string>();

        public void DbCallType()
        {
            Pages.Clear();
            var array = call.KPI("Type call");
            foreach (string item in array)
            {
                Pages.Add(item);
            }
        }
    }
}