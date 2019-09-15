namespace XYZschool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class course : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Credits", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "Department", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Department");
            DropColumn("dbo.Courses", "Credits");
        }
    }
}
