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
#line 1 "C:\Users\runef\Source\Repos\p3-project\Project\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\runef\Source\Repos\p3-project\Project\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\runef\Source\Repos\p3-project\Project\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\runef\Source\Repos\p3-project\Project\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\runef\Source\Repos\p3-project\Project\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\runef\Source\Repos\p3-project\Project\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\runef\Source\Repos\p3-project\Project\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\runef\Source\Repos\p3-project\Project\_Imports.razor"
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\runef\Source\Repos\p3-project\Project\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\runef\Source\Repos\p3-project\Project\_Imports.razor"
using Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\runef\Source\Repos\p3-project\Project\_Imports.razor"
using Project.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\runef\Source\Repos\p3-project\Project\_Imports.razor"
using Project.Shared.ComponentCode;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\runef\Source\Repos\p3-project\Project\_Imports.razor"
using System.Linq;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\runef\Source\Repos\p3-project\Project\Pages\ItemPages\SpecificItem.razor"
using Project.CSharpFiles;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Product/{ItemSpecification}")]
    public partial class SpecificItem : SpecificItemCode
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 57 "C:\Users\runef\Source\Repos\p3-project\Project\Pages\ItemPages\SpecificItem.razor"
       
    
    public string Visits;
    public string CartItem;

    // Add an item to a string in local storage that works as a cart
    public void AddItem()
    {
        CartItem += $"& {Prod.Id} {Prod.ColourFinder(SelectedColour).ColourId} {SelectedSize}";
    }

    public void ResetSize()
    {
        SelectedSize = Prod.ColourFinder(SelectedColour).Sizes[0];
    }

    public string FindStock(string SelectedColour, string SelectedSize)
    {
        int TempVar = Prod.ColourFinder(SelectedColour).Sizes.FindIndex(x => x == SelectedSize);
        if (TempVar < 0)
        {
            ResetSize();
            return Prod.ColourFinder(SelectedColour).stock[0];
        }
        return Prod.ColourFinder(SelectedColour).stock[TempVar];
    }

    // Load the cart from local storage
    public async Task Read()
    {
        var result = await BrowserStorage.GetAsync<string>("CartItems");
        CartItem = result.Success ? result.Value : "";
    }

    public async Task Read2() {
        var result = await SessionStorage.GetAsync<string>("PagesVisited");
        Visits = result.Success ? result.Value : "";
        var visitArray = SplitVisits();

        // DbCall
        if (!visitArray.Contains(Prod.Id.ToString()))
        {
            DbCall call = new DbCall();
            call.VisitUpdate(Prod.Id);
        }
        Visits += "$" + Prod.Id;
        await Save();
    }

    // Save the string into local storage
    public async Task Save()
    {
        await BrowserStorage.SetAsync("CartItems", CartItem);
        await SessionStorage.SetAsync("PagesVisited", Visits);
    }

    public string[] SplitVisits()
    {
        var array = Visits.Split('$');
        array = array.Skip(1).ToArray();
        array = array.Distinct().ToArray();
        return array;
    }

    // Load specific methods on page load
    protected override Task OnInitializedAsync()
    {
        Read();
        Read2();
        return base.OnInitializedAsync();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ProtectedSessionStorage SessionStorage { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ProtectedLocalStorage BrowserStorage { get; set; }
    }
}
#pragma warning restore 1591
