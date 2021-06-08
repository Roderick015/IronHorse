using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IronHorseCore.Models
{

    [ModelMetadataType(typeof(TollMetaData))]
    public partial class Toll
    {
    }

    public interface TollMetaData
    {
        [Display(Name = "Id Operacion")]
        public int OperationsId { get; set; }

        [Display(Name = "Fecha de pago")]
        public DateTime DatePay { get; set; }

        [Display(Name = "Pago")]
        public float Pay { get; set; }
    }
}
