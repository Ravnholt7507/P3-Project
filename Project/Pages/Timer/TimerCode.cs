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
        public DateTime dt;

        public void Main2()
        {
            dt = DateTime.Now;
            Main3();

        }

        public void Store()
        {
            dt = DateTime.Now;
        }

        public void Count()
        {
            Counter++;
        }

        protected override Task OnInitializedAsync()
        {
            Main2();
            return base.OnInitializedAsync();
        }

        public void ShowTime()
        {
            for (; ; )
            {
                Console.WriteLine(DateTime.Now.ToString());
                Console.WriteLine("\a");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        static void Main3()
        {
            TimerCode PC = new TimerCode();
            ThreadStart TS = new ThreadStart(PC.ShowTime);
            Thread t = new Thread(TS);
            t.Start();
            Console.ReadLine();
        }
    }
}

