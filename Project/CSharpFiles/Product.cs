using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project.CSharpFiles
{
    public class Product
    {
        public Product(params object[] args)
        {
            //this.Id = ;
            // this.Name = array[0];
            // this.Description = array[1];
            // this.Colour = array[2];
            // this.Size = array[3];
            // this.Price = double.Parse(array[4]);
            // this.Stock = int.Parse(array[5]);
            // this.Transparency = array[6];
            // this.Category = array[7];
            // this.Type = array[8];
            // this.ImageLink = array[9];
            // this.Barcode = array[10];
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Colour_id { get; set; }
        public string Colour { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Transparency { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string ImageLink { get; set; }
        public string Barcode { get; set; }

        public int OrderAmount = 1;
        public double SubTotal { get; set; }

        public double CalcPrice()
        {
            return SubTotal = OrderAmount * Price;
        }

         public static Product CreateInstance(string barcode)
         {
             return new Product();
         }

        public string[][] Call(string callType, params object[] args)
        {
            DbCall dbCall = new DbCall();
            string[][] productArray = {};
            string[][] array = new string[1][];
            if (callType == "Multiple products")
            {
                productArray = dbCall.ProductCalls("Multiple products");

            }

            else if (callType == "Specific Product")
            {
                if (args[0].ToString() == "Kald 1")
                {
                    productArray = dbCall.ProductCalls(callType, args[0], args[1], args[2]);                    
                }
                else if (args[0].ToString() == "Kald 2")
                {
                    productArray = dbCall.ProductCalls(callType, args[0], args[1]);
                }

            }
            else if (callType == "Cart Call")
            {
                productArray = dbCall.ProductCalls(callType, args);
            }
            
            return productArray;
        }
    }

    public class ProductRepository
    {

    }
}
