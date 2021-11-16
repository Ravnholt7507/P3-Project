using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.CSharpFiles;

namespace Project.Pages
{
    public class SpecificItemCode : ComponentBase
    {
        public Product prod;

        [Parameter]
        public int Id { get; set; }
        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if (Id > 0)
            {
                prod = GetProduct(Id);
            }
        }

        public Product GetProduct(int id)
        {
            Product product = new Product(id);
            {
                if (product.Id == id)
                    return product;
                return null;
            }
        }

        public List<Product> CartItems = new List<Product>() {};

        public void AddToCart(Product item)
        {
            CartItems.Add(item);
        }
    }
}
