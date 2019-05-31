using AspFinalProject.AppCode.Constant;
using AspFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspFinalProject.Areas.Admin.Controllers
{
    [CVfilter]
    [CVExceptionFilter]
    public class AdminController : Controller
    {
        myCvDbContext db = new myCvDbContext();
        // GET: Admin/Admin
        public ActionResult Index()
        {

            return View();
        }


        [AllowAnonymous]
        public ActionResult LoginPart()
        {


            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult LoginPart(string email, string password)
        {

            var admin = db.Person.Where(w=>w.Email==email||w.Phone==email).FirstOrDefault();
           
            if (admin != null)
            {
                string HashPassword = PasswordExtention.HashPassword(password);
                if (admin.Password==password &&(admin.Email == email|| admin.Phone==email))
                {
                    var adminSession = new SessionKey();
                    Session[SessionKey.Admin] = email;

                    var x = Session[SessionKey.Admin];
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.Login = "Password is Wrong!!";
                    return View();
                }

            }
            else
            {
                ViewBag.Login = "Email OR Password is Wrong!!";
                return View();
            }

        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("LoginPart", "Admin");
        }
        public ActionResult ChangePassword()
        {

            return View();
        }
        public ActionResult ChangePasswordd(string oldpassword, string newpassword, string confirmnewpassword)
        {
           
            var admin = db.Person.FirstOrDefault();
            if (oldpassword==admin.Password)
            {
                ViewBag.PreviousPassword = "True";
                if (newpassword!=confirmnewpassword)
                {
                    TempData["Confirm"] = "Passwords are not the same!!!";
                    return RedirectToAction("ChangePassword","Admin");
                }
                else
                {
                    admin.Password = confirmnewpassword;
                    db.Entry(admin).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    TempData["Confirm"] = "You have already changed the password";

                    return RedirectToAction("LoginPart", "Admin");

                }
            }
            else
            {
                TempData["OldPassword"] = " Old Password is Wrong";
                return RedirectToAction("ChangePassword","Admin");
            }
        }

        [AllowAnonymous]
        public ActionResult ForgetPassword()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult FindPwd(string email)
        {
            var admin = db.Person.FirstOrDefault();
            if (email == "")
            {

                return Json("", JsonRequestBehavior.AllowGet);
            }
            else if (admin.Email!=email && admin.Phone!=email)
            {

                //TempData["noAdmin"] = "This email doesn't exists!!";
                return Json("noMail", JsonRequestBehavior.AllowGet);
            }
           
            else
            {
                Extention.SendMail("Reset Password","Your Code is "+ " " + admin.Password+" "+".", admin.Email);
                return RedirectToAction("LoginPart","Admin");
            }
        }

    }
}