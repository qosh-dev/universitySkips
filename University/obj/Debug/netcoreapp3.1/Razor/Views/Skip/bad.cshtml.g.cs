#pragma checksum "C:\Users\_qosh\Documents\C#\University\Views\Skip\bad.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e1b01f772a15804ce79ebae2f2b5bc20d6caba2c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Skip_bad), @"mvc.1.0.view", @"/Views/Skip/bad.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Skip/bad.cshtml", typeof(AspNetCore.Views_Skip_bad))]
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
#line 1 "C:\Users\_qosh\Documents\C#\University\Views\_ViewImports.cshtml"
using University;

#line default
#line hidden
#line 2 "C:\Users\_qosh\Documents\C#\University\Views\_ViewImports.cshtml"
using service.Main.Models;

#line default
#line hidden
#line 3 "C:\Users\_qosh\Documents\C#\University\Views\_ViewImports.cshtml"
using service.Skips.Models;

#line default
#line hidden
#line 4 "C:\Users\_qosh\Documents\C#\University\Views\_ViewImports.cshtml"
using service.Skips.ViewModels;

#line default
#line hidden
#line 5 "C:\Users\_qosh\Documents\C#\University\Views\_ViewImports.cshtml"
using service.Main.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1b01f772a15804ce79ebae2f2b5bc20d6caba2c", @"/Views/Skip/bad.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6dc94c88b8feda46bf734d03eeab4fe0f8b9052a", @"/Views/_ViewImports.cshtml")]
    public class Views_Skip_bad : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Group", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "desc", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\_qosh\Documents\C#\University\Views\Skip\bad.cshtml"
  
    var r16 = new {
        group = (List<Group>)Model.R16.id,
        data = (List<ReportToWorkSheet>)Model.R16.data
    };
    var r35 = new {
        group = (List<Group>)Model.R35.id,
        data = (List<ReportToWorkSheet>)Model.R35.data
    };

#line default
#line hidden
            BeginContext(265, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 12 "C:\Users\_qosh\Documents\C#\University\Views\Skip\bad.cshtml"
 if (r16.group.Count() != 0){

#line default
#line hidden
            BeginContext(298, 79, true);
            WriteLiteral("    <h4 style=\"float: right; margin-right:15px\">Студенты в желтом списке</h4>\r\n");
            EndContext();
            BeginContext(379, 279, true);
            WriteLiteral(@"    <table class=""table table-hover"" style=""margin-bottom: 50px"">
        <thead>
            <tr>
                <td>Название группы</td>
                <td>Количество штрафников</td>
                <td>Данные</td>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 24 "C:\Users\_qosh\Documents\C#\University\Views\Skip\bad.cshtml"
             for (int i = 0; i < r16.data.Count(); i++)
            {
                var href = $"/Skip/Report?id={@r16.group[i].Id}&eduYear={DateTime.Now.Year - r16.group[i].EduFrom + 1}&semester={lib.Methods.GetSemestry()}&fromCount=" + 16;

#line default
#line hidden
            BeginContext(905, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(977, 99, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e1b01f772a15804ce79ebae2f2b5bc20d6caba2c5724", async() => {
                BeginContext(1055, 17, false);
#line 29 "C:\Users\_qosh\Documents\C#\University\Views\Skip\bad.cshtml"
                                                                                                Write(r16.group[i].Name);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 29 "C:\Users\_qosh\Documents\C#\University\Views\Skip\bad.cshtml"
                                                                      WriteLiteral(r16.group[i].Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1076, 55, true);
            WriteLiteral("\r\n                    </td>\r\n\r\n                    <td>");
            EndContext();
            BeginContext(1132, 24, false);
#line 32 "C:\Users\_qosh\Documents\C#\University\Views\Skip\bad.cshtml"
                   Write(r16.data[i].data.Count());

#line default
#line hidden
            EndContext();
            BeginContext(1156, 61, true);
            WriteLiteral("</td>\r\n\r\n                    <td>\r\n                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1217, "\"", 1229, 1);
#line 35 "C:\Users\_qosh\Documents\C#\University\Views\Skip\bad.cshtml"
WriteAttributeValue("", 1224, href, 1224, 5, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1230, 62, true);
            WriteLiteral(">Отчет</a>\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 38 "C:\Users\_qosh\Documents\C#\University\Views\Skip\bad.cshtml"
            }

#line default
#line hidden
            BeginContext(1307, 32, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
            EndContext();
#line 41 "C:\Users\_qosh\Documents\C#\University\Views\Skip\bad.cshtml"

}

#line default
#line hidden
            BeginContext(1344, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 45 "C:\Users\_qosh\Documents\C#\University\Views\Skip\bad.cshtml"
 if (r35.group.Count() != 0){

#line default
#line hidden
            BeginContext(1379, 359, true);
            WriteLiteral(@"    <h4 style=""float: right; margin-right:15px"">Студенты в красном списке</h4>
    <table class=""table table-hover"" style=""margin-bottom: 50px"">
        <thead>
            <tr>
                <td>Название группы</td>
                <td>Количество штрафников</td>
                <td>Данные</td>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 56 "C:\Users\_qosh\Documents\C#\University\Views\Skip\bad.cshtml"
             for (int i = 0; i < r35.data.Count(); i++)
            {
                var href = $"/Skip/Report?id={@r35.group[i].Id}&eduYear={DateTime.Now.Year - r35.group[i].EduFrom + 1}&semester={lib.Methods.GetSemestry()}&fromCount=" + 35;

#line default
#line hidden
            BeginContext(1985, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2057, 99, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e1b01f772a15804ce79ebae2f2b5bc20d6caba2c10960", async() => {
                BeginContext(2135, 17, false);
#line 61 "C:\Users\_qosh\Documents\C#\University\Views\Skip\bad.cshtml"
                                                                                                Write(r35.group[i].Name);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 61 "C:\Users\_qosh\Documents\C#\University\Views\Skip\bad.cshtml"
                                                                      WriteLiteral(r35.group[i].Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2156, 55, true);
            WriteLiteral("\r\n                    </td>\r\n\r\n                    <td>");
            EndContext();
            BeginContext(2212, 24, false);
#line 64 "C:\Users\_qosh\Documents\C#\University\Views\Skip\bad.cshtml"
                   Write(r35.data[i].data.Count());

#line default
#line hidden
            EndContext();
            BeginContext(2236, 61, true);
            WriteLiteral("</td>\r\n\r\n                    <td>\r\n                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2297, "\"", 2309, 1);
#line 67 "C:\Users\_qosh\Documents\C#\University\Views\Skip\bad.cshtml"
WriteAttributeValue("", 2304, href, 2304, 5, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2310, 62, true);
            WriteLiteral(">Отчет</a>\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 70 "C:\Users\_qosh\Documents\C#\University\Views\Skip\bad.cshtml"
            }

#line default
#line hidden
            BeginContext(2387, 37, true);
            WriteLiteral("        </tbody>\r\n    </table>     \r\n");
            EndContext();
#line 73 "C:\Users\_qosh\Documents\C#\University\Views\Skip\bad.cshtml"
}

#line default
#line hidden
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
