namespace XYZschool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vfr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OfficeAssignments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Students", "OfficeAssignment_ID", c => c.Int());
            CreateIndex("dbo.Students", "OfficeAssignment_ID");
            AddForeignKey("dbo.Students", "OfficeAssignment_ID", "dbo.OfficeAssignments", "ID");
            DropColumn("dbo.Students", "OfficeAssignment_OfficeId");
            DropColumn("dbo.Students", "OfficeAssignment_Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "OfficeAssignment_Location", c => c.String());
            AddColumn("dbo.Students", "OfficeAssignment_OfficeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Students", "OfficeAssignment_ID", "dbo.OfficeAssignments");
            DropIndex("dbo.Students", new[] { "OfficeAssignment_ID" });
            DropColumn("dbo.Students", "OfficeAssignment_ID");
            DropTable("dbo.OfficeAssignments");
        }
    }
}
