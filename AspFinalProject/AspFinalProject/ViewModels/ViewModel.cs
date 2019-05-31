using AspFinalProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspFinalProject.ViewModels
{
    public class ViewModel
    {
        //public Person Person { get; set; }

        //public IEnumerable <Category> Categories { get; set; }
        public IEnumerable<Contact> ContactIE { get; set; }

        public Contact UserMessage { get; set; }

    }
}