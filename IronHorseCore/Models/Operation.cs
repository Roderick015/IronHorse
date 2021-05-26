using System;
using System.Collections.Generic;

#nullable disable

namespace IronHorseCore.Models
{
    public partial class Operation
    {
        public Operation()
        {
            Driverexpenses = new HashSet<Driverexpense>();
        }

        public int Id { get; set; }
        public string Mes { get; set; }
        public int DriverId { get; set; }
        public int TypeLoadId { get; set; }
        public int ClientId { get; set; }
        public int TypeProductId { get; set; }
        public DateTime? OutDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int SourceId { get; set; }
        public int DestinyId { get; set; }
        public int TractoId { get; set; }
        public int CarretaId { get; set; }
        public int UnitId { get; set; }
        public int MoneyId { get; set; }
        public DateTime? LoadDate { get; set; }
        public int CarrierId { get; set; }
        public int OdometerBegin { get; set; }
        public int OdometerEnd { get; set; }
        public float UnitPay { get; set; }
        public float? Fuel { get; set; }

        public virtual Truck Carreta { get; set; }
        public virtual Carrier Carrier { get; set; }
        public virtual Client Client { get; set; }
        public virtual Place Destiny { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Money Money { get; set; }
        public virtual Place Source { get; set; }
        public virtual Truck Tracto { get; set; }
        public virtual Typeload TypeLoad { get; set; }
        public virtual Typeproduct TypeProduct { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual ICollection<Driverexpense> Driverexpenses { get; set; }
    }
}
