#pragma checksum "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Customer/Views/Product/ProductDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a0f07eb87aa808f6fe98bdfd72445ff4ef392aab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customer_Views_Product_ProductDetails), @"mvc.1.0.view", @"/Areas/Customer/Views/Product/ProductDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a0f07eb87aa808f6fe98bdfd72445ff4ef392aab", @"/Areas/Customer/Views/Product/ProductDetails.cshtml")]
    public class Areas_Customer_Views_Product_ProductDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OnlineShop.Areas.Admin.Models.ProductVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Customer/Views/Product/ProductDetails.cshtml"
  
    ViewBag.Title = "Product Details";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h2>Product Details</h2>\n<div class=\"col-lg-4 mt-2\">\n    <img class=\"img-thumbnail\"");
            BeginWriteAttribute("src", " src=\"", 200, "\"", 218, 1);
#nullable restore
#line 10 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Customer/Views/Product/ProductDetails.cshtml"
WriteAttributeValue("", 206, Model.Image, 206, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/>\n    <h4>Name: ");
#nullable restore
#line 11 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Customer/Views/Product/ProductDetails.cshtml"
         Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n    <p>Description: ");
#nullable restore
#line 12 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Customer/Views/Product/ProductDetails.cshtml"
               Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n    <p>Price: $");
#nullable restore
#line 13 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Customer/Views/Product/ProductDetails.cshtml"
          Write(Model.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n    <p>Category: ");
#nullable restore
#line 14 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Customer/Views/Product/ProductDetails.cshtml"
            Write(Model.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n    <p>Category description: ");
#nullable restore
#line 15 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Customer/Views/Product/ProductDetails.cshtml"
                        Write(Model.Category.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n    <p>");
#nullable restore
#line 16 "/Users/leontiipolovinko/RiderProjects/OnlineShop/OnlineShop/Areas/Customer/Views/Product/ProductDetails.cshtml"
  Write(Html.ActionLink("Order", "", "", null, new {@class="btn btn-warning"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OnlineShop.Areas.Admin.Models.ProductVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
