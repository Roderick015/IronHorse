#pragma checksum "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6f0f52dc07339162e63a6925187a54ae5945521b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Trucks_Delete), @"mvc.1.0.view", @"/Views/Trucks/Delete.cshtml")]
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
#line 1 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\_ViewImports.cshtml"
using IronHorseCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\_ViewImports.cshtml"
using IronHorseCore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f0f52dc07339162e63a6925187a54ae5945521b", @"/Views/Trucks/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18f941ddcd1d2d6985a91c2414a3462d83ced358", @"/Views/_ViewImports.cshtml")]
    public class Views_Trucks_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IronHorseCore.Models.Truck>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
   ViewData["Title"] = "Delete"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div>\n    <h4>Eliminar Tracto/Carreta</h4>\n    <h6 class=\"text-danger\">¿Estás seguro de que quieres eliminar esto?</h6>\n    <hr />\n    <dl class=\"row\">\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 11 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.CarrierId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 14 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Carrier.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 17 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 20 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 23 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IsRemolcado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 26 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IsRemolcado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 29 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IsSemiremolque));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 32 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IsSemiremolque));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 35 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.SemiremolqueTipo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 38 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayFor(model => model.SemiremolqueTipo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 41 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Placa));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 44 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Placa));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 47 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Soatnumero));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 50 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Soatnumero));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 53 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Soatvigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 56 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Soatvigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 59 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.PolizaNro));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 62 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayFor(model => model.PolizaNro));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 65 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.PolizaVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 68 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayFor(model => model.PolizaVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 71 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.PolizaAccidentesPersonalesVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 74 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayFor(model => model.PolizaAccidentesPersonalesVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 77 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.PolizaSeguroTrecVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 80 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayFor(model => model.PolizaSeguroTrecVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 83 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.RevisionTecnicaNro));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 86 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayFor(model => model.RevisionTecnicaNro));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 89 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.RevisionTecnicaVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 92 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayFor(model => model.RevisionTecnicaVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 95 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.CkecklistInspeccionGeneralVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 98 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayFor(model => model.CkecklistInspeccionGeneralVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 101 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Gpsproveedor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 104 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Gpsproveedor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 107 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.GpscertificadoInstalacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 110 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayFor(model => model.GpscertificadoInstalacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 113 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TarjetaCirualacionVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 116 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayFor(model => model.TarjetaCirualacionVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 119 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TarjetaMercaderiaVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 122 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayFor(model => model.TarjetaMercaderiaVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 125 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Propietario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 128 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Propietario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 131 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.BonificacionPesosMedidas));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 134 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayFor(model => model.BonificacionPesosMedidas));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 137 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.BonifacionMatpel));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 140 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
       Write(Html.DisplayFor(model => model.BonifacionMatpel));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n    </dl>\n\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6f0f52dc07339162e63a6925187a54ae5945521b18737", async() => {
                WriteLiteral("\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6f0f52dc07339162e63a6925187a54ae5945521b19002", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 145 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n        <input type=\"submit\" value=\"Eliminar\" class=\"btn btn-danger\" /> |\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6f0f52dc07339162e63a6925187a54ae5945521b20782", async() => {
                    WriteLiteral("Regresar");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IronHorseCore.Models.Truck> Html { get; private set; }
    }
}
#pragma warning restore 1591