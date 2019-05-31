using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspFinalProject.Models.Entity
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
    }
}