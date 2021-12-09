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
        private int Week = 1;
        public string SListSize = "4";
        public DateTime DateNow;
        public DateTime Update_Date;
        public List<int> Weeks = new List<int>();
        public List<int> PageVisits = new List<int>();
        public List<int> Purchases = new List<int>();

        public List<int> SubPurchases = new List<int>();
        public List<int> SubPageVisits = new List<int>();
        public List<int> SubWeeks = new List<int>();
        
        // Start timer
        private void FirstTime()
        {
            DateNow = DateTime.Now;
            //WeekCalc();
            Update_Date = DateNow.AddSeconds(1);
        }

        //public void WeekCalc()
        //{
        //    for (int i = 0; i < 4; i++)
        //    {
        //        if (Weeks.Count != ) {
        //            var item = Weeks[^1] - i;
        //            SubWeeks[i] = item;

        //            SubPageVisits[i] = PageVisits[SubWeeks[i]];

        //            if (SubWeeks.Count > int.Parse(SListSize))
        //            {
        //                SubWeeks.RemoveAt(0);
        //                SubPageVisits.RemoveAt(0);
        //            }
        //        }
        //    }
        //}

        //Store Kpis in database
        private void StoreKpi()
        {
            PageVisits.Add(Visit);
            Purchases.Add(Purchase);
            Weeks.Add(Week);
            if (Weeks.Count > int.Parse(SListSize))
            {
                for (int i = 0; i < Weeks.Count - int.Parse(SListSize); i++)
                {
                    PageVisits.RemoveAt(0);
                    Purchases.RemoveAt(0);
                    Weeks.RemoveAt(0);
                }
               
            }
        }

        // Retrieve Kpis from database
        private void RetrieveKpi()
        {
            if (Week == 52) { Week = 0; }
            Week++;
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
        
        private void WeekCheck()
        {
            DateNow = DateTime.Now;
            if (DateTime.Compare(DateNow, Update_Date) > 0)
            {
                StoreKpi();
                RetrieveKpi();
                Update_Date = DateNow.AddSeconds(1);
            }
        }

        // Timer that run methods every n seconds
        private async Task DoSomethingEveryTreeSeconds()
        {
            while (true)
            {
                var delayTask = Task.Delay(1000);
                await delayTask; // wait until at least 3s elapsed since delayTask created
                WeekCheck();
                StateHasChanged();
            }
        }

        protected override Task OnInitializedAsync()
        {
            FirstTime();
            WeekCheck();
            DoSomethingEveryTreeSeconds();
            return base.OnInitializedAsync();
        }

    }
}

