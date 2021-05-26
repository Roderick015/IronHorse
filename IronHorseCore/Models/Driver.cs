using System;
using System.Collections.Generic;

#nullable disable

namespace IronHorseCore.Models
{
    public partial class Driver
    {
        public Driver()
        {
            Driverexpenses = new HashSet<Driverexpense>();
            Operations = new HashSet<Operation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public bool Status { get; set; }
        public string Dni { get; set; }
        public DateTime Dnivigencia { get; set; }
        public string LicenseDriverNumber { get; set; }
        public DateTime LicenseDriverValidaty { get; set; }
        public string LicenseDriver2Number { get; set; }
        public DateTime? LicenseDriver2Validaty { get; set; }
        public bool Iqpf { get; set; }
        public bool CursosPortuarios { get; set; }
        public DateTime? CursosPortuariosVigencia { get; set; }
        public bool InduccionImpala { get; set; }
        public DateTime? InduccionImpalaVigencia { get; set; }
        public bool InduccionLogisminsa { get; set; }
        public DateTime? InduccionLogisminsaVigencia { get; set; }
        public bool InduccionPerubar { get; set; }
        public DateTime? InduccionPerubarVigencia { get; set; }
        public bool InduccionShouxin { get; set; }
        public DateTime? InduccionShouxinVigencia { get; set; }
        public bool InduccionTisur { get; set; }
        public bool InduccionRansa { get; set; }
        public bool InduccionAcerosA { get; set; }
        public string UniqueId { get; set; }
        public string MetaAuth { get; set; }
        public bool IsRemoved { get; set; }

        public virtual ICollection<Driverexpense> Driverexpenses { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
