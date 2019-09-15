namespace XYZschool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdff : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Departments", "StarDate");
            DropColumn("dbo.Departments", "Administrator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Departments", "Administrator", c => c.String());
            AddColumn("dbo.Departments", "StarDate", c => c.DateTime(nullable: false));
        }
    }
}
