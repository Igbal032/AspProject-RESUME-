using AspFinalProject.Models;
using AspFinalProject.Models.Entity;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace AspFinalProject.Controllers
{

    [CVExceptionFilter]
    public class HomeController : Controller
    {

        myCvDbContext db = new myCvDbContext();

        public ActionResult Index()

        {
            var person = db.Person.FirstOrDefault();
            return View(person);
        }

        public ActionResult EditPage()
        {

            return View();
        }

        [ChildActionOnly]
        public ActionResult SideBar()
        {
            var person = db.Person.FirstOrDefault();
            return View(person);
        }

        public ActionResult SocialProfile()
        {

            var socials = db.SocialProfiles.Where(w => w.DeletedDate == null).ToList();
            return View(socials);
        }

        public ActionResult ErrorHtml()
        {

            return View();
        }

        public ActionResult AddCategory(string name)
        {
            Category newCategory = new Category
            {
                Name = name,
                CreatedDate = DateTime.Now,

            };
            db.Category.Add(newCategory);
            db.SaveChanges();

            return View(newCategory);
        }

        public ActionResult ResumePage()
        {

            return View();
        }

        public ActionResult Portfolio()
        {


            return View();
        }

        [ChildActionOnly]
        public ActionResult BioAndSkillsForResume()
        {

            var skills = db.Skills.Where(w => w.DeletedDate == null).ToList();
            return View(skills);
        }
        [ChildActionOnly]
        public ActionResult AcademicBackGroundForResume()
        {

            var acBack = db.AcademicBackground.Where(w => w.DeletedDate == null).ToList();
            return View(acBack);
        }

        [ChildActionOnly]
        public ActionResult ProfessionalExperienceForResume()
        {

            var prfExperience = db.ProfessionalExperience.Where(w => w.DeletedDate == null).ToList();
            return View(prfExperience);
        }

        public ActionResult Contact()
        {

            var person = db.Person.FirstOrDefault();
            return View(person);
        }

        [HttpPost]
        public ActionResult ContactMe([Bind(Include = "UserName,FromEmail,Subject,Message,SendingDate")] Contact NewContact)
        { //todo

            if (NewContact.UserName == null || NewContact.FromEmail == null || NewContact.Message == null)
            {
                TempData["FillContactInputs"] = "Please, Fill all Inputs";
                return RedirectToAction("Contact", "Home");
            }
            else
            {
                var email = db.Person.FirstOrDefault();
                var count = 1;
                var s = "";
                foreach (var item in db.Contact.Where(w => w.isRead == false).ToList())
                {

                    count++;
                }
                if (count > 1)
                {
                    s = "s";
                }
                NewContact.SendingDate = DateTime.Now;
                db.Contact.Add(NewContact);
                Extention.SendMail("Message", "You have " + count + " new Email" + s + "", email.Email);
                db.SaveChanges();
                return RedirectToAction("Index", db.Person.FirstOrDefault());

            }
        }


    }
}