#pragma checksum "C:\Users\shayl\source\repos\BlackRockEvents\BlackRockEvents\Views\Reservations\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "46bca292d0dc166d5b0c8c9eaef0f1d054a17fff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reservations_List), @"mvc.1.0.view", @"/Views/Reservations/List.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46bca292d0dc166d5b0c8c9eaef0f1d054a17fff", @"/Views/Reservations/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e8d564491c897b32a691c052ffb9feb13d3962a2", @"/Views/_ViewImports.cshtml")]
    public class Views_Reservations_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\shayl\source\repos\BlackRockEvents\BlackRockEvents\Views\Reservations\List.cshtml"
  
    ViewData["Title"] = "View";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""wrapper"">
    <h1 class=""text-center"">Unavailable Dates</h1>
    <hr />
    <div class=""container"">
        <table id=""unavailableTable"" class=""table table-bordered table-hover table-striped"">
            <thead class=""thead-dark"">
                <tr>
                    <th scope=""col"">
                        StartTime
                    </th>
                    <th scope=""col"">
                        EndTime
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td></td>
                    <td></td>
                </tr>
            </tbody>
        </table>
    </div>
    <hr />
    <p class=""text-center"">
       <input type=""button"" class=""btn btn-primary"" value=""Request Reservation""");
            BeginWriteAttribute("onclick", " onclick=\"", 902, "\"", 965, 3);
            WriteAttributeValue("", 912, "location.href=\'", 912, 15, true);
#nullable restore
#line 30 "C:\Users\shayl\source\repos\BlackRockEvents\BlackRockEvents\Views\Reservations\List.cshtml"
WriteAttributeValue("", 927, Url.Action("Create", "Reservations"), 927, 37, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 964, "\'", 964, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n    </p>\r\n</div>\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"https://cdn.datatables.net/v/bs4/dt-1.11.5/datatables.min.css\"/>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"" src=""https://cdn.datatables.net/v/bs4/dt-1.11.5/datatables.min.js""></script>
    <script>
              $(document).ready(function (){
                    $('#unavailableTable').DataTable({
                        ajax:{
                            url: '/Reservations/GetList',
                            dataSrc: ''
                        },
                        columns:[
                            {
                                title: ""Start Time"",
                                data: ""startTime"", 
                            },
                            {
                                title: ""End Time"",
                                data: ""endTime"",
                            }
                        ]
                    });
                });                  
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
