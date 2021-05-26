using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace IronHorseCore.Models
{
    [ModelMetadataType(typeof(OperationexpenseMetaData))]
    public partial class Operationexpense
    {
    }

    public interface OperationexpenseMetaData
    {
        public int TypeExpenseId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
    }
}
