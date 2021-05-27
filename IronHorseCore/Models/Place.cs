using System;
using System.Collections.Generic;

#nullable disable

namespace IronHorseCore.Models
{
    public partial class Place
    {
        public Place()
        {
            ClientrateDestinies = new HashSet<Clientrate>();
            ClientrateSources = new HashSet<Clientrate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }

        public virtual ICollection<Clientrate> ClientrateDestinies { get; set; }
        public virtual ICollection<Clientrate> ClientrateSources { get; set; }
    }
}
