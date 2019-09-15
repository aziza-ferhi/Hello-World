namespace XYZschool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mcs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Moyens", "Course_CourseId", c => c.Int());
            CreateIndex("dbo.Moyens", "Course_CourseId");
            AddForeignKey("dbo.Moyens", "Course_CourseId", "dbo.Courses", "CourseId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Moyens", "Course_CourseId", "dbo.Courses");
            DropIndex("dbo.Moyens", new[] { "Course_CourseId" });
            DropColumn("dbo.Moyens", "Course_CourseId");
        }
    }
}
