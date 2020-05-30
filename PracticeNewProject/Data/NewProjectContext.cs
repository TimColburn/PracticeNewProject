using PracticeNewProject.Models;
using System.Data.Entity;

namespace PracticeNewProject.Data
{
    public class NewProjectContext : DbContext
    {
        public NewProjectContext()
        {
            Database.SetInitializer<NewProjectContext>(new NewProjectDBInitializer());
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Course> Courses { get; set; }

    }
}