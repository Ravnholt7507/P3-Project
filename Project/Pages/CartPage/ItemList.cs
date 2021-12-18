using System;
using System.Collections.Generic;
using System.Linq;
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
                string[] singleProd = array[i].Split(" ");
                singleProd = singleProd.Skip(1).ToArray();

                Product item = new Product();
                item.Id = int.Parse(singleProd[0]);
                item.Colour_id = int.Parse(singleProd[1]);
                
                string[][] prodArray = new string[1][];
                prodArray= item.Call("Cart Call", array[i]);
                item.Name = prodArray[0][0];
                item.Price = double.Parse(prodArray[0][1]);
                item.Colour = prodArray[0][2];
                item.ImageLink = prodArray[0][3];
                item.Size = prodArray[0][4];
                item.Stock = int.Parse(prodArray[0][5]);
                item.SubTotal = item.Price;
                Order.Add(item);
            }
            return Order;
        }
    }
}