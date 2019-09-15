using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XYZschool.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public float Test { get; set; }
        public float Ptest { get; set; }
        public float Exam { get; set; }
        public double FinaleGrade { get; set; }
        public int StudentID { get; set; }
        public int CourseId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}