using System;
using System.ComponentModel.DataAnnotations;

namespace MasterApplication_SSluzbaMVC.Models
{
    public class RegisterForAnExam
    {
        [Key]
        [Display(Name = "Register for an exam")]
        public int RegisterForAnExamID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter exam date and time")]
        [Display(Name = "Exam date")]
        public DateTime ExamDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter exam room")]
        [Display(Name = "Exam room")]
        public string ExamRoom { get; set; }


        [Display(Name = "Department")]
        public int DepartmentID { get; set; }

        public virtual Department Department { get; set; }

        [Display(Name = "Student")]
        public int StudentID { get; set; }

        public virtual Student Student { get; set; }

        [Display(Name = "Professor")]
        public int ProfessorID { get; set; }

        public virtual Professor Professor { get; set; }

        [Display(Name = "Subject")]
        public int SubjectID { get; set; }

        public virtual Subject Subject { get; set; }

        [Display(Name = "Exam period")]
        public int ExamPeriodID { get; set; }

        public virtual ExamPeriod ExamPeriod { get; set; }



    }
}