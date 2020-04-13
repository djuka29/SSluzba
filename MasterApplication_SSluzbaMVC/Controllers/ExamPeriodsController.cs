using MasterApplication_SSluzbaMVC.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MasterApplication_SSluzbaMVC.Controllers
{
    public class ExamPeriodsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExamPeriods
        public ActionResult Index()
        {
            return View(db.ExamPeriods.ToList());
        }

        public ActionResult GetData()
        {

            var examPeriods = db.ExamPeriods.ToList();
            return Json(new { data = examPeriods }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {

            if (id == 0)
            {
                var examPeriodVM = new ExamPeriod();
                examPeriodVM.BegginngOfExamPeriod = DateTime.Now;
                examPeriodVM.EndingOfExamPeriod = DateTime.Now;
                return View(examPeriodVM);
            }
            else
            {
                return View(db.ExamPeriods.Where(x => x.ExamPeriodID == id).FirstOrDefault<ExamPeriod>());
            }

        }

        [HttpPost]
        public ActionResult AddOrEdit(ExamPeriod examPeriod)
        {
            if (ModelState.IsValid)
            {
                if (examPeriod.ExamPeriodID == 0)
                {


                    db.ExamPeriods.Add(examPeriod);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(examPeriod).State = EntityState.Modified;
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
                
                ExamPeriod examPeriod = db.ExamPeriods.Where(x => x.ExamPeriodID == id).FirstOrDefault<ExamPeriod>();
                db.ExamPeriods.Remove(examPeriod);
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
