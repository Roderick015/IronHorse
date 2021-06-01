using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IronHorseCore.Models
{
    [ModelMetadataType(typeof(BillMetaData))]
    public partial class Bill
    {
    }

    public interface BillMetaData
    {
        [Display(Name = "Operación")]
        public int OperationId { get; set; }

        [Display(Name = "Numero de Serie")]
        public string SerialNumber { get; set; }

        [Display(Name = "Fecha de pago")]
        public DateTime? Datepay { get; set; }

        [Display(Name = "Estado de Factura")]
        public int? Status { get; set; }

        [Display(Name = "Total")]
        public decimal? Total { get; set; }
    }
}
