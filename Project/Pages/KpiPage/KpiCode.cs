﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.CSharpFiles;

namespace Project.Pages.KpiPage 
{
    public class KpiCode : ComponentBase
    {
        private DbCall call = new DbCall();
        
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
        public List<string> Kpis = new List<string>() { "Resultgrad", "Buffer", "Egenkapital", "Likviditet" };
        public List<string> Months = new List<string>() { "Jan", "Feb", "Mar", "Apr" };
        public List<string> Percent = new List<string>() { "5%", "10%", "30%", "70%" };

        protected override Task OnInitializedAsync()
        {
            string[] typeArray = call.KPI("Type call");
            return base.OnInitializedAsync();
        }
    }
}
