#pragma checksum "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Shared/Dropdown.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4a06e41d686a3fd1e01b315a360f6f83a49450bf"
// <auto-generated/>
#pragma warning disable 1591
namespace Project.Shared
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
    public partial class Dropdown : DropdownCode
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "w3-padding-64 w3-large w3-text-grey");
            __builder.AddAttribute(2, "style", "font-weight:bold");
            __builder.OpenElement(3, "button");
            __builder.AddAttribute(4, "class", "w3-bar-item w3-button");
            __builder.AddAttribute(5, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 4 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Shared/Dropdown.razor"
                                                    Dropdownbtn

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(6, "<i class=\"fa fa-bars\"></i>Kategorier");
            __builder.CloseElement();
            __builder.AddMarkupContent(7, "\n    ");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "dropdown-content");
            __builder.OpenComponent<Project.Shared.PrintList>(10);
            __builder.AddAttribute(11, "Pages", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.List<System.String>>(
#nullable restore
#line 6 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Shared/Dropdown.razor"
                          InsertPages

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(12, "\n\n");
            __builder.OpenElement(13, "style");
            __builder.AddMarkupContent(14, "\n    .dropdown-content {\n        display: none;\n        display: ");
#nullable restore
#line 13 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Shared/Dropdown.razor"
__builder.AddContent(15, Visible);

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(16, ";\n    }\n    .dropdown-content a{\n        margin-left: 10px;\n    }\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
