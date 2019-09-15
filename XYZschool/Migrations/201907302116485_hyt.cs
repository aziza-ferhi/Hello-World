namespace XYZschool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hyt : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "Height");
            DropColumn("dbo.Students", "Weight");
            DropColumn("dbo.Students", "Hobbies");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Hobbies", c => c.String());
            AddColumn("dbo.Students", "Weight", c => c.Single(nullable: false));
            AddColumn("dbo.Students", "Height", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
