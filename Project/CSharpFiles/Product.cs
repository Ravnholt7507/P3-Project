using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project.CSharpFiles
{
    public class Product
    {
        public Product(int i)
        {
            DbCall call = new DbCall();
            string[] array = call.SpecificArticleCall(i);
            this.Id = i;
            this.Name = array[0];
            this.Description = array[1];
            this.Colour = array[2];
            this.Size = array[3];
            this.Price = double.Parse(array[4]);
            this.Stock = int.Parse(array[5]);
            this.Transparency = array[6];
            this.Category = array[7];
            this.Type = array[8];
            this.ImageLink = array[9];
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Colour { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Transparency { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string ImageLink { get; set; }

        public int OrderAmount = 1;
        public double SubTotal { get; set; }

        public double CalcPrice()
        {
            return SubTotal = OrderAmount * Price;
        }

        public static Product CreateInstance(int i)
        {
            return new Product(i);
        }
    }

    public class ProductRepository
    {

    }
}
