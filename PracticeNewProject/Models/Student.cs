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
        public int StudentId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool GenderMale { get; set; }
        public string Address { get; set; }
        public List<string> Hobbies { get; set; }
        public string Course { get; set; }
        public List<string> Skills { get; set; }

    }

}