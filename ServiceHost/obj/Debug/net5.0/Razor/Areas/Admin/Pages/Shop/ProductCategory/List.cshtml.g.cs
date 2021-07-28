#pragma checksum "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\ProductCategory\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d52bb4de494a794925b48b63399b10dfeec4a95f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Areas.Admin.Pages.Shop.ProductCategory.Areas_Admin_Pages_Shop_ProductCategory_List), @"mvc.1.0.view", @"/Areas/Admin/Pages/Shop/ProductCategory/List.cshtml")]
namespace ServiceHost.Areas.Admin.Pages.Shop.ProductCategory
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d52bb4de494a794925b48b63399b10dfeec4a95f", @"/Areas/Admin/Pages/Shop/ProductCategory/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb4fc8b75927fcfb39346331739cf96934a9c24b", @"/Areas/Admin/Pages/_ViewImports.cshtml")]
    public class Areas_Admin_Pages_Shop_ProductCategory_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ShopManagement.Application.Contract.ProductCategory.ProductCategoryViewModel>>
    {
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
                        <table id=""datatable"" class=""table table-striped table-bordered"">
                            <thead>
                            <tr>
                                <th>#</th>
                                <th>نام</th>
                                <th>تصویر گروه</th>
                                <th>تاریخ ایجاد</th>
                                <th>عملیات</th>
                            </tr>
                            </thead>


                            <tbody>
");
#nullable restore
#line 26 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\ProductCategory\List.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 29 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\ProductCategory\List.cshtml"
                                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 30 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\ProductCategory\List.cshtml"
                                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td><img");
            BeginWriteAttribute("src", " src=\"", 1283, "\"", 1300, 1);
#nullable restore
#line 31 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\ProductCategory\List.cshtml"
WriteAttributeValue("", 1289, item.Image, 1289, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width: 80px;height: 80px\" /></td>\r\n                                    <td>");
#nullable restore
#line 32 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\ProductCategory\List.cshtml"
                                   Write(item.CreationDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n                                        <a");
            BeginWriteAttribute("href", " href=\"", 1493, "\"", 1557, 2);
            WriteAttributeValue("", 1500, "#showmodal=", 1500, 11, true);
#nullable restore
#line 34 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\ProductCategory\List.cshtml"
WriteAttributeValue("", 1511, Url.Page("./Index","Edit",new {id = item.Id}), 1511, 46, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-warning waves-effect waves-light\">ویرایش <i class=\"md md-edit\"></i></a>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 37 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\ProductCategory\List.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ShopManagement.Application.Contract.ProductCategory.ProductCategoryViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
