using System.ComponentModel.DataAnnotations;

namespace SalaryPackaging.Models
{
     public enum CompanyType
    {
        Corporate,
        Hospital,
        PBI
    }

    public enum EmploymentType
    {
        FullTime,
        PartTime,
        Casual
    }

    public class Employee
    {
        [Required]
        public CompanyType CompanyType { get; set; }

        [Required]
        public EmploymentType EmploymentType { get; set; }

        [Required]
        public bool IsEducated { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number.")]
        public decimal Salary { get; set; }

        [Required]
        [Range(0, 40, ErrorMessage = "Hours worked per week must be between 0 and 40.")]
        public int HoursWorkedPerWeek { get; set; }

        public decimal SalaryPackagingLimit { get; set; } = 0;
    }
}
