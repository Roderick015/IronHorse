using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IronHorseCore.Helper
{
    public class MetaAuth
    {
        public MetaAuth()
        {
            Created = DateTime.Now;
            Modified = DateTime.Now;
            Removed = null;
            RemovedUserID = null;
        }

        public System.DateTime Created { get; set; }
        public int CreatedUserID { get; set; }
        public System.DateTime Modified { get; set; }
        public int ModifiedUserID { get; set; }
        public Nullable<System.DateTime> Removed { get; set; }
        public Nullable<int> RemovedUserID { get; set; }
    }
}
