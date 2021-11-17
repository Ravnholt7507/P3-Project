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
    }
}
