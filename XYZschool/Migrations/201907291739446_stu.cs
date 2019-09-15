namespace XYZschool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Office_OfficeId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "Office_Location", c => c.String());
            DropColumn("dbo.Students", "Photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Photo", c => c.Binary());
            DropColumn("dbo.Students", "Office_Location");
            DropColumn("dbo.Students", "Office_OfficeId");
        }
    }
}
