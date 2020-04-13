using MasterApplication_SSluzbaMVC.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MasterApplication_SSluzbaMVC.Controllers
{
    public class SubjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Subjects
        public ActionResult Index()
        {
            return View(db.Subjects.ToList());
        }

        public ActionResult GetData()
        {

            var subjects = db.Subjects.ToList();
            return Json(new { data = subjects }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Subject());
            }
            else
            {
                return View(db.Subjects.Where(x => x.SubjectID == id).FirstOrDefault<Subject>());
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Subject subject)
        {
            if (ModelState.IsValid)
            {
                if (subject.SubjectID == 0)
                {


                    db.Subjects.Add(subject);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(subject).State = EntityState.Modified;
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
                //Candidate candidate = db.Candidates.Find(id);
                Subject subject = db.Subjects.Where(x => x.SubjectID == id).FirstOrDefault<Subject>();
                db.Subjects.Remove(subject);
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
