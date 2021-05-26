using System;
using System.Collections.Generic;

#nullable disable

namespace IronHorseCore.Models
{
    public partial class Operationexpense
    {
        public int Id { get; set; }
        public int TypeExpenseId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
    }
}
