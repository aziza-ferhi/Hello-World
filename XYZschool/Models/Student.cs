using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XYZschool.Models
{
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }
        public int StudentID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public OfficeAssignment OfficeAssignment { get; set; }
       
        public virtual ICollection<Course> Courses { get; set; }
        public  ICollection<Grade>  Grades { get; set; }
    }
}
