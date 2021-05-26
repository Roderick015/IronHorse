using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IronHorseCore.Models
{
    [ModelMetadataType(typeof(ClientMetaData))]
    public partial class Client
    {
    }

    public interface ClientMetaData
    {
        [Display(Name = "Razón Social")]
        public string Name { get; set; }

        [Display(Name = "RUC")]
        public string Code { get; set; }

        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Display(Name = "Contacto")]
        public string Contact { get; set; }

        [Display(Name = "Contacto Celular")]
        public string ContactPhone { get; set; }

        [Display(Name = "Contacto Email")]
        public string ContactEmail { get; set; }

        [Display(Name = "Habilitado")]
        public bool Enabled { get; set; }
    }
}
