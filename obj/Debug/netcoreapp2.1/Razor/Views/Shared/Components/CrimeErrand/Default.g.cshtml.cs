#pragma checksum "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Shared\Components\CrimeErrand\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f6e5ba2518e087d01e0cef87f82c26c492cdd02"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_CrimeErrand_Default), @"mvc.1.0.view", @"/Views/Shared/Components/CrimeErrand/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/CrimeErrand/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_CrimeErrand_Default))]
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
#line 1 "C:\Users\jonas\source\repos\EnvironmentCrime\Views\_ViewImports.cshtml"
using EnvironmentCrime.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f6e5ba2518e087d01e0cef87f82c26c492cdd02", @"/Views/Shared/Components/CrimeErrand/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48ad61d0408a93f9778d393541101fee5a01c7e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_CrimeErrand_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Errand>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/imagetest.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("klicka på bilden"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(27, 14, true);
            WriteLiteral("\r\n<h3>Ärende: ");
            EndContext();
            BeginContext(42, 14, false);
#line 5 "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Shared\Components\CrimeErrand\Default.cshtml"
       Write(Model.ErrandID);

#line default
#line hidden
            EndContext();
            BeginContext(56, 173, true);
            WriteLiteral("</h3>\r\n\r\n<!--Nedan ser man en lista på ärenden-->\r\n<section id=\"leftColumn\">\r\n    <h3>Anmälan</h3>\r\n    <p>\r\n        <span class=\"label\">Typ av brott:</span><br />\r\n        ");
            EndContext();
            BeginContext(230, 17, false);
#line 12 "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Shared\Components\CrimeErrand\Default.cshtml"
   Write(Model.TypeOfCrime);

#line default
#line hidden
            EndContext();
            BeginContext(247, 85, true);
            WriteLiteral("\r\n    </p>\r\n    <p>\r\n        <span class=\"label\">Brottsplats: </span><br />\r\n        ");
            EndContext();
            BeginContext(333, 11, false);
#line 16 "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Shared\Components\CrimeErrand\Default.cshtml"
   Write(Model.Place);

#line default
#line hidden
            EndContext();
            BeginContext(344, 85, true);
            WriteLiteral("\r\n    </p>\r\n    <p>\r\n        <span class=\"label\">Brottsdatum: </span><br />\r\n        ");
            EndContext();
            BeginContext(430, 46, false);
#line 20 "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Shared\Components\CrimeErrand\Default.cshtml"
   Write(Model.DateOfObservation.ToString("yyyy/mm/dd"));

#line default
#line hidden
            EndContext();
            BeginContext(476, 82, true);
            WriteLiteral("\r\n    </p>\r\n    <p>\r\n        <span class=\"label\">Anmälare: </span><br />\r\n        ");
            EndContext();
            BeginContext(559, 18, false);
#line 24 "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Shared\Components\CrimeErrand\Default.cshtml"
   Write(Model.InformerName);

#line default
#line hidden
            EndContext();
            BeginContext(577, 81, true);
            WriteLiteral("\r\n    </p>\r\n    <p>\r\n        <span class=\"label\">Telefon: </span><br />\r\n        ");
            EndContext();
            BeginContext(659, 19, false);
#line 28 "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Shared\Components\CrimeErrand\Default.cshtml"
   Write(Model.InformerPhone);

#line default
#line hidden
            EndContext();
            BeginContext(678, 86, true);
            WriteLiteral("\r\n    </p>\r\n    <p>\r\n        <span class=\"label\">Observationer:</span><br />\r\n        ");
            EndContext();
            BeginContext(765, 17, false);
#line 32 "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Shared\Components\CrimeErrand\Default.cshtml"
   Write(Model.Observation);

#line default
#line hidden
            EndContext();
            BeginContext(782, 145, true);
            WriteLiteral("\r\n    </p>\r\n</section>\r\n\r\n<section id=\"rightColumn\">\r\n    <h3>Utredning</h3>\r\n    <p>\r\n        <span class=\"label\">Status:</span><br />\r\n        ");
            EndContext();
            BeginContext(928, 14, false);
#line 40 "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Shared\Components\CrimeErrand\Default.cshtml"
   Write(Model.StatusId);

#line default
#line hidden
            EndContext();
            BeginContext(942, 92, true);
            WriteLiteral("\r\n    </p>\r\n    <p>\r\n        <span class=\"label\">Ansvarig avdelning: </span><br />\r\n        ");
            EndContext();
            BeginContext(1035, 18, false);
#line 44 "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Shared\Components\CrimeErrand\Default.cshtml"
   Write(Model.DepartmentId);

#line default
#line hidden
            EndContext();
            BeginContext(1053, 85, true);
            WriteLiteral("\r\n    </p>\r\n    <p>\r\n        <span class=\"label\">Handläggare: </span><br />\r\n        ");
            EndContext();
            BeginContext(1139, 16, false);
#line 48 "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Shared\Components\CrimeErrand\Default.cshtml"
   Write(Model.EmployeeId);

#line default
#line hidden
            EndContext();
            BeginContext(1155, 197, true);
            WriteLiteral("\r\n    </p>\r\n    <p>\r\n        <span class=\"label\">Provtagning: </span><br />\r\n        Provtagning.pdf\r\n    </p>\r\n    <p>\r\n        <span class=\"label\">Ytterligare information: </span><br />\r\n        ");
            EndContext();
            BeginContext(1353, 22, false);
#line 56 "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Shared\Components\CrimeErrand\Default.cshtml"
   Write(Model.InvestigatorInfo);

#line default
#line hidden
            EndContext();
            BeginContext(1375, 83, true);
            WriteLiteral("\r\n    </p>\r\n    <p>\r\n        <span class=\"label\">Händelser: </span><br />\r\n        ");
            EndContext();
            BeginContext(1459, 24, false);
#line 60 "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Shared\Components\CrimeErrand\Default.cshtml"
   Write(Model.InvestigatorAction);

#line default
#line hidden
            EndContext();
            BeginContext(1483, 80, true);
            WriteLiteral("\r\n    </p>\r\n    <p>\r\n        <span class=\"label\">Bilder: </span><br />\r\n        ");
            EndContext();
            BeginContext(1563, 59, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a2121b57144d4397b1baf21191040f2e", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1622, 22, true);
            WriteLiteral("\r\n    </p>\r\n</section>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Errand> Html { get; private set; }
    }
}
#pragma warning restore 1591
