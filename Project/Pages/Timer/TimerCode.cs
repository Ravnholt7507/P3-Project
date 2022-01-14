using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Pages
{
    public class TimerCode : ComponentBase
    {
        public int Visit;
        public int Purchase;
        private int Month = 1;
        public int ListSize;
        public DateTime DateNow;
        public DateTime Update_Date;
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
            Update_Date = DateNow.AddSeconds(3);
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
            DateNow = DateTime.Now;
            if (DateTime.Compare(DateNow, Update_Date) > 0)
            {
                StoreKpi();
                RetrieveKpi();
                Update_Date = DateNow.AddSeconds(3);
                if (Months.Count < 4)
                {
                    ShowMonths(0);
                }
                else
                {
                    ShowMonths(Months.Count - 4);
                }
                StateHasChanged();
            }
        }

        // Timer that run methods every n seconds
        public async Task DoSomethingEveryTreeSeconds()
        {
            while (true)
            {
                var delayTask = Task.Delay(3000);
                await delayTask; // wait until at least 3s elapsed since delayTask created
                MonthCheck();
                Console.WriteLine("Updated: " + DateNow);
            }
        }

        protected override Task OnInitializedAsync()
        {
            FirstTime();
            MonthCheck();
            DoSomethingEveryTreeSeconds();
            return base.OnInitializedAsync();
        }
    }
}

