using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Pages.KpiPage 
{
    public class KpiCode : ComponentBase
    {
        public int i = 1;
        public string Visible = "";

        public void Popup()
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
        public void StatsPopup()
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
    }
}
