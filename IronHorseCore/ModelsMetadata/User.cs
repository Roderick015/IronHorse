using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IronHorseCore.Models
{
    [ModelMetadataType(typeof(UserMetaData))]
    public partial class User
    {
    }

    public interface UserMetaData
    {
        [Display(Name = "Tipo Doc.")]
        public string TypeDoc { get; set; }

        [Display(Name = "Numero Doc.")]
        public string NumberDoc { get; set; }

        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Celular")]
        public string CellPhone { get; set; }

        [Display(Name = "Telefono")]
        public string Phone { get; set; }

        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Ultimo Acceso")]
        public DateTime LastAccess { get; set; }

        [Display(Name = "Habilitado")]
        public bool Enabled { get; set; }

        [Display(Name = "Puesto")]
        public string Rol { get; set; }
    }
}
