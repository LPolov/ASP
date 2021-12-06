#pragma checksum "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/Categories.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "da0bb11ddfe7fa3250118c126def284f563f6be0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Category_Categories), @"mvc.1.0.view", @"/Areas/Admin/Views/Category/Categories.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da0bb11ddfe7fa3250118c126def284f563f6be0", @"/Areas/Admin/Views/Category/Categories.cshtml")]
    public class Areas_Admin_Views_Category_Categories : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<OnlineShop.Areas.Admin.Models.CategoryVM>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/Categories.cshtml"
  
    ViewBag.Title = "Categories";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h2>Categories</h2>\n");
#nullable restore
#line 9 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/Categories.cshtml"
 if (TempData["CSM"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success\">\n        ");
#nullable restore
#line 12 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/Categories.cshtml"
   Write(TempData["CSM"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </div>\n");
#nullable restore
#line 14 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/Categories.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<p>\n    ");
#nullable restore
#line 16 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/Categories.cshtml"
Write(Html.ActionLink( "Create new Category", "AddCategory", "Category", null, new {@class="btn btn-success"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n</p>\n\n<table class=\"table\">\n    <tr>\n        <th>Name</th>\n        <th>Description</th>\n        <th></th>\n    </tr>\n    \n");
#nullable restore
#line 26 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/Categories.cshtml"
     foreach(var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <td>");
#nullable restore
#line 29 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/Categories.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 30 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/Categories.cshtml"
           Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>\n                ");
#nullable restore
#line 32 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/Categories.cshtml"
           Write(Html.ActionLink("Edit", "EditCategory", new {id=item.Id}));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\n                ");
#nullable restore
#line 33 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/Categories.cshtml"
           Write(Html.ActionLink("Delete", "DeleteCategory", new {id=item.Id}, new {@class = "delete"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n            </td>\n        </tr>\n");
#nullable restore
#line 37 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/Categories.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(function () {
            /*Page delete confirmation*/
            $(""a.delete"").click(function (){
                if (!confirm(""Are you sure that you want to delete this category?"")) {
                    return false;
                }
            })
        })
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<OnlineShop.Areas.Admin.Models.CategoryVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591