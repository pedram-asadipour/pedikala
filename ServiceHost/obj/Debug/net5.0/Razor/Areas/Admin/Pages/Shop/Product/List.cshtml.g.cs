#pragma checksum "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ca4443fd10573db61a37284a79e0943dc2be3afd"
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
#nullable restore
#line 1 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
using ShopManagement.Configuration.Permission;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca4443fd10573db61a37284a79e0943dc2be3afd", @"/Areas/Admin/Pages/Shop/Product/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6770203410d7709f9602a165c2446643bb4837f", @"/Areas/Admin/Pages/_ViewImports.cshtml")]
    public class Areas_Admin_Pages_Shop_Product_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ShopManagement.Application.Contract.Product.ProductViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/MainTheme/img/empty.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 7rem;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("empty"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 10rem;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning waves-effect waves-light"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("row"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::ServiceHost.Framework.PermissionTagHelper __ServiceHost_Framework_PermissionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ca4443fd10573db61a37284a79e0943dc2be3afd5429", async() => {
                WriteLiteral(@"
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
                WriteLiteral("         <tbody>\r\n");
#nullable restore
#line 30 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 33 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                                   Write(item.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                    <td>\r\n");
#nullable restore
#line 35 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                                         if (string.IsNullOrWhiteSpace(item.Image))
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ca4443fd10573db61a37284a79e0943dc2be3afd7868", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 38 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ca4443fd10573db61a37284a79e0943dc2be3afd9518", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 1880, "~/Uploads/", 1880, 10, true);
#nullable restore
#line 41 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
AddHtmlAttributeValue("", 1890, item.Image, 1890, 11, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 41 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
AddHtmlAttributeValue("", 1930, item.Name, 1930, 10, false);

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
                WriteLiteral("\r\n");
#nullable restore
#line 42 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    </td>\r\n                                    <td>");
#nullable restore
#line 44 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                                   Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                    <td class=\"ltr\">");
#nullable restore
#line 45 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                                               Write(item.ProductCode);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 46 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                                   Write(item.CategoryName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                    <td>\r\n");
#nullable restore
#line 48 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                                         if (item.IsRemoved)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <i class=\"md md-close text-danger\"></i>\r\n                                            <span>غیر فعال</span>\r\n");
#nullable restore
#line 52 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <i class=\"md md-check text-success\"></i>\r\n                                            <span>فعال</span>\r\n");
#nullable restore
#line 57 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    </td>\r\n                                    <td>");
#nullable restore
#line 59 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                                   Write(item.CreationDate);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                    <td>\r\n                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ca4443fd10573db61a37284a79e0943dc2be3afd14678", async() => {
                    WriteLiteral("ویرایش <i class=\"md md-edit\"></i>");
                }
                );
                __ServiceHost_Framework_PermissionTagHelper = CreateTagHelper<global::ServiceHost.Framework.PermissionTagHelper>();
                __tagHelperExecutionContext.Add(__ServiceHost_Framework_PermissionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 61 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                                           WriteLiteral(ShopPermissions.EditProduct);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __ServiceHost_Framework_PermissionTagHelper.Permission = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("permission", __ServiceHost_Framework_PermissionTagHelper.Permission, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 3138, "#showmodal=", 3138, 11, true);
#nullable restore
#line 62 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
AddHtmlAttributeValue("", 3149, Url.Page("./Index", "Edit", new {id = item.Id}), 3149, 48, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ca4443fd10573db61a37284a79e0943dc2be3afd17140", async() => {
                    WriteLiteral("\r\n");
#nullable restore
#line 65 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                                             if (item.IsRemoved)
                                            {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                                <a");
                    BeginWriteAttribute("href", " href=\"", 3551, "\"", 3620, 2);
                    WriteAttributeValue("", 3558, "#operation=", 3558, 11, true);
#nullable restore
#line 67 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
WriteAttributeValue("", 3569, Url.Page("./Index", "Restore", new {id = item.Id}), 3569, 51, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" class=\"btn btn-success waves-effect waves-light\">فعال <i class=\"md md-check\"></i></a>\r\n");
#nullable restore
#line 68 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                                <a");
                    BeginWriteAttribute("href", " href=\"", 3903, "\"", 3972, 2);
                    WriteAttributeValue("", 3910, "#operation=", 3910, 11, true);
#nullable restore
#line 71 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
WriteAttributeValue("", 3921, Url.Page("./Index", "Removed", new {id = item.Id}), 3921, 51, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" class=\"btn btn-danger waves-effect waves-light\">غیر فعال <i class=\"md md-close\"></i></a>\r\n");
#nullable restore
#line 72 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                                            }

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                        ");
                }
                );
                __ServiceHost_Framework_PermissionTagHelper = CreateTagHelper<global::ServiceHost.Framework.PermissionTagHelper>();
                __tagHelperExecutionContext.Add(__ServiceHost_Framework_PermissionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 64 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                                              WriteLiteral(ShopPermissions.RemoveRestoreProduct);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __ServiceHost_Framework_PermissionTagHelper.Permission = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("permission", __ServiceHost_Framework_PermissionTagHelper.Permission, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 76 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            </tbody>\r\n                        </table>\r\n\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n");
            }
            );
            __ServiceHost_Framework_PermissionTagHelper = CreateTagHelper<global::ServiceHost.Framework.PermissionTagHelper>();
            __tagHelperExecutionContext.Add(__ServiceHost_Framework_PermissionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 5 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Shop\Product\List.cshtml"
                 WriteLiteral(ShopPermissions.Product);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __ServiceHost_Framework_PermissionTagHelper.Permission = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("permission", __ServiceHost_Framework_PermissionTagHelper.Permission, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
