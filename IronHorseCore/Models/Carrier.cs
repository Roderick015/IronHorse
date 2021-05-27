using System;
using System.Collections.Generic;

#nullable disable

namespace IronHorseCore.Models
{
    public partial class Carrier
    {
        public Carrier()
        {
            Operations = new HashSet<Operation>();
            Trucks = new HashSet<Truck>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }

        public virtual ICollection<Operation> Operations { get; set; }
        public virtual ICollection<Truck> Trucks { get; set; }
    }
}
