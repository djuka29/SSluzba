using MasterApplication_SSluzbaMVC.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MasterApplication_SSluzbaMVC.Controllers
{
    public class ProfessorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Professors
        public ActionResult Index()
        {
            return View(db.Professors.ToList());
        }

        public ActionResult GetData()
        {

            var professors = db.Professors.ToList();
            return Json(new { data = professors }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {

            if (id == 0)
            {

                return View(new Professor());
            }
            else
            {
                return View(db.Professors.Where(x => x.ProfessorID == id).FirstOrDefault<Professor>());
            }

        }

        [HttpPost]
        public ActionResult AddOrEdit(Professor professor)
        {
            if (ModelState.IsValid)
            {
                if (professor.ProfessorID == 0)
                {


                    db.Professors.Add(professor);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(professor).State = EntityState.Modified;
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
                Professor professor = db.Professors.Where(x => x.ProfessorID == id).FirstOrDefault<Professor>();
                db.Professors.Remove(professor);
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
