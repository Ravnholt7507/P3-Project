#pragma checksum "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Shared/PrintList.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2b381bfc4e5481194e8a5db865059a2674411227"
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
    public partial class PrintList : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "Kasse");
#nullable restore
#line 8 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Shared/PrintList.razor"
     for (int i = 0; i < Pages.Count; i++)
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(2, "a");
            __builder.AddAttribute(3, "href", 
#nullable restore
#line 10 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Shared/PrintList.razor"
                  Pages[i]

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(4, "class", "w3-bar-item w3-button");
#nullable restore
#line 10 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Shared/PrintList.razor"
__builder.AddContent(5, Pages[i]);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
#nullable restore
#line 11 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Shared/PrintList.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 2 "/Users/minmacbook/OneDrive - Aalborg Universitet/Uni/Programmering/3. Semester/P3/P3-Project/Project/Shared/PrintList.razor"
       
    [Parameter]
    public List<string> Pages { get; set; }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
