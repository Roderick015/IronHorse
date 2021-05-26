using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace IronHorseCore.Models
{

    [ModelMetadataType(typeof(ClientrateMetaData))]
    public partial class Clientrate
    {
    }

    public interface ClientrateMetaData
        {

        public int ClientId { get; set; }

        [Display(Name = "Tipo de Servicio")]
        public string TypeService { get; set; }

        [Display(Name = "Unidad de pago")]
        public string BillableUnit { get; set; }

        [Display(Name = "Habilitado")]
        public string CollectionUnit { get; set; }

        [Display(Name = "Precio sin IGV")]
        public string PriceWithoutVat { get; set; }

        [Display(Name = "Número de Contrato")]
        public string ContractNumber { get; set; }

        [Display(Name = "Expiracion de Contrato")]
        public string ContractExpiration { get; set; }

        [Display(Name = "Moneda")]
        public string Currency { get; set; }
    }
}
