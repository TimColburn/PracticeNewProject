namespace PracticeNewProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectedManyToManyRelationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Skills", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.Skills", "Hobby_Id", "dbo.Hobbies");
            DropForeignKey("dbo.Hobbies", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.Skills", "Student_StudentId", "dbo.Students");
            DropIndex("dbo.Hobbies", new[] { "Student_StudentId" });
            DropIndex("dbo.Skills", new[] { "Skill_Id" });
            DropIndex("dbo.Skills", new[] { "Hobby_Id" });
            DropIndex("dbo.Skills", new[] { "Student_StudentId" });
            CreateTable(
                "dbo.StudentHobbies",
                c => new
                    {
                        Student_StudentId = c.Int(nullable: false),
                        Hobby_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_StudentId, t.Hobby_Id })
                .ForeignKey("dbo.Students", t => t.Student_StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Hobbies", t => t.Hobby_Id, cascadeDelete: true)
                .Index(t => t.Student_StudentId)
                .Index(t => t.Hobby_Id);
            
            CreateTable(
                "dbo.SkillStudents",
                c => new
                    {
                        Skill_Id = c.Int(nullable: false),
                        Student_StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Skill_Id, t.Student_StudentId })
                .ForeignKey("dbo.Skills", t => t.Skill_Id, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_StudentId, cascadeDelete: true)
                .Index(t => t.Skill_Id)
                .Index(t => t.Student_StudentId);
            
            DropColumn("dbo.Hobbies", "Student_StudentId");
            DropColumn("dbo.Skills", "Skill_Id");
            DropColumn("dbo.Skills", "Hobby_Id");
            DropColumn("dbo.Skills", "Student_StudentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "Student_StudentId", c => c.Int());
            AddColumn("dbo.Skills", "Hobby_Id", c => c.Int());
            AddColumn("dbo.Skills", "Skill_Id", c => c.Int());
            AddColumn("dbo.Hobbies", "Student_StudentId", c => c.Int());
            DropForeignKey("dbo.SkillStudents", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.SkillStudents", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.StudentHobbies", "Hobby_Id", "dbo.Hobbies");
            DropForeignKey("dbo.StudentHobbies", "Student_StudentId", "dbo.Students");
            DropIndex("dbo.SkillStudents", new[] { "Student_StudentId" });
            DropIndex("dbo.SkillStudents", new[] { "Skill_Id" });
            DropIndex("dbo.StudentHobbies", new[] { "Hobby_Id" });
            DropIndex("dbo.StudentHobbies", new[] { "Student_StudentId" });
            DropTable("dbo.SkillStudents");
            DropTable("dbo.StudentHobbies");
            CreateIndex("dbo.Skills", "Student_StudentId");
            CreateIndex("dbo.Skills", "Hobby_Id");
            CreateIndex("dbo.Skills", "Skill_Id");
            CreateIndex("dbo.Hobbies", "Student_StudentId");
            AddForeignKey("dbo.Skills", "Student_StudentId", "dbo.Students", "StudentId");
            AddForeignKey("dbo.Hobbies", "Student_StudentId", "dbo.Students", "StudentId");
            AddForeignKey("dbo.Skills", "Hobby_Id", "dbo.Hobbies", "Id");
            AddForeignKey("dbo.Skills", "Skill_Id", "dbo.Skills", "Id");
        }
    }
}
