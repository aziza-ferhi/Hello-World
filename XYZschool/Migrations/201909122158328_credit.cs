namespace XYZschool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class credit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "Credits", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "Credits");
        }
    }
}
