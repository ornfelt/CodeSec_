#pragma checksum "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Investigator\StartInvestigator.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "420706d58183e0e1686b3055b3e471497346710d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Investigator_StartInvestigator), @"mvc.1.0.view", @"/Views/Investigator/StartInvestigator.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Investigator/StartInvestigator.cshtml", typeof(AspNetCore.Views_Investigator_StartInvestigator))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"420706d58183e0e1686b3055b3e471497346710d", @"/Views/Investigator/StartInvestigator.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48ad61d0408a93f9778d393541101fee5a01c7e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Investigator_StartInvestigator : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnvironmentRepository>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("reports"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Investigator", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "StartInvestigator", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("logout"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("selected", new global::Microsoft.AspNetCore.Html.HtmlString("selected"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CrimeInvestigator", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Investigator\StartInvestigator.cshtml"
  
    Layout = "_LoggedInLayout";
    

#line default
#line hidden
            BeginContext(75, 2355, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "82777d4ece8e4989b54daec73647e31f", async() => {
                BeginContext(81, 43, true);
                WriteLiteral("\r\n    <nav>\r\n        <ul>\r\n            <li>");
                EndContext();
                BeginContext(124, 98, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fbcf7287942e48d98f795df8f7737604", async() => {
                    BeginContext(204, 14, true);
                    WriteLiteral("Start(Ärenden)");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(222, 37, true);
                WriteLiteral("</li>\r\n            <li class=\"right\">");
                EndContext();
                BeginContext(259, 71, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9a8f86232a04431eb130d2a28a20edb0", async() => {
                    BeginContext(318, 8, true);
                    WriteLiteral("Logga ut");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(330, 516, true);
                WriteLiteral(@"</li>
        </ul>
    </nav><!-- End Nav -->

    <div id=""content"">
        <h2>Ärenden</h2>
        <p class=""info"">Du är inloggad som handläggare</p>

        <table id=""managerForm"">
            <tr>
                <td class=""label"">Välj status:</td>
                <td>&nbsp;</td>
                <td class=""label"">Ärendenummer:</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <select name=""status"">
                        ");
                EndContext();
                BeginContext(846, 46, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "59429d8d5fe3445aa9891ce066b851bc", async() => {
                    BeginContext(874, 9, true);
                    WriteLiteral("Välj alla");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(892, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 28 "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Investigator\StartInvestigator.cshtml"
                         foreach (ErrandStatus errandstatus in Model.ErrandStatuses)
                        {

#line default
#line hidden
                BeginContext(1007, 28, true);
                WriteLiteral("                            ");
                EndContext();
                BeginContext(1035, 72, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fd8534435ae9442dbb7eb94abf029ddc", async() => {
                    BeginContext(1075, 23, false);
#line 30 "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Investigator\StartInvestigator.cshtml"
                                                              Write(errandstatus.StatusName);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 30 "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Investigator\StartInvestigator.cshtml"
                              WriteLiteral(errandstatus.StatusName);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1107, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 31 "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Investigator\StartInvestigator.cshtml"
                        }

#line default
#line hidden
                BeginContext(1136, 646, true);
                WriteLiteral(@"                    </select>
                </td>
                <td><input class=""button"" type=""submit"" value=""Hämta lista"" /></td>
                <td><input name=""casenumber"" /></td>
                <td><input class=""button"" type=""submit"" value=""Sök"" /></td>
            </tr>
        </table>

        <!--Nedan ser man en lista på ärenden-->
        <table>
            <tr>
                <th>Ärende anmält</th>
                <th>Ärendenummer</th>
                <th>Miljöbrott</th>
                <th>Status</th>
                <th>Avdelning</th>
                <th>Handläggare</th>
            </tr>
        
");
                EndContext();
#line 51 "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Investigator\StartInvestigator.cshtml"
             foreach (Errand errand in Model.Errands)
            {

#line default
#line hidden
                BeginContext(1852, 30, true);
                WriteLiteral("        <tr>\r\n            <td>");
                EndContext();
                BeginContext(1883, 47, false);
#line 54 "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Investigator\StartInvestigator.cshtml"
           Write(errand.DateOfObservation.ToString("yyyy/mm/dd"));

#line default
#line hidden
                EndContext();
                BeginContext(1930, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(1953, 116, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "72fa6a18813a44299afb3bc176db4ac9", async() => {
                    BeginContext(2050, 15, false);
#line 55 "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Investigator\StartInvestigator.cshtml"
                                                                                                           Write(errand.ErrandID);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 55 "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Investigator\StartInvestigator.cshtml"
                                                                                  WriteLiteral(errand.ErrandID);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2069, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(2093, 18, false);
#line 56 "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Investigator\StartInvestigator.cshtml"
           Write(errand.TypeOfCrime);

#line default
#line hidden
                EndContext();
                BeginContext(2111, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(2135, 15, false);
#line 57 "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Investigator\StartInvestigator.cshtml"
           Write(errand.StatusId);

#line default
#line hidden
                EndContext();
                BeginContext(2150, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(2174, 19, false);
#line 58 "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Investigator\StartInvestigator.cshtml"
           Write(errand.DepartmentId);

#line default
#line hidden
                EndContext();
                BeginContext(2193, 23, true);
                WriteLiteral("</td>\r\n            <td>");
                EndContext();
                BeginContext(2217, 17, false);
#line 59 "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Investigator\StartInvestigator.cshtml"
           Write(errand.EmployeeId);

#line default
#line hidden
                EndContext();
                BeginContext(2234, 22, true);
                WriteLiteral("</td>\r\n        </tr>\r\n");
                EndContext();
#line 61 "C:\Users\jonas\source\repos\EnvironmentCrime\Views\Investigator\StartInvestigator.cshtml"
            }

#line default
#line hidden
                BeginContext(2271, 152, true);
                WriteLiteral("        \r\n    </table>\r\n\r\n        <footer>\r\n            &copy; Småstads Kommun All rights reserved.\r\n        </footer>\r\n    </div><!-- End Content -->\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnvironmentRepository> Html { get; private set; }
    }
}
#pragma warning restore 1591
