namespace TodoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialdatabasedefinition : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        NoteId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        TaskId = c.Int(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.NoteId)
                .ForeignKey("dbo.Tasks", t => t.TaskId)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        StatusId = c.Int(),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.StatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Notes", "TaskId", "dbo.Tasks");
            DropIndex("dbo.Tasks", new[] { "StatusId" });
            DropIndex("dbo.Notes", new[] { "TaskId" });
            DropTable("dbo.Tasks");
            DropTable("dbo.Status");
            DropTable("dbo.Notes");
        }
    }
}
