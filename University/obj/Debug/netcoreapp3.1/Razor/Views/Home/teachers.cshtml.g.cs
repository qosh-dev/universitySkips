#pragma checksum "C:\Users\_qosh\Documents\C#\University\Views\Home\teachers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6b36b0104c19d2b3de087d8edea460be078f0d93"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_teachers), @"mvc.1.0.view", @"/Views/Home/teachers.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/teachers.cshtml", typeof(AspNetCore.Views_Home_teachers))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b36b0104c19d2b3de087d8edea460be078f0d93", @"/Views/Home/teachers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6dc94c88b8feda46bf734d03eeab4fe0f8b9052a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_teachers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Teacher[]>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(18, 10, true);
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n");
            EndContext();
#line 7 "C:\Users\_qosh\Documents\C#\University\Views\Home\teachers.cshtml"
 if(Model.Count() != 0){


#line default
#line hidden
            BeginContext(56, 147, true);
            WriteLiteral("<h4 style=\"float: right; margin-right:15px\">Список работников</h4>\r\n<table class=\"table table-hover\" style=\"margin-bottom: 50px\">\r\n\r\n\r\n\r\n</table>\r\n");
            EndContext();
#line 15 "C:\Users\_qosh\Documents\C#\University\Views\Home\teachers.cshtml"



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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Teacher[]> Html { get; private set; }
    }
}
#pragma warning restore 1591
