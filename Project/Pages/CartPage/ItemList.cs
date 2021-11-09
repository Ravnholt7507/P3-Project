using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Pages
{
    public class ItemList : ComponentBase
    {
        public List<Product> Order { get; set; }
        public class Product
        {
            public string Type { get; set; }
            public double Price { get; set; }
            public double subTotal { get; set; }
            public int StorageCount { get; set; }
            public int OrderAmount { get; set; }
            public double CalcPrice()
            {
                return subTotal = OrderAmount * Price;
            }
        }
        public double Total { get; set; }
        public static string Supply_Demand = "none";
        public static string NegativeOrder = "none";

        public int ErrorPos(int Demand, int Supply)
        {
            if (Demand >= Supply)
            {
                Supply_Demand = "block";
                return 0;
            }
            if (Demand == 69)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                Supply_Demand = "none";
                NegativeOrder = "none";
                return 1;
            }
        }
        public int ErrorNeg(int Demand, int Supply)
        {
            if (Demand <= 1)
            {
                NegativeOrder = "block";
                return 0;
            }
            else
            {
                NegativeOrder = "none";
                Supply_Demand = "none";
                return 1;
            }
        }
        public void RemoveError()
        {
            NegativeOrder = "none";
            Supply_Demand = "none";
        }


        public void CalcTotal()
        {
            Total = 0;
            foreach (var item in Order)
            {
                Total += item.subTotal;
            }   
        }

        public void LoadItems()
        {
            Product Item1 = new Product
            {
                Type = "Shorts",
                Price = 100,
                OrderAmount = 1,
                StorageCount = 100,
                subTotal = 100
            };
            Product Item2 = new Product
            {
                Type = "Shirt",
                Price = 52,
                OrderAmount = 1,
                StorageCount = 5,
                subTotal = 52
            };
            Product Item3 = new Product
            {
                Type = "Hat",
                Price = 69,
                OrderAmount = 1,
                StorageCount = 2,
                subTotal = 69
            };
            Product Item4 = new Product
            {
                Type = "Hoodie",
                Price = 96,
                OrderAmount = 1,
                StorageCount = 4,
                subTotal = 96
            };

            Order = new List<Product> { Item1, Item2, Item3, Item4};
        }
        protected override Task OnInitializedAsync()
        {
            LoadItems();
            CalcTotal();
            return base.OnInitializedAsync();
        }
    }
}