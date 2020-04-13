using System.ComponentModel.DataAnnotations;

namespace MasterApplication_SSluzbaMVC.Models
{
    public class Department
    {
        [Key]
        [Display(Name = "Department")]
        public int DepartmentID { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Numbers are not allowed, please enter department name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter department name")]
        [Display(Name = "Department name")]
        public string DepartmentName { get; set; }

        [RegularExpression(@"^[A-Z]+$", ErrorMessage = "Numbers are not allowed, please enter upper case department code")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter department code")]
        [Display(Name = "Code")]
        public string DepartmentCode { get; set; }
    }
}