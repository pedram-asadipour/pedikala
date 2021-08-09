#pragma checksum "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ebe25540ae863c091b1b50029632b74185d00393"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Areas.Admin.Pages.Shop.Product.Areas_Admin_Pages_Shop_Product_List), @"mvc.1.0.view", @"/Areas/Admin/Pages/Shop/Product/List.cshtml")]
namespace ServiceHost.Areas.Admin.Pages.Shop.Product
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ebe25540ae863c091b1b50029632b74185d00393", @"/Areas/Admin/Pages/Shop/Product/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb4fc8b75927fcfb39346331739cf96934a9c24b", @"/Areas/Admin/Pages/_ViewImports.cshtml")]
    public class Areas_Admin_Pages_Shop_Product_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ShopManagement.Application.Contract.Product.ProductViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 80px; height: 100px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div class=""row"">
    <div class=""col-md-12"">
        <div class=""panel panel-default"">
            <div class=""panel-heading"">
                <h3 class=""panel-title"">لیست گروه محصولات</h3>
            </div>
            <div class=""panel-body"">
                <div class=""row"">
                    <div class=""col-md-12 col-sm-12 col-xs-12 text-center table-responsive"">
                        <table id=""datatable"" class=""table table-striped table-bordered "">
                            <thead>
                            <tr>
                                <th>#</th>
                                <th>تصویر محصول</th>
                                <th>نام</th>
                                <th>کد</th>
                                <th>گروه محصول</th>
                                <th>وضعیت محصول</th>
                                <th>تاریخ ایجاد</th>
                                <th>عملیات</th>
                            </tr>
                            </thead>

");
            WriteLiteral("\r\n                            <tbody>\r\n");
#nullable restore
#line 29 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 32 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ebe25540ae863c091b1b50029632b74185d003935180", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1412, "~/Uploads/", 1412, 10, true);
#nullable restore
#line 34 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
AddHtmlAttributeValue("", 1422, item.Image, 1422, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 34 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
AddHtmlAttributeValue("", 1475, item.Name, 1475, 10, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>");
#nullable restore
#line 36 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 37 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                                   Write(item.ProductCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 38 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                                   Write(item.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n");
#nullable restore
#line 40 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                                         if (item.IsRemoved)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <i class=\"md md-close text-danger\"></i>\r\n                                            <span>غیر فعال</span>\r\n");
#nullable restore
#line 44 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <i class=\"md md-check text-success\"></i>\r\n                                            <span>فعال</span>\r\n");
#nullable restore
#line 49 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </td>\r\n                                    <td>");
#nullable restore
#line 51 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                                   Write(item.CreationDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n                                        <a");
            BeginWriteAttribute("href", " href=\"", 2534, "\"", 2600, 2);
            WriteAttributeValue("", 2541, "#showmodal=", 2541, 11, true);
#nullable restore
#line 53 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
WriteAttributeValue("", 2552, Url.Page("./Index", "Edit", new {id = item.Id}), 2552, 48, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-warning waves-effect waves-light\">ویرایش <i class=\"md md-edit\"></i></a>\r\n\r\n");
#nullable restore
#line 55 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                                         if (item.IsRemoved)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <a");
            BeginWriteAttribute("href", " href=\"", 2843, "\"", 2912, 2);
            WriteAttributeValue("", 2850, "#operation=", 2850, 11, true);
#nullable restore
#line 57 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
WriteAttributeValue("", 2861, Url.Page("./Index", "Restore", new {id = item.Id}), 2861, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success waves-effect waves-light\">فعال <i class=\"md md-check\"></i></a>\r\n");
#nullable restore
#line 58 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <a");
            BeginWriteAttribute("href", " href=\"", 3179, "\"", 3248, 2);
            WriteAttributeValue("", 3186, "#operation=", 3186, 11, true);
#nullable restore
#line 61 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
WriteAttributeValue("", 3197, Url.Page("./Index", "Removed", new {id = item.Id}), 3197, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger waves-effect waves-light\">غیر فعال <i class=\"md md-close\"></i></a>\r\n");
#nullable restore
#line 62 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 65 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ShopManagement.Application.Contract.Product.ProductViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591