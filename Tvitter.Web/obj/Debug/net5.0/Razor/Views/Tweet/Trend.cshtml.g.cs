#pragma checksum "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Tweet\Trend.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3a46170bc5708c981e8f007ed1375a5bcbbedfee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tweet_Trend), @"mvc.1.0.view", @"/Views/Tweet/Trend.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a46170bc5708c981e8f007ed1375a5bcbbedfee", @"/Views/Tweet/Trend.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df0a60fea85bb04020732d441da23322f29eaead", @"/Views/_ViewImports.cshtml")]
    public class Views_Tweet_Trend : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tag>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Tweet\Trend.cshtml"
  
    ViewData["Title"] = "Tweets";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"py-4 px-4\">\r\n\r\n    <div class=\"col-11 mx-auto\">\r\n");
#nullable restore
#line 9 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Tweet\Trend.cshtml"
         foreach (var tweet in Model.Tweets)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div");
            BeginWriteAttribute("id", " id=\"", 190, "\"", 221, 2);
            WriteAttributeValue("", 195, "view", 195, 4, true);
#nullable restore
#line 11 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Tweet\Trend.cshtml"
WriteAttributeValue("", 199, tweet.ID.ToString(), 199, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                ");
#nullable restore
#line 12 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Tweet\Trend.cshtml"
           Write(await Html.PartialAsync("PartialView/_DisplayTweet", Tuple.Create<User, Tweet>(tweet.User, tweet)));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 14 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Tweet\Trend.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tag> Html { get; private set; }
    }
}
#pragma warning restore 1591
