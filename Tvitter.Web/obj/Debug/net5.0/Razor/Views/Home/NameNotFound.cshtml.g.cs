#pragma checksum "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Home\NameNotFound.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c37b162fae5e9f4717e5bda826f876a7af7cf930"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_NameNotFound), @"mvc.1.0.view", @"/Views/Home/NameNotFound.cshtml")]
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
#line 1 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\_ViewImports.cshtml"
using Tvitter.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\_ViewImports.cshtml"
using Tvitter.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\_ViewImports.cshtml"
using Tvitter.Model.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c37b162fae5e9f4717e5bda826f876a7af7cf930", @"/Views/Home/NameNotFound.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df0a60fea85bb04020732d441da23322f29eaead", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_NameNotFound : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Home\NameNotFound.cshtml"
  
    ViewData["Title"] = "Not Found";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-9 mx-auto mt-4\">\r\n            <div class=\"error-template\">\r\n                <h1>\r\n                    Oops!\r\n                </h1>\r\n                <h2>\r\n                    ");
#nullable restore
#line 14 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Home\NameNotFound.cshtml"
               Write(TempData["NotFoundName"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" Not Found
                </h2>
                <div class=""error-details"">
                    Nothing found from specified key
                </div>
                <div class=""error-actions mt-2"">
                    <button onClick=""goBack()"" class=""btn btn-primary btn-lg"">
                        Back
                    </button>
                </div>
            </div>
        </div>
    </div>
</div>
");
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
