using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Project.CSharpFiles;

namespace Project.Pages.ItemPages
{
    public class SpecificItemCode : ComponentBase
    {
        public Product Prod;

        [Parameter]
        public string ItemSpecification { get; set; }


        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            string[] specificationArray = new string[4];
            specificationArray = ItemSpecification.Split("&");
            int prodId = int.Parse(specificationArray[0]);
            int colourId = int.Parse(specificationArray[1]);
            string size = specificationArray[2];
            

            if (prodId != 0 && colourId != 0 && size != "")
            {
                Prod = GetProduct(prodId, colourId, size);
            }
        }

        public Product GetProduct(int prodid, int colourid, string size)
        {
            Product product = new Product
            {
                Id = prodid,
                Colour_id = colourid,
                Size = size
            };
            string[][] array = new string[1][];
            array = product.Call("Specific Product", "Kald 1", prodid, colourid);
            string[][] colourSizeArray = product.Call("Specific Product", "Kald 2", prodid);
            product.Name = array[0][0];
            product.Price = int.Parse(array[0][1]);
            product.Description = array[0][2];
            product.ImageLink = array[0][3];
     
            for (int i = 0; i < colourSizeArray.Length; i++)
            {
                if (colourSizeArray[i] != null)
                {
                    //product.ColourList.Add(colourSizeArray[i][0]);
                    product.MyColours.Add(new Colour(colourSizeArray[i][0]));
                }
            }
            
            for (int i = 0; i < colourSizeArray.Length; i++) 
            {
                if (colourSizeArray[i] != null)
                    {
                    for (int k = 2; k < colourSizeArray.Length; k++)
                    {
                        if (colourSizeArray[i][k] != null)
                        {
                            product.MyColours[i].Sizes.Add(colourSizeArray[i][k]); 
                        }
                    }                 
                }
            }
            if (product.Id == prodid && product.Colour_id == colourid && product.Size == size)
                return product;
            return null;
        }
    }
}
