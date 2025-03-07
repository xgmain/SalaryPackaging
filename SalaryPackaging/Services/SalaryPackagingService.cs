using SalaryPackaging.Models;
using System.Collections.Generic;
using System.Linq;
using SalaryPackaging.Services.Strategy;

namespace SalaryPackaging.Services
{
    public class SalaryPackagingService : ISalaryPackagingService
    {
        private readonly Dictionary<CompanyType, ISalaryPackagingStrategy> _strategies;

        public SalaryPackagingService(IEnumerable<ISalaryPackagingStrategy> strategies)
        {
            _strategies = strategies.ToDictionary(strategy => strategy.Company);
        }
        public decimal CalculatePackageLimit(Employee employee)
        {

            if (employee == null || employee.Salary <= 0)
                return 0; // Invalid input

            if (_strategies.TryGetValue(employee.CompanyType, out var strategy))
                return strategy.CalculatePackageLimit(employee);

            return 0; // Invalid company type
        }

    }
}
