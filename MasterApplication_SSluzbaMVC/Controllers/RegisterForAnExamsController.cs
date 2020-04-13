using MasterApplication_SSluzbaMVC.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MasterApplication_SSluzbaMVC.Controllers
{
    public class RegisterForAnExamsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RegisterForAnExams
        public ActionResult Index()
        {
            var registerForExams = db.RegisterForExams.Include(r => r.Department).Include(r => r.ExamPeriod).Include(r => r.Professor).Include(r => r.Student).Include(r => r.Subject);
            return View(registerForExams.ToList());
        }

        public ActionResult GetData()
        {

            var registerForExams = db.RegisterForExams.Include(r => r.Department).Include(r => r.ExamPeriod).Include(r => r.Professor).Include(r => r.Student).Include(r => r.Subject);
            return Json(new { data = registerForExams }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {

            if (id == 0)
            {
                var registerForAnExamVM = new RegisterForAnExam();
                registerForAnExamVM.ExamDate = System.DateTime.Now;
                ViewBag.ExamPeriodID = new SelectList(db.ExamPeriods, "ExamPeriodID", "ExamPeriodName");
                //ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentNameIndex");
                ViewBag.ProfessorID = new SelectList(db.Professors, "ProfessorID", "ProfessorName");
                //ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName");
                ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName");
                return View(registerForAnExamVM);
            }
            else
            {
                ViewBag.ExamPeriodID = new SelectList(db.ExamPeriods, "ExamPeriodID", "ExamPeriodName");
                //ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentNameIndex");
                ViewBag.ProfessorID = new SelectList(db.Professors, "ProfessorID", "ProfessorName");
                //ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName");
                ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "SubjectName");
                return View(db.RegisterForExams.Where(x => x.RegisterForAnExamID == id).FirstOrDefault<RegisterForAnExam>());
            }

        }

        [Route("RegisterForAnExams/GetStudentsByDepartment?dpmId={dpmId}")]
        public JsonResult GetStudentsByDepartment(int? dpmId)
        { 
            var temp = db.Students.Where(x => dpmId.HasValue ? x.DepartmentID == dpmId.Value : true).ToList();
            return Json(temp, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetDepartmens()
        {
            var temp =  db.Departments;
            return Json(temp.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost] 
        public ActionResult AddOrEdit(RegisterForAnExam registerForAnExam) 
        {
            if (ModelState.IsValid)
            {
                if (registerForAnExam.RegisterForAnExamID == 0)
                {


                    db.RegisterForExams.Add(registerForAnExam);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(registerForAnExam).State = EntityState.Modified;
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
                
                RegisterForAnExam registerForAnExam = db.RegisterForExams.Where(x => x.RegisterForAnExamID == id).FirstOrDefault<RegisterForAnExam>();
                db.RegisterForExams.Remove(registerForAnExam);
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
