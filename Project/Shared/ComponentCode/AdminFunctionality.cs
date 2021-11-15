using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Shared
{
    public class AdminFunctionality : ComponentBase
    {
        public string addItem = null;
        public string[] colors =
        {
        "black",
        "white",
        "blue",
        "green",
        "red",
        "yellow",
        "purple",
        "brown",
        "grey",
        "pink",
        "orange"
    };
        public string[] sizes =
        {
        "xxs",
        "xs",
        "s",
        "m",
        "l",
        "xl",
        "xxl"
    };



        public class Product
        {
            public string Type { get; set; }
            public double Price { get; set; }
            public string[] color { get; set; }
            public string[] size { get; set; }


        }

        public void LoadItems()
        {

            //Product Item1 = new Product
            //{
            //    Type = "Shorts",
            //    Price = 100

            //};
            //Product Item2 = new Product
            //{
            //    Type = "Shirt",
            //    Price = 52

            //};
        }
        protected override Task OnInitializedAsync()
        {
            LoadItems();
            return base.OnInitializedAsync();
        }
    }


   
}
