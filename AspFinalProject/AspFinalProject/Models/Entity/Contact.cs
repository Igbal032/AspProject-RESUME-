using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspFinalProject.Models.Entity
{
    public class Contact
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }
        //[Required(ErrorMessage = "FromEmail is required")]
        public string FromEmail { get; set; }
        public string Subject { get; set; }
        //[Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }
        public DateTime SendingDate { get; set; }
        //[Required(ErrorMessage = "Answer is required")]
        public string Answer { get; set; }

        [ScaffoldColumn(false)]
        public bool isAnswered { get; set; }
        [ScaffoldColumn(false)]
        public bool isRead { get; set; }
        [ScaffoldColumn(false)]
        public DateTime?  DeletedDate { get; set; }


    }
}