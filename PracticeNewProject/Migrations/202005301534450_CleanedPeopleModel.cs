namespace PracticeNewProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CleanedPeopleModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.People", "Position_Id", "dbo.Positions");
            DropIndex("dbo.People", new[] { "Department_Id" });
            DropIndex("dbo.People", new[] { "Position_Id" });
            DropColumn("dbo.People", "Gender");
            DropColumn("dbo.People", "Department_Id");
            DropColumn("dbo.People", "Position_Id");
            DropTable("dbo.Departments");
            DropTable("dbo.Positions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.People", "Position_Id", c => c.Int());
            AddColumn("dbo.People", "Department_Id", c => c.Int());
            AddColumn("dbo.People", "Gender", c => c.Int(nullable: false));
            CreateIndex("dbo.People", "Position_Id");
            CreateIndex("dbo.People", "Department_Id");
            AddForeignKey("dbo.People", "Position_Id", "dbo.Positions", "Id");
            AddForeignKey("dbo.People", "Department_Id", "dbo.Departments", "Id");
        }
    }
}
