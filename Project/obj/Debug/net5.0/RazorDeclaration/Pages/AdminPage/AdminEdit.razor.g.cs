// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Project.Pages.AdminPage
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
#line 2 "C:\Users\runef\Source\Repos\p3-project\Project\Pages\AdminPage\AdminEdit.razor"
using CSharpFiles;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\runef\Source\Repos\p3-project\Project\Pages\AdminPage\AdminEdit.razor"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\runef\Source\Repos\p3-project\Project\Pages\AdminPage\AdminEdit.razor"
using System.Linq;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/EditProducts")]
    public partial class AdminEdit : AdminCode
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 210 "C:\Users\runef\Source\Repos\p3-project\Project\Pages\AdminPage\AdminEdit.razor"
           
        public int i = 1;
        public string Visible = "";

        public void Popup()
        {
            i++;
            if (i % 2 == 0)
            {
                Visible = "block";
            }
            else
            {
                Visible = "none";
            }
        }



        string PlaceholderName;
        string PlaceholderPrice;
        string PlaceholderDescription;
        string PlaceholderTransparency;
        string PlaceholderMaterials;

    

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
