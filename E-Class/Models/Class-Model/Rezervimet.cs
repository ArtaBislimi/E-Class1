using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Class.Models.Class_Model
{
    public class Rezervimet
    {
        public int RezervimeID { get; set; }
        public Grupi GrupiID { get; set; }
        public Profesori ProfesoriID { get; set; }
        public Salla SallaID { get; set; }
        public Lenda LendaID { get; set; }
        public DateTime Fillimi { get; set; }
        public DateTime Mbarimi { get; set; }
        public int statusi { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool IsDeleted { get; set; }
    }
}