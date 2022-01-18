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
            i = 1;
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
            i2 = 1;
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

        public List<string> Kpis = new List<string>() { "Antal produktvisninger", "Totale salg", "Visninger per salg, for produkt", "RoI"};
        public List<string> Percent = new List<string>();
        public string[] typeArray;
        public string[][][] ProductArray;

        protected override Task OnInitializedAsync()
        {
            FirstTime();
            MonthCheck();
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


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        private int Month = 1;
        public int ListSize;
        public DateTime DateNow;
        public int UpdateDate;

        public List<int> Months = new List<int>();
        public List<int> PageVisits = new List<int>();
        public List<int> Purchases = new List<int>();
        public List<int> PurchVisit = new List<int>();

        public List<int> SubMonths = new List<int>();
        public List<int> SubVisits = new List<int>();
        public List<int> SubPurchases = new List<int>();
        public List<int> SubPurchVisit = new List<int>();

        public void ShowMonths(int k)
        {
            SubMonths.Clear();
            SubVisits.Clear();
            SubPurchases.Clear();
            SubPurchVisit.Clear();

            for (int i = k; i < k + 4; i++)
            {
                if (i < Months.Count)
                {
                    SubMonths.Add(Months.ElementAt(i));
                    SubVisits.Add(PageVisits.ElementAt(i));
                    SubPurchases.Add(Purchases.ElementAt(i));
                    SubPurchVisit.Add(PurchVisit.ElementAt(i));
                }
            }
        }

        // Start timer
        public void FirstTime()
        {
            DateNow = DateTime.Now;
            UpdateDate = DateTime.DaysInMonth(DateNow.Year, DateNow.Month);

            if (Months.Count < 4)
            {
                ShowMonths(0);
            }
            else
            {
                ShowMonths(Months.Count - 4);
            }
        }

        //Store Kpis in database
        private void StoreKpi()
        {
            //PageVisits.Add(int);
            //Purchases.Add(int);
            //Months.Add(string);
            //PurchVisit.Add(double);
        }

        // Retrieve Kpis from database
        private void RetrieveKpi()
        {
            if (Month == 12) { Month = 0; }
            Month++;
        }

        private void SaveKpi(DateTime date)
        {
            DbCall dbCall = new DbCall();
            dbCall.NewMonthInDb(date);
            dbCall.SaveToKpi(date);
        }

        public void MonthCheck()
        {
            //DateNow = DateTime.Now;
            UpdateDate = DateTime.DaysInMonth(DateNow.Year, DateNow.Month);
            if (DateNow.Date.Day == UpdateDate)
            {
                SaveKpi(DateNow);
                StoreKpi();
                RetrieveKpi();
                if (Months.Count < 4)
                {
                    ShowMonths(0);
                }
                else
                {
                    ShowMonths(Months.Count - 4);
                }
                //StateHasChanged();
            }
        }

        // Timer that run methods every n seconds
        public async Task DoSomethingEveryTreeSeconds()
        {
            DateNow = DateTime.Now;
            while (true)
            {
                var delayTask = Task.Delay(1000);
                await delayTask; // wait until at least 3s elapsed since delayTask created
                DateNow = DateNow.AddDays(1);
                MonthCheck();
                Console.WriteLine("Updated: " + DateNow);
            }
        }
    }
}
