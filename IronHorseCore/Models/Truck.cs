using System;
using System.Collections.Generic;

#nullable disable

namespace IronHorseCore.Models
{
    public partial class Truck
    {
        public Truck()
        {
            OperationCarreta = new HashSet<Operation>();
            OperationTractos = new HashSet<Operation>();
        }

        public int Id { get; set; }
        public bool Status { get; set; }
        public bool IsRemolcado { get; set; }
        public bool IsSemiremolque { get; set; }
        public string SemiremolqueTipo { get; set; }
        public string Placa { get; set; }
        public string Soatnumero { get; set; }
        public DateTime? Soatvigencia { get; set; }
        public string PolizaNro { get; set; }
        public DateTime? PolizaVigencia { get; set; }
        public DateTime? PolizaAccidentesPersonalesVigencia { get; set; }
        public DateTime? PolizaSeguroTrecVigencia { get; set; }
        public string RevisionTecnicaNro { get; set; }
        public DateTime? RevisionTecnicaVigencia { get; set; }
        public DateTime? CkecklistInspeccionGeneralVigencia { get; set; }
        public string Gpsproveedor { get; set; }
        public DateTime? GpscertificadoInstalacion { get; set; }
        public DateTime? TarjetaCirualacionVigencia { get; set; }
        public DateTime? TarjetaMercaderiaVigencia { get; set; }
        public string Propietario { get; set; }
        public string BonificacionPesosMedidas { get; set; }
        public string BonifacionMatpel { get; set; }

        public virtual ICollection<Operation> OperationCarreta { get; set; }
        public virtual ICollection<Operation> OperationTractos { get; set; }
    }
}
