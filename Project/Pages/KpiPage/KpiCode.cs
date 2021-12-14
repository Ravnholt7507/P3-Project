using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.CSharpFiles;

namespace Project.Pages.KpiPage 
{
    public class KpiCode : ComponentBase
    {
        public DbCall call = new DbCall();
        List<Product> KPIData = new List<Product>();
        public string Visible = "";
        private int i = 1;
        private int i2 = 1;
        public string Visible2 = "";
        public int Counter = 0;
        public int CounterOverride = 0;
        double _SoldPrView = 0;
        public string fillTable;
        
        public void ShowProducts(string type)
        {
            fillTable = type;
            StateHasChanged();
            Popup();
            Counter = 0;
        }

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
            i2++;
            if (i2 % 2 == 0)
            {
                Visible2 = "block";
            }
            else
            {
                Visible2 = "none";
            }
        }

        public List<string> Kpis = new List<string>() { "Antal produktvisninger", "Totale salg", "Visninger per salg, for produkt", "Salg af valgte farve", "RoI"};
        //public List<string> Months = new List<string>() { "Jan", "Feb", "Mar", "Apr" };
        public List<string> Percent = new List<string>();
        public string[] typeArray;
        public string[][][] ProductArray;

        protected override Task OnInitializedAsync()
        {
            typeArray = call.KPI("Type call");
            ProductArray = call.KPI2();
            return base.OnInitializedAsync();
        }

        public double RoI(double investment, int amountSold, double price)
        {
            double result = 0;

            result = (amountSold * price) / investment;

            return result * 100;
        }

        public double SoldPrView(int views, int sold)
        {
            double result = 0;

            if (sold != 0)
            {
                result = views / sold;
            }

            return result;     
        }
        
        public void ShowKPI(string[] productkpi)
        {
            List<string> placeholderdata = new List<string>();
            int TotalSales = 0;
            KPIData = call.KPI3(int.Parse(productkpi[1]));
            foreach (var item in KPIData)
            {
                TotalSales += item.Sold;
            }
            _SoldPrView = SoldPrView(KPIData[0].Views, TotalSales);
            placeholderdata.Add(KPIData[0].Views.ToString());
            placeholderdata.Add(TotalSales.ToString());
            placeholderdata.Add(_SoldPrView.ToString());
            foreach (var item in KPIData)
            {
                if (item.Colour == productkpi[4])
                {
                    placeholderdata.Add(item.Sold.ToString());
                }
            }
            Percent = placeholderdata;
        }
        public bool DataBaseVerify(string AccesToken)
        {
            return call.Verify(AccesToken);
        }
    }
}
