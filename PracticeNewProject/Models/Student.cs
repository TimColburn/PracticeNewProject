using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeNewProject.Models
{
    public class Student
    {
        public Student()
        {
            AvailableHobbies = new List<SelectListItem>()
            {
                new SelectListItem { Text="None", Value="0" },
                new SelectListItem { Text="Cricket", Value="1" },
                new SelectListItem { Text="Dancing", Value="2" },
                new SelectListItem { Text="Drawing", Value="3" },
            };

            AvailableCourses = new List<SelectListItem>()
            {
                new SelectListItem { Text="None", Value="0" },
                new SelectListItem { Text="BCA", Value="1" },
                new SelectListItem { Text="BCS", Value="2" },
                new SelectListItem { Text="MCA", Value="3" },
                new SelectListItem { Text="MCS", Value="4" },
            };

            AvailableSkills = new List<SelectListItem>()
            {
                new SelectListItem { Text="None", Value="0" },
                new SelectListItem { Text="C#", Value="1" },
                new SelectListItem { Text="ASP.NET", Value="2" },
                new SelectListItem { Text="ASP.NET Core", Value="3" },
                new SelectListItem { Text="Azure", Value="4" },
            };

        }

        public int StudentId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool GenderMale { get; set; }
        public string Address { get; set; }
        public List<string> Hobbies { get; set; }
        public string Course { get; set; }
        public List<string> Skills { get; set; }

        [NotMapped]
        public List<SelectListItem> AvailableHobbies { get; set; }

        [NotMapped]
        public List<SelectListItem> AvailableCourses { get; set; }

        [NotMapped]
        public List<SelectListItem> AvailableSkills { get; set; }
    }

}