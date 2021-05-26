using System;
using System.Collections.Generic;

#nullable disable

namespace IronHorseCore.Models
{
    public partial class Client
    {
        public Client()
        {
            Clientrates = new HashSet<Clientrate>();
            Operations = new HashSet<Operation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public bool Enabled { get; set; }
        public string UniqueId { get; set; }
        public string MetaAuth { get; set; }
        public bool IsRemoved { get; set; }

        public virtual ICollection<Clientrate> Clientrates { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
