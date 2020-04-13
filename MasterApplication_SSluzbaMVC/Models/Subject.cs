using System.ComponentModel.DataAnnotations;

namespace MasterApplication_SSluzbaMVC.Models
{
    public class Subject
    {
        [Key]
        [Display(Name = "Subject")]
        public int SubjectID { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Numbers are not allowed, please enter subject name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter subject name")]
        [Display(Name = "Subject name")]
        public string SubjectName { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Numbers are not allowed, please enter subject code")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter subject code")]
        [Display(Name = "Code")]
        public string SubjectCode { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Semestre must be from 1 to 8")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter subject semestre")]
        [Display(Name = "Semestre")]
        public string Semestre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter ESPB")]
        [Display(Name = "ESPB")]
        public int ESPB { get; set; }
    }
}