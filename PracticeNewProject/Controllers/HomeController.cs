using PracticeNewProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeNewProject.Controllers
{
    public class HomeController : Controller
    {
        // from:  https://dotnettutorials.net/lesson/dropdownlist-html-helper-mvc/

        private NewProjectContext db = new NewProjectContext();

        public ActionResult Index()
        {
            List<Department> departments = new List<Department>()
            {
                new Department() {Id = 1, Name="IT" },
                new Department() {Id = 2, Name="HR" },
                new Department() {Id = 3, Name="Payroll" },
            };
            ViewBag.Departments = departments;

            List<SelectListItem> genders = new List<SelectListItem>();
            foreach (var item in Enum.GetValues(typeof(GenderEnum)))
            {
                genders.Add(new SelectListItem()
                {
                    Value = ((int)item).ToString(),
                    Text = item.ToString()
                });
            }
            ViewBag.Genders = genders;

            return View();
        }

        public ActionResult StudentRegistrationForm()
        {
            var student = new Student();
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StudentRegistrationForm(Student student)
        {

            //tmc  need to fix the multiple selections
            //          use MultiSelectList?
            //          see: https://entityframework.net/knowledge-base/19663782/how-can-i-get-my-multiselectlist-to-bind-to-my-data-model-
            //tmc - also, consider using ViewBag instead of putting
            //          the lists in the model
            //          or, make the lists available on the 
            //          class (make them static)
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }




        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}