#pragma checksum "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/EditCategory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "686d7c47b0677ca4577c313c496a42b55da4f179"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Category_EditCategory), @"mvc.1.0.view", @"/Areas/Admin/Views/Category/EditCategory.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"686d7c47b0677ca4577c313c496a42b55da4f179", @"/Areas/Admin/Views/Category/EditCategory.cshtml")]
    public class Areas_Admin_Views_Category_EditCategory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OnlineShop.Areas.Admin.Models.CategoryVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/EditCategory.cshtml"
  
    ViewBag.Title = "title";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 8 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/EditCategory.cshtml"
 if (TempData["CSM"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success\">\n        ");
#nullable restore
#line 11 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/EditCategory.cshtml"
   Write(TempData["CSM"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </div>\n");
#nullable restore
#line 13 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/EditCategory.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 15 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/EditCategory.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/EditCategory.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-horizontal\">\n        <hr>\n        ");
#nullable restore
#line 20 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/EditCategory.cshtml"
   Write(Html.ValidationSummary(true, "", new {@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        <div class=\"form-group\">\n            ");
#nullable restore
#line 22 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/EditCategory.cshtml"
       Write(Html.LabelFor(  model => model.Name, htmlAttributes: new {@class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <div class=\"col-md-10\">\n                ");
#nullable restore
#line 24 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/EditCategory.cshtml"
           Write(Html.EditorFor(model => model.Name, new {htmlAttributes = new {@class = "form-control"}}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                ");
#nullable restore
#line 25 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/EditCategory.cshtml"
           Write(Html.ValidationMessageFor(model => model.Name, "", new {@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n        </div>\n        <div class=\"form-group\">\n            ");
#nullable restore
#line 29 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/EditCategory.cshtml"
       Write(Html.LabelFor(  model => model.Description, htmlAttributes: new {@class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <div class=\"col-md-10\">\n                ");
#nullable restore
#line 31 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/EditCategory.cshtml"
           Write(Html.TextAreaFor(model => model.Description, new {@class = "form-control"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                ");
#nullable restore
#line 32 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/EditCategory.cshtml"
           Write(Html.ValidationMessageFor(model => model.Description, "", new {@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </div>\n        </div>\n\n        <div class=\"form-group\">\n            <div class=\"offset-2 col\">\n                ");
#nullable restore
#line 38 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/EditCategory.cshtml"
           Write(Html.ActionLink("Back", "Index", "Page", null, new {@class="btn btn-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                <input type=\"submit\" value=\"Save Page\" class=\"btn btn-success\"/>\n            </div>\n        </div>\n    </div>\n");
#nullable restore
#line 43 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Admin/Views/Category/EditCategory.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OnlineShop.Areas.Admin.Models.CategoryVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
