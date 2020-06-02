namespace PracticeNewProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeRelationshipsManyToMany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "Skill_Id", c => c.Int());
            AddColumn("dbo.Skills", "Hobby_Id", c => c.Int());
            CreateIndex("dbo.Skills", "Skill_Id");
            CreateIndex("dbo.Skills", "Hobby_Id");
            AddForeignKey("dbo.Skills", "Skill_Id", "dbo.Skills", "Id");
            AddForeignKey("dbo.Skills", "Hobby_Id", "dbo.Hobbies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "Hobby_Id", "dbo.Hobbies");
            DropForeignKey("dbo.Skills", "Skill_Id", "dbo.Skills");
            DropIndex("dbo.Skills", new[] { "Hobby_Id" });
            DropIndex("dbo.Skills", new[] { "Skill_Id" });
            DropColumn("dbo.Skills", "Hobby_Id");
            DropColumn("dbo.Skills", "Skill_Id");
        }
    }
}
