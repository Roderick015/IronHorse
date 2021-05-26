using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace IronHorseCore.Models
{
    [ModelMetadataType(typeof(OperationMetaData))]
    public partial class Operation
    {
    }

    public interface OperationMetaData
    {
        public string Mes { get; set; }
        [Display(Name = "Cliente")]
        public int ClientId { get; set; }

        [Display(Name = "Transportista")]
        public int CarrierId { get; set; }
        [Display(Name = "Tipo de Carga")]
        public int TypeLoadId { get; set; }
        [Display(Name = "Tipo de Producto")]
        public int TypeProductId { get; set; }

        [Display(Name = "Fecha carguio")]
        public DateTime? LoadDate { get; set; }
        [Display(Name = "Fecha salida")]
        public DateTime? OutDate { get; set; }
        [Display(Name = "Fecha Fin")]
        public DateTime? EndDate { get; set; }


        [Display(Name = "Origen")]
        public int SourceId { get; set; }
        [Display(Name = "Destino")]
        public int DestinyId { get; set; }


        [Display(Name = "Conductor")]
        public int DriverId { get; set; }
        [Display(Name = "Tracto")]
        public int TractoId { get; set; }
        [Display(Name = "Carreta")]
        public int CarretaId { get; set; }

        [Display(Name = "Und de Cobro")]
        public int UnitId { get; set; }
        [Display(Name = "Dato Und de Cobro")]
        public float? UnitPay { get; set; }
        [Display(Name = "Moneda")]
        public int MoneyId { get; set; }







        [Display(Name = "Odometro inicio")]
        public int OdometerBegin { get; set; }
        [Display(Name = "Odometro final")]
        public int OdometerEnd { get; set; }
        [Display(Name = "Combustible GL")]
        public float? Fuel { get; set; }


    }
}
