namespace QuickEstimationDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedallTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assumptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VersionID = c.Int(nullable: false),
                        Assumption = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EstimationVersionsHistories", t => t.VersionID, cascadeDelete: true)
                .Index(t => t.VersionID);
            
            CreateTable(
                "dbo.InScopes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VersionID = c.Int(nullable: false),
                        InScpoeItem = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EstimationVersionsHistories", t => t.VersionID, cascadeDelete: true)
                .Index(t => t.VersionID);
            
            CreateTable(
                "dbo.OutScopes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VersionID = c.Int(nullable: false),
                        OutScopeItes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EstimationVersionsHistories", t => t.VersionID, cascadeDelete: true)
                .Index(t => t.VersionID);
            
            CreateTable(
                "dbo.ProjectReleaseEfforts_Featured",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VersionID = c.Int(nullable: false),
                        Task = c.String(),
                        TotalEfforts = c.Single(nullable: false),
                        TotalCost = c.Single(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EstimationVersionsHistories", t => t.VersionID, cascadeDelete: true)
                .Index(t => t.VersionID);
            
            CreateTable(
                "dbo.VersionDetails_Phased",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VersionID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        Task = c.String(),
                        SubTask = c.String(),
                        Time = c.Single(nullable: false),
                        NoOfItems = c.Int(nullable: false),
                        TotalEfforts = c.Single(nullable: false),
                        TotalCost = c.Single(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Catagories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.EstimationVersionsHistories", t => t.VersionID, cascadeDelete: true)
                .Index(t => t.VersionID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.VersionDetails_Featured",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VersionID = c.Int(nullable: false),
                        Task = c.String(),
                        SubTask = c.String(),
                        Time_Requirement = c.Single(nullable: false),
                        Time_Design = c.Single(nullable: false),
                        Time_UX = c.Single(nullable: false),
                        Time_Development = c.Single(nullable: false),
                        Time_Testing = c.Single(nullable: false),
                        Time_Deployment = c.Single(nullable: false),
                        TotalEfforts = c.Single(nullable: false),
                        TotalCost = c.Single(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EstimationVersionsHistories", t => t.VersionID, cascadeDelete: true)
                .Index(t => t.VersionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VersionDetails_Featured", "VersionID", "dbo.EstimationVersionsHistories");
            DropForeignKey("dbo.VersionDetails_Phased", "VersionID", "dbo.EstimationVersionsHistories");
            DropForeignKey("dbo.VersionDetails_Phased", "CategoryID", "dbo.Catagories");
            DropForeignKey("dbo.ProjectReleaseEfforts_Featured", "VersionID", "dbo.EstimationVersionsHistories");
            DropForeignKey("dbo.OutScopes", "VersionID", "dbo.EstimationVersionsHistories");
            DropForeignKey("dbo.InScopes", "VersionID", "dbo.EstimationVersionsHistories");
            DropForeignKey("dbo.Assumptions", "VersionID", "dbo.EstimationVersionsHistories");
            DropIndex("dbo.VersionDetails_Featured", new[] { "VersionID" });
            DropIndex("dbo.VersionDetails_Phased", new[] { "CategoryID" });
            DropIndex("dbo.VersionDetails_Phased", new[] { "VersionID" });
            DropIndex("dbo.ProjectReleaseEfforts_Featured", new[] { "VersionID" });
            DropIndex("dbo.OutScopes", new[] { "VersionID" });
            DropIndex("dbo.InScopes", new[] { "VersionID" });
            DropIndex("dbo.Assumptions", new[] { "VersionID" });
            DropTable("dbo.VersionDetails_Featured");
            DropTable("dbo.VersionDetails_Phased");
            DropTable("dbo.ProjectReleaseEfforts_Featured");
            DropTable("dbo.OutScopes");
            DropTable("dbo.InScopes");
            DropTable("dbo.Assumptions");
        }
    }
}
