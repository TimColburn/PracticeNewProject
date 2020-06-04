namespace PracticeNewProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseIdIsNullableInt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "CourseId", "dbo.Courses");
            DropIndex("dbo.Students", new[] { "CourseId" });
            AlterColumn("dbo.Students", "CourseId", c => c.Int());
            CreateIndex("dbo.Students", "CourseId");
            AddForeignKey("dbo.Students", "CourseId", "dbo.Courses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "CourseId", "dbo.Courses");
            DropIndex("dbo.Students", new[] { "CourseId" });
            AlterColumn("dbo.Students", "CourseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "CourseId");
            AddForeignKey("dbo.Students", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
    }
}
