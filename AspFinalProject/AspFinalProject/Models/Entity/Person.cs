using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspFinalProject.Models.Entity
{
    public class Person : BaseEntity
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
        public string Experience { get; set; }
        public string Degree { get; set; }
        public string CareerLevel { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }

        public string Phone { get; set; }

        public string Website { get; set; }

        public string imgPath { get; set; }

        public string Password { get; set; }



    }
}