#pragma checksum "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9ec13c27ee0810052d1a0dac35c197bf97727ea1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Pages_Category), @"mvc.1.0.razor-page", @"/Pages/Category.cshtml")]
namespace ServiceHost.Pages
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
#line 2 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
using _01_Framework.Tools;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{id}/{slug}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9ec13c27ee0810052d1a0dac35c197bf97727ea1", @"/Pages/Category.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea6a6f18f052b762881d64e1e6bb1f85c600fea9", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Category : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("breadcrumb-img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/ProductDetail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Category", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
  
    ViewData["Title"] = "دسته بندی " + Model.Category.Name;
    ViewData["MetaDescription"] = Model.Category.MetaDescription;
    ViewData["KeyWord"] = Model.Category.Keyword;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"breadcrumb-area section-space--half\">\r\n    <div class=\"container wide\">\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-12\">\r\n                <div class=\"breadcrumb-wrapper\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9ec13c27ee0810052d1a0dac35c197bf97727ea15364", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 531, "~/Uploads/", 531, 10, true);
#nullable restore
#line 16 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
AddHtmlAttributeValue("", 541, Model.Category.Image, 541, 21, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 16 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
AddHtmlAttributeValue("", 569, Model.Category.ImageAlt, 569, 24, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "title", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 16 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
AddHtmlAttributeValue("", 602, Model.Category.ImageTitle, 602, 26, false);

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
            WriteLiteral("\r\n                    <div class=\"breadcrumb-content\">\r\n                        <h2 class=\"breadcrumb-content__title\">");
#nullable restore
#line 18 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                                         Write(Model.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                        <ul class=\"breadcrumb-content__page-map\">\r\n                            <li>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9ec13c27ee0810052d1a0dac35c197bf97727ea18428", async() => {
                WriteLiteral("صفحه اصلی");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </li>\r\n                            <li class=\"active\">");
#nullable restore
#line 23 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                          Write(Model.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<div class=""page-content-area"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""page-wrapper"">
                    <div class=""page-content-wrapper"">
                        <div class=""row"">
");
            WriteLiteral("\r\n                            <div class=\"col-lg-12\">\r\n                                <div class=\"shop-page-content\">\r\n\r\n                                    <div class=\"row shop-product-wrap grid three-column\">\r\n\r\n");
#nullable restore
#line 79 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                         foreach (var product in Model.Category.Products)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            <div class=""col-12 col-lg-4 col-md-4 col-sm-6"">
                                                <div class=""single-grid-product grid-view-product"">
                                                    <div class=""single-grid-product__image"">
                                                        <div class=""single-grid-product__label"">

");
#nullable restore
#line 86 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                                             if (product.HasDiscount && product.IsInStock)
                                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                <span class=\"sale\">");
#nullable restore
#line 88 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                                                              Write(product.DiscountRate);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</span>\r\n");
#nullable restore
#line 89 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 90 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                                             if (!product.IsInStock)
                                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                <span class=\"new\">ناموجود</span>\r\n");
#nullable restore
#line 93 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        </div>\r\n                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9ec13c27ee0810052d1a0dac35c197bf97727ea113167", async() => {
                WriteLiteral("\r\n                                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9ec13c27ee0810052d1a0dac35c197bf97727ea113483", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 5586, "~/Uploads/", 5586, 10, true);
#nullable restore
#line 99 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
AddHtmlAttributeValue("", 5596, product.Image, 5596, 14, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 100 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
AddHtmlAttributeValue("", 5701, product.ImageAlt, 5701, 17, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "title", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 101 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
AddHtmlAttributeValue("", 5793, product.ImageTitle, 5793, 19, false);

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
                WriteLiteral("\r\n                                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 97 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                                             WriteLiteral(product.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 98 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                                               WriteLiteral(product.Name.Sluggish());

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["slug"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-slug", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["slug"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

                                                        <div class=""hover-icons"">
                                                            <a href=""javascript:void(0)"">
                                                                <i class=""ion-bag""></i>
                                                            </a>
                                                            <a href=""javascript:void(0)"" data-toggle=""modal""
                                                               data-target=""#quick-view-modal-container"">
                                                                <i class=""ion-android-open""></i>
                                                            </a>
                                                        </div>

                                                    </div>
                                                    <div class=""single-grid-product__content"">
                                                        <div class=""single-grid-product_");
            WriteLiteral("_category-rating\">\r\n                                                            <span class=\"category\">\r\n                                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9ec13c27ee0810052d1a0dac35c197bf97727ea120034", async() => {
#nullable restore
#line 120 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                                                                                               Write(Model.Category.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 119 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                                                     WriteLiteral(Model.Category.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 120 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                                                       WriteLiteral(Model.Category.Name.Sluggish());

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["slug"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-slug", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["slug"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                                            </span>
                                                            <span class=""rating"">
                                                                <i class=""ion-android-star active""></i>
                                                                <i class=""ion-android-star active""></i>
                                                                <i class=""ion-android-star active""></i>
                                                                <i class=""ion-android-star active""></i>
                                                                <i class=""ion-android-star-outline""></i>
                                                            </span>
                                                        </div>

                                                        <h3 class=""single-grid-product__title"">
                                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9ec13c27ee0810052d1a0dac35c197bf97727ea124229", async() => {
                WriteLiteral("\r\n                                                                ");
#nullable restore
#line 135 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                                           Write(product.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 133 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                                                 WriteLiteral(product.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 134 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                                                   WriteLiteral(product.Name.Sluggish());

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["slug"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-slug", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["slug"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                        </h3>\r\n\r\n                                                        <p class=\"single-grid-product__price\">\r\n");
#nullable restore
#line 140 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                                             if (product.IsInStock)
                                                            {
                                                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 142 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                                                 if (product.HasDiscount)
                                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                    <span class=\"discounted-price\">");
#nullable restore
#line 144 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                                                                              Write(product.DiscountPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                                                    <span class=\"main-price discounted\">");
#nullable restore
#line 145 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                                                                                   Write(product.UnitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 146 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                                                }
                                                                else
                                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                    <span class=\"discounted-price\">");
#nullable restore
#line 149 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                                                                              Write(product.UnitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 150 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 150 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                                                 
                                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        </p>\r\n\r\n");
#nullable restore
#line 154 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                                         if (product.HasDiscount && product.IsInStock)
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <div class=\"product-countdown\" data-countdown=\"");
#nullable restore
#line 156 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                                                                                      Write(product.DiscountEndDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"></div>\r\n");
#nullable restore
#line 157 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    </div>\r\n                                                </div>\r\n\r\n                                            </div>\r\n");
#nullable restore
#line 162 "C:\Users\pedram\Desktop\pedram\source\Pedikala\ServiceHost\Pages\Category.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </div>\r\n\r\n                                </div>\r\n\r\n");
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServiceHost.Pages.CategoryModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Pages.CategoryModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Pages.CategoryModel>)PageContext?.ViewData;
        public ServiceHost.Pages.CategoryModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
