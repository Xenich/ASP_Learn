#pragma checksum "D:\Projects\GoogleDrive\Programming\C#\ASPNet\ASPNET_Core_MVC_MODELS\ASPNET_Core_MVC_MODELS\Views\HtmlHelper\HTMLHelperSelect.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "68c9dede0a0ba9d2dc95805729c6a15150ef9f25"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_HtmlHelper_HTMLHelperSelect), @"mvc.1.0.view", @"/Views/HtmlHelper/HTMLHelperSelect.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/HtmlHelper/HTMLHelperSelect.cshtml", typeof(AspNetCore.Views_HtmlHelper_HTMLHelperSelect))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\Projects\GoogleDrive\Programming\C#\ASPNet\ASPNET_Core_MVC_MODELS\ASPNET_Core_MVC_MODELS\Views\_ViewImports.cshtml"
using ASPNET_Core_MVC_MODELS;

#line default
#line hidden
#line 2 "D:\Projects\GoogleDrive\Programming\C#\ASPNet\ASPNET_Core_MVC_MODELS\ASPNET_Core_MVC_MODELS\Views\_ViewImports.cshtml"
using ASPNET_Core_MVC_MODELS.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68c9dede0a0ba9d2dc95805729c6a15150ef9f25", @"/Views/HtmlHelper/HTMLHelperSelect.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"132d8b637d3b63d02c9724397904fb10c991b27b", @"/Views/_ViewImports.cshtml")]
    public class Views_HtmlHelper_HTMLHelperSelect : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\Projects\GoogleDrive\Programming\C#\ASPNet\ASPNET_Core_MVC_MODELS\ASPNET_Core_MVC_MODELS\Views\HtmlHelper\HTMLHelperSelect.cshtml"
  
    Layout = "~/Views/Shared/_MyLayout.cshtml";
    ViewData["Title"] = "HTMLHelperSelect";

#line default
#line hidden
            BeginContext(103, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 8 "D:\Projects\GoogleDrive\Programming\C#\ASPNet\ASPNET_Core_MVC_MODELS\ASPNET_Core_MVC_MODELS\Views\HtmlHelper\HTMLHelperSelect.cshtml"
 using (Html.BeginForm("HTMLHelperSelect", "HtmlHelper", FormMethod.Post))
{

#line default
#line hidden
            BeginContext(290, 19, true);
            WriteLiteral("    <p>\r\n\r\n        ");
            EndContext();
            BeginContext(310, 60, false);
#line 12 "D:\Projects\GoogleDrive\Programming\C#\ASPNet\ASPNET_Core_MVC_MODELS\ASPNET_Core_MVC_MODELS\Views\HtmlHelper\HTMLHelperSelect.cshtml"
   Write(Html.Label("select", "Выпадающий список созданный на месте"));

#line default
#line hidden
            EndContext();
            BeginContext(370, 16, true);
            WriteLiteral("<br />\r\n        ");
            EndContext();
            BeginContext(387, 113, false);
#line 13 "D:\Projects\GoogleDrive\Programming\C#\ASPNet\ASPNET_Core_MVC_MODELS\ASPNET_Core_MVC_MODELS\Views\HtmlHelper\HTMLHelperSelect.cshtml"
   Write(Html.DropDownList("User", new SelectList(new string[] { "Tom", "Sam", "Bob", "Alice" }), "Выберите пользователя"));

#line default
#line hidden
            EndContext();
            BeginContext(500, 6, true);
            WriteLiteral("      ");
            EndContext();
            BeginContext(651, 32, true);
            WriteLiteral("\r\n        <br /><br />\r\n        ");
            EndContext();
            BeginContext(684, 93, false);
#line 15 "D:\Projects\GoogleDrive\Programming\C#\ASPNet\ASPNET_Core_MVC_MODELS\ASPNET_Core_MVC_MODELS\Views\HtmlHelper\HTMLHelperSelect.cshtml"
   Write(Html.Label("select1", "Выпадающий список с коллекцией, переданной из контроллера во ViewBag"));

#line default
#line hidden
            EndContext();
            BeginContext(777, 16, true);
            WriteLiteral("<br />\r\n        ");
            EndContext();
            BeginContext(794, 58, false);
#line 16 "D:\Projects\GoogleDrive\Programming\C#\ASPNet\ASPNET_Core_MVC_MODELS\ASPNET_Core_MVC_MODELS\Views\HtmlHelper\HTMLHelperSelect.cshtml"
   Write(Html.DropDownList("newUsers", ViewBag.Users as SelectList));

#line default
#line hidden
            EndContext();
            BeginContext(852, 6, true);
            WriteLiteral("      ");
            EndContext();
            BeginContext(1116, 34, true);
            WriteLiteral("\r\n\r\n        <br /><br />\r\n        ");
            EndContext();
            BeginContext(1151, 73, false);
#line 20 "D:\Projects\GoogleDrive\Programming\C#\ASPNet\ASPNET_Core_MVC_MODELS\ASPNET_Core_MVC_MODELS\Views\HtmlHelper\HTMLHelperSelect.cshtml"
   Write(Html.Label("select2", "ListBox с той же самой коллекцией из контроллера"));

#line default
#line hidden
            EndContext();
            BeginContext(1224, 15, true);
            WriteLiteral("<br />         ");
            EndContext();
            BeginContext(1348, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(1359, 59, false);
#line 21 "D:\Projects\GoogleDrive\Programming\C#\ASPNet\ASPNET_Core_MVC_MODELS\ASPNET_Core_MVC_MODELS\Views\HtmlHelper\HTMLHelperSelect.cshtml"
   Write(Html.ListBox("ListUsers", ViewBag.Users as MultiSelectList));

#line default
#line hidden
            EndContext();
            BeginContext(1418, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(1451, 32, true);
            WriteLiteral("\r\n        <br /><br />\r\n        ");
            EndContext();
            BeginContext(1484, 75, false);
#line 23 "D:\Projects\GoogleDrive\Programming\C#\ASPNet\ASPNET_Core_MVC_MODELS\ASPNET_Core_MVC_MODELS\Views\HtmlHelper\HTMLHelperSelect.cshtml"
   Write(Html.Label("select2", "Создание выпадающего списка на основе перечисления"));

#line default
#line hidden
            EndContext();
            BeginContext(1559, 12, true);
            WriteLiteral("<br />      ");
            EndContext();
            BeginContext(1648, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(1659, 71, false);
#line 24 "D:\Projects\GoogleDrive\Programming\C#\ASPNet\ASPNET_Core_MVC_MODELS\ASPNET_Core_MVC_MODELS\Views\HtmlHelper\HTMLHelperSelect.cshtml"
   Write(Html.DropDownList("daytime", Html.GetEnumSelectList(typeof(TimeOfDay))));

#line default
#line hidden
            EndContext();
            BeginContext(1730, 95, true);
            WriteLiteral("\r\n        <br />\r\n        <input type=\"submit\" value=\"Отправить\" />\r\n        <br />\r\n    </p>\r\n");
            EndContext();
#line 29 "D:\Projects\GoogleDrive\Programming\C#\ASPNet\ASPNET_Core_MVC_MODELS\ASPNET_Core_MVC_MODELS\Views\HtmlHelper\HTMLHelperSelect.cshtml"
}

#line default
#line hidden
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
