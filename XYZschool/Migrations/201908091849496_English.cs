namespace XYZschool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class English : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grades", "Test", c => c.Single(nullable: false));
            AddColumn("dbo.Grades", "Ptest", c => c.Single(nullable: false));
            AddColumn("dbo.Grades", "Exam", c => c.Single(nullable: false));
            DropColumn("dbo.Grades", "DS");
            DropColumn("dbo.Grades", "TP");
            DropColumn("dbo.Grades", "Examen");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Grades", "Examen", c => c.Single(nullable: false));
            AddColumn("dbo.Grades", "TP", c => c.Single(nullable: false));
            AddColumn("dbo.Grades", "DS", c => c.Single(nullable: false));
            DropColumn("dbo.Grades", "Exam");
            DropColumn("dbo.Grades", "Ptest");
            DropColumn("dbo.Grades", "Test");
        }
    }
}
