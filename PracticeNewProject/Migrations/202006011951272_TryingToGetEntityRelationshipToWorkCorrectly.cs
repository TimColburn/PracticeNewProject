namespace PracticeNewProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TryingToGetEntityRelationshipToWorkCorrectly : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "SelectedCourseId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "SelectedCourseId");
        }
    }
}
