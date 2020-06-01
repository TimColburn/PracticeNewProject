using PracticeNewProject.Data;
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
            //List<Department> departments = new List<Department>()
            //{
            //    new Department() {Id = 1, Name="IT" },
            //    new Department() {Id = 2, Name="HR" },
            //    new Department() {Id = 3, Name="Payroll" },
            //};
            //ViewBag.Departments = departments;

            //List<SelectListItem> genders = new List<SelectListItem>();
            //foreach (var item in Enum.GetValues(typeof(GenderEnum)))
            //{
            //    genders.Add(new SelectListItem()
            //    {
            //        Value = ((int)item).ToString(),
            //        Text = item.ToString()
            //    });
            //}
            //ViewBag.Genders = genders;

            return View();
        }

        public ActionResult StudentRegistrationForm()
        {
            ViewBag.AvailableHobbies = db.Hobbies.ToList();
            ViewBag.AvailableCourses = db.Courses.Select(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() }).ToList();
            ViewBag.AvailableSkills = db.Skills.Select(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() }).ToList();
            var student = new Student();
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StudentRegistrationForm(Student student)
        {
            if (ModelState.IsValid)
            {
                //convert the selected ids into objects
                student.Course = db.Courses.Find(student.CourseId);
                student.Skills = student.SelectedSkillIds.Select(m => db.Skills.Find(m)).ToList();
                student.Hobbies = student.SelectedHobbyIds.Select(m => db.Hobbies.Find(m)).ToList();
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AvailableHobbies = db.Hobbies.ToList();
            ViewBag.AvailableCourse = db.Courses.Select(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() }).ToList();
            ViewBag.AvailableSkills = db.Skills.Select(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() }).ToList();

            return View(student);
        }

    }
}