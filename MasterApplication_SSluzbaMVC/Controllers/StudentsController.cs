using MasterApplication_SSluzbaMVC.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MasterApplication_SSluzbaMVC.Controllers
{
    public class StudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Department);
            return View(students.ToList());
        }

        public ActionResult GetData()
        {

            var students = db.Students.Include(s => s.Department);
            return Json(new { data = students }, JsonRequestBehavior.AllowGet);
        }

        
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {

            if (id == 0)
            {
                var studentVM = new Student();
                studentVM.StudentDOB = DateTime.Now;
                ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName");
                return View(studentVM);
            }
            else
            {
                ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName");
                return View(db.Students.Where(x => x.StudentID == id).FirstOrDefault<Student>());
            }

        }

        [HttpPost]
        public ActionResult AddOrEdit(Student student)
        {
            if (ModelState.IsValid)
            {
                if (student.StudentID == 0)
                {


                    db.Students.Add(student);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(student).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Student student = db.Students.Where(x => x.StudentID == id).FirstOrDefault<Student>();
                db.Students.Remove(student);
                db.SaveChanges();

            }
            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
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
