using System;
using System.Collections.Generic;

#nullable disable

namespace IronHorseCore.Models
{
    public partial class Unit
    {
        public Unit()
        {
            Operations = new HashSet<Operation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }

        public virtual ICollection<Operation> Operations { get; set; }
    }
}
