using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Class.Models.Class_Model
{
    public class Salla
    {
        public int SallaID { get; set; }
        public int NumriSalles { get; set; }
        public char Tipi { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool IsDeleted { get; set; }

    }
}