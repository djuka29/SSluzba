using System;
using System.ComponentModel.DataAnnotations;

namespace MasterApplication_SSluzbaMVC.Models
{
    public class ExamPeriod
    {
        [Key]
        [Display(Name = "Exam period")]
        public int ExamPeriodID { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Numbers are not allowed, please enter exam period name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter exam period name")]
        [Display(Name = "Exam period name")]
        public string ExamPeriodName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter begginnig of exam period")]
        [Display(Name = "Begginng of exam period")]
        public DateTime BegginngOfExamPeriod { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter ending of exam period")]
        [Display(Name = "Ending of exam period")]
        public DateTime EndingOfExamPeriod { get; set; }


    }
}