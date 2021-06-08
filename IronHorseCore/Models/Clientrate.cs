using System;
using System.Collections.Generic;

#nullable disable

namespace IronHorseCore.Models
{
    public partial class Clientrate
    {
        public Clientrate()
        {
            Operations = new HashSet<Operation>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public int TypeServiceId { get; set; }
        public int TypeLoadId { get; set; }
        public int TypeProductId { get; set; }
        public string Description { get; set; }
        public int SourceId { get; set; }
        public int DestinyId { get; set; }
        public int UnitId { get; set; }
        public int MoneyId { get; set; }
        public decimal? PriceWithoutVat { get; set; }
        public string ContractNumber { get; set; }
        public string ContractExpiration { get; set; }
        public bool Enabled { get; set; }
        public string UniqueId { get; set; }
        public string MetaAuth { get; set; }
        public bool IsRemoved { get; set; }

        public virtual Client Client { get; set; }
        public virtual Place Destiny { get; set; }
        public virtual Money Money { get; set; }
        public virtual Place Source { get; set; }
        public virtual Typeload TypeLoad { get; set; }
        public virtual Typeproduct TypeProduct { get; set; }
        public virtual Typeservice TypeService { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
