using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XYZschool.Migrations;
using XYZschool.Models;
using XYZschool.ViewModels;
namespace XYZschool.Controllers
{
    public class Students1Controller : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Students1
        public ActionResult Index( int? id, int? courseID, int? moyenID )
        {
            var viewModel = new StudentIndexData();

            viewModel.Students = db.Students
            .Include(i => i.Courses.Select(c => c.Department))
            
                .OrderBy(i => i.LastName);
            var students = db.Students.Include(c => c.OfficeAssignment);

            if (id != null)
            {
                ViewBag.StudentID = id.Value;
                viewModel.Courses = viewModel.Students.Where(
                    i => i.StudentID == id.Value).Single().Courses;
                foreach(Course cour in viewModel.Courses)
                {
                    db.Entry(cour).Collection(x => x.Grades).Load();
                }
                
            }
            if (courseID != null)
            {
                ViewBag.CourseID = courseID.Value;
                // Lazy loading
                //viewModel.Enrollments = viewModel.Courses.Where(
                //    x => x.CourseID == courseID).Single().Enrollments;
                // Explicit loading
                var selectedCourse = viewModel.Courses.Where(x => x.CourseId == courseID).Single();

                db.Entry(selectedCourse).Collection(x => x.Grades).Load();
                if (selectedCourse.Grades != null)
                {
                    //foreach (Grade Moyen in selectedCourse.Grades)
                    //{
                    //    db.Entry(Moyen).Reference(x => x.Student).Load();
                    //}

                    //viewModel.Moyennes = selectedCourse.Grades;
                    viewModel.Grade = selectedCourse.Grades.Where(g => g.Student.StudentID == id).FirstOrDefault();
                }
            }
            
            
            return View(viewModel);
        }

        // GET: Students1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,FirstName,LastName,DateOfBirth,OfficeAssignment")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,FirstName,LastName,DateOfBirth,Photo,Height,Weight,Hobbies")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Subscribe(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.currentStudent = student;
            ViewBag.listCourses = student.Courses;
            var courses = db.Courses ;
            return View(courses.ToList());
        }
        public ActionResult Add(int? idCourse, int? idStudent )

        {
            if (idCourse == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(idCourse);
            if (course == null)
            {
                return HttpNotFound();
            }

            if (idStudent == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             Student student= db.Students.Find(idStudent) ;
            if (student == null)
            {
                return HttpNotFound();
            }
            
            student.Courses.Add(course);
            db.SaveChanges();
            return RedirectToAction("Subscribe", new { id = student.StudentID });

        }

        public ActionResult Fill(int? courseID , int? IDstudent)
        {
           
            if (courseID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(courseID);
            if (course == null)
            {
                return HttpNotFound();
            }

            if (IDstudent == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            } 
            Student student = db.Students.Find(IDstudent);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = IDstudent.Value;
            TempData["IDstudent"] = IDstudent;
           
            
            return View();
         }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Fill([Bind(Include = "Test , Ptest, Exam ")] Grade moyen  ,int? courseID) {
           
            int IDstudent = (int)TempData["IDstudent"]  ;
            TempData["IDstudent"] = IDstudent;
            Student stu = db.Students.Where(x => x.StudentID == IDstudent).FirstOrDefault();
            Course cour = db.Courses.Where(i => i.CourseId == courseID).FirstOrDefault();
            var aa = db.Grades.Where(g => g.CourseId == courseID).ToList();
            moyen.Student = stu; 
            moyen.Course = cour;
            //List<Student> sss = db.Students.ToList();
            if (ModelState.IsValid)
            {
                moyen.FinaleGrade = ((moyen.Test * 0.5) + (moyen.Ptest * 0.3) + (moyen.Exam * 1.5)) / 3;
                db.Grades.Add(moyen);
                stu.Grades.Add(moyen);
                cour.Grades.Add(moyen);
                db.SaveChanges();
                 aa = cour.Grades.ToList();








                 return RedirectToAction("Index");
                
            }

            return View(moyen);
        }
        // Get Edit marks
        public ActionResult EditMarks (int? courseID, int? IDstudent )
        {
            if (courseID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(courseID);
            if (course == null)
            {
                return HttpNotFound();
            }

            if (IDstudent == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(IDstudent);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View() ;
        }
        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMarks([Bind(Include = "Test , Ptest , Exam")] Grade moyen , int? courseID)
        {
            int IDstudent = (int)TempData["IDstudent"];
            Student stu = db.Students.Where(x => x.StudentID == IDstudent).FirstOrDefault();
            Course cour = db.Courses.Where(i => i.CourseId == courseID).FirstOrDefault();
            moyen.Student = stu;
            moyen.Course = cour;
            if (ModelState.IsValid)
            {
                db.Entry(moyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moyen);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

       
    }

}
