#pragma checksum "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2a57ba5163211b923bfaf6bbfc0305dc8bc10e54"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Account_Views_User_Login), @"mvc.1.0.view", @"/Areas/Account/Views/User/Login.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a57ba5163211b923bfaf6bbfc0305dc8bc10e54", @"/Areas/Account/Views/User/Login.cshtml")]
    public class Areas_Account_Views_User_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OnlineShop.Areas.Account.Models.LoginUserVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Login.cshtml"
  
    ViewBag.Title = "Login";
    Layout = "Login_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2 class=\"d-flex justify-content-center\">Login</h2>\n");
#nullable restore
#line 8 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Login.cshtml"
 using (Html.BeginForm())
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Login.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"form-horizontal align-items-center\">\n            ");
#nullable restore
#line 12 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Login.cshtml"
       Write(Html.ValidationSummary(true, "", new {@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            <div class=\"form-outline mb-4\">\n                ");
#nullable restore
#line 14 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Login.cshtml"
           Write(Html.LabelFor(model => model.Email, htmlAttributes: new {@class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                <div class=\"col-md-10 w-25\">\n                    ");
#nullable restore
#line 16 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Login.cshtml"
               Write(Html.EditorFor(model => model.Email, new {htmlAttributes = new {@class = "form-control"}}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    ");
#nullable restore
#line 17 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Login.cshtml"
               Write(Html.ValidationMessageFor(model => model.Email, "", new {@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </div>\n            </div>\n            <div class=\"form-outline mb-4\">\n                ");
#nullable restore
#line 21 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Login.cshtml"
           Write(Html.LabelFor(model => model.Password, htmlAttributes: new {@class = "control-label col-md-2"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                <div class=\"col-md-10 w-25\">\n                    ");
#nullable restore
#line 23 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Login.cshtml"
               Write(Html.PasswordFor(model => model.Password, new {htmlAttributes = new {@class = "form-control"}}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    ");
#nullable restore
#line 24 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Login.cshtml"
               Write(Html.ValidationMessageFor(model => model.Password, "", new {@class = "text-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </div>\n            </div>\n\n            <div class=\"form-group\">\n                <div class=\"col\">\n                    <input type=\"submit\" value=\"Login\" class=\"btn btn-success\"/>\n                    <hr/>\n                    ");
#nullable restore
#line 32 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Login.cshtml"
               Write(Html.ActionLink("Forgot password?", "ResetPassword", "User", new {Area = "Account"}, new {@class = "btn btn-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    ");
#nullable restore
#line 33 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Login.cshtml"
               Write(Html.ActionLink("Do not have an account?", "Register", "User", new {Area = "Account"}, new {@class = "btn btn-warning"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </div>\n            </div>\n        </div>\n");
#nullable restore
#line 37 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Account/Views/User/Login.cshtml"
        
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OnlineShop.Areas.Account.Models.LoginUserVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
