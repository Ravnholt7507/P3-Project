// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Project.Pages.ItemPages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "c:\users\runef\source\repos\p3-project\project\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "c:\users\runef\source\repos\p3-project\project\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "c:\users\runef\source\repos\p3-project\project\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "c:\users\runef\source\repos\p3-project\project\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "c:\users\runef\source\repos\p3-project\project\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "c:\users\runef\source\repos\p3-project\project\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "c:\users\runef\source\repos\p3-project\project\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "c:\users\runef\source\repos\p3-project\project\_Imports.razor"
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "c:\users\runef\source\repos\p3-project\project\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "c:\users\runef\source\repos\p3-project\project\_Imports.razor"
using Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "c:\users\runef\source\repos\p3-project\project\_Imports.razor"
using Project.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "c:\users\runef\source\repos\p3-project\project\_Imports.razor"
using Project.Shared.ComponentCode;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "c:\users\runef\source\repos\p3-project\project\_Imports.razor"
using System.Linq;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "c:\users\runef\source\repos\p3-project\project\Pages\ItemPages\ItemSearchPage.razor"
using Project.CSharpFiles;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Products")]
    public partial class ItemSearchPage : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 24 "c:\users\runef\source\repos\p3-project\project\Pages\ItemPages\ItemSearchPage.razor"
       

    public void Loop()
    {
        Product productCall = new Product();
        string[][] productArray = productCall.Call("Multiple products");
        for (int i = 0; i < productArray.Length; i++)
        {
            Product newproduct = new Product
            {
                Id = int.Parse(productArray[i][0]),
                Name = productArray[i][1],
                Price = double.Parse(productArray[i][2]),
                Colour_id = int.Parse(productArray[i][3]),
                ImageLink = productArray[i][4],
                Size = productArray[i][5]
            };
            Products.Add(newproduct);
        }
    }

    protected override Task OnInitializedAsync()
    {
        Loop();
        return base.OnInitializedAsync();
    }

    public List<Product> Products = new List<Product>() { };

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Products = GetProducts();
    }

    public void HandleSearch(string filter)
    {
        Products = GetProducts(filter);
    }


    public List<Product> GetProducts(string filter = null)
    {
        if (string.IsNullOrWhiteSpace(filter))
        {
            return Products;
        }

        var array = filter.Split(' ');
        DbCall dbcall = new DbCall();
        string[] itemArray = dbcall.SearchCall("Kvinder", "bukser", "bl??", "small");
        Console.WriteLine(itemArray[0][0]);
        List<Product> newProducts = new List<Product>();
        for (int i = 0; i < itemArray.Length; i++)
        {
            newProducts.Add(Product.CreateInstance(itemArray[i]));
        }
        return newProducts;
    }

    [Parameter]
    public Product CartItem { get; set; }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
