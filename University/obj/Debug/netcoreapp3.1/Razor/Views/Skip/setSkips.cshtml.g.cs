#pragma checksum "C:\Users\_qosh\Documents\C#\University\Views\Skip\setSkips.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc83102f23ae8a5042d87c4838c93d6c81c70fa2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Skip_setSkips), @"mvc.1.0.view", @"/Views/Skip/setSkips.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Skip/setSkips.cshtml", typeof(AspNetCore.Views_Skip_setSkips))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc83102f23ae8a5042d87c4838c93d6c81c70fa2", @"/Views/Skip/setSkips.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6dc94c88b8feda46bf734d03eeab4fe0f8b9052a", @"/Views/_ViewImports.cshtml")]
    public class Views_Skip_setSkips : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Group>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("padding: 20px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Skip", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "setSkips", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/groupByDep.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            DefineSection("CSS", async() => {
                BeginContext(28, 118, true);
                WriteLiteral("\r\n    <style>\r\n        li{\r\n            margin-top: 10px;\r\n            margin-bottom: 10px;\r\n        }\r\n    </style>\r\n");
                EndContext();
            }
            );
            BeginContext(226, 34, true);
            WriteLiteral("\r\n            <hr />\r\n            ");
            EndContext();
            BeginContext(260, 2411, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc83102f23ae8a5042d87c4838c93d6c81c70fa26270", async() => {
                BeginContext(362, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(380, 47, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc83102f23ae8a5042d87c4838c93d6c81c70fa26668", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#line 18 "C:\Users\_qosh\Documents\C#\University\Views\Skip\setSkips.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(427, 177, true);
                WriteLiteral("\r\n                <p style=\"font-size: 18px; margin:auto 15%; padding-bottom: 25px\">\r\n                    <b> Форма для добавления пропусков в группу :</b>\r\n                    ");
                EndContext();
                BeginContext(605, 10, false);
#line 21 "C:\Users\_qosh\Documents\C#\University\Views\Skip\setSkips.cshtml"
               Write(Model.Name);

#line default
#line hidden
                EndContext();
                BeginContext(615, 34, true);
                WriteLiteral(" <span style=\"font-size: small;\">(");
                EndContext();
                BeginContext(650, 13, false);
#line 21 "C:\Users\_qosh\Documents\C#\University\Views\Skip\setSkips.cshtml"
                                                            Write(Model.EduFrom);

#line default
#line hidden
                EndContext();
                BeginContext(663, 65, true);
                WriteLiteral(")</span>  \r\n                    <span style=\"font-size: 12px;\">\r\n");
                EndContext();
                BeginContext(797, 216, true);
                WriteLiteral("                    </span>    \r\n                </p>\r\n                <ul style=\"margin-left: 20px;\" >\r\n                    <li>Год обучения : \r\n                        <select name=\"eduYear\" style=\"width: 40px;\">\r\n");
                EndContext();
#line 29 "C:\Users\_qosh\Documents\C#\University\Views\Skip\setSkips.cshtml"
                         for (int i = 1; i < Model.EduDuration +1; i++)
                        {
                            

#line default
#line hidden
#line 31 "C:\Users\_qosh\Documents\C#\University\Views\Skip\setSkips.cshtml"
                             if(i == Model.Course){

#line default
#line hidden
                BeginContext(1166, 32, true);
                WriteLiteral("                                ");
                EndContext();
                BeginContext(1198, 39, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc83102f23ae8a5042d87c4838c93d6c81c70fa210248", async() => {
                    BeginContext(1227, 1, false);
#line 32 "C:\Users\_qosh\Documents\C#\University\Views\Skip\setSkips.cshtml"
                                                       Write(i);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                BeginWriteTagHelperAttribute();
#line 32 "C:\Users\_qosh\Documents\C#\University\Views\Skip\setSkips.cshtml"
                                            WriteLiteral(i);

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
                BeginContext(1237, 7, true);
                WriteLiteral("     \r\n");
                EndContext();
#line 33 "C:\Users\_qosh\Documents\C#\University\Views\Skip\setSkips.cshtml"
                            } else{

#line default
#line hidden
                BeginContext(1281, 32, true);
                WriteLiteral("                                ");
                EndContext();
                BeginContext(1313, 31, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc83102f23ae8a5042d87c4838c93d6c81c70fa212883", async() => {
                    BeginContext(1334, 1, false);
#line 34 "C:\Users\_qosh\Documents\C#\University\Views\Skip\setSkips.cshtml"
                                               Write(i);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 34 "C:\Users\_qosh\Documents\C#\University\Views\Skip\setSkips.cshtml"
                                    WriteLiteral(i);

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
                BeginContext(1344, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 35 "C:\Users\_qosh\Documents\C#\University\Views\Skip\setSkips.cshtml"
                            }

#line default
#line hidden
#line 35 "C:\Users\_qosh\Documents\C#\University\Views\Skip\setSkips.cshtml"
                             
                        }

#line default
#line hidden
                BeginContext(1404, 104, true);
                WriteLiteral("                        </select>    \r\n                    </li>\r\n\r\n                    <li>Семестр : \r\n");
                EndContext();
#line 41 "C:\Users\_qosh\Documents\C#\University\Views\Skip\setSkips.cshtml"
                         if(Model.Semester == 1){

#line default
#line hidden
                BeginContext(1559, 96, true);
                WriteLiteral("                            <label for=\"r1\" ><input id=\"r1\" type=\"radio\" checked name=\"semester\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1655, "\"", 1678, 1);
#line 42 "C:\Users\_qosh\Documents\C#\University\Views\Skip\setSkips.cshtml"
WriteAttributeValue("", 1663, Model.Semester, 1663, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1679, 133, true);
                WriteLiteral(">Первый</label>\r\n                            <label for=\"r2\" ><input id=\"r2\" type=\"radio\" name=\"semester\" value=\"2\"> Второй</label>\r\n");
                EndContext();
#line 44 "C:\Users\_qosh\Documents\C#\University\Views\Skip\setSkips.cshtml"
                        } else{

#line default
#line hidden
                BeginContext(1845, 211, true);
                WriteLiteral("                            <label for=\"r1\" ><input id=\"r1\" type=\"radio\" name=\"semester\" value=\"1\">Первый</label>\r\n                            <label for=\"r2\" ><input id=\"r2\" type=\"radio\" checked name=\"semester\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2056, "\"", 2079, 1);
#line 46 "C:\Users\_qosh\Documents\C#\University\Views\Skip\setSkips.cshtml"
WriteAttributeValue("", 2064, Model.Semester, 2064, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2080, 17, true);
                WriteLiteral(">Второй</label>\r\n");
                EndContext();
#line 47 "C:\Users\_qosh\Documents\C#\University\Views\Skip\setSkips.cshtml"
                        }

#line default
#line hidden
                BeginContext(2124, 286, true);
                WriteLiteral(@"                    </li>

                    <li id=""month"">
                    </li>

                </ul>
                

                <p></p>
                <p style=""font-size: 13px;"">Выберите файл</p>
                <input style="""" type=""hidden"" name=""groupId""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2410, "\"", 2427, 1);
#line 58 "C:\Users\_qosh\Documents\C#\University\Views\Skip\setSkips.cshtml"
WriteAttributeValue("", 2418, Model.Id, 2418, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2428, 236, true);
                WriteLiteral(">\r\n                <input style=\"float: left;margin-right: 15px;\" type=\"file\" name=\"file\" id=\"id\">\r\n                \r\n                <input style=\"float: left; margin-left: 15px; \" type=\"submit\"  value=\"Отправить в базу\">\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2671, 26, true);
            WriteLiteral("\r\n            <hr />\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(2714, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(2720, 68, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc83102f23ae8a5042d87c4838c93d6c81c70fa220309", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#line 67 "C:\Users\_qosh\Documents\C#\University\Views\Skip\setSkips.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2788, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Group> Html { get; private set; }
    }
}
#pragma warning restore 1591
