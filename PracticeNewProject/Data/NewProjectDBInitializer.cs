using PracticeNewProject.Models;
using System.Data.Entity;

namespace PracticeNewProject.Data
{
    public class NewProjectDBInitializer : DropCreateDatabaseAlways<NewProjectContext>
    {

        protected override void Seed(NewProjectContext context)
        {
            context.Hobbies.Add(new Hobby() { Name = "Cricket" });
            context.Hobbies.Add(new Hobby() { Name = "Dancing" });
            context.Hobbies.Add(new Hobby() { Name = "Drawing" });

            context.Skills.Add(new Skill() { Name = "C#" });
            context.Skills.Add(new Skill() { Name = "ASP.NET" });
            context.Skills.Add(new Skill() { Name = "ASP.NET Core" });
            context.Skills.Add(new Skill() { Name = "Azure" });

            context.Courses.Add(new Course() { Name = "BCA" });
            context.Courses.Add(new Course() { Name = "BCS" });
            context.Courses.Add(new Course() { Name = "MCA" });
            context.Courses.Add(new Course() { Name = "MCS" });
        }
    }
}