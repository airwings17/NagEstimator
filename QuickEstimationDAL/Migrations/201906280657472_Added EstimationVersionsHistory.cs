namespace QuickEstimationDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEstimationVersionsHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EstimationVersionsHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        EstimationType = c.String(),
                        VersionSummary = c.String(),
                        Estimates = c.Single(nullable: false),
                        Cost = c.Single(nullable: false),
                        CustomerSharedEstimates = c.Single(nullable: false),
                        CustomerSharedCost = c.Single(nullable: false),
                        EstimationDate = c.DateTime(nullable: false),
                        PMEfforts = c.Single(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        EstimatedBy = c.String(),
                        ReviewedBy = c.String(),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            AlterColumn("dbo.Projects", "CostPerhr", c => c.Single());
            AlterColumn("dbo.Projects", "TechnicalApproachNeeded", c => c.Boolean());
            AlterColumn("dbo.Projects", "EnvtSetupAndRampupNeeded", c => c.Boolean());
            AlterColumn("dbo.Projects", "BrowserTestingNeeded", c => c.Boolean());
            AlterColumn("dbo.Projects", "DeviceTestingNeeded", c => c.Boolean());
            AlterColumn("dbo.Projects", "PerformanceTestingNeeded", c => c.Boolean());
            AlterColumn("dbo.Projects", "AutomationTestingNeeded", c => c.Boolean());
            AlterColumn("dbo.Projects", "RegressionTestingNeeded", c => c.Boolean());
            AlterColumn("dbo.Projects", "ReleaseDocumentNeeded", c => c.Boolean());
            AlterColumn("dbo.Projects", "AdminGuideNeeded", c => c.Boolean());
            AlterColumn("dbo.Projects", "UserGuideNeeded", c => c.Boolean());
            AlterColumn("dbo.Projects", "PMEffortsinPercentage", c => c.Single());
            AlterColumn("dbo.Projects", "Created", c => c.DateTime());
            AlterColumn("dbo.Projects", "Modified", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EstimationVersionsHistories", "ProjectId", "dbo.Projects");
            DropIndex("dbo.EstimationVersionsHistories", new[] { "ProjectId" });
            AlterColumn("dbo.Projects", "Modified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "Created", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "PMEffortsinPercentage", c => c.Single(nullable: false));
            AlterColumn("dbo.Projects", "UserGuideNeeded", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Projects", "AdminGuideNeeded", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Projects", "ReleaseDocumentNeeded", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Projects", "RegressionTestingNeeded", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Projects", "AutomationTestingNeeded", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Projects", "PerformanceTestingNeeded", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Projects", "DeviceTestingNeeded", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Projects", "BrowserTestingNeeded", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Projects", "EnvtSetupAndRampupNeeded", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Projects", "TechnicalApproachNeeded", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Projects", "CostPerhr", c => c.Single(nullable: false));
            DropTable("dbo.EstimationVersionsHistories");
        }
    }
}
