#pragma checksum "C:\Users\shayl\source\repos\BlackRockEvents\BlackRockEvents\Views\Reservations\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc4f9f038c42545c32faf1179080d424cbe34c8e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reservations_Details), @"mvc.1.0.view", @"/Views/Reservations/Details.cshtml")]
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
#line 1 "C:\Users\shayl\source\repos\BlackRockEvents\BlackRockEvents\Views\_ViewImports.cshtml"
using BlackRockEvents;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\shayl\source\repos\BlackRockEvents\BlackRockEvents\Views\_ViewImports.cshtml"
using BlackRockEvents.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc4f9f038c42545c32faf1179080d424cbe34c8e", @"/Views/Reservations/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e8d564491c897b32a691c052ffb9feb13d3962a2", @"/Views/_ViewImports.cshtml")]
    public class Views_Reservations_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BlackRockEvents.Models.Reservation>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ThankYou", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\shayl\source\repos\BlackRockEvents\BlackRockEvents\Views\Reservations\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"wrapper\">\r\n    <h1 class=\"text-center\">Reservation</h1>    \r\n    <h4 class=\"text-center\">Please Review Your Reservation Request Details</h4>\r\n    <hr />  \r\n    <div class=\"text-center\">\r\n         <dl>\r\n            <dt>\r\n                ");
#nullable restore
#line 13 "C:\Users\shayl\source\repos\BlackRockEvents\BlackRockEvents\Views\Reservations\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.StartTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
#nullable restore
#line 16 "C:\Users\shayl\source\repos\BlackRockEvents\BlackRockEvents\Views\Reservations\Details.cshtml"
           Write(Html.DisplayFor(model => model.StartTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                ");
#nullable restore
#line 19 "C:\Users\shayl\source\repos\BlackRockEvents\BlackRockEvents\Views\Reservations\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.EndTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
#nullable restore
#line 22 "C:\Users\shayl\source\repos\BlackRockEvents\BlackRockEvents\Views\Reservations\Details.cshtml"
           Write(Html.DisplayFor(model => model.EndTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                ");
#nullable restore
#line 25 "C:\Users\shayl\source\repos\BlackRockEvents\BlackRockEvents\Views\Reservations\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.EventType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
#nullable restore
#line 28 "C:\Users\shayl\source\repos\BlackRockEvents\BlackRockEvents\Views\Reservations\Details.cshtml"
           Write(Html.DisplayFor(model => model.EventType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                ");
#nullable restore
#line 31 "C:\Users\shayl\source\repos\BlackRockEvents\BlackRockEvents\Views\Reservations\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.NumOfAttendees));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
#nullable restore
#line 34 "C:\Users\shayl\source\repos\BlackRockEvents\BlackRockEvents\Views\Reservations\Details.cshtml"
           Write(Html.DisplayFor(model => model.NumOfAttendees));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                ");
#nullable restore
#line 37 "C:\Users\shayl\source\repos\BlackRockEvents\BlackRockEvents\Views\Reservations\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.SeatsPerTable));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
#nullable restore
#line 40 "C:\Users\shayl\source\repos\BlackRockEvents\BlackRockEvents\Views\Reservations\Details.cshtml"
           Write(Html.DisplayFor(model => model.SeatsPerTable));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n        </dl>  \r\n            <div class=\"text-center\">\r\n                <h2>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc4f9f038c42545c32faf1179080d424cbe34c8e8020", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 44 "C:\Users\shayl\source\repos\BlackRockEvents\BlackRockEvents\Views\Reservations\Details.cshtml"
                                                                   WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</h2>\r\n                <h2>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc4f9f038c42545c32faf1179080d424cbe34c8e10318", async() => {
                WriteLiteral("Continue");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("    </h2>\r\n            </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BlackRockEvents.Models.Reservation> Html { get; private set; }
    }
}
#pragma warning restore 1591