namespace XYZschool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xyz : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Courses", name: "DepartmentId_DepartmentId", newName: "Department_DepartmentId");
            RenameIndex(table: "dbo.Courses", name: "IX_DepartmentId_DepartmentId", newName: "IX_Department_DepartmentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Courses", name: "IX_Department_DepartmentId", newName: "IX_DepartmentId_DepartmentId");
            RenameColumn(table: "dbo.Courses", name: "Department_DepartmentId", newName: "DepartmentId_DepartmentId");
        }
    }
}
