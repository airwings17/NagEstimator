namespace QuickEstimationDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedprojectUrlNamecolumninProjectstable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "projectUrlName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "projectUrlName");
        }
    }
}
