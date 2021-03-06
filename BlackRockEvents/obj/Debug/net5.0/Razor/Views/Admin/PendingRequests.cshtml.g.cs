#pragma checksum "C:\Users\shayl\source\repos\BlackRockEvents\BlackRockEvents\Views\Admin\PendingRequests.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "204106183ac754fc9137ed19ae653eb391b0334f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_PendingRequests), @"mvc.1.0.view", @"/Views/Admin/PendingRequests.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"204106183ac754fc9137ed19ae653eb391b0334f", @"/Views/Admin/PendingRequests.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e8d564491c897b32a691c052ffb9feb13d3962a2", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_PendingRequests : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\shayl\source\repos\BlackRockEvents\BlackRockEvents\Views\Admin\PendingRequests.cshtml"
  
    ViewData["Title"] = "PendingRequests";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""wrapper"">
<h1 class=""text-center"">Pending Requests</h1>
<hr />
<table id=""pendingRequestsTable"" class=""table table-bordered table-hover table-sm table-striped"" >
    <thead class=""thead-dark"">
        <tr>
            <th scope=""col"">
                Start Time
            </th>
            <th scope=""col"">
                End Time
            </th>
            <th scope=""col"">
                Event Type
            </th>
            <th scope=""col"">
                Number of Attendees
            </th>
            <th scope=""col"">
               Guests Per Table
            </th>
            <th scope=""col"">
                Approve/Deny
            </th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>
            </td>

            <td>
            </td>

            <td>
            </td>

            <td>
            </td>

            <td>
            </td>

            <td>
               
            </td>
        </tr>
    ");
            WriteLiteral("</tbody>\r\n</table>\r\n</div>\r\n\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"https://cdn.datatables.net/v/bs4/dt-1.11.5/b-2.2.2/datatables.min.css\"/>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"" src=""https://cdn.datatables.net/v/bs4/dt-1.11.5/b-2.2.2/datatables.min.js""></script>
    <script type=""text/javascript"">
              $(document).ready(function (){
                    $('#pendingRequestsTable').DataTable({
                        ajax:{
                            url: '/Admin/GetList',
                            dataSrc: ''
                        },
                        columns:[
                            {
                                title: ""Start Time"",
                                data: ""startTime""
                            },
                            {
                                title: ""End Time"",
                                data: ""endTime""
                            },
                            {
                                title: ""Event Type"",
                                data: ""typeEvent"" 
                            },
                            {
                                title:");
                WriteLiteral(@" ""Number Of Attendees"",
                                data: ""attendees"" 
                            },
                            {
                                title: ""Guests Per Table"",
                                data: ""guestsPerTable"" 
                            },
                            {
                                title: ""Approve/Deny"",
                                data: ""approve"",
                                render: function (data){
                                    /*return '<a class=""btn btn-primary"" asp-action=""AdminApprove"" asp-route-id=""'+data+'"">Approve</a>';*/
                                    let mystring='<a href=""/Admin/AdminApprove/' +data+'""><i class=""fa-solid fa-check""></i></a>' +
                                    '<a href=""/Admin/Delete/' +data+ '""><i class=""fa-solid fa-x""></i></i></a>';
                                    return mystring;
                                }
                            }
                        ]
        ");
                WriteLiteral("            });\r\n                });\r\n                         \r\n    </script>\r\n");
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
