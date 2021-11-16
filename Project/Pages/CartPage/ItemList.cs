using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Project.CSharpFiles;

namespace Project.Pages.CartPage
{
    public class ItemList : ComponentBase
    {
        public List<Product> Order { get; set; }



        public double Total { get; set; }
        public static string SupplyDemand = "none";
        public static string NegativeOrder = "none";

        public int ErrorPos(int demand, int supply)
        {
            if (demand >= supply)
            {
                SupplyDemand = "block";
                return 0;
            }
            if (demand == 69)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                SupplyDemand = "none";
                NegativeOrder = "none";
                return 1;
            }
        }

        public int ErrorNeg(int demand, int supply)
        {
            if (demand <= 1)
            {
                NegativeOrder = "block";
                return 0;
            }
            else
            {
                NegativeOrder = "none";
                SupplyDemand = "none";
                return 1;
            }
        }

        public void RemoveError()
        {
            NegativeOrder = "none";
            SupplyDemand = "none";
        }

        public void CalcTotal()
        {
            Total = 0;
            foreach (var item in Order)
            {
                Total += item.SubTotal;
            }
        }

        public void LoadItems()
        {
            Order = new List<Product>();
            for (int i = 1; i < 10; i++)
            {
                Product item = Product.CreateInstance(i);
                item.SubTotal = item.Price;
                Order.Add(item);
            }
        }

        protected override Task OnInitializedAsync()
        {
            LoadItems();
            CalcTotal();
            return base.OnInitializedAsync();
        }
    }
}