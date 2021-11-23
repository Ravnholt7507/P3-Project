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
#line 1 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/_Imports.razor"
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/_Imports.razor"
using Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/_Imports.razor"
using Project.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/_Imports.razor"
using Project.Shared.ComponentCode;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/_Imports.razor"
using System.Linq;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Pages/ItemPages/ItemSearchPage.razor"
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
#line 56 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Pages/ItemPages/ItemSearchPage.razor"
       
    
    public void Loop()
    {
        string[] placeholder = {"0209094010800000","0204044020100000","0201074000000000","0210061100700000","0109020080300000","0210001040000000","0209113060700000","0002002070700000","0005123090700000","0102072000400000" };
        foreach (var barcode in placeholder)
        {
            Product product = new Product(barcode);
            Products.Add(product);
        }
    }

    protected override Task OnInitializedAsync()
    {
        Loop();
        return base.OnInitializedAsync();
    }
    
    public List<Product> Products = new List<Product>() {};

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
            Console.WriteLine("Null");
            return Products;
        }
        
        var array = filter.Split(' ');
        DbCall dbcall = new DbCall();
        string[] itemArray = dbcall.SearchCall("blå", "small");
        Console.WriteLine(itemArray[0][0]);
        List<Product> newProducts = new List<Product>();
        for (int i = 0; i < itemArray.Length; i++)
        {
            newProducts.Add(Product.CreateInstance(itemArray[i]));
        }
        return newProducts;
    }

    [Parameter]
        public Product CartItem{ get; set; }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591