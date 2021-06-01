using System;
using System.Collections.Generic;

#nullable disable

namespace IronHorseCore.Models
{
    public partial class Bill
    {
        public int Id { get; set; }
        public int OperationId { get; set; }
        public DateTime? Created { get; set; }
        public decimal? Total { get; set; }
        public string SerialNumber { get; set; }
        public int? Status { get; set; }
        public DateTime? Datepay { get; set; }

        public virtual Operation Operation { get; set; }
    }
}
