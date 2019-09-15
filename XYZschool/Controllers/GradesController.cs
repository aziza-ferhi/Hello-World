using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XYZschool.Models;

namespace XYZschool.Controllers
{
    public class GradesController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Moyens
        public ActionResult Index()
        {
            return View(db.Grades.ToList());
        }

        // GET: Moyens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grade moyen = db.Grades.Find(id);
            if (moyen == null)
            {
                return HttpNotFound();
            }
            return View(moyen);
        }

        // GET: Moyens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Moyens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MoyenId,DS,TP,Examen,FinaleGrade")] Grade moyen)
        {
            if (ModelState.IsValid)
            {
                db.Grades.Add(moyen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moyen);
        }

        // GET: Moyens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grade moyen = db.Grades.Find(id);
            if (moyen == null)
            {
                return HttpNotFound();
            }
            return View(moyen);
        }

        // POST: Moyens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MoyenId,DS,TP,Examen,FinaleGrade")] Grade moyen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moyen);
        }

        // GET: Moyens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grade moyen = db.Grades.Find(id);
            if (moyen == null)
            {
                return HttpNotFound();
            }
            return View(moyen);
        }

        // POST: Moyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grade moyen = db.Grades.Find(id);
            db.Grades.Remove(moyen);
            db.SaveChanges();
            return RedirectToAction("Index");
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
