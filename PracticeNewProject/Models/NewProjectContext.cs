using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PracticeNewProject.Models
{
    public class NewProjectContext : DbContext
    {
        public NewProjectContext()
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}