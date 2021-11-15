// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Project.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/_Imports.razor"
using Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/_Imports.razor"
using Project.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/_Imports.razor"
using Project.Shared.ComponentCode;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Products")]
    public partial class SearchProductPage : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 55 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Pages/SearchProductPage.razor"
       
    
    public void Loop()
    {
        for (int i = 1; i < 11; i++)
        {
            Product product = new Product();
            Products.Add(product);
        }
    }

    protected override Task OnInitializedAsync()
    {
        Loop();
        return base.OnInitializedAsync();
    }
    
    public List<Product> Products = new List<Product>()
    {
    };

    public class Product
    {
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageLink { get; set; }
        public string Description { get; set; }
    }

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
        if (string.IsNullOrWhiteSpace(filter)) return Products;
        return Products;
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
