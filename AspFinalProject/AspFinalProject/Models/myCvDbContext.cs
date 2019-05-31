using AspFinalProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspFinalProject.Models
{
    public class myCvDbContext : DbContext
    {
        public myCvDbContext()
            : base("name=cString")
        {

        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProfessionalExperience> ProfessionalExperience { get; set; }
        public DbSet<AcademicBackground> AcademicBackground { get; set; }

        public DbSet<Skills> Skills { get; set; }
        public DbSet<SocialProfiles> SocialProfiles { get; set; }
        public DbSet<TypeOfSkill> TypeOfSkill { get; set; }
        public DbSet<ErrorHistory> ErrorHistory { get; set; }


    }
}