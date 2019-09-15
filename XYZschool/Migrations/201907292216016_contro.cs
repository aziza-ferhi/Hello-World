namespace XYZschool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contro : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "OfficeAssignment_OfficeId", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "OfficeAssignment_Location", c => c.String());
            DropColumn("dbo.Students", "Office_OfficeId");
            DropColumn("dbo.Students", "Office_Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Office_Location", c => c.String());
            AddColumn("dbo.Students", "Office_OfficeId", c => c.Int(nullable: false));
            DropColumn("dbo.Students", "OfficeAssignment_Location");
            DropColumn("dbo.Students", "OfficeAssignment_OfficeId");
        }
    }
}
