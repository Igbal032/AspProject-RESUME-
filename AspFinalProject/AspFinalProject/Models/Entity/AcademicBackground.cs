using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspFinalProject.Models.Entity
{
    public class AcademicBackground : BaseEntity
    {
        public string Qualification { get; set; }
        public string Degree { get; set; }

        public string UniversityName { get; set; }
        public string YearOfObtention { get; set; }
        public string Details { get; set; }

        public string imgPathAc { get; set; }

    }
}