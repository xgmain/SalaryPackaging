using SalaryPackaging.Models;

namespace SalaryPackaging.Services.Strategy
{
    public class CorporateSalaryPackagingStrategy : ISalaryPackagingStrategy
    {
        public CompanyType Company => CompanyType.Corporate;

        public decimal CalculatePackageLimit(Employee employee)
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
    }
}
