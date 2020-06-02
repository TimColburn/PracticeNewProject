﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeNewProject.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}