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
        [Display(Name = "Cliente")]
        public int ClientId { get; set; }
        [Display(Name = "Tipo de Servicio")]
        public int TypeServiceId { get; set; }
        [Display(Name = "Tipo de Carga")]
        public int TypeLoadId { get; set; }
        [Display(Name = "Tipo de Producto")]
        public int TypeProductId { get; set; }
        [Display(Name = "Descripcion")]
        public string Description { get; set; }
        [Display(Name = "Origen")]
        public int SourceId { get; set; }
        [Display(Name = "Destino")]
        public int DestinyId { get; set; }
        [Display(Name = "Unidad")]
        public int UnitId { get; set; }
        [Display(Name = "Moneda")]
        public int MoneyId { get; set; }
        [Display(Name = "Precio sin IGV")]
        [Required(ErrorMessage = "Este es obligatorio")]
        public decimal PriceWithoutVat { get; set; }
        [Display(Name = "Número de Contrato")]
        public string ContractNumber { get; set; }
        [Display(Name = "Expiracion de Contrato")]
        public string ContractExpiration { get; set; }

    }
}
