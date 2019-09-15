using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace XYZschool.Models
{
    public class SchoolContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SchoolContext() : base("name=SchoolContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolContext,
       XYZschool.Migrations.Configuration>("SchoolContext"));
        }

        public System.Data.Entity.DbSet<XYZschool.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<XYZschool.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<XYZschool.Models.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<XYZschool.Models.OfficeAssignment> OfficeAssignments { get; set; }

        public System.Data.Entity.DbSet<XYZschool.Models.Grade> Grades { get; set; }
    }
}
