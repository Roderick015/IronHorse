using System;
using System.Collections.Generic;

#nullable disable

namespace IronHorseCore.Models
{
    public partial class Operation
    {
        public Operation()
        {
            Bills = new HashSet<Bill>();
            Driverexpenses = new HashSet<Driverexpense>();
            Tolls = new HashSet<Toll>();
        }

        public int Id { get; set; }
        public string MonthYear { get; set; }
        public int DriverId { get; set; }
        public int ClientId { get; set; }
        public int ClientrateId { get; set; }
        public DateTime? OutDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int TractoId { get; set; }
        public int CarretaId { get; set; }
        public DateTime? LoadDate { get; set; }
        public int CarrierId { get; set; }
        public int? OdometerBegin { get; set; }
        public int? OdometerEnd { get; set; }
        public float? UnitPay { get; set; }
        public float? Fuel { get; set; }
        public float? Capacity { get; set; }

        public virtual Truck Carreta { get; set; }
        public virtual Carrier Carrier { get; set; }
        public virtual Client Client { get; set; }
        public virtual Clientrate Clientrate { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Truck Tracto { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Driverexpense> Driverexpenses { get; set; }
        public virtual ICollection<Toll> Tolls { get; set; }
    }
}
