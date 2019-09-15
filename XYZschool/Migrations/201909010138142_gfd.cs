namespace XYZschool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gfd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Grades", "Course_CourseId", "dbo.Courses");
            DropForeignKey("dbo.Grades", "Student_StudentID", "dbo.Students");
            DropIndex("dbo.Grades", new[] { "Course_CourseId" });
            DropIndex("dbo.Grades", new[] { "Student_StudentID" });
            RenameColumn(table: "dbo.Grades", name: "Course_CourseId", newName: "CourseId");
            RenameColumn(table: "dbo.Grades", name: "Student_StudentID", newName: "StudentID");
            AlterColumn("dbo.Grades", "CourseId", c => c.Int(nullable: false));
            AlterColumn("dbo.Grades", "StudentID", c => c.Int(nullable: false));
            CreateIndex("dbo.Grades", "StudentID");
            CreateIndex("dbo.Grades", "CourseId");
            AddForeignKey("dbo.Grades", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
            AddForeignKey("dbo.Grades", "StudentID", "dbo.Students", "StudentID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grades", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Grades", "CourseId", "dbo.Courses");
            DropIndex("dbo.Grades", new[] { "CourseId" });
            DropIndex("dbo.Grades", new[] { "StudentID" });
            AlterColumn("dbo.Grades", "StudentID", c => c.Int());
            AlterColumn("dbo.Grades", "CourseId", c => c.Int());
            RenameColumn(table: "dbo.Grades", name: "StudentID", newName: "Student_StudentID");
            RenameColumn(table: "dbo.Grades", name: "CourseId", newName: "Course_CourseId");
            CreateIndex("dbo.Grades", "Student_StudentID");
            CreateIndex("dbo.Grades", "Course_CourseId");
            AddForeignKey("dbo.Grades", "Student_StudentID", "dbo.Students", "StudentID");
            AddForeignKey("dbo.Grades", "Course_CourseId", "dbo.Courses", "CourseId");
        }
    }
}
