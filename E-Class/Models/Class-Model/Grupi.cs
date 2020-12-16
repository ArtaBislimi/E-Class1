using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Class.Models.Class_Model
{
    public class Grupi
    {
        public int GrupiID { get; set; }

        [Required]
        public int EmriGrupi { get; set; }

        public int VitiAkademik { get; set; }


        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date in the format dd/mm/yyyy hh:mm")]
        public DateTime CreatedOn { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date in the format dd/mm/yyyy hh:mm")]

        public DateTime LastUpdate { get; set; }

        public bool IsDeleted { get; set; }

    }
}