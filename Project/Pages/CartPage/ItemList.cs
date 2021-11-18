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

        public List<Product> LoadItems(string[] array)
        {
            Order = new List<Product>();
            for (int i = 0; i < array.Length; i++)
            {
                Product item = Product.CreateInstance(array[i]);
                item.SubTotal = item.Price;
                Order.Add(item);
            }
            return Order;
        }

        protected override Task OnInitializedAsync()
        {
            CalcTotal();
            return base.OnInitializedAsync();
        }
    }
}