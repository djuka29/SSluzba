using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterApplication_SSluzbaMVC.Models
{
    public class Student
    {
        [Key]
        [Display(Name = "Student")]
        public int StudentID { get; set; }

        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Numbers are not allowed, please enter full name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter full name")]
        [Display(Name = "Student name")]
        public string StudentName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter index number")]
        [Display(Name = "Index number")]
        public string IndexNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter date of birth")]
        [Display(Name = "Date of birth")]
        public DateTime StudentDOB { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter year of studies")]
        [Range(1, 5, ErrorMessage = "Please enter year from 1 to 5")]
        [Display(Name = "Year of studies")]
        public int YearOfStudies { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter address")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter valid email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter way of financing")]
        [Display(Name = "On budget")]
        public bool IsBudget { get; set; }

        
        [Display(Name = "Department")]
        public int? DepartmentID { get; set; }

        public virtual Department Department { get; set; }

        [NotMapped]
        public string StudentNameIndex { get => StudentName + " " + IndexNumber; }
    }
}