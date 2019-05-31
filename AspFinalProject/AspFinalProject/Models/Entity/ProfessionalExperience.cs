using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspFinalProject.Models.Entity
{
    public class ProfessionalExperience : BaseEntity
    {
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public string Duration { get; set; }
        public string imgPath { get; set; }


    }
}