#pragma checksum "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Accounts\Role\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9e2460bb7db49c8c2277905e4705629bfdeb801"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Areas.Admin.Pages.Accounts.Role.Areas_Admin_Pages_Accounts_Role_List), @"mvc.1.0.view", @"/Areas/Admin/Pages/Accounts/Role/List.cshtml")]
namespace ServiceHost.Areas.Admin.Pages.Accounts.Role
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9e2460bb7db49c8c2277905e4705629bfdeb801", @"/Areas/Admin/Pages/Accounts/Role/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb4fc8b75927fcfb39346331739cf96934a9c24b", @"/Areas/Admin/Pages/_ViewImports.cshtml")]
    public class Areas_Admin_Pages_Accounts_Role_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<AccountManagement.Application.Contract.Role.RoleViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div class=""row"">
    <div class=""col-md-12"">
        <div class=""panel panel-default"">
            <div class=""panel-heading"">
                <h3 class=""panel-title"">لیست نقش کاربران</h3>
            </div>
            <div class=""panel-body"">
                <div class=""row"">
                    <div class=""col-md-12 col-sm-12 col-xs-12 text-center table-responsive"">
                        <table id=""datatable"" class=""table table-striped table-bordered "">
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>نقش کاربر</th>
                                    <th>تاریخ ایجاد</th>
                                    <th>عملیات</th>
                                </tr>
                            </thead>


                            <tbody>
");
#nullable restore
#line 25 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Accounts\Role\List.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 28 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Accounts\Role\List.cshtml"
                                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 29 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Accounts\Role\List.cshtml"
                                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 30 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Accounts\Role\List.cshtml"
                                   Write(item.CreationDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n                                        <a");
            BeginWriteAttribute("href", " href=\"", 1346, "\"", 1412, 2);
            WriteAttributeValue("", 1353, "#showmodal=", 1353, 11, true);
#nullable restore
#line 32 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Accounts\Role\List.cshtml"
WriteAttributeValue("", 1364, Url.Page("./Index", "Edit", new {id = item.Id}), 1364, 48, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-warning waves-effect waves-light\">ویرایش<i class=\"md md-edit\"></i></a>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 35 "C:\Users\pedram\Desktop\me\source\pedikala\ServiceHost\Areas\Admin\Pages\Accounts\Role\List.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<AccountManagement.Application.Contract.Role.RoleViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
