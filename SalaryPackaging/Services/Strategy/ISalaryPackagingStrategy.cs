using SalaryPackaging.Models;

namespace SalaryPackaging.Services.Strategy
{
    public interface ISalaryPackagingStrategy
    {
        decimal CalculatePackageLimit(Employee employee);
        CompanyType Company { get; }
    }
}
