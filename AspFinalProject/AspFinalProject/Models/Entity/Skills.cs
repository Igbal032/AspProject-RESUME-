using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspFinalProject.Models.Entity
{
    public class Skills : BaseEntity
    {
        public string Name { get; set; }
        public string YourDescription { get; set; }
        public int? SkillLevel { get; set; }
        public string SkillDescription { get; set; }
        public bool DisplayAsBar { get; set; }
        public bool DisplayAsTag { get; set; }
        public  string TypeOfSkill { get; set; }
        public string Category { get; set; }

    }
}