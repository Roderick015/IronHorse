#pragma checksum "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8b955d82efa989ebcc414e50b80d3d55dbe63219"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Trucks_Details), @"mvc.1.0.view", @"/Views/Trucks/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b955d82efa989ebcc414e50b80d3d55dbe63219", @"/Views/Trucks/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18f941ddcd1d2d6985a91c2414a3462d83ced358", @"/Views/_ViewImports.cshtml")]
    public class Views_Trucks_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IronHorseCore.Models.Truck>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n");
#nullable restore
#line 3 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
   ViewData["Title"] = "Details"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div>\n    <h4>Tracto/Carreta</h4>\n    <hr />\n    <dl class=\"row\">\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 10 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CarrierId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 13 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayFor(model => model.Carrier.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 16 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 19 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayFor(model => model.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 22 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IsRemolcado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 25 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayFor(model => model.IsRemolcado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 28 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IsSemiremolque));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 31 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayFor(model => model.IsSemiremolque));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 34 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SemiremolqueTipo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 37 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayFor(model => model.SemiremolqueTipo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 40 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Placa));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 43 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayFor(model => model.Placa));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 46 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Soatnumero));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 49 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayFor(model => model.Soatnumero));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 52 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Soatvigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 55 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayFor(model => model.Soatvigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 58 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PolizaNro));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 61 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayFor(model => model.PolizaNro));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 64 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PolizaVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 67 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayFor(model => model.PolizaVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 70 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PolizaAccidentesPersonalesVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 73 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayFor(model => model.PolizaAccidentesPersonalesVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 76 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PolizaSeguroTrecVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 79 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayFor(model => model.PolizaSeguroTrecVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 82 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.RevisionTecnicaNro));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 85 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayFor(model => model.RevisionTecnicaNro));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 88 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.RevisionTecnicaVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 91 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayFor(model => model.RevisionTecnicaVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 94 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CkecklistInspeccionGeneralVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 97 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayFor(model => model.CkecklistInspeccionGeneralVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 100 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Gpsproveedor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 103 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayFor(model => model.Gpsproveedor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 106 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.GpscertificadoInstalacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 109 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayFor(model => model.GpscertificadoInstalacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 112 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TarjetaCirualacionVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 115 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayFor(model => model.TarjetaCirualacionVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 118 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TarjetaMercaderiaVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 121 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayFor(model => model.TarjetaMercaderiaVigencia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 124 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Propietario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 127 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayFor(model => model.Propietario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 130 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BonificacionPesosMedidas));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 133 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayFor(model => model.BonificacionPesosMedidas));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n        <dt class=\"col-sm-2\">\n            ");
#nullable restore
#line 136 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BonifacionMatpel));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dt>\n        <dd class=\"col-sm-10\">\n            ");
#nullable restore
#line 139 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
       Write(Html.DisplayFor(model => model.BonifacionMatpel));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n    </dl>\n</div>\n<div>\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b955d82efa989ebcc414e50b80d3d55dbe6321918003", async() => {
                WriteLiteral("Editar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 144 "D:\AgileCorp\Proyectos\IronHorse\IronHorseCore\Views\Trucks\Details.cshtml"
                           WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
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
            WriteLiteral(" |\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b955d82efa989ebcc414e50b80d3d55dbe6321920142", async() => {
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
            WriteLiteral("\n</div>\n");
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