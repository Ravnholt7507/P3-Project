#pragma checksum "C:\Users\runef\Source\Repos\p3-project\Project\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7af15ab49d41b0c19c3737c9110e263e83aefd69"
// <auto-generated/>
#pragma warning disable 1591
namespace Project.Shared
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
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "page");
            __builder.AddAttribute(2, "b-ajb5ewb1of");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "b-ajb5ewb1of");
            __builder.OpenComponent<Project.Shared.NavMenu>(5);
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(6, "\r\n    ");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "class", "main");
            __builder.AddAttribute(9, "b-ajb5ewb1of");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "content px-4");
            __builder.AddAttribute(12, "b-ajb5ewb1of");
            __builder.AddMarkupContent(13, "<!DOCTYPE html>\r\n            ");
            __builder.OpenElement(14, "html");
            __builder.AddAttribute(15, "b-ajb5ewb1of");
            __builder.AddMarkupContent(16, @"<title b-ajb5ewb1of>W3.CSS Template</title>
            <meta charset=""UTF-8"" b-ajb5ewb1of>
            <meta name=""viewport"" content=""width=device-width, initial-scale=1"" b-ajb5ewb1of>
            <link rel=""stylesheet"" href=""https://www.w3schools.com/w3css/4/w3.css"" b-ajb5ewb1of>
            <link rel=""stylesheet"" href=""https://fonts.googleapis.com/css?family=Roboto"" b-ajb5ewb1of>
            <link rel=""stylesheet"" href=""https://fonts.googleapis.com/css?family=Montserrat"" b-ajb5ewb1of>
            <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"" b-ajb5ewb1of>

            ");
            __builder.AddMarkupContent(17, @"<style b-ajb5ewb1of>
                .w3-sidebar a {
                    font-family: ""Roboto"", sans-serif
                }

                body, h1, h2, h3, h4, h5, h6, .w3-wide {
                    font-family: ""Montserrat"", sans-serif;
                }

                .buttright{
                      font-family: ""Open Sans"", sans-serif;
                      font-size: 16px;
                      letter-spacing: 2px;
                      text-decoration: none;
                      text-transform: uppercase;
                      color: #000;
                      cursor: pointer;
                      border: 3px solid;
                      padding: 0.25em 0.5em;
                      box-shadow: 1px 1px 0px 0px, 2px 2px 0px 0px, 3px 3px 0px 0px, 4px 4px 0px 0px, 5px 5px 0px 0px;
                      position: relative;
                      user-select: none;
                      -webkit-user-select: none;
                      touch-action: manipulation;
                }
            </style>

            ");
            __builder.OpenElement(18, "body");
            __builder.AddAttribute(19, "class", "w3-content");
            __builder.AddAttribute(20, "style", "max-width: 100%");
            __builder.AddAttribute(21, "b-ajb5ewb1of");
            __builder.AddMarkupContent(22, @"<header class=""w3-bar w3-top w3-hide-large w3-black w3-xlarge"" b-ajb5ewb1of><div class=""w3-bar-item w3-padding-24 w3-wide"" b-ajb5ewb1of>LOGO</div>
                    <a href=""javascript:void(0)"" class=""w3-bar-item w3-button w3-padding-24 w3-right"" onclick=""w3_open()"" b-ajb5ewb1of><i class=""fa fa-bars"" b-ajb5ewb1of></i></a></header>

                
                <div class=""w3-overlay w3-hide-large"" onclick=""w3_close()"" style=""cursor:pointer"" title=""close side menu"" id=""myOverlay"" b-ajb5ewb1of></div>

                
                ");
            __builder.OpenElement(23, "div");
            __builder.AddAttribute(24, "class", "w3-main");
            __builder.AddAttribute(25, "style", "margin-left:250px");
            __builder.AddAttribute(26, "b-ajb5ewb1of");
            __builder.AddMarkupContent(27, "<div class=\"w3-hide-large\" style=\"margin-top:83px\" b-ajb5ewb1of></div>\r\n\r\n                    \r\n                    ");
            __builder.OpenElement(28, "header");
            __builder.AddAttribute(29, "class", "w3-container w3-xlarge");
            __builder.AddAttribute(30, "b-ajb5ewb1of");
            __builder.AddMarkupContent(31, "<a class=\"w3-left\" href b-ajb5ewb1of></a>\r\n                        ");
            __builder.OpenElement(32, "p");
            __builder.AddAttribute(33, "class", "w3-right");
            __builder.AddAttribute(34, "b-ajb5ewb1of");
#nullable restore
#line 69 "C:\Users\runef\Source\Repos\p3-project\Project\Shared\MainLayout.razor"
                             if (isLoaded)
                            {

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(35, @"<div class=""admin_kpi_btns"" b-ajb5ewb1of><a class=""buttright"" href=""Admin"" b-ajb5ewb1of>Admin</a>
                                <a class=""buttright"" href=""Admin2"" b-ajb5ewb1of>Admin2</a>
                                <a class=""buttright"" href=""Kpi"" b-ajb5ewb1of>Kpi</a></div>");
#nullable restore
#line 76 "C:\Users\runef\Source\Repos\p3-project\Project\Shared\MainLayout.razor"
                            }

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(36, "<a class=\"w3-button\" href=\"Cart\" b-ajb5ewb1of><i class=\"fa fa-shopping-cart w3-margin-right\" b-ajb5ewb1of> Cart </i></a>\r\n                            <i class=\"fa fa-search\" b-ajb5ewb1of></i>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\r\n\r\n                    ");
            __builder.AddContent(38, 
#nullable restore
#line 82 "C:\Users\runef\Source\Repos\p3-project\Project\Shared\MainLayout.razor"
                     Body

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(39, "\r\n\r\n                    ");
            __builder.AddMarkupContent(40, "<footer class=\"w3-padding-64 w3-light-grey w3-small w3-center\" id=\"footer\" b-ajb5ewb1of><div class=\"w3-row-padding\" b-ajb5ewb1of><div class=\"w3-col s4 w3-center\" b-ajb5ewb1of><h4 b-ajb5ewb1of>About</h4>\r\n                                I dag er alt t??j indfarvet med kemi, uanset om stoffet er ??kologisk eller ej. Samtidig anvendes der betydelige m??ngder vand ved indfarvningen (100L vand pr. 1 kg. Stof bare ved indfarvning), fordi t??jet skal skylles igennem for kemikalier. Det betyder, at brugeren bliver udsat for kemi, n??r t??jet anvendes, og producenterne spilder store dele af naturens vandressourcer.\r\n                                Derfor vil vi i elemental levere kemifrie produkter til familier, der ??nsker, at deres babyer/b??rn skal g?? i t??j, der ikke uds??tter deres b??rn for kemi og samtidig er produceret med naturens ressourcer.\r\n                                Alle vores produkter er indfarvet uden kemi og er derfor et reelt ??kologisk alternativ, s?? du ikke uds??tter dit barn for kemi. Derfor sker design og produktion p?? jordens pr??misser.\r\n                                Vores naturlige indfarvning sker med restprodukter fra f??devareproduktion (skal fra granat??bler, citronblade, olivenblade, lavendel) og et ler-mineral, som f??r det naturlige farvestof til at binde til metervaren mindst lige s?? godt som ved traditionelle kemiske farvestoffer. Dette resulterer i 80% mindre vandforbrug og 50% mindre energiforbrug i farveprocessen, fordi vi ikke skal bruge energi p?? at skylle kemi ud af produktet for at komme under EU???s max krav til kemiindhold i tekstiler.\r\n                            </div>\r\n\r\n                            <div class=\"w3-col s4 w3-right\" b-ajb5ewb1of><h4 b-ajb5ewb1of>Store</h4>\r\n                                <p b-ajb5ewb1of><i class=\"fa fa-fw fa-map-marker\" b-ajb5ewb1of></i> Company Name</p>\r\n                                <p b-ajb5ewb1of><i class=\"fa fa-fw fa-phone\" b-ajb5ewb1of></i> 0044123123</p>\r\n                                <p b-ajb5ewb1of><i class=\"fa fa-fw fa-envelope\" b-ajb5ewb1of></i> ex@mail.com</p></div></div></footer>\r\n                    ");
            __builder.AddMarkupContent(41, "<div class=\"w3-black w3-center w3-padding-24\" b-ajb5ewb1of><a class=\"w3-hover-opacity\" b-ajb5ewb1of>Powered by Esben</a></div>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 114 "C:\Users\runef\Source\Repos\p3-project\Project\Shared\MainLayout.razor"
 
    public string AccessToken = null;

    bool isLoaded;

    public async Task Read()
    {
        var AccessTokenSession = await SessionStorage.GetAsync<string>("UserName");
        AccessToken = AccessTokenSession.Value;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        LayoutCode layout = new LayoutCode();

        await Read();
        if (layout.DataBaseVerify(AccessToken))
        {
            isLoaded = true;
        }
        StateHasChanged();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ProtectedSessionStorage SessionStorage { get; set; }
    }
}
#pragma warning restore 1591
