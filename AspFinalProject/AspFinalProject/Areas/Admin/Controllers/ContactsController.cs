using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspFinalProject.Models;
using AspFinalProject.Models.Entity;
using AspFinalProject.ViewModels;


namespace AspFinalProject.Areas.Admin.Controllers
{
    [CVfilter]
    [CVExceptionFilter]
    public class ContactsController : Controller
    {
        private myCvDbContext db = new myCvDbContext();


        // GET: Admin/Contacts
        public ActionResult Index()
        {

            return View(db.Contact.OrderByDescending(o => o.Id).Where(c => c.DeletedDate == null).ToList());
        }

        // GET: Admin/Contacts/Details/5
        public ActionResult Answer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contact.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }

            if (!contact.isRead == true)
            {
                contact.isRead = true;
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(contact, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult sendAnsweredMessage(int? id, string answeredMessage)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contact.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            contact.Answer = answeredMessage;
            contact.isAnswered = true;
            Extention.SendMail("CV", contact.Answer, contact.FromEmail);
            db.Entry(contact).State = EntityState.Modified;
            db.SaveChanges();
            if (Request.IsAjaxRequest())
            {
                var emails = db.Contact.OrderByDescending(o => o.Id).Where(w=>w.DeletedDate==null).ToList();
                return PartialView("~/Areas/Admin/Views/Shared/PartialViews/_MessageList.cshtml", emails);
            }

            return RedirectToAction("Index");
        }

        public ActionResult closeModal(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contact.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }

            if (!contact.isRead == true)
            {
                contact.isRead = true;
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
            }

            var emails = db.Contact.OrderByDescending(o => o.Id).Where(c => c.DeletedDate == null).ToList();
            return PartialView("~/Areas/Admin/Views/Shared/PartialViews/_MessageList.cshtml", emails);
        }


        // GET: Admin/Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contact.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return Json(contact, JsonRequestBehavior.AllowGet);
        }

        // POST: Admin/Contacts/Delete/5
        [HttpPost]
        public ActionResult DeleteConfirmed(int? id)
        {
            Contact contact = db.Contact.Find(id);
            contact.DeletedDate = DateTime.Now;
            contact.isAnswered = true;
            db.Entry(contact).State = EntityState.Modified;
            db.SaveChanges();
            if (Request.IsAjaxRequest())
            {
                var emails = db.Contact.OrderByDescending(o => o.Id).Where(w=>w.DeletedDate==null).ToList();
                return PartialView("~/Areas/Admin/Views/Shared/PartialViews/_MessageList.cshtml", emails);
            }
            return RedirectToAction("Index","Contacts");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
