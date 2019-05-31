using AspFinalProject.Models;
using AspFinalProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AspFinalProject.Areas.Admin.Controllers
{

    [CVfilter]
    [CVExceptionFilter]
    public class EditController : Controller
    {

        myCvDbContext db = new myCvDbContext();
        // GET: Admin/Edit


        public ActionResult EditPage()
        {

            return View();
        }

        [ChildActionOnly]
        public ActionResult BioAndSkillsView()
        {

            var bioAndSkils = db.Skills.Where(w => w.DeletedDate == null).ToList();
            return View(bioAndSkils);
        }

        public ActionResult editBioAndSkill(int? id)
        {

            var skill = db.Skills.Find(id);
            return Json(skill, JsonRequestBehavior.AllowGet);
        }

        public ActionResult saveEditBioAndSkill(int? id, string yourdescription,
            int skilllevel, bool displayastag, bool displayasbar, string skilldescription,
             int? categorie, int? typeoffskills)
        {

            var skill = db.Skills.Find(id);
            var category = db.Category.Find(categorie);
            var skillss = db.TypeOfSkill.Find(typeoffskills);
            if (category == null || typeoffskills == null)
            {
                return Json("nullCategoryAndSkill", JsonRequestBehavior.AllowGet);
            }
            skill.YourDescription = yourdescription;
            skill.DisplayAsTag = displayasbar;
            skill.DisplayAsTag = displayastag;
            skill.SkillDescription = skilldescription;
            skill.Category = category.Name;
            skill.SkillLevel = skilllevel;
            skill.TypeOfSkill = skillss.Name;
            skill.ModifiedDate = DateTime.Now;
            db.Entry(skill).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return PartialView("~/Areas/Admin/Views/Shared/PartialViews/BioAndSkillList.cshtml", db.Skills.Where(w => w.DeletedDate == null).ToList());
        }

        [ChildActionOnly]
        public ActionResult CategoryView()
        {

            var categories = db.Category.Where(w => w.DeletedDate == null).ToList();
            return View(categories);
        }


        public ActionResult AddCategory(string name) //aleert problem
        {
            var checkCategory = db.Category.Any(w => w.DeletedDate == null && w.Name == name);
            if (name == "")
            {
                return Json(name, JsonRequestBehavior.AllowGet);
            }
            else if (checkCategory)
            {

                return Json("sameName", JsonRequestBehavior.AllowGet);
            }
            else
            {
                Category newCategory = new Category
                {
                    Name = name,
                    CreatedDate = DateTime.Now,

                };
                db.Category.Add(newCategory);
                db.SaveChanges();

                return PartialView("~/Areas/Admin/Views/Edit/CategoryView.cshtml", db.Category.ToList());
            }

        }
        public ActionResult DeleteExistsCategory(string name)
        {
            var checkCategory = db.Category.Where(w => w.DeletedDate == null && w.Name == name).FirstOrDefault();
            if (name == "")
            {

                return Json(name, JsonRequestBehavior.AllowGet);
            }
            else if (checkCategory == null)
            {

                return Json("noName", JsonRequestBehavior.AllowGet);
            }
            else
            {
                var category = db.Category.Where(w => w.DeletedDate == null && w.Name == name).FirstOrDefault();
                category.DeletedDate = DateTime.Now;
                db.Entry(category).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return PartialView("~/Areas/Admin/Views/Edit/CategoryView.cshtml", db.Category.Where(w => w.DeletedDate == null).ToList());
            }

        }

        public ActionResult AddSkills(string name) //Alert problem
        {
            var checkSkill = db.TypeOfSkill.Any(w => w.DeletedDate == null && w.Name == name);
            if (name == "")
            {

                return Json(name, JsonRequestBehavior.AllowGet);
            }
            else if (checkSkill)
            {

                return Json("sameName", JsonRequestBehavior.AllowGet);
            }
            else
            {
                TypeOfSkill newTypeOfSkill = new TypeOfSkill
                {
                    Name = name,
                    CreatedDate = DateTime.Now,

                };
                db.TypeOfSkill.Add(newTypeOfSkill);
                db.SaveChanges();

                return PartialView("~/Areas/Admin/Views/Edit/TypeOfSkillsView.cshtml", db.TypeOfSkill.ToList());
            }

        }

        public ActionResult DeleteExistSkill(string name)
        {
            var checkSkill = db.TypeOfSkill.Where(w => w.DeletedDate == null && w.Name == name).FirstOrDefault();
            if (name == "")
            {

                return Json(name, JsonRequestBehavior.AllowGet);
            }
            else if (checkSkill == null)
            {

                return Json("noName", JsonRequestBehavior.AllowGet);
            }
            else
            {
                var skill = db.TypeOfSkill.Where(w => w.DeletedDate == null && w.Name == name).FirstOrDefault();
                skill.DeletedDate = DateTime.Now;
                db.Entry(skill).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return PartialView("~/Areas/Admin/Views/Edit/TypeOfSkillsView.cshtml", db.TypeOfSkill.Where(w => w.DeletedDate == null).ToList());
            }


        }

        [ChildActionOnly]
        public ActionResult TypeOfSkillsView(int? id)
        {

            var skills = db.TypeOfSkill.Where(w => w.DeletedDate == null).ToList();
            return View(skills);
        }

        [HttpPost]
        public ActionResult addSkillsClick(Skills newSkills, int? categories, int? typeoffskillss)
        {

            //if (newSkills.Category==null||newSkills.TypeOfSkill==null)
            //{

            //    TempData["Category OR Skill"] = "Please, select Category and Skill, and fill all input";
            //    return RedirectToAction("EditPage", "Edit", new { area="Admin"});

            //}
            if (categories == null|| typeoffskillss == null)
            {

                TempData["Category OR Skill"] = "Please, select Category and Skill, and fill all input";
                return RedirectToAction("EditPage", "Edit", new { area="Admin"});

            }
            else if (ModelState.IsValid || typeoffskillss != null || typeoffskillss != null)
            {
                var category = db.Category.Find(categories);
                var skill = db.TypeOfSkill.Find(typeoffskillss);
                newSkills.CreatedDate = DateTime.Now;
                newSkills.Category = category.Name;
                newSkills.TypeOfSkill = skill.Name;
                db.Skills.Add(newSkills);
                db.SaveChanges();
                return RedirectToAction("EditPage", "Edit");
            }
            else
            {
                TempData["Skills"] = "Select Category and Skill and fill All Iinputs!!";
                return RedirectToAction("EditPage", "Edit");
            }
        }

        public ActionResult DeleteSkill(int? id)
        {
            var delSkill = db.Skills.Find(id);
            delSkill.DeletedDate = DateTime.Now;
            db.Entry(delSkill).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EditPage", "Edit", db.Skills.Where(w => w.DeletedDate == null).ToList());
        }

        [ChildActionOnly]
        public ActionResult ProfessionDetailsView()
        {

            var prfDetails = db.Person.FirstOrDefault();

            return View(prfDetails);
        }


        [HttpGet]
        public ActionResult ShowDetails()
        {

            var prfDetails = db.Person.FirstOrDefault();

            return Json(prfDetails, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult saveChange(Person person, HttpPostedFileBase imgPath, string fileName)
        {
            Person entity = db.Person.FirstOrDefault();
            if (entity == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (imgPath != null)
            {
                bool valid = true;
                if (!imgPath.CheckImageType())
                {
                    ModelState.AddModelError("mediaUrl", "Şəkil uyğun deyil!");
                    valid = false;
                }

                if (!imgPath.CheckImageSize(5))
                {
                    ModelState.AddModelError("mediaUrl", "Şəklin ölçüsü uyğun deyil!");
                    valid = false;
                }

                if (valid)
                {
                    string newPath = imgPath.SaveImage(Server.MapPath("~/Template/Media/Profile"));

                    //System.IO.File.Move(Server.MapPath(System.IO.Path.Combine("~/Template/media", entity.MediaUrl)),
                    //    Server.MapPath(System.IO.Path.Combine("~/Template/media", entity.MediaUrl)));


                    entity.imgPath = newPath;

                }
            }
            else if (!string.IsNullOrWhiteSpace(entity.imgPath)
                && !string.IsNullOrWhiteSpace(fileName))
            {
                entity.imgPath = null;
            }

            if ((person.FullName == null) || (person.Location == null) || (person.Experience == null) || (person.Degree == null)
                   || (person.CareerLevel == null) || (person.Email == null) || (person.Fax == null))
            {
                TempData["PersonInfomation"] = "Fill All inputs";
                return RedirectToAction("EditPage", "Edit");
            }

            var lastPerson = db.Person.FirstOrDefault();
            lastPerson.FullName = person.FullName;
            lastPerson.Age = person.Age;
            lastPerson.Location = person.Location;
            lastPerson.Experience = person.Experience;
            lastPerson.Degree = person.Degree;
            lastPerson.Phone = person.Phone;
            lastPerson.CareerLevel = person.CareerLevel;
            lastPerson.Email = person.Email;
            lastPerson.Fax = person.Fax;
            lastPerson.Website = person.Website;
            lastPerson.imgPath = entity.imgPath;

            db.Entry(lastPerson).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            if (Request.IsAjaxRequest())
            {
                var person1 = db.Person.FirstOrDefault();

                return PartialView("~/Areas/Admin/Views/Shared/PartialViews/_personDetails.cshtml", person1);

            }

            return RedirectToAction("EditPage", "Edit");
        }


        public ActionResult editAcademicBack(int? id)
        {
            var acBc = db.AcademicBackground.Find(id);
            return Json(acBc, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult saveEditAcademicBack(int? id, string qualification, string degree, string universityname, string yearofobtention, string details)
        {
            var acBc = db.AcademicBackground.Find(id);
            acBc.UniversityName = universityname;
            acBc.YearOfObtention = yearofobtention;
            acBc.Details = details;
            acBc.Degree = degree;
            acBc.Qualification = qualification;
            acBc.ModifiedDate = DateTime.Now;
            db.Entry(acBc).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return PartialView("~/Areas/Admin/Views/Shared/PartialViews/AcBackList.cshtml", db.AcademicBackground.Where(w => w.DeletedDate == null).ToList());
        }

        [ChildActionOnly]
        public ActionResult AcademicBacgroundView()
        {

            var acBg = db.AcademicBackground.Where(w => w.DeletedDate == null).ToList();

            return View(acBg);
        }
        [ChildActionOnly]
        public ActionResult ProfessionalExperienceView()
        {
            var prf = db.ProfessionalExperience.Where(w => w.DeletedDate == null).ToList();

            return View(prf);

        }
        public ActionResult editExperience(int? id)
        {
            var experience = db.ProfessionalExperience.Find(id);
            return Json(experience, JsonRequestBehavior.AllowGet);
        }

        public ActionResult saveEditExperience(int? id, string duration, string location, string jobtitle, string companyname, string details)
        {
            var experience1 = db.ProfessionalExperience.Find(id);
            experience1.CompanyName = companyname;
            experience1.JobTitle = jobtitle;
            experience1.Location = location;
            experience1.Details = details;
            experience1.Duration = duration;
            experience1.ModifiedDate = DateTime.Now;
            db.Entry(experience1).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return PartialView("~/Areas/Admin/Views/Shared/PartialViews/ExperienceList.cshtml", db.ProfessionalExperience.Where(w => w.DeletedDate == null).ToList());
        }


        [ChildActionOnly]
        public ActionResult Social()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddAcademicBacground(AcademicBackground acBackground, HttpPostedFileBase imgPath, string filename)
        {

            if (imgPath != null)
            {
                bool valid = true;
                if (!imgPath.CheckImageType())
                {
                    ModelState.AddModelError("mediaUrl", "Şəkil uyğun deyil!");
                    valid = false;
                }

                if (!imgPath.CheckImageSize(5))
                {
                    ModelState.AddModelError("mediaUrl", "Şəklin ölçüsü uyğun deyil!");
                    valid = false;
                }

                if (valid)
                {
                    string newPath = imgPath.SaveImage(Server.MapPath("~/Template/Media/AcademicBackground"));

                    //System.IO.File.Move(Server.MapPath(System.IO.Path.Combine("~/Template/media", entity.MediaUrl)),
                    //    Server.MapPath(System.IO.Path.Combine("~/Template/media", entity.MediaUrl)));


                    acBackground.imgPathAc = newPath;

                }
            }
            else if (!string.IsNullOrWhiteSpace(acBackground.imgPathAc)
                && !string.IsNullOrWhiteSpace(filename))
            {
                acBackground.imgPathAc = null;
            }

            if ((acBackground.Qualification == null) || (acBackground.UniversityName == null)
                || (acBackground.YearOfObtention == null)
                || (acBackground.Degree == null))
            {

                TempData["Fill all Inputs AcBack"] = "Qualification,  University's Name,  Year Of Obtention, and Degree must be filled!! ";

                return RedirectToAction("EditPage", "Edit");

            }

            else
            {
                AcademicBackground newAcademicBackground = new AcademicBackground
                {
                    Qualification = acBackground.Qualification,
                    Degree = acBackground.Degree,
                    UniversityName = acBackground.UniversityName,
                    YearOfObtention = acBackground.YearOfObtention,
                    Details = acBackground.Details,
                    CreatedDate = DateTime.Now,
                    imgPathAc = acBackground.imgPathAc,

                };
                db.AcademicBackground.Add(newAcademicBackground);
                db.SaveChanges();

                return RedirectToAction("EditPage", "Edit");
            }

        }

        [HttpPost]
        public ActionResult DeletedBackground(int? id)
        {
            var delAcademic = db.AcademicBackground.Find(id);
            delAcademic.DeletedDate = DateTime.Now;
            db.Entry(delAcademic).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EditPage", "Edit", db.AcademicBackground.Where(w => w.DeletedDate == null).ToList());
        }

        public ActionResult DeletedExperience(int? id)
        {

            var delExperience = db.ProfessionalExperience.Find(id);
            delExperience.DeletedDate = DateTime.Now;
            db.Entry(delExperience).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EditPage", "Edit", db.ProfessionalExperience.Where(w => w.DeletedDate == null).ToList());
        }

        [HttpPost]
        public ActionResult AddExperience(ProfessionalExperience newExperiencee, HttpPostedFileBase imgPath, string fileName)
        {
            if (imgPath != null)
            {
                bool valid = true;
                if (!imgPath.CheckImageType())
                {
                    ModelState.AddModelError("mediaUrl", "Şəkil uyğun deyil!");
                    valid = false;
                }

                if (!imgPath.CheckImageSize(5))
                {
                    ModelState.AddModelError("mediaUrl", "Şəklin ölçüsü uyğun deyil!");
                    valid = false;
                }

                if (valid)
                {
                    string newPath = imgPath.SaveImage(Server.MapPath("~/Template/Media/Experience"));

                    //System.IO.File.Move(Server.MapPath(System.IO.Path.Combine("~/Template/media", entity.MediaUrl)),
                    //    Server.MapPath(System.IO.Path.Combine("~/Template/media", entity.MediaUrl)));

                    newExperiencee.imgPath = newPath;

                }
            }

            else if (!string.IsNullOrWhiteSpace(newExperiencee.imgPath)
                && !string.IsNullOrWhiteSpace(fileName))
            {
                newExperiencee.imgPath = null;
            }

            if ((newExperiencee.Location == null) || (newExperiencee.Duration == null)
               || (newExperiencee.JobTitle == null) || (newExperiencee.CompanyName == null)
               || (newExperiencee.Details == null))
            {

                TempData["Fill all Inputs Experience"] = "Company's Name,  Job Title,  Location, Duration, and Details must be filled!! ";

                return RedirectToAction("EditPage", "Edit");

            }
            else
            {
                ProfessionalExperience newExperience = new ProfessionalExperience
                {
                    Duration = newExperiencee.Duration,

                    JobTitle = newExperiencee.JobTitle,
                    CompanyName = newExperiencee.CompanyName,
                    Location = newExperiencee.Location,
                    Details = newExperiencee.Details,
                    CreatedDate = DateTime.UtcNow,
                    imgPath = newExperiencee.imgPath,

                };
                db.ProfessionalExperience.Add(newExperiencee);

                db.SaveChanges();
                return RedirectToAction("EditPage", "Edit");
            }

        }

        public ActionResult saveAllChange()
        {
            db.SaveChanges();
            return RedirectToAction("Index", "Admin", new { area = "Admin" });
        }


    }
}