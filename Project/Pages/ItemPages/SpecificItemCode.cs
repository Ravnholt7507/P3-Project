using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Project.CSharpFiles;

namespace Project.Pages.ItemPages
{
    public class SpecificItemCode : ComponentBase
    {
        public Product prod;

        [Parameter]
        public string Barcode { get; set; }
        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if (Barcode != "")
            {
                prod = GetProduct(Barcode);
            }
        }

        public Product GetProduct(string barcode)
        {
            Product product = new Product(barcode);
            {
                if (product.Barcode == barcode)
                    return product;
                return null;
            }
        }
    }
}
