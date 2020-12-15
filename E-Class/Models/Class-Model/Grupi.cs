using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Class.Models.Class_Model
{
    public class Grupi
    {
        public int GrupiID { get; set; }
        public int EmriGrupi { get; set; }
        public int VitiAkademik { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool IsDeleted { get; set; }

    }
}