using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace IronHorseCore.Models
{
    [ModelMetadataType(typeof(TypeexpenseMetaData))]
    public partial class Typeexpense
    {
    }

    public interface TypeexpenseMetaData
    {
        public string Name { get; set; }
    }
}
