#pragma checksum "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Profile\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c87433c468fffa5bc95502ab67ebdb2c546365c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profile_Index), @"mvc.1.0.view", @"/Views/Profile/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c87433c468fffa5bc95502ab67ebdb2c546365c", @"/Views/Profile/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df0a60fea85bb04020732d441da23322f29eaead", @"/Views/_ViewImports.cshtml")]
    public class Views_Profile_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<User>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Profile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-dark btn-sm btn-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Profile\Index.cshtml"
  
    ViewData["Title"] = "Profile";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row py-5 px-4"">
    <div class=""col-12 mx-auto"">
        <!-- Profile widget -->
        <div class=""bg-white shadow rounded overflow-hidden"">
            <div class=""px-4 pt-0 pb-4 cover"">
                <div class=""media align-items-end profile-head"">

                    <div class=""profile mr-3"">
");
#nullable restore
#line 15 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Profile\Index.cshtml"
                         if (Model.ProfilePictureUrl != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <img");
            BeginWriteAttribute("src", " src=\"", 505, "\"", 548, 1);
#nullable restore
#line 17 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Profile\Index.cshtml"
WriteAttributeValue("", 511, Url.Content(Model.ProfilePictureUrl), 511, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"...\" width=\"130\" class=\"rounded mb-2 img-thumbnail\">\r\n");
#nullable restore
#line 18 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Profile\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <img src=\"https://st.depositphotos.com/1779253/5140/v/600/depositphotos_51405259-stock-illustration-male-avatar-profile-picture-use.jpg\" alt=\"...\" width=\"130\" class=\"rounded mb-2 img-thumbnail\">\r\n");
#nullable restore
#line 22 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Profile\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"mt-4\"></div>\r\n                    </div>\r\n                    <div class=\"media-body mb-5 text-white\">\r\n                        <h4 class=\"mt-0 mb-0\">");
#nullable restore
#line 26 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Profile\Index.cshtml"
                                         Write(Model.Fullname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                        <h6 class=\"mt-0 mb-0\">");
#nullable restore
#line 27 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Profile\Index.cshtml"
                                         Write(Html.Raw("@"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Profile\Index.cshtml"
                                                       Write(Model.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h6>
                        <div class=""mb-3""></div>
                    </div>
                </div>
            </div>
            <div class=""bg-light p-4 d-flex justify-content-sm-between text-center mt-4"">
                <div class=""mt-0"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2c87433c468fffa5bc95502ab67ebdb2c546365c7665", async() => {
                WriteLiteral("Edit profile");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 35 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Profile\Index.cshtml"
                     if (Model.Location != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <b class=""mt-0 mb-0"">
                            <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-geo-alt"" viewBox=""0 0 16 16"">
                                <path d=""M12.166 8.94c-.524 1.062-1.234 2.12-1.96 3.07A31.493 31.493 0 0 1 8 14.58a31.481 31.481 0 0 1-2.206-2.57c-.726-.95-1.436-2.008-1.96-3.07C3.304 7.867 3 6.862 3 6a5 5 0 0 1 10 0c0 .862-.305 1.867-.834 2.94zM8 16s6-5.686 6-10A6 6 0 0 0 2 6c0 4.314 6 10 6 10z"" />
                                <path d=""M8 8a2 2 0 1 1 0-4 2 2 0 0 1 0 4zm0 1a3 3 0 1 0 0-6 3 3 0 0 0 0 6z"" />
                            </svg>
                            ");
#nullable restore
#line 42 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Profile\Index.cshtml"
                       Write(Model.Location);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </b>\r\n");
#nullable restore
#line 44 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Profile\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Profile\Index.cshtml"
                     if (Model.Website != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <b class=""mt-0 mb-0"">
                            <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-globe"" viewBox=""0 0 16 16"">
                                <path d=""M0 8a8 8 0 1 1 16 0A8 8 0 0 1 0 8zm7.5-6.923c-.67.204-1.335.82-1.887 1.855A7.97 7.97 0 0 0 5.145 4H7.5V1.077zM4.09 4a9.267 9.267 0 0 1 .64-1.539 6.7 6.7 0 0 1 .597-.933A7.025 7.025 0 0 0 2.255 4H4.09zm-.582 3.5c.03-.877.138-1.718.312-2.5H1.674a6.958 6.958 0 0 0-.656 2.5h2.49zM4.847 5a12.5 12.5 0 0 0-.338 2.5H7.5V5H4.847zM8.5 5v2.5h2.99a12.495 12.495 0 0 0-.337-2.5H8.5zM4.51 8.5a12.5 12.5 0 0 0 .337 2.5H7.5V8.5H4.51zm3.99 0V11h2.653c.187-.765.306-1.608.338-2.5H8.5zM5.145 12c.138.386.295.744.468 1.068.552 1.035 1.218 1.65 1.887 1.855V12H5.145zm.182 2.472a6.696 6.696 0 0 1-.597-.933A9.268 9.268 0 0 1 4.09 12H2.255a7.024 7.024 0 0 0 3.072 2.472zM3.82 11a13.652 13.652 0 0 1-.312-2.5h-2.49c.062.89.291 1.733.656 2.5H3.82zm6.853 3.472A7.024 7.024 0 0 0 13.745 12H11.91a9.27 9.27 0 ");
            WriteLiteral(@"0 1-.64 1.539 6.688 6.688 0 0 1-.597.933zM8.5 12v2.923c.67-.204 1.335-.82 1.887-1.855.173-.324.33-.682.468-1.068H8.5zm3.68-1h2.146c.365-.767.594-1.61.656-2.5h-2.49a13.65 13.65 0 0 1-.312 2.5zm2.802-3.5a6.959 6.959 0 0 0-.656-2.5H12.18c.174.782.282 1.623.312 2.5h2.49zM11.27 2.461c.247.464.462.98.64 1.539h1.835a7.024 7.024 0 0 0-3.072-2.472c.218.284.418.598.597.933zM10.855 4a7.966 7.966 0 0 0-.468-1.068C9.835 1.897 9.17 1.282 8.5 1.077V4h2.355z"" />
                            </svg>
                            ");
#nullable restore
#line 51 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Profile\Index.cshtml"
                       Write(Model.Website);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </b>\r\n");
#nullable restore
#line 53 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Profile\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n                <ul class=\"list-inline mb-0\">\r\n                    <li class=\"list-inline-item\">\r\n                        <h5 class=\"font-weight-bold mb-0 d-block\">");
#nullable restore
#line 57 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Profile\Index.cshtml"
                                                             Write(Model.Tweets.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5><small class=\"text-muted\"> <i class=\"fas fa-image mr-1\"></i><a");
            BeginWriteAttribute("href", " href=\"", 4388, "\"", 4418, 3);
            WriteAttributeValue("", 4395, "/", 4395, 1, true);
#nullable restore
#line 57 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Profile\Index.cshtml"
WriteAttributeValue("", 4396, Model.Username, 4396, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4411, "/Tweets", 4411, 7, true);
            EndWriteAttribute();
            WriteLiteral(">Tweets</a></small>\r\n                    </li>\r\n                    <li class=\"list-inline-item\">\r\n                        <h5 class=\"font-weight-bold mb-0 d-block\">");
#nullable restore
#line 60 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Profile\Index.cshtml"
                                                             Write(Model.Followers.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5><small class=\"text-muted\"> <i class=\"fas fa-user mr-1\"></i><a");
            BeginWriteAttribute("href", " href=\"", 4672, "\"", 4705, 3);
            WriteAttributeValue("", 4679, "/", 4679, 1, true);
#nullable restore
#line 60 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Profile\Index.cshtml"
WriteAttributeValue("", 4680, Model.Username, 4680, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4695, "/Followers", 4695, 10, true);
            EndWriteAttribute();
            WriteLiteral(">Followers</a></small>\r\n                    </li>\r\n                    <li class=\"list-inline-item\">\r\n                        <h5 class=\"font-weight-bold mb-0 d-block\">");
#nullable restore
#line 63 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Profile\Index.cshtml"
                                                             Write(Model.Following.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5><small class=\"text-muted\"> <i class=\"fas fa-user mr-1\"></i><a");
            BeginWriteAttribute("href", " href=\"", 4962, "\"", 4995, 3);
            WriteAttributeValue("", 4969, "/", 4969, 1, true);
#nullable restore
#line 63 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Profile\Index.cshtml"
WriteAttributeValue("", 4970, Model.Username, 4970, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4985, "/Following", 4985, 10, true);
            EndWriteAttribute();
            WriteLiteral(@">Following</a></small>
                    </li>
                </ul>
            </div>
            <div class=""px-4 py-3"">
                

                <h5 class=""mb-0"">About</h5>
                <div class=""p-4 rounded shadow-sm bg-light"">
                    <p class=""font-italic mb-0"">");
#nullable restore
#line 72 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Profile\Index.cshtml"
                                           Write(Model.About);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n            </div>\r\n            <div class=\"py-4 px-4\">\r\n                <div class=\"d-flex align-items-center justify-content-between mb-3\">\r\n                    <h5 class=\"mb-0\">Recent Tweets</h5><a");
            BeginWriteAttribute("href", " href=\"", 5544, "\"", 5574, 3);
            WriteAttributeValue("", 5551, "/", 5551, 1, true);
#nullable restore
#line 77 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Profile\Index.cshtml"
WriteAttributeValue("", 5552, Model.Username, 5552, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5567, "/Tweets", 5567, 7, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-link text-muted\">Show all</a>\r\n                </div>\r\n                <div class=\"col-11 mx-auto\">\r\n");
#nullable restore
#line 80 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Profile\Index.cshtml"
                     foreach (var tweet in Model.Tweets)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div");
            BeginWriteAttribute("id", " id=\"", 5801, "\"", 5832, 2);
            WriteAttributeValue("", 5806, "view", 5806, 4, true);
#nullable restore
#line 82 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Profile\Index.cshtml"
WriteAttributeValue("", 5810, tweet.ID.ToString(), 5810, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            ");
#nullable restore
#line 83 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Profile\Index.cshtml"
                       Write(await Html.PartialAsync("PartialView/_DisplayTweet", Tuple.Create<User, Tweet>(Model, tweet)));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n");
#nullable restore
#line 85 "C:\Users\yunus\Desktop\wtech\final\Tvitter.Web\Tvitter.Web\Views\Profile\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<User> Html { get; private set; }
    }
}
#pragma warning restore 1591
