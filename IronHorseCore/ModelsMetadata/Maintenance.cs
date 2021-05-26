using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

#nullable disable

namespace IronHorseCore.Models
{
    [ModelMetadataType(typeof(MaintenanceMetaData))]
    public partial class Maintenance
    {
    }

    public interface MaintenanceMetaData
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
    }
}
