#pragma checksum "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Shared/NavMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f4c616d3332781ab8f434217bb59c150f9d1d778"
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
using Project.Data;

#line default
#line hidden
#nullable disable
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "nav");
            __builder.AddAttribute(1, "class", "w3-sidebar w3-bar-block w3-white w3-collapse w3-top");
            __builder.AddAttribute(2, "style", "z-index:3;width:250px");
            __builder.AddAttribute(3, "id", "mySidebar");
            __builder.AddMarkupContent(4, "<div class=\"w3-container w3-display-container w3-padding-16\"><i onclick=\"w3_close()\" class=\"fa fa-remove w3-hide-large w3-button w3-display-topright\"></i>\n        <h3 class=\"w3-wide\"><b>UTG Asket</b></h3></div>\n\n    ");
            __builder.OpenComponent<Project.Shared.Dropdown>(5);
            __builder.CloseComponent();
            __builder.AddMarkupContent(6, "\n    \n\n    ");
            __builder.AddMarkupContent(7, "<a href=\"#footer\" class=\"w3-bar-item w3-button w3-padding\">Contact</a>\n    ");
            __builder.AddMarkupContent(8, "<a href=\"javascript:void(0)\" class=\"w3-bar-item w3-button w3-padding\" onclick=\"document.getElementById(\'newsletter\').style.display=\'block\'\">Newsletter</a>\n    ");
            __builder.AddMarkupContent(9, "<a href=\"#footer\" class=\"w3-bar-item w3-button w3-padding\">Subscribe</a>");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
