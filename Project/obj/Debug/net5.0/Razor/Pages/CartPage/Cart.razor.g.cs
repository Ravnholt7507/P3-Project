#pragma checksum "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Pages/CartPage/Cart.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "54bc7ba2bb4aa3ef9cdbdb61d4dff4a52c2bdfad"
// <auto-generated/>
#pragma warning disable 1591
namespace Project.Pages.CartPage
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
#line 3 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Pages/CartPage/Cart.razor"
using CSharpFiles;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Cart")]
    public partial class Cart : ItemList
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "input");
            __builder.AddAttribute(1, "class", "form-control");
            __builder.AddAttribute(2, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 6 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Pages/CartPage/Cart.razor"
                                   ItemsInCart

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(3, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => ItemsInCart = __value, ItemsInCart));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(4, "\n");
            __builder.OpenElement(5, "button");
            __builder.AddAttribute(6, "class", "btn btn-secondary");
            __builder.AddAttribute(7, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 7 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Pages/CartPage/Cart.razor"
                                            Read

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(8, "Read");
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\n");
            __builder.OpenElement(10, "button");
            __builder.AddAttribute(11, "class", "btn btn-secondary");
            __builder.AddAttribute(12, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 8 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Pages/CartPage/Cart.razor"
                                            Delete

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(13, "Delete");
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\n\n");
            __builder.AddMarkupContent(15, "<h1>Din indkoebskurv</h1>\n\n\n");
            __builder.OpenElement(16, "div");
            __builder.AddAttribute(17, "class", "page");
            __builder.OpenElement(18, "div");
            __builder.AddAttribute(19, "class", "cart-overview");
#nullable restore
#line 42 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Pages/CartPage/Cart.razor"
         foreach (var item in Order)
        {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(20, "div");
            __builder.AddAttribute(21, "class", "item-container");
            __builder.OpenElement(22, "h4");
#nullable restore
#line 45 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Pages/CartPage/Cart.razor"
__builder.AddContent(23, item.Name);

#line default
#line hidden
#nullable disable
            __builder.AddContent(24, " x ");
#nullable restore
#line 45 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Pages/CartPage/Cart.razor"
__builder.AddContent(25, item.OrderAmount);

#line default
#line hidden
#nullable disable
            __builder.AddContent(26, " ");
            __builder.OpenElement(27, "p");
            __builder.AddAttribute(28, "class", "right");
#nullable restore
#line 45 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Pages/CartPage/Cart.razor"
__builder.AddContent(29, item.SubTotal);

#line default
#line hidden
#nullable disable
            __builder.AddContent(30, ",-");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\n                ");
            __builder.OpenElement(32, "button");
            __builder.AddAttribute(33, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 46 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Pages/CartPage/Cart.razor"
                                  () => { item.OrderAmount += ErrorPos(item.OrderAmount, item.Stock); item.CalcPrice(); CalcTotal(); }

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(34, "class", "butt");
            __builder.AddMarkupContent(35, "<b>+</b>");
            __builder.CloseElement();
            __builder.AddMarkupContent(36, "\n                ");
            __builder.OpenElement(37, "button");
            __builder.AddAttribute(38, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 47 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Pages/CartPage/Cart.razor"
                                  () => { item.OrderAmount -= ErrorNeg(item.OrderAmount, item.Stock); item.CalcPrice(); CalcTotal(); }

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(39, "class", "butt");
            __builder.AddMarkupContent(40, "<b>-</b>");
            __builder.CloseElement();
            __builder.AddMarkupContent(41, "\n                ");
            __builder.OpenElement(42, "button");
            __builder.AddAttribute(43, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 48 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Pages/CartPage/Cart.razor"
                                  () => { Order.Remove(item); CalcTotal(); RemoveError(); }

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(44, "class", "butt right");
            __builder.AddMarkupContent(45, "<b>x</b>");
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 50 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Pages/CartPage/Cart.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.OpenElement(46, "div");
            __builder.AddAttribute(47, "class", "order-total");
            __builder.OpenElement(48, "p");
            __builder.AddContent(49, "Ordre Total:");
            __builder.OpenElement(50, "b");
            __builder.AddAttribute(51, "class", "right");
#nullable restore
#line 52 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Pages/CartPage/Cart.razor"
__builder.AddContent(52, Total);

#line default
#line hidden
#nullable disable
            __builder.AddContent(53, ",-");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(54, "\n            ");
            __builder.AddMarkupContent(55, "<b class=\"Supply_Demand error\">Not enough in stock :(</b>\n            ");
            __builder.AddMarkupContent(56, "<b class=\"Negative_Order error\">If you want to remove press X instead</b>\n            ");
            __builder.AddMarkupContent(57, "<a class=\"butt\" href=\"https://www.youtube.com/watch?v=dQw4w9WgXcQ\">Checkout</a>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(58, "\n\n");
            __builder.OpenElement(59, "style");
            __builder.AddMarkupContent(60, @"
    .page {
        height: fit-content;
        margin-bottom: 30px;
    }

    .cart-overview {
        outline: solid;
        outline-color: black;
        width: 500px;
        background-color: #efefef;
    }

    .item-container {
        border-bottom: 1px solid;
        padding: 2px;
    }

    .order-total {
        background-color: #bababa;
        height: 100%;
    }

    .order-total p{
        font-size: 30px;
    }

    .right {
        float: right;
    }

    .cart-overview b {
        font-size: large;
    }

    .error {
        background-color: lightcoral;
    }

    .Supply_Demand {
        display: ");
#nullable restore
#line 100 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Pages/CartPage/Cart.razor"
__builder.AddContent(61, SupplyDemand);

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(62, ";\n    }\n\n    .Negative_Order {\n        display: ");
#nullable restore
#line 104 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Pages/CartPage/Cart.razor"
__builder.AddContent(63, NegativeOrder);

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(64, ";\n    }\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 12 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Pages/CartPage/Cart.razor"
       
    public string ItemsInCart;

    public async Task Read()
    {
        var result = await BrowserStorage.GetAsync<string>("CartItems");
        ItemsInCart = result.Success ? result.Value : "";
        Console.WriteLine(ItemsInCart);
    }

    public async Task Delete()
    {
        await BrowserStorage.DeleteAsync("CartItems");
    }
    public string[] BarcodeArray()
    {
        string[] array = ItemsInCart.Split(' ');
        return array;
    }
    
    protected override Task OnInitializedAsync()
    {
        Read();
        //LoadItems(BarcodeArray());
        return base.OnInitializedAsync();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ProtectedLocalStorage BrowserStorage { get; set; }
    }
}
#pragma warning restore 1591
