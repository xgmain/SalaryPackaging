using SalaryPackaging.Models;

namespace SalaryPackaging.Services
{
    public class SalaryPackagingService : ISalaryPackagingService
    {
        public decimal CalculatePackageLimit(Employee employee)
        {
            if (employee == null || employee.Salary <= 0)
                return 0; // Invalid input

            decimal packageLimit = 0;

            switch (employee.CompanyType)
            {
                case CompanyType.Corporate:
                    packageLimit = CalculateCorporateLimit(employee);
                    break;
                case CompanyType.Hospital:
                    packageLimit = CalculateHospitalLimit(employee);
                    break;
                case CompanyType.PBI:
                    packageLimit = CalculatePBILimit(employee);
                    break;
                default:
                    return 0; // Invalid company type
            }

            return packageLimit;
        }

        private decimal CalculateCorporateLimit(Employee employee)
        {
            if (employee.EmploymentType == EmploymentType.Casual)
                return 0;

            decimal baseLimit = employee.Salary <= 100000
                ? employee.Salary * 0.01m
                : (100000 * 0.01m) + ((employee.Salary - 100000) * 0.001m);

            if (employee.EmploymentType == EmploymentType.PartTime)
            {
                decimal percentage = Math.Min(1, (decimal)employee.HoursWorkedPerWeek / 38);
                baseLimit *= percentage;
            }

            return baseLimit;
        }

        private decimal CalculateHospitalLimit(Employee employee)
        {
            decimal baseLimit = Math.Max(10000, employee.Salary * 0.2m);
            baseLimit = Math.Min(baseLimit, 30000);

            if (employee.IsEducated)
                baseLimit += 5000;

            if (employee.EmploymentType == EmploymentType.FullTime)
            {
                baseLimit *= 1.095m;
                baseLimit += employee.Salary * 0.012m;
            }

            return baseLimit;
        }

        private decimal CalculatePBILimit(Employee employee)
        {
            decimal baseLimit = Math.Min(50000, employee.Salary * 0.3255m);

            if (employee.EmploymentType == EmploymentType.Casual)
                return employee.Salary * 0.1m;

            if (employee.IsEducated)
                baseLimit += 2000 + (employee.Salary * 0.01m);

            if (employee.EmploymentType == EmploymentType.PartTime)
                baseLimit *= 0.8m;

            return baseLimit;
        }
    }
}
