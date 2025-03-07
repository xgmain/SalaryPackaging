using SalaryPackaging.Models;

namespace SalaryPackaging.Services.Strategy
{
    public class PBISalaryPackagingStrategy : ISalaryPackagingStrategy
    {
        public CompanyType Company => CompanyType.PBI;

        public decimal CalculatePackageLimit(Employee employee)
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
