#pragma checksum "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Components\CountProductComment\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2478723a8d50063aa84209e5ca9c1e3ce8c61b9b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Areas.Admin.Pages.Components.CountProductComment.Areas_Admin_Pages_Components_CountProductComment_Default), @"mvc.1.0.view", @"/Areas/Admin/Pages/Components/CountProductComment/Default.cshtml")]
namespace ServiceHost.Areas.Admin.Pages.Components.CountProductComment
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2478723a8d50063aa84209e5ca9c1e3ce8c61b9b", @"/Areas/Admin/Pages/Components/CountProductComment/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb4fc8b75927fcfb39346331739cf96934a9c24b", @"/Areas/Admin/Pages/_ViewImports.cshtml")]
    public class Areas_Admin_Pages_Components_CountProductComment_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Components\CountProductComment\Default.cshtml"
 if (Model > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <span class=\"badge badge-danger\">");
#nullable restore
#line 5 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Components\CountProductComment\Default.cshtml"
                                Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 6 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Components\CountProductComment\Default.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591
