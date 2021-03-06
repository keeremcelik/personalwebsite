#pragma checksum "C:\Users\90553\source\repos\WebUI\WebUI\Views\Blog\DetailProject.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1b5f3667544aaf534716f106f00f8d999768abde"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_DetailProject), @"mvc.1.0.view", @"/Views/Blog/DetailProject.cshtml")]
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
#line 1 "C:\Users\90553\source\repos\WebUI\WebUI\Views\_ViewImports.cshtml"
using WebUI;

#line default
#line hidden
#line 2 "C:\Users\90553\source\repos\WebUI\WebUI\Views\_ViewImports.cshtml"
using WebUI.Models;

#line default
#line hidden
#line 3 "C:\Users\90553\source\repos\WebUI\WebUI\Views\_ViewImports.cshtml"
using WebUI.Entity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b5f3667544aaf534716f106f00f8d999768abde", @"/Views/Blog/DetailProject.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fd4fbdbca56b0bec173417d3a8da59b6e37fb6a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Blog_DetailProject : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Project>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top image-cover image-cover"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onclick", new global::Microsoft.AspNetCore.Html.HtmlString("openImg(this)"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("myImg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-thumbnail image-cover"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("max-height:200px; min-height:200px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("200px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\90553\source\repos\WebUI\WebUI\Views\Blog\DetailProject.cshtml"
  
    ViewData["Title"] = "Blog Project detail";
    Layout = "_BlogLayout";

#line default
#line hidden
            WriteLiteral("\r\n\r\n<h1 class=\"mt-4\">");
#line 8 "C:\Users\90553\source\repos\WebUI\WebUI\Views\Blog\DetailProject.cshtml"
            Write(Model.Name);

#line default
#line hidden
            WriteLiteral("</h1>\r\n<p class=\"lead\">\r\n    by\r\n    <a href=\"#\">Kerem ÇELİK</a>\r\n</p>\r\n<hr />\r\n<p>Posted on <strong>");
#line 14 "C:\Users\90553\source\repos\WebUI\WebUI\Views\Blog\DetailProject.cshtml"
                Write(Model.Date.ToString("dddd, dd MMMM yyyy"));

#line default
#line hidden
            WriteLiteral(" </strong> </p>\r\n<hr />\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1b5f3667544aaf534716f106f00f8d999768abde6039", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 355, "~/img/projects/", 355, 15, true);
#line 16 "C:\Users\90553\source\repos\WebUI\WebUI\Views\Blog\DetailProject.cshtml"
AddHtmlAttributeValue("", 370, Model.ProjectId, 370, 16, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 386, "/", 386, 1, true);
#line 16 "C:\Users\90553\source\repos\WebUI\WebUI\Views\Blog\DetailProject.cshtml"
AddHtmlAttributeValue("", 387, ViewBag.CoverImage.Name, 387, 24, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 16 "C:\Users\90553\source\repos\WebUI\WebUI\Views\Blog\DetailProject.cshtml"
AddHtmlAttributeValue("", 418, Model.Name, 418, 11, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<hr />\r\n\r\n");
#line 19 "C:\Users\90553\source\repos\WebUI\WebUI\Views\Blog\DetailProject.cshtml"
Write(Html.Raw(Model.Content));

#line default
#line hidden
            WriteLiteral("\r\n\r\n<hr />\r\n<div class=\"row\">\r\n");
#line 23 "C:\Users\90553\source\repos\WebUI\WebUI\Views\Blog\DetailProject.cshtml"
     foreach (var item in ViewBag.image)
    {

#line default
#line hidden
            WriteLiteral("        <div class=\"col-md-3 mb-3\">\r\n            <div class=\"card\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1b5f3667544aaf534716f106f00f8d999768abde8749", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 677, "~/img/projects/", 677, 15, true);
#line 27 "C:\Users\90553\source\repos\WebUI\WebUI\Views\Blog\DetailProject.cshtml"
AddHtmlAttributeValue("", 692, Model.ProjectId, 692, 16, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 708, "/", 708, 1, true);
#line 27 "C:\Users\90553\source\repos\WebUI\WebUI\Views\Blog\DetailProject.cshtml"
AddHtmlAttributeValue("", 709, item.Name, 709, 10, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 27 "C:\Users\90553\source\repos\WebUI\WebUI\Views\Blog\DetailProject.cshtml"
AddHtmlAttributeValue("", 817, Model.Name, 817, 11, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n            </div>\r\n\r\n        </div>\r\n");
#line 32 "C:\Users\90553\source\repos\WebUI\WebUI\Views\Blog\DetailProject.cshtml"
    }

#line default
#line hidden
            WriteLiteral("</div>\r\n<div id=\"imgModal\" class=\"modal \" onclick=\"this.style.display=\'none\'\">\r\n    <span class=\"close\">&times;</span>\r\n    <img  id=\"imgModalImg\">\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Project> Html { get; private set; }
    }
}
#pragma warning restore 1591
