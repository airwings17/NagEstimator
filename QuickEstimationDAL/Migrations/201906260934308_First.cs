namespace QuickEstimationDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        Manager = c.String(),
                        CostPerhr = c.Single(nullable: false),
                        Team = c.String(),
                        EmailLink = c.String(),
                        SketchLink = c.String(),
                        JiraLink = c.String(),
                        TechnicalApproachNeeded = c.Boolean(nullable: false),
                        EnvtSetupAndRampupNeeded = c.Boolean(nullable: false),
                        BrowserTestingNeeded = c.Boolean(nullable: false),
                        DeviceTestingNeeded = c.Boolean(nullable: false),
                        PerformanceTestingNeeded = c.Boolean(nullable: false),
                        AutomationTestingNeeded = c.Boolean(nullable: false),
                        RegressionTestingNeeded = c.Boolean(nullable: false),
                        ReleaseDocumentNeeded = c.Boolean(nullable: false),
                        AdminGuideNeeded = c.Boolean(nullable: false),
                        UserGuideNeeded = c.Boolean(nullable: false),
                        PMEffortsinPercentage = c.Single(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Projects");
        }
    }
}
