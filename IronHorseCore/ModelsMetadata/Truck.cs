using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IronHorseCore.Models
{
    [ModelMetadataType(typeof(TruckMetaData))]
    public partial class Truck
    {
    }

    public interface TruckMetaData
    {
        [Display(Name = "Transportista")]
        public int? CarrierId { get; set; }

        [Display(Name = "Estado")]
        public bool Status { get; set; }

        [Display(Name = "Remolque")]
        public bool IsRemolcado { get; set; }

        [Display(Name = "Semiremolque")]
        public bool IsSemiremolque { get; set; }

        [Display(Name = "Tipo Semiremolque")]
        public string SemiremolqueTipo { get; set; }

        [Display(Name = "Placa")]
        public string Placa { get; set; }

        [Display(Name = "Numero de Soat")]
        public string Soatnumero { get; set; }

        [Display(Name = "Fecha de Vigencia de Soat")]
        public DateTime? Soatvigencia { get; set; }

        [Display(Name = "Numero de Poliza")]
        public string PolizaNro { get; set; }

        [Display(Name = "Fecha de Vigencia de Poliza")]
        public DateTime? PolizaVigencia { get; set; }

        [Display(Name = "Fecha de Vigencia de Poliza de Accidentes Personales")]
        public DateTime? PolizaAccidentesPersonalesVigencia { get; set; }

        [Display(Name = "Fecha de Vigencia de Poliza de Seguro Trec")]
        public DateTime? PolizaSeguroTrecVigencia { get; set; }

        [Display(Name = "Numero de Revision Tecnica")]
        public string RevisionTecnicaNro { get; set; }

        [Display(Name = "Fecha de Vigencia de Revision Tecnica")]
        public DateTime? RevisionTecnicaVigencia { get; set; }

        [Display(Name = "Fecha de Vigencia de Checklist Inspeccion General")]
        public DateTime? CkecklistInspeccionGeneralVigencia { get; set; }

        [Display(Name = "Proveedor de GPS")]
        public string Gpsproveedor { get; set; }

        [Display(Name = "Fecha de Certificado de instalacion de GPS")]
        public DateTime? GpscertificadoInstalacion { get; set; }

        [Display(Name = "Fecha de Vigencia de Tarjeta de Circulacion")]
        public DateTime? TarjetaCirualacionVigencia { get; set; }

        [Display(Name = "Fecha de Vigencia de Tarjeta de Mercaderia")]
        public DateTime? TarjetaMercaderiaVigencia { get; set; }

        [Display(Name = "Propietario")]
        public string Propietario { get; set; }

        [Display(Name = "Bonificacion de Pesos y Medidas")]
        public string BonificacionPesosMedidas { get; set; }

        [Display(Name = "Bonificacion de Matpel")]
        public string BonifacionMatpel { get; set; }

    }
}
