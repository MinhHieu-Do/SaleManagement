#pragma checksum "D:\CoreMVC\WebApp.SaleManagement\WebApp.SaleManagement\Views\Customer\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13481d6a3f535325a40fd266c4bc5a1e53ebbeaf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_Details), @"mvc.1.0.view", @"/Views/Customer/Details.cshtml")]
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
#line 1 "D:\CoreMVC\WebApp.SaleManagement\WebApp.SaleManagement\Views\_ViewImports.cshtml"
using WebApp.SaleManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\CoreMVC\WebApp.SaleManagement\WebApp.SaleManagement\Views\_ViewImports.cshtml"
using WebApp.SaleManagement.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13481d6a3f535325a40fd266c4bc5a1e53ebbeaf", @"/Views/Customer/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2fc5066d168971038f5aa2673470325f597e638c", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApp.SaleManagement.Models.Customer>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("rounded-circle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("User Image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/profiles/avatar-01.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("actions"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "OrderManager", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\CoreMVC\WebApp.SaleManagement\WebApp.SaleManagement\Views\Customer\Details.cshtml"
  
    ViewData["Title"] = "Details";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""content container-fluid"">

        <!-- Page Header -->
        <div class=""page-header"">
            <div class=""row"">
                <div class=""col"">
                    <h3 class=""page-title"">Profile</h3>

                </div>
            </div>
        </div>
        <!-- /Page Header -->

        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""profile-header"">
                    <div class=""row align-items-center"">
                        <div class=""col-auto profile-image"">
                            <a href=""#"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "13481d6a3f535325a40fd266c4bc5a1e53ebbeaf7436", async() => {
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
            WriteLiteral("\r\n                            </a>\r\n                        </div>\r\n                        <div class=\"col ml-md-n2 profile-user-info\">\r\n                            <h4 class=\"user-name mb-0\">");
#nullable restore
#line 29 "D:\CoreMVC\WebApp.SaleManagement\WebApp.SaleManagement\Views\Customer\Details.cshtml"
                                                  Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                            <h6 class=\"text-muted\">");
#nullable restore
#line 30 "D:\CoreMVC\WebApp.SaleManagement\WebApp.SaleManagement\Views\Customer\Details.cshtml"
                                              Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                            <div class=\"user-Location\"><i class=\"fa fa-map-marker\"></i> ");
#nullable restore
#line 31 "D:\CoreMVC\WebApp.SaleManagement\WebApp.SaleManagement\Views\Customer\Details.cshtml"
                                                                                   Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n                        </div>\r\n                        <div class=\"col-auto profile-btn\">\r\n\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13481d6a3f535325a40fd266c4bc5a1e53ebbeaf9975", async() => {
                WriteLiteral("\r\n                                Back To List\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
                <div class=""profile-menu"">
                    <ul class=""nav nav-tabs nav-tabs-solid"">
                        <li class=""nav-item"">
                            <a class=""nav-link active"" data-toggle=""tab"" href=""#per_details_tab"">About</a>
                        </li>
                        <li class=""nav-item"">
                            <a class=""nav-link"" data-toggle=""tab"" href=""#password_tab"">Order</a>
                        </li>
                    </ul>
                </div>
                <div class=""tab-content profile-tab-cont"">

                    <!-- Personal Details Tab -->
                    <div class=""tab-pane fade show active"" id=""per_details_tab"">

                        <!-- Personal Details -->
                        <div class=""row"">
                            <div class=""col-lg-12"">
                                <div class=""card"">
                       ");
            WriteLiteral(@"             <div class=""card-body"">
                                        <h5 class=""card-title d-flex justify-content-between"">
                                            
                                            <span class=""text-primary""> Customer Details</span>


                                        </h5>
                                        <div class=""row"">
                                            <p class=""col-sm-3 text-muted text-sm-right mb-0 mb-sm-3"">Name</p>
                                            <p class=""col-sm-9"">");
#nullable restore
#line 70 "D:\CoreMVC\WebApp.SaleManagement\WebApp.SaleManagement\Views\Customer\Details.cshtml"
                                                           Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                        </div>

                                        <div class=""row"">
                                            <p class=""col-sm-3 text-muted text-sm-right mb-0 mb-sm-3"">Email</p>
                                            <p class=""col-sm-9"">");
#nullable restore
#line 75 "D:\CoreMVC\WebApp.SaleManagement\WebApp.SaleManagement\Views\Customer\Details.cshtml"
                                                           Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                        </div>
                                        <div class=""row"">
                                            <p class=""col-sm-3 text-muted text-sm-right mb-0 mb-sm-3"">Mobile</p>
                                            <p class=""col-sm-9"">");
#nullable restore
#line 79 "D:\CoreMVC\WebApp.SaleManagement\WebApp.SaleManagement\Views\Customer\Details.cshtml"
                                                           Write(Model.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                        </div>
                                        <div class=""row"">
                                            <p class=""col-sm-3 text-muted text-sm-right mb-0"">Address</p>
                                            <p class=""col-sm-9 mb-0"">
                                                ");
#nullable restore
#line 84 "D:\CoreMVC\WebApp.SaleManagement\WebApp.SaleManagement\Views\Customer\Details.cshtml"
                                           Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                            </p>
                                        </div>
                                    </div>
                                </div>



                            </div>


                        </div>
                        <!-- /Personal Details -->

                    </div>
                    <!-- /Personal Details Tab -->
                    <!-- Change Password Tab -->
                    <div id=""password_tab"" class=""tab-pane fade"">

                        <div class=""row"">
                            <div class=""col-lg-12"">
                                <div class=""card"">

                                    <div class=""card-body"">
                                        <div class=""table-responsive table-hover"">
                                            <table class=""table mb-0"">
                                                <thead>
                                                    <tr>
                           ");
            WriteLiteral(@"                             <th>OrderId</th>
                                                        <th>Order Date</th>
                                                        <th>Status</th>
                                                        <th>Total</th>
                                                        <th></th>
                                                    </tr>
                                                </thead>
                                                <tbody>
");
#nullable restore
#line 120 "D:\CoreMVC\WebApp.SaleManagement\WebApp.SaleManagement\Views\Customer\Details.cshtml"
                                                     foreach (var item in Model.Orders)
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <tr>\r\n                                                        <td>");
#nullable restore
#line 123 "D:\CoreMVC\WebApp.SaleManagement\WebApp.SaleManagement\Views\Customer\Details.cshtml"
                                                       Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                        <td>");
#nullable restore
#line 124 "D:\CoreMVC\WebApp.SaleManagement\WebApp.SaleManagement\Views\Customer\Details.cshtml"
                                                       Write(item.OrderDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 125 "D:\CoreMVC\WebApp.SaleManagement\WebApp.SaleManagement\Views\Customer\Details.cshtml"
                                                         if (item.Status.ToString() == "PendingReview")
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <td class=\"text-warning\">\r\n                                                                <b>");
#nullable restore
#line 128 "D:\CoreMVC\WebApp.SaleManagement\WebApp.SaleManagement\Views\Customer\Details.cshtml"
                                                              Write(item.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                                                            </td>\r\n");
#nullable restore
#line 130 "D:\CoreMVC\WebApp.SaleManagement\WebApp.SaleManagement\Views\Customer\Details.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 131 "D:\CoreMVC\WebApp.SaleManagement\WebApp.SaleManagement\Views\Customer\Details.cshtml"
                                                         if (item.Status.ToString() == "PendingShipment")
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <td class=\"text-primary \">\r\n                                                                <b>");
#nullable restore
#line 134 "D:\CoreMVC\WebApp.SaleManagement\WebApp.SaleManagement\Views\Customer\Details.cshtml"
                                                              Write(item.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                                                            </td>\r\n");
#nullable restore
#line 136 "D:\CoreMVC\WebApp.SaleManagement\WebApp.SaleManagement\Views\Customer\Details.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 137 "D:\CoreMVC\WebApp.SaleManagement\WebApp.SaleManagement\Views\Customer\Details.cshtml"
                                                         if (item.Status.ToString() == "Complete")
                                                        {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <td class=\"text-success\">\r\n                                                                <b>");
#nullable restore
#line 141 "D:\CoreMVC\WebApp.SaleManagement\WebApp.SaleManagement\Views\Customer\Details.cshtml"
                                                              Write(item.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                                                            </td>\r\n");
#nullable restore
#line 143 "D:\CoreMVC\WebApp.SaleManagement\WebApp.SaleManagement\Views\Customer\Details.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <td>");
#nullable restore
#line 144 "D:\CoreMVC\WebApp.SaleManagement\WebApp.SaleManagement\Views\Customer\Details.cshtml"
                                                       Write(item.Total);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                        <td>\r\n                                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13481d6a3f535325a40fd266c4bc5a1e53ebbeaf21462", async() => {
                WriteLiteral(@"
                                                                <button type=""submit"" class=""btn btn-sm bg-primary-light "">
                                                                    <i class=""fe fe-eye""></i> Details
                                                                </button>
                                                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 146 "D:\CoreMVC\WebApp.SaleManagement\WebApp.SaleManagement\Views\Customer\Details.cshtml"
                                                                                                                                                    WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                            &nbsp;\r\n                                                        </td>\r\n                                                    </tr>\r\n");
#nullable restore
#line 154 "D:\CoreMVC\WebApp.SaleManagement\WebApp.SaleManagement\Views\Customer\Details.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                    <!-- /Change Password Tab -->

                </div>
            </div>
        </div>

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApp.SaleManagement.Models.Customer> Html { get; private set; }
    }
}
#pragma warning restore 1591
