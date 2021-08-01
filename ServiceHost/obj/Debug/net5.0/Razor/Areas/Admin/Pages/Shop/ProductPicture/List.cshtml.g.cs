#pragma checksum "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\ProductPicture\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a183d25f4ef5a1fa3d4b225653876f49a1e8924f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Areas.Admin.Pages.Shop.ProductPicture.Areas_Admin_Pages_Shop_ProductPicture_List), @"mvc.1.0.view", @"/Areas/Admin/Pages/Shop/ProductPicture/List.cshtml")]
namespace ServiceHost.Areas.Admin.Pages.Shop.ProductPicture
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a183d25f4ef5a1fa3d4b225653876f49a1e8924f", @"/Areas/Admin/Pages/Shop/ProductPicture/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb4fc8b75927fcfb39346331739cf96934a9c24b", @"/Areas/Admin/Pages/_ViewImports.cshtml")]
    public class Areas_Admin_Pages_Shop_ProductPicture_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ShopManagement.Application.Contract.ProductPicture.ProductPictureViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"



<div class=""row"">
    <div class=""col-md-12"">
        <div class=""panel panel-default"">
            <div class=""panel-heading"">
                <h3 class=""panel-title"">لیست تصاویر محصولات</h3>
            </div>
            <div class=""panel-body"">
                <div class=""row"">
                    <div class=""col-md-12 col-sm-12 col-xs-12 text-center table-responsive"">
                        <table id=""datatable"" class=""table table-striped table-bordered "">
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>تصویر محصول</th>
                                    <th>نام محصول</th>
                                    <th>وضعیت تصویر</th>
                                    <th>تاریخ ایجاد</th>
                                    <th>عملیات</th>
                                </tr>
                            </thead>


                            <tbody>
");
#nullable restore
#line 29 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\ProductPicture\List.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 32 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\ProductPicture\List.cshtml"
                                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n                                        <img");
            BeginWriteAttribute("src", " src=\"", 1366, "\"", 1383, 1);
#nullable restore
#line 34 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\ProductPicture\List.cshtml"
WriteAttributeValue("", 1372, item.Image, 1372, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width: 80px; height: 80px\"");
            BeginWriteAttribute("alt", " alt=\"", 1418, "\"", 1441, 1);
#nullable restore
#line 34 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\ProductPicture\List.cshtml"
WriteAttributeValue("", 1424, item.ProductName, 1424, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/></td>\r\n                                    <td>");
#nullable restore
#line 35 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\ProductPicture\List.cshtml"
                                   Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n");
#nullable restore
#line 37 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\ProductPicture\List.cshtml"
                                         if (item.IsRemoved)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <span><i class=\"md md-clear text-danger\"></i>غیر فعال</span>\r\n");
#nullable restore
#line 40 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\ProductPicture\List.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <span><i class=\"md md-check text-success\"></i>فعال</span>\r\n");
#nullable restore
#line 44 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\ProductPicture\List.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </td>\r\n                                    <td>");
#nullable restore
#line 46 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\ProductPicture\List.cshtml"
                                   Write(item.CreationDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n                                        <a");
            BeginWriteAttribute("href", " href=\"", 2238, "\"", 2304, 2);
            WriteAttributeValue("", 2245, "#showmodal=", 2245, 11, true);
#nullable restore
#line 48 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\ProductPicture\List.cshtml"
WriteAttributeValue("", 2256, Url.Page("./Index", "Edit", new {id = item.Id}), 2256, 48, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-warning waves-effect waves-light\">ویرایش <i class=\"md md-edit\"></i></a>\r\n\r\n");
#nullable restore
#line 50 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\ProductPicture\List.cshtml"
                                         if (item.IsRemoved)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a");
            BeginWriteAttribute("href", " href=\"", 2539, "\"", 2608, 2);
            WriteAttributeValue("", 2546, "#operation=", 2546, 11, true);
#nullable restore
#line 52 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\ProductPicture\List.cshtml"
WriteAttributeValue("", 2557, Url.Page("./Index", "Restore", new {id = item.Id}), 2557, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success waves-effect waves-light\">فعال <i class=\"md md-check\"></i></a>\r\n");
#nullable restore
#line 53 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\ProductPicture\List.cshtml"

                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a");
            BeginWriteAttribute("href", " href=\"", 2869, "\"", 2938, 2);
            WriteAttributeValue("", 2876, "#operation=", 2876, 11, true);
#nullable restore
#line 57 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\ProductPicture\List.cshtml"
WriteAttributeValue("", 2887, Url.Page("./Index", "Removed", new {id = item.Id}), 2887, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger waves-effect waves-light\">غیر فعال <i class=\"md md-close\"></i></a>\r\n");
#nullable restore
#line 58 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\ProductPicture\List.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 62 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Areas\Admin\Pages\Shop\ProductPicture\List.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ShopManagement.Application.Contract.ProductPicture.ProductPictureViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
