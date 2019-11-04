namespace QuickEstimationDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProjectstable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "UATSupportNeeded", c => c.Boolean());
            AddColumn("dbo.Projects", "WarrantySupportNeeded", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "WarrantySupportNeeded");
            DropColumn("dbo.Projects", "UATSupportNeeded");
        }
    }
}
