#pragma checksum "C:\Users\pedram\Desktop\pedram\source\pedikala\ServiceHost\Areas\Admin\Pages\Inventory\OperationLog.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93945718d2a84e647a3152396c213d5a16ed9e4a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Areas.Admin.Pages.Inventory.Areas_Admin_Pages_Inventory_OperationLog), @"mvc.1.0.view", @"/Areas/Admin/Pages/Inventory/OperationLog.cshtml")]
namespace ServiceHost.Areas.Admin.Pages.Inventory
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93945718d2a84e647a3152396c213d5a16ed9e4a", @"/Areas/Admin/Pages/Inventory/OperationLog.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb4fc8b75927fcfb39346331739cf96934a9c24b", @"/Areas/Admin/Pages/_ViewImports.cshtml")]
    public class Areas_Admin_Pages_Inventory_OperationLog : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<InventoryManagement.Application.Contract.Inventory.InventoryOperationViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"modal-header\">\r\n    <button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-hidden=\"true\">×</button>\r\n    <h4 class=\"modal-title\">لیست گردش انبار (");
#nullable restore
#line 5 "C:\Users\pedram\Desktop\pedram\source\pedikala\ServiceHost\Areas\Admin\Pages\Inventory\OperationLog.cshtml"
                                        Write(Model.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(@")</h4>
</div>
<div class=""row"">
    <div class=""col-md-12"">
        <div class=""panel panel-default"">
            <div class=""panel-body"">
                <div class=""row"">
                    <div class=""col-md-12 col-sm-12 col-xs-12 text-center table-responsive"">
                        <table class=""table table-bordered "">
                            <thead>
                            <tr>
                                <th>#</th>
                                <th>نوع گردش</th>
                                <th>تعداد</th>
                                <th>نام اپراتور</th>
                                <th>موچودی انبار در زمان گردش</th>
                                <th>توضیحات</th>
                                <th>تاریخ گردش</th>
                            </tr>
                            </thead>

                            <tbody>
");
#nullable restore
#line 27 "C:\Users\pedram\Desktop\pedram\source\pedikala\ServiceHost\Areas\Admin\Pages\Inventory\OperationLog.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr");
            BeginWriteAttribute("class", " class=\"", 1284, "\"", 1342, 1);
#nullable restore
#line 29 "C:\Users\pedram\Desktop\pedram\source\pedikala\ServiceHost\Areas\Admin\Pages\Inventory\OperationLog.cshtml"
WriteAttributeValue("", 1292, item.OperationType ? "bg-success" : "bg-danger", 1292, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <td>");
#nullable restore
#line 30 "C:\Users\pedram\Desktop\pedram\source\pedikala\ServiceHost\Areas\Admin\Pages\Inventory\OperationLog.cshtml"
                                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 31 "C:\Users\pedram\Desktop\pedram\source\pedikala\ServiceHost\Areas\Admin\Pages\Inventory\OperationLog.cshtml"
                                    Write(item.OperationType ? "افزایش" : "کاهش");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 32 "C:\Users\pedram\Desktop\pedram\source\pedikala\ServiceHost\Areas\Admin\Pages\Inventory\OperationLog.cshtml"
                                   Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 33 "C:\Users\pedram\Desktop\pedram\source\pedikala\ServiceHost\Areas\Admin\Pages\Inventory\OperationLog.cshtml"
                                   Write(item.OperatorName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 34 "C:\Users\pedram\Desktop\pedram\source\pedikala\ServiceHost\Areas\Admin\Pages\Inventory\OperationLog.cshtml"
                                   Write(item.CurrentCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 35 "C:\Users\pedram\Desktop\pedram\source\pedikala\ServiceHost\Areas\Admin\Pages\Inventory\OperationLog.cshtml"
                                   Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 36 "C:\Users\pedram\Desktop\pedram\source\pedikala\ServiceHost\Areas\Admin\Pages\Inventory\OperationLog.cshtml"
                                   Write(item.OperationDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 38 "C:\Users\pedram\Desktop\pedram\source\pedikala\ServiceHost\Areas\Admin\Pages\Inventory\OperationLog.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </tbody>
                        </table>

                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<div class=""modal-footer"">
    <button type=""button"" class=""btn btn-default waves-effect"" data-dismiss=""modal"">بستن</button>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<InventoryManagement.Application.Contract.Inventory.InventoryOperationViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
