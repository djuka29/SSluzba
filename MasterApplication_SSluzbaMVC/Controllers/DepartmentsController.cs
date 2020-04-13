using MasterApplication_SSluzbaMVC.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MasterApplication_SSluzbaMVC.Controllers
{
    public class DepartmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Departments
        public ActionResult Index()
        {
            return View(db.Departments.ToList());
        }

        public ActionResult GetData()
        {

            var departments = db.Departments.ToList();
            return Json(new { data = departments }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {

            if (id == 0)
            {
                return View(new Department());
            }
            else
            {
                return View(db.Departments.Where(x => x.DepartmentID == id).FirstOrDefault<Department>());
            }

        }

        [HttpPost]
        public ActionResult AddOrEdit(Department department)
        {
            if (ModelState.IsValid)
            {
                if (department.DepartmentID == 0)
                {


                    db.Departments.Add(department);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(department).State = EntityState.Modified;
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
                
                Department department = db.Departments.Where(x => x.DepartmentID == id).FirstOrDefault<Department>();
                db.Departments.Remove(department);
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
