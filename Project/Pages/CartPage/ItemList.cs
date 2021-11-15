using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Project.Data;

namespace Project.Pages
{
    public class ItemList : ComponentBase
    {
        public List<Product> Order { get; set; }
        
        public class Product
        {
            private DbCall Call = new DbCall();

            private Product(int i)
            {
                string[] array = Call.CartCall(i);
                this.Name = array[0];
                this.Price = int.Parse(array[1]);
                this.OrderAmount = 1;
                this.SubTotal = Price;
            }

            public static Product CreateInstance(int i)
            {
                return new Product(i);
            }

            public string Name { get; set; }
            public double Price { get; set; }
            public double SubTotal { get; set; }
            public int OrderAmount { get; set; }
            public double CalcPrice()
            {
                return SubTotal = OrderAmount * Price;
            }
            
        }
        public double Total { get; set; }

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
            //for (int i = 1; i < 100; i++)
            //{
            int i = 52; 
            Product item = Product.CreateInstance(i);
            Order.Add(item);
            //}
        }
        protected override Task OnInitializedAsync()
        {
            LoadItems();
            CalcTotal();
            return base.OnInitializedAsync();
        }
    }
}