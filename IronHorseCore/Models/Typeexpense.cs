using System;
using System.Collections.Generic;

#nullable disable

namespace IronHorseCore.Models
{
    public partial class Typeexpense
    {
        public Typeexpense()
        {
            Driverexpenses = new HashSet<Driverexpense>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Enabled { get; set; }

        public virtual ICollection<Driverexpense> Driverexpenses { get; set; }
    }
}
