#pragma checksum "C:\MyStuff\Projects\AppDev-master\AppDev-master\NeoStore\NeoStore\Views\Report\ProductNotSoldViewModelReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "18db36404ddd98bca2d4012ad924f3bfbd1491f2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_ProductNotSoldViewModelReport), @"mvc.1.0.view", @"/Views/Report/ProductNotSoldViewModelReport.cshtml")]
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
#nullable restore
#line 1 "C:\MyStuff\Projects\AppDev-master\AppDev-master\NeoStore\NeoStore\Views\_ViewImports.cshtml"
using NeoStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\MyStuff\Projects\AppDev-master\AppDev-master\NeoStore\NeoStore\Views\_ViewImports.cshtml"
using NeoStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18db36404ddd98bca2d4012ad924f3bfbd1491f2", @"/Views/Report/ProductNotSoldViewModelReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20f8fa70cb662d43095918d8f35705e82ec25e2c", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_ProductNotSoldViewModelReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<NeoStore.ViewModels.ProductNotSoldViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\MyStuff\Projects\AppDev-master\AppDev-master\NeoStore\NeoStore\Views\Report\ProductNotSoldViewModelReport.cshtml"
  
    ViewData["Title"] = "Product Not Sold";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>Product Not Sold List (Last 30 Days)</h1>\n<table class=\"table\">\n    <thead>\n        <tr>\n            <th>\n                ");
#nullable restore
#line 12 "C:\MyStuff\Projects\AppDev-master\AppDev-master\NeoStore\NeoStore\Views\Report\ProductNotSoldViewModelReport.cshtml"
           Write(Html.DisplayNameFor(model => model.ProductId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 15 "C:\MyStuff\Projects\AppDev-master\AppDev-master\NeoStore\NeoStore\Views\Report\ProductNotSoldViewModelReport.cshtml"
           Write(Html.DisplayNameFor(model => model.ProductCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 18 "C:\MyStuff\Projects\AppDev-master\AppDev-master\NeoStore\NeoStore\Views\Report\ProductNotSoldViewModelReport.cshtml"
           Write(Html.DisplayNameFor(model => model.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 21 "C:\MyStuff\Projects\AppDev-master\AppDev-master\NeoStore\NeoStore\Views\Report\ProductNotSoldViewModelReport.cshtml"
           Write(Html.DisplayNameFor(model => model.AvailableStock));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n            <th>\n                ");
#nullable restore
#line 24 "C:\MyStuff\Projects\AppDev-master\AppDev-master\NeoStore\NeoStore\Views\Report\ProductNotSoldViewModelReport.cshtml"
           Write(Html.DisplayNameFor(model => model.ProductCategory));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </th>\n        </tr>\n    </thead>\n    <tbody>\n");
#nullable restore
#line 29 "C:\MyStuff\Projects\AppDev-master\AppDev-master\NeoStore\NeoStore\Views\Report\ProductNotSoldViewModelReport.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <td>\n                ");
#nullable restore
#line 33 "C:\MyStuff\Projects\AppDev-master\AppDev-master\NeoStore\NeoStore\Views\Report\ProductNotSoldViewModelReport.cshtml"
           Write(Html.DisplayFor(modelItem => item.ProductId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 36 "C:\MyStuff\Projects\AppDev-master\AppDev-master\NeoStore\NeoStore\Views\Report\ProductNotSoldViewModelReport.cshtml"
           Write(Html.DisplayFor(modelItem => item.ProductCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 39 "C:\MyStuff\Projects\AppDev-master\AppDev-master\NeoStore\NeoStore\Views\Report\ProductNotSoldViewModelReport.cshtml"
           Write(Html.DisplayFor(modelItem => item.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 42 "C:\MyStuff\Projects\AppDev-master\AppDev-master\NeoStore\NeoStore\Views\Report\ProductNotSoldViewModelReport.cshtml"
           Write(Html.DisplayFor(modelItem => item.AvailableStock));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n            <td>\n                ");
#nullable restore
#line 45 "C:\MyStuff\Projects\AppDev-master\AppDev-master\NeoStore\NeoStore\Views\Report\ProductNotSoldViewModelReport.cshtml"
           Write(Html.DisplayFor(modelItem => item.ProductCategory));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </td>\n        </tr>\n");
#nullable restore
#line 48 "C:\MyStuff\Projects\AppDev-master\AppDev-master\NeoStore\NeoStore\Views\Report\ProductNotSoldViewModelReport.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\n</table>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<NeoStore.ViewModels.ProductNotSoldViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
