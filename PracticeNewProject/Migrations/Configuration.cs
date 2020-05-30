namespace PracticeNewProject.Migrations
{
    using PracticeNewProject.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PracticeNewProject.Models.NewProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PracticeNewProject.Models.NewProjectContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.


            context.Hobbies.AddOrUpdate(new Hobby() { Name = "Cricket" });
            context.Hobbies.AddOrUpdate(new Hobby() { Name = "Dancing" });
            context.Hobbies.AddOrUpdate(new Hobby() { Name = "Drawing" });


            context.Skills.AddOrUpdate(new Skill() { Name = "C#" });
            context.Skills.AddOrUpdate(new Skill() { Name = "ASP.NET" });
            context.Skills.AddOrUpdate(new Skill() { Name = "ASP.NET Core" });
            context.Skills.AddOrUpdate(new Skill() { Name = "Azure" });
        }
    }
}
