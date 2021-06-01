using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IronHorseCore.Models
{
    [ModelMetadataType(typeof(TypeexpenseMetaData))]
    public partial class Typeexpense
    {
    }

    public interface TypeexpenseMetaData
    {
        [Display(Name = "Gasto")]
        public string Name { get; set; }
    }
}
