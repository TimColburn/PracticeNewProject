namespace PracticeNewProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CleanedUpEditView : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "UserName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "UserName", c => c.String());
        }
    }
}
