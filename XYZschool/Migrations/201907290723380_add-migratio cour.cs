namespace XYZschool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigratiocour : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Title", c => c.String());
            DropColumn("dbo.Courses", "CourseName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "CourseName", c => c.String());
            DropColumn("dbo.Courses", "Title");
        }
    }
}
