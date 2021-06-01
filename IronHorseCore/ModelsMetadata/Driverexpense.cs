using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace IronHorseCore.Models
{
    [ModelMetadataType(typeof(DriverexpenseMetaData))]
    public partial class Driverexpense
    {
    }

    public interface DriverexpenseMetaData
    {
        public int DriverId { get; set; }

        [Display(Name = "Tipo de Gasto")]
        public int TypeExpenseId { get; set; }

        [Display(Name = "Fecha")]
        public DateTime Date { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Display(Name = "Monto")]
        public float Amount { get; set; }

        public int OperacionDesignada { get; set; }
        public int AprobadoPor { get; set; }
        public int? OperationId { get; set; }
    }
}
