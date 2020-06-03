using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
            Hobbies = new HashSet<Hobby>();
            Skills = new HashSet<Skill>();
        }

        public int StudentId { get; set; }

        [Required]
        public string UserName { get; set; }

        public string Password { get; set; }

        [DisplayName("Gender")]
        public bool GenderMale { get; set; }
        public string Address { get; set; }

        [DisplayName("Course")]
        public int CourseId { get; set; }


        [NotMapped]
        public List<int> SelectedSkillIds { get; set; }

        [NotMapped]
        public List<int> SelectedHobbyIds { get; set; }


        public virtual Course Course { get; set; }
        public virtual ICollection<Hobby> Hobbies { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
    }

}