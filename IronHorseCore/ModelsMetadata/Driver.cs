using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace IronHorseCore.Models
{
    [ModelMetadataType(typeof(DriverMetaData))]
    public partial class Driver
    {
    }

    public interface DriverMetaData
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string Name { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDay { get; set; }

        [Display(Name = "Licencia de conducir Número")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string LicenseDriverNumber { get; set; }

        [Display(Name = "Licencia de conducir Vencimiento")]
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime LicenseDriverValidaty { get; set; }

        [Display(Name = "Licencia de conducir 2 Número")]
        public string LicenseDriver2Number { get; set; }

        [Display(Name = "Licencia de conducir 2 Vencimiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? LicenseDriver2Validaty { get; set; }

        [Display(Name = "DNI")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string Dni { get; set; }

        [Display(Name = "DNI Vigencia")]
        [Required(ErrorMessage = "Campo Requerido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Dnivigencia { get; set; }

        [Display(Name = "IQPF")]
        public int Iqpf { get; set; }

        [Display(Name = "Cursos Portuarios")]
        public bool CursosPortuarios { get; set; }

        [Display(Name = "Cursos Portuarios Vigencia")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? CursosPortuariosVigencia { get; set; }

        [Display(Name = "Induccion Impala")]
        public bool InduccionImpala { get; set; }

        [Display(Name = "Habilitado")]
        public bool Status { get; set; }

        [Display(Name = "Inducción Impala Vigencia")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? InduccionImpalaVigencia { get; set; }

        [Display(Name = "Inducción Logisminsa")]
        public bool InduccionLogisminsa { get; set; }

        [Display(Name = "Inducción Logisminsa Vigencia")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? InduccionLogisminsaVigencia { get; set; }

        [Display(Name = "Induccion Perubar")]
        public bool InduccionPerubar { get; set; }

        [Display(Name = "Induccion Perubar Vigencia")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? InduccionPerubarVigencia { get; set; }

        [Display(Name = "Induccion Shouxin")]
        public bool InduccionShouxin { get; set; }

        [Display(Name = "Induccion Shouxin Vigencia")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime InduccionShouxinVigencia { get; set; }

        [Display(Name = "Induccion Tisur")]
        public bool InduccionTisur { get; set; }

        [Display(Name = "Induccion Ransa")]
        public bool InduccionRansa { get; set; }

        [Display(Name = "Induccion Aceros A")]
        public bool InduccionAcerosA { get; set; }

    }
}
