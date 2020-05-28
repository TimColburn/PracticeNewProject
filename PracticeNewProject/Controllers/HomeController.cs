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