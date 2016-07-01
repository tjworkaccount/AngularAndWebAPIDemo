namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Samples",
                c => new
                    {
                        SampleId = c.Int(nullable: false, identity: true),
                        Barcode = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, storeType: "date"),
                        CreatedBy = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SampleId)
                .ForeignKey("dbo.Users", t => t.CreatedBy, cascadeDelete: true)
                .ForeignKey("dbo.Statuses", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.CreatedBy)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Statuses",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Samples", "StatusId", "dbo.Statuses");
            DropForeignKey("dbo.Samples", "CreatedBy", "dbo.Users");
            DropIndex("dbo.Samples", new[] { "StatusId" });
            DropIndex("dbo.Samples", new[] { "CreatedBy" });
            DropTable("dbo.Statuses");
            DropTable("dbo.Users");
            DropTable("dbo.Samples");
        }
    }
}