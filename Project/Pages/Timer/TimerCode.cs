using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Project.CSharpFiles;

namespace Project.Pages
{
    public class TimerCode : ComponentBase
    {
        public int Visit;
        public int Purchase;
        private int Month = 1;
        public int ListSize;
        public DateTime DateNow;
        public int UpdateDate;
        public List<int> Months = new List<int>();
        public List<int> PageVisits = new List<int>();
        public List<int> Purchases = new List<int>();

        public List<int> SubMonths = new List<int>();
        public List<int> SubVisits = new List<int>();
        public List<int> SubPurchases = new List<int>();

        public void ShowMonths(int k)
        {
            SubMonths.Clear();
            SubVisits.Clear();
            SubPurchases.Clear();

            for (int i = k; i < k + 4; i++)
            {
                if (i < Months.Count)
                {
                    SubMonths.Add(Months.ElementAt(i));
                    SubVisits.Add(PageVisits.ElementAt(i));
                    SubPurchases.Add(Purchases.ElementAt(i));
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
            PageVisits.Add(Visit);
            Purchases.Add(Purchase);
            Months.Add(Month);
        }

        // Retrieve Kpis from database
        private void RetrieveKpi()
        {
            if (Month == 12) { Month = 0; }
            Month++;
            Visit = 0;
            Purchase = 0;
        }

        private void SaveKpi(DateTime date)
        {
            DbCall dbCall = new DbCall();
            dbCall.NewMonthInDb(date);
            dbCall.SaveToKpi(date);
        }

        // Count a page event
        public void APageVisit()
        {
            Visit++;
        }
        public void APurchase()
        {
            Purchase++;
        }

        public void MonthCheck()
        {
            //DateNow = DateTime.Now;
            UpdateDate = DateTime.DaysInMonth(DateNow.Year, DateNow.Month);
            if (DateNow.Date.Day == UpdateDate )
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

        protected override Task OnInitializedAsync()
        {
            FirstTime();
            MonthCheck();
            //DoSomethingEveryTreeSeconds();
            return base.OnInitializedAsync();
        }
    }
}

