using System;
using System.Collections.Generic;

#nullable disable

namespace IronHorseCore.Models
{
    public partial class Place
    {
        public Place()
        {
            OperationDestinies = new HashSet<Operation>();
            OperationSources = new HashSet<Operation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }

        public virtual ICollection<Operation> OperationDestinies { get; set; }
        public virtual ICollection<Operation> OperationSources { get; set; }
    }
}
