using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Class.Models.Class_Model
{
    public class Lenda
    {
        public int LendaID { get; set; }
        public string Emertimi { get; set; }
        public string Libri { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool IsDeleted { get; set; }
        


    }
}