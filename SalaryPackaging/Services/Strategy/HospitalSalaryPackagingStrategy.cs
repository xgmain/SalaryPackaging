using SalaryPackaging.Models;

namespace SalaryPackaging.Services.Strategy
{
    public class HospitalSalaryPackagingStrategy : ISalaryPackagingStrategy
    {
        public CompanyType Company => CompanyType.Hospital;

        public decimal CalculatePackageLimit(Employee employee)
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
    }
}
