#pragma checksum "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3786459e58c3988b0fe22baa8748ea833e63f730"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Account_Views_User_Register), @"mvc.1.0.view", @"/Areas/Account/Views/User/Register.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3786459e58c3988b0fe22baa8748ea833e63f730", @"/Areas/Account/Views/User/Register.cshtml")]
    public class Areas_Account_Views_User_Register : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OnlineShop.Areas.Account.Models.ApplicationUserVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Register.cshtml"
  
    ViewBag.Title = "Registration";
    Layout = "Login_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h2>Register an account</h2>\n\n<div class=\"justify-content-center\">\n");
#nullable restore
#line 11 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Register.cshtml"
     using (Html.BeginForm())
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Register.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"form-horizontal align-items-center\">\n            ");
#nullable restore
#line 15 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Register.cshtml"
       Write(Html.ValidationSummary(true, "", new {@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <div class=\"form-outline mb-4\">\n                ");
#nullable restore
#line 17 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Register.cshtml"
           Write(Html.LabelFor(  model => model.FName, htmlAttributes: new {@class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                <div class=\"col-md-10 w-25\">\n                    ");
#nullable restore
#line 19 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Register.cshtml"
               Write(Html.EditorFor(model => model.FName, new {htmlAttributes = new {@class = "form-control"}}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    ");
#nullable restore
#line 20 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Register.cshtml"
               Write(Html.ValidationMessageFor(model => model.FName, "", new {@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </div>\n            </div>\n            <div class=\"form-outline mb-4\">\n                ");
#nullable restore
#line 24 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Register.cshtml"
           Write(Html.LabelFor(  model => model.LName, htmlAttributes: new {@class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                <div class=\"col-md-10 w-25\">\n                    ");
#nullable restore
#line 26 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Register.cshtml"
               Write(Html.EditorFor(model => model.LName, new {htmlAttributes = new {@class = "form-control"}}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    ");
#nullable restore
#line 27 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Register.cshtml"
               Write(Html.ValidationMessageFor(model => model.LName, "", new {@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </div>\n            </div>\n            <div class=\"form-outline mb-4\">\n                ");
#nullable restore
#line 31 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Register.cshtml"
           Write(Html.LabelFor(  model => model.Email,"Enter your email", htmlAttributes: new {@class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                <div class=\"col-md-10 w-25\">\n                    ");
#nullable restore
#line 33 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Register.cshtml"
               Write(Html.EditorFor(model => model.Email, new {htmlAttributes = new {@class = "form-control"}}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    ");
#nullable restore
#line 34 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Register.cshtml"
               Write(Html.ValidationMessageFor(model => model.Email, "", new {@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </div>\n            </div>\n            <div class=\"form-outline mb-4\">\n                ");
#nullable restore
#line 38 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Register.cshtml"
           Write(Html.LabelFor(  model => model.Password, htmlAttributes: new {@class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                <div class=\"col-md-10 w-25\">\n                    ");
#nullable restore
#line 40 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Register.cshtml"
               Write(Html.PasswordFor(model => model.Password, new {htmlAttributes = new {@class = "form-control"}}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    ");
#nullable restore
#line 41 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Register.cshtml"
               Write(Html.ValidationMessageFor(model => model.Password, "", new {@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </div>\n            </div>\n            <div class=\"form-outline mb-4\">\n                ");
#nullable restore
#line 45 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Register.cshtml"
           Write(Html.LabelFor(  model => model.PasswordConfirmation, htmlAttributes: new {@class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                <div class=\"col-md-10 w-25\">\n                    ");
#nullable restore
#line 47 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Register.cshtml"
               Write(Html.PasswordFor(model => model.PasswordConfirmation, new {htmlAttributes = new {@class = "form-control"}}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    ");
#nullable restore
#line 48 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Register.cshtml"
               Write(Html.ValidationMessageFor(model => model.PasswordConfirmation, "", new {@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </div>\n            </div>\n\n            <div class=\"form-group\">\n                <div class=\"offset-2 col\">\n                    ");
#nullable restore
#line 54 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Register.cshtml"
               Write(Html.ActionLink( "Back", "Login", "User", new { Area = "Account" }, new {@class = "btn btn-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    <input type=\"submit\" value=\"Create an account\" class=\"btn btn-success\"/>\n                </div>\n            </div>\n        </div>\n");
#nullable restore
#line 59 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Register.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OnlineShop.Areas.Account.Models.ApplicationUserVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
