using System;
using System.Collections.Generic;

#nullable disable

namespace IronHorseCore.Models
{
    public partial class Driverexpense
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public int TypeExpenseId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public int? OperacionDesignada { get; set; }
        public int? AprobadoPor { get; set; }
        public int? OperationId { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual Operation Operation { get; set; }
        public virtual Typeexpense TypeExpense { get; set; }
    }
}
