using System;
using System.Collections.Generic;

#nullable disable

namespace IronHorseCore.Models
{
    public partial class Clientrate
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string TypeService { get; set; }
        public string BillableUnit { get; set; }
        public string CollectionUnit { get; set; }
        public string PriceWithoutVat { get; set; }
        public string ContractNumber { get; set; }
        public string ContractExpiration { get; set; }
        public string Currency { get; set; }

        public virtual Client Client { get; set; }
    }
}
