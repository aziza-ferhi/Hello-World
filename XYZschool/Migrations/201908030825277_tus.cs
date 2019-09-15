namespace XYZschool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Moyens",
                c => new
                    {
                        MoyenId = c.Int(nullable: false, identity: true),
                        DS = c.Single(nullable: false),
                        TP = c.Single(nullable: false),
                        Examen = c.Single(nullable: false),
                        Student_StudentID = c.Int(),
                    })
                .PrimaryKey(t => t.MoyenId)
                .ForeignKey("dbo.Students", t => t.Student_StudentID)
                .Index(t => t.Student_StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Moyens", "Student_StudentID", "dbo.Students");
            DropIndex("dbo.Moyens", new[] { "Student_StudentID" });
            DropTable("dbo.Moyens");
        }
    }
}
