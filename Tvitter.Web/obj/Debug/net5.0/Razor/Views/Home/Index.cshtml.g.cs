#pragma checksum "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "743735e75d1241c1b2b2982e63308b0665b6102b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"743735e75d1241c1b2b2982e63308b0665b6102b", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df0a60fea85bb04020732d441da23322f29eaead", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tuple<User, Tweet>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home";

#line default
#line hidden
#nullable disable
            WriteLiteral("<section>\r\n    <div class=\"container text-dark col-12 mx-auto\">\r\n        <div class=\"mx-auto\">\r\n            <div class=\"card\">\r\n                <div class=\"card-body p-3\">\r\n                    <div class=\"d-flex flex-start w-100\">\r\n");
#nullable restore
#line 12 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Home\Index.cshtml"
                         if (Model.Item1.ProfilePictureUrl != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <img class=\"rounded-circle shadow-1-strong mr-3\"");
            BeginWriteAttribute("src", "\r\n                                 src=\"", 473, "\"", 556, 1);
#nullable restore
#line 15 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 513, Url.Content(Model.Item1.ProfilePictureUrl), 513, 43, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                                 alt=\"avatar\"\r\n                                 width=\"65\"\r\n                                 height=\"65\" />\r\n");
#nullable restore
#line 19 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Home\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <img class=""rounded-circle shadow-1-strong mr-3""
                                 src=""https://st.depositphotos.com/1779253/5140/v/600/depositphotos_51405259-stock-illustration-male-avatar-profile-picture-use.jpg""
                                 alt=""avatar""
                                 width=""65""
                                 height=""65"" />
");
#nullable restore
#line 27 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Home\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 29 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Home\Index.cshtml"
                   Write(await Html.PartialAsync("PartialView/_PostTweet", Model.Item2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"mx-auto mb-2 mt-2\">\r\n");
#nullable restore
#line 36 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Home\Index.cshtml"
             foreach (var tweet in Model.Item1.HomePageTweets.Take(50))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div");
            BeginWriteAttribute("id", " id=\"", 1522, "\"", 1559, 2);
            WriteAttributeValue("", 1527, "view", 1527, 4, true);
#nullable restore
#line 38 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Home\Index.cshtml"
WriteAttributeValue("", 1531, tweet.Item2.ID.ToString(), 1531, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                ");
#nullable restore
#line 39 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Home\Index.cshtml"
           Write(await Html.PartialAsync("PartialView/_DisplayTweet", Tuple.Create<User, Tweet>(tweet.Item1, tweet.Item2)));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 41 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n        <div class=\"container mb-5\">\r\n            <div class=\"card bg-success text-white\">\r\n                <div class=\"card-body\">All caught up!</div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tuple<User, Tweet>> Html { get; private set; }
    }
}
#pragma warning restore 1591
