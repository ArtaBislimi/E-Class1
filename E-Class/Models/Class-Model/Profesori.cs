using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Class.Models.Class_Model
{
    public class Profesori
    {
        public int ProfesoratID { get; set; }
        public string Emri { get; set; }
        public string Mbiemri { get; set; }
        public string Mail { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool IsDeleted { get; set; }

    }
}