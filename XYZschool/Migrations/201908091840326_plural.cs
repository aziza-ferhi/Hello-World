namespace XYZschool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class plural : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Moyens", "Course_CourseId", "dbo.Courses");
            DropForeignKey("dbo.Moyens", "Student_StudentID", "dbo.Students");
            DropIndex("dbo.Moyens", new[] { "Course_CourseId" });
            DropIndex("dbo.Moyens", new[] { "Student_StudentID" });
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        DS = c.Single(nullable: false),
                        TP = c.Single(nullable: false),
                        Examen = c.Single(nullable: false),
                        FinaleGrade = c.Double(nullable: false),
                        Course_CourseId = c.Int(),
                        Student_StudentID = c.Int(),
                    })
                .PrimaryKey(t => t.GradeId)
                .ForeignKey("dbo.Courses", t => t.Course_CourseId)
                .ForeignKey("dbo.Students", t => t.Student_StudentID)
                .Index(t => t.Course_CourseId)
                .Index(t => t.Student_StudentID);
            
            DropTable("dbo.Moyens");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Moyens",
                c => new
                    {
                        MoyenId = c.Int(nullable: false, identity: true),
                        DS = c.Single(nullable: false),
                        TP = c.Single(nullable: false),
                        Examen = c.Single(nullable: false),
                        Course_CourseId = c.Int(),
                        Student_StudentID = c.Int(),
                    })
                .PrimaryKey(t => t.MoyenId);
            
            DropForeignKey("dbo.Grades", "Student_StudentID", "dbo.Students");
            DropForeignKey("dbo.Grades", "Course_CourseId", "dbo.Courses");
            DropIndex("dbo.Grades", new[] { "Student_StudentID" });
            DropIndex("dbo.Grades", new[] { "Course_CourseId" });
            DropTable("dbo.Grades");
            CreateIndex("dbo.Moyens", "Student_StudentID");
            CreateIndex("dbo.Moyens", "Course_CourseId");
            AddForeignKey("dbo.Moyens", "Student_StudentID", "dbo.Students", "StudentID");
            AddForeignKey("dbo.Moyens", "Course_CourseId", "dbo.Courses", "CourseId");
        }
    }
}
