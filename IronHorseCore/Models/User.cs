using System;
using System.Collections.Generic;

#nullable disable

namespace IronHorseCore.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string TypeDoc { get; set; }
        public string NumberDoc { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime LastAccess { get; set; }
        public bool Enabled { get; set; }
        public string Rol { get; set; }
        public string UniqueId { get; set; }
        public string MetaAuth { get; set; }
        public bool IsRemoved { get; set; }
    }
}
