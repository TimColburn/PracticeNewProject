using PracticeNewProject.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace PracticeNewProject.Data
{
    public class NewProjectDBInitializer : DropCreateDatabaseAlways<NewProjectContext>
    {

        protected override void Seed(NewProjectContext context)
        {
            var hobby1 = new Hobby() { Name = "Cricket" };
            var hobby2 = new Hobby() { Name = "Dancing" };
            var hobby3 = new Hobby() { Name = "Drawing" };

            var skill1 = new Skill() { Name = "C#" };
            var skill2 = new Skill() { Name = "ASP.NET" };
            var skill3 = new Skill() { Name = "ASP.NET Core" };
            var skill4 = new Skill() { Name = "Asure" };

            var course1 = new Course() { Name = "AAA" };
            var course2 = new Course() { Name = "BBB" };
            var course3 = new Course() { Name = "CCC" };
            var course4 = new Course() { Name = "DDD" };

            var student1 = new Student()
            {
                Address = "1111 Main St",
                Course = course1,
                GenderMale = true,
                Hobbies = new List<Hobby>() { hobby1 },
                Password = "password1",
                Skills = new List<Skill>() { skill1 },
                UserName = "TimA",
            };
            var student2 = new Student()
            {
                Address = "2222 Main St",
                Course = course1,
                GenderMale = false,
                Hobbies = new List<Hobby>() { hobby1, hobby2 },
                Password = "password2",
                Skills = new List<Skill>() { skill1, skill2},
                UserName = "TimB",
            };

            context.Hobbies.AddRange(new List<Hobby>() { hobby1, hobby2, hobby3 });
            context.Skills.AddRange(new List<Skill>() { skill1, skill2, skill3, skill4 });
            context.Courses.AddRange(new List<Course>() { course1, course2, course3, course4 });

            context.Students.Add(student1);
            context.Students.Add(student2);
        }
    }
}