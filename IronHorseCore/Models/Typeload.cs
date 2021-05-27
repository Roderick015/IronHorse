using System;
using System.Collections.Generic;

#nullable disable

namespace IronHorseCore.Models
{
    public partial class Typeload
    {
        public Typeload()
        {
            Clientrates = new HashSet<Clientrate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }

        public virtual ICollection<Clientrate> Clientrates { get; set; }
    }
}
