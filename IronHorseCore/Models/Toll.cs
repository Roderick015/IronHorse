using System;
using System.Collections.Generic;

#nullable disable

namespace IronHorseCore.Models
{
    public partial class Toll
    {
        public int Id { get; set; }
        public int OperationsId { get; set; }
        public DateTime DatePay { get; set; }
        public decimal Pay { get; set; }

        public virtual Operation Operations { get; set; }
    }
}
