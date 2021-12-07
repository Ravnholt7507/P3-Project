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
        public int Counter;
        public int LastCount;
        public DateTime dt;
        public List<int> Clicks = new List<int>();

        public void FirstTime()
        {
            dt = DateTime.Now;   
        }

        public void Store()
        {
            dt = DateTime.Now;
            Clicks.Add(Counter);
            if (Clicks.Count > 4)
            {
                Clicks.RemoveAt(0);
            }
            Counter = 0;
        }

        public void Count()
        {
            Counter++;
        }

        public async Task DoSomethingEveryTreeSeconds()
        {
            while (true)
            {
                var delayTask = Task.Delay(3000);
                Store();
                StateHasChanged();
                await delayTask; // wait until at least 10s elapsed since delayTask created
            }
        }

        protected override Task OnInitializedAsync()
        {
            FirstTime();
            DoSomethingEveryTreeSeconds();
            return base.OnInitializedAsync();
        }

    }
}

