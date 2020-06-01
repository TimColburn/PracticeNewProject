namespace PracticeNewProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedSelectedCourseId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "SelectedCourseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "SelectedCourseId", c => c.Int(nullable: false));
        }
    }
}
