namespace CodeMeter.HttpService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Guid = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                        Client = c.String(maxLength: 256),
                        Description = c.String(maxLength: 2048),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 2048),
                        ProjectID = c.Int(nullable: false),
                        IsRunning = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.TaskLogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TaskID = c.Int(nullable: false),
                        Start = c.DateTime(),
                        End = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tasks", t => t.TaskID, cascadeDelete: true)
                .Index(t => t.TaskID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.TaskLogs", "TaskID", "dbo.Tasks");
            DropIndex("dbo.TaskLogs", new[] { "TaskID" });
            DropIndex("dbo.Tasks", new[] { "ProjectID" });
            DropTable("dbo.TaskLogs");
            DropTable("dbo.Tasks");
            DropTable("dbo.Projects");
        }
    }
}
