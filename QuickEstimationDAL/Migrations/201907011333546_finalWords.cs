namespace QuickEstimationDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finalWords : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Assumptions", "Assumption", c => c.String(nullable: false));
            AlterColumn("dbo.EstimationVersionsHistories", "VersionSummary", c => c.String(nullable: false));
            AlterColumn("dbo.EstimationVersionsHistories", "Estimates", c => c.Single());
            AlterColumn("dbo.EstimationVersionsHistories", "Cost", c => c.Single());
            AlterColumn("dbo.EstimationVersionsHistories", "CustomerSharedEstimates", c => c.Single());
            AlterColumn("dbo.EstimationVersionsHistories", "CustomerSharedCost", c => c.Single());
            AlterColumn("dbo.EstimationVersionsHistories", "EstimationDate", c => c.DateTime());
            AlterColumn("dbo.EstimationVersionsHistories", "PMEfforts", c => c.Single());
            AlterColumn("dbo.EstimationVersionsHistories", "Created", c => c.DateTime());
            AlterColumn("dbo.EstimationVersionsHistories", "Modified", c => c.DateTime());
            AlterColumn("dbo.Projects", "ProjectName", c => c.String(nullable: false));
            AlterColumn("dbo.Catagories", "TaskCategory", c => c.String(nullable: false));
            AlterColumn("dbo.InScopes", "InScpoeItem", c => c.String(nullable: false));
            AlterColumn("dbo.OutScopes", "OutScopeItes", c => c.String(nullable: false));
            AlterColumn("dbo.ProjectReleaseEfforts_Featured", "Task", c => c.String(nullable: false));
            AlterColumn("dbo.ProjectReleaseEfforts_Featured", "TotalEfforts", c => c.Single());
            AlterColumn("dbo.ProjectReleaseEfforts_Featured", "TotalCost", c => c.Single());
            AlterColumn("dbo.VersionDetails_Phased", "Task", c => c.String(nullable: false));
            AlterColumn("dbo.VersionDetails_Phased", "Time", c => c.Single());
            AlterColumn("dbo.VersionDetails_Phased", "NoOfItems", c => c.Int());
            AlterColumn("dbo.VersionDetails_Phased", "TotalEfforts", c => c.Single());
            AlterColumn("dbo.VersionDetails_Phased", "TotalCost", c => c.Single());
            AlterColumn("dbo.VersionDetails_Featured", "Task", c => c.String(nullable: false));
            AlterColumn("dbo.VersionDetails_Featured", "Time_Requirement", c => c.Single());
            AlterColumn("dbo.VersionDetails_Featured", "Time_Design", c => c.Single());
            AlterColumn("dbo.VersionDetails_Featured", "Time_UX", c => c.Single());
            AlterColumn("dbo.VersionDetails_Featured", "Time_Development", c => c.Single());
            AlterColumn("dbo.VersionDetails_Featured", "Time_Testing", c => c.Single());
            AlterColumn("dbo.VersionDetails_Featured", "Time_Deployment", c => c.Single());
            AlterColumn("dbo.VersionDetails_Featured", "TotalEfforts", c => c.Single());
            AlterColumn("dbo.VersionDetails_Featured", "TotalCost", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VersionDetails_Featured", "TotalCost", c => c.Single(nullable: false));
            AlterColumn("dbo.VersionDetails_Featured", "TotalEfforts", c => c.Single(nullable: false));
            AlterColumn("dbo.VersionDetails_Featured", "Time_Deployment", c => c.Single(nullable: false));
            AlterColumn("dbo.VersionDetails_Featured", "Time_Testing", c => c.Single(nullable: false));
            AlterColumn("dbo.VersionDetails_Featured", "Time_Development", c => c.Single(nullable: false));
            AlterColumn("dbo.VersionDetails_Featured", "Time_UX", c => c.Single(nullable: false));
            AlterColumn("dbo.VersionDetails_Featured", "Time_Design", c => c.Single(nullable: false));
            AlterColumn("dbo.VersionDetails_Featured", "Time_Requirement", c => c.Single(nullable: false));
            AlterColumn("dbo.VersionDetails_Featured", "Task", c => c.String());
            AlterColumn("dbo.VersionDetails_Phased", "TotalCost", c => c.Single(nullable: false));
            AlterColumn("dbo.VersionDetails_Phased", "TotalEfforts", c => c.Single(nullable: false));
            AlterColumn("dbo.VersionDetails_Phased", "NoOfItems", c => c.Int(nullable: false));
            AlterColumn("dbo.VersionDetails_Phased", "Time", c => c.Single(nullable: false));
            AlterColumn("dbo.VersionDetails_Phased", "Task", c => c.String());
            AlterColumn("dbo.ProjectReleaseEfforts_Featured", "TotalCost", c => c.Single(nullable: false));
            AlterColumn("dbo.ProjectReleaseEfforts_Featured", "TotalEfforts", c => c.Single(nullable: false));
            AlterColumn("dbo.ProjectReleaseEfforts_Featured", "Task", c => c.String());
            AlterColumn("dbo.OutScopes", "OutScopeItes", c => c.String());
            AlterColumn("dbo.InScopes", "InScpoeItem", c => c.String());
            AlterColumn("dbo.Catagories", "TaskCategory", c => c.String());
            AlterColumn("dbo.Projects", "ProjectName", c => c.String());
            AlterColumn("dbo.EstimationVersionsHistories", "Modified", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EstimationVersionsHistories", "Created", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EstimationVersionsHistories", "PMEfforts", c => c.Single(nullable: false));
            AlterColumn("dbo.EstimationVersionsHistories", "EstimationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EstimationVersionsHistories", "CustomerSharedCost", c => c.Single(nullable: false));
            AlterColumn("dbo.EstimationVersionsHistories", "CustomerSharedEstimates", c => c.Single(nullable: false));
            AlterColumn("dbo.EstimationVersionsHistories", "Cost", c => c.Single(nullable: false));
            AlterColumn("dbo.EstimationVersionsHistories", "Estimates", c => c.Single(nullable: false));
            AlterColumn("dbo.EstimationVersionsHistories", "VersionSummary", c => c.String());
            AlterColumn("dbo.Assumptions", "Assumption", c => c.String());
        }
    }
}
