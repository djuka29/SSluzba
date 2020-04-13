using System.ComponentModel.DataAnnotations;

namespace MasterApplication_SSluzbaMVC.Models
{
    public class Professor
    {
        [Key]
        [Display(Name = "Professor")]
        public int ProfessorID { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Numbers are not allowed, please enter full name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter professor's name")]
        [Display(Name = "Professor name")]
        public string ProfessorName { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Numbers are not allowed, please enter upper case academic rank")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter professor's academic rank")]
        [Display(Name = "Academic rank")]
        public string AcademicRank { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter professor's email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter professor's address")]
        [Display(Name = "Address")]
        public string Address { get; set; }


    }
}