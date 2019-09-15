namespace XYZschool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class course1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Grade_GradeId", "dbo.Grades");
            DropIndex("dbo.Students", new[] { "Grade_GradeId" });
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StarDate = c.DateTime(nullable: false),
                        Administrator = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            AddColumn("dbo.Courses", "DepartmentId_DepartmentId", c => c.Int());
            CreateIndex("dbo.Courses", "DepartmentId_DepartmentId");
            AddForeignKey("dbo.Courses", "DepartmentId_DepartmentId", "dbo.Departments", "DepartmentId");
            DropColumn("dbo.Courses", "Department");
            DropColumn("dbo.Students", "Grade_GradeId");
            DropTable("dbo.Grades");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        GradeName = c.String(),
                        Section = c.String(),
                    })
                .PrimaryKey(t => t.GradeId);
            
            AddColumn("dbo.Students", "Grade_GradeId", c => c.Int());
            AddColumn("dbo.Courses", "Department", c => c.String());
            DropForeignKey("dbo.Courses", "DepartmentId_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Courses", new[] { "DepartmentId_DepartmentId" });
            DropColumn("dbo.Courses", "DepartmentId_DepartmentId");
            DropTable("dbo.Departments");
            CreateIndex("dbo.Students", "Grade_GradeId");
            AddForeignKey("dbo.Students", "Grade_GradeId", "dbo.Grades", "GradeId");
        }
    }
}
