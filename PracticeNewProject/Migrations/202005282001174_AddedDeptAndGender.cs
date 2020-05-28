namespace PracticeNewProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDeptAndGender : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.People", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.People", "Department_Id", c => c.Int());
            CreateIndex("dbo.People", "Department_Id");
            AddForeignKey("dbo.People", "Department_Id", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Department_Id", "dbo.Departments");
            DropIndex("dbo.People", new[] { "Department_Id" });
            DropColumn("dbo.People", "Department_Id");
            DropColumn("dbo.People", "Gender");
            DropTable("dbo.Departments");
        }
    }
}
