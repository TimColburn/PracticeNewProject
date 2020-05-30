namespace PracticeNewProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentModelNowPointsToEntityTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hobbies", "Student_StudentId", c => c.Int());
            AddColumn("dbo.Skills", "Student_StudentId", c => c.Int());
            AddColumn("dbo.Students", "Course_Id", c => c.Int());
            CreateIndex("dbo.Hobbies", "Student_StudentId");
            CreateIndex("dbo.Skills", "Student_StudentId");
            CreateIndex("dbo.Students", "Course_Id");
            AddForeignKey("dbo.Students", "Course_Id", "dbo.Courses", "Id");
            AddForeignKey("dbo.Hobbies", "Student_StudentId", "dbo.Students", "StudentId");
            AddForeignKey("dbo.Skills", "Student_StudentId", "dbo.Students", "StudentId");
            DropColumn("dbo.Students", "Course");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Course", c => c.String());
            DropForeignKey("dbo.Skills", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.Hobbies", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "Course_Id", "dbo.Courses");
            DropIndex("dbo.Students", new[] { "Course_Id" });
            DropIndex("dbo.Skills", new[] { "Student_StudentId" });
            DropIndex("dbo.Hobbies", new[] { "Student_StudentId" });
            DropColumn("dbo.Students", "Course_Id");
            DropColumn("dbo.Skills", "Student_StudentId");
            DropColumn("dbo.Hobbies", "Student_StudentId");
        }
    }
}
